using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseTamingMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseTamingMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Animal)
		{
			if (!(base.Owner.GetAsTarget() is AnimalInstance { AnimalType: var animalType } animalInstance))
			{
				base.IsEnabled = false;
				return;
			}
			if (animalType == AnimalType.Domestic || animalType == AnimalType.Pet || animalType == AnimalType.DomesticNpc || animalType == AnimalType.WildAggressive)
			{
				base.IsEnabled = false;
				return;
			}
			if (!animalInstance.Blueprint.CanBeTamed)
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_taming");
			base.Text = base.Text + " " + AnimalUtils.GetLocalizedName(animalInstance.Blueprint);
			if (animalInstance.IsSleeping)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("cant_interact_sleeping_animal");
				base.IsEnabled = false;
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null)
			{
				base.IsEnabled = false;
				return;
			}
			if (selectedWorker.Skills.GetSkill(SkillType.AnimalHandling).Level < animalInstance.Blueprint.MinTameSkill)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("error_no_skilled_animal_worker", GetSelectedWorker());
				base.IsEnabled = false;
				return;
			}
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(animalInstance);
			DisableIfReserved();
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			if (!(base.Owner.GetAsTarget() is AnimalInstance animalInstance))
			{
				return;
			}
			if (!animalInstance.CanTryTaming)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("tame_try_maximum"));
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Tame, animalInstance);
				ForceGoal("TameAnimalGoal", animalInstance);
			}
		}
	}
}
