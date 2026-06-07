using System;
using System.Linq;
using System.Xml.Serialization;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	[XmlInclude(typeof(DeployCostEffect))]
	[XmlInclude(typeof(DronePartHealthEffect))]
	[XmlInclude(typeof(DroneWeaponEffect))]
	[XmlInclude(typeof(ImprovedAfterburner))]
	[XmlInclude(typeof(ImprovedDrill))]
	[XmlInclude(typeof(ImprovedEnergyShield))]
	[XmlInclude(typeof(NoInputAllowed))]
	[XmlInclude(typeof(ResourceCollectionEffect))]
	[XmlInclude(typeof(SuperchargedBatteries))]
	[XmlInclude(typeof(ThrusterEffect))]
	[XmlInclude(typeof(WeaponWorkshop))]
	[XmlInclude(typeof(WirelessResourceTransfer))]
	[XmlInclude(typeof(ImprovedHealing))]
	[XmlInclude(typeof(DynamoEffect))]
	public abstract class DroneEffect
	{
		public abstract EEffectType EffectType { get; }

		public virtual Texture2D GetIcon()
		{
			DroneEffectSetting droneEffectSetting = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.AllEffectSettings.FirstOrDefault((DroneEffectSetting s) => s.Effect.EffectType == EffectType);
			if (droneEffectSetting == null)
			{
				return null;
			}
			return droneEffectSetting.Icon;
		}

		public virtual string GetDescription()
		{
			DroneEffectSetting droneEffectSetting = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.AllEffectSettings.FirstOrDefault((DroneEffectSetting s) => s.Effect.EffectType == EffectType);
			if (droneEffectSetting == null)
			{
				return null;
			}
			return droneEffectSetting.Description.GetTranslation();
		}

		public virtual bool IsAllowed()
		{
			return SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.All((DroneEffect e) => e.EffectType != EffectType);
		}
	}
}
