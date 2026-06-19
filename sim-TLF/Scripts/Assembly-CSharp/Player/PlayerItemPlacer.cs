using AssembleSystem.FSM.Parts;
using AssembleSystem.FSM.Parts.States;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
	public class PlayerItemPlacer : MonoBehaviour
	{
		[SerializeField]
		private RaycasterInfo _playerRaycastInfo;

		[Inject]
		private IPlayerInputService _inputService;

		private void OnEnable()
		{
			_inputService.OnInteract += TryPlaceAssembleObject;
		}

		private void OnDisable()
		{
			_inputService.OnInteract -= TryPlaceAssembleObject;
		}

		private void TryPlaceAssembleObject(InputAction.CallbackContext context)
		{
			if (_playerRaycastInfo.Hit.transform != null && _playerRaycastInfo.Hit.transform.TryGetComponent<ITempPart>(out var component))
			{
				Debug.Log(component.MainPart.gameObject.name);
				component.MainPart.GetComponent<PartObjectStateMachine>().Placed = true;
			}
		}
	}
}
