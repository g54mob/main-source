using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(TableUpdatesGroup), OrderFirst = true)]
	public class CreateChairs : RestaurantTableUpdateSystem
	{
		private EntityQuery Tables;

		private HashSet<Vector3> OccupiedSpaces;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPerformTableUpdate_60;

		protected override void Initialise()
		{
			base.Initialise();
			OccupiedSpaces = new HashSet<Vector3>();
			Tables = GetEntityQuery(new QueryHelper().All(typeof(CApplianceTable), typeof(CPosition)).None(typeof(CHeldAppliance)));
		}

		protected override void OnUpdate()
		{
			int ghostChair = AssetReference.GhostChair;
			int chair = AssetReference.Chair;
			NativeArray<Entity> nativeArray = Tables.ToEntityArray(Allocator.Temp);
			NativeArray<CApplianceTable> nativeArray2 = Tables.ToComponentDataArray<CApplianceTable>(Allocator.Temp);
			NativeArray<CPosition> nativeArray3 = Tables.ToComponentDataArray<CPosition>(Allocator.Temp);
			bool replaceWithDisabledGhosts = _SingletonEntityQuery_SPerformTableUpdate_60.GetSingleton<SPerformTableUpdate>().ReplaceWithDisabledGhosts;
			OccupiedSpaces.Clear();
			OccupiedSpaces.Add(GetFrontDoor());
			for (int i = 0; i < nativeArray2.Length; i++)
			{
				CApplianceTable cApplianceTable = nativeArray2[i];
				CPosition cPosition = nativeArray3[i];
				int room = base.TileManager.GetRoom(cPosition);
				Orientation[] all = OrientationHelpers.All;
				foreach (Orientation o in all)
				{
					Orientation o2 = cPosition.Rotation.RotateOrientation(o);
					if (cApplianceTable.PreventsSitting(o))
					{
						continue;
					}
					Vector3 vector = o2.ToOffset() + cPosition;
					if (OccupiedSpaces.Contains(vector) || room != base.TileManager.GetRoom(vector))
					{
						continue;
					}
					Entity occupant = base.TileManager.GetOccupant(vector);
					quaternion rotation = quaternion.LookRotation(vector - cPosition, new float3(0f, 1f, 0f));
					if (base.EntityManager.HasComponent<CGhostChairTableCandidates>(occupant))
					{
						DynamicBuffer<CGhostChairTableCandidates> buffer = GetBuffer<CGhostChairTableCandidates>(occupant);
						bool flag = false;
						foreach (CGhostChairTableCandidates item in buffer)
						{
							if (item.Table == nativeArray[i])
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							buffer.Add(new CGhostChairTableCandidates
							{
								Table = nativeArray[i],
								Rotation = rotation
							});
						}
					}
					if (occupant == default(Entity))
					{
						OccupiedSpaces.Add(vector);
						Entity entity = base.EntityManager.CreateEntity();
						base.EntityManager.AddComponentData(entity, new CCreateAppliance
						{
							ID = ghostChair
						});
						base.EntityManager.AddComponentData(entity, new CApplianceGhostChair
						{
							ReplaceWith = chair,
							IsDisabled = replaceWithDisabledGhosts,
							Table = nativeArray[i]
						});
						base.EntityManager.AddComponentData(entity, default(CApplianceChair));
						base.EntityManager.AddComponentData(entity, new CPosition(vector, rotation));
						base.EntityManager.AddBuffer<CGhostChairTableCandidates>(entity).Add(new CGhostChairTableCandidates
						{
							Table = nativeArray[i],
							Rotation = rotation
						});
						base.TileManager.SetOccupant(vector, entity);
					}
				}
			}
			nativeArray2.Dispose();
			nativeArray3.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SPerformTableUpdate_60 = GetEntityQuery(ComponentType.ReadOnly<SPerformTableUpdate>());
		}
	}
}
