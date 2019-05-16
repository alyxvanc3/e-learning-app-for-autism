using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Sprite[] Pps;
    public Sprite CurrentPp;
    public Text KullaniciAdi;
    private static MenuController _instance = null;
    public static MenuController Instance
    {
        get
        {
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else if (_instance == null)
        {
            _instance = this;
        }
    }

    public GameObject[] MenuObjects;

    void Start ()
    {
        DisableAll();
        if (PlayerManager.Instance.CurrentProfile != null)
        {
            LoadMenu(5);
        }
        else
        {
            LoadMenu(0);
        }

    }

    public void LoadMenu(int index)
    {
        DisableAll();
        MenuObjects[index].SetActive(true);

        if (index == 5)
        {
            ProfileEntered();
        }
        if (index == 0)
        {
            MenuObjects[3].SetActive(true);
            MenuObjects[4].SetActive(true);
        }

    }

    public void ProfileEntered()
    {
        MenuObjects[0].SetActive(true);
        KullaniciAdi.text = PlayerManager.Instance.CurrentProfile[1];
        var photoId = 0;
        int.TryParse(PlayerManager.Instance.CurrentProfile[4], out photoId);
    
        CurrentPp = GameObject.FindGameObjectWithTag("kullanıcı").GetComponent<Image>().sprite 
                                                                            = Pps[photoId];
       
        

    }

    public void DisableAll()
    {
        foreach (GameObject obj in MenuObjects)
        {
            obj.SetActive(false);
        }
    }

    public void LogOut()
    {
        PlayerManager.Instance.CurrentProfile = null;
        LevelManager.Instance.LoadLevel("Baslangic");
    }
}
