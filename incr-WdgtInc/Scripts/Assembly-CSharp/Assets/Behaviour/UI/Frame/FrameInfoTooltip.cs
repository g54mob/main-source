using Assets.Source.Buff;
using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.UI.Frame
{
	public class FrameInfoTooltip : MonoBehaviour, ITooltipCustomSource
	{
		public void AddTooltipCustomContent(UITooltip tooltip)
		{
			AddTooltipInfoContent(ActiveWorldFrame.Current.ActiveFrame, tooltip);
			tooltip.AddTextLine("");
			tooltip.AddTextLine("@ToolbarInformationDesc");
		}

		public static void AddTooltipInfoContent(WorldFrame frame, UITooltip tooltip)
		{
			tooltip.AddTextLine("@FrameDetailsSpeed");
			double upgradeMultiplier = frame.GetUpgradeMultiplier(FrameUpgradeType.Speed);
			if (upgradeMultiplier > 1.0)
			{
				tooltip.AddTextLine(Translation.Translate("@FrameDetailsUpgrades") + " " + GameMath.FormatPercentage(upgradeMultiplier, FormatPercentageMode.Offset));
			}
			foreach (FrameBuff buff in frame.Buffs)
			{
				double speedMultiplier = buff.GetSpeedMultiplier(frame, handCraft: false);
				if (speedMultiplier > 1.0)
				{
					tooltip.AddTextLine(Translation.Translate(buff.Ability.DisplayName) + ": " + GameMath.FormatPercentage(speedMultiplier, FormatPercentageMode.Offset));
				}
			}
			foreach (FrameBuff buff2 in GamePlayer.Current.Buffs)
			{
				double speedMultiplier2 = buff2.GetSpeedMultiplier(frame, handCraft: false);
				if (speedMultiplier2 > 1.0)
				{
					tooltip.AddTextLine(Translation.Translate(buff2.Ability.DisplayName) + ": " + GameMath.FormatPercentage(speedMultiplier2, FormatPercentageMode.Offset));
				}
			}
			double servitudeSpeedMultiplier = frame.GetServitudeSpeedMultiplier();
			if (servitudeSpeedMultiplier > 1.0)
			{
				tooltip.AddTextLine(Translation.Translate("@t6u_indentured_servitude_name") + ": " + GameMath.FormatPercentage(servitudeSpeedMultiplier, FormatPercentageMode.Offset));
			}
			double logisticsSpeedMultiplier = frame.GetLogisticsSpeedMultiplier();
			if (logisticsSpeedMultiplier > 1.0)
			{
				tooltip.AddTextLine(Translation.Translate("@t3f_logistics_hub_name") + ": " + GameMath.FormatPercentage(logisticsSpeedMultiplier, FormatPercentageMode.Offset));
			}
			tooltip.AddTextLine(Translation.Translate("@FrameDetailsTotal") + " " + GameMath.FormatPercentage(frame.GetSpeedMultiplier(handCraft: false), FormatPercentageMode.Offset));
			tooltip.AddTextLine("");
			tooltip.AddTextLine("@FrameDetailsProductivity");
			double upgradeMultiplier2 = frame.GetUpgradeMultiplier(FrameUpgradeType.Productivity);
			if (upgradeMultiplier2 > 1.0)
			{
				tooltip.AddTextLine(Translation.Translate("@FrameDetailsUpgrades") + " " + GameMath.FormatPercentage(upgradeMultiplier2, FormatPercentageMode.Offset));
			}
			if (GamePlayer.Current.CityProductivityMultiplier > 1f)
			{
				tooltip.AddTextLine(Translation.Translate("@T8CityBuilderLabel") + ": " + GameMath.FormatPercentage(GamePlayer.Current.CityProductivityMultiplier, FormatPercentageMode.Offset));
			}
			foreach (FrameBuff buff3 in frame.Buffs)
			{
				double productivityMultiplier = buff3.GetProductivityMultiplier(frame, handCraft: false);
				if (productivityMultiplier > 1.0)
				{
					tooltip.AddTextLine(Translation.Translate(buff3.Ability.DisplayName) + ": " + GameMath.FormatPercentage(productivityMultiplier, FormatPercentageMode.Offset));
				}
			}
			foreach (FrameBuff buff4 in GamePlayer.Current.Buffs)
			{
				double productivityMultiplier2 = buff4.GetProductivityMultiplier(frame, handCraft: false);
				if (productivityMultiplier2 > 1.0)
				{
					tooltip.AddTextLine(Translation.Translate(buff4.Ability.DisplayName) + ": " + GameMath.FormatPercentage(productivityMultiplier2, FormatPercentageMode.Offset));
				}
			}
			double servitudeProductivityMultiplier = frame.GetServitudeProductivityMultiplier();
			if (servitudeProductivityMultiplier > 1.0)
			{
				tooltip.AddTextLine(Translation.Translate("@t6u_indentured_servitude_name") + ": " + GameMath.FormatPercentage(servitudeProductivityMultiplier, FormatPercentageMode.Offset));
			}
			double logisticsProductivityMultiplier = frame.GetLogisticsProductivityMultiplier();
			if (logisticsProductivityMultiplier > 1.0)
			{
				tooltip.AddTextLine(Translation.Translate("@t3f_logistics_hub_name") + ": " + GameMath.FormatPercentage(logisticsProductivityMultiplier, FormatPercentageMode.Offset));
			}
			tooltip.AddTextLine(Translation.Translate("@FrameDetailsTotal") + " " + GameMath.FormatPercentage(frame.GetProductivityMultiplier(handCraft: false), FormatPercentageMode.Offset));
		}
	}
}
