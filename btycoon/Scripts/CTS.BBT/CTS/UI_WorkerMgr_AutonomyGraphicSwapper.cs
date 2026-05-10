using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UI_WorkerMgr_AutonomyGraphicSwapper : UI_WorkerMgr_WorkerInfoBase
	{
		[SerializeField]
		private List<StringKey> _allowedModes;

		[Inject(false)]
		private GraphicToggleSwap _swapper;

		protected override void OnAwake()
		{
			base.OnAwake();
			Worker.CVarAutonomyEnabled.SubscribeToChange(OnGlobalAutonomyChanged);
			_workerPanel.DisplayModeChanged += OnDisplayModeChanged;
		}

		private void OnDestroy()
		{
			Worker.CVarAutonomyEnabled.UnsubscribeToChange(OnGlobalAutonomyChanged);
			_workerPanel.DisplayModeChanged -= OnDisplayModeChanged;
		}

		private void OnDisplayModeChanged(StringKey obj)
		{
			Repaint();
		}

		public override void Repaint()
		{
			if (!(base._worker == null))
			{
				if (!_allowedModes.Contains(_workerPanel.CurrentMode))
				{
					_swapper.SetValue(isOn: true);
					return;
				}
				bool value = !base._worker.ChoreAssigner.IsLocked && Worker.GlobalAutonomyEnabled;
				_swapper.SetValue(value);
			}
		}

		protected override void OnWorkerSet(Worker worker)
		{
			WorkerChoreAssigner choreAssigner = worker.ChoreAssigner;
			choreAssigner.LockStateChanged = (Action<bool>)Delegate.Combine(choreAssigner.LockStateChanged, new Action<bool>(OnWorkerAutonomyChanged));
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
	}
}
