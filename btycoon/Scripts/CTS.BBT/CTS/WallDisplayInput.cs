using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class WallDisplayInput : CTSBehaviour
	{
		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private WallHideButton _hideButton;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			InputManager.game.wallDisplayToggle.onComplete += OnWallDisplay;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			InputManager.game.wallDisplayToggle.onComplete -= OnWallDisplay;
		}

		private void OnWallDisplay(InputAction.CallbackContext ctx)
		{
			if (!UIUtility.InInputField())
			{
				_hideButton.SetActive(!WallHideButton.Active);
			}
		}
	}
}
