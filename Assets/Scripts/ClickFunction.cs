using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickFunction : MonoBehaviour
{
    public GameObject towerChoiceScene;
    public Towers towers;
    public Transform platePos;
    private bool isPlatePosSet = false;
    public GameObject selectedPlate;


    


    private void Awake()
    {
        towerChoiceScene.SetActive(false);
        

    }

    private void Start()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("OnMouseDown called.");
        if (gameObject.tag == "BuildingPlate")
        {
            selectedPlate = gameObject;
            platePos = gameObject.transform;
            Debug.Log("Assigned platePos: " + platePos.position);
            towerChoiceScene.SetActive(true);
            isPlatePosSet = true;
        }
        else
        {
            Debug.Log("GameObject tag is not BuildingPlate.");
        }

    }

    public bool IsPlatePosSet()
    {
        return isPlatePosSet;
    }

}

