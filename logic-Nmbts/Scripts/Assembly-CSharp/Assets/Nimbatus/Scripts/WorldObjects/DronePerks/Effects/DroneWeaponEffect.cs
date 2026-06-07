using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class DroneWeaponEffect : DroneEffect
	{
		public EEffectType SpecificEffectType = EEffectType.DroneWeapon;

		public bool AllWeaponTypes;

		[HideIf("AllWeaponTypes", true)]
		public List<EWeaponType> AllowedWeaponTypes;

		public FixedAttributeUpgrade Upgrade;

		public override EEffectType EffectType
		{
			get
			{
				return SpecificEffectType;
			}
		}

		public bool IsCompatible(Emitter emitter)
		{
			if (!AllWeaponTypes && AllowedWeaponTypes != null && !AllowedWeaponTypes.Contains(emitter.WeaponType))
			{
				return false;
			}
			return true;
		}

		public override bool IsAllowed()
		{
			if (SpecificEffectType == EEffectType.DroneWeapon)
			{
				return true;
			}
			return base.IsAllowed();
		}

		public override string GetDescription()
		{
			return Upgrade.GetToolTip();
		}
	}
}
