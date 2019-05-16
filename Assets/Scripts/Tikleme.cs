using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tikleme : MonoBehaviour {

    public Image[] tikler;
    public Sprite tikli;

    static Tikleme()
    {
        Instance = null;
    }

    public static Tikleme Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start ()
    {
        for (int i = 0; i < 7; i++)
        {
            int skor;
            if (PlayerManager.Instance.CurrentProfile == null) return;
            int.TryParse(PlayerManager.Instance.CurrentProfile[5 + i], out skor);
            if ( skor > 5)
            {
                tikler[i].sprite = tikli;
            }
        }
        
        

    }
	
}
