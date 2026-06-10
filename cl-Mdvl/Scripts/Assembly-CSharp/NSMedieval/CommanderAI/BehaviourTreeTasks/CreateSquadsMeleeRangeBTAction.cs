using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Utils.Pool.Janitors;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Create sub-groups of melee and ranged units")]
	public class CreateSquadsMeleeRangeBTAction : UnitsBTActionBase
	{
		public BBParameter<List<CommanderAIUnit>> meleeSquad;

		public BBParameter<List<CommanderAIUnit>> rangedSquad;

		protected override string info => "Group units into squads";

		protected override void OnStart()
		{
			BBParameter<List<CommanderAIUnit>> bBParameter = meleeSquad;
			if (bBParameter.value == null)
			{
				List<CommanderAIUnit> list = (bBParameter.value = new List<CommanderAIUnit>());
			}
			bBParameter = rangedSquad;
			if (bBParameter.value == null)
			{
				List<CommanderAIUnit> list = (bBParameter.value = new List<CommanderAIUnit>());
			}
			if (base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
				return;
			}
			if (base.UnitCount > 1 && meleeSquad.value.Count == 0)
			{
				RebalanceSquads();
			}
			if (meleeSquad.value.Count > 0 && (meleeSquad.value.AnyNonAlloc((CommanderAIUnit unit) => unit.Humanoid.HasDisposed || unit.Humanoid.HasDiedOrFainted) || rangedSquad.value.AnyNonAlloc((CommanderAIUnit unit) => unit.Humanoid.HasDisposed || unit.Humanoid.HasDiedOrFainted)))
			{
				RebalanceSquads();
			}
			EndAction();
		}

		private void RebalanceSquads()
		{
			Log.Debug("Rebalancing squads", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\CreateSquadsMeleeRangeBTAction.cs");
			meleeSquad.value.Clear();
			rangedSquad.value.Clear();
			using PooledList<CommanderAIUnit> pooledList = base.Units.WherePooled((CommanderAIUnit unit) => !CombatUtils.IsNullOrDisposed(unit.Humanoid));
			while (pooledList.Count > 0)
			{
				CommanderAIUnit commanderAIUnit = pooledList.PopFront();
				if (commanderAIUnit.Humanoid.EnemyBehaviour.NpcBlueprint.Type == NPCType.Archer)
				{
					rangedSquad.value.Add(commanderAIUnit);
				}
				else
				{
					meleeSquad.value.Add(commanderAIUnit);
				}
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(35, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\CreateSquadsMeleeRangeBTAction.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Rebalanced squads (melee ");
				messageBuilder.AppendFormatted(meleeSquad.value.Count);
				messageBuilder.AppendLiteral(", ranged ");
				messageBuilder.AppendFormatted(rangedSquad.value.Count);
				messageBuilder.AppendLiteral(")");
			}
			Log.Debug(messageBuilder);
		}
	}
}
