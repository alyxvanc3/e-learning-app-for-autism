using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private string[] _currentP;
    
    public string[] CurrentProfile {
        get { return _currentP; }
        set { _currentP = value; } }

    public int AvatarSelection = 0;

    private static PlayerManager _instance = null;
    public static PlayerManager Instance
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
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        string nick = PlayerPrefs.GetString("LastEnteredNick", null);
        if ( nick == null)
        {
            CurrentProfile = null;
        }
        else
        {
            GetProfile(nick);
        }
        
    }

    public void EnterwithProfile()
    {
        var profileInfo = new string[2];
        profileInfo[0] = GameObject.FindGameObjectWithTag("Kullanıcı Adı").GetComponent<Text>().text;
        profileInfo[1] = GameObject.FindGameObjectWithTag("Şifre").GetComponent<Text>().text;
        PlayerPrefs.SetString("LastEnteredNick", profileInfo[0]);

        if (PlayerPrefs.GetString(profileInfo[0] + " Kullanıcı Adı") == profileInfo[0]
                 && PlayerPrefs.GetString(profileInfo[0] + " Şifre") == profileInfo[1])
        {
            GetProfile(profileInfo[0]);

            MenuController.Instance.LoadMenu(5);
        }

        else
        {
            Debug.Log("Yanlis sifre ya da kullanici adi");
        }
    }

    public void SelectAvatar(int i)
    {
        AvatarSelection = i;
    }

    public void SaveProfile()
    {
        // Profil icin kayit bilgilerinin olusturulmasi
        var profileInfo = new string[12];
        profileInfo[0] = GameObject.FindGameObjectWithTag("Ad Soyad").GetComponent<Text>().text;
        profileInfo[1] = GameObject.FindGameObjectWithTag("Kullanıcı Adı").GetComponent<Text>().text;
        profileInfo[2] = GameObject.FindGameObjectWithTag("Şifre").GetComponent<Text>().text;
        profileInfo[3] = GameObject.FindGameObjectWithTag("Tekrar Şifre").GetComponent<Text>().text;
        profileInfo[4] = AvatarSelection.ToString();

        // Profil bilgilerinin kaydedilmesi
        PlayerPrefs.SetString(profileInfo[1] + " Ad Soyad", profileInfo[0]);
        PlayerPrefs.SetString(profileInfo[1] + " Kullanıcı Adı", profileInfo[1]);
        PlayerPrefs.SetString(profileInfo[1] + " Şifre", profileInfo[2]);
        PlayerPrefs.SetString(profileInfo[1] + " Tekrar Şifre", profileInfo[3]);
        PlayerPrefs.SetString(profileInfo[1] + " Avatar", profileInfo[4]);
        PlayerPrefs.SetString(profileInfo[1] + " Skor1", "0");
        PlayerPrefs.SetString(profileInfo[1] + " Skor2", "0");
        PlayerPrefs.SetString(profileInfo[1] + " Skor3", "0");
        PlayerPrefs.SetString(profileInfo[1] + " Skor4", "0");
        PlayerPrefs.SetString(profileInfo[1] + " Skor5", "0");
        PlayerPrefs.SetString(profileInfo[1] + " Skor6", "0");
        PlayerPrefs.SetString(profileInfo[1] + " Skor7", "0");

        PlayerPrefs.SetString("LastEnteredNick", profileInfo[0]);

        PlayerPrefs.Save();

        Instance.CurrentProfile = profileInfo;
        MenuController.Instance.LoadMenu(5);
    }

    public void GetProfile(string kullaniciAdi)
    {
        var profileInfo = new string[12];
        profileInfo[0] = PlayerPrefs.GetString(kullaniciAdi + " Ad Soyad");
        profileInfo[1] = PlayerPrefs.GetString(kullaniciAdi + " Kullanıcı Adı");
        profileInfo[2] = PlayerPrefs.GetString(kullaniciAdi + " Şifre");
        profileInfo[3] = PlayerPrefs.GetString(kullaniciAdi + " Tekrar Şifre");
        profileInfo[4] = PlayerPrefs.GetString(kullaniciAdi + " Avatar");
        profileInfo[5] = PlayerPrefs.GetString(kullaniciAdi + " Skor1");
        profileInfo[6] = PlayerPrefs.GetString(kullaniciAdi + " Skor2");
        profileInfo[7] = PlayerPrefs.GetString(kullaniciAdi + " Skor3");
        profileInfo[8] = PlayerPrefs.GetString(kullaniciAdi + " Skor4");
        profileInfo[9] = PlayerPrefs.GetString(kullaniciAdi + " Skor5");
        profileInfo[10] = PlayerPrefs.GetString(kullaniciAdi + " Skor6");
        profileInfo[11] = PlayerPrefs.GetString(kullaniciAdi + " Skor7");
        Instance.CurrentProfile = profileInfo;


    }

}
