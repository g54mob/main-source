using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSMedieval.Model;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class AnimalStatsExtraPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private List<StatType> stats;

		[SerializeField]
		private LayoutGroupView statsParent;

		[SerializeField]
		private LayoutGroupView effectorsParent;

		private readonly List<FillBarLayoutItemView> workerStats = new List<FillBarLayoutItemView>();

		private readonly List<EffectorLayoutItemView> statEffectors = new List<EffectorLayoutItemView>();

		protected override void SetupTabPanel()
		{
			if (base.Animal == null || base.Animal.HasDisposed)
			{
				return;
			}
			int num = 0;
			foreach (StatType stat2 in stats)
			{
				StatInstance stat = base.Animal.Stats.GetStat(stat2);
				if (stat != null)
				{
					FillBarLayoutItemView at = workerStats.GetAt(statsParent, num);
					num++;
					at.SetBasicData(StatUtils.GetLocalizedName(stat.Blueprint, base.Animal.GetInfo().BodyType), stat2.ToString(), string.Empty, string.Empty, StatUtils.GetTooltipLines(stat, base.Animal.Gender), stat.StatTrend, StatUtils.GetSliderValues(stat), StatUtils.GetThresholds(stat), null, invertArrows: false, string.Empty);
				}
			}
			workerStats.SetActiveFromIndex(num, active: false);
			List<EffectorViewData> list = new List<EffectorViewData>();
			foreach (ActiveEffectorInfo activeEffector in base.Animal.Stats.Stats.First().Value.Owner.GetActiveEffectors())
			{
				if (!activeEffector.Blueprint.UIGroup.HasFlag(EffectorUiGroup.Stats))
				{
					continue;
				}
				string text = activeEffector.Name;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				int num2 = 1;
				float minutesLeft = -1f;
				num2 += activeEffector.StackCount;
				if (activeEffector.TimeLeft() > 0f)
				{
					minutesLeft = activeEffector.TimeLeft();
				}
				LocKeys[] locKeys = null;
				if (activeEffector.Blueprint != null)
				{
					locKeys = activeEffector.Blueprint.LocKeys;
					EffectDetailsHolder[] effects = activeEffector.Blueprint.Effects;
					foreach (EffectDetailsHolder effectDetailsHolder in effects)
					{
						if ((effectDetailsHolder.Type == EffectorType.AttributeModify || effectDetailsHolder.Type == EffectorType.AttributeAdderModify) && effectDetailsHolder.Parameters.TryGetValue("Attribute", out var value))
						{
							dictionary[value] = string.Empty;
							if (effectDetailsHolder.Parameters.TryGetValue("Multiplier", out var value2))
							{
								dictionary[effectDetailsHolder.Parameters["Attribute"]] = value2;
							}
							if (effectDetailsHolder.Parameters.TryGetValue("Value", out var value3))
							{
								dictionary[effectDetailsHolder.Parameters["Attribute"]] = value3;
							}
						}
					}
				}
				list.Add(new EffectorViewData(text, float.NaN, num2, minutesLeft, dictionary, locKeys));
			}
			num = 0;
			foreach (EffectorViewData item in list)
			{
				statEffectors.GetAt(effectorsParent, num).SetStatData(item, base.Animal, num);
				num++;
			}
			statEffectors.SetActiveFromIndex(list.Count, active: false);
		}

		protected override void UpdateTabPanel()
		{
			SetupTabPanel();
		}
	}
}
