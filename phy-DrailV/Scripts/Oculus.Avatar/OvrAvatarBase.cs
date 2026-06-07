using Oculus.Avatar;
using UnityEngine;

public class OvrAvatarBase : OvrAvatarComponent
{
	private ovrAvatarBaseComponent component;

	private void Update()
	{
		if (!(owner == null))
		{
			if (CAPI.ovrAvatarPose_GetBaseComponent(owner.sdkAvatar, ref component))
			{
				UpdateAvatar(component.renderComponent);
				return;
			}
			owner.Base = null;
			Object.Destroy(this);
		}
	}
}
