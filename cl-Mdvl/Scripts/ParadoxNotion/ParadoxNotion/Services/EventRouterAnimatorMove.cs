using UnityEngine;

namespace ParadoxNotion.Services
{
	public class EventRouterAnimatorMove : MonoBehaviour
	{
		public event EventRouter.EventDelegate onAnimatorMove;

		private void OnAnimatorMove()
		{
			if (this.onAnimatorMove != null)
			{
				this.onAnimatorMove(new EventData(base.gameObject, this));
			}
		}
	}
}
