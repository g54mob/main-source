using UnityEngine;

namespace WaveHarmonic.Crest
{
	public sealed class CollisionQuery : QueryBase, ICollisionProvider, IQueryProvider
	{
		protected override int Kernel => 0;

		public CollisionQuery(WaterRenderer water)
			: base(water.AnimatedWavesLod)
		{
		}

		public int Query(int ownerHash, float minSpatialLength, Vector3[] queryPoints, Vector3[] resultDisplacements, Vector3[] resultNormals, Vector3[] resultVelocities, CollisionLayer layer = CollisionLayer.Everything, Vector3? center = null)
		{
			int num = 0;
			if (!UpdateQueryPoints(ownerHash, minSpatialLength, queryPoints, (resultNormals != null) ? queryPoints : null))
			{
				num |= 2;
			}
			if (!RetrieveResults(ownerHash, resultDisplacements, null, resultNormals))
			{
				num |= 1;
			}
			if (resultVelocities != null)
			{
				num |= CalculateVelocities(ownerHash, resultVelocities);
			}
			return num;
		}

		public int Query(int ownerHash, float minimumSpatialLength, Vector3[] queryPoints, float[] resultHeights, Vector3[] resultNormals, Vector3[] resultVelocities, CollisionLayer layer = CollisionLayer.Everything, Vector3? center = null)
		{
			int num = 0;
			if (!UpdateQueryPoints(ownerHash, minimumSpatialLength, queryPoints, (resultNormals != null) ? queryPoints : null))
			{
				num |= 2;
			}
			if (!RetrieveResults(ownerHash, null, resultHeights, resultNormals))
			{
				num |= 1;
			}
			if (resultVelocities != null)
			{
				num |= CalculateVelocities(ownerHash, resultVelocities);
			}
			return num;
		}
	}
}
