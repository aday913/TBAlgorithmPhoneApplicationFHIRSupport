using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OkayButtonLinearCode : MonoBehaviour {
    public int TargetScene;
    public void NextSceneOnClick(string input)
    {
        int Case = GameObject.FindGameObjectWithTag("Manager").GetComponent<Settings>().QuestionType;
        Debug.Log("CASE: " + Case);
        Debug.Log("TESTING: " + input);

        int comparison = 1;

        if (Case != 1)
        {
            SceneManager.LoadScene(TargetScene);
        }
        else
        {
            string FHIR_Information = input;
            Debug.Log("From OB script: " + FHIR_Information);

            var Fhir_Client = new FhirClient("http://stu3.test.pyrohealth.net/fhir");
            Fhir_Client.Timeout = (60 * 1000);

            Debug.Log("patient=Patient/" + FHIR_Information);

            Hl7.Fhir.Model.Bundle ReturnedSearchBundle = Fhir_Client.Search<Hl7.Fhir.Model.Observation>(new string[] { "patient=Patient/" + FHIR_Information});

            Debug.Log("GOT A BUNDLE");

            string id = "";

            foreach (var Entry in ReturnedSearchBundle.Entry)
            {
                Debug.Log(Entry.Resource.Id);
                id = Entry.Resource.Id;
            }

            Debug.Log(id);

            var obs = Fhir_Client.Read<Observation>("Observation/" + id);

            Debug.Log("WE HAVE READ THE OBSERVATION");
            Debug.Log(obs.Interpretation.Coding[0].Code);
            Debug.Log(obs.Code.Coding[0].Code);
            Debug.Log(obs.Code.Coding[0].Code.GetType());

            if (obs.Code.Coding[0].Code == "23537-4")
            {
                Debug.Log("WE HAVE MOVED INTO THE LOINC IF");

                if (obs.Interpretation.Coding[0].Code == "H")
                {
                    SceneManager.LoadScene(13);
                    Debug.Log("Should have loaded in scene 13");
                }
                else
                {
                    SceneManager.LoadScene(9);
                }
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
