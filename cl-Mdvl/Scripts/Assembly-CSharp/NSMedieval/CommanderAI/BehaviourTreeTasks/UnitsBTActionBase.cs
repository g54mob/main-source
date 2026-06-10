using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSMedieval.CombatAi;
using NSMedieval.Village.Map.Pathfinding;
using NodeCanvas.Framework;
using UnityEngine;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	public abstract class UnitsBTActionBase : CommanderAIBTActionBase
	{
		public BBParameter<ICollection<CommanderAIUnit>> sourceUnits;

		protected float currentTime;

		private float lastUpdatedUnitForPathfindingTime = float.MinValue;

		private CommanderAIUnit unitForPathfinding;

		protected new IEnumerable<CommanderAIUnit> Units
		{
			get
			{
				foreach (CommanderAIUnit item in sourceUnits.value)
				{
					if (!CombatAiUtils.IsAgentDefeated(item.Humanoid))
					{
						yield return item;
					}
				}
			}
		}

		protected int UnitCount
		{
			get
			{
				if (sourceUnits?.value == null)
				{
					return 0;
				}
				int num = 0;
				foreach (CommanderAIUnit item in sourceUnits.value)
				{
					if (!CombatAiUtils.IsAgentDefeated(item.Humanoid))
					{
						num++;
					}
				}
				return num;
			}
		}

		protected new CommanderAIUnit FirstUnit
		{
			get
			{
				foreach (CommanderAIUnit item in sourceUnits.value)
				{
					if (!CombatAiUtils.IsAgentDefeated(item.Humanoid))
					{
						return item;
					}
				}
				return null;
			}
		}

		protected CommanderAIUnit UnitForPathfinding
		{
			get
			{
				if (Units == null || UnitCount == 0)
				{
					return null;
				}
				if (UnitCount == 1)
				{
					return Units.First();
				}
				if (unitForPathfinding != null && !unitForPathfinding.Humanoid.HasDiedOrFainted && !unitForPathfinding.Humanoid.HasDisposed && currentTime - lastUpdatedUnitForPathfindingTime < 3f)
				{
					return unitForPathfinding;
				}
				lastUpdatedUnitForPathfindingTime = currentTime;
				float num = float.MaxValue;
				CommanderAIUnit commanderAIUnit = null;
				foreach (CommanderAIUnit unit in Units)
				{
					if (CombatAiUtils.IsAgentDefeated(unit.Humanoid))
					{
						continue;
					}
					float num2 = 0f;
					foreach (CommanderAIUnit unit2 in Units)
					{
						num2 += unit.Humanoid.GetPosition().DistanceSquared(unit2.Humanoid.GetPosition());
						if (!PathfinderUtil.IsPathPossible(unit.Humanoid, unit2.Humanoid))
						{
							num2 += 1000f;
						}
					}
					if (num2 < num)
					{
						num = num2;
						commanderAIUnit = unit;
					}
				}
				Log.Trace("Failed to find unit for pathfinding, all units are disposed", "C:\\GIT\\dev\\Assets\\Scripts\\CommanderAI\\BTActions\\UnitsBTActionBase.cs");
				unitForPathfinding = commanderAIUnit;
				return unitForPathfinding;
			}
		}

		protected override string info => $"{sourceUnits}";

		protected override void OnUpdate()
		{
			currentTime = Time.time;
			base.OnUpdate();
		}

		protected CommanderAIUnit GetClosestUnit(Vector3 position)
		{
			return Units.MinItem((CommanderAIUnit unit) => unit.Humanoid.GetPosition().DistanceSquared(in position));
		}
	}
}
