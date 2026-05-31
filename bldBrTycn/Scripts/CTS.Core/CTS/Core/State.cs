using UnityEngine;

namespace CTS.Core
{
	public abstract class State<T> where T : MonoBehaviour
	{
		protected T parent { get; private set; }

		protected FSM<T> fsm { get; private set; }

		internal void Init(T p_parent, FSM<T> p_fsm)
		{
			parent = p_parent;
			fsm = p_fsm;
		}

		public abstract void OnStateEnter();

		public abstract void OnStateExit();
	}
}
