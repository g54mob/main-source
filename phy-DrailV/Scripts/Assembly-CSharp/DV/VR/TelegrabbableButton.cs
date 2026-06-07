using DV.CabControls.VRTK;
using DV.Interaction;
using DV.VRTK_Extensions;

namespace DV.VR
{
	public class TelegrabbableButton : TelegrabbableInteractionTarget
	{
		private ButtonVRTK button;

		protected override void Start()
		{
			base.Start();
			button = GetComponent<ButtonVRTK>();
			base.enabled = false;
		}

		private void Update()
		{
			SetHighlight(on: true);
		}

		public override void StartInteraction(TelegrabInteractionHandler handler)
		{
			base.StartInteraction(handler);
			button.Use();
			base.enabled = true;
			HapticUtils.DoHapticPulse(handler.ControllerReference, HapticIntensityType.Normal);
			if (button.IsHoldMode)
			{
				handler.FakeInteractableObjectProvider.GrabFakeObject(HandPose.Point);
			}
		}

		public override void StopInteraction(TelegrabInteractionHandler handler)
		{
			base.StopInteraction(handler);
			SetHighlight(on: false);
			base.enabled = false;
			if (button.IsHoldMode && button.IsOn)
			{
				button.Use();
				HapticUtils.DoHapticPulse(handler.ControllerReference, HapticIntensityType.Weak);
				handler.FakeInteractableObjectProvider.UngrabFakeObject();
			}
		}
	}
}
