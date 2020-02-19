using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yarisma : MonoBehaviour
{
   public  int sayac=0;
    public Image bir, iki, uc, dort,sure;
    public Text soruismi, cevapa, cevapb, cevapc, cevapd,soru,time;
    Sorular sr;
    public Sprite normalRenk;
    public GameObject yanlisCevap,dogruCevap,zamanDoldu;
    public Color norm;
    public int kategoriSoru=0;
    public bool zamanAksinMi = false;
    public List<bool> sorulanlarSpor;
    public List<bool> sorulanlarGenelKultur;
    public List<bool> sorulanlarEglence;

    public int cevap,question;
    public float zaman;

    void Start()
    {
        //Kategori Sorularının Sayacı(Text şeklinde gelmesin diye 3 tane ayrı ayrı for yazıldı)
        sr = GetComponent<Sorular>();
        for(int i = 0; i < sr.spor.Count; i++)
        {
            sorulanlarSpor.Add(false);
        }
        for (int i = 0; i < sr.genelkultur.Count; i++)
        {
            sorulanlarGenelKultur.Add(false);
        }
        for (int i = 0; i < sr.eglence.Count; i++)
        {
            sorulanlarEglence.Add(false);
        }
        SoruEkle();
        
    }

    
    void Update()
    {

        if (kategoriSoru % 4==0 && kategoriSoru!=0)
        {
            GameObject.Find("player").GetComponent<OyunIcerik>().SporMu = false;
            GameObject.Find("player").GetComponent<OyunIcerik>().GenelKulturMu = false;
            GameObject.Find("player").GetComponent<Oyuncu>().enabled = true;
            GameObject.Find("player").GetComponent<OyunIcerik>().rb.bodyType = RigidbodyType2D.Dynamic;
            GameObject.Find("player").GetComponent<OyunIcerik>().soruSahne.SetActive(false);
            kategoriSoru++;
            GameObject.Find("player").GetComponent<OyunIcerik>().sureDurdur = true;
        }



        if (sayac == 3)
        {

           
        }
        //Sorudaki zaman 
        if (zamanAksinMi) { 
        if (zaman > 0)
        {
            zaman -= Time.deltaTime;
            time.text = zaman.ToString("00");
        }
        
       if(zaman<=0)
        {
            zamanDoldu.SetActive(true);
            
            Debug.Log("Zaman Doldu...");
        }
        }

    }


    public void SoruEkle()
    {
        //Soru cevap kodları 
        //Şıkların renkleri
        bir.color = norm;
        iki.color = norm;
        uc.color = norm;
        dort.color = norm;
        dogruCevap.SetActive(false);
        sayac++;
        if (GameObject.Find("player").GetComponent<OyunIcerik>().SporMu == true)
        {
            for (int i = 0; i < sorulanlarSpor.Count; i++)
            {
                
               
                if (sorulanlarSpor[i] == false)
                {
                    int sorusayi = Random.Range(0, sorulanlarSpor.Count);
                  
                    if (sorulanlarSpor[sorusayi] == false)
                    {
                      //  kategoriSoru++;
                        sorulanlarSpor[sorusayi] = true;
                        question++;
                        zaman = 20;
                        soru.text = "Soru " + question;
                        soruismi.text = sr.spor[sorusayi].soruismi;
                        cevapa.text = sr.spor[sorusayi].cevapa;
                        cevapb.text = sr.spor[sorusayi].cevapb;
                        cevapc.text = sr.spor[sorusayi].cevapc;
                        cevapd.text = sr.spor[sorusayi].cevapd;
                        cevap = sr.spor[sorusayi].cevap;
                    }
                    else
                    {

                        if (GameObject.Find("player").GetComponent<OyunIcerik>().SporMu == true)
                            SoruEkle();

                    }

                    break;
                }
                if (i == sorulanlarSpor.Count - 1)
                {

                }

            }
        }
       else if (GameObject.Find("player").GetComponent<OyunIcerik>().EglenceMi == true)
        {
            for (int i = 0; i < sorulanlarEglence.Count; i++)
            {


                if (sorulanlarEglence[i] == false)
                {
                    int sorusayi = Random.Range(0, sorulanlarEglence.Count);

                    if (sorulanlarEglence[sorusayi] == false)
                    {
                     //   kategoriSoru++;
                        sorulanlarEglence[sorusayi] = true;
                        question++;
                        zaman = 20;
                        soru.text = "Soru " + question;
                        soruismi.text = sr.eglence[sorusayi].soruismi;
                        cevapa.text = sr.eglence[sorusayi].cevapa;
                        cevapb.text = sr.eglence[sorusayi].cevapb;
                        cevapc.text = sr.eglence[sorusayi].cevapc;
                        cevapd.text = sr.eglence[sorusayi].cevapd;
                        cevap = sr.eglence[sorusayi].cevap;
                    }
                    else
                    {

                        if (GameObject.Find("player").GetComponent<OyunIcerik>().EglenceMi == true)
                            SoruEkle();

                    }

                    break;
                }
                if (i == sorulanlarEglence.Count - 1)
                {

                }

            }
        }
        else if (GameObject.Find("player").GetComponent<OyunIcerik>().GenelKulturMu == true)
        {
            for (int i = 0; i < sorulanlarGenelKultur.Count; i++)
            {
                if (sorulanlarGenelKultur[i] == false)
                {
                    int sorusayi = Random.Range(0, sorulanlarGenelKultur.Count);
                    if (sorulanlarGenelKultur[sorusayi] == false)
                    {
                    //    kategoriSoru++;
                        sorulanlarGenelKultur[sorusayi] = true;
                        question++;
                        zaman = 20;
                        soru.text = "Soru " + question;
                        soruismi.text = sr.genelkultur[sorusayi].soruismi;
                        cevapa.text = sr.genelkultur[sorusayi].cevapa;
                        cevapb.text = sr.genelkultur[sorusayi].cevapb;
                        cevapc.text = sr.genelkultur[sorusayi].cevapc;
                        cevapd.text = sr.genelkultur[sorusayi].cevapd;
                        cevap = sr.genelkultur[sorusayi].cevap;
                    }
                    else
                    {
                        if (GameObject.Find("player").GetComponent<OyunIcerik>().GenelKulturMu == true)
                            SoruEkle();

                    }

                    break;
                }
                if (i == sorulanlarGenelKultur.Count - 1)
                {

                }

            }

        }
    }
    public void CevapVer(int deger)
    {
        if (deger == cevap)
        {
            //doğru cevap rengi
            kategoriSoru++;
            if (deger == 1)
                bir.color = Color.green;
            if (deger == 2)
                iki.color = Color.green;
            if (deger == 3)
                uc.color = Color.green;
            if (deger == 4)
                dort.color = Color.green;
            dogruCevap.SetActive(true);
            
            Debug.Log("DOGRU CEVAP");
            Invoke("SoruEkle", 1f);//1 saniye geciktiriyor
            

        }
        else
        {
            //yanlış cevap rengi
            if (deger == 1)
                bir.color = Color.red;
            if (deger == 2)
                iki.color = Color.red;
            if (deger == 3)
                uc.color = Color.red;
            if (deger == 4)
                dort.color = Color.red;
            yanlisCevap.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("YANLIS CEVAP");
        }
    }
   
}
