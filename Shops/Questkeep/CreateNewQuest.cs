﻿using UnityEngine;
using System.Collections;

public class CreateNewQuest  {

    private Quest newQuest;

    public Quest returnQuest()
    {
        CreateQuest();
        return newQuest;
    }

    public Quest returnControl()
    {
        controlEvent();
        return newQuest;
    }

    private void controlEvent()
    {
        newQuest = new Quest();
        newQuest.QuestType = Quest.QuestTypes.Control;

        int randTemp = Random.Range(0, WorldInformation.Kingdoms.Count);

        newQuest.QuestAlliance = WorldInformation.Kingdoms[randTemp];
        newQuest.QuestLocation = WorldInformation.Areas.Find(x => x.AreaType != Area.AreaTypes.City && x.OwnedBy != newQuest.QuestAlliance);
        newQuest.QuestEnemy = newQuest.QuestLocation.OwnedBy;
        

        newQuest.QuestName = "Control: " + newQuest.QuestLocation.AreaName +"!";
        newQuest.QuestDescription = newQuest.QuestLocation.AreaName + " has fallen into a state of disarray and " + newQuest.QuestAlliance.KingName + " is making a move!";

        newQuest.RecommendedLevel = GameInformation.PlayerLevel;
        newQuest.GoldReward = newQuest.RecommendedLevel * newQuest.RecommendedLevel + 300;

    }

    private void CreateQuest()
    {
        newQuest = new Quest();

        //Location
        DetermineLocation();

        //Type  
        DetermineType();

        //Alliance
        newQuest.QuestAlliance = WorldInformation.Areas.Find(x => x.AreaID == WorldInformation.CurrentArea + "").OwnedBy;

        //Enemy
        //No enemy for normal quests

        //Name
        DetermineName();



        //Description
        DetermineDescription();

        //Recommended Lvl
        DetermineRecommendedLevel();

        //Gold reward
        DetermineGold();
        //weapon, equipment, or potion reward
        DetermineReward();

    }

    private void DetermineReward()
    {
        int randTemp = Random.Range(1, 4);
        CreateNewWeapon cw = new CreateNewWeapon();
        CreateNewPotion cp = new CreateNewPotion();
        CreateNewEquipment ce = new CreateNewEquipment();

        if (newQuest.QuestType == Quest.QuestTypes.CaravanProtect)
        {
            newQuest.GoldReward = 21 * newQuest.RecommendedLevel;
            if (randTemp == 4)
                newQuest.PotionReward = cp.returnPotion();
        }
        else if (newQuest.QuestType == Quest.QuestTypes.Delivery)
        {
            newQuest.GoldReward = 16 * newQuest.RecommendedLevel;
            if (randTemp < 3)
                newQuest.PotionReward = cp.returnPotion();
            else if (randTemp == 3)
                newQuest.EquipmentReward = ce.returnEquipment();
            else
                newQuest.WeaponReward = cw.returnWeapon();
        }
        else if (newQuest.QuestType == Quest.QuestTypes.TreasureMapGetMap)
        {
            newQuest.WeaponReward = cw.returnWeapon();
            newQuest.EquipmentReward = ce.returnEquipment();

        }
    }

    private void DetermineGold()
    {
        if (newQuest.QuestType == Quest.QuestTypes.CaravanProtect)
        {
            newQuest.GoldReward = 21 * newQuest.RecommendedLevel ;
        }
        else if (newQuest.QuestType == Quest.QuestTypes.Delivery)
        {
            newQuest.GoldReward = 16 * newQuest.RecommendedLevel;
        }
        else if (newQuest.QuestType == Quest.QuestTypes.TreasureMapGetMap)
        {
            newQuest.GoldReward = 9 * newQuest.RecommendedLevel;
        }
    }

    private void DetermineRecommendedLevel()
    {
        int randtemp = Random.Range(1, 5);
        if (randtemp == 1)
            newQuest.RecommendedLevel = GameInformation.PlayerLevel - 4;
        else if(randtemp == 2)
            newQuest.RecommendedLevel = GameInformation.PlayerLevel - 2;
        else if (randtemp == 3)
            newQuest.RecommendedLevel = GameInformation.PlayerLevel;
        else if (randtemp == 4)
            newQuest.RecommendedLevel = GameInformation.PlayerLevel + 2;
        else if (randtemp == 5)
            newQuest.RecommendedLevel = GameInformation.PlayerLevel + 4;

        if (newQuest.RecommendedLevel < 1)
            newQuest.RecommendedLevel = 1;

    }

    private void DetermineDescription()
    {
        if (newQuest.QuestType == Quest.QuestTypes.CaravanProtect)
        {
            newQuest.QuestDescription = "The adventurer has given me a fair bit of coin to protect an incoming shipment of goods at "+newQuest.QuestLocation.AreaName;
        }
        else if (newQuest.QuestType == Quest.QuestTypes.Delivery)
        {
            newQuest.QuestDescription = "The adventure asked me to deliver a message of extreme importance. I better get deliver the letter to "+newQuest.QuestLocation.AreaName+" quick.";
        }
        else if (newQuest.QuestType == Quest.QuestTypes.TreasureMapGetMap)
        {
            newQuest.QuestDescription = "It seems the adventurer stumbled upon a treasure map leading to a secret location in "+newQuest.QuestLocation.AreaName+ ". He agreed give me the location if we split the rewards.";
        }
    }

    private void DetermineLocation()
    {
        int randTemp = Random.Range(0, 9);
        Area questLocation = WorldInformation.Areas.Find(x => x.AreaID == randTemp + "");
        newQuest.QuestLocation = questLocation;
    }

    private void DetermineName()
    {
        if(newQuest.QuestType == Quest.QuestTypes.CaravanProtect)
        {
            newQuest.QuestName = "Hired Protection!";
        }
        if (newQuest.QuestType == Quest.QuestTypes.Delivery)
        {
            newQuest.QuestName = "Impotant Delivery!";
        }
        if (newQuest.QuestType == Quest.QuestTypes.TreasureMapGetMap)
        {
            newQuest.QuestName = "Treasure!?";
        }
    }

    private void DetermineType()
    {
        int randTemp = Random.Range(1, 3);
        if(randTemp == 1)
        {
            newQuest.QuestType = Quest.QuestTypes.CaravanProtect;
        }
        if (randTemp == 2)
        {
            newQuest.QuestType = Quest.QuestTypes.Delivery;
        }
        if (randTemp == 3)
        {
            newQuest.QuestType = Quest.QuestTypes.TreasureMapGetMap;
        }
    }

}
