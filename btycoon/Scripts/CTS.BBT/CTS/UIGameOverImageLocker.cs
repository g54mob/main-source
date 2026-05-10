using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UIGameOverImageLocker : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private ImageLocker _locker;

		private readonly LockToggle _lockToggle = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_lockToggle.Add(_locker);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			GameOver.GameOverTimerTriggered += OnGameOverTriggered;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			GameOver.GameOverTimerTriggered -= OnGameOverTriggered;
		}

		private void OnGameOverTriggered(bool active)
		{
			_lockToggle.SetLock(active);
		}
	}
}
