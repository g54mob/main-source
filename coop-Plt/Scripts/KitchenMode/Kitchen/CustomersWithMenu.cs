using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(ForcedLocations))]
	public class CustomersWithMenu : WaitingGroupSystem
	{
		private EntityQuery MenusQuery;

		protected override void Initialise()
		{
			base.Initialise();
			MenusQuery = GetEntityQuery(new QueryHelper().All(typeof(CAssignedMenu)));
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = MenusQuery.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (Require<CAssignedMenu>(item, out CAssignedMenu comp) && Require<CMenu>((Entity)comp, out CMenu _) && Require<CHeldBy>((Entity)comp, out CHeldBy comp3) && Require<CPartOfTableSet>((Entity)comp3, out CPartOfTableSet comp4) && Require<CTableSet>((Entity)comp4, out CTableSet comp5) && !comp5.IsWaitingTable && !Has<COccupiedByGroup>(comp4) && Require<CPatience>(item, out CPatience comp6) && RequireBuffer(item, out DynamicBuffer<CGroupMember> comp7))
				{
					NewGroup(new CWaitingGroup
					{
						Group = item,
						MemberCount = comp7.Length,
						State = GroupState.HostStand,
						IsUrgent = (comp6.RemainingTime < 0.1f),
						PatienceRemaining = comp6.RemainingTime,
						ForceLocation = comp4
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
