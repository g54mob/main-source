using System;
using KitchenData;
using MessagePack;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public static class SaveUpgrades
	{
		[Serializable]
		[MessagePackObject(false)]
		public struct V1 : IComponentData
		{
			[Key(0)]
			public int ID;

			[Key(1)]
			public bool HasLocation;

			[Key(2)]
			public Vector3 Location;
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct V2 : IComponentData
		{
			[Key(0)]
			public int ID;

			[Key(1)]
			public bool IsFromLevel;

			[Key(2)]
			public bool HasLocation;

			[Key(3)]
			public Vector3 Location;
		}

		public static bool DoesLoadedEntityMatch(EntityManager em, Entity e)
		{
			return em.HasComponent<CUpgrade>(e);
		}

		public static bool Recreate(EntityManager save, EntityManager em, Entity e)
		{
			if (save.RequireComponent<V1>(e, out var component))
			{
				if (!GameData.Main.Has(component.ID))
				{
					return false;
				}
				Entity entity = em.CreateEntity(typeof(CPersistThroughSceneChanges));
				em.AddComponentData(entity, new CUpgrade
				{
					ID = component.ID,
					IsFromLevel = true
				});
				if (component.HasLocation)
				{
					em.AddComponentData(entity, new CPosition(component.Location));
				}
				return true;
			}
			if (save.RequireComponent<V2>(e, out var component2))
			{
				if (!GameData.Main.Has(component2.ID))
				{
					return false;
				}
				Entity entity2 = em.CreateEntity(typeof(CPersistThroughSceneChanges));
				em.AddComponentData(entity2, new CUpgrade
				{
					ID = component2.ID,
					IsFromLevel = component2.IsFromLevel
				});
				if (component2.HasLocation)
				{
					em.AddComponentData(entity2, new CPosition(component2.Location));
				}
				return true;
			}
			return false;
		}

		public static bool Save(EntityManager em, Entity e, out V2 output)
		{
			if (em.RequireComponent<CUpgrade>(e, out var component))
			{
				if (em.RequireComponent<CHeldBy>(e, out var component2) && em.RequireComponent<CPosition>(component2, out var component3))
				{
					output = new V2
					{
						ID = component.ID,
						Location = component3,
						HasLocation = true,
						IsFromLevel = component.IsFromLevel
					};
					return true;
				}
				if (em.RequireComponent<CPosition>(e, out var component4))
				{
					output = new V2
					{
						ID = component.ID,
						Location = component4,
						HasLocation = true,
						IsFromLevel = component.IsFromLevel
					};
					return true;
				}
				output = new V2
				{
					ID = component.ID,
					IsFromLevel = component.IsFromLevel
				};
				return true;
			}
			output = default(V2);
			return false;
		}
	}
}
