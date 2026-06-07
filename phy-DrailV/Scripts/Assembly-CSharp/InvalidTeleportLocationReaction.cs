using DV.VRTK_Extensions;
using UnityEngine;

public class InvalidTeleportLocationReaction : MonoBehaviour
{
	public ZoneBlocker blocker;

	private bool currentlyHovering;

	private ControllerTooltip controllerTooltip;

	private void Start()
	{
		if (VRManager.IsVREnabled())
		{
			SetupListeners(on: true);
		}
		else
		{
			Object.Destroy(this);
		}
	}

	private void SetupListeners(bool on)
	{
		blocker.Hovered.Manage(OnHovered, on);
		blocker.Unhovered.Manage(OnUnhovered, on);
	}

	private void OnHovered()
	{
		if (!currentlyHovering)
		{
			CleanUp();
			currentlyHovering = true;
			HandIPointableSource lastSource = blocker.lastSource;
			string hoverText = blocker.GetHoverText();
			if (controllerTooltip != null)
			{
				controllerTooltip.HideTooltip();
			}
			controllerTooltip = ((lastSource == HandIPointableSource.VRRight) ? VRTK_ControllerUtils_DV.ControllerTooltipRight : VRTK_ControllerUtils_DV.ControllerTooltipLeft);
			if (controllerTooltip != null)
			{
				controllerTooltip.ShowTooltip(hoverText, showBackground: true);
			}
		}
	}

	private void OnUnhovered()
	{
		CleanUp();
	}

	private void CleanUp()
	{
		currentlyHovering = false;
		if (controllerTooltip != null)
		{
			controllerTooltip.HideTooltip();
		}
		controllerTooltip = null;
	}
}
