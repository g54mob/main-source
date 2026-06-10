using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class GoalPreferenceTooltipView : CreatureBaseTooltipView
	{
		private GoalPreferenceLevel goalPreferenceLevel;

		public void SetData(CreatureBase creature, GoalPreferenceLevel goalPreferenceType)
		{
			goalPreferenceLevel = goalPreferenceType;
			SetTooltipData(creature);
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			GoalPreferenceLevelData dataByPreferenceLevel = Repository<GoalPreferenceLevelRepository, GoalPreferenceLevelData>.Instance.GetDataByPreferenceLevel(goalPreferenceLevel);
			AppendLine(AssetUtils.GetSpriteAsset(goalPreferenceLevel.ToString().ToLower()) + " " + LocKeyUtils.GetName(dataByPreferenceLevel.LocKeys).ToLocalized(base.CreatureBase.GetInfo().BodyType), TooltipStyles.TooltipTitle);
			AppendLine(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(dataByPreferenceLevel.LocKeys)), TooltipStyles.TooltipDescriptionLine);
			if (goalPreferenceLevel == GoalPreferenceLevel.Indifferent || goalPreferenceLevel == GoalPreferenceLevel.None)
			{
				return lines;
			}
			AppendLine(HumanoidUtils.GetLocalizedGoalPrefLevel(base.Humanoid, goalPreferenceLevel));
			return lines;
		}
	}
}
