using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseBuildingConstructionMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseBuildingConstructionMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.Construction)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance))
			{
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_building_construction");
				base.IsEnabled = false;
			}
			else
			{
				if (!baseBuildingInstance.OwnedByPlayer())
				{
					return;
				}
				base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_building_construction");
				base.Text = base.Text + " " + BuildingUtils.GetLocalizedName(baseBuildingInstance.Blueprint.GetID());
				int minBuildSkillRequired = baseBuildingInstance.Blueprint.MinBuildSkillRequired;
				HumanoidInstance selectedWorker = GetSelectedWorker();
				if (selectedWorker != null && selectedWorker.Skills.GetSkill(SkillType.Construction).Level < minBuildSkillRequired)
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("construction_skill_level_low");
					base.IsEnabled = false;
				}
				else if (!baseBuildingInstance.IsBlueprintOnClearNode())
				{
					base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("build_sight_must_be_clear");
					string localizedBlockerPile = baseBuildingInstance.GetLocalizedBlockerPile();
					if (!string.IsNullOrEmpty(localizedBlockerPile))
					{
						base.Tooltip = base.Tooltip + " (" + localizedBlockerPile + ")";
					}
					base.IsEnabled = false;
				}
				else
				{
					EnableIfWorkerIsSelected();
					DisableIfUnreachableFromSelectedWorker(baseBuildingInstance);
					DisableIfReserved();
				}
			}
		}

		public override bool Setup(AdditionalMenuFloatingElement overlayElement, AdditionalMenuItemData data)
		{
			if (!(base.Owner.GetAsTarget() is BaseBuildingInstance { ConstructionPhase: ConstructionPhase.Foundation }))
			{
				return false;
			}
			return base.Setup(overlayElement, data);
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker?.GetGoapAgent() != null && !selectedWorker.HasFainted && !selectedWorker.HasDisposed && base.Owner.GetAsTarget() is BaseBuildingInstance baseBuildingInstance && (!MonoSingleton<ReservationManager>.Instance.IsReserved(baseBuildingInstance) || MonoSingleton<ReservationManager>.Instance.IsReservedBy(baseBuildingInstance, selectedWorker)))
			{
				ForceGoal("ConstructBuildingGoal", baseBuildingInstance);
			}
		}
	}
}
