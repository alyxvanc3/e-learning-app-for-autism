using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Odullendirme : MonoBehaviour
{
    public Animator Anim;
    public int dogru = 0;


    private static Odullendirme instance = null;

    public static Odullendirme Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void AnimDogru()
    {
        Anim.SetTrigger("dogru");
        dogru = 1;
    }

    public void AnimBasardin()
    {
        Anim.SetTrigger("basardin");
        dogru = 0;

        if (PlayerManager.Instance.CurrentProfile != null)
        {
            Scoring();
        }

    }

    public void Scoring()
    {
        // skor artırma
        int currentTag;
        int.TryParse(tag, out currentTag);


        int score = 0;
        int.TryParse(PlayerManager.Instance.CurrentProfile[currentTag + 4], out score);
        score++;


        // skoru kaydetme
        PlayerManager.Instance.CurrentProfile[currentTag + 4] = score.ToString();
        PlayerPrefs.SetString(PlayerManager.Instance.CurrentProfile[1] + " Skor" + tag, score.ToString());
    }


}