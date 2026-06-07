using System.Collections.Generic;
using DV.CabControls.VRTK;
using DV.Highlighting;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.CabControls
{
	public class TouchscreenVRTK : TouchscreenBase
	{
		private VRTK_ControlImplBaseInteractableObject interactable;

		private HashSet<GameObject> touchingControllers = new HashSet<GameObject>();

		protected override void Awake()
		{
			base.Awake();
			interactable = base.gameObject.AddComponent<VRTK_ControlImplBaseInteractableObject>();
			interactable.isGrabbable = false;
			interactable.isUsable = true;
			interactable.InteractableObjectUsed += OnInteractableObjectUsed;
			interactable.InteractableObjectTouched += OnTouched;
			interactable.InteractableObjectUntouched += OnUntouched;
			interactable.priority = 1;
			interactable.pipaExclusiveInteraction = true;
			interactable.controlImplBase = this;
			interactable.interactionHandPoses = GenerateHandPoses();
			interactable.SetCustomInteractionPoint(GetInteractionPoint);
		}

		private void OnInteractableObjectUsed(object sender, InteractableObjectEventArgs e)
		{
			Touch(LocalPipaPosition(e.interactingObject), vrTolerance);
			Use();
		}

		private void OnTouched(object sender, InteractableObjectEventArgs e)
		{
			GameObject interactingObject = e.interactingObject;
			touchingControllers.Add(interactingObject);
			_ = currentlyTouchedSection;
			Touch(LocalPipaPosition(interactingObject), vrTolerance);
		}

		private void OnUntouched(object sender, InteractableObjectEventArgs e)
		{
			touchingControllers.Remove(e.interactingObject);
			Untouch();
			base.IsTouched = touchingControllers.Count <= 0;
		}

		public override bool IsGrabbed()
		{
			return false;
		}

		public override void ForceEndInteraction()
		{
			interactable.ForceStopInteracting();
		}

		private void Update()
		{
			if (touchingControllers.Count <= 0)
			{
				return;
			}
			foreach (GameObject touchingController in touchingControllers)
			{
				Vector2Int vector2Int = currentlyTouchedSection;
				Touch(LocalPipaPosition(touchingController), vrTolerance);
				if (vector2Int != currentlyTouchedSection)
				{
					HapticUtils.DoHapticPulse(VRTK_DeviceFinder.GetControllerReferenceForHand(VRTK_DeviceFinder.GetControllerHand(touchingController)), HapticIntensityType.Normal);
				}
			}
		}

		private Vector3 LocalPipaPosition(GameObject controller)
		{
			Vector3 position = PipaUtils.PipaPosition(controller);
			return base.transform.InverseTransformPoint(position);
		}

		private Vector3 GetInteractionPoint(Vector3 pipaPosition)
		{
			return ClosestSectionCenterWorldPosition(pipaPosition);
		}

		protected override bool SetHighlight(bool on)
		{
			if (!base.SetHighlight(on) || highlightTag == null)
			{
				return false;
			}
			SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on, highlightTag, AGeneralHighlighter.HighlightType.Control, useObstructedMaterial: false);
			return true;
		}
	}
}
