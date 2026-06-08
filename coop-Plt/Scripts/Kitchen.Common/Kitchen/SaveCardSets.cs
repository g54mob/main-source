using System;
using KitchenData;
using MessagePack;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public static class SaveCardSets
	{
		[Serializable]
		[MessagePackObject(false)]
		public struct V1 : IComponentData
		{
			[Key(0)]
			public bool HasLocation;

			[Key(1)]
			public int Tier;

			[Key(2)]
			public Vector3 Location;
		}

		public struct V2 : IComponentData
		{
			public int Tier;

			public FixedString64 Name;
		}

		[InternalBufferCapacity(15)]
		public struct V1Buffer : IBufferElementData
		{
			public int CardID;
		}

		public static bool DoesLoadedEntityMatch(EntityManager em, Entity e)
		{
			return em.HasComponent<CFranchiseItem>(e);
		}

		public static bool Recreate(EntityManager save, EntityManager em, Entity e)
		{
			if (save.RequireComponent<V2>(e, out var component) && save.HasComponent<V1Buffer>(e))
			{
				Entity entity = em.CreateEntity(typeof(CPersistentItem), typeof(CFranchiseItem), typeof(CFranchiseTier), typeof(CPersistThroughSceneChanges));
				em.SetComponentData(entity, new CPersistentItem
				{
					Type = PersistentStorageType.FranchiseCardSet,
					ItemID = AssetReference.FranchiseCardSet
				});
				em.SetComponentData(entity, new CFranchiseTier
				{
					Tier = component.Tier
				});
				DataObjectList cards = default(DataObjectList);
				foreach (V1Buffer item in save.GetBuffer<V1Buffer>(e))
				{
					if (GameData.Main.TryGet<ICard>(item.CardID, out var _, warn_if_fail: true))
					{
						cards.Add(item.CardID);
					}
				}
				em.SetComponentData(entity, new CFranchiseItem
				{
					Name = component.Name,
					Cards = cards
				});
				return true;
			}
			if (save.RequireComponent<V1>(e, out var component2) && save.HasComponent<V1Buffer>(e))
			{
				Entity entity2 = em.CreateEntity(typeof(CPersistentItem), typeof(CFranchiseItem), typeof(CFranchiseTier), typeof(CPersistThroughSceneChanges));
				em.SetComponentData(entity2, new CPersistentItem
				{
					Type = PersistentStorageType.FranchiseCardSet,
					ItemID = AssetReference.FranchiseCardSet
				});
				em.SetComponentData(entity2, new CFranchiseTier
				{
					Tier = component2.Tier
				});
				if (component2.HasLocation)
				{
					em.AddComponentData(entity2, new CPosition(component2.Location));
				}
				DataObjectList cards2 = default(DataObjectList);
				foreach (V1Buffer item2 in save.GetBuffer<V1Buffer>(e))
				{
					cards2.Add(item2.CardID);
				}
				em.SetComponentData(entity2, new CFranchiseItem
				{
					Cards = cards2
				});
				return true;
			}
			return false;
		}

		public static bool Save(EntityManager em, Entity e, EntityManager em_out)
		{
			Debug.LogError("Tried to use outdated save mechanism for card sets");
			return false;
		}
	}
}
