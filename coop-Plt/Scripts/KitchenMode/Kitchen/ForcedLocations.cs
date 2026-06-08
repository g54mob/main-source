using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ForcedLocations : AssignmentSystem
	{
		private EntityQuery WaitingGroups;

		protected override void Initialise()
		{
			base.Initialise();
			WaitingGroups = GetEntityQuery(typeof(CWaitingGroup));
		}

		protected override void OnUpdate()
		{
			using NativeArray<CWaitingGroup> nativeArray = WaitingGroups.ToComponentDataArray<CWaitingGroup>(Allocator.Temp);
			foreach (CWaitingGroup item in nativeArray)
			{
				if (!(item.ForceLocation == default(Entity)) && Require<CTableSet>(item.ForceLocation, out CTableSet comp))
				{
					NewAssignment(new CAvailableAssignment
					{
						Entity = item.ForceLocation,
						MaxCapacity = comp.ChairCount,
						PrioritiseExactSize = Has<CTablePrioritiseCorrectGroups>(item.ForceLocation),
						State = (comp.IsWaitingTable ? GroupState.WaitingTable : GroupState.FullTable)
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
			ctx.Set(group, new CAssignedTable
			{
				Table = assignment.Entity
			});
			ctx.Add<CGroupGoingToTable>(group);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
