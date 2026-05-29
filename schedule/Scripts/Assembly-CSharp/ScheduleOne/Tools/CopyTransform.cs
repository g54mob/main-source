using UnityEngine;

namespace ScheduleOne.Tools
{
	public class CopyTransform : MonoBehaviour
	{
		public enum EUpdateMode
		{
			Update = 0,
			LateUpdate = 1,
			FixedUpdate = 2
		}

		public Transform Target;

		public EUpdateMode UpdateMode;

		public bool CopyPosition;

		public bool CopyRotation;

		public bool CopyScale;

		public Vector3 GlobalPositionOffset;

		public Vector3 LocalPositionOffset;

		public Vector3 RotationOffset;

		private void FixedUpdate()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void Copy()
		{
		}
	}
}
