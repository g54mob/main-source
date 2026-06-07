using UnityEngine;
using VRTK;

public class PlayerInputTouchpadControl : VRTK_TouchpadControl
{
	[SerializeField]
	private LocomotionInputWrapper locomotionInput;

	protected override void OnEnable()
	{
		base.OnEnable();
		if (locomotionInput == null)
		{
			Debug.LogError("PlayerInputTouchpadControl doesn't have LocomotionInputWrapper assigned", this);
		}
	}

	protected override VRTK_ObjectControl GetOtherControl()
	{
		GameObject gameObject = (VRTK_DeviceFinder.IsControllerLeftHand(base.transform.parent.gameObject) ? VRTK_DeviceFinder.GetControllerRightHand() : VRTK_DeviceFinder.GetControllerLeftHand());
		if (gameObject != null)
		{
			return gameObject.GetComponentInChildren<VRTK_TouchpadControl>();
		}
		return null;
	}

	protected override void TouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
	{
		base.TouchpadTouchEnd(sender, e);
		if ((bool)locomotionInput)
		{
			locomotionInput.ResetAxis(VRTK_DeviceFinder.IsControllerLeftHand(base.transform.parent.gameObject));
		}
	}

	protected override void Update()
	{
		base.Update();
		ControlFixedUpdate();
	}

	protected override void FixedUpdate()
	{
		CheckDirectionDevice();
		CheckFalling();
	}

	public void ResetInput()
	{
		currentAxis = Vector2.zero;
		touchpadFirstChange = true;
		if ((bool)locomotionInput)
		{
			locomotionInput.ResetAxis(VRTK_DeviceFinder.IsControllerLeftHand(base.transform.parent.gameObject));
		}
	}
}
