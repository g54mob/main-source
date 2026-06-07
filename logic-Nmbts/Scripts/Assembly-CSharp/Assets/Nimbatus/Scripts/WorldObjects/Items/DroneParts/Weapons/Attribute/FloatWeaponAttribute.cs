using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute
{
	public class FloatWeaponAttribute : WeaponAttribute
	{
		public float BaseValue;

		[HideInInspector]
		public int NumberOfDigits;

		public bool CustomRange;

		[ShowIf("CustomRange", true)]
		public float Min;

		[ShowIf("CustomRange", true)]
		public float Max;

		private List<FloatUpgrade> _activeUpgrades = new List<FloatUpgrade>();

		[HideInInspector]
		private float _perkModifier;

		[HideInInspector]
		public float Value
		{
			get
			{
				float num = BaseValue;
				float enhancementPercentage = EnhancementPercentage;
				if (enhancementPercentage > 0f)
				{
					num = Mathf.Max(Min, Mathf.Min(Max, BaseValue * ((100f + enhancementPercentage) / 100f)));
				}
				if (enhancementPercentage < 0f)
				{
					num = Mathf.Min(Max, Mathf.Max(Min, BaseValue * ((100f + enhancementPercentage) / 100f)));
				}
				return (float)Math.Round(num, NumberOfDigits);
			}
		}

		[HideInInspector]
		public float EnhancementPercentage
		{
			get
			{
				float num = 0f;
				if (_activeUpgrades != null && _activeUpgrades.Count > 0)
				{
					for (int i = 0; i < _activeUpgrades.Count; i++)
					{
						FloatUpgrade floatUpgrade = _activeUpgrades[i];
						num += floatUpgrade.CurrentUpgradeValue;
					}
				}
				return num + _perkModifier;
			}
		}

		public void Init(EWeaponAttributeType attribute, int digits, float min, float max, bool usedByPlayer, bool hidden = false)
		{
			Init(attribute, hidden);
			NumberOfDigits = digits;
			if (!CustomRange)
			{
				Max = max;
				Min = min;
			}
			_activeUpgrades = new List<FloatUpgrade>();
			_activeUpgrades.Clear();
			_perkModifier = 0f;
			if (!usedByPlayer || SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects == null)
			{
				return;
			}
			foreach (DroneWeaponEffect item in SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects.OfType<DroneWeaponEffect>())
			{
				if (item.Upgrade.Attribute == Attribute)
				{
					_perkModifier += item.Upgrade.Enhancement;
				}
			}
		}

		public List<FloatUpgrade> GetActiveUpgrades()
		{
			return _activeUpgrades;
		}

		public override string ToString()
		{
			if (Math.Abs(EnhancementPercentage) > 0.001f)
			{
				return LabelHelper.White + AttributeName + ": " + LabelHelper.Green + Value.ToString("###0.###", CultureInfo.InvariantCulture) + LabelHelper.LightGrey + " (" + EnhancementPercentage.ToString("###0.###") + "%)";
			}
			return LabelHelper.White + AttributeName + ": " + LabelHelper.Orange + Value.ToString("###0.###", CultureInfo.InvariantCulture);
		}

		public override void ApplyUpgrade(WeaponAttributeUpgrade emitterUpgrade)
		{
			if (emitterUpgrade == null)
			{
				return;
			}
			foreach (AttributeUpgrade attributeUpgrade in emitterUpgrade.AttributeUpgrades.Where((AttributeUpgrade a) => a.Attribute == Attribute))
			{
				if (_activeUpgrades.All((FloatUpgrade u) => u.Upgrade != attributeUpgrade))
				{
					_activeUpgrades.Add(new FloatUpgrade(attributeUpgrade));
				}
			}
		}

		public override void Update(bool shooting)
		{
			for (int i = 0; i < _activeUpgrades.Count; i++)
			{
				FloatUpgrade floatUpgrade = _activeUpgrades[i];
				TimedAttributeUpgrade timedAttributeUpgrade = floatUpgrade.Upgrade as TimedAttributeUpgrade;
				if (timedAttributeUpgrade != null)
				{
					if (shooting)
					{
						float a = floatUpgrade.CurrentUpgradeValue + (float)timedAttributeUpgrade.ChangePerSecond * Time.deltaTime;
						a = Mathf.Min(a, timedAttributeUpgrade.MaxEnhancement);
						a = Mathf.Max(a, timedAttributeUpgrade.MinEnhancement);
						floatUpgrade.CurrentUpgradeValue = a;
					}
					else
					{
						floatUpgrade.CurrentUpgradeValue = timedAttributeUpgrade.StartEnhancement;
					}
				}
			}
		}
	}
}
