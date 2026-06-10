using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseHuntingMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseHuntingMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Hunting)
		{
			if (!(base.Owner.GetAsTarget() is AnimalInstance animalInstance))
			{
				base.IsEnabled = false;
				return;
			}
			if (animalInstance.AnimalType == AnimalType.Domestic || animalInstance.AnimalType == AnimalType.Pet || animalInstance.AnimalType == AnimalType.DomesticNpc)
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_hunting");
			base.Text = base.Text + " " + AnimalUtils.GetLocalizedName(animalInstance.Blueprint);
			EnableIfWorkerIsSelected();
			if (base.IsEnabled)
			{
				HumanoidInstance selectedWorker = GetSelectedWorker();
				if (!CombatUtils.HasRangedWeapon(selectedWorker))
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("hunting_requires_ranged_weapon", selectedWorker);
					base.IsEnabled = false;
				}
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is AnimalInstance animalInstance)
			{
				MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.Hunt, animalInstance);
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(selectedWorker, animalInstance);
				ForceGoal("HuntingGoal", animalInstance);
			}
		}
	}
}
