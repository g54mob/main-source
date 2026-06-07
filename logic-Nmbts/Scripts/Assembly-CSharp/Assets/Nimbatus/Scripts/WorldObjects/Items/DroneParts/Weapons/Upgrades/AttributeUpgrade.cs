using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades
{
	[Serializable]
	public abstract class AttributeUpgrade
	{
		public EWeaponAttributeType Attribute;

		public bool Hidden;

		public abstract string GetToolTip();

		protected string GetFormattedPercentValue(int value)
		{
			if (value == 0)
			{
				return LabelHelper.White ?? "";
			}
			if (value > 0)
			{
				return LabelHelper.Green + "+ " + value + "%";
			}
			return LabelHelper.Red + "- " + Math.Abs(value) + "%";
		}
	}
}
