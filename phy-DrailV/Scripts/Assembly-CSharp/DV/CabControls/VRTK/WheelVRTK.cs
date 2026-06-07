using DV.CabControls.Spec;
using DV.Interaction;
using DV.VR;

namespace DV.CabControls.VRTK
{
	public class WheelVRTK : WheelBase, IGrabPoseProvider
	{
		private VRTK_ControlImplBaseInteractableObject interactable;

		public HandPose GrabPose => interactable.interactionHandPoses.grabPose;

		protected override void Awake()
		{
			base.Awake();
			Wheel component = GetComponent<Wheel>();
			interactable = base.gameObject.AddComponent<VRTK_ControlImplBaseInteractableObject>();
			interactable.isGrabbable = true;
			interactable.priority = 0;
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
			vRTK_RotatorTrackGrabAttachLimitedForce.precisionGrab = true;
			vRTK_RotatorTrackGrabAttachLimitedForce.maxForceMagnitude = component.rotatorMaxForceMagnitude;
			if (component.useHaptics)
			{
				WheelRotatorHaptics wheelRotatorHaptics = base.gameObject.AddComponent<WheelRotatorHaptics>();
				wheelRotatorHaptics.notchAngle = component.notchAngle;
				diffThreshold = component.notchAngle;
				wheelRotatorHaptics.enableWhenTouching = component.enableWhenTouching;
			}
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
