using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_Legsanim_SetDesiredMoveDir : MonoBehaviour
	{
		public LegsAnimator LegsAnim;

		public Vector3 Direction = Vector3.zero;

		private void Update()
		{
			LegsAnim.User_SetDesiredMovementDirection(Direction);
		}
	}
}
