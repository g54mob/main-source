using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class AnalyseCustomerSchedule : RestaurantSystem
	{
		private EntityQuery ScheduledCustomers;

		protected override void Initialise()
		{
			base.Initialise();
			ScheduledCustomers = GetEntityQuery(typeof(CScheduledCustomer));
		}

		protected override void OnUpdate()
		{
			SScheduleAnalysis t = default(SScheduleAnalysis);
			using NativeArray<Entity> nativeArray = ScheduledCustomers.ToEntityArray(Allocator.Temp);
			using NativeArray<CScheduledCustomer> nativeArray2 = ScheduledCustomers.ToComponentDataArray<CScheduledCustomer>(Allocator.Temp);
			t.MinGroupSize = 999;
			for (int i = 0; i < nativeArray2.Length; i++)
			{
				Entity e = nativeArray[i];
				CScheduledCustomer cScheduledCustomer = nativeArray2[i];
				t.MinGroupSize = Mathf.Min(t.MinGroupSize, cScheduledCustomer.GroupSize);
				t.MaxGroupSize = Mathf.Max(t.MaxGroupSize, cScheduledCustomer.GroupSize);
				t.TotalGroups++;
				t.TotalExtraGroups += (Has<CExtraScheduledCustomer>(e) ? 1 : 0);
			}
			Set(t);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
