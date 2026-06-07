using DV.CabControls.Spec;
using DV.Interaction;
using DV.VR;
using VRTK.GrabAttachMechanics;

namespace DV.CabControls.VRTK
{
	public class PullerVRTK : PullerBase, IGrabPoseProvider
	{
		private VRTK_ControlImplBaseInteractableObject interactable;

		public HandPose GrabPose => interactable.interactionHandPoses.grabPose;

		protected override void Awake()
		{
			base.Awake();
			GetComponent<Puller>();
			interactable = base.gameObject.AddComponent<VRTK_ControlImplBaseInteractableObject>();
			interactable.isGrabbable = true;
			interactable.InteractableObjectGrabbed += delegate
			{
				FireGrabbed();
			};
			interactable.InteractableObjectUngrabbed += delegate
			{
				FireUngrabbed();
			};
			interactable.priority = 0;
			interactable.pipaExclusiveInteraction = false;
			interactable.controlImplBase = this;
			interactable.interactionHandPoses = GenerateHandPoses();
			VRTK_TrackObjectGrabAttach vRTK_TrackObjectGrabAttach = base.gameObject.AddComponent<VRTK_TrackObjectGrabAttach>();
			vRTK_TrackObjectGrabAttach.precisionGrab = true;
			interactable.grabAttachMechanicScript = vRTK_TrackObjectGrabAttach;
			base.gameObject.AddComponent<TelegrabbableGrabbable>();
		}

		public override bool IsGrabbed()
		{
			return interactable.IsGrabbed();
		}

		public override void ForceEndInteraction()
		{
			interactable.ForceStopInteracting();
		}
	}
}
