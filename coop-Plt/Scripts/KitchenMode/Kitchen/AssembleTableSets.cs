using Kitchen.Layouts;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(TableUpdatesGroup))]
	public class AssembleTableSets : TableUpdateSystem
	{
		private EntityQuery TableSets;

		private EntityQuery AllInvalidTables;

		private EntityQuery AllUnassignedTables;

		protected override void Initialise()
		{
			base.Initialise();
			TableSets = GetEntityQuery(typeof(CTableSet));
			AllInvalidTables = GetEntityQuery(new EntityQueryDesc
			{
				All = new ComponentType[1] { typeof(CApplianceTable) },
				Any = new ComponentType[3]
				{
					typeof(CHeldBy),
					typeof(CDestroyApplianceAtDay),
					typeof(CForSale)
				}
			});
			AllUnassignedTables = GetEntityQuery(new EntityQueryDesc
			{
				All = new ComponentType[2]
				{
					typeof(CApplianceTable),
					typeof(CPosition)
				},
				None = new ComponentType[4]
				{
					typeof(CPartOfTableSet),
					typeof(CHeldBy),
					typeof(CForSale),
					typeof(CDestroyApplianceAtDay)
				}
			});
		}

		protected override void OnUpdate()
		{
			NativeArray<Entity> nativeArray = TableSets.ToEntityArray(Allocator.Temp);
			foreach (Entity item in nativeArray)
			{
				NativeArray<CTableSetParts> nativeArray2 = GetBuffer<CTableSetParts>(item).ToNativeArray(Allocator.Temp);
				foreach (CTableSetParts item2 in nativeArray2)
				{
					if (!HasComponent<CPartOfTableSet>(item2))
					{
						DestroySet(item);
						break;
					}
				}
				nativeArray2.Dispose();
			}
			nativeArray.Dispose();
			NativeArray<Entity> nativeArray3 = AllInvalidTables.ToEntityArray(Allocator.Temp);
			foreach (Entity item3 in nativeArray3)
			{
				RemoveFromSet(item3);
			}
			NativeArray<Entity> nativeArray4 = AllUnassignedTables.ToEntityArray(Allocator.Temp);
			foreach (Entity item4 in nativeArray4)
			{
				CAppliance component = GetComponent<CAppliance>(item4);
				CApplianceTable component2 = GetComponent<CApplianceTable>(item4);
				Entity set = CreateTableSet(item4, component2.IsWaitingTable, Has<CTablePrioritiseCorrectGroups>(item4));
				if (component2.IsIndividualTable)
				{
					continue;
				}
				CPosition component3 = GetComponent<CPosition>(item4);
				int room = base.TileManager.GetRoom(component3);
				foreach (LayoutPosition direction in LayoutHelpers.Directions)
				{
					Vector3 vector = component3 + new Vector3(direction.x, 0f, direction.y);
					if (room != base.TileManager.GetRoom(vector))
					{
						continue;
					}
					Entity occupant = base.TileManager.GetOccupant(vector);
					if (base.EntityManager.RequireComponent<CPartOfTableSet>(occupant, out var component4) && GetComponent<CAppliance>(occupant).ID == component.ID)
					{
						CApplianceTable component5 = GetComponent<CApplianceTable>(occupant);
						if (!component5.IsIndividualTable && component2.IsWaitingTable == component5.IsWaitingTable)
						{
							JoinTableSets(set, component4);
						}
					}
				}
			}
			nativeArray3.Dispose();
			nativeArray4.Dispose();
		}

		public Entity CreateTableSet(Entity base_table, bool waiting_table = false, bool is_prioritise_size_table = false)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CTableSet));
			SetComponent(entity, new CTableSet
			{
				IsWaitingTable = waiting_table
			});
			base.EntityManager.AddBuffer<CDirtItem>(entity);
			base.EntityManager.AddBuffer<CTableSetGrabPoints>(entity);
			base.EntityManager.AddBuffer<CTableAffectedBy>(entity);
			base.EntityManager.AddBuffer<CTablePlace>(entity);
			base.EntityManager.AddBuffer<CTableSetParts>(entity).Add(base_table);
			base.EntityManager.AddComponent<CPartOfTableSet>(base_table);
			SetComponent(base_table, new CPartOfTableSet
			{
				TableSet = entity
			});
			base.EntityManager.AddComponent<CPosition>(entity);
			SetComponent(entity, GetComponent<CPosition>(base_table));
			base.EntityManager.AddComponent<CTableSetModifier>(entity);
			if (is_prioritise_size_table)
			{
				Set<CTablePrioritiseCorrectGroups>(entity);
			}
			return entity;
		}

		protected void RemoveFromSet(Entity part)
		{
			if (base.EntityManager.RequireComponent<CPartOfTableSet>(part, out var component))
			{
				DestroySet(component);
			}
		}

		protected void DestroySet(Entity set)
		{
			NativeArray<CTableSetParts> nativeArray = GetBuffer<CTableSetParts>(set).ToNativeArray(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				base.EntityManager.RemoveComponent<CPartOfTableSet>(nativeArray[i]);
			}
			nativeArray.Dispose();
			base.EntityManager.DestroyEntity(set);
		}

		protected void JoinTableSets(Entity set1, Entity set2)
		{
			if (!(set1 == set2))
			{
				DynamicBuffer<CTableSetParts> buffer = GetBuffer<CTableSetParts>(set1);
				DynamicBuffer<CTableSetParts> buffer2 = GetBuffer<CTableSetParts>(set2);
				for (int i = 0; i < buffer2.Length; i++)
				{
					SetComponent(buffer2[i].Entity, new CPartOfTableSet
					{
						TableSet = set1
					});
					buffer.Add(buffer2[i]);
				}
				base.EntityManager.DestroyEntity(set2);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
