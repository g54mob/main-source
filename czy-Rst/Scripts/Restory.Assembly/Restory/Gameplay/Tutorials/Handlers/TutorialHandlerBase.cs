using System;
using Restory.Data.Tutorials;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public abstract class TutorialHandlerBase
	{
		public readonly TutorialBase Tutorial;

		protected bool IsCompleted { get; private set; }

		public event Action<TutorialHandlerBase> OnTutorialComplete;

		protected TutorialHandlerBase(TutorialBase tutorial)
		{
			Tutorial = tutorial;
		}

		public abstract void Init();

		public abstract void Cleanup();

		protected void CompleteTutorial()
		{
			if (!IsCompleted)
			{
				IsCompleted = true;
				this.OnTutorialComplete?.Invoke(this);
			}
		}
	}
}
