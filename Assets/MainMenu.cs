using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //ayarlar menüsü
    public GameObject AyarlarIcerik;
    public GameObject ButonInaktiflestir;

    //Oyuna geçiş
    public void OyunOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Ayarlar içindeki ses aç kapa
    public void SesAcKapa()
    {
        AyarlarIcerik.SetActive(true);
        ButonInaktiflestir.SetActive(false);
    }

    //Çıkış butonu
    public void OyundanCik()
    {
        Application.Quit();
    }
    public void Geri()
    {
        ButonInaktiflestir.SetActive(true);
        AyarlarIcerik.SetActive(false);
    }
}
