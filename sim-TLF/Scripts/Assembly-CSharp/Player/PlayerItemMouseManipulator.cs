using Items;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerItemMouseManipulator : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _playerViewRaycaster;

		private IMouseButtonManipulatable _manipulatedItem;

		private bool _isManipulatingUp;

		private bool _isManipulatingDown;

		[Inject]
		private IPlayerInputService _inputService;

		private void OnEnable()
		{
			_inputService.OnInteract += TryManipulateUp;
			_inputService.OnDrop += TryManipulateDown;
		}

		private void OnDisable()
		{
			_inputService.OnInteract -= TryManipulateUp;
			_inputService.OnDrop += TryManipulateDown;
		}

		private void Update()
		{
			if (_manipulatedItem != null)
			{
				if (_isManipulatingUp)
				{
					_manipulatedItem.TryManipulateUp();
				}
				else if (_isManipulatingDown)
				{
					_manipulatedItem.TryManipulateDown();
				}
			}
		}

		private void TryManipulateUp(InputAction.CallbackContext context)
		{
			Transform transform = _playerViewRaycaster.Hit.transform;
			if (context.started && transform != null)
			{
				transform.TryGetComponent<IMouseButtonManipulatable>(out _manipulatedItem);
				_isManipulatingUp = true;
				if (_manipulatedItem == null)
				{
					return;
				}
			}
			if (context.canceled && _manipulatedItem != null)
			{
				_isManipulatingUp = false;
				_manipulatedItem = null;
			}
		}

		private void TryManipulateDown(InputAction.CallbackContext context)
		{
			Transform transform = _playerViewRaycaster.Hit.transform;
			if (context.started && transform != null)
			{
				transform.TryGetComponent<IMouseButtonManipulatable>(out _manipulatedItem);
				_isManipulatingDown = true;
				if (_manipulatedItem == null)
				{
					return;
				}
			}
			if (context.canceled && _manipulatedItem != null)
			{
				_isManipulatingDown = false;
				_manipulatedItem = null;
			}
		}
	}
}
