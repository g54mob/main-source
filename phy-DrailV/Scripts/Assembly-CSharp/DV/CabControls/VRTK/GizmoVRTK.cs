using UnityEngine;
using VRTK.GrabAttachMechanics;
using VRTK.SecondaryControllerGrabActions;

namespace DV.CabControls.VRTK
{
	public class GizmoVRTK : GizmoBase, IInteractionStyleTarget
	{
		public VRTK_ControlImplBaseInteractableObject Interactable { get; private set; }

		public Transform GrabAnchorLeft { get; private set; }

		public Transform GrabAnchorRight { get; private set; }

		protected override void Awake()
		{
			base.Awake();
			Interactable = base.gameObject.AddComponent<VRTK_ControlImplBaseInteractableObject>();
			Interactable.isGrabbable = true;
			Interactable.InteractableObjectGrabbed += delegate
			{
				FireGrabbed();
			};
			Interactable.InteractableObjectUngrabbed += delegate
			{
				FireUngrabbed();
			};
			Interactable.priority = 0;
			Interactable.pipaExclusiveInteraction = false;
			Interactable.controlImplBase = this;
			Interactable.interactionHandPoses = GenerateHandPoses();
			(Interactable.grabAttachMechanicScript = base.gameObject.AddComponent<VRTK_ChildOfControllerGrabAttach>()).precisionGrab = spec.precisionGrab;
			Interactable.secondaryGrabActionScript = base.gameObject.AddComponent<VRTK_SwapControllerGrabAction>();
			SetupAttachPoint(Interactable.grabAttachMechanicScript);
			base.InteractionAllowedChanged += delegate(bool val)
			{
				Interactable.isGrabbable = val;
			};
			if (spec.telegrabbable)
			{
				TelegrabbableGizmo telegrabbableGizmo = Telegrabbable.MakeTelegrabbable<TelegrabbableGizmo>(base.gameObject);
				telegrabbableGizmo.gizmo = this;
				telegrabbableGizmo.rb = GetComponent<Rigidbody>();
			}
		}

		private void SetupAttachPoint(VRTK_BaseGrabAttach attach)
		{
			Transform transform = base.transform.Find("[anchor]");
			Transform transform2 = base.transform.Find("[left anchor]");
			Transform transform3 = base.transform.Find("[right anchor]");
			if ((bool)transform2 && (bool)transform3)
			{
				if (!attach.precisionGrab)
				{
					attach.leftSnapHandle = transform2;
					attach.rightSnapHandle = transform3;
				}
				GrabAnchorLeft = transform2;
				GrabAnchorRight = transform3;
			}
			else if ((bool)transform)
			{
				if (!attach.precisionGrab)
				{
					attach.leftSnapHandle = transform;
					attach.rightSnapHandle = transform;
				}
				GrabAnchorLeft = transform;
				GrabAnchorRight = transform;
			}
		}

		public override bool IsGrabbed()
		{
			return Interactable.IsGrabbed();
		}

		protected override void AcceptSetValue(float newValue)
		{
			Debug.Log("GizmoVRTK doesn't support setting value", this);
		}

		public override void ForceEndInteraction()
		{
			Interactable.ForceStopInteracting();
		}
	}
}
