using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public class ActionHubGetFun : AgentHubAction
	{
		private StationNeedFill _nearestFunStation;

		private ITrapMachine _nearestTrapMachine;

		private Func<Agent, int> _stationNeedFillScore;

		private AgentActionUseStationNeedFill _useStationNeedFillAction;

		private float _stationFunDistance;

		private AgentActionUseMachine _useMachineAction;

		private float _trapDistance;

		private readonly float _completionRange;

		private static readonly StringKey _funActionKey = "NeedFillAction";

		private static readonly Func<ITrapMachine, Agent, bool> TrapIsValidMachine = (ITrapMachine trap, Agent agent) => trap is MachineBase { MachinePowerState: EMachinePowerState.On } && trap.RoomObject.CurrentRoom.NavArea.IsInMask(agent.Movement.AreaMask);

		public ActionHubGetFun(float completionRange)
		{
			_completionRange = completionRange;
			_stationNeedFillScore = CalculateScoreFunStation;
			_useMachineAction = new AgentActionUseMachine(null);
			AddScoredAction(_useMachineAction, CalculateScoreTrapMachine);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			if (!agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Fun, out var statisticValue))
			{
				return true;
			}
			return statisticValue >= _completionRange;
		}

		protected override void PreCheck(Agent agent)
		{
			base.PreCheck(agent);
			CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(agent.RoomObject, out _nearestFunStation, out _stationFunDistance, StationNeedFill.IsStatisticAndValidForAgent, agent, EAgentStatistics.Fun);
			RemoveAction(_useStationNeedFillAction);
			if ((bool)_nearestFunStation)
			{
				ActionData randomActionData = _nearestFunStation.GetRandomActionData(_funActionKey);
				if (randomActionData == null)
				{
					_useStationNeedFillAction = null;
				}
				else
				{
					_useStationNeedFillAction = randomActionData.InstantiateAction() as AgentActionUseStationNeedFill;
					if (_useStationNeedFillAction != null)
					{
						_useStationNeedFillAction.Station = _nearestFunStation;
						AddScoredAction(_useStationNeedFillAction, _stationNeedFillScore);
					}
				}
			}
			if (agent.IsHuman)
			{
				CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(agent.RoomObject, out _nearestTrapMachine, out _trapDistance, TrapIsValidMachine, agent);
			}
			else
			{
				_nearestTrapMachine = null;
			}
			_useMachineAction.SetMachine(_nearestTrapMachine as MachineBase);
		}

		private int CalculateScoreTrapMachine(Agent agent)
		{
			if ((object)_useMachineAction.Machine == null)
			{
				return -1;
			}
			if (!_useMachineAction.Machine.CanBeUsed(agent))
			{
				return -1;
			}
			if (agent is Customer { IsVampire: false } customer && CTSSingleton<LevelParameters>.Instance.Furnitures.DoesAnyExist(Cell.IsAvailableForTrap, customer))
			{
				return 100050;
			}
			return 100000 - (int)_trapDistance;
		}

		private int CalculateScoreFunStation(Agent agent)
		{
			if ((object)_nearestFunStation == null)
			{
				return -1;
			}
			if (!_nearestFunStation.CanBeUsed(agent))
			{
				return -1;
			}
			return 100000 - (int)_stationFunDistance;
		}
	}
}
