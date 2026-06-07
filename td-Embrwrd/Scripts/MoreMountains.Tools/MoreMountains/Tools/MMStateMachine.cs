using System;
using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMStateMachine<T> : MMIStateMachine where T : struct, IComparable, IConvertible, IFormattable
	{
		public delegate void OnStateChangeDelegate();

		public GameObject Target;

		public OnStateChangeDelegate OnStateChange;

		public bool TriggerEvents { get; set; }

		public T CurrentState { get; protected set; }

		public T PreviousState { get; protected set; }

		public MMStateMachine(GameObject target, bool triggerEvents)
		{
		}

		public virtual void ChangeState(T newState)
		{
		}

		public virtual void RestorePreviousState()
		{
		}
	}
}
