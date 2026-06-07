using System.Collections;
using DV;
using DV.Items.Snapping;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class InfoAreaVrBeltSlot : InfoArea
{
	public float displayDelay = 0.5f;

	private bool showingInfo;

	private bool showingOnLeftHand;

	[SerializeField]
	private ItemSnapPointBase snapPoint;

	private ControllerPipa hoveringPipa;

	private Coroutine delayedDisplayCoro;

	private void OnDisable()
	{
		if (delayedDisplayCoro != null)
		{
			StopCoroutine(delayedDisplayCoro);
			delayedDisplayCoro = null;
		}
		if (showingInfo)
		{
			ControllerTooltip controllerTooltip = (showingOnLeftHand ? VRTK_ControllerUtils_DV.ControllerTooltipLeft : VRTK_ControllerUtils_DV.ControllerTooltipRight);
			if (controllerTooltip != null)
			{
				controllerTooltip.HideTooltip();
			}
			showingInfo = false;
			if (hoveringPipa != null)
			{
				hoveringPipa.grab.ControllerGrabInteractableObject -= OnGrabbedWhileTooltipDisplayed;
			}
		}
		hoveringPipa = null;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (showingInfo || delayedDisplayCoro != null || hoveringPipa != null)
		{
			return;
		}
		ControllerPipa component = other.GetComponent<ControllerPipa>();
		if (component != null)
		{
			if (PipaUtils.GetPipaHand(component.transform) == PipaUtils.PipaHand.None)
			{
				Debug.LogError("Unexpected state: enteredPipa is not pipa transform!");
			}
			else if (!(snapPoint.SnappedItem != null) && !(component.grab.GetGrabbedObject() != null))
			{
				hoveringPipa = component;
				delayedDisplayCoro = StartCoroutine(DelayedConditionalTooltipDisplay());
			}
		}
	}

	private IEnumerator DelayedConditionalTooltipDisplay()
	{
		yield return WaitFor.SecondsRealtime(displayDelay);
		if (snapPoint.SnappedItem != null || hoveringPipa == null || hoveringPipa.grab.GetGrabbedObject() != null)
		{
			hoveringPipa = null;
			delayedDisplayCoro = null;
			yield break;
		}
		showingOnLeftHand = PipaUtils.GetPipaHand(hoveringPipa.transform) == PipaUtils.PipaHand.Left;
		ControllerTooltip controllerTooltip = (showingOnLeftHand ? VRTK_ControllerUtils_DV.ControllerTooltipLeft : VRTK_ControllerUtils_DV.ControllerTooltipRight);
		if (controllerTooltip != null)
		{
			controllerTooltip.ShowTooltip(SingletonBehaviour<InteractionText>.Instance.GetText(infoType), showBackground: true);
		}
		showingInfo = true;
		hoveringPipa.grab.ControllerGrabInteractableObject += OnGrabbedWhileTooltipDisplayed;
		delayedDisplayCoro = null;
	}

	private void OnGrabbedWhileTooltipDisplayed(object sender, ObjectInteractEventArgs e)
	{
		if (!showingInfo)
		{
			Debug.LogError("Unexpected state: OnGrabbedWhileTooltipDisplayed called when showingInfo isn't set!");
			return;
		}
		if (hoveringPipa == null)
		{
			Debug.LogError("Unexpected state: hoveringPipa is null in OnGrabbedWhileTooltipDisplayed");
			return;
		}
		ControllerTooltip controllerTooltip = (showingOnLeftHand ? VRTK_ControllerUtils_DV.ControllerTooltipLeft : VRTK_ControllerUtils_DV.ControllerTooltipRight);
		if (controllerTooltip != null)
		{
			controllerTooltip.HideTooltip();
		}
		showingInfo = false;
		hoveringPipa.grab.ControllerGrabInteractableObject -= OnGrabbedWhileTooltipDisplayed;
		hoveringPipa = null;
	}

	private void OnTriggerExit(Collider other)
	{
		ControllerPipa component = other.GetComponent<ControllerPipa>();
		if (component == null || hoveringPipa != component)
		{
			return;
		}
		if (showingInfo)
		{
			ControllerTooltip controllerTooltip = (showingOnLeftHand ? VRTK_ControllerUtils_DV.ControllerTooltipLeft : VRTK_ControllerUtils_DV.ControllerTooltipRight);
			if (controllerTooltip != null)
			{
				controllerTooltip.HideTooltip();
			}
			showingInfo = false;
			hoveringPipa.grab.ControllerGrabInteractableObject -= OnGrabbedWhileTooltipDisplayed;
		}
		else if (delayedDisplayCoro != null)
		{
			StopCoroutine(delayedDisplayCoro);
			delayedDisplayCoro = null;
		}
		hoveringPipa = null;
	}
}
