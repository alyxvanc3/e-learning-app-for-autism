using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SentenceManager : MonoBehaviour {
    public GameObject[] Sentences;
    public int counter;
    [SerializeField]
    private int size;

    private GameObject Down;
    private GameObject Up;

    static SentenceManager instance = null;

    public static SentenceManager Instance {
        get {
            return instance;
        }
    }

    void Awake() {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else if (instance == null) {
            instance = this;

        }
    }

    public void Start() {
        counter = 0;
        size = Sentences.Length;

        Down = GameObject.FindGameObjectWithTag("asagi");
        Up = GameObject.FindGameObjectWithTag("yukari");
        Up.SetActive(false);
    }

    public void PreviousSentence() {
        if(counter > 0)
        {
            if (!Down.activeInHierarchy)
            {
                Down.SetActive(true);
            }
            Sentences[counter].SetActive(false);
            counter--;
            Sentences[counter].SetActive(true);
            if (counter == 0)
            {
                Up.SetActive(false);
            }
        }
    }

    public void NextSentence() {
        if(counter < size - 1) {
            if (!Up.activeInHierarchy)
            {
                Up.SetActive(true);
            }
            Sentences[counter].SetActive(false);
            counter++;
            Sentences[counter].SetActive(true);
            if (counter == size - 1)
            {
                Down.SetActive(false);
            }
        }
    }


}
