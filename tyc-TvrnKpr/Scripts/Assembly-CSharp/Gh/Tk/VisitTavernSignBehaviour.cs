namespace Gh.Tk
{
	public class VisitTavernSignBehaviour : PatronBehaviour
	{
		protected VisitTavernSignBehaviour()
		{
		}

		public VisitTavernSignBehaviour(Patron owner)
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
