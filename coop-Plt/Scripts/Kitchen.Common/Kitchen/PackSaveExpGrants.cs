using System;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	public static class PackSaveExpGrants
	{
		public class Save : PackSaver<V1>
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

		[Serializable]
		[MessagePackObject(false)]
		[AutoUnionIndex(0)]
		public struct V1 : IPackSaveObject, ISaveObject
		{
			[Key(0)]
			public int Amount;

			[Key(1)]
			public int ExpIdentifier;

			[Key(2)]
			public bool IsGranted;

			public bool Save(EntityManager em, Entity e)
			{
				if (!em.RequireComponent<CExpGrant>(e, out var component))
				{
					return false;
				}
				Amount = component.Amount;
				ExpIdentifier = component.ExpIdentifier;
				IsGranted = component.IsGranted;
				return true;
			}

			public void Load(EntityManager em)
			{
				Entity entity = em.CreateEntity();
				em.AddComponent<CPersistThroughSceneChanges>(entity);
				em.AddComponentData(entity, new CExpGrant
				{
					Amount = Amount,
					ExpIdentifier = ExpIdentifier,
					IsGranted = IsGranted
				});
			}
		}
	}
}
