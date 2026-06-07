using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public class WeaponReceivableSettings : BaseReceivableSettings
	{
		public int NumberOfUpgrades;

		public bool AllTypes = true;

		[HideIf("AllTypes", true)]
		public List<EWeaponType> AllowedTypes = new List<EWeaponType>();

		public bool AllAmmunitions = true;

		[HideIf("AllAmmunitions", true)]
		public List<EAmmunitionType> AllowedAmmunitions = new List<EAmmunitionType>();

		public override BaseReceivable CreateReceivable(int seed, int amount)
		{
			return new WeaponReceivable
			{
				WeaponSeed = seed,
				NumberOfUpgrades = NumberOfUpgrades,
				WeaponType = ((!AllTypes) ? AllowedTypes.RandomItemSeed(seed) : EWeaponType.None),
				WeaponAmmunition = ((!AllAmmunitions) ? AllowedAmmunitions.RandomItemSeed(seed) : EAmmunitionType.None),
				Amount = amount,
				Rarity = (EWeaponRarity)Mathf.Max(0, Mathf.Min(3, NumberOfUpgrades)),
				HideRarity = false
			};
		}
	}
}
