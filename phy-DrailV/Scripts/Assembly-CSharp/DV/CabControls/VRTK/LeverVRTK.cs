using DV.Interaction;
using DV.VR;

namespace DV.CabControls.VRTK
{
	public class LeverVRTK : LeverBase, IGrabPoseProvider
	{
		private VRTK_ControlImplBaseInteractableObject interactable;

		public HandPose GrabPose => interactable.interactionHandPoses.grabPose;

		protected override void Awake()
		{
			base.Awake();
			interactable = base.gameObject.AddComponent<VRTK_ControlImplBaseInteractableObject>();
			interactable.isGrabbable = true;
			interactable.priority = 1;
			interactable.pipaExclusiveInteraction = false;
			interactable.controlImplBase = this;
			interactable.interactionHandPoses = GenerateHandPoses();
			interactable.InteractableObjectGrabbed += delegate
			{
				FireGrabbed();
			};
			interactable.InteractableObjectUngrabbed += delegate
			{
				FireUngrabbed();
			};
			VRTK_RotatorTrackGrabAttachLimitedForce vRTK_RotatorTrackGrabAttachLimitedForce = base.gameObject.AddComponent<VRTK_RotatorTrackGrabAttachLimitedForce>();
			vRTK_RotatorTrackGrabAttachLimitedForce.maxForceMagnitude = spec.maxForceAppliedMagnitude;
			vRTK_RotatorTrackGrabAttachLimitedForce.forceMultiplier = spec.pullingForceMultiplier;
			vRTK_RotatorTrackGrabAttachLimitedForce.leftSnapHandle = spec.interactionPoint;
			vRTK_RotatorTrackGrabAttachLimitedForce.rightSnapHandle = spec.interactionPoint;
			interactable.grabAttachMechanicScript = vRTK_RotatorTrackGrabAttachLimitedForce;
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
