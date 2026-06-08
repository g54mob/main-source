using Unity.Entities;

namespace Kitchen
{
	public class DisableAutomaticAppliancesAtNight : RestaurantSystem
	{
		public EntityQuery Appliances;

		protected override void Initialise()
		{
			base.Initialise();
			Appliances = GetEntityQuery(typeof(CAppliance));
		}

		protected override void OnUpdate()
		{
			if (HasSingleton<SIsDayTime>())
			{
				base.EntityManager.RemoveComponent<CDisableAutomation>(Appliances);
			}
			else
			{
				base.EntityManager.AddComponent<CDisableAutomation>(Appliances);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
