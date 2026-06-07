using DV.VR;
using VRTK.GrabAttachMechanics;

namespace DV.CabControls.VRTK
{
	public class RotaryVRTK : RotaryBase
	{
		private VRTK_ControlImplBaseInteractableObject interactable;

		protected override void Awake()
		{
			base.Awake();
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
			interactable.priority = 1;
			interactable.pipaExclusiveInteraction = false;
			interactable.controlImplBase = this;
			interactable.interactionHandPoses = GenerateHandPoses();
			VRTK_TrackObjectGrabAttach vRTK_TrackObjectGrabAttach = base.gameObject.AddComponent<VRTK_TrackObjectGrabAttach>();
			vRTK_TrackObjectGrabAttach.precisionGrab = true;
			vRTK_TrackObjectGrabAttach.velocityLimit = 0f;
			interactable.grabAttachMechanicScript = vRTK_TrackObjectGrabAttach;
			TelegrabbableTwistScroller telegrabbableTwistScroller = base.gameObject.AddComponent<TelegrabbableTwistScroller>();
			telegrabbableTwistScroller.localAxis = base.Spec.jointAxis;
			telegrabbableTwistScroller.flipScrollDirection = base.Spec.scrollWheelHoverScroll < 0f;
			if (base.Spec.IsNotched)
			{
				float num = (base.Spec.useLimits ? (base.Spec.jointLimitMax - base.Spec.jointLimitMin) : 360f);
				telegrabbableTwistScroller.anglePerScroll = num / (float)base.Spec.notches;
			}
			else
			{
				telegrabbableTwistScroller.anglePerScroll = 22.5f;
			}
		}

		public override bool IsGrabbed()
		{
			if ((bool)interactable)
			{
				return interactable.IsGrabbed();
			}
			return false;
		}

		public override void ForceEndInteraction()
		{
			interactable.ForceStopInteracting();
		}
	}
}
