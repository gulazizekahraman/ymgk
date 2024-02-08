using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject tavukPrefab; // Tavuk modeli Prefab'ý
    public Text tavukSayacText; // Tavuk sayýsýný gösterecek metin alaný
    public AudioSource sesEfekti; // Týklama sesi
    private int tavukSayisi = 0; // Tavuk sayacý

    void Start()
    {
        // Her tavuk assestini eklemek için bir döngü
        for (int i = 1; i <= 3; i++)
        {
            string tavukAssestAdi = "Chicken_001(" + i + ")"; // Tavuk assestlerinin isimlerini oluþtur
            GameObject tavuk = Resources.Load<GameObject>(tavukAssestAdi); // Tavuk assestini yükle
            if (tavuk != null)
            {
                Instantiate(tavuk, transform.position + Vector3.right * i, Quaternion.identity); // Tavuklarý sahneye ekle
            }
            else
            {
                Debug.LogError("Tavuk assesti yüklenemedi: " + tavukAssestAdi); // Hata durumunda uyarý ver
            }
        }
    }
    void OnMouseDown()
    {
        // Tavuða týklandýðýnda çalýþacak kod
        tavukSayisi++; // Tavuk sayacýný artýr
        UpdateTavukSayac(); // Tavuk sayacýný güncelle
        PlaySesEfekti(); // Týklama sesini çal
    }

    void UpdateTavukSayac()
    {
        // Tavuk sayacýný güncelle ve UI'da göster
        tavukSayacText.text = "Tavuk Sayýsý: " + tavukSayisi.ToString();
    }

    void PlaySesEfekti()
    {
        // Týklama sesini çal
        sesEfekti.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
