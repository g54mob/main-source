using DV.Utils;
using DV.VRTK_Extensions;
using VRTK;

[ExecuteBefore(typeof(TeleportPointerController))]
public class VRTK_ControllerEvents_LateUpdate : VRTK_ControllerEvents
{
	protected override void Update()
	{
	}

	private void LateUpdate()
	{
		base.Update();
	}

	protected override void CheckTouchpadEvents(VRTK_ControllerReference controllerReference)
	{
		if (controllerReference.GetControllerTypeDV() != ControllerType_DV.HPReverbG2)
		{
			base.CheckTouchpadEvents(controllerReference);
		}
	}

	protected override void CheckButtonTwoEvents(VRTK_ControllerReference controllerReference)
	{
		if (controllerReference.GetControllerTypeDV() != ControllerType_DV.HPReverbG2)
		{
			base.CheckButtonTwoEvents(controllerReference);
		}
		else
		{
			CheckButtonTwoEventsG2(controllerReference);
		}
	}

	private void CheckButtonTwoEventsG2(VRTK_ControllerReference controllerReference)
	{
		bool controllerButtonState = VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonOne, SDK_BaseController.ButtonPressTypes.TouchDown, controllerReference);
		bool controllerButtonState2 = VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonOne, SDK_BaseController.ButtonPressTypes.TouchUp, controllerReference);
		bool controllerButtonState3 = VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonOne, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference);
		bool controllerButtonState4 = VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.ButtonOne, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference);
		if (!controllerButtonState && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.TouchDown, controllerReference))
		{
			OnButtonTwoTouchStart(SetControllerEvent(ref buttonTwoTouched, value: true, 1f));
		}
		if (!controllerButtonState3 && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.PressDown, controllerReference))
		{
			OnButtonTwoPressed(SetControllerEvent(ref buttonTwoPressed, value: true, 1f));
		}
		else if (!controllerButtonState4 && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.PressUp, controllerReference))
		{
			OnButtonTwoReleased(SetControllerEvent(ref buttonTwoPressed));
		}
		if (!controllerButtonState2 && VRTK_SDK_Bridge.GetControllerButtonState(SDK_BaseController.ButtonTypes.Touchpad, SDK_BaseController.ButtonPressTypes.TouchUp, controllerReference))
		{
			OnButtonTwoTouchEnd(SetControllerEvent(ref buttonTwoTouched));
		}
	}
}
