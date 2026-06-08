using System.Collections.Generic;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateBedrooms : FranchiseFirstFrameSystem
	{
		private EntityQuery Players;

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(typeof(CPlayer), typeof(CPosition));
		}

		protected override void OnUpdate()
		{
			NativeArray<Entity> nativeArray = Players.ToEntityArray(Allocator.Temp);
			List<Vector3> bedrooms = LobbyPositionAnchors.Bedrooms;
			for (int i = 0; i < 4; i++)
			{
				Entity target = CreateAssigned(i, GameData.Main.Get<Appliance>(AssetReference.Bed), bedrooms[i] + new Vector3(0f, 0f, 1f), Vector3.forward);
				Entity entity = CreateAssigned(i, GameData.Main.Get<Appliance>(AssetReference.InteractionProxy), bedrooms[i] + new Vector3(0f, 0f, 0f), Vector3.forward);
				base.EntityManager.AddComponentData(entity, new CInteractionProxy
				{
					Target = target,
					IsActive = true
				});
				Entity entity2 = CreateAssigned(i, GameData.Main.Get<Appliance>(AssetReference.OutfitStation), bedrooms[i] + new Vector3(-2f, 0f, 0.5f), Vector3.forward);
				base.EntityManager.AddComponent<CCosmeticSelector>(entity2);
				base.EntityManager.SetComponentData(entity2, new CCosmeticSelector
				{
					Type = CosmeticType.Outfit,
					DrawLocation = new Vector3((i == 3) ? (-1f) : (-0.25f), 0f, 0f)
				});
				CreateAssigned(i, GameData.Main.Get<Appliance>(AssetReference.OccupationIndicator), bedrooms[i] + new Vector3(1f, 0f, 0f), Vector3.forward);
				PlaceSpawnMarker(i, bedrooms[i] + new Vector3(-1f, 0f, 0f));
				foreach (Entity item in nativeArray)
				{
					if (i == GetComponent<CPlayer>(item).Index)
					{
						base.EntityManager.SetComponentData(item, new CPosition(bedrooms[i] + new Vector3(-1f, 0f, 0f)));
						break;
					}
				}
			}
			nativeArray.Dispose();
		}

		protected void PlaceSpawnMarker(int index, Vector3 location)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CPlayerSpawnLocation));
			base.EntityManager.SetComponentData(entity, new CPlayerSpawnLocation
			{
				Index = index,
				Location = location
			});
		}

		protected Entity CreateAssigned(int bedroom, Appliance appliance, Vector3 location, Vector3 facing)
		{
			Entity entity = Create(appliance, location, facing);
			base.EntityManager.AddComponentData(entity, new CBedroomPart
			{
				Room = bedroom
			});
			base.EntityManager.AddComponentData(entity, new COwnedByPlayer
			{
				Player = default(Entity)
			});
			base.EntityManager.AddComponentData(entity, default(CColourByOwner));
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
