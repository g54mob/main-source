using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Receivables
{
	[Serializable]
	public class WeaponReceivable : BaseReceivable
	{
		public int WeaponSeed;

		public int NumberOfUpgrades;

		public EWeaponType WeaponType;

		public EAmmunitionType WeaponAmmunition;

		public int Amount;

		public EWeaponRarity Rarity;

		public bool HideRarity;

		[XmlIgnore]
		private WeaponPreset _preset;

		public override EReceivableType Type()
		{
			return EReceivableType.DronePart;
		}

		public override T GetReward<T>()
		{
			return (T)(object)GetGeneratedWeapon();
		}

		public override Texture2D GetIcon()
		{
			return SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.RandomWeaponIcon;
		}

		public override string GetTitle()
		{
			if (HideRarity)
			{
				return LocalizationManager.GetTranslation("GalaxyMap/RandomWeapon");
			}
			string translation = "";
			switch (Rarity)
			{
			case EWeaponRarity.Common:
				translation = LocalizationManager.GetTranslation("GalaxyMap/CommonWeapon");
				break;
			case EWeaponRarity.Uncommon:
				translation = LocalizationManager.GetTranslation("GalaxyMap/UncommonWeapon");
				break;
			case EWeaponRarity.Rare:
				translation = LocalizationManager.GetTranslation("GalaxyMap/RareWeapon");
				break;
			case EWeaponRarity.Epic:
				translation = LocalizationManager.GetTranslation("GalaxyMap/EpicWeapon");
				break;
			}
			string text = "" + LabelHelper.GetRarityColor(Rarity);
			LocalizationManager.ApplyLocalizationParams(ref translation, "Amount", NumberOfUpgrades.ToString());
			return text + translation;
		}

		public override string GetAmount()
		{
			return Amount.ToString();
		}

		public override void HandleReward()
		{
			if (_preset == null)
			{
				GeneratePreset();
			}
			_preset.StackSize += Amount;
			Weapon itemById = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItemById<Weapon>(_preset.UniqueID);
			if (itemById != null)
			{
				itemById.ChangeStackSize(Amount);
				itemById.Preset.StackSize += Amount;
				return;
			}
			if (!RuntimeGlobals.HasWeaponWorkshop || _preset.UpgradeSlots <= 0)
			{
				List<Weapon> list = new List<Weapon>();
				foreach (DronePart unlockedDronePart in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.Weapon))
				{
					Weapon item;
					if ((object)(item = unlockedDronePart as Weapon) != null)
					{
						list.Add(item);
					}
				}
				itemById = list.FirstOrDefault((Weapon e) => e.Preset.Emitter.WeaponType == _preset.Emitter.WeaponType && e.Preset.Ammunition.AmmunitionType == _preset.Ammunition.AmmunitionType && e.Preset.Upgrades.Count == _preset.Upgrades.Count && e.Preset.Upgrades.All((WeaponAttributeUpgrade u) => _preset.Upgrades.Any((WeaponAttributeUpgrade weaponAttributeUpgrade) => weaponAttributeUpgrade.UniqueId == u.UniqueId)));
				if (itemById != null)
				{
					itemById.ChangeStackSize(Amount);
					itemById.Preset.StackSize += Amount;
					return;
				}
			}
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GenerateAndAddWeapon(_preset);
		}

		public Weapon GetGeneratedWeapon()
		{
			if (_preset == null)
			{
				GeneratePreset();
			}
			return SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GenerateWeapon(_preset) as Weapon;
		}

		private void GeneratePreset()
		{
			_preset = WeaponPreset.GenerateRandomPreset(new System.Random(WeaponSeed), WeaponType, WeaponAmmunition, NumberOfUpgrades, !RuntimeGlobals.HasWeaponWorkshop);
		}

		public override bool IsPositive()
		{
			return true;
		}
	}
}
