using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	public class CollisionQueryWithPasses : ICollisionProvider, IQueryProvider, IQueryable
	{
		private readonly CollisionQuery _AnimatedWaves;

		private readonly CollisionQuery _DynamicWaves;

		private readonly CollisionQuery _Displacement;

		private readonly WaterRenderer _Water;

		public int ResultGuidCount => _AnimatedWaves.ResultGuidCount + _DynamicWaves.ResultGuidCount + _Displacement.ResultGuidCount;

		public int RequestCount => _AnimatedWaves.RequestCount + _DynamicWaves.RequestCount + _Displacement.RequestCount;

		public int QueryCount => _AnimatedWaves.QueryCount + _DynamicWaves.QueryCount + _Displacement.QueryCount;

		public CollisionQueryWithPasses()
		{
			_Water = ManagerBehaviour<WaterRenderer>.Instance;
			_AnimatedWaves = new CollisionQuery(_Water);
			_DynamicWaves = new CollisionQuery(_Water);
			_Displacement = new CollisionQuery(_Water);
		}

		public CollisionQueryWithPasses(WaterRenderer water)
		{
			_Water = water;
			_AnimatedWaves = new CollisionQuery(water);
			_DynamicWaves = new CollisionQuery(water);
			_Displacement = new CollisionQuery(water);
		}

		protected CollisionQuery GetProvider(CollisionLayer layer)
		{
			CollisionLayers collisionLayers = _Water.AnimatedWavesLod._CollisionLayers;
			if (collisionLayers == CollisionLayers.Nothing)
			{
				return _Displacement;
			}
			bool flag = layer == CollisionLayer.Everything;
			if (flag && collisionLayers.HasFlag(CollisionLayers.Displacement))
			{
				return _Displacement;
			}
			if ((flag || layer >= CollisionLayer.AfterDynamicWaves) && collisionLayers.HasFlag(CollisionLayers.DynamicWaves) && _Water.DynamicWavesLod.Enabled)
			{
				return _DynamicWaves;
			}
			return _AnimatedWaves;
		}

		public int Query(int hash, float minimumLength, Vector3[] points, float[] heights, Vector3[] normals, Vector3[] velocities, CollisionLayer layer = CollisionLayer.Everything, Vector3? center = null)
		{
			return GetProvider(layer).Query(hash, minimumLength, points, heights, normals, velocities);
		}

		public int Query(int hash, float minimumLength, Vector3[] points, Vector3[] displacements, Vector3[] normals, Vector3[] velocities, CollisionLayer layer = CollisionLayer.Everything, Vector3? center = null)
		{
			return GetProvider(layer).Query(hash, minimumLength, points, displacements, normals, velocities);
		}

		public void UpdateQueries(WaterRenderer water, CollisionLayer layer)
		{
			switch (layer)
			{
			case CollisionLayer.Everything:
				_Displacement.UpdateQueries(water);
				break;
			case CollisionLayer.AfterAnimatedWaves:
				_AnimatedWaves.UpdateQueries(water);
				break;
			case CollisionLayer.AfterDynamicWaves:
				_DynamicWaves.UpdateQueries(water);
				break;
			}
		}

		public void UpdateQueries(WaterRenderer water)
		{
			_Displacement.UpdateQueries(water);
		}

		public void SendReadBack(WaterRenderer water, CollisionLayers layers)
		{
			_AnimatedWaves.SendReadBack(water);
			_DynamicWaves.SendReadBack(water);
			_Displacement.SendReadBack(water);
		}

		public void SendReadBack(WaterRenderer water)
		{
			_Displacement.SendReadBack(water);
		}

		public void CleanUp()
		{
			_AnimatedWaves.CleanUp();
			_DynamicWaves.CleanUp();
			_Displacement.CleanUp();
		}

		public void Initialize(WaterRenderer water)
		{
		}
	}
}
