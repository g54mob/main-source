using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS
{
	public class FilthObserver : MonoBehaviour
	{
		[SerializeField]
		private Agent _agent;

		[SerializeField]
		private RoomObject _roomObject;

		private void Awake()
		{
			if (!_agent)
			{
				_agent = GetComponent<Agent>();
			}
			if (!_roomObject)
			{
				_roomObject = GetComponent<RoomObject>();
			}
		}

		private void OnDisable()
		{
			if ((bool)_roomObject)
			{
				_roomObject.CurrentRoomChanged -= OnCurrentRoomChanged;
			}
			FilthManager.RoomFilthChanged -= OnRoomFilthChanged;
		}

		private void OnEnable()
		{
			if ((bool)_agent && (bool)_roomObject)
			{
				_roomObject.CurrentRoomChanged += OnCurrentRoomChanged;
				FilthManager.RoomFilthChanged += OnRoomFilthChanged;
			}
		}

		private void Update()
		{
			if ((bool)_roomObject)
			{
				_roomObject.TryFindCurrentRoom();
			}
		}

		private void OnCurrentRoomChanged()
		{
			UpdateStatistic(CTSSingleton<FilthManager>.Instance.GetRoomFilth(_roomObject.CurrentRoom));
		}

		private void OnRoomFilthChanged(RoomBuilding room, int filth)
		{
			if ((bool)_agent && (bool)_roomObject && !(room != _roomObject.CurrentRoom))
			{
				UpdateStatistic(filth);
			}
		}

		private void UpdateStatistic(int filth)
		{
			NumericStatistic numericStatistic = _agent.Statistics.GetNumericStatistic(EAgentStatistics.Environment);
			_agent.Statistics.SetStatisticValue(EAgentStatistics.Environment, numericStatistic.Max - (float)filth);
		}
	}
}
