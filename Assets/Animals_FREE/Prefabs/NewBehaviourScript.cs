using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject tavukPrefab; // Tavuk modeli Prefab'�
    public Text tavukSayacText; // Tavuk say�s�n� g�sterecek metin alan�
    public AudioSource sesEfekti; // T�klama sesi
    private int tavukSayisi = 0; // Tavuk sayac�

    void Start()
    {
        // Her tavuk assestini eklemek i�in bir d�ng�
        for (int i = 1; i <= 3; i++)
        {
            string tavukAssestAdi = "Chicken_001(" + i + ")"; // Tavuk assestlerinin isimlerini olu�tur
            GameObject tavuk = Resources.Load<GameObject>(tavukAssestAdi); // Tavuk assestini y�kle
            if (tavuk != null)
            {
                Instantiate(tavuk, transform.position + Vector3.right * i, Quaternion.identity); // Tavuklar� sahneye ekle
            }
            else
            {
                Debug.LogError("Tavuk assesti y�klenemedi: " + tavukAssestAdi); // Hata durumunda uyar� ver
            }
        }
    }
    void OnMouseDown()
    {
        // Tavu�a t�kland���nda �al��acak kod
        tavukSayisi++; // Tavuk sayac�n� art�r
        UpdateTavukSayac(); // Tavuk sayac�n� g�ncelle
        PlaySesEfekti(); // T�klama sesini �al
    }

    void UpdateTavukSayac()
    {
        // Tavuk sayac�n� g�ncelle ve UI'da g�ster
        tavukSayacText.text = "Tavuk Say�s�: " + tavukSayisi.ToString();
    }

    void PlaySesEfekti()
    {
        // T�klama sesini �al
        sesEfekti.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
