using UnityEngine;

namespace LaundryBear
{
	public abstract class State<TStateEnum, TTransitionEnum, TOwner> : ScriptableObject where TOwner : Object
	{
		public abstract TStateEnum GetEnum();

		public virtual void UpdateState(TOwner owner, object userData)
		{
		}

		public abstract bool CanTransition(TTransitionEnum transition);

		public abstract TStateEnum HandleTransition(TTransitionEnum transition);

		public virtual void OnEnterState(TStateEnum previousState, TOwner owner, object userData)
		{
		}

		public virtual void OnExitState(TOwner owner, object userData)
		{
		}

		public virtual void FixedUpdateState(TOwner owner, object userData)
		{
		}

		public virtual void OnOwnerAnimatorMove(TOwner owner, object userData)
		{
		}

		public virtual void OnOwnerAnimatorIK(TOwner owner, object userData)
		{
		}

		public virtual void LateUpdateState(TOwner owner, object userData)
		{
		}
	}
}
