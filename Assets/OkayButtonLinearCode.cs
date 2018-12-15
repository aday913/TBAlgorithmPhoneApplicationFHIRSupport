using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OkayButtonLinearCode : MonoBehaviour {
    public int TargetScene;
    public void NextSceneOnClick(string input)
    {
        int Case = GameObject.FindGameObjectWithTag("Manager").GetComponent<Settings>().QuestionType;
       
        if (Case != 1)
        {
            Debug.Log("Should be trying to load next scene");
            SceneManager.LoadScene(TargetScene);
        }
        else
        {
            string FHIR_Information = input;

            var Fhir_Client = new FhirClient("http://stu3.test.pyrohealth.net/fhir");
            Fhir_Client.Timeout = (60 * 1000);

            Hl7.Fhir.Model.Bundle ReturnedSearchBundle = Fhir_Client.Search<Hl7.Fhir.Model.Observation>(new string[] { "patient=Patient/" + FHIR_Information});

            string id = "";

            foreach (var Entry in ReturnedSearchBundle.Entry)
            {
                id = Entry.Resource.Id;
            }

            var obs = Fhir_Client.Read<Observation>("Observation/" + id);

            if (obs.Code.Coding[0].Code == "23537-4")
            {

                if (obs.Interpretation.Coding[0].Code == "H")
                {
                    SceneManager.LoadScene(13);
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
