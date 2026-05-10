using UnityEngine;

namespace RootMotion.FinalIK
{
	[CreateAssetMenu(fileName = "Editor IK Pose", menuName = "Final IK/Editor IK Pose", order = 1)]
	public class EditorIKPose : ScriptableObject
	{
		public Vector3[] localPositions;

		public Quaternion[] localRotations;

		public bool xtb => false;

		public void kzu(Transform[] a)
		{
		}

		public bool kzv(Transform[] a)
		{
			return false;
		}
	}
}
