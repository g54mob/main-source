using Items;
using JSAM;
using UI.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerItemUser : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _playerRaycasterInfo;

		[Inject]
		private IInventoryUIService _inventoryUIService;

		[Inject]
		private IInventoryService _inventoryService;

		[Inject]
		private IPlayerInputService _playerInputService;

		[Inject]
		private IPlayerEquipService _playerEquipService;

		private IUsable _lastUsable;

		private void OnEnable()
		{
			_playerInputService.OnPlayerUse += TryUnuse;
			_playerInputService.OnPlayerUse += OnItemUse;
		}

		private void OnDisable()
		{
			_playerInputService.OnPlayerUse -= TryUnuse;
			_playerInputService.OnPlayerUse -= OnItemUse;
		}

		private void OnItemUse(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				if (_playerRaycasterInfo.Hit.transform != null && _playerRaycasterInfo.Hit.transform.TryGetComponent<IUsable>(out var component))
				{
					component.Use();
					_lastUsable = component;
					AudioManager.PlaySound(InteractionLibrarySounds.UseItem);
				}
			}
			else if (context.canceled && _lastUsable != null)
			{
				_lastUsable.UnUse();
				_lastUsable = null;
			}
		}

		private void TryUnuse(InputAction.CallbackContext context)
		{
			_ = context.performed;
		}
	}
}
