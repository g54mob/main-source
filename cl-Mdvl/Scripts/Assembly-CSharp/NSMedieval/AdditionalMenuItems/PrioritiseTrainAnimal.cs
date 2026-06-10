using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseTrainAnimal : AdditionalMenuPrioritiseItem
	{
		public PrioritiseTrainAnimal(IAdditionalMenuOwner owner)
			: base(owner, JobType.Animal)
		{
			if (!(base.Owner.GetAsTarget() is AnimalInstance animalInstance))
			{
				base.IsEnabled = false;
				return;
			}
			if (animalInstance.IsAtEvent())
			{
				base.IsEnabled = false;
				return;
			}
			if (animalInstance.AnimalType != AnimalType.Domestic)
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_train");
			base.Text = base.Text + " " + AnimalUtils.GetLocalizedName(animalInstance.Blueprint);
			if (GetSelectedWorker()?.Skills.GetSkill(SkillType.AnimalHandling).Level < animalInstance.Blueprint.MinTrainSkill)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("error_no_skilled_animal_worker");
				base.IsEnabled = false;
			}
			else if (animalInstance.IsSleeping)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("cant_interact_sleeping_animal");
				base.IsEnabled = false;
			}
			else
			{
				EnableIfWorkerIsSelected();
				DisableIfUnreachableFromSelectedWorker(animalInstance);
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			if (!(base.Owner.GetAsTarget() is AnimalInstance animalInstance))
			{
				return;
			}
			if (!animalInstance.CanTryTraining)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("train_try_maximum"));
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Train, animalInstance);
				ForceGoal("TrainAnimalGoal", animalInstance);
			}
		}
	}
}
