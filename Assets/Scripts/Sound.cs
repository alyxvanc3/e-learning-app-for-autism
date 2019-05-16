using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    static Sound instance = null;
    public static Sound Instance {
        get {
            return instance;
        }
    }

    void Awake() {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else if (instance == null) {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    public AudioSource backgroundAudio;
    public bool toggle = true;
    private void Start()
    {
        backgroundAudio = instance.GetComponent<AudioSource>();
    }

    public void OffOn()
    {
        backgroundAudio.mute = !backgroundAudio.mute;
    }
    public void toggleSound()
    {
        toggle = !toggle;

        if (toggle)
            AudioListener.volume = 1f;

        else
            AudioListener.volume = 0f;
    }
}
