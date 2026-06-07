using System.Collections.Generic;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	internal sealed class CollisionQueryPerCamera : QueryPerCamera<CollisionQueryWithPasses>, ICollisionProvider, IQueryProvider
	{
		public CollisionQueryPerCamera()
			: base(ManagerBehaviour<WaterRenderer>.Instance)
		{
		}

		public CollisionQueryPerCamera(WaterRenderer water)
			: base(water)
		{
		}

		public int Query(int hash, float minimumLength, Vector3[] points, float[] heights, Vector3[] normals, Vector3[] velocities, CollisionLayer layer = CollisionLayer.Everything, Vector3? center = null)
		{
			if (_Water.IsSeparateViewpointCameraLoop)
			{
				return _Providers[_Water.CurrentCamera].Query(hash, minimumLength, points, heights, normals, velocities, layer, center);
			}
			int num = -1;
			float num2 = float.PositiveInfinity;
			Vector2 vector = FindCenter(points, center);
			foreach (KeyValuePair<Camera, CollisionQueryWithPasses> provider in _Providers)
			{
				Camera key = provider.Key;
				if (!_Water.ShouldExecuteQueries(key))
				{
					continue;
				}
				float sqrMagnitude = (vector - key.transform.position.XZ()).sqrMagnitude;
				if (num != 0 || !(num2 < sqrMagnitude))
				{
					int num3 = provider.Value.Query(hash, minimumLength, points, heights, normals, velocities, layer, center);
					if (num < 0 || num3 == 0)
					{
						num = num3;
						num2 = sqrMagnitude;
					}
				}
			}
			return num;
		}

		public int Query(int hash, float minimumLength, Vector3[] points, Vector3[] displacements, Vector3[] normals, Vector3[] velocities, CollisionLayer layer = CollisionLayer.Everything, Vector3? center = null)
		{
			if (_Water.IsSeparateViewpointCameraLoop)
			{
				return _Providers[_Water.CurrentCamera].Query(hash, minimumLength, points, displacements, normals, velocities, layer, center);
			}
			int num = -1;
			float num2 = float.PositiveInfinity;
			Vector2 vector = FindCenter(points, center);
			foreach (KeyValuePair<Camera, CollisionQueryWithPasses> provider in _Providers)
			{
				Camera key = provider.Key;
				if (!_Water.ShouldExecuteQueries(key))
				{
					continue;
				}
				float sqrMagnitude = (vector - key.transform.position.XZ()).sqrMagnitude;
				if (num != 0 || !(num2 < sqrMagnitude))
				{
					int num3 = provider.Value.Query(hash, minimumLength, points, displacements, normals, velocities, layer, center);
					if (num < 0 || num3 == 0)
					{
						num = num3;
						num2 = sqrMagnitude;
					}
				}
			}
			return num;
		}

		public void SendReadBack(WaterRenderer water, CollisionLayers layers)
		{
			_Providers[water.CurrentCamera].SendReadBack(water, layers);
		}

		public void UpdateQueries(WaterRenderer water, CollisionLayer layer)
		{
			_Providers[water.CurrentCamera].UpdateQueries(water, layer);
		}
	}
}
