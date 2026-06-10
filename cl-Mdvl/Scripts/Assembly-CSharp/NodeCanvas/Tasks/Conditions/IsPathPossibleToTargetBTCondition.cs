using System.Linq;
using NSEipix.Repository;
using NSMedieval.CommanderAI;
using NSMedieval.Goap;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Village.Map.Pathfinding;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Going Medieval")]
	[Description("Returns true if we have a direct path to the given target")]
	public class IsPathPossibleToTargetBTCondition : ConditionTask<CommanderAgentProxy>
	{
		public BBParameter<IDamageTakingAgent> target;

		public bool IgnoreWorkerTag;

		private static WalkableModel walkableModelNoDoors;

		protected override string info => $"direct path exists to -> {target}";

		[RuntimeInitializeOnLoadMethod]
		public static void OnDomainReload()
		{
			walkableModelNoDoors = null;
		}

		protected override bool OnCheck()
		{
			if (target?.value == null || target.value.HasDisposed)
			{
				return false;
			}
			CommanderAIUnit commanderAIUnit = base.agent.Units.First();
			if (IgnoreWorkerTag)
			{
				if ((object)walkableModelNoDoors == null)
				{
					walkableModelNoDoors = Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentUnwalkableDoors();
				}
				return PathfinderUtil.IsPathPossible(commanderAIUnit.Humanoid, target.value, walkableModelNoDoors);
			}
			return PathfinderUtil.IsPathPossible(commanderAIUnit.Humanoid, target.value);
		}
	}
}
