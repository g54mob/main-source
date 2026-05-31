using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.UI
{
	public class OpenCanvasEscape : CTSBehaviour
	{
		[SerializeField]
		private bool _canBeOpenWithEscap;

		[SerializeField]
		private InputActionReference _openCanvasWithEscape;

		[SerializeField]
		[Inject(false)]
		private CanvasGroupController _controllerCanvas;

		[SerializeField]
		[Inject(false)]
		private CanvasExclusivity _canvasExclusivity;

		protected override void OnAwake()
		{
			_openCanvasWithEscape.action.performed += EscapePerfomed;
		}

		private void OnDestroy()
		{
			_openCanvasWithEscape.action.performed -= EscapePerfomed;
		}

		private void EscapePerfomed(InputAction.CallbackContext obj)
		{
			if ((!_canvasExclusivity || !CanvasExclusivity.IsOpen(_canvasExclusivity.ExclusivityGroup)) && _canBeOpenWithEscap)
			{
				TryExitCurrentWithEscape();
			}
		}

		private void TryExitCurrentWithEscape()
		{
			if (!_controllerCanvas.IsShown)
			{
				_controllerCanvas.QuickShow();
			}
		}
	}
}
