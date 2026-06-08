using MessagePack;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public static class PackSaveUpgrades
	{
		public class Save : PackSaver<V1>
		{
			protected internal override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
			}
		}

		public class LoadV2 : PackLoader<V2>
		{
			protected internal override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
			}
		}

		public class LoadV1 : PackLoader<V1>
		{
			protected internal override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
			}
		}

		[MessagePackObject(false)]
		[AutoUnionIndex(3)]
		public struct V2 : IPackSaveObject, ISaveObject
		{
			[Key(0)]
			public int ID;

			[Key(1)]
			public bool IsFromLevel;

			[Key(2)]
			public Vector3 Location;

			[Key(3)]
			public bool HasLocation;

			public bool Save(EntityManager em, Entity e)
			{
				EntityContext entityContext = new EntityContext(em);
				if (!entityContext.Require<CUpgrade>(e, out var comp))
				{
					return false;
				}
				ID = comp.ID;
				IsFromLevel = comp.IsFromLevel;
				if (entityContext.Require<CHeldBy>(e, out var comp2) && entityContext.Require<CPosition>(comp2, out var comp3))
				{
					Location = comp3;
					HasLocation = true;
					return true;
				}
				if (entityContext.Require<CPosition>(e, out comp3))
				{
					Location = comp3;
					HasLocation = true;
					return true;
				}
				return true;
			}

			public void Load(EntityManager em)
			{
				EntityContext entityContext = new EntityContext(em);
				Entity entity = entityContext.CreateEntity();
				entityContext.Add<CPersistThroughSceneChanges>(entity);
				entityContext.Set(entity, new CUpgrade
				{
					ID = ID,
					IsFromLevel = IsFromLevel
				});
				if (HasLocation)
				{
					entityContext.Set(entity, new CPosition(Location));
				}
			}
		}

		[MessagePackObject(false)]
		public struct V1 : IPackSaveObject, ISaveObject
		{
			[Key(0)]
			public int ID;

			[Key(1)]
			public bool IsFromLevel;

			[Key(2)]
			public SerializableVector3 Location;

			[Key(3)]
			public bool HasLocation;

			public bool Save(EntityManager em, Entity e)
			{
				EntityContext entityContext = new EntityContext(em);
				if (!entityContext.Require<CUpgrade>(e, out var comp))
				{
					return false;
				}
				ID = comp.ID;
				IsFromLevel = comp.IsFromLevel;
				if (entityContext.Require<CHeldBy>(e, out var comp2) && entityContext.Require<CPosition>(comp2, out var comp3))
				{
					Location = new SerializableVector3(comp3);
					HasLocation = true;
					return true;
				}
				if (entityContext.Require<CPosition>(e, out comp3))
				{
					Location = new SerializableVector3(comp3);
					HasLocation = true;
					return true;
				}
				return true;
			}

			public void Load(EntityManager em)
			{
				EntityContext entityContext = new EntityContext(em);
				Entity entity = entityContext.CreateEntity();
				entityContext.Add<CPersistThroughSceneChanges>(entity);
				entityContext.Set(entity, new CUpgrade
				{
					ID = ID,
					IsFromLevel = IsFromLevel
				});
				if (HasLocation)
				{
					entityContext.Set(entity, new CPosition(Location.ToVector3()));
				}
			}
		}
	}
}
