using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	public static class PackSaveSpeedrun
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

		[MessagePackObject(false)]
		[AutoUnionIndex(8)]
		public struct V1 : IPackSaveObject, ISaveObject
		{
			[Key(0)]
			public int Year;

			[Key(1)]
			public int Week;

			[Key(2)]
			public int DurationMilliseconds;

			[Key(3)]
			public float Percentile;

			public bool Save(EntityManager em, Entity e)
			{
				if (!em.RequireComponent<SBestSpeedrun>(e, out var component))
				{
					return false;
				}
				Year = component.Year;
				Week = component.Week;
				DurationMilliseconds = component.DurationMilliseconds;
				Percentile = component.Percentile;
				return true;
			}

			public void Load(EntityManager em)
			{
				Entity entity = em.CreateEntity();
				em.AddComponent<CPersistThroughSceneChanges>(entity);
				em.AddComponentData(entity, new SBestSpeedrun
				{
					Year = Year,
					Week = Week,
					DurationMilliseconds = DurationMilliseconds,
					Percentile = Percentile
				});
			}
		}
	}
}
