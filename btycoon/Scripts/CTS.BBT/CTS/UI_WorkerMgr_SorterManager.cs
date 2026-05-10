using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class UI_WorkerMgr_SorterManager : CTSBehaviour
	{
		[SerializeField]
		private UI_WorkerMgr_Layouter _workerLayouter;

		[SerializeField]
		private UI_WorkerMgr_SortingToggle _togglePrefab;

		[SerializeField]
		private StringKey[] _baseSorterKeys;

		[SerializeField]
		[Inject(false)]
		private ToggleGroup _toggleGroup;

		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private CanvasGroupController _groupController;

		private Dictionary<StringKey, UI_WorkerMgr_SortingToggle> _baseSorters = new Dictionary<StringKey, UI_WorkerMgr_SortingToggle>();

		private Dictionary<EAgentStatistics, UI_WorkerMgr_SortingToggle> _statisticSorters = new Dictionary<EAgentStatistics, UI_WorkerMgr_SortingToggle>();

		protected override void OnAwake()
		{
			base.OnAwake();
			_workerLayouter.WasRepaint += OnLayoutRepaint;
			_workerLayouter.DisplayModeChanged += OnLayoutRepaint;
			_groupController.CanvasShowning += OnCanvasShowing;
		}

		private void OnDestroy()
		{
			_workerLayouter.WasRepaint -= OnLayoutRepaint;
			_workerLayouter.DisplayModeChanged -= OnLayoutRepaint;
			_groupController.CanvasShowning -= OnCanvasShowing;
		}

		private void OnCanvasShowing(bool obj)
		{
			if (obj)
			{
				Repaint();
			}
		}

		private void OnLayoutRepaint()
		{
			Repaint();
		}

		public void Repaint()
		{
			if (_workerLayouter.ActivePanelCount < 2)
			{
				DisableAll();
				return;
			}
			UI_WorkerMgr_WorkerPanel uI_WorkerMgr_WorkerPanel = null;
			foreach (UI_WorkerMgr_WorkerPanel panel in _workerLayouter.Panels)
			{
				if (panel.isActiveAndEnabled)
				{
					uI_WorkerMgr_WorkerPanel = panel;
					break;
				}
			}
			if ((object)uI_WorkerMgr_WorkerPanel == null)
			{
				DisableAll();
				return;
			}
			RepaintToggles<StringKey, UI_WorkerMgr_SortingAnchorBase>(_baseSorters, uI_WorkerMgr_WorkerPanel.SorterReferences.BaseSorters);
			RepaintToggles<EAgentStatistics, UI_WorkerMgr_SortingAnchorStatistic>(_statisticSorters, uI_WorkerMgr_WorkerPanel.SorterReferences.StatisticSorters);
			void RepaintToggles<TKey, TAnchor>(Dictionary<TKey, UI_WorkerMgr_SortingToggle> sorters, ReadOnlyDictionary<TKey, TAnchor> sorterReferences) where TAnchor : UI_WorkerMgr_SortingAnchorBase
			{
				TKey key;
				foreach (KeyValuePair<TKey, UI_WorkerMgr_SortingToggle> sorter in sorters)
				{
					sorter.Deconstruct(out key, out var value);
					TKey key2 = key;
					UI_WorkerMgr_SortingToggle uI_WorkerMgr_SortingToggle = value;
					uI_WorkerMgr_SortingToggle.Disable();
					if (!sorterReferences.ContainsKey(key2))
					{
						uI_WorkerMgr_SortingToggle.gameObject.SetActive(value: false);
					}
				}
				foreach (KeyValuePair<TKey, TAnchor> item in sorterReferences)
				{
					item.Deconstruct(out key, out var value2);
					TKey key3 = key;
					TAnchor val = value2;
					if (!sorters.TryGetValue(key3, out var value3))
					{
						value3 = (sorters[key3] = CreateToggle(val.GetComparer()));
					}
					value3.transform.position = value3.transform.position.SetX(val.transform.position.x);
					value3.gameObject.SetActive(val.isActiveAndEnabled);
				}
			}
		}

		private UI_WorkerMgr_SortingToggle CreateToggle(IComparer<Worker> comparer)
		{
			UI_WorkerMgr_SortingToggle uI_WorkerMgr_SortingToggle = CTSFactory.Instantiate(_togglePrefab, base.transform, instantiateInWorldSpace: false, false);
			uI_WorkerMgr_SortingToggle.Setup(_workerLayouter, _toggleGroup, comparer);
			return uI_WorkerMgr_SortingToggle;
		}

		private void DisableAll()
		{
			UI_WorkerMgr_SortingToggle value;
			foreach (KeyValuePair<StringKey, UI_WorkerMgr_SortingToggle> baseSorter in _baseSorters)
			{
				baseSorter.Deconstruct(out var _, out value);
				value.gameObject.SetActive(value: false);
			}
			foreach (KeyValuePair<EAgentStatistics, UI_WorkerMgr_SortingToggle> statisticSorter in _statisticSorters)
			{
				statisticSorter.Deconstruct(out var _, out value);
				value.gameObject.SetActive(value: false);
			}
		}
	}
}
