using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades
{
	[Serializable]
	public class WeaponAttributeUpgrade : NimbatusItem, IBuyable
	{
		public bool AllWeaponTypes;

		[HideIf("AllWeaponTypes", true)]
		[OdinSerialize]
		protected List<EWeaponType> AllowedWeaponTypes = new List<EWeaponType>();

		[OdinSerialize]
		protected internal List<AttributeUpgrade> AttributeUpgrades = new List<AttributeUpgrade>();

		[OdinSerialize]
		protected internal List<WeaponAttributeUpgrade> ParentUpgrades = new List<WeaponAttributeUpgrade>();

		[NonSerialized]
		protected internal List<WeaponAttributeUpgrade> ChildUpgrades = new List<WeaponAttributeUpgrade>();

		[OdinSerialize]
		protected internal EWeaponUpgradeLevel UpgradeLevel;

		public override void InitStackSettings()
		{
			IsStackable = false;
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip();
			bool flag = true;
			foreach (AttributeUpgrade attributeUpgrade in AttributeUpgrades)
			{
				if (!string.IsNullOrEmpty(attributeUpgrade.GetToolTip()))
				{
					if (!flag)
					{
						text += Environment.NewLine;
					}
					else
					{
						flag = false;
					}
					text += attributeUpgrade.GetToolTip();
				}
			}
			return text;
		}

		public bool IsCompatible(Emitter emitter)
		{
			if (!AllWeaponTypes && AllowedWeaponTypes != null && !AllowedWeaponTypes.Contains(emitter.WeaponType))
			{
				return false;
			}
			return AttributeUpgrades.TrueForAll((AttributeUpgrade a) => emitter.Attributes.Any((WeaponAttribute weaponAttribute) => weaponAttribute.Attribute == a.Attribute));
		}

		protected Dictionary<ETerrainMaterial, int> GetPriceInternal()
		{
			int num = CalculateTier();
			int num2 = MaxTier(num);
			Dictionary<ETerrainMaterial, int> dictionary = new Dictionary<ETerrainMaterial, int>();
			if (RuntimeGlobals.GameModeSettings.HasPartUnlocking)
			{
				int value = Mathf.CeilToInt(20f * (float)num * ((num2 <= 3) ? 2f : ((7f + (float)(num2 - 3)) / (float)num2)) / 10f) * 10;
				dictionary.Add(ETerrainMaterial.RareOre, value);
			}
			else if (num <= 2)
			{
				dictionary.Add(ETerrainMaterial.CommonOre, 80 * num);
			}
			else
			{
				dictionary.Add(ETerrainMaterial.CommonOre, Mathf.CeilToInt((float)(100 * num) * (5f / (float)num2) / 10f) * 10);
				dictionary.Add(ETerrainMaterial.RareOre, Mathf.CeilToInt((float)(20 * num) * (5f / (float)num2) / 10f) * 10);
			}
			return dictionary;
		}

		protected int CalculateTier()
		{
			if (ParentUpgrades != null && ParentUpgrades.Count > 0)
			{
				return ParentUpgrades.Max((WeaponAttributeUpgrade p) => p.CalculateTier()) + 1;
			}
			return 0;
		}

		public void AddChild(WeaponAttributeUpgrade child)
		{
			if (!ChildUpgrades.Contains(child))
			{
				ChildUpgrades.Add(child);
			}
		}

		protected int MaxTier(int max)
		{
			foreach (WeaponAttributeUpgrade childUpgrade in ChildUpgrades)
			{
				max = Mathf.Max(max, childUpgrade.CalculateTier());
				max = childUpgrade.MaxTier(max);
			}
			return max;
		}

		public Dictionary<ETerrainMaterial, int> GetPrice()
		{
			return GetPriceInternal();
		}

		public void Buy()
		{
			if (!HasResourcesToBuy() || Unlocked)
			{
				return;
			}
			foreach (KeyValuePair<ETerrainMaterial, int> item in GetPrice())
			{
				SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.UseResources(item.Key, item.Value);
			}
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.Unlock(this);
		}

		public void ChangeLockStatus(bool unlock)
		{
			if (unlock)
			{
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.Unlock(this);
			}
			else
			{
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.Lock(this);
			}
		}

		public bool HasResourcesToBuy()
		{
			bool flag = true;
			foreach (KeyValuePair<ETerrainMaterial, int> item in GetPrice())
			{
				flag &= SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.HasResources(item.Key, item.Value);
			}
			return flag;
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
		}

		public override NimbatusItemData CreateData()
		{
			return new NimbatusItemData();
		}
	}
}
