namespace Kitchen
{
	public abstract class FranchiseBuilderSystem : GameSystemBase
	{
		public const int CardsForFranchise = 3;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SFranchiseBuilderMarker>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
