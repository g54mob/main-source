using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class FloorChangeInputsObserver : MonoBehaviour
	{
		public static event Action NextFloorInputPressed;

		public static event Action PreviousFloorInputPressed;

		private void OnEnable()
		{
			InputManager.game.nextFloor.onDown += NextFloorOnDown;
			InputManager.game.previousFloor.onDown += PreviousFloorOnDown;
		}

		private void OnDisable()
		{
			InputManager.game.nextFloor.onDown -= NextFloorOnDown;
			InputManager.game.previousFloor.onDown -= PreviousFloorOnDown;
		}

		private void PreviousFloorOnDown(InputAction.CallbackContext ctx)
		{
			FloorChangeInputsObserver.PreviousFloorInputPressed?.Invoke();
		}

		private void NextFloorOnDown(InputAction.CallbackContext ctx)
		{
			FloorChangeInputsObserver.NextFloorInputPressed?.Invoke();
		}
	}
}
