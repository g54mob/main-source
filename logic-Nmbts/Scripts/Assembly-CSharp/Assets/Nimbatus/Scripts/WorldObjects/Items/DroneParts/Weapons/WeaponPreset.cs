using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons
{
	[Serializable]
	public class WeaponPreset
	{
		[HideInInspector]
		public string UniqueID;

		public string Name;

		public Emitter Emitter;

		public Ammunition Ammunition;

		public int StackSize;

		public int UpgradeSlots;

		public List<WeaponAttributeUpgrade> Upgrades = new List<WeaponAttributeUpgrade>();

		private Emitter _emitter;

		public WeaponPreset()
		{
			UniqueID = Guid.NewGuid().ToString();
		}

		public bool IsUsedInDrone(RootDronePart drone)
		{
			return drone.GetAllChildParts<Weapon>().Any((Weapon w) => w.UniqueId == UniqueID);
		}

		public bool IsUsedInDrone(DronePart drone)
		{
			return drone.GetAllChildParts<Weapon>().Any((Weapon w) => w.UniqueId == UniqueID);
		}

		public bool IsCompatible(WeaponAttributeUpgrade upgrade)
		{
			if (Emitter == null)
			{
				return true;
			}
			if (upgrade == null)
			{
				return true;
			}
			Emitter emitter = UnityEngine.Object.Instantiate(Emitter);
			bool result = upgrade.IsCompatible(emitter);
			UnityEngine.Object.Destroy(emitter.gameObject);
			return result;
		}

		public void RemoveIncompatibleUpgrades()
		{
			int num = 0;
			foreach (WeaponAttributeUpgrade item in Upgrades.ToList())
			{
				num++;
				if (num > UpgradeSlots)
				{
					Upgrades.Remove(item);
				}
				else if (!(item == null) && !IsCompatible(item))
				{
					Upgrades.Remove(item);
				}
			}
		}

		public void InitFromSeed(System.Random rnd)
		{
			int seed = rnd.Next();
			int seed2 = rnd.Next();
			if (Ammunition == null)
			{
				List<Ammunition> items = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<Ammunition>();
				Ammunition = items.RandomItemProbability((Ammunition a) => a.Probability, seed);
			}
			if (Emitter == null)
			{
				Emitter = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetRandomItem<Emitter>(seed2);
			}
			Name = StringHelper.GenerateRandomWeaponName(rnd, Emitter, Ammunition);
		}

		public void FillRandomUpgrades(System.Random rng, int amount)
		{
			List<WeaponAttributeUpgrade> items = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<WeaponAttributeUpgrade>();
			items.Shuffle(rng);
			int num = 0;
			foreach (WeaponAttributeUpgrade item in items)
			{
				if (num >= amount)
				{
					break;
				}
				if (IsCompatible(item) && IsAllowed(item))
				{
					Upgrades.Add(item);
					num++;
				}
			}
		}

		private bool IsAllowed(WeaponAttributeUpgrade upgrade)
		{
			int num = 0;
			foreach (AttributeUpgrade newUpgrade in upgrade.AttributeUpgrades)
			{
				if (newUpgrade.Attribute == EWeaponAttributeType.ElementalMultiplier && (Ammunition.AmmunitionType == EAmmunitionType.Kinetic || Ammunition.AmmunitionType == EAmmunitionType.Bio))
				{
					num++;
					continue;
				}
				foreach (WeaponAttributeUpgrade upgrade2 in Upgrades)
				{
					foreach (AttributeUpgrade attributeUpgrade in upgrade2.AttributeUpgrades)
					{
						if (newUpgrade.Attribute != attributeUpgrade.Attribute)
						{
							continue;
						}
						FixedAttributeUpgrade fixedAttributeUpgrade;
						FixedAttributeUpgrade fixedAttributeUpgrade2;
						if ((fixedAttributeUpgrade = attributeUpgrade as FixedAttributeUpgrade) != null && (fixedAttributeUpgrade2 = newUpgrade as FixedAttributeUpgrade) != null)
						{
							if (!fixedAttributeUpgrade.IsPositive() || !fixedAttributeUpgrade2.IsPositive())
							{
								num++;
								continue;
							}
							Weapon weapon = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GenerateWeapon(this) as Weapon;
							FloatWeaponAttribute floatWeaponAttribute;
							if (weapon != null && (floatWeaponAttribute = weapon.Emitter.Attributes.Where((WeaponAttribute a) => a is FloatWeaponAttribute).FirstOrDefault((WeaponAttribute a) => a.Attribute == newUpgrade.Attribute) as FloatWeaponAttribute) != null && Mathf.Abs(floatWeaponAttribute.Max - floatWeaponAttribute.Value) < float.Epsilon)
							{
								num++;
							}
						}
						else
						{
							num++;
						}
					}
				}
			}
			return num < upgrade.AttributeUpgrades.Count;
		}

		public string GetTooltip()
		{
			string text = LabelHelper.Blue + Name + LabelHelper.White;
			text = string.Concat(text, LabelHelper.NewLine, LabelHelper.LightGrey, Emitter.CustomToolTip, LabelHelper.NewLine);
			text = text + LabelHelper.White + "HP: " + LabelHelper.Orange + SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponTemplate.GetComponent<HealthPool>().ActiveMaxHealth + " ";
			text = text + LabelHelper.White + "Mass: " + LabelHelper.Orange + SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponTemplate.GetComponent<Rigidbody>().mass;
			return text + LabelHelper.NewLine + LabelHelper.White + "Upgrade Slots: " + LabelHelper.Orange + UpgradeSlots;
		}

		internal void Load(WeaponPresetData presetData)
		{
			UniqueID = presetData.UniqueId;
			Name = presetData.Name;
			StackSize = presetData.StackSize;
			Ammunition = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItemById<Ammunition>(presetData.AmmunitionId);
			Emitter = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItemById<Emitter>(presetData.EmitterId);
			UpgradeSlots = presetData.UpgradeSlots;
			if (UpgradeSlots <= 0)
			{
				UpgradeSlots = presetData.Upgrades.Count;
			}
			Upgrades = new List<WeaponAttributeUpgrade>();
			int num = 0;
			foreach (string upgrade in presetData.Upgrades)
			{
				Upgrades.Add(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItemById<WeaponAttributeUpgrade>(upgrade));
				num++;
				if (num > UpgradeSlots)
				{
					break;
				}
			}
		}

		internal WeaponPresetData Save()
		{
			WeaponPresetData weaponPresetData = new WeaponPresetData();
			weaponPresetData.UniqueId = UniqueID;
			weaponPresetData.StackSize = StackSize;
			weaponPresetData.Name = Name;
			weaponPresetData.UpgradeSlots = UpgradeSlots;
			if (Ammunition != null)
			{
				weaponPresetData.AmmunitionId = Ammunition.UniqueId;
			}
			if (Emitter != null)
			{
				weaponPresetData.EmitterId = Emitter.UniqueId;
			}
			if (Upgrades != null)
			{
				weaponPresetData.Upgrades = new List<string>();
				foreach (WeaponAttributeUpgrade item in Upgrades.Where((WeaponAttributeUpgrade u) => u != null))
				{
					weaponPresetData.Upgrades.Add(item.UniqueId);
				}
			}
			return weaponPresetData;
		}

		public WeaponPreset Clone()
		{
			WeaponPresetData presetData = Save();
			WeaponPreset weaponPreset = new WeaponPreset();
			weaponPreset.Load(presetData);
			return weaponPreset;
		}

		public static WeaponPreset GenerateRandomPreset(System.Random rng, int upgradeSlots, bool fillWithUpgrades)
		{
			WeaponPreset weaponPreset = new WeaponPreset();
			weaponPreset.InitFromSeed(rng);
			weaponPreset.UpgradeSlots = upgradeSlots;
			if (fillWithUpgrades)
			{
				weaponPreset.FillRandomUpgrades(rng, upgradeSlots);
			}
			return weaponPreset;
		}

		public static WeaponPreset GenerateRandomPreset(System.Random rng, EWeaponType emitter, EAmmunitionType ammo, int upgradeCount, bool fillWithUpgrades)
		{
			WeaponPreset weaponPreset = new WeaponPreset
			{
				Emitter = ((emitter == EWeaponType.None) ? null : (from e in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<Emitter>()
					where e.WeaponType == emitter
					select e).ToList().RandomItem(rng)),
				Ammunition = ((ammo == EAmmunitionType.None) ? null : (from a in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<Ammunition>()
					where a.AmmunitionType == ammo
					select a).ToList().RandomItem(rng))
			};
			weaponPreset.InitFromSeed(rng);
			weaponPreset.UpgradeSlots = upgradeCount;
			if (fillWithUpgrades)
			{
				weaponPreset.FillRandomUpgrades(rng, upgradeCount);
			}
			return weaponPreset;
		}

		public static WeaponPreset Generate(int seed, WeaponPreset preset)
		{
			WeaponPreset weaponPreset = new WeaponPreset();
			if (preset != null)
			{
				weaponPreset = preset;
			}
			weaponPreset.InitFromSeed(new System.Random(seed));
			return weaponPreset;
		}

		public void SetUpgrade(int upgradeIndex, WeaponAttributeUpgrade upgrade)
		{
			while (Upgrades.Count <= upgradeIndex)
			{
				Upgrades.Add(null);
			}
			Upgrades[upgradeIndex] = upgrade;
		}

		public bool HasUpgrade(WeaponAttributeUpgrade upgrade)
		{
			return Upgrades.Any((WeaponAttributeUpgrade u) => u == upgrade);
		}

		public void SetDefaultName()
		{
			Name = StringHelper.GenerateStarterWeaponName(new System.Random(0), Emitter, Ammunition);
		}
	}
}
