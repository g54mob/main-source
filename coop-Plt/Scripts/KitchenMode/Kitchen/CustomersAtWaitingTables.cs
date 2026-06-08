using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class CustomersAtWaitingTables : WaitingGroupSystem
	{
		private EntityQuery QueueGroupsQuery;

		protected override void Initialise()
		{
			base.Initialise();
			QueueGroupsQuery = GetEntityQuery(new QueryHelper().All(typeof(CCustomerGroup), typeof(CGroupPhaseQueue), typeof(CPatience)).Any(typeof(CGroupGoingToTable), typeof(CGroupAtWaitingTable)).None(typeof(CAssignedMenu)));
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = QueueGroupsQuery.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (Require<CPatience>(item, out CPatience comp) && RequireBuffer(item, out DynamicBuffer<CGroupMember> comp2))
				{
					NewGroup(new CWaitingGroup
					{
						Group = item,
						MemberCount = comp2.Length,
						State = GroupState.WaitingTable,
						IsUrgent = (comp.RemainingTime < 0.1f),
						PatienceRemaining = comp.RemainingTime
					});
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
