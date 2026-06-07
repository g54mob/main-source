using DV.CabControls;
using DV.VRTK_Extensions;

namespace DV.VR
{
	public class TelegrabbableUseControl : TelegrabbableInteractionTarget
	{
		public override void StartInteraction(TelegrabInteractionHandler handler)
		{
			base.StartInteraction(handler);
			GetComponent<ControlImplBase>().Use();
			HapticUtils.DoHapticPulse(handler.ControllerReference, HapticIntensityType.Normal);
		}
	}
}
