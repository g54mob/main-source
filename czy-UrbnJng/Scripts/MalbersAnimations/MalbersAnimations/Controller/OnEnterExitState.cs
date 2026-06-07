using System;
using UnityEngine.Events;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class OnEnterExitState
	{
		public StateID ID;

		public UnityEvent OnEnter;

		public UnityEvent OnExit;
	}
}
