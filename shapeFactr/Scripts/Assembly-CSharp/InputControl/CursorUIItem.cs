using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace InputControl
{
	public class CursorUIItem : CursorUIBase
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private Toggle _toggle;

		[SerializeField]
		private bool _forceInteract;

		[SerializeField]
		private bool _forceSwitchAction;

		[SerializeField]
		private bool _isInactiveObjectNotWorking;

		public UnityEvent OnClick;

		public UnityEvent OnSwitchAction;

		public UnityEvent OnCancelAction;

		private bool IsInteractable()
		{
			return false;
		}

		private void ExecuteAction(UnityEvent action)
		{
		}

		public override void OnDecide()
		{
		}

		public override void OnCancel()
		{
		}

		public override void OnSwitch()
		{
		}
	}
}
