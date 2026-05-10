using UnityEngine;

namespace PG
{
	public class LookAtTransform : MonoBehaviour
	{
		[SerializeField]
		private Transform TargetTransform;

		[SerializeField]
		private Vector3 LocalPositionOffset;

		[SerializeField]
		private Vector3 RotationOffset;

		private Transform ParentTransform;

		private void LateUpdate()
		{
		}
	}
}
