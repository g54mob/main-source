using System;
using UnityEngine;

namespace MoreMountains.Tools
{
	public struct MMStateChangeEvent<T> where T : struct, IComparable, IConvertible, IFormattable
	{
		public GameObject Target;

		public MMStateMachine<T> TargetStateMachine;

		public T NewState;

		public T PreviousState;

		public MMStateChangeEvent(MMStateMachine<T> stateMachine)
		{
			Target = stateMachine.Target;
			TargetStateMachine = stateMachine;
			NewState = stateMachine.CurrentState;
			PreviousState = stateMachine.PreviousState;
		}
	}
}
