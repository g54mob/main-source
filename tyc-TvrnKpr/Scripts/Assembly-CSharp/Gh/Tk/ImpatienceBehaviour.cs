namespace Gh.Tk
{
	public class ImpatienceBehaviour : PatronBehaviour
	{
		private PatienceStat _patienceStat;

		protected ImpatienceBehaviour()
		{
		}

		public ImpatienceBehaviour(Patron owner)
		{
		}

		public override void Init()
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public static bool TriggerOutOfPatience(Patron patron, bool logRanOutOfPatienceSatisfaction, bool disableHotHeadReaction = false)
		{
			return false;
		}
	}
}
