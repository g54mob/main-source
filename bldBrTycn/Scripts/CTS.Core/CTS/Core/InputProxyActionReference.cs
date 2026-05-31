using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.Core
{
	public class InputProxyActionReference : InputProxy
	{
		[SerializeField]
		private InputActionReference _actionReference;

		protected override void OnAwake()
		{
			base.OnAwake();
			_actionReference.action.started += base.SendStartedEvent;
			_actionReference.action.performed += base.SendCompletedEvent;
			_actionReference.action.canceled += base.SendCancelledEvent;
		}

		private void OnDestroy()
		{
			_actionReference.action.started -= base.SendStartedEvent;
			_actionReference.action.performed -= base.SendCompletedEvent;
			_actionReference.action.canceled -= base.SendCancelledEvent;
		}

		public override bool IsInProgress()
		{
			return _actionReference.action.inProgress;
		}
	}
}
