using Oculus.Avatar;
using UnityEngine;

public class OvrAvatarHand : OvrAvatarComponent
{
	public bool isLeftHand = true;

	private ovrAvatarHandComponent component;

	private void Update()
	{
		if (owner == null)
		{
			return;
		}
		bool flag = false;
		if ((!isLeftHand) ? CAPI.ovrAvatarPose_GetRightHandComponent(owner.sdkAvatar, ref component) : CAPI.ovrAvatarPose_GetLeftHandComponent(owner.sdkAvatar, ref component))
		{
			UpdateAvatar(component.renderComponent);
			return;
		}
		if (isLeftHand)
		{
			owner.HandLeft = null;
		}
		else
		{
			owner.HandRight = null;
		}
		Object.Destroy(this);
	}
}
