using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{


    public Question[] questions;

    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    [SerializeField]
    private Text trueAnswerText;
    [SerializeField]
    private Image trueAnswerImage;
    [SerializeField]
    private Text falseAnswerText;
    [SerializeField]
    private Image falseAnswerImage;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    [SerializeField]
    Animator animator;

    void Start()
    {
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
       // Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

       factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "DOĞRU!";
            falseAnswerText.text = "YANLIŞ!";
        }else
        {
            trueAnswerText.text = "YANLIŞ!";
            falseAnswerText.text = "DOĞRU!";
        }
    }


    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue()
    {

        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            Debug.Log("CORRECT");
            GameManager.totalScore += 3;
        }
        else
        {
            Debug.Log("WRONG");
            GameManager.totalScore -= 1;
        }

        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (! currentQuestion.isTrue)
        {
          
            Debug.Log("CORRECT");
            GameManager.totalScore += 3;
        }
        else
        {
            Debug.Log("WRONG");
            GameManager.totalScore -= 1;
        }

        StartCoroutine(TransitionToNextQuestion());
    }
}
