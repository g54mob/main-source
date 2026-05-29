using UnityEngine;

namespace Animancer.FSM
{
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer.FSM/StateBehaviour")]
	public abstract class StateBehaviour : MonoBehaviour, IState
	{
		public virtual bool CanEnterState => true;

		public virtual bool CanExitState => true;

		public virtual void OnEnterState()
		{
			base.enabled = true;
		}

		public virtual void OnExitState()
		{
			if (!(this == null))
			{
				base.enabled = false;
			}
		}
	}
}
