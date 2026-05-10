using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using JetBrains.Annotations;
using UnityEngine;

namespace CTS
{
	public class UI_WorkerMgr_Layouter : CTSBehaviour, IRepaint
	{
		private class PanelComparer : IComparer<UI_WorkerMgr_WorkerPanel>
		{
			private IComparer<Worker> _comparer;

			private readonly IComparer<Worker> _fallBackComparer;

			public PanelComparer(IComparer<Worker> fallBackComparer)
			{
				_fallBackComparer = fallBackComparer;
			}

			public void SetComparer(IComparer<Worker> worker)
			{
				_comparer = worker;
			}

			protected virtual int Compare(Worker x, Worker y)
			{
				return _comparer.Compare(x, y);
			}

			public int Compare(UI_WorkerMgr_WorkerPanel x, UI_WorkerMgr_WorkerPanel y)
			{
				int num = Compare(x.AssignedWorker, y.AssignedWorker);
				if (num == 0)
				{
					return _fallBackComparer.Compare(x.AssignedWorker, y.AssignedWorker);
				}
				return num;
			}
		}

		private class PanelInvertComparer : PanelComparer
		{
			public PanelInvertComparer(IComparer<Worker> fallBackComparer)
				: base(fallBackComparer)
			{
			}

			protected override int Compare(Worker x, Worker y)
			{
				return base.Compare(y, x);
			}
		}

		[SerializeField]
		[Inject(false)]
		private Transform _panelContainer;

		[SerializeField]
		private UI_WorkerMgr_WorkerPanel _panelPrefab;

		[SerializeField]
		private WorkerComparer _fallbackComparer;

		[SerializeField]
		private StringKey _startDisplayMode = "WorkerMgr_Info";

		private List<UI_WorkerMgr_WorkerPanel> _panels = new List<UI_WorkerMgr_WorkerPanel>();

		private Stack<UI_WorkerMgr_WorkerPanel> _panelPool = new Stack<UI_WorkerMgr_WorkerPanel>();

		private PanelComparer _panelSorter;

		private PanelInvertComparer _panelInvertSorter;

		private StringKey _currentDisplayMode;

		[CanBeNull]
		private Func<Worker, bool> _currentFilter;

		public ReadOnlyList<UI_WorkerMgr_WorkerPanel> Panels => _panels;

		public int ActivePanelCount => _panels.Count((UI_WorkerMgr_WorkerPanel panel) => panel.gameObject.activeSelf);

		public event Action WasRepaint;

		public event Action DisplayModeChanged;

		protected override void OnAwake()
		{
			base.OnAwake();
			IComparer<Worker> comparer = _fallbackComparer.GetComparer();
			_panelSorter = new PanelComparer(comparer);
			_panelInvertSorter = new PanelInvertComparer(comparer);
			Worker.WorkerSpawned += OnWorkerHired;
			Worker.Fired += OnWorkerFired;
			AgentIdentityPanel.OnWorkerNameChange += OnRenameWorker;
			Agent.AgentDespawned += OnAgentDespawned;
			SetDisplayCategory(_startDisplayMode);
			Repaint();
		}

		private void OnDestroy()
		{
			Worker.WorkerSpawned -= OnWorkerHired;
			Worker.Fired -= OnWorkerFired;
			Agent.AgentDespawned -= OnAgentDespawned;
			AgentIdentityPanel.OnWorkerNameChange -= OnRenameWorker;
		}

		public void SetDisplayCategory(ScriptableStringKey key)
		{
			SetDisplayCategory((StringKey)key);
		}

		public void SetDisplayCategory(StringKey key)
		{
			if (_currentDisplayMode == key)
			{
				return;
			}
			_currentDisplayMode = key;
			foreach (UI_WorkerMgr_WorkerPanel panel in _panels)
			{
				panel.SetDisplayMode(_currentDisplayMode);
			}
			this.DisplayModeChanged?.Invoke();
		}

		public void Reorder(IComparer<Worker> comparer, bool reverse)
		{
			if (reverse)
			{
				_panelInvertSorter.SetComparer(comparer);
				_panels.Sort(_panelInvertSorter);
			}
			else
			{
				_panelSorter.SetComparer(comparer);
				_panels.Sort(_panelSorter);
			}
			for (int num = _panels.Count - 1; num >= 0; num--)
			{
				_panels[num].transform.SetAsFirstSibling();
			}
		}

