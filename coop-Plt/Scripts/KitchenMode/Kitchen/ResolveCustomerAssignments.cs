using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(CustomerAssignmentGroup), OrderLast = true)]
	public class ResolveCustomerAssignments : GameSystemBase
	{
		private EntityQuery Locations;

		private EntityQuery Groups;

		private EntityQuery HostStands;

		private SystemReferenceCache<IWaitingGroupSystem> GroupSystemCache;

		private SystemReferenceCache<IAssignmentSystem> AssignmentSystemCache;

		private readonly List<bool> _TrueFalse = new List<bool> { true, false };

		protected override void Initialise()
		{
			base.Initialise();
			Groups = GetEntityQuery(typeof(CWaitingGroup));
			HostStands = GetEntityQuery(typeof(CApplianceHostStand), typeof(CPathable));
			Locations = GetEntityQuery(typeof(CAvailableAssignment));
		}

		public override void PostInitialisation()
		{
			base.PostInitialisation();
			GroupSystemCache = new SystemReferenceCache<IWaitingGroupSystem>(base.World);
			AssignmentSystemCache = new SystemReferenceCache<IAssignmentSystem>(base.World);
		}

		protected override void OnUpdate()
		{
			using NativeArray<CAvailableAssignment> array = Locations.ToComponentDataArray<CAvailableAssignment>(Allocator.Temp);
			using NativeArray<CWaitingGroup> array2 = Groups.ToComponentDataArray<CWaitingGroup>(Allocator.Temp);
			array2.Sort(default(GroupComparer));
			array.Sort(default(LocationComparer));
			EntityContext ctx = new EntityContext(base.EntityManager);
			bool flag = !HostStands.IsEmpty;
			bool flag2 = false;
			foreach (bool item in _TrueFalse)
			{
				foreach (CWaitingGroup item2 in array2)
				{
					if (flag2)
					{
						break;
					}
					foreach (CAvailableAssignment item3 in array)
					{
						if ((!flag || item3.State != GroupState.FullTable || item2.IsUrgent || !(item2.ForceLocation == default(Entity))) && (!item || (item3.PrioritiseExactSize && item2.MemberCount == item3.MaxCapacity)) && item3.CanFit(item2) && item2.WillMoveTo(item3))
						{
							MakeAssignment(item3, item2, ctx);
							flag2 = true;
							break;
						}
					}
				}
			}
		}

		protected void MakeAssignment(CAvailableAssignment assignment, CWaitingGroup group, EntityContext ctx)
		{
			if (group.State == GroupState.Queue && !HasStatus(RestaurantStatus.NoQueueReset))
			{
				Entity entity = ctx.CreateEntity();
				ctx.Set(entity, new UpdateQueuePatience.CQueuePatienceBoost
				{
					Seconds = base.Data.Difficulty.QueuePatienceBoost
				});
			}
			if (AssignmentSystemCache.Get(assignment.System, out var system) && GroupSystemCache.Get(group.System, out var system2))
			{
				if (Has<CQueuePosition>(group))
				{
					ctx.Remove<CQueuePosition>(group);
				}
				if (Has<CGroupAtWaitingTable>(group))
				{
					ctx.Remove<CGroupAtWaitingTable>(group);
				}
				if (Has<CGroupWaitingForTable>(group))
				{
					ctx.Remove<CGroupWaitingForTable>(group);
				}
				if (Require<CAssignedTable>((Entity)group, out CAssignedTable comp))
				{
					ctx.Remove<COccupiedByGroup>(comp);
					ctx.Remove<CAssignedTable>(group);
				}
				if (Require<CAssignedStand>((Entity)group, out CAssignedStand comp2))
				{
					ctx.Remove<COccupiedByGroup>(comp2);
					ctx.Remove<CAssignedStand>(group);
				}
				if (Require<CAssignedMenu>((Entity)group, out CAssignedMenu comp3))
				{
					ctx.Destroy(comp3);
					ctx.Remove<CAssignedMenu>(group);
				}
				if (assignment.State == GroupState.FullTable)
				{
					ctx.Remove<CGroupQueue>(group);
				}
				system2.Accept(assignment, group, ctx);
				system.Accept(assignment, group, ctx);
				ctx.Add<CGroupStateChanged>(group);
				ctx.Add<CUpdateGroupInstruction>(group);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
