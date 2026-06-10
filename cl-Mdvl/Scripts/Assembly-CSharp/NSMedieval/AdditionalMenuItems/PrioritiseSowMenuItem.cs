using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Manager;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;

namespace NSMedieval.AdditionalMenuItems
{
	public class PrioritiseSowMenuItem : AdditionalMenuPrioritiseItem
	{
		public PrioritiseSowMenuItem(IAdditionalMenuOwner owner)
			: base(owner, JobType.PlantCropfields)
		{
			if (!(base.Owner.GetAsTarget() is CropfieldInstance cropfieldInstance))
			{
				base.IsEnabled = false;
				return;
			}
			base.Text = MonoSingleton<LocalizationController>.Instance.GetText("prioritise_gardening");
			if ((GetSelectedWorker()?.Skills.GetSkill(SkillType.Botanical))?.Level < cropfieldInstance.CultivablePlant.MinBotanicalSkill)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("needed_skills") + ": " + AdditionalMenuItemUtil.GenerateSkillInfo("Botanical".ToLower(), cropfieldInstance.CultivablePlant.MinBotanicalSkill);
				base.IsEnabled = false;
				return;
			}
			if (CropsManager.UseSeeds && MonoSingleton<ResourcePileTracker>.Instance.GetCount(cropfieldInstance.Blueprint.SeedBlueprint).AllowedCount <= 0)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("cropfield_error_no_seeds");
				base.IsEnabled = false;
				return;
			}
			int dayOfYear = GlobalSaveController.CurrentVillageData.DateAndTime.DayOfYear;
			if (dayOfYear < cropfieldInstance.MinSowDate - 1 || dayOfYear > cropfieldInstance.MaxSowDate - 1)
			{
				base.Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("cropfield_error_sowing_period");
				base.IsEnabled = false;
			}
			else if (!cropfieldInstance.HasFreeSpace() || cropfieldInstance.IsOnFire)
			{
				base.IsEnabled = false;
			}
		}

		protected override void OnClickCallback()
		{
			base.OnClickCallback();
			if (base.Owner.GetAsTarget() is CropfieldInstance { HasDisposed: false } cropfieldInstance)
			{
				ForceGoal("PlantCropsGoal", cropfieldInstance);
			}
		}
	}
}
