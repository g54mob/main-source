using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class FurnitureShopInputsObserver : MonoBehaviour
	{
		[SerializeField]
		private InputActionReference _clockWiseWithR;

		[SerializeField]
		private InputActionReference _counterClockWithR;

		public static event Action PlaceInputPressed;

		public static event Action CancelPlacementInputPressed;

		public static event Action RotateClockwiseInputPressed;

		public static event Action RotateCounterClockwiseInputPressed;

		private void OnEnable()
		{
			InputManager.game.build.place.onComplete += PlaceOnDown;
			InputManager.game.build.cancelplacement.onDown += CancelPlacementOnDown;
			InputManager.game.build.rotateclockwise.onComplete += RotateClockwiseOnDown;
			InputManager.game.build.rotatecounterclockwise.onComplete += RotateCounterClockwiseOnDown;
			_clockWiseWithR.action.performed += RotateClockwiseOnDown;
			_counterClockWithR.action.performed += RotateCounterClockwiseOnDown;
		}

		private void OnDisable()
		{
			InputManager.game.build.place.onComplete -= PlaceOnDown;
			InputManager.game.build.cancelplacement.onDown -= CancelPlacementOnDown;
			InputManager.game.build.rotateclockwise.onComplete -= RotateClockwiseOnDown;
			InputManager.game.build.rotatecounterclockwise.onComplete -= RotateCounterClockwiseOnDown;
			_clockWiseWithR.action.performed -= RotateClockwiseOnDown;
			_counterClockWithR.action.performed -= RotateCounterClockwiseOnDown;
		}

		private void PlaceOnDown(InputAction.CallbackContext ctx)
		{
			FurnitureShopInputsObserver.PlaceInputPressed?.Invoke();
		}

		private void CancelPlacementOnDown(InputAction.CallbackContext ctx)
		{
			FurnitureShopInputsObserver.CancelPlacementInputPressed?.Invoke();
		}

		private void RotateClockwiseOnDown(InputAction.CallbackContext ctx)
		{
			FurnitureShopInputsObserver.RotateClockwiseInputPressed?.Invoke();
		}

		private void RotateCounterClockwiseOnDown(InputAction.CallbackContext ctx)
		{
			FurnitureShopInputsObserver.RotateCounterClockwiseInputPressed?.Invoke();
		}
	}
}
