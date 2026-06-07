using System;
using UnityEngine;

namespace VRTK.Examples
{
	[Obsolete("`VRTK_RoomExtender_ControllerExample` will be removed in a future version of VRTK.")]
	public class VRTK_RoomExtender_ControllerExample : MonoBehaviour
	{
		protected VRTK_RoomExtender roomExtender;

		private void Start()
		{
			if (GetComponent<VRTK_ControllerEvents>() == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_RoomExtender_ControllerExample", "VRTK_ControllerEvents", "the Controller Alias"));
			}
			else if (UnityEngine.Object.FindObjectOfType<VRTK_RoomExtender>() == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_SCENE, "VRTK_RoomExtender_ControllerExample", "VRTK_RoomExtender"));
			}
			else
			{
				roomExtender = UnityEngine.Object.FindObjectOfType<VRTK_RoomExtender>();
				GetComponent<VRTK_ControllerEvents>().TouchpadPressed += DoTouchpadPressed;
				GetComponent<VRTK_ControllerEvents>().TouchpadReleased += DoTouchpadReleased;
				GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += DoSwitchMovementFunction;
			}
		}

		private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e)
		{
			roomExtender.additionalMovementMultiplier = ((e.touchpadAxis.magnitude * 5f > 1f) ? (e.touchpadAxis.magnitude * 5f) : 1f);
			if (roomExtender.additionalMovementEnabledOnButtonPress)
			{
				EnableAdditionalMovement();
			}
			else
			{
				DisableAdditionalMovement();
			}
		}

		private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
		{
			if (roomExtender.additionalMovementEnabledOnButtonPress)
			{
				DisableAdditionalMovement();
			}
			else
			{
				EnableAdditionalMovement();
			}
		}

		private void DoSwitchMovementFunction(object sender, ControllerInteractionEventArgs e)
		{
			switch (roomExtender.movementFunction)
			{
			case VRTK_RoomExtender.MovementFunction.Nonlinear:
				roomExtender.movementFunction = VRTK_RoomExtender.MovementFunction.LinearDirect;
				break;
			case VRTK_RoomExtender.MovementFunction.LinearDirect:
				roomExtender.movementFunction = VRTK_RoomExtender.MovementFunction.Nonlinear;
				break;
			}
		}

		private void EnableAdditionalMovement()
		{
			roomExtender.additionalMovementEnabled = true;
		}

		private void DisableAdditionalMovement()
		{
			roomExtender.additionalMovementEnabled = false;
		}
	}
}
