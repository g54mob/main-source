namespace Kitchen
{
	public abstract class GameEffectSystemBase : GameSystemBase
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SRequireEffectUpdate>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
