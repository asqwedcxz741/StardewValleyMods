﻿using StardewValley;
using System.Collections.Generic;

namespace BetterTrainLoot.Data
{

    //public const int compartments = 3;
    //public const int grass = 4;
    //public const int hay = 5;

    //public const int randomTrain = 0;
    //public const int jojaTrain = 1;
    //public const int coalTrain = 2;
    //public const int passengerTrain = 3;
    //public const int uniformColorPlainTrain = 4;  -- Not Used
    //public const int prisonTrain = 5;
    //public const int christmasTrain = 6;


    public enum TRAINS
    {
        RANDOM_TRAIN = 0,
        JOJA_TRAIN = 1,
        COAL_TRAIN = 2,
        PASSENGER_TRAIN =3,
        UNKNOWN = 4,
        PRISON_TRAIN = 5,
        CHRISTMAS_TRAIN = 6
    }

    

    public class TrainData 
    {
        public TRAINS TrainCarID { get; set; }

        public List<TrainTreasure> treasureList { get; set; }

        public TrainData(TRAINS id)
        {
            this.TrainCarID = id;
        }

        public void UpdateTrainLootChances(double todayLuck)
        {            
            //double todayLuck = Game1.dailyLuck;
            double itemBaseChance = 0.0;
            foreach (TrainTreasure item in this.treasureList)
            {
                itemBaseChance = Game1.random.NextDouble() / 10.0;  // The bestcase is 10% (0.1)
                itemBaseChance = itemBaseChance + (itemBaseChance * todayLuck);

                item.Chance = itemBaseChance * (double)item.Rarity;
            }
        }
    }
}
