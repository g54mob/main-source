using System.Collections.Generic;
using NSEipix;
using NSMedieval.StatsSystem;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval/Pick Unit")]
	[Description("Picks unit with best mining skill in given group")]
	public class PickBestMinerUnitBTAction : UnitsBTActionBase
	{
		public BBParameter<List<CommanderAIUnit>> saveAs;

		public BBParameter<MapNode> prevNode;

		protected override string info => $"{saveAs} = Best unit to mine.";

		protected override void OnStart()
		{
			if (base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
				return;
			}
			CommanderAIUnit commanderAIUnit = base.Units.MaxItem((CommanderAIUnit unit) => unit.Humanoid.Skills.GetSkill(SkillType.Mining).Level, null, (CommanderAIUnit unit) => unit.Humanoid.Skills.GetSkill(SkillType.Mining) != null && !unit.Humanoid.HasDiedOrFainted && PathfinderUtil.IsPathPossible(unit.Humanoid, prevNode.value));
			if (commanderAIUnit == null)
			{
				EndAction(success: false);
				return;
			}
			saveAs.SetValue(new List<CommanderAIUnit> { commanderAIUnit });
			EndAction();
		}
	}
}
