using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.Model;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class EnemyMoodExtraPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private LayoutGroupView moodParent;

		[SerializeField]
		private FillBarLayoutItemView moodBar;

		private readonly List<EffectorLayoutItemView> moodEffectors = new List<EffectorLayoutItemView>();

		protected override void SetupTabPanel()
		{
			StatInstance stat = base.Humanoid.Stats.GetStat(StatType.Mood);
			moodBar.SetBasicData(StatUtils.GetLocalizedName(stat.Blueprint, base.Humanoid.Info.BodyType), StatType.Mood.ToString(), string.Empty, string.Empty, StatUtils.GetTooltipLines(stat, base.Humanoid.Info.BodyType), stat.StatTrend, StatUtils.GetSliderValues(stat), StatUtils.GetThresholds(stat), stat.Target, invertArrows: false, string.Empty);
			GetMoodModifiers();
		}

		private void GetMoodModifiers()
		{
			SortedList<float, EffectorViewData> sortedList = new SortedList<float, EffectorViewData>(Comparer<float>.Create(CompareInverse));
			foreach (ModifierInstanceStack item in base.Humanoid.Stats.GetModifierInstanceStack())
			{
				foreach (ModifierInstance instance in item.Instances)
				{
					StatEffector effector = instance.Effector;
					if (!(instance is MoodBasicModifierInstance) || effector == null || !effector.UIGroup.HasFlag(EffectorUiGroup.Mood))
					{
						continue;
					}
					MoodBasicModifierInstance moodBasicModifierInstance = instance as MoodBasicModifierInstance;
					float num = (float)Math.Round(moodBasicModifierInstance.ModifierValuePair.Value, 2);
					if (Math.Abs(num) < 0.001f)
					{
						continue;
					}
					string key = moodBasicModifierInstance.ModifierValuePair.Key;
					bool isEnabled;
					if (string.IsNullOrEmpty(moodBasicModifierInstance.Tag))
					{
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\EnemyMoodExtraPanel.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("MoodBasicModifierInstance ");
							messageBuilder.AppendFormatted(key);
							messageBuilder.AppendLiteral(": 'Tag' is either null or empty!");
						}
						Log.Warning(messageBuilder);
						continue;
					}
					int firstIndexOfEffector = base.Humanoid.Stats.GetFirstIndexOfEffector(moodBasicModifierInstance.Tag);
					if (firstIndexOfEffector == -1)
					{
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\EnemyMoodExtraPanel.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("ActiveEffectorInfo: ");
							messageBuilder.AppendFormatted(key);
							messageBuilder.AppendLiteral(", does not exist!");
						}
						Log.Warning(messageBuilder);
						continue;
					}
					ActiveEffectorInfo effectorByIndex = base.Humanoid.Stats.GetEffectorByIndex(firstIndexOfEffector);
					if (effectorByIndex.Blueprint == null)
					{
						FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\EnemyMoodExtraPanel.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("ActiveEffectorInfo: ");
							messageBuilder.AppendFormatted(key);
							messageBuilder.AppendLiteral(", 'Blueprint' is null!");
						}
						Log.Warning(messageBuilder);
					}
					else
					{
						LocKeys[] locKeys = effectorByIndex.Blueprint.LocKeys;
						int stackCount = 1 + effectorByIndex.StackCount;
						float minutesLeft = -1f;
						if (effectorByIndex.TimeLeft() > 0f)
						{
							minutesLeft = effectorByIndex.TimeLeft();
						}
						sortedList.Add(num, new EffectorViewData(key, num, stackCount, minutesLeft, null, locKeys));
					}
				}
			}
			for (int i = 0; i < sortedList.Values.Count; i++)
			{
				EffectorViewData data = sortedList.Values[i];
				moodEffectors.GetAt(moodParent, i).SetStatData(data, base.Humanoid, i);
			}
			moodEffectors.SetActiveFromIndex(sortedList.Values.Count, active: false);
		}

		protected override void UpdateTabPanel()
		{
			SetupTabPanel();
		}

		private int CompareInverse(float x, float y)
		{
			if ((double)y < (double)x)
			{
				return -1;
			}
			_ = (double)y;
			_ = (double)x;
			return 1;
		}
	}
}
