using System.Collections.Generic;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateNewKitchen))]
	[UpdateInGroup(typeof(ChangeModeGroup))]
	public class CreateStartingItems : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CStartingItemsProvided : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CIsBonusItem : IComponentData
		{
		}

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SSceneData_31;

		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SSceneData>();
		}

		protected override void OnUpdate()
		{
			Entity singletonEntity = _SingletonEntityQuery_SSceneData_31.GetSingletonEntity();
			if (HasComponent<CStartingItemsProvided>(singletonEntity))
			{
				return;
			}
			base.EntityManager.AddComponent<CStartingItemsProvided>(singletonEntity);
			if (!base.EntityManager.HasComponent<CStartingItem>(singletonEntity))
			{
				return;
			}
			EntityManager entityManager = base.EntityManager;
			List<Vector3> postTiles = GetPostTiles();
			int num = 0;
			NativeArray<CStartingItem> nativeArray = GetBuffer<CStartingItem>(singletonEntity).ToNativeArray(Allocator.Temp);
			foreach (CStartingItem item in nativeArray)
			{
				if (base.Data.TryGet<Appliance>(item, out var output))
				{
					Vector3 vector = Vector3.zero;
					bool flag = false;
					while (!flag && num < postTiles.Count)
					{
						vector = postTiles[num++];
						if (base.TileManager.GetOccupant(vector) == default(Entity) && !base.TileManager.GetTile(vector).HasFeature)
						{
							flag = true;
						}
					}
					Entity entity = PostHelpers.CreateApplianceParcel(base.EntityManager, vector, output.ID);
					base.EntityManager.AddComponent<CIsBonusItem>(entity);
					continue;
				}
				Entity entity2 = base.EntityManager.CreateEntity(typeof(CProgressionOption), typeof(CProgressionOption.Selected), typeof(CProgressionOption.Displayed));
				entityManager.SetComponentData(entity2, new CProgressionOption
				{
					ID = item.ID,
					FromFranchise = true
				});
				if (item.SkipFirstTimeInfo)
				{
					entityManager.AddComponent<CSkipShowingRecipe>(entity2);
				}
			}
			nativeArray.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SSceneData_31 = GetEntityQuery(ComponentType.ReadOnly<SSceneData>());
		}
	}
}
