using System.Linq;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseRopeAnimalMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseRopeAnimalMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Animal)
		{
			IGoapTargetable asTarget = base.Owner.GetAsTarget();
			AnimalInstance animalInstance = asTarget as AnimalInstance;
			if (animalInstance == null)
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
			AnimalPenInstance pen = animalInstance.GetPen();
			if (pen != null && pen.CanTakeAnimal(animalInstance))
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_rope");
			base.Text = base.Text + " " + AnimalUtils.GetLocalizedName(animalInstance.Blueprint);
			if (!MonoSingleton<PenViewManager>.Instance.PenInstances.Any((AnimalPenInstance x) => x.CanTakeAnimal(animalInstance)))
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("no_valid_pen");
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
			AnimalInstance animalInstance = base.Owner.GetAsTarget() as AnimalInstance;
			if (animalInstance == null)
			{
				return;
			}
			if (!MonoSingleton<PenViewManager>.Instance.PenInstances.Any((AnimalPenInstance x) => x.CanTakeAnimal(animalInstance)))
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("no_valid_pen"));
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed)
			{
				ForceGoal("RopeAnimalGoal", animalInstance);
			}
		}
	}
}
