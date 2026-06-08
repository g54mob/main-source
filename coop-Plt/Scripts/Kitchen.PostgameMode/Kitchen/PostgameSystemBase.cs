namespace Kitchen
{
	public abstract class PostgameSystemBase : GenericSystemBase
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SPostgameMarker>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
