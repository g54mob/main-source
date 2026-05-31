using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class QuickSave : CTSBehaviour
	{
		[SerializeField]
		private InputActionReference _input;

		protected override void OnAwake()
		{
			base.OnAwake();
			_input.action.performed += OnInputPerformed;
		}

		private void OnDestroy()
		{
			_input.action.performed -= OnInputPerformed;
		}

		private void OnInputPerformed(InputAction.CallbackContext obj)
		{
			CTSSingleton<ProfileManager>.Instance.Save();
		}
	}
}
