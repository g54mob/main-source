namespace Kitchen
{
	public abstract class GameOverSystem : RestaurantSystem
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SGameOver>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
