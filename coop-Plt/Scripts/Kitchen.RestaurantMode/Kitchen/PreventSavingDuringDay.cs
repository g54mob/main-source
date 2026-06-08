namespace Kitchen
{
	public class PreventSavingDuringDay : RestaurantSystem
	{
		protected override void OnUpdate()
		{
			if (Has<SIsDayTime>())
			{
				Set<SPreventSaving>();
			}
			else
			{
				Clear<SPreventSaving>();
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
