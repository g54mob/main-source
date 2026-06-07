using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_RotateAt : MonoBehaviour
	{
		public Transform ToRotate;

		public Transform LookAt;

		private void Update()
		{
			Vector3 position = LookAt.position;
			position.y = ToRotate.position.y;
			ToRotate.LookAt(position);
		}
	}
}
