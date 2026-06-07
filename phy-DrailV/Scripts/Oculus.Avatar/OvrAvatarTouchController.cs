using Oculus.Avatar;
using UnityEngine;

public class OvrAvatarTouchController : OvrAvatarComponent
{
	public bool isLeftHand = true;

	private ovrAvatarControllerComponent component;

	private void Update()
	{
		if (owner == null)
		{
			return;
		}
		bool flag = false;
		if ((!isLeftHand) ? CAPI.ovrAvatarPose_GetRightControllerComponent(owner.sdkAvatar, ref component) : CAPI.ovrAvatarPose_GetLeftControllerComponent(owner.sdkAvatar, ref component))
		{
			UpdateAvatar(component.renderComponent);
			return;
		}
		if (isLeftHand)
		{
			owner.ControllerLeft = null;
		}
		else
		{
			owner.ControllerRight = null;
		}
		Object.Destroy(this);
	}
}
