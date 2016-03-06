﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldInformation : MonoBehaviour {
    public static string CurrentArea { get; set; }
    public static int[,] Edges = new int[10, 5] { { 2, 9, 0, 0, 0 }, { 1, 4, 0, 0, 0 }, { 4, 0, 0, 0, 0 }, { 2, 3, 5, 9, 0 }, { 4, 6, 7, 8, 0 }, { 5, 7, 0, 0, 0 }, { 5, 6, 0, 0, 0 }, { 5, 10, 0, 0, 0 }, { 1, 4, 10, 0, 0 }, { 8, 9, 0, 0, 0 } };

    public static ShopInventory shopInv = new ShopInventory();

    private static CreateNewWeapon WeaponCreator = new CreateNewWeapon();
    private static CreateNewEquipment EquipmentCreator = new CreateNewEquipment();
    private static CreateNewPotion PotionCreator = new CreateNewPotion();

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Use this for initialization

    public static void RenewShopInv()
    {
        if(shopInv != null)
        {
            //REMOVE FROM DATABASE
        }
        //add to database!!!!!! -------------------------------------------------->>>>>>>>>>>>>>

        List<BaseWeapon> WArr = new List<BaseWeapon>();
        List<BasePotion> PArr = new List<BasePotion>();
        List<BaseEquipment> EArr = new List<BaseEquipment>();

        for(int i = 0; i<5; i++)
        {
            WArr.Add( WeaponCreator.returnWeapon());
            PArr.Add(PotionCreator.returnPotion());
            EArr.Add(EquipmentCreator.returnEquipment());
        }

        shopInv.Equipment = EArr;
        shopInv.Potions = PArr;
        shopInv.Weapons = WArr;

    }
    void Start () {
        RenewShopInv();
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}