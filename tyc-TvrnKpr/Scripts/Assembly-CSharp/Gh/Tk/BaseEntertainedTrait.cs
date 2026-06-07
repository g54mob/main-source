namespace Gh.Tk
{
	public abstract class BaseEntertainedTrait : ActorTrait
	{
		protected abstract string CodexTooltipName { get; }

		protected abstract float PatronPatienceChangePerHour { get; }

		protected abstract float StaffWorkSpeedModifier { get; }

		protected abstract float StaffMoveSpeedModifier { get; }

		protected BaseEntertainedTrait()
		{
		}

		public BaseEntertainedTrait(Actor owner)
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}
	}
}
