using System;
using CTS.Core;

namespace CTS.BBT.AI
{
	public class ActionHubLoadMachine : AgentHubAction
	{
		private readonly MachineBase _machine;

		private readonly WorkerActionUnloadMachine _unloadCageAction;

		private readonly WorkerActionLoadMachine _loadMachine;

		public ActionHubLoadMachine(MachineBase machine)
		{
			_machine = machine;
			_loadMachine = new WorkerActionLoadMachine(_machine, null);
			AddScoredAction(_loadMachine, LoadMachine);
			_unloadCageAction = new WorkerActionUnloadMachine(null, shouldVictimBeControlled: true);
			AddScoredAction(_unloadCageAction, CalculateUnloadCage);
		}

		protected override void PreCheck(Agent agent)
		{
			base.PreCheck(agent);
			if (agent is Worker worker)
			{
				_loadMachine.Victim = worker.ControlledHuman;
			}
		}

		protected override bool CanAnyActionBePerformed(Agent agent)
		{
			if (!_machine.Furniture.Controller.IsPlaced)
			{
				return false;
			}
			return base.CanAnyActionBePerformed(agent);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			return _machine.HasAVictim;
		}

		private bool CanCageBeUsed(Cell cell, Worker worker)
		{
			if (!worker.RoomAssignations.CanUseRoom(cell.Furniture.RoomObject.CurrentRoom))
			{
				return false;
			}
			if (cell.HasAVictim && cell.Victim.IsAlive)
			{
				return ((Customer)cell.Victim).BloodQuality >= _machine.MachineBloodQuality.CurrentBloodQuality;
			}
			return false;
		}

		private int CalculateUnloadCage(Agent agent)
		{
			if (!(agent is Worker worker))
			{
				return -1;
			}
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(worker.RoomObject, out Cell outFurniture, out float _, (Func<Cell, Worker, bool>)CanCageBeUsed, worker))
			{
				_unloadCageAction.SetMachine(outFurniture);
				return 100;
			}
			return -1;
		}

		private int LoadMachine(Agent agent)
		{
			if (!(agent is Worker worker))
			{
				return -1;
			}
			if ((bool)worker.ControlledHuman)
			{
				return 900;
			}
			return -1;
		}
	}
}
