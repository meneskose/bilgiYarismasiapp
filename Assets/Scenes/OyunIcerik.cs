using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunIcerik : MonoBehaviour
{
    public GameObject soruSahne;
    public Rigidbody2D rb;
    public  int sayac = 0;
    public GameObject[] engeller;
    Vector3 dinamikKonum;
   
    public GameObject[] kategoriler;
    public bool sureDurdur = true;
    public bool SporMu = false;
    public bool GenelKulturMu = false;
    public bool EglenceMi = false;

    float engelSay = 1;



    // Start is called before the first frame update
    void Start()
    {
        dinamikKonum = gameObject.transform.position;
        EngelOlustur();
        
    }

    // Update is called once per frame
    void Update()
    {
        //soru geldiğinde arka planda engellerin gelmesini engeller(süreyi durdurur)
        if(sureDurdur)
        engelSay += Time.deltaTime;
        if (engelSay >= 8)
        {
            EngelOlustur();

            engelSay = 1;

        }
        //ilk engelden sonra kategori oluştur
        if (sayac == 1)
        {
            KategoriOlustur();
            sayac++;
        }
        //her 2 engelde bir kategori oluştur
        if (sayac % 4 == 0 && sayac != 0 )
        {
            KategoriOlustur();
            sayac++;
        }







    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "eglence")
        {
            EglenceMi = true;
            GenelKulturMu = false;
            SporMu = false;
            Invoke("SoruGelisGeciktir", 1.1f);
        }
    
        if (collision.tag == "spor")
        {
            EglenceMi = false;
            GenelKulturMu = false;
            SporMu = true;
            Invoke("SoruGelisGeciktir", 1.1f);
        }
        if (collision.gameObject.tag == "sayac")
        {
            sayac++;
        }
        if (collision.gameObject.tag == "genelkultur")
        {
            EglenceMi = false;
            SporMu = false;
            GenelKulturMu = true;
            Invoke("SoruGelisGeciktir", 1.1f);
        }
    }
    void SoruGelisGeciktir()
    {
        GameObject.Find("Main Camera").GetComponent<Yarisma>().SoruEkle();
        GameObject.Find("Main Camera").GetComponent<Yarisma>().zamanAksinMi = true;
        sureDurdur = false;
        soruSahne.SetActive(true);
        //soru gelince oyuncu kodunu kapatır
        GameObject.Find("player").GetComponent<Oyuncu>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;

    }
    public void KategoriOlustur()
    {

        dinamikKonum.x = gameObject.transform.position.x + 45.5f;
        dinamikKonum.z = 10;

        dinamikKonum.y = 0;
        Instantiate(kategoriler[Random.Range(0, kategoriler.Length)], dinamikKonum, Quaternion.identity);
    }


    public void EngelOlustur()
    {

        dinamikKonum.x = gameObject.transform.position.x + 20;
        dinamikKonum.z = 10;

        dinamikKonum.y = 0;



        Instantiate(engeller[Random.Range(0, engeller.Length)], dinamikKonum, Quaternion.identity);

    }

}
