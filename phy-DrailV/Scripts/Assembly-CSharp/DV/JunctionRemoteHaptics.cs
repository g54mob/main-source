using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV
{
	public class JunctionRemoteHaptics : MonoBehaviour
	{
		private const float USE_HAPTIC_STRENGTH = 0.4f;

		private JunctionRemoteLogic remoteLogic;

		private VRTK_InteractableObject interactable;

		private CommsJunctionSwitcher switcher;

		private void Start()
		{
			remoteLogic = GetComponent<JunctionRemoteLogic>();
			interactable = GetComponentInParent<VRTK_InteractableObject>();
			switcher = GetComponent<CommsJunctionSwitcher>();
			if (remoteLogic == null || interactable == null)
			{
				Debug.LogError("Couldn't extract JunctionRemoteLogic or VRTK_InteractableObject. Destroying self!", this);
				Object.Destroy(this);
			}
			else
			{
				SetupListeners(on: true);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				interactable.InteractableObjectUsed += OnUsed;
				switcher.JunctionHovered += OnHovered;
			}
			else
			{
				interactable.InteractableObjectUsed -= OnUsed;
				switcher.JunctionHovered -= OnHovered;
			}
		}

		private void OnHovered(JunctionSwitchRemoteControllable junction)
		{
			HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(interactable.GetGrabbingObject()), HapticIntensityType.Normal);
		}

		private void OnUsed(object sender, InteractableObjectEventArgs e)
		{
			if (remoteLogic.IsPointingToSwitch())
			{
				HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(e.interactingObject), HapticIntensityType.Normal);
			}
		}
	}
}
