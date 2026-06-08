namespace Kitchen
{
	public class CreateRerollCostTracker : GameSystemBase
	{
		protected override void OnUpdate()
		{
			if (!HasSingleton<SRerollCost>())
			{
				Set(new SRerollCost
				{
					Cost = 10
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
