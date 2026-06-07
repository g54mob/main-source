using DV.CabControls.NonVR;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

public class ItemInteractionTextScanNonVr : MonoBehaviour
{
	public Grabber grabber;

	private void Update()
	{
		if ((bool)SingletonBehaviour<InteractionTextControllerNonVr>.Instance && !grabber.IsGrabbing())
		{
			InfoArea component2;
			if ((bool)grabber.Raycaster.CurrentlyRaycasted && grabber.Raycaster.CurrentlyRaycasted.TryGetComponent<ItemNonVR>(out var _))
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.GrabItem);
			}
			else if (grabber.Raycaster.AnythingHit && grabber.Raycaster.CurrentlyHit.collider.TryGetComponent<InfoArea>(out component2))
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(component2.infoType);
			}
		}
	}
}
