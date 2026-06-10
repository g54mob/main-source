using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseAnimalHarvestMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseAnimalHarvestMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Animal)
		{
			if (!(base.Owner.GetAsTarget() is AnimalInstance animalInstance))
			{
				base.IsEnabled = false;
				return;
			}
			if (animalInstance.AnimalType != AnimalType.Domestic && animalInstance.AnimalType != AnimalType.Pet)
			{
				base.IsEnabled = false;
				return;
			}
			if (!animalInstance.HasHarvestableProduction())
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_animal_harvest");
			base.Text = base.Text + " " + AnimalUtils.GetLocalizedName(animalInstance.Blueprint);
			if (animalInstance.IsSleeping)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("cant_interact_sleeping_animal");
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
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is AnimalInstance animalInstance)
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Harvest, animalInstance);
				ForceGoal("HarvestAnimalGoal", animalInstance);
			}
		}
	}
}
