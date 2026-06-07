namespace Gh.Tk
{
	public class AbortOrderBehaviour : PatronBehaviour
	{
		protected AbortOrderBehaviour()
		{
		}

		public AbortOrderBehaviour(Patron owner)
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
