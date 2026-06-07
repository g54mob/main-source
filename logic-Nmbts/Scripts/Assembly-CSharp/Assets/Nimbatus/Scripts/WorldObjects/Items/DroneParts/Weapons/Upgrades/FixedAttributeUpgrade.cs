using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades
{
	public class FixedAttributeUpgrade : AttributeUpgrade
	{
		public int Enhancement;

		public override string GetToolTip()
		{
			if (!Hidden)
			{
				string translation = LocalizationManager.GetTranslation("EWeaponAttributeType/" + Attribute);
				return LabelHelper.Green + GetFormattedPercentValue(Enhancement) + " " + LabelHelper.White + translation;
			}
			return "";
		}

		public bool IsPositive()
		{
			if (Attribute == EWeaponAttributeType.EnergyUsage || Attribute == EWeaponAttributeType.Recoil)
			{
				return Enhancement < 0;
			}
			return Enhancement > 0;
		}
	}
}
