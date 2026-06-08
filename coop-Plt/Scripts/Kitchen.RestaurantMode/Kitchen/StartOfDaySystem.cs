namespace Kitchen
{
	public abstract class StartOfDaySystem : DaySystem
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SIsDayFirstUpdate>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
