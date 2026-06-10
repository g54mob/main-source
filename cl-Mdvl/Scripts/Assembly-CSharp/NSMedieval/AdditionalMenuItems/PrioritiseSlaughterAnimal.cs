using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseSlaughterAnimal : AdditionalMenuPrioritiseItem
	{
		public PrioritiseSlaughterAnimal(IAdditionalMenuOwner owner)
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
			if (animalInstance.AnimalType != AnimalType.Domestic && animalInstance.AnimalType != AnimalType.Pet)
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_slaughter");
			base.Text = base.Text + " " + AnimalUtils.GetLocalizedName(animalInstance.Blueprint);
			EnableIfWorkerIsSelected();
			DisableIfUnreachableFromSelectedWorker(animalInstance);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is AnimalInstance animalInstance)
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Slaughter, animalInstance);
				ForceGoal("SlaughterAnimalGoal", animalInstance);
			}
		}
	}
}
