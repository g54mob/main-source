using KitchenData;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	public abstract class ResearchSystem : GameSystemBase
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SResearchSystemMarker>();
		}

		protected Entity Create(Item ingredient, Vector3 location, Vector3 facing)
		{
			int iD = ((ingredient.DedicatedProvider == null) ? base.Data.ReferableObjects.DefaultProvider.ID : ingredient.DedicatedProvider.ID);
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CItemProvider));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = iD
			});
			entityManager.SetComponentData(entity, CItemProvider.InfiniteItemProvider(ingredient.ID));
			entityManager.SetComponentData(entity, new CPosition(location, quaternion.LookRotation(facing, new float3(0f, 1f, 0f))));
			base.TileManager.SetOccupant(location, entity);
			return entity;
		}

		protected Entity Create(int appliance, Vector3 location, Vector3 facing)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = appliance
			});
			entityManager.SetComponentData(entity, new CPosition(location, quaternion.LookRotation(facing, new float3(0f, 1f, 0f))));
			base.TileManager.SetOccupant(location, entity);
			return entity;
		}

		protected Entity Create(Appliance appliance, Vector3 location, Vector3 facing)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = appliance.ID
			});
			entityManager.SetComponentData(entity, new CPosition(location, quaternion.LookRotation(facing, new float3(0f, 1f, 0f))));
			base.TileManager.SetOccupant(location, entity);
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
