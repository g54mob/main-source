namespace Gh.Tk
{
	public class DrinkBehaviour : PatronBehaviour, IAiComponentVisualInfo, IAiComponentIsDoneInfo
	{
		public DrinkBehaviour()
		{
		}

		public DrinkBehaviour(Patron owner)
		{
		}

		public override void Init()
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
