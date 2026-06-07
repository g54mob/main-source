using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityStandardAssets.Characters.FirstPerson
{
	[Serializable]
	public class RayLookAt
	{
		public InputController inputctrl;

		private bool i_interact;

		private bool secondAction;

		private bool i_closemenu;

		private bool hoverIsOn;

		public float distToInteractObject;

		private float hitDistance;

		private float currentHoldTime;

		private Interact interactable;

		private Interact previoousInteractable;

		[SerializeField]
		private Camera playerCamera;

		private Action<InputAction.CallbackContext> onInteractPerformed;

		private Action<InputAction.CallbackContext> onInteractCanceled;

		private Action<InputAction.CallbackContext> onSecondActionPerformed;

		private Action<InputAction.CallbackContext> onSecondActionCanceled;

		private Action<InputAction.CallbackContext> onCloseMenuStarted;

		private int _raycastLayerMask;

		public void Init()
		{
		}

		public void Cleanup()
		{
		}

		public void HandleLookAtRay(Transform character)
		{
		}

		private void ResetHold()
		{
		}

		private void HideItemNameOrSiluete()
		{
		}

		public void CloseInteractionMenu()
		{
		}
	}
}
