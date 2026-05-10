using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UI_WorkerMgr_AutonomyToggle : UI_WorkerMgr_WorkerInfoBase
	{
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		private LockToggle _toggleLock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_toggleLock.Add(_toggle);
			_toggle.onValueChanged.AddListener(OnToggleChanged);
			Worker.CVarAutonomyEnabled.SubscribeToChange(OnGlobalAutonomyChanged);
		}

		private void OnDestroy()
		{
			_toggle.onValueChanged.RemoveListener(OnToggleChanged);
			Worker.CVarAutonomyEnabled.UnsubscribeToChange(OnGlobalAutonomyChanged);
		}

		private void OnToggleChanged(bool isOn)
		{
			base._worker.ChoreAssigner.SetActive(isOn);
		}

		private void OnGlobalAutonomyChanged(bool isOn)
		{
			_toggleLock.SetLock(!isOn);
		}

		protected override void OnWorkerSet(Worker worker)
		{
			base.OnWorkerSet(worker);
			worker.ChoreAssigner.SelfLockChanged += OnWorkerAutonomyChanged;
		}

		protected override void OnWorkerUnset(Worker worker)
		{
			base.OnWorkerUnset(worker);
			worker.ChoreAssigner.SelfLockChanged -= OnWorkerAutonomyChanged;
		}

		private void OnWorkerAutonomyChanged()
		{
			Repaint();
		}

		public override void Repaint()
		{
			if ((object)base._worker != null)
			{
				_toggle.isOn = !base._worker.ChoreAssigner.IsLocked;
			}
		}
	}
}
