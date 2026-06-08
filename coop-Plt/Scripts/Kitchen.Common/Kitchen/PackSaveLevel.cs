using System;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public static class PackSaveLevel
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
		[AutoUnionIndex(2)]
		public struct V1 : IPackSaveObject, ISaveObject, IProgress
		{
			[Key(0)]
			public int Level;

			[Key(1)]
			public int ExpProgress;

			public bool Save(EntityManager em, Entity e)
			{
				if (!em.RequireComponent<SPlayerLevel>(e, out var component))
				{
					return false;
				}
				Level = component.Level;
				ExpProgress = component.ExpProgress;
				return true;
			}

			public void Load(EntityManager em)
			{
				Entity entity = em.CreateEntity();
				em.AddComponent<CPersistThroughSceneChanges>(entity);
				em.AddComponentData(entity, new SPlayerLevel
				{
					Level = Level,
					ExpProgress = ExpProgress
				});
			}

			public ProgressInfo Progress()
			{
				return new ProgressInfo
				{
					Level = Level,
					Exp = ExpProgress
				};
			}
		}
	}
}
