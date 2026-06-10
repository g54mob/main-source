using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;

namespace NSMedieval.AdditionalMenuItems
{
	public abstract class AdditionalMenuPrioritiseItem : AdditionalMenuItemBase
	{
		private const float ExclusiveReservation = 1f;

		protected AdditionalMenuPrioritiseItem(IAdditionalMenuOwner owner, JobType requiredJob = JobType.None, bool canDoWhileDrafted = false, bool showWorkerSkillInTitle = true)
			: base(owner, requiredJob, canDoWhileDrafted)
		{
			base.IsEnabled = true;
			if (showWorkerSkillInTitle)
			{
				ShowWorkerSkillInTitle();
			}
		}

		private void ShowWorkerSkillInTitle()
		{
			base.MenuTitle = string.Empty;
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker != null && base.RequiredJob != JobType.None)
			{
				Job byJobType = Repository<JobRepository, Job>.Instance.GetByJobType(base.RequiredJob);
				if (byJobType.RelatedSkill != SkillType.None)
				{
					base.MenuTitle = selectedWorker.Info.FirstName + " (" + AdditionalMenuItemUtil.GenerateSkillInfo(byJobType.RelatedSkill.ToString().ToLower(), selectedWorker.GetSkillLevel(byJobType.RelatedSkill)) + ")";
				}
			}
		}

		protected void ForceGoal(string goalId, IReservable setPreferredReservable, HumanoidInstance goalExecutor = null)
		{
			HumanoidInstance humanoidInstance = goalExecutor ?? GetSelectedWorker();
			if (!(humanoidInstance?.GetGoapAgent() is WorkerGoapAgent workerGoapAgent))
			{
				return;
			}
			if (setPreferredReservable != null)
			{
				MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(humanoidInstance, setPreferredReservable);
				if (!MonoSingleton<ReservationManager>.Instance.TryToExclusiveReservation(setPreferredReservable, humanoidInstance, 1f))
				{
					bool flag;
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(46, 1, out flag, "C:\\GIT\\dev\\Assets\\Scripts\\Component\\AdditionalMenu\\Items\\AdditionalMenuPrioritiseItem.cs");
					if (flag)
					{
						messageBuilder.AppendLiteral("Could not exclusive reserve item for humanoid:");
						messageBuilder.AppendFormatted(humanoidInstance);
					}
					Log.Warning(messageBuilder);
				}
			}
			workerGoapAgent.Abort();
			workerGoapAgent.ForceNextGoalExclusive(goalId);
		}

		protected override string GetButtonTextSuffix()
		{
			if (base.RequiredJob == JobType.None)
			{
				return string.Empty;
			}
			string text = MonoSingleton<LocalizationController>.Instance.GetText("job_name_" + base.RequiredJob.ToString().ToLower());
			return "\n<style=Desc>" + MonoSingleton<LocalizationController>.Instance.GetText("general_job") + ": " + text;
		}
	}
}
