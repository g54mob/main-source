namespace Gh.Tk
{
	public class SeekCounsellingBehaviour : PatronBehaviour, IAiComponentVisualInfo, IAiComponentIsDoneInfo
	{
		protected SeekCounsellingBehaviour()
		{
		}

		public SeekCounsellingBehaviour(Patron owner)
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
