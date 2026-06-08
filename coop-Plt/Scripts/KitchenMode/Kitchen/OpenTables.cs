using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class OpenTables : AssignmentSystem
	{
		private EntityQuery FreeTablesQuery;

		protected override void Initialise()
		{
			base.Initialise();
			FreeTablesQuery = GetEntityQuery(new EntityQueryDesc
			{
				All = new ComponentType[1] { typeof(CTableSet) },
				None = new ComponentType[1] { typeof(COccupiedByGroup) }
			});
			RequireForUpdate(FreeTablesQuery);
		}

		protected override void OnUpdate()
		{
			using NativeArray<Entity> nativeArray = FreeTablesQuery.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				if (HasComponent<CTableReadyForCustomers>(item) && !HasComponent<COccupiedByGroup>(item))
				{
					bool isWaitingTable = GetComponent<CTableSet>(item).IsWaitingTable;
					int length = GetBuffer<CTablePlace>(item).Length;
					float attractiveness = GetComponent<CTableSetModifier>(item).Attractiveness;
					NewAssignment(new CAvailableAssignment
					{
						Entity = item,
						Attractiveness = attractiveness,
						MaxCapacity = length,
						PrioritiseExactSize = Has<CTablePrioritiseCorrectGroups>(item),
						State = (isWaitingTable ? GroupState.WaitingTable : GroupState.FullTable)
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
