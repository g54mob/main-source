using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_MoveLegTowards : MonoBehaviour
	{
		public LegsAnimator LegsAnim;

		public int LegIndex;

		public Transform Target;

		[Space(5f)]
		public bool Apply = true;

		public void SwitchUse()
		{
			Apply = !Apply;
		}

		private void Update()
		{
			if (!(LegsAnim == null))
			{
				if (Target == null)
				{
					Apply = false;
				}
				if (!Apply)
				{
					LegsAnim.User_MoveLegTo_Restore(LegIndex);
				}
				else
				{
					LegsAnim.User_MoveLegTo(LegIndex, Target);
				}
			}
		}
	}
}
