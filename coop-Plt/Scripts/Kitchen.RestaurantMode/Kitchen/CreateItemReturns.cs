using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateItemReturns : RestaurantSystem
	{
		private EntityQuery ItemReturns;

		protected override void Initialise()
		{
			base.Initialise();
			ItemReturns = GetEntityQuery(typeof(CReturnItem), typeof(CHeldBy));
			RequireForUpdate(ItemReturns);
		}

		protected override void OnUpdate()
		{
			Vector3 min = base.Bounds.min;
			Vector3 vector = min;
			vector.y = 0f;
			vector.z -= 2f;
			bool flag = false;
			for (int i = 0; (float)i < base.Bounds.size.z + 2f; i++)
			{
				for (int j = 0; (float)j <= base.Bounds.size.x; j++)
				{
					if (base.TileManager.IsSuitableEmptyTile(vector))
					{
						flag = true;
						break;
					}
					vector.x += 1f;
				}
				if (flag)
				{
					break;
				}
				vector.x = min.x;
				vector.z += 1f;
			}
			if (flag)
			{
				Entity entity = ItemReturns.First();
				if (HasComponent<CHeldAppliance>(entity))
				{
					base.EntityManager.RemoveComponent<CHeldAppliance>(entity);
					base.EntityManager.RemoveComponent<CHeldBy>(entity);
					base.EntityManager.AddComponent<CRemoveView>(entity);
					base.EntityManager.SetComponentData(entity, new CRequiresView
					{
						Type = ViewType.Appliance
					});
					base.EntityManager.SetComponentData(entity, (CPosition)vector);
					base.TileManager.SetOccupant(vector, entity);
				}
				else
				{
					Entity entity2 = base.EntityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CItemHolder), typeof(CMaintainInView));
					base.EntityManager.SetComponentData(entity2, new CCreateAppliance
					{
						ID = AssetReference.ItemReturnAppliance
					});
					base.EntityManager.SetComponentData(entity2, new CPosition(vector));
					base.EntityManager.SetComponentData(entity2, new CItemHolder
					{
						HeldItem = entity
					});
					base.EntityManager.SetComponentData(entity, new CHeldBy
					{
						Holder = entity2
					});
				}
				base.EntityManager.RemoveComponent<CReturnItem>(entity);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
