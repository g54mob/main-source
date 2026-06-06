using System;

namespace MalbersAnimations.Controller.AI
{
	[Serializable]
	public class MAITransition
	{
		public MAIDecision decision;

		public MAIState trueState;

		public MAIState falseState;
	}
}
