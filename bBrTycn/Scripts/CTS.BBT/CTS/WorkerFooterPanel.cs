using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class WorkerFooterPanel : AbsAgentPanel
	{
		[SerializeField]
		private CTSButton _dismissButton;

		private LockToggle _buttonLock = new LockToggle();

		protected override void Awake()
		{
			base.Awake();
			_buttonLock.Add(_dismissButton);
			_dismissButton.onClick.AddListener(OnDismiss);
		}

		public override void SetAgentInfo()
		{
			if (!(base._agent == null) && base._agent is Worker worker)
			{
				_buttonLock.SetLock(!worker.Dismissable);
			}
		}

		private void OnDismiss()
		{
			if (!(base._agent == null) && base._agent is Worker worker)
			{
				worker.Dismiss();
			}
		}

		public override void ClearAgentInfo()
		{
		}
	}
}
