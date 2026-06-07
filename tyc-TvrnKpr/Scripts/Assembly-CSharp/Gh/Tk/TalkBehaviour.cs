using System.Collections.Generic;

namespace Gh.Tk
{
	public class TalkBehaviour : PatronBehaviour
	{
		[PersistenceOptIn]
		private float _nextTalking;

		private static float _maxTalkDistanceSquared;

		protected TalkBehaviour()
		{
		}

		public TalkBehaviour(Patron owner)
		{
		}

		public void TalkNow()
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		private List<Patron> GetTalkPartners()
		{
			return null;
		}
	}
}
