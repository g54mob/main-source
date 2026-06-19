using System;

namespace TH20
{
	public class ChallengeEvents : IGameEventsBase
	{
		public Action<Challenge> OnChallengeStarted;

		public Action<Challenge> OnChallengeCompleted;

		public Action<ChallengeVIP> OnChallengeVIPCompleted;

		public Action<Challenge> OnChallengeFinished;

		public ChallengeEvents()
		{
			GameEventsRegistry.RegisterLevelEvent(this);
		}

		public void VerifyEvents()
		{
			OnChallengeStarted.VerifyIsNull();
			OnChallengeCompleted.VerifyIsNull();
			OnChallengeVIPCompleted.VerifyIsNull();
			OnChallengeFinished.VerifyIsNull();
		}
	}
}
