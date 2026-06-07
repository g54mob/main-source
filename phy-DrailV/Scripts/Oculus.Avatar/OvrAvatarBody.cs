using Oculus.Avatar;
using UnityEngine;

public class OvrAvatarBody : OvrAvatarComponent
{
	public ovrAvatarBodyComponent component;

	public ovrAvatarComponent? GetNativeAvatarComponent()
	{
		if (owner == null)
		{
			return null;
		}
		if (CAPI.ovrAvatarPose_GetBodyComponent(owner.sdkAvatar, ref component))
		{
			CAPI.ovrAvatarComponent_Get(component.renderComponent, includeName: true, ref nativeAvatarComponent);
			return nativeAvatarComponent;
		}
		return null;
	}

	private void Update()
	{
		if (!(owner == null))
		{
			if (CAPI.ovrAvatarPose_GetBodyComponent(owner.sdkAvatar, ref component))
			{
				UpdateAvatar(component.renderComponent);
				return;
			}
			owner.Body = null;
			Object.Destroy(this);
		}
	}
}
