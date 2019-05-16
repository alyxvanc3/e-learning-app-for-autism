using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInfo : MonoBehaviour
{
    public Text NickName;
    public Text[] Scores;
    public string[] profileInfo;

    void Start()
    {
        NickName.text = MenuController.Instance.KullaniciAdi.text;
        GameObject.FindGameObjectWithTag("kullanıcı").GetComponent<Image>().sprite = MenuController.Instance.CurrentPp;

        profileInfo = PlayerManager.Instance.CurrentProfile;
        Scores[0].text = profileInfo[5];
        Scores[1].text = profileInfo[6];
        Scores[2].text = profileInfo[7];
        Scores[3].text = profileInfo[8];
        Scores[4].text = profileInfo[9];
        Scores[5].text = profileInfo[10];
        Scores[6].text = profileInfo[11];
    }
}
