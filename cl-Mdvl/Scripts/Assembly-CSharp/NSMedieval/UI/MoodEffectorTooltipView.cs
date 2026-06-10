using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class MoodEffectorTooltipView : CreatureBaseTooltipView
	{
		private HashSet<string> goalPreferenceEffectorIds = new HashSet<string> { "GoalPreferenceVeryNegative", "GoalPreferenceNegative", "GoalPreferencePositive", "GoalPreferenceVeryPositive" };

		private List<string> tooltipArgs;

		private List<string> goals = new List<string>();

		public void SetTooltipArgs(List<string> tooltipArgs)
		{
			this.tooltipArgs = tooltipArgs;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			StatEffector byID = Repository<EffectorRepository, StatEffector>.Instance.GetByID(base.KeyId);
			string effectorName = UiUtils.GetEffectorName(byID, GetBodyType());
			string text = UiUtils.GetEffectorInfo(byID, GetBodyType(), base.Humanoid);
			if (base.KeyId == "JealousBedroom" && base.Humanoid != null && base.Humanoid.WorkerBehaviour?.JealousOfWorkersBedroom != null)
			{
				text = text.Replace("<other_name>", base.Humanoid.WorkerBehaviour.JealousOfWorkersBedroom);
			}
			if (base.CreatureBase != null)
			{
				RoleEffectorData roleEffectorData = base.CreatureBase.OnEnterRoomEffectors.FirstOrDefault((RoleEffectorData data) => data.EffectorId.Equals(base.KeyId));
				if (roleEffectorData != null)
				{
					text = HumanoidRoleUtils.ParseRoleText(text, roleEffectorData.RoleInstance.RoleOwner, roleEffectorData.RoleInstance);
				}
				RoleEffectorData roleEffectorData2 = base.CreatureBase.OnStayRoomEffectors.FirstOrDefault((RoleEffectorData data) => data.EffectorId.Equals(base.KeyId));
				if (roleEffectorData2 != null)
				{
					text = HumanoidRoleUtils.ParseRoleText(text, roleEffectorData2.RoleInstance.RoleOwner, roleEffectorData2.RoleInstance);
				}
			}
			HumanoidInstance humanoid = base.Humanoid;
			if (humanoid != null && humanoid.WorkerBehaviour != null && base.Humanoid.WorkerBehaviour.HumanoidRoleOwner.AssignedRole)
			{
				text = HumanoidRoleUtils.ParseRoleText(text, base.Humanoid, base.Humanoid.ActiveBehaviour.HumanoidRoleOwner.RoleInstance);
			}
			if (goalPreferenceEffectorIds.Contains(base.KeyId) && base.Humanoid != null)
			{
				goals.Clear();
				foreach (GoalPreference item in base.Humanoid.GoalPreferences.GetGoalPrefByEffectorId(base.KeyId))
				{
					goals.Add(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(item.LocKeys)));
				}
				text = text.Replace("<goal_names>", string.Join(", ", goals));
			}
			AppendLine(effectorName, TooltipStyles.TooltipTitle);
			if (text != "effector_info_" + base.KeyId)
			{
				AppendLine(text, TooltipStyles.TooltipDescriptionLine);
			}
			foreach (string tooltipArg in tooltipArgs)
			{
				AppendLine(tooltipArg, TooltipStyles.TooltipAttribute);
			}
			return lines;
		}
	}
}
