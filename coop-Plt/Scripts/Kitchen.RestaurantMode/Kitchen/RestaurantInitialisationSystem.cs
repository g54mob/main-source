namespace Kitchen
{
	public abstract class RestaurantInitialisationSystem : GameSystemBase
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<CreateNewKitchen.SKitchenFirstFrame>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
