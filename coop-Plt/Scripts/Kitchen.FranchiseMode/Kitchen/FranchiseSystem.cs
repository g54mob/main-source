using KitchenData;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Kitchen
{
	public abstract class FranchiseSystem : GameSystemBase
	{
		protected override void Initialise()
		{
			base.Initialise();
			RequireSingletonForUpdate<SFranchiseMarker>();
		}

		protected Entity Create(int id, Vector3 location, Vector3 facing)
		{
			return Create(GameData.Main.Get<Appliance>(id), location, facing);
		}

		protected Entity Create(Appliance appliance, Vector3 location, Vector3 facing)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = appliance.ID
			});
			entityManager.SetComponentData(entity, new CPosition(location, (facing != Vector3.zero) ? quaternion.LookRotation(facing, new float3(0f, 1f, 0f)) : quaternion.identity));
			base.TileManager.SetOccupant(location, entity);
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
