using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.ThreeDimensional
{
	public class UIObject3DTimerComponent : MonoBehaviour
	{
		public List<DelayedAction> delayedActions;

		public void DelayedCall(float delay, Action action, MonoBehaviour target, bool forceEvenIfTargetIsInactive)
		{
		}

		private void Update()
		{
		}
	}
}
