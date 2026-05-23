using Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Utils
{
	public class DisableInput : MonoBehaviour
	{
		[SerializeField]
		private BaseEvent _disableInput;

		[SerializeField]
		private BaseEvent _enableInput;

		[SerializeField]
		private PlayerInput _playerInput;

		private void Start()
		{
			_disableInput.Register(Disable);
			_enableInput.Register(Enable);
		}

		private void OnDestroy()
		{
			_disableInput.UnRegister(Disable);
			_enableInput.UnRegister(Enable);
		}

		private void Enable()
		{
			_playerInput.ActivateInput();
		}

		private void Disable()
		{
			_playerInput.DeactivateInput();
		}
	}
}
