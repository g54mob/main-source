using System.Collections;
using DV.CabControls;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

public class TutorialJobUseNonVr : MonoBehaviour
{
	private TutorialJob tutorialJobBooklet;

	private GrabHandlerItem grabHandler;

	private ItemBase item;

	private LayerMask interactionObjectsLayerMask;

	private RaycastHit currentHit;

	private bool interactionTextUpdate;

	private IEnumerator Start()
	{
		yield return null;
		tutorialJobBooklet = GetComponent<TutorialJob>();
		grabHandler = GetComponent<GrabHandlerItem>();
		item = GetComponent<ItemBase>();
		if (grabHandler == null || item == null || tutorialJobBooklet == null)
		{
			Debug.LogWarning("Couldn't extract TutorialJob, GrabHandlerItem or ItemBase used for non VR interaction. Deleting this script!", this);
			Object.Destroy(this);
			yield break;
		}
		interactionObjectsLayerMask = LayerMask.GetMask("Grabbed_Item");
		item.Grabbed += OnGrab;
		item.Ungrabbed += OnUngrab;
	}

	private void OnGrab(ControlImplBase _)
	{
		item.Used += OnTutorialBookletUsed;
		interactionTextUpdate = true;
	}

	private void OnUngrab(ControlImplBase _)
	{
		item.Used -= OnTutorialBookletUsed;
		interactionTextUpdate = false;
	}

	private void Update()
	{
		if (interactionTextUpdate && (bool)SingletonBehaviour<InteractionTextControllerNonVr>.Instance && ScanForHit() && currentHit.rigidbody?.GetComponent<TutorialJobValidator>() != null)
		{
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.JobBookletValidatorUse);
		}
	}

	private void OnTutorialBookletUsed()
	{
		if (ScanForHit())
		{
			TutorialJobValidator tutorialJobValidator = currentHit.rigidbody?.GetComponent<TutorialJobValidator>();
			if (tutorialJobValidator != null)
			{
				tutorialJobValidator.ValidateTutorialJob(tutorialJobBooklet);
			}
		}
	}

	private bool ScanForHit()
	{
		Grabber grabber = grabHandler.GetGrabber();
		if (grabber == null)
		{
			return false;
		}
		return Physics.SphereCast(grabber.Cursor.GetRay(), 0.005f, out currentHit, 1.5f, interactionObjectsLayerMask, QueryTriggerInteraction.Ignore);
	}
}
