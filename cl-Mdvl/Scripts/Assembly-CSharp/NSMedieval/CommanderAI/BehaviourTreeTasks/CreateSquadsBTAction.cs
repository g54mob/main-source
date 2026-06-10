using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSMedieval.Manager;
using NSMedieval.Utils.Pool.Janitors;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	[Category("✫ Going Medieval")]
	[Description("Create sub-groups of the given unit group by purpose")]
	public class CreateSquadsBTAction : UnitsBTActionBase
	{
		public BBParameter<List<CommanderAIUnit>> artillerySquad;

		public BBParameter<List<CommanderAIUnit>> nonArtillerySquad;

		protected override string info => "Group units into squads";

		protected override void OnStart()
		{
			BBParameter<List<CommanderAIUnit>> bBParameter = artillerySquad;
			if (bBParameter.value == null)
			{
				List<CommanderAIUnit> list = (bBParameter.value = new List<CommanderAIUnit>());
			}
			bBParameter = nonArtillerySquad;
			if (bBParameter.value == null)
			{
				List<CommanderAIUnit> list = (bBParameter.value = new List<CommanderAIUnit>());
			}
			if (base.Units == null || base.UnitCount == 0)
			{
				EndAction(success: false);
				return;
			}
			if (artillerySquad.value.Count > 0 && !base.agent.HasArtilleryAmmo)
			{
				RebalanceSquads();
			}
			if (artillerySquad.value.Count == 0 && nonArtillerySquad.value.Count == 0)
			{
				RebalanceSquads();
			}
			if (base.UnitCount > 1 && artillerySquad.value.Count == 0 && base.agent.HasArtilleryAmmo)
			{
				RebalanceSquads();
			}
			if (artillerySquad.value.Count > 0 && (artillerySquad.value.AnyNonAlloc((CommanderAIUnit unit) => unit.Humanoid.HasDisposed || unit.Humanoid.HasDiedOrFainted) || nonArtillerySquad.value.AnyNonAlloc((CommanderAIUnit unit) => unit.Humanoid.HasDisposed || unit.Humanoid.HasDiedOrFainted)))
			{
				RebalanceSquads();
			}
			EndAction();
		}

		private void RebalanceSquads()
		{
			Log.Debug("Rebalancing squads", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\CreateSquadsBTAction.cs");
			artillerySquad.value.Clear();
			nonArtillerySquad.value.Clear();
			if (base.UnitCount == 1)
			{
				nonArtillerySquad.value.Add(base.FirstUnit);
				return;
			}
			using PooledList<CommanderAIUnit> pooledList = base.Units.WherePooled((CommanderAIUnit unit) => !CombatUtils.IsNullOrDisposed(unit.Humanoid));
			int num;
			if (!base.agent.HasArtilleryAmmo)
			{
				num = 0;
			}
			else
			{
				num = Math.Min(base.agent.TotalSiegeWeaponsCount, base.UnitCount / 2);
				pooledList.Sort((CommanderAIUnit unit1, CommanderAIUnit unit2) => unit1.Humanoid.ActiveBehaviour.NpcBlueprint.Price.CompareTo(unit2.Humanoid.ActiveBehaviour.NpcBlueprint.Price));
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				artillerySquad.value.Add(pooledList.PopFront());
			}
			while (pooledList.Count > 0)
			{
				nonArtillerySquad.value.Add(pooledList.PopFront());
			}
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(46, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\CreateSquadsBTAction.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Rebalanced squads (artillery ");
				messageBuilder.AppendFormatted(artillerySquad.value.Count);
				messageBuilder.AppendLiteral(", non-artillery ");
				messageBuilder.AppendFormatted(nonArtillerySquad.value.Count);
				messageBuilder.AppendLiteral(")");
			}
			Log.Debug(messageBuilder);
		}
	}
}
