using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[Constructor("Construct")]
	public class UI_WorkerMgr_PriorityPanel : UI_WorkerMgr_WorkerInfoBase
	{
		[SerializeField]
		private ChoreCategoryData[] _priorities = Array.Empty<ChoreCategoryData>();

		[SerializeField]
		private Transform _prioritiesContainer;

		[SerializeField]
		private UI_WorkerMgr_PriorityToggle _togglePrefab;

		private Dictionary<ChoreCategory, UI_WorkerMgr_PriorityToggle> _toggles = new Dictionary<ChoreCategory, UI_WorkerMgr_PriorityToggle>();

		private void Construct()
		{
			ChoreCategoryData[] priorities = _priorities;
			foreach (ChoreCategoryData choreCategoryData in priorities)
			{
				if (!_toggles.ContainsKey(choreCategoryData.Category))
				{
					UI_WorkerMgr_PriorityToggle uI_WorkerMgr_PriorityToggle = CTSFactory.Instantiate(_togglePrefab, _prioritiesContainer, instantiateInWorldSpace: false, true);
					uI_WorkerMgr_PriorityToggle.SetPriority(choreCategoryData);
					uI_WorkerMgr_PriorityToggle.SetDisplay(isShown: false);
					_toggles[choreCategoryData.Category] = uI_WorkerMgr_PriorityToggle;
				}
			}
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			foreach (KeyValuePair<ChoreCategory, UI_WorkerMgr_PriorityToggle> toggle in _toggles)
			{
				toggle.Deconstruct(out var _, out var value);
				value.ToggleChanged += OnToggleChanged;
			}
			Worker.CVarAutonomyEnabled.SubscribeToChange(OnGlobalAutonomyChanged);
		}

		private void OnDestroy()
		{
			foreach (KeyValuePair<ChoreCategory, UI_WorkerMgr_PriorityToggle> toggle in _toggles)
			{
				toggle.Deconstruct(out var _, out var value);
				value.ToggleChanged -= OnToggleChanged;
			}
			Worker.CVarAutonomyEnabled.UnsubscribeToChange(OnGlobalAutonomyChanged);
		}

		public override void Repaint()
		{
			if (base._worker == null)
			{
				return;
			}
			bool autonomyActive = base._worker.ChoreAssigner.IsAutonomyActive();
			foreach (var (_, toggle) in _toggles)
			{
				Repaint(toggle, autonomyActive);
			}
		}

		private void Repaint(UI_WorkerMgr_PriorityToggle toggle, bool autonomyActive)
		{
			if (base._worker.ChoreAssigner.TryGetPrioritySelfActive(toggle.Category, out var selfEnabled))
			{
				toggle.SetDisplay(isShown: true);
				toggle.SetValue(selfEnabled);
			}
			else
			{
				toggle.SetDisplay(isShown: false);
			}
			toggle.SetInteractable(autonomyActive);
		}

		protected override void OnWorkerSet(Worker worker)
		{
			WorkerChoreAssigner choreAssigner = worker.ChoreAssigner;
			choreAssigner.LockStateChanged = (Action<bool>)Delegate.Combine(choreAssigner.LockStateChanged, new Action<bool>(OnWorkerAutonomyChanged));
			worker.ChoreAssigner.PriorityStatusChanged += OnPriorityChanged;
		}

		private void OnPriorityChanged(ChoreCategory arg1, bool arg2)
		{
			if (!(base._worker == null) && _toggles.TryGetValue(arg1, out var value))
			{
				Repaint(value, base._worker.ChoreAssigner.IsAutonomyActive());
			}
		}

		protected override void OnWorkerUnset(Worker worker)
		{
			WorkerChoreAssigner choreAssigner = worker.ChoreAssigner;
			choreAssigner.LockStateChanged = (Action<bool>)Delegate.Remove(choreAssigner.LockStateChanged, new Action<bool>(OnWorkerAutonomyChanged));
		}

		private void OnWorkerAutonomyChanged(bool obj)
		{
			Repaint();
		}

		private void OnGlobalAutonomyChanged(bool obj)
		{
			Repaint();
		}

		private void OnToggleChanged(ChoreCategory choreCategory, bool isOn)
		{
			if (!(base._worker == null))
			{
				base._worker.ChoreAssigner.TogglePriority(choreCategory, isOn);
			}
		}
	}
}
