using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateCustomerSchedule))]
	[UpdateInGroup(typeof(CustomerSchedulingGroup))]
	public class CustomersAreCats : RestaurantSystem
	{
		private EntityQuery ScheduledCustomers;

		protected override void Initialise()
		{
			base.Initialise();
			ScheduledCustomers = GetEntityQuery(typeof(CScheduledCustomer));
		}

		protected override void OnUpdate()
		{
			if (!Has<SRequireSchedulingUpdate>() || !HasStatus(RestaurantStatus.HalloweenTreatCustomersAreCats))
			{
				return;
			}
			using NativeArray<Entity> nativeArray = ScheduledCustomers.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (Require<CScheduledCustomer>(item, out CScheduledCustomer comp) && !comp.IsCat)
				{
					comp.IsCat = true;
					Set(item, comp);
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
