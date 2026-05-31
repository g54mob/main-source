using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS
{
	public class UIAgentInfos : UICanvasGroup, ILockable
	{
		private static readonly Resource<UINeedBar> NeedBarPrefab = new Resource<UINeedBar>("UI/NeedBar");

		private Agent _currentAgent;

		private readonly List<UINeedBar> _uiObjects = new List<UINeedBar>();

		private readonly List<UINeedBar> _uiObjectsPool = new List<UINeedBar>();

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		protected override void Awake()
		{
			base.Awake();
			WorldSelector.RegisterToSelection<Agent>(OnAgentSelectionChanged);
		}

		private void OnDestroy()
		{
			WorldSelector.UnregisterToSelection<Agent>(OnAgentSelectionChanged);
		}

		private void OnAgentSelectionChanged(Agent agent, bool selected)
		{
			if (selected)
			{
				OnAgentSelected(agent);
			}
			else
			{
				OnAgentDeselected();
			}
		}

		private void OnAgentSelected(Agent agent)
		{
			if (!(_currentAgent == agent))
			{
				_currentAgent = agent;
				UpdateAgent();
				if (!ObjectLock.IsLocked())
				{
					SetActive(p_state: true);
				}
			}
		}

		private void OnAgentDeselected()
		{
			if ((bool)_currentAgent)
			{
				_currentAgent = null;
			}
			foreach (UINeedBar uiObject in _uiObjects)
			{
				uiObject.gameObject.SetActive(value: false);
				_uiObjectsPool.Add(uiObject);
				_uiObjects.Remove(uiObject);
			}
			SetActive(p_state: false);
		}

		private void UpdateAgent()
		{
			foreach (UINeedBar uiObject in _uiObjects)
			{
				uiObject.gameObject.SetActive(value: false);
			}
			foreach (KeyValuePair<EAgentStatistics, NumericStatistic> getAllStatistic in _currentAgent.Statistics.GetAllStatistics)
			{
				if (getAllStatistic.Value.PublicValue)
				{
					UINeedBar uINeedBar;
					if (_uiObjectsPool.Count == 0)
					{
						uINeedBar = UnityEngine.Object.Instantiate((UINeedBar)NeedBarPrefab, base.transform);
					}
					else
					{
						uINeedBar = _uiObjectsPool[0];
						_uiObjectsPool.Remove(uINeedBar);
					}
					_uiObjects.Add(uINeedBar);
					uINeedBar.SetText(getAllStatistic.Key.ToString());
					uINeedBar.AssignStatistic(getAllStatistic.Value);
					uINeedBar.gameObject.SetActive(value: true);
				}
			}
		}

		void ILockable.OnLocked()
		{
			SetActive(p_state: false);
		}

		void ILockable.OnUnlocked()
		{
			if ((bool)_currentAgent)
			{
				SetActive(p_state: true);
			}
		}

		public void Clear()
		{
			OnAgentDeselected();
		}
	}
}
