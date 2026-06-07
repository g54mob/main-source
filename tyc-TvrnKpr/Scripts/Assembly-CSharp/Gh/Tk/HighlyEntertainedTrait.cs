using System;

namespace Gh.Tk
{
	[TraitNotValidWith(new Type[] { typeof(EntertainedTrait) })]
	public class HighlyEntertainedTrait : BaseEntertainedTrait
	{
		protected override string CodexTooltipName => null;

		protected override float PatronPatienceChangePerHour => 0f;

		protected override float StaffWorkSpeedModifier => 0f;

		protected override float StaffMoveSpeedModifier => 0f;

		protected HighlyEntertainedTrait()
		{
		}

		public HighlyEntertainedTrait(Actor owner)
		{
		}
	}
}
