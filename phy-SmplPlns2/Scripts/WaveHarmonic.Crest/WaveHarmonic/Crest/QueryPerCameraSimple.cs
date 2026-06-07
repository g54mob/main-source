using System.Collections.Generic;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	internal abstract class QueryPerCameraSimple<T> : QueryPerCamera<T>, IQueryableSimple, IQueryable where T : IQueryableSimple, new()
	{
		protected QueryPerCameraSimple(WaterRenderer water)
			: base(water)
		{
		}

		public int Query(int id, float length, Vector3[] queries, Vector3[] results, Vector3? center = null)
		{
			if (_Water.IsSeparateViewpointCameraLoop)
			{
				return _Providers[_Water.CurrentCamera].Query(id, length, queries, results, center);
			}
			int num = -1;
			float num2 = float.PositiveInfinity;
			Vector2 vector = FindCenter(queries, center);
			foreach (KeyValuePair<Camera, T> provider in _Providers)
			{
				Camera key = provider.Key;
				if (!_Water.ShouldExecuteQueries(key))
				{
					continue;
				}
				float sqrMagnitude = (vector - key.transform.position.XZ()).sqrMagnitude;
				if (num != 0 || !(num2 < sqrMagnitude))
				{
					int num3 = provider.Value.Query(id, length, queries, results, center);
					if (num < 0 || num3 == 0)
					{
						num = num3;
						num2 = sqrMagnitude;
					}
				}
			}
			return num;
		}
	}
}
