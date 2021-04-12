using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//jaīmporte lai varetu piesaistit IDropHandler interfeisu un lietot OnDrop funkciju
using UnityEngine.EventSystems;

public class NomesanasVieta : MonoBehaviour, IDropHandler
{
    //uzgalaba velkama objekta rotaciju ap z assi un noliekamas vietas rotaciju
    //starpibu uzgalabas cik liela z ass rotacijas leņķa starpiba starp abiem objektiem
    private float vietasZrot, velkamaObjeZrot, rotacijasStarpiba;
    //uzglaba velkama objekta un nomesanas vietas izmerus
    private Vector2 vietasIzm, velkObjIzm;
    //uzglaba objektu x un y ass izmeru starpibu
    private float xIzmeruStarpiba, yIzmeruStarpiba;
    //norade uz skriptu objektu
    public Objekti objektuSkripts;

    //nostrada ja objektu cenšas nomest uz nometama lauka
    public void OnDrop(PointerEventData notikums)
    {
        //parbauda vai kads objekts tiek vilkts
        if (notikums.pointerDrag != null)
        {
            //ja nomešanas laukā uzmetā attela tags sakrit lauka tagu
            if ((notikums.pointerDrag.tag.Equals(tag)))
            {
                //iegust objekta rotaciju grados
                vietasZrot = notikums.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
                velkamaObjeZrot = GetComponent<RectTransform>().transform.eulerAngles.z;
                //aprekina rotacijas starpibu 
                rotacijasStarpiba = Mathf.Abs(vietasZrot - velkamaObjeZrot);
                //iegust objektu izmerus 
                vietasIzm = notikums.pointerDrag.GetComponent<RectTransform>().localScale;
                velkObjIzm = GetComponent<RectTransform>().localScale;
                xIzmeruStarpiba = Mathf.Abs(vietasIzm.x - velkObjIzm.x);
                yIzmeruStarpiba = Mathf.Abs(vietasIzm.y - velkObjIzm.y);

                //parbauda vai objektu savstarpeja rotacija neatsķiras vairāk par 9 grādiem 
                //un vai x un y izmeri neatšķiras vairak par 0.15
                if ((rotacijasStarpiba <= 9 || (rotacijasStarpiba >= 351 && rotacijasStarpiba <= 360))
                    && (xIzmeruStarpiba <= 0.15 && yIzmeruStarpiba <= 0.15))
                {
                    objektuSkripts.vaiIstajaVieta = true;
                    //nometamo objektu iecentre vieta
                    notikums.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        GetComponent<RectTransform>().anchoredPosition;
                    //pielago nosmesta objekta rotaciju
                    notikums.pointerDrag.GetComponent<RectTransform>().localRotation =
                        GetComponent<RectTransform>().localRotation;
                    //pielago nomesta obejkta rotaciju
                    notikums.pointerDrag.GetComponent<RectTransform>().localScale =
                        GetComponent<RectTransform>().localScale;


                    /*parbauda oec tagiem kurs no objektiem ir pareizi nomests, 
                    tad atskano atbilsotsu skanu*/
                    switch (notikums.pointerDrag.tag)
                    {
                        case "Atkritumi":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[3]);
                            break;
                        case "Atrie":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[1]);
                            break;
                        case "Skola":
                            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[2]);
                            break;

                        default:
                            Debug.Log("nedefinets tag!");
                            break;
                    }
                }
                //ja objektu tagi nesakrit un nomet nepareizaja vieta
            }
            else
            {
                objektuSkripts.vaiIstajaVieta = false;
                //atsakano skanu
                objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[0]);

                //atkariba no objektu taga kurs tika vilkts objekta
                //uzbida uz ta sakotneja kooardinatam
                switch (notikums.pointerDrag.tag)
                {
                    case "Atrie":
                        objektuSkripts.atkritumuMasina.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.atkrKoord;
                        break;
                    case "Atkritumi":
                        objektuSkripts.atroMasina.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.atroKoord;
                        break;
                    case "Skola":
                        objektuSkripts.autobuss.GetComponent<RectTransform>().localPosition =
                            objektuSkripts.bussKoord;
                        break;

                    default:
                        Debug.Log("objektam nav noteikta parvietosanas vieta!");
                        break;
                }

            }
        }
    }
}
