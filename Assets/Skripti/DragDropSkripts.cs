using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//jāimporte lai varetu stradata ar eventsystems
using UnityEngine.EventSystems;
public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler /* IEndDragHandler*/ {
    //uzglabas noradi uzz objektu skriptu
    //  public Objekti objektuSkripts;
    //velakamam objektam piestiprinata komponente
    private CanvasGroup kanvasGrupa;
    //vilktāobjekta atrašanās vietas kooardinātu maiņa
    private RectTransform velkObjRectTransf;

    private void Awake()
    {
        //piekļūst objektam piesastītajai CanvasGroup komponentei
        kanvasGrupa = GetComponent<CanvasGroup>();
        //Piekļūst objektam RectTransform komponentei
        velkObjRectTransf = GetComponent<RectTransform>();
    }

    //nostrādā nospiežot peles klikšķi uz objektu
    public void OnPointerDown(PointerEventData notikums)
    {
        Debug.Log("Uzklikšķina uz velkama objekta!");
    }

    //nostrada uzsākot vilksanu 
    public void OnBeginDrag(PointerEventData notikums)
    {
        Debug.Log("Uzsākta vilkšana!");
        //attīra pēdejo vilkto objektu 
        //objektuSkripts.pedejaisVilktais = null;
        //uzsākot vilkt objektu tas paliek nedaudz caurspidigs
        kanvasGrupa.alpha = 0.6f;
        //lai obejktam veretu iet cauri rycast stars
        kanvasGrupa.blocksRaycasts = false;

    }

    //nostrada reli notiekot vilkšanai
    public void OnDrag(PointerEventData notikums)
    {
        Debug.Log("Notiek vilkšana!");
        //velkObjRectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;
    }
}
