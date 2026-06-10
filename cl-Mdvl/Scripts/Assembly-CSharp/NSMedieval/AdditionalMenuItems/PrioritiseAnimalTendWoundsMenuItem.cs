using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseAnimalTendWoundsMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseAnimalTendWoundsMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.TendWounds, canDoWhileDrafted: true)
		{
			if (base.Owner.GetAsTarget() is AnimalInstance animalInstance && animalInstance.HasUntendendWounds() && (animalInstance.AnimalType == AnimalType.Domestic || animalInstance.AnimalType == AnimalType.Pet))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_tending_wounds");
				base.Text = base.Text + " " + AnimalUtils.GetLocalizedName(animalInstance.Blueprint);
				if (animalInstance.IsSleeping)
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
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			AnimalInstance animalInstance = base.Owner.GetAsTarget() as AnimalInstance;
			if (selectedWorker?.GetGoapAgent() != null && animalInstance != null)
			{
				ForceGoal("TendWoundsGoal", animalInstance);
			}
		}
	}
}
