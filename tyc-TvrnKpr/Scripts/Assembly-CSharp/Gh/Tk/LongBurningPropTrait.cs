namespace Gh.Tk
{
	public class LongBurningPropTrait : PropTraitBase
	{
		[PersistenceOptIn]
		public int Uses { get; set; }

		protected LongBurningPropTrait()
		{
		}

		public LongBurningPropTrait(Prop owner)
		{
		}
	}
}
