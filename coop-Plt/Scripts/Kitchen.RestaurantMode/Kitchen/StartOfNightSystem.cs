namespace Kitchen
{
	public abstract class StartOfNightSystem : NightSystem
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SIsNightFirstUpdate>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
