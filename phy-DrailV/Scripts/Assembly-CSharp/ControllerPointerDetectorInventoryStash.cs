using DV.CabControls.Spec;
using UnityEngine;
using VRTK;

public class ControllerPointerDetectorInventoryStash : ControllerPointerDetector
{
	protected override bool InteractionAllowed => true;

	protected override bool ValidIntersect(VRTK_InteractGrab grab)
	{
		GameObject grabbedObject = grab.GetGrabbedObject();
		if (grabbedObject != null)
		{
			return grabbedObject.GetComponent<Item>() != null;
		}
		return false;
	}

	protected override bool CheckWarnImproperTouch(VRTK_InteractGrab grab)
	{
		return false;
	}

	public void ForceUnhighlight()
	{
		UpdateHighlight(forceUnhighlight: true);
	}
}
