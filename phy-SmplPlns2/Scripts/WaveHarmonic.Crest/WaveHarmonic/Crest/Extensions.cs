using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal static class Extensions
	{
		public static void UpdateQueries(this ICollisionProvider self, WaterRenderer water, CollisionLayer layer)
		{
			if (self is CollisionQueryPerCamera collisionQueryPerCamera)
			{
				collisionQueryPerCamera.UpdateQueries(water, layer);
			}
			else if (self is CollisionQueryWithPasses collisionQueryWithPasses)
			{
				collisionQueryWithPasses.UpdateQueries(water, layer);
			}
			else if (!(self is ICollisionProvider.NoneProvider))
			{
				Debug.LogError("Crest: no valid query provider. Report this to developers!");
			}
		}

		public static void UpdateQueries(this ICollisionProvider self, WaterRenderer water)
		{
			(self as IQueryable)?.UpdateQueries(water);
		}

		public static void SendReadBack(this ICollisionProvider self, WaterRenderer water, CollisionLayers layer)
		{
			if (self is CollisionQueryPerCamera collisionQueryPerCamera)
			{
				collisionQueryPerCamera.SendReadBack(water, layer);
			}
			else if (self is CollisionQueryWithPasses collisionQueryWithPasses)
			{
				collisionQueryWithPasses.SendReadBack(water, layer);
			}
			else if (!(self is ICollisionProvider.NoneProvider))
			{
				Debug.LogError("Crest: no valid query provider. Report this to developers!");
			}
		}

		public static void CleanUp(this ICollisionProvider self)
		{
			(self as IQueryable)?.CleanUp();
		}

		public static void UpdateQueries(this IQueryProvider self, WaterRenderer water)
		{
			(self as IQueryable)?.UpdateQueries(water);
		}

		public static void CleanUp(this IQueryProvider self)
		{
			(self as IQueryable)?.CleanUp();
		}
	}
}
