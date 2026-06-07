namespace Gh.Tk
{
	public class DryBehaviour : PatronBehaviour
	{
		private const float _cooldownDuration = 60f;

		private WetTrait _wetTrait;

		protected DryBehaviour()
		{
		}

		public DryBehaviour(Patron owner)
		{
		}

		public override bool IsTreshholdReached()
		{
			return false;
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
