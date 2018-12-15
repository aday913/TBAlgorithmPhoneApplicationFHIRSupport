using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {
    /*
     Assign QuestionType a number on a scale of 1-10, it will represent the question type.
     1=TextInput
     2=Yes or No Question
     3=MultipleChoice
     4=SelectAllThatApply
     5=TextOutput
    
     Write the Question in the Question variable as a string.

     Write the buildIndex number into GoToScene as an integer, this is the scene to go to if the question is linear.
     
     Set the MultiScene bool to true if the question is non-linear and must branch into different scenes. 
     
     List the buildIndexes of scenes that will be needed for the question as integers, and then set the required response for each one.
     So far, I can only think of using integers to represent options in multiple choice as 1,2,3 for options A, B, or C. If the
     question is a yes or no, then 1, 2 are used respectively. Select all that apply is not yet supported for this system.
     IMPORTANT: Make sure the size of each array is the same!
     
     If the Question type is multiple choice, then make sure to set the choices in the MultipleChoiceChoices array.
    */
    public int QuestionType;
    public string Question;
    public int GoToScene;

    public bool MultiScene;
    public int[] GoToScenes;
    //public int[] RequiredResponse;

    public string[] MultipleChoiceChoices;
    public bool[] choices; //used for select all that apply, it will be an array of chosen size to keep track of user's selections.

    public string userInput; //This variable will store what the user typed into the text box. 
    public int Response;
    //I will look into saving this to a persistant data array that will contain all answers given by user.
    //These are just variables used for prefabs of every single survey component, don't change these.
    public GameObject QuestionBox; 
    public GameObject OkayButtonLinear;
    public GameObject OkayButtonNonLinear;
    public GameObject TextInput;
    public GameObject YesNoButtons;
    public GameObject MultipleChoice;
    public GameObject SATA;


    private void GenerateQuestion()
    {
        GameObject question = Instantiate(QuestionBox, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        question.GetComponent<Text>().text = Question;
        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        if (MultiScene)
        {
            GameObject okayButton = Instantiate(OkayButtonNonLinear, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            okayButton.GetComponent<OkayButtonNonLinearCode>().Scenes = GoToScenes;
            okayButton.GetComponent<OkayButtonNonLinearCode>().choice = Response; //Remember to set this according to answer provided by user.
            //Remember scenes are in order from 0 to size of array. My code takes this into account by subtracting one from
            //the value of array index you want. Choice here is referring to the first option in GoToScenes array.
            //Set button's options to those of the user
        }
        else
        {
            GameObject okayButton = Instantiate(OkayButtonLinear, GameObject.FindGameObjectWithTag("MainCanvas").transform);
            okayButton.GetComponent<OkayButtonLinearCode>().TargetScene = GoToScene;
            //Set button's sceneIndex to the one set by the user.
        }
        switch (QuestionType) //Reminder: 1=TextInput, 2=YorN Question, 3=MultipleChoice, 4=SATA, 5=TextOutput
        {
            case 1: //Looks confusing, but Instantiate simply spawns the necessary survey components in their predetermined positions.
                //The parent of each survey component is always set to the maincanvas to facilitate this.
                Instantiate(TextInput, GameObject.FindGameObjectWithTag("MainCanvas").transform);
                break;
            case 2:
                Instantiate(YesNoButtons, GameObject.FindGameObjectWithTag("MainCanvas").transform);
                break;
            case 3:
                GameObject mc = Instantiate(MultipleChoice, GameObject.FindGameObjectWithTag("MainCanvas").transform);
                mc.GetComponent<Dropdown>().options.Clear();
                foreach (string c in MultipleChoiceChoices)
                {
                    mc.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = c });
                }
                break;
            case 4:
                //Select all that apply code, convoluted like crazy, but works.
                for (int i=(MultipleChoiceChoices.Length-1);i>=0;i--)
                {
                    GameObject sata = Instantiate(SATA, GameObject.FindGameObjectWithTag("MainCanvas").transform);
                    sata.GetComponent<SATAScript>().order = i;
                    sata.GetComponent<RectTransform>().Find("Label").gameObject.GetComponent<Text>().text = MultipleChoiceChoices[i];
                    sata.GetComponent<RectTransform>().localPosition = new Vector2(0, -(i * 64 + 20) ); //10 is just an arbitrary spacing value
                }
                break;
            case 5:
                //Text output case, in which only the "question" (which is actually just a text output) shows up with an "okay" at the bottom
                //Thus, there is nothing else to instantiate except for the text output ("question") and the okay button, which are already instantiated
                break;
        }
    }
    public void Start()
    {
        GenerateQuestion();
    }
}
