using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class StatesLayoutContainer : MonoBehaviour
	{
		[SerializeField]
		private GameObject _layoutPrefab;

		[SerializeField]
		private StatBar[] _stateslist;

		[SerializeField]
		private int _statCountPerLaout = 2;

		private List<Transform> _layouts = new List<Transform>();

		private Agent _agent;

		private void Start()
		{
		}

		private void Clear()
		{
			for (int i = 0; i < _stateslist.Length; i++)
			{
				_stateslist[i].gameObject.SetActive(value: false);
			}
		}

		public void ShowStats(AgentPanelGroup.showMode showMode)
		{
			if (showMode == AgentPanelGroup.showMode.Hire)
			{
				return;
			}
			for (int i = 0; i < _stateslist.Length; i++)
			{
				if (_stateslist[i].Key == "Satisfaction" && _agent is Worker)
				{
					AddStatsToLayout(_stateslist[i]);
				}
				else if (_stateslist[i].Key == "Thirsty" && _agent is Worker)
				{
					AddStatsToLayout(_stateslist[i]);
				}
				else if (_stateslist[i].Key == "Fun" && _agent is Customer)
				{
					AddStatsToLayout(_stateslist[i]);
				}
				else if (_stateslist[i].Key == "Social" && _agent is Customer)
				{
					AddStatsToLayout(_stateslist[i]);
				}
			}
		}

		private void AddStatsToLayout(StatBar bar)
		{
			for (int i = 0; i < _layouts.Count; i++)
			{
				if (_layouts[i].transform.childCount < 2)
				{
					bar.transform.SetParent(_layouts[i].transform);
					bar.gameObject.SetActive(value: true);
					break;
				}
			}
		}

		public void SetAgentInfo(Agent p_agent, AgentPanelGroup.showMode showMode)
		{
			OnAgentChanging();
			_agent = p_agent;
			Clear();
			ShowStats(showMode);
		}

		private void OnAgentChanging()
		{
			if (!(_agent == null))
			{
				_agent.Health.HealthpointsChanged -= OnHealthpointsChanged;
			}
		}

		private void OnHealthpointsChanged(int p_point)
		{
		}
	}
}
