using System.Collections.Generic;
using NSMedieval.Manager;

namespace NSMedieval.CommanderAI.BehaviourTreeTasks
{
	public abstract class MultiUnitActionBase : UnitsBTActionBaseThread
	{
		private HashSet<CommanderAIUnit> inProgressUnits;

		private HashSet<CommanderAIUnit> tempUnitsToEnd;

		private bool startCycleHappened;

		protected abstract bool TryUnitStart(CommanderAIUnit unit);

		protected abstract void OnUnitTick(CommanderAIUnit unit);

		protected abstract void OnUnitEnd(CommanderAIUnit unit);

		protected void EndUnitAction(CommanderAIUnit unit)
		{
			if (inProgressUnits.Contains(unit))
			{
				tempUnitsToEnd.Add(unit);
			}
		}

		protected override void OnStart()
		{
			if (inProgressUnits == null)
			{
				inProgressUnits = new HashSet<CommanderAIUnit>();
			}
			inProgressUnits.Clear();
			if (tempUnitsToEnd == null)
			{
				tempUnitsToEnd = new HashSet<CommanderAIUnit>();
			}
			tempUnitsToEnd.Clear();
			startCycleHappened = false;
			base.OnStart();
		}

		protected override void OnTick()
		{
			if (base.IsThreadJobRunning)
			{
				return;
			}
			if (!startCycleHappened)
			{
				startCycleHappened = true;
				foreach (CommanderAIUnit unit in base.Units)
				{
					if (!CombatUtils.IsNullOrDisposed(unit.Humanoid) && !inProgressUnits.Contains(unit) && TryUnitStart(unit))
					{
						inProgressUnits.Add(unit);
					}
				}
			}
			foreach (CommanderAIUnit inProgressUnit in inProgressUnits)
			{
				OnUnitTick(inProgressUnit);
			}
			foreach (CommanderAIUnit item in tempUnitsToEnd)
			{
				inProgressUnits.Remove(item);
				OnUnitEnd(item);
			}
			tempUnitsToEnd.Clear();
			if (inProgressUnits.Count == 0)
			{
				EndAction();
			}
		}

		protected override void OnStop()
		{
			inProgressUnits.Clear();
			tempUnitsToEnd.Clear();
		}
	}
}
