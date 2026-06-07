using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute
{
	public abstract class WeaponAttribute
	{
		[NonSerialized]
		[HideInInspector]
		public string AttributeName;

		[NonSerialized]
		[HideInInspector]
		public EWeaponAttributeType Attribute;

		[NonSerialized]
		[HideInInspector]
		public bool Hidden;

		public void Init(EWeaponAttributeType attribute, bool hidden = false)
		{
			Attribute = attribute;
			Hidden = hidden;
			AttributeName = LocalizationManager.GetTranslation("EWeaponAttributeType/" + Attribute);
		}

		public abstract void ApplyUpgrade(WeaponAttributeUpgrade emitterUpgrade);

		public abstract void Update(bool shooting);
	}
}
