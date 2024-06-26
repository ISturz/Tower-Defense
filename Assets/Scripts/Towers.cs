using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Towers : MonoBehaviour
{

    public GameObject Tower;

    private int frostTowerCount = 0;
    private ClickFunction clickFunction;

    private Button frostTowerBtn;
    private Button ballistaTowerBtn;
    private Button tinyTowerBtn;

    public GameObject towerChoiceScene;

    private Transform selectedTowerLocation;
    private int damage;
    private float reloadTime;

    public GameObject selectedPlate;




    public Towers() { } //Default Constructor

    public Towers(Transform _towerLocation)
    {
        this.selectedTowerLocation = _towerLocation;
    }


    public Towers(Transform _towerLocation, int _damage, float _reloadTime)
    {
        this.selectedTowerLocation = _towerLocation;
        this.damage = _damage;
        this.reloadTime = _reloadTime;
    }

    public Transform TowerLocation
    {
        get { return selectedTowerLocation; }
        set { selectedTowerLocation = value; }

    }

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float ReloadTIme
    {
        get { return reloadTime; }
        set { reloadTime = value; }

    }

    private void Awake()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        clickFunction = GameObject.FindGameObjectWithTag("BuildingPlate").GetComponent<ClickFunction>();
        





    }

    void Update()
    {

    }

    public void CreateTower(GameObject Tower)
    {
        Debug.Log("Create Tower works here");
        towerChoiceScene.SetActive(false);
        

        if (gameObject.CompareTag("FrostTower"))
        {
            if (clickFunction.IsPlatePosSet())
            {
                Transform platePos = clickFunction.platePos;
                if (platePos != null)
                {
                    Vector3 position = platePos.position;
                    Quaternion rotation = platePos.rotation;
                    Debug.Log("Instantiating tower at position: " + position + " with rotation: " + rotation);
                    Instantiate(Tower, position, rotation);
                }
                else
                {
                    Debug.LogError("platePos is null in ClickFunction.");
                }
            }
            else
            {
                Debug.LogError("platePos is not set.");
            }


        }
        else if (gameObject.CompareTag("BallistaTower"))
        {


           // Debug.Log("Tower chosen: " + Tower.name + " Plate Chosen: " + clickFunction.selectedPlate.name);
            Instantiate(Tower, clickFunction.platePos.position, clickFunction.platePos.rotation);
        }
        else if (gameObject.CompareTag("TinyTower"))
        {

           // Debug.Log("Tower chosen: " + Tower.name + " Plate Chosen: " + clickFunction.selectedPlate.name);
            Instantiate(Tower, clickFunction.platePos.position, clickFunction.platePos.rotation);
        }
        else
        {
            Debug.Log("Unable to create Tower");
        }



    }

    public void DestoryTower()
    {

    }

    public void EditTower()
    {

    }

    public void OnMouseDown()
    {
        if (gameObject.tag == "BuildingPlate")
        {
            
            selectedPlate = gameObject;
        }


    }
}
