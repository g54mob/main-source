using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_Scroller : MonoBehaviour
	{
		public Vector3 MoveDirection = Vector3.zero;

		public float RestartBelowX = -3f;

		public float MoveBackBy = 6f;

		private void Update()
		{
			if (base.transform.position.x < RestartBelowX)
			{
				base.transform.position -= MoveDirection.normalized * MoveBackBy;
			}
			base.transform.position += MoveDirection * Time.deltaTime;
		}
	}
}
