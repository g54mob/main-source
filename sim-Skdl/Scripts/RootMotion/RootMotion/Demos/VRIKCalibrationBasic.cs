using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class VRIKCalibrationBasic : MonoBehaviour
	{
		[Tooltip("The VRIK component.")]
		public VRIK ik;

		[Tooltip("HMD.")]
		[Header("Head")]
		public Transform centerEyeAnchor;

		[Tooltip("Position offset of the camera from the head bone (root space).")]
		public Vector3 headAnchorPositionOffset;

		[Tooltip("Rotation offset of the camera from the head bone (root space).")]
		public Vector3 headAnchorRotationOffset;

		[Tooltip("Left Hand Controller")]
		[Header("Hands")]
		public Transform leftHandAnchor;

		[Tooltip("Right Hand Controller")]
		public Transform rightHandAnchor;

		[Tooltip("Position offset of the hand controller from the hand bone (controller space).")]
		public Vector3 handAnchorPositionOffset;

		[Tooltip("Rotation offset of the hand controller from the hand bone (controller space).")]
		public Vector3 handAnchorRotationOffset;

		[Header("Scale")]
		[Tooltip("Multiplies the scale of the root.")]
		public float scaleMlp;

		[Header("Data stored by Calibration")]
		public VRIKCalibrator.CalibrationData data;

		private void LateUpdate()
		{
		}
	}
}
