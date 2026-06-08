using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class OpenHostStands : AssignmentSystem
	{
		private EntityQuery HostStandsQuery;

		protected override void Initialise()
		{
			base.Initialise();
			HostStandsQuery = GetEntityQuery(new QueryHelper().All(typeof(CApplianceHostStand), typeof(CHostStandQueueLocation), typeof(CPathable)).None(typeof(COccupiedByGroup)));
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = HostStandsQuery.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (!HasComponent<COccupiedByGroup>(item))
				{
					NewAssignment(new CAvailableAssignment
					{
						Entity = item,
						MaxCapacity = -1,
						State = GroupState.HostStand
					});
				}
			}
		}

		public override void Accept(CAvailableAssignment assignment, CWaitingGroup group, EntityContext ctx)
		{
			ctx.Set(assignment.Entity, new COccupiedByGroup
			{
				Group = group
			});
			ctx.Set(group, new CAssignedStand
			{
				Stand = assignment.Entity
			});
			ctx.Add<CGroupWaitingForTable>(group);
			ctx.Set(group, GetComponent<CCustomerSettings>(group).NewPhase(PatienceReason.Seating));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
