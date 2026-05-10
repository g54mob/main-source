using UnityEngine;

namespace CTS
{
	public class WallFurnitureDetectionPoint : MonoBehaviour
	{
		private void Awake()
		{
			base.gameObject.layer = 8;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawRay(base.transform.position, base.transform.forward * 0.1f);
		}
	}
}
