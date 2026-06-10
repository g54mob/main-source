using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ActionAnimation : NSEipix.Base.Model
	{
		[SerializeField]
		private string actionID;

		[SerializeField]
		private string animationTrigger;

		[SerializeField]
		private bool waitForAnimation;

		public string AnimationTrigger => animationTrigger;

		public bool WaitForAnimation => waitForAnimation;

		public override string GetID()
		{
			return actionID;
		}
	}
}
