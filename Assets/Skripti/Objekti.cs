using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objekti : MonoBehaviour
{
    //GameObject kas uzglaba visus velkamos objektus
    public GameObject atkritumuMasina;
    public GameObject atroMasina;
    public GameObject autobuss;

    /*Uzgalaba velkamo objektu sakotneja pozicija
    kooardinatas (lai zinatu kur aizmest objektu ja tas nolikts nepareizaja vieta*/
    //Objekti paliek Public taču paslepj no Inspect loga
    [HideInInspector]
    public Vector2 atkrKoord;
    [HideInInspector]
    public Vector2 atroKoord;
    [HideInInspector]
    public Vector2 bussKoord;
    //uzglaba ainas esošo kanvu
    public Canvas kanva;
    //uzglaba skanas avotu kurāatskaņot audio failus
    public AudioSource skanasAvots;
    //masivs kas uzglaba visas skanas
    public AudioClip[] skanaKoAtskanot;
    //uzgalab objektus kurš ir pedejais pievientoais 
    public GameObject pedejaisVilktais = null;
    //mainigais atbild par to vai obejkts ir nolikts pareizi vai nepareizi
    [HideInInspector]
    public bool vaiIstajaVieta = false;

    //funkcija nostrada tiklidz nospiesta play pogu

    private void Awake()
    {
        atkrKoord = atkritumuMasina.GetComponent<RectTransform>().localPosition;
        atroKoord = atroMasina.GetComponent<RectTransform>().localPosition;
        bussKoord = autobuss.GetComponent<RectTransform>().localPosition;
    }

}
