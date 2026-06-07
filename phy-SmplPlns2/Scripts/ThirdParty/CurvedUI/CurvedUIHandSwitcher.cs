using UnityEngine;

namespace CurvedUI
{
	public class CurvedUIHandSwitcher : MonoBehaviour
	{
		[SerializeField]
		private GameObject LaserBeam;

		[SerializeField]
		[Tooltip("If true, when player clicks the trigger on the other hand, we'll instantly set it as UI controlling hand and move the pointer to it.")]
		private bool autoSwitchHands = true;

		[Header("Optional")]
		[SerializeField]
		[Tooltip("If set, pointer will be placed as a child of this transform, instead of the current VR SDKs Camera Rig.")]
		private Transform leftHandOverride;

		[SerializeField]
		[Tooltip("If set, pointer will be placed as a child of this transform, instead of the current VR SDKs Camera Rig.")]
		private Transform rightHandOverride;

		private void SwitchHandTo(CurvedUIInputModule.Hand newHand)
		{
			CurvedUIInputModule.Instance.UsedHand = newHand;
			if ((bool)CurvedUIInputModule.Instance.ControllerTransform)
			{
				if (newHand == CurvedUIInputModule.Hand.Left && (bool)leftHandOverride)
				{
					CurvedUIInputModule.Instance.PointerTransformOverride = leftHandOverride;
				}
				if (newHand == CurvedUIInputModule.Hand.Right && (bool)rightHandOverride)
				{
					CurvedUIInputModule.Instance.PointerTransformOverride = rightHandOverride;
				}
				LaserBeam.transform.SetParent(CurvedUIInputModule.Instance.ControllerTransform);
				LaserBeam.transform.ResetTransform();
				LaserBeam.transform.LookAt(LaserBeam.transform.position + CurvedUIInputModule.Instance.ControllerPointingDirection);
			}
			else
			{
				Debug.LogError("CURVEDUI: No Active controller that can be used as a parent of the pointer. Is the controller gameobject present on the scene and active?");
			}
		}
	}
}