		public void DisableFiltering()
		{
			_currentFilter = null;
			foreach (UI_WorkerMgr_WorkerPanel panel in _panels)
			{
				panel.gameObject.SetActive(value: true);
			}
			this.WasRepaint?.Invoke();
		}

		public void Filter(Func<Worker, bool> filter)
		{
			_currentFilter = filter;
			foreach (UI_WorkerMgr_WorkerPanel panel in _panels)
			{
				panel.gameObject.SetActive(filter(panel.AssignedWorker));
			}
			this.WasRepaint?.Invoke();
		}

		public void Repaint()
		{
			for (int num = _panels.Count - 1; num >= 0; num--)
			{
				UI_WorkerMgr_WorkerPanel uI_WorkerMgr_WorkerPanel = _panels[num];
				if (uI_WorkerMgr_WorkerPanel.AssignedWorker == null || !WorkerList.All.Contains(uI_WorkerMgr_WorkerPanel.AssignedWorker))
				{
					OnWorkerFired(uI_WorkerMgr_WorkerPanel.AssignedWorker);
				}
			}
			foreach (Worker item in WorkerList.All)
			{
				if (item.IsEngaged)
				{
					OnWorkerHired(item);
				}
			}
			this.WasRepaint?.Invoke();
		}

		public bool ContainsWorker(Worker worker)
		{
			foreach (UI_WorkerMgr_WorkerPanel panel in _panels)
			{
				if (panel.AssignedWorker == worker)
				{
					return true;
				}
			}
			return false;
		}

		private void OnWorkerHired(Worker worker)
		{
			if (!ContainsWorker(worker))
			{
				UI_WorkerMgr_WorkerPanel orCreatePanel = GetOrCreatePanel();
				orCreatePanel.SetWorker(worker);
				orCreatePanel.SetDisplayMode(_currentDisplayMode);
				orCreatePanel.gameObject.SetActive(value: true);
				_panels.Add(orCreatePanel);
				if (_currentFilter != null)
				{
					Filter(_currentFilter);
				}
				else
				{
					this.WasRepaint?.Invoke();
				}
			}
		}

		private void OnRenameWorker(Worker worker)
		{
			for (int num = _panels.Count - 1; num >= 0; num--)
			{
				UI_WorkerMgr_WorkerPanel uI_WorkerMgr_WorkerPanel = _panels[num];
				if (!(uI_WorkerMgr_WorkerPanel.AssignedWorker != worker))
				{
					uI_WorkerMgr_WorkerPanel.RenameWorker(worker);
				}
			}
		}

		private void OnWorkerFired(Worker worker)
		{
			RemoveWorker(worker);
		}

		private void OnAgentDespawned(Agent agent)
		{
			RemoveAgent(agent);
		}

		private void RemoveAgent(Agent agent)
		{
			if (agent is Worker worker)
			{
				RemoveWorker(worker);
			}
		}

		private void RemoveWorker(Worker worker)
		{
			int num = 0;
			for (int num2 = _panels.Count - 1; num2 >= 0; num2--)
			{
				UI_WorkerMgr_WorkerPanel uI_WorkerMgr_WorkerPanel = _panels[num2];
				if (!(uI_WorkerMgr_WorkerPanel.AssignedWorker != worker))
				{
					uI_WorkerMgr_WorkerPanel.gameObject.SetActive(value: false);
					_panelPool.Push(uI_WorkerMgr_WorkerPanel);
					_panels.RemoveAt(num2);
					num++;
				}
			}
			if (num > 0)
			{
				this.WasRepaint?.Invoke();
			}
		}

		private UI_WorkerMgr_WorkerPanel GetOrCreatePanel()
		{
			if (!_panelPool.TryPop(out var result))
			{
				result = CTSFactory.Instantiate(_panelPrefab, _panelContainer, instantiateInWorldSpace: false, false);
			}
			result.transform.SetAsLastSibling();
			return result;
		}
	}
}
