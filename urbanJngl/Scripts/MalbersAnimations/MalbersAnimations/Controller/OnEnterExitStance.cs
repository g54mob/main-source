using System;
using UnityEngine.Events;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class OnEnterExitStance
	{
		public StanceID ID;

		public UnityEvent OnEnter;

		public UnityEvent OnExit;
	}
}
