using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public class ElevatorLine : ILockable
	{
		private static readonly Resource<BarVisualObject> ElevatorPfb = new Resource<BarVisualObject>("Prefabs/Pfb_Elevator");

		[SerializeField]
		private float _oneFloorDuration = 3f;

		private BarVisualObject _elevatorObject;

		private ObjectToggler _elevatorDoorsToggler;

		private SortedList<int, ElevatorPortal> _portals;

		private Coroutine _moveRoutine;

		private readonly SortedDictionary<int, List<AgentActionElevator>> _descendingTargets = new SortedDictionary<int, List<AgentActionElevator>>();

		private readonly SortedDictionary<int, List<AgentActionElevator>> _ascendingTargets = new SortedDictionary<int, List<AgentActionElevator>>();

		private readonly List<AgentActionElevator> _allTargets = new List<AgentActionElevator>();

		private readonly Dictionary<AgentActionElevator, int> _currentOccupants = new Dictionary<AgentActionElevator, int>();

		private int _firstTargetFloor;

		[field: SerializeField]
		public int StartFloor { get; private set; }

		[field: SerializeField]
		public ElevatorPortal[] Portals { get; private set; }

		public bool Debug { get; set; }

		public ElevatorPortal CurrentPortal
		{
			get
			{
				if (!_portals.TryGetValue(CurrentFloor, out var value))
				{
					return null;
				}
				return value;
			}
		}

		public int CurrentFloor { get; private set; }

		public int Direction { get; private set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public void Awake()
		{
			_portals = new SortedList<int, ElevatorPortal>();
			ElevatorPortal[] portals = Portals;
			foreach (ElevatorPortal elevatorPortal in portals)
			{
				_portals.TryAdd(elevatorPortal.Floor, elevatorPortal);
				elevatorPortal.Line = this;
			}
			IList<ElevatorPortal> values = _portals.Values;
			values[0].UpperFloor = values[1];
			for (int j = 1; j < values.Count - 1; j++)
			{
				values[j].LowerFloor = values[j - 1];
				values[j].UpperFloor = values[j + 1];
			}
			values[values.Count - 1].LowerFloor = values[values.Count - 2];
			CurrentFloor = _portals[StartFloor].Floor;
			_elevatorObject = UnityEngine.Object.Instantiate((BarVisualObject)ElevatorPfb);
			_elevatorObject.transform.SetPositionAndRotation(_portals[StartFloor].transform);
			_elevatorDoorsToggler = _elevatorObject.GetComponent<ObjectToggler>();
		}

		internal void AddRequest(int targetFloor, int currentFloor, AgentActionElevator requester)
		{
			if (_allTargets.Contains(requester))
			{
				return;
			}
			if (targetFloor < currentFloor)
			{
				if (!_descendingTargets.ContainsKey(currentFloor))
				{
					_descendingTargets.Add(currentFloor, new List<AgentActionElevator>());
				}
				_descendingTargets[currentFloor].Add(requester);
				_allTargets.Add(requester);
			}
			else
			{
				if (!_ascendingTargets.ContainsKey(currentFloor))
				{
					_ascendingTargets.Add(currentFloor, new List<AgentActionElevator>());
				}
				_ascendingTargets[currentFloor].Add(requester);
				_allTargets.Add(requester);
			}
			StartRoutine(targetFloor, currentFloor);
		}

		private void StartRoutine(int targetFloor, int currentFloor)
		{
			if (_moveRoutine == null)
			{
				Direction = Math.Sign(targetFloor - currentFloor);
				_firstTargetFloor = currentFloor;
				_moveRoutine = StaticCoroutines.StartStaticCoroutine(ElevatorLoop());
			}
		}

		private IEnumerator ElevatorLoop()
		{
			int currentFloor = CurrentFloor;
			if (_firstTargetFloor != currentFloor)
			{
				if (CurrentPortal.IsOpen)
				{
					yield return CurrentPortal.SetClosed();
					_elevatorDoorsToggler.SetActive(value: true);
				}
				float duration = (float)Math.Abs(_firstTargetFloor - currentFloor) * _oneFloorDuration;
				yield return MoveTo(_firstTargetFloor, duration);
			}
			do
			{
				if (!CurrentPortal.IsOpen)
				{
					_elevatorDoorsToggler.SetActive(value: false);
					yield return CurrentPortal.SetOpen();
				}
				if (Direction > 0)
				{
					if (_ascendingTargets.ContainsKey(CurrentFloor))
					{
						yield return LetRequestersEnter(_ascendingTargets[CurrentFloor]);
					}
				}
				else if (_descendingTargets.ContainsKey(CurrentFloor))
				{
					yield return LetRequestersEnter(_descendingTargets[CurrentFloor]);
				}
				while (ObjectLock.IsLocked())
				{
					yield return null;
				}
				if (_ascendingTargets.Count <= 0 && _descendingTargets.Count <= 0)
				{
					_moveRoutine = null;
					CurrentPortal.Close();
					yield break;
				}
				yield return CurrentPortal.SetClosed();
				_elevatorDoorsToggler.SetActive(value: true);
				if (!GetNextTargetFloor(out var outTargetFloor))
				{
					yield break;
				}
				yield return MoveTo(outTargetFloor, (float)Math.Abs(outTargetFloor - CurrentFloor) * _oneFloorDuration);
				_elevatorDoorsToggler.SetActive(value: false);
				yield return CurrentPortal.SetOpen();
				yield return LetRequestersExit();
				CalculateNextDirection();
			}
			while (_descendingTargets.Count > 0 || _ascendingTargets.Count > 0);
			_moveRoutine = null;
			yield return CurrentPortal.SetClosed();
			IEnumerator LetRequestersEnter(List<AgentActionElevator> requests)
			{
				while (requests.Count > 0)
				{
					AgentActionElevator agentActionElevator = requests[0];
					if (agentActionElevator.Stopped)
					{
						requests.Remove(agentActionElevator);
						_allTargets.Remove(agentActionElevator);
					}
					else if (!agentActionElevator.ReadyToEnter)
					{
						yield return null;
					}
					else
					{
						requests.Remove(agentActionElevator);
						_allTargets.Remove(agentActionElevator);
						agentActionElevator.CanEnterElevator = true;
						if (requests.Count <= 0)
						{
							yield return new WaitForSeconds(2f);
						}
						else
						{
							yield return new WaitForSeconds(1f);
						}
					}
				}
			}
			IEnumerator LetRequestersExit()
			{
				List<AgentActionElevator> agentsToClear = new List<AgentActionElevator>();
				Dictionary<AgentActionElevator, int> dictionary = new Dictionary<AgentActionElevator, int>(_currentOccupants);
				foreach (KeyValuePair<AgentActionElevator, int> item in dictionary)
				{
					if (item.Value == CurrentFloor)
					{
						item.Key.CanExitElevator = true;
						agentsToClear.Add(item.Key);
						yield return new WaitForSeconds(1f);
					}
				}
				foreach (AgentActionElevator item2 in agentsToClear)
				{
					ClearRequest(item2);
				}
			}
		}

		private bool GetNextTargetFloor(out int outTargetFloor)
		{
			int num = CurrentFloor;
			if (Direction > 0)
			{
				foreach (KeyValuePair<int, List<AgentActionElevator>> ascendingTarget in _ascendingTargets)
				{
					if (ascendingTarget.Key > CurrentFloor)
					{
						num = ascendingTarget.Key;
						break;
					}
				}
				foreach (KeyValuePair<AgentActionElevator, int> currentOccupant in _currentOccupants)
				{
					if (currentOccupant.Value > CurrentFloor)
					{
						if (num == CurrentFloor)
						{
							num = currentOccupant.Value;
						}
						else if (currentOccupant.Value < num)
						{
							num = currentOccupant.Value;
						}
					}
				}
			}
			else
			{
				foreach (KeyValuePair<int, List<AgentActionElevator>> item in new Dictionary<int, List<AgentActionElevator>>(_descendingTargets.Reverse()))
				{
					if (item.Key < CurrentFloor)
					{
						num = item.Key;
						break;
					}
				}
				foreach (KeyValuePair<AgentActionElevator, int> currentOccupant2 in _currentOccupants)
				{
					if (currentOccupant2.Value < CurrentFloor)
					{
						if (num == CurrentFloor)
						{
							num = currentOccupant2.Value;
						}
						else if (currentOccupant2.Value > num)
						{
							num = currentOccupant2.Value;
						}
					}
				}
			}
			outTargetFloor = num;
			if (num == CurrentFloor)
			{
				_moveRoutine = null;
				StartRoutine(_allTargets[0].TargetFloor, _allTargets[0].StartFloor);
				return false;
			}
			return true;
		}

		private void CalculateNextDirection()
		{
			if (Direction > 0)
			{
				if (_ascendingTargets.Count <= 0)
				{
					Direction = -1;
				}
			}
			else if (_descendingTargets.Count <= 0)
			{
				Direction = 1;
			}
		}

		private IEnumerator MoveTo(int targetFloor, float duration)
		{
			_elevatorObject.transform.DOMove(_portals[targetFloor].transform.position, duration);
			yield return new WaitForSeconds(duration * 0.35f);
			CurrentFloor = targetFloor;
			yield return new WaitForSeconds(duration * 0.65f);
			_elevatorObject.transform.position = _portals[CurrentFloor].transform.position;
		}

		internal void AddOccupant(AgentActionElevator occupant, int targetFloor)
		{
			if (!_currentOccupants.ContainsKey(occupant))
			{
				_currentOccupants.Add(occupant, targetFloor);
			}
		}

		internal void ClearRequest(AgentActionElevator request)
		{
			if (_ascendingTargets.ContainsKey(request.StartFloor))
			{
				_ascendingTargets[request.StartFloor].Remove(request);
				if (_ascendingTargets[request.StartFloor].Count <= 0)
				{
					_ascendingTargets.Remove(request.StartFloor);
				}
			}
			if (_descendingTargets.ContainsKey(request.StartFloor))
			{
				_descendingTargets[request.StartFloor].Remove(request);
				if (_descendingTargets[request.StartFloor].Count <= 0)
				{
					_descendingTargets.Remove(request.StartFloor);
				}
			}
			if (_currentOccupants.ContainsKey(request))
			{
				_currentOccupants.Remove(request);
			}
			_allTargets.Remove(request);
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
