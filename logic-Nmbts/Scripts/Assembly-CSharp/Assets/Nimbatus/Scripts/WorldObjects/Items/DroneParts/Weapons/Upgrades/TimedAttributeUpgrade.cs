using Assets.Nimbatus.GUI.Common.Scripts;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades
{
	public class TimedAttributeUpgrade : AttributeUpgrade
	{
		public int ChangePerSecond;

		public int StartEnhancement;

		public int MaxEnhancement;

		public int MinEnhancement;

		public override string GetToolTip()
		{
			if (!Hidden)
			{
				string translation = LocalizationManager.GetTranslation("EWeaponAttributeType/" + Attribute);
				string text = ((ChangePerSecond > 0) ? ("(" + LocalizationManager.GetTranslation("DronePartSettings/Max") + GetFormattedPercentValue(MaxEnhancement) + LabelHelper.White + ")") : ("(" + LocalizationManager.GetTranslation("DronePartSettings/Min") + GetFormattedPercentValue(MinEnhancement) + LabelHelper.White + ")"));
				if (StartEnhancement != 0)
				{
					return GetFormattedPercentValue(StartEnhancement) + " " + LabelHelper.White + translation + LabelHelper.Orange + "   " + GetFormattedPercentValue(ChangePerSecond) + " " + LabelHelper.White + translation + "/s " + text;
				}
				return GetFormattedPercentValue(ChangePerSecond) + " " + LabelHelper.White + translation + "/s " + text;
			}
			return "";
		}
	}
}
