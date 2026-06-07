namespace Gh.Tk
{
	[TraitRarityConfig(0.3f, "elf")]
	[TraitRarityConfig(0.01f, null)]
	public class MentalBreakLethargicTrait : MentalBreakTraitBase
	{
		protected MentalBreakLethargicTrait()
		{
		}

		public MentalBreakLethargicTrait(Staff owner)
		{
		}

		public override bool IsCatharsisActive()
		{
			return false;
		}

		protected override void TriggerInternal()
		{
		}
	}
}
