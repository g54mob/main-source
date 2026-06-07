using System;

namespace Assets.Nimbatus.Scripts.Tutorial
{
	[Serializable]
	public class TutorialState
	{
		public ETutorialType TutorialType;

		public bool IsCompleted;

		public TutorialState()
		{
		}

		public TutorialState(ETutorialType t, bool completed)
		{
			TutorialType = t;
			IsCompleted = completed;
		}
	}
}
