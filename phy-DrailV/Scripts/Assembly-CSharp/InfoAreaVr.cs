using DV;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;

public class InfoAreaVr : InfoArea
{
	private bool showingInfo;

	private bool showingOnLeftHand;

	private void OnDisable()
	{
		if (showingInfo)
		{
			ControllerTooltip controllerTooltip = (showingOnLeftHand ? VRTK_ControllerUtils_DV.ControllerTooltipLeft : VRTK_ControllerUtils_DV.ControllerTooltipRight);
			if (controllerTooltip != null)
			{
				controllerTooltip.HideTooltip();
			}
			showingInfo = false;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (showingInfo)
		{
			return;
		}
		ControllerPipa component = other.GetComponent<ControllerPipa>();
		if (!(component != null))
		{
			return;
		}
		PipaUtils.PipaHand pipaHand = PipaUtils.GetPipaHand(component.transform);
		if (pipaHand == PipaUtils.PipaHand.None)
		{
			Debug.LogError("Unexpected state: enteredPipa is not pipa transform!");
			return;
		}
		showingOnLeftHand = pipaHand == PipaUtils.PipaHand.Left;
		ControllerTooltip controllerTooltip = (showingOnLeftHand ? VRTK_ControllerUtils_DV.ControllerTooltipLeft : VRTK_ControllerUtils_DV.ControllerTooltipRight);
		if (controllerTooltip != null)
		{
			controllerTooltip.ShowTooltip(SingletonBehaviour<InteractionText>.Instance.GetText(infoType), showBackground: true);
		}
		showingInfo = true;
	}

	private void OnTriggerExit(Collider other)
	{
		if (!showingInfo)
		{
			return;
		}
		ControllerPipa component = other.GetComponent<ControllerPipa>();
		if (!(component != null))
		{
			return;
		}
		PipaUtils.PipaHand pipaHand = PipaUtils.GetPipaHand(component.transform);
		if (pipaHand == PipaUtils.PipaHand.None)
		{
			Debug.LogError("Unexpected state: exitedPipa is not pipa transform!");
		}
		else if (pipaHand == (PipaUtils.PipaHand)((!showingOnLeftHand) ? 1 : 2))
		{
			ControllerTooltip controllerTooltip = (showingOnLeftHand ? VRTK_ControllerUtils_DV.ControllerTooltipLeft : VRTK_ControllerUtils_DV.ControllerTooltipRight);
			if (controllerTooltip != null)
			{
				controllerTooltip.HideTooltip();
			}
			showingInfo = false;
		}
	}
}
