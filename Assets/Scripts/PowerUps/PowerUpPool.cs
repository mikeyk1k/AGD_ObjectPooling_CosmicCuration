using CosmicCuration.Enemy;
using CosmicCuration.Utilities;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;

namespace CosmicCuration.PowerUps
{
    public class PowerUpPool : GenericObjectPool<PowerUpController>
    {
        private PowerUpData powerUpData;

        public PowerUpController GetPowerUp<T>(PowerUpData powerUpData) where T : PowerUpController
        {
            this.powerUpData = powerUpData;
            return GetItem<T>();
        }

        protected override PowerUpController CreateItem<T>()
        {
            if (typeof(T) == typeof(Shield))
                return new Shield(powerUpData);
            if (typeof(T) == typeof(DoubleTurret))
                return new DoubleTurret(powerUpData);
            if (typeof(T) == typeof(RapidFire))
                return new RapidFire(powerUpData);
            throw new Exception($"PowerUp Type not supported");
        }
    }
}