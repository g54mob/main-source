using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Tools/Lock Axis")]
	public class LockAxis : MonoBehaviour
	{
		public bool LockX = true;

		public bool LockY;

		public bool LockZ;

		public Vector3 LockOffset;

		private void Update()
		{
			Vector3 position = base.transform.position;
			if (LockX)
			{
				position.x = LockOffset.x;
			}
			if (LockY)
			{
				position.y = LockOffset.y;
			}
			if (LockZ)
			{
				position.z = LockOffset.z;
			}
			base.transform.position = position;
		}
	}
}
