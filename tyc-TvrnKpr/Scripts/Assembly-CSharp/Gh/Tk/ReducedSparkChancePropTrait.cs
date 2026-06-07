namespace Gh.Tk
{
	public class ReducedSparkChancePropTrait : PropTraitBase
	{
		[PersistenceOptIn]
		public int Uses { get; set; }

		protected ReducedSparkChancePropTrait()
		{
		}

		public ReducedSparkChancePropTrait(Prop owner)
		{
		}
	}
}
