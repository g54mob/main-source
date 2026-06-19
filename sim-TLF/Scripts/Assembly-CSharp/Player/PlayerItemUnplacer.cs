using AssembleSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerItemUnplacer : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _viewRaycaster;

		[Inject]
		private IPlayerInputService _inputService;

		private void OnEnable()
		{
			_inputService.OnDrop += TryUnplaceObject;
		}

		private void OnDisable()
		{
			_inputService.OnDrop -= TryUnplaceObject;
		}

		private void Update()
		{
		}

		private void TryUnplaceObject(InputAction.CallbackContext context)
		{
			Transform transform = _viewRaycaster.Hit.transform;
			if (transform != null && transform.TryGetComponent<PartObject>(out var component) && component.IsPickable && component.StateMachine != null && component.StateMachine.Placed && !component.StateMachine.Tightened)
			{
				component.StateMachine.Placed = false;
			}
		}
	}
}
