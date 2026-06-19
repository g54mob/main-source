using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace UI.HUD
{
	public class PlayerHUDEnabler : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _hudCanvasGroup;

		private bool _hudHidden;

		[Inject]
		private IPlayerInputService _playerInputService;

		private void OnEnable()
		{
			_playerInputService.OnHideHud += SwitchHud;
		}

		private void OnDisable()
		{
			_playerInputService.OnHideHud -= SwitchHud;
		}

		private void SwitchHud(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				_hudHidden = !_hudHidden;
				_hudCanvasGroup.alpha = ((!_hudHidden) ? 1 : 0);
			}
		}
	}
}
