using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Manager;
using NSMedieval.StatsSystem;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Village.Map.Pathfinding.SiegeTraversalProvider;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Pick Unit")]
	[Description("Picks unit with best construction skill in given group")]
	public class PickBestBuilderUnitBTAction : UnitsBTActionBase
	{
		public BBParameter<List<CommanderAIUnit>> saveAs;

		public BBParameter<BaseBuildingInstance> buildingToBuild;

		protected override string info => $"{saveAs} = Best unit to build.";

		protected override void OnStart()
		{
			if (base.Units == null || base.UnitCount == 0 || buildingToBuild?.value == null || buildingToBuild.value.HasDisposed)
			{
				EndAction(success: false);
				return;
			}
			if (buildingToBuild.value.ConstructionPhase == ConstructionPhase.Finished)
			{
				Log.Info($"Building {buildingToBuild} is already finished", SiegeTraversalProvider.LogPath);
				buildingToBuild.value = null;
				EndAction(success: false);
				return;
			}
			CommanderAIUnit commanderAIUnit = base.Units.MaxItem((CommanderAIUnit unit) => unit.Humanoid.Skills.GetSkill(SkillType.Construction).Level, null, (CommanderAIUnit unit) => !CombatUtils.IsNullOrDisposed(unit.Humanoid) && unit.Humanoid.Skills.GetSkill(SkillType.Construction) != null && !unit.Humanoid.HasDiedOrFainted && PathfinderUtil.IsPathPossible(unit.Humanoid, buildingToBuild.value));
			if (commanderAIUnit == null)
			{
				Log.Info($"No suitable builder found for {buildingToBuild}", SiegeTraversalProvider.LogPath);
				buildingToBuild.value = null;
				EndAction(success: false);
			}
			else
			{
				saveAs.SetValue(new List<CommanderAIUnit> { commanderAIUnit });
				EndAction();
			}
		}
	}
}
