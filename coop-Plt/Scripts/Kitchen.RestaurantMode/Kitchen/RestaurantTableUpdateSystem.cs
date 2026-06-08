namespace Kitchen
{
	public abstract class RestaurantTableUpdateSystem : RestaurantSystem
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SPerformTableUpdate>();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
