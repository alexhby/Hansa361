﻿using UnityEngine;
using System.Collections;
[System.Serializable]

//Quests Class -- represents the structure containing all values relevant to a quest
public class Quest  { 
    //Some of these types haven't been implemented yet!
    public enum QuestTypes
    {
        Control, // will have an alliance and enemy  NORMAL TERRITORY TAKEOVERS (non city) difficulty scaled to distance from king's city
        CaravanProtect, // Defend caravan quests, quests given at the store, improves reputation based on the recommended level.
        Main, 
        Random,
        TreasureMapGetMap,
        TreasureMapGetArtifact,
        HelpStranger,
        Delivery

        
    }

    public QuestTypes QuestType { get; set; }

    

    //Determines who the player will gain influence/reputation with
    public Kingdom QuestAlliance { get; set; }

    //Determines who the player will lose influence/reputation with
    public Kingdom QuestEnemy { get; set; }


    public string QuestName { get; set; }
    public Area QuestLocation { get; set; }
    public string QuestDescription { get; set; }



    //Will let the player know the difficulty of the quest with regard to their current level
    //This will also set the levels of the enemies in the quest
    public int RecommendedLevel { get; set; }
    

    //set all reward types
    public int GoldReward { get; set; }
    public int ReputationReward { get; set; }
    public BaseWeapon WeaponReward { get; set; }
    public BaseEquipment EquipmentReward { get; set; }
    public BasePotion PotionReward { get; set; }
    


	
}
