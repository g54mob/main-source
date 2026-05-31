using UnityEngine;

namespace Gadd420
{
	public class IK : MonoBehaviour
	{
		public int chainLength;

		public Transform target;

		public Transform pole;

		public int iterations;

		[Header("Distance To Stop Calculations")]
		public float delta;

		[Range(0f, 1f)]
		public float snapBackStrength;

		public Vector3 extraRotation;

		public int rotationParentNumber;

		private float[] bonesLength;

		private float completeLength;

		private Transform[] bones;

		private Vector3[] positions;

		private Vector3[] startDirection;

		private Quaternion[] startRotationBone;

		private Quaternion startRotationTarget;

		private Transform root;

		[HideInInspector]
		public bool hasCrashed;

		private void Awake()
		{
		}

		private void Initialise()
		{
		}

		private void LateUpdate()
		{
		}

		private void DoIK()
		{
		}

		private Vector3 GetPositionRootSpace(Transform current)
		{
			return default(Vector3);
		}

		private void SetPositionRootSpace(Transform current, Vector3 position)
		{
		}

		private Quaternion GetRotationRootSpace(Transform current)
		{
			return default(Quaternion);
		}

		private void SetRotationRootSpace(Transform current, Quaternion rotation)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
