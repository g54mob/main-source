using System;
using System.Collections.Generic;

namespace CTS.BBT.AI
{
	public class ActionHubCaptureHuman : AgentHubAction
	{
		private readonly Cell _cell;

		private WorkerActionLoadMachine _actionLoadMachine;

		private WorkerActionHypnotize _actionHypnotize;

		private Customer _foundHuman;

		private List<Customer> _customers = new List<Customer>();

		private static readonly Func<Customer, int, Worker, bool> CustomerIsValidForCageWithAssignation = (Customer customer, int cellQuality, Worker worker) => (worker.AssignationBypassPowers || customer.IsInWorkerAssignation(worker)) && CustomerIsValidForCage(customer, cellQuality);

		private static readonly Func<Customer, int, bool> CustomerIsValidForCage = delegate(Customer customer, int cellQuality)
		{
			if (!customer.Health.IsAlive)
			{
				return false;
			}
			if (customer.BloodQuality < cellQuality)
			{
				return false;
			}
			return !customer.Tags.HasTag(EAgentTag.WentInMachine);
		};

		public bool UseAssignation { get; set; }

		public ActionHubCaptureHuman(Cell cell)
		{
			_cell = cell;
			_actionLoadMachine = new WorkerActionLoadMachine(_cell, null);
			AddScoredAction(_actionLoadMachine, LoadHumanScore);
			_actionHypnotize = new WorkerActionHypnotize(null);
			AddScoredAction(_actionHypnotize, HypnotizeHumanScore);
		}

		protected override void PreCheck(Agent agent)
		{
			base.PreCheck(agent);
			if (agent is Worker worker)
			{
				_actionLoadMachine.Victim = worker.ControlledHuman;
				if (UseAssignation)
				{
					_foundHuman = CustomerManager.GetRandomAvailableHuman(CustomerIsValidForCageWithAssignation, _cell.MachineBloodQuality.CurrentBloodQuality, worker);
				}
				else
				{
					_foundHuman = CustomerManager.GetRandomAvailableHuman(CustomerIsValidForCage, _cell.MachineBloodQuality.CurrentBloodQuality);
				}
				_actionHypnotize.Human = _foundHuman;
			}
		}

		protected override bool CanAnyActionBePerformed(Agent agent)
		{
			if (!_cell.Furniture.Controller.IsPlaced)
			{
				return false;
			}
			if (!base.IsPlaying && (_cell.HasAVictim || _cell.IsReserved))
			{
				return false;
			}
			if (!(agent is Worker worker))
			{
				return false;
			}
			if (worker.ObjectHolding.IsCurrentlyHolding)
			{
				if (!worker.ControlledHuman)
				{
					return false;
				}
			}
			else if (!worker.ControlledHuman && !worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Hypnosis))
			{
				return false;
			}
			return base.CanAnyActionBePerformed(agent);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			return _cell.HasAVictim;
		}

		private int HypnotizeHumanScore(Agent agentRef)
		{
			if (!(agentRef is Worker worker))
			{
				return -1;
			}
			if ((bool)worker.ControlledHuman)
			{
				return -1;
			}
			if (!worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Hypnosis))
			{
				return -1;
			}
			if (!_actionHypnotize.Human)
			{
				return -1;
			}
			return 100;
		}

		private int LoadHumanScore(Agent agentRef)
		{
			if (!(agentRef is Worker worker))
			{
				return -1;
			}
			if (!worker.ControlledHuman)
			{
				return -1;
			}
			if (!CustomerIsValidForCage(worker.ControlledHuman, _cell.MachineBloodQuality.CurrentBloodQuality))
			{
				return -1;
			}
			_cell.IsReserved = true;
			return 150;
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			if (_cell.IsReserved)
			{
				_cell.IsReserved = false;
			}
		}
	}
}
