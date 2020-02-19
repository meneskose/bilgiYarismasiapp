using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oyuncu : MonoBehaviour {
    public Rigidbody2D rb;
    public float Hiz;
    bool bastiMi = false;
    public GameObject kamera;
   
    
    public GameObject oyunBitisEkrani;

	// Oyun baslayınca calısır(Normal Zamanda oynatır)
	void Start () {
        Time.timeScale = 1;

	}
	
	
	void Update () {

       




        Vector2 vek = new Vector2(gameObject.transform.position.x, 10);
        //Yukardan cıkmama kodu
        if (gameObject.transform.position.y >= 10)
        {
            gameObject.transform.position = vek;
            //ters yonde kuvvet uygular
            rb.AddForce(new Vector2(0, -150));
            
        }
        

        kamera.transform.position += transform.right * Time.deltaTime * 6;
        gameObject.transform.position += transform.right * Time.deltaTime *6;
		if(bastiMi)
            // if(bastiMi==true) = if(bastiMi)
            // if(bastiMi != true) = if(!bastiMi)
            rb.AddForce(new Vector2(0, Hiz));
    }
    public void BasiliTut() {

        bastiMi = true;
    }
    public void Basmadi()
    {
        bastiMi = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //engeller isimli collidera girince
        if(collision.gameObject.tag == "engeller")
        {
            oyunBitisEkrani.SetActive(true);
            //gecikmeli fonksiyon çalıştırma
            Time.timeScale = 0;
         //   Invoke("ZamanDurdur", 1);
        }
        
       



    }
    void ZamanDurdur()
    {
        
       // Time.timeScale = 0;
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }





}
