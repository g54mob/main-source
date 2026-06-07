using System;
using DV.UIFramework;

namespace DV.UI
{
	public abstract class ATutorialsMenuProvider : NullCheckingMonoBehaviour
	{
		[Serializable]
		public struct Data
		{
			public bool de2Passed;

			public bool de6Passed;

			public bool dh4Passed;

			public bool dm3Passed;

			public bool s282aPassed;

			public bool s060Passed;

			public bool microshunterPassed;

			public bool dm1uPassed;

			public bool isPlayerOnLocoThatSupportsQuickTutorial;

			public bool isQuickTutorialRunning;
		}

		public abstract Data GetData();

		public abstract void SetData(Data data);

		public abstract void AbortCurrentQuickTutorial();

		public abstract void RunCouplingTutorial();

		public abstract void RunLocoTutorial();

		public abstract bool IsQuickTutorialUserControlAllowed();

		public abstract bool IsMetaTutorialHackActive();

		public abstract bool IsQuickTutorialRunning();
	}
}
