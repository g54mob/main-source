using System.Collections.Generic;
using System.Globalization;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class EffectorLayoutItemView : LayoutGroupItemView
	{
		private const int TitleIndex = 0;

		private const int ValueIndex = 1;

		private CreatureBase creatureBase;

		public void SetStatData(EffectorViewData data, HumanoidInstance humanoid, int index)
		{
			creatureBase = humanoid;
			SetStatData(data, index, humanoid.Info.BodyType);
			if (GetTooltip(data, out var tooltipOut))
			{
				tooltipOut.SetTooltipData(data.Name, humanoid);
			}
		}

		public void SetStatData(EffectorViewData data, AnimalInstance animal, int index)
		{
			SetStatData(data, index, animal.Gender);
			if (GetTooltip(data, out var tooltipOut))
			{
				tooltipOut.SetTooltipData(data.Name, animal);
			}
		}

		private bool GetTooltip(EffectorViewData data, out MoodEffectorTooltipView tooltipOut)
		{
			tooltipOut = base.TooltipNew as MoodEffectorTooltipView;
			if ((object)tooltipOut == null)
			{
				return false;
			}
			List<string> list = new List<string>();
			if (data.MinutesLeft > 0f)
			{
				list.Add(MonoSingleton<LocalizationController>.Instance.GetText("expires_in") + ": " + UiUtils.GetTimeFormatByMinutes(data.MinutesLeft, isDuration: true));
			}
			if (data.Attributes != null)
			{
				foreach (KeyValuePair<string, string> attribute in data.Attributes)
				{
					if (!attribute.Key.TryParseEnumNameOrInt<AttributeType>(out var parsedEnumValue))
					{
						bool isEnabled;
						FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\EffectorLayoutItemView.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Failed to parse attribute enum '");
							messageBuilder.AppendFormatted(attribute.Key);
							messageBuilder.AppendLiteral("'");
						}
						Log.Error(messageBuilder);
					}
					Attribute byID = Repository<AttributeRepository, Attribute>.Instance.GetByID($"{parsedEnumValue}");
					string text = AttributeUtils.GetLocalizedAttributeName(byID) ?? "";
					if (!(text == string.Empty))
					{
						if (float.TryParse(attribute.Value, out var result))
						{
							text = text + " " + AttributeUtils.GetLocalizedAttributeModifier(byID, result);
						}
						list.Add(text);
					}
				}
			}
			tooltipOut.SetTooltipArgs(list);
			return true;
		}

		private void SetStatData(EffectorViewData data, int index, BodyType bodyType)
		{
			string text = UiUtils.GetEffectorName(Repository<EffectorRepository, StatEffector>.Instance.GetByID(data.Name), bodyType);
			if (data.StackCount > 1)
			{
				text = $"{data.StackCount}X {text}";
			}
			SetText(0, text);
			string text2 = (float.IsNaN(data.Value) ? string.Empty : UiUtils.FormatPositiveNegative(data.Value.ToString(CultureInfo.InvariantCulture), data.Value));
			SetText(1, text2);
			SetBackground(index);
		}
	}
}
