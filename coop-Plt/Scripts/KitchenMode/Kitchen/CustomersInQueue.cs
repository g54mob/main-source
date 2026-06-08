using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class CustomersInQueue : WaitingGroupSystem
	{
		private EntityQuery QueueGroupsQuery;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SQueueMarker_6;

		protected override void Initialise()
		{
			base.Initialise();
			QueueGroupsQuery = GetEntityQuery(new QueryHelper().All(typeof(CCustomerGroup), typeof(CGroupPhaseQueue), typeof(CPatience), typeof(CQueuePosition)).None(typeof(CAssignedMenu)));
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = QueueGroupsQuery.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (RequireBuffer(item, out DynamicBuffer<CGroupMember> comp) && Require<CQueuePosition>(item, out CQueuePosition comp2))
				{
					bool isUrgent = false;
					if (Has<SQueueMarker>())
					{
						isUrgent = Require<CPatience>(_SingletonEntityQuery_SQueueMarker_6.GetSingletonEntity(), out CPatience comp3) && comp3.StartTime != 0f && comp3.RemainingTime < 0.1f;
					}
					NewGroup(new CWaitingGroup
					{
						Group = item,
						MemberCount = comp.Length,
						State = GroupState.Queue,
						IsUrgent = isUrgent,
						PatienceRemaining = comp2.QueuePosition
					});
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SQueueMarker_6 = GetEntityQuery(ComponentType.ReadOnly<SQueueMarker>());
		}
	}
}
