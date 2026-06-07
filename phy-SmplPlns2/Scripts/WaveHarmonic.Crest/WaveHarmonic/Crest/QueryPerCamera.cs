using System.Collections.Generic;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	internal abstract class QueryPerCamera<T> : IQueryable where T : IQueryable, new()
	{
		internal readonly WaterRenderer _Water;

		internal readonly Dictionary<Camera, T> _Providers = new Dictionary<Camera, T>();

		public int ResultGuidCount
		{
			get
			{
				int num = 0;
				foreach (var (camera2, val2) in _Providers)
				{
					if (_Water.ShouldExecuteQueries(camera2))
					{
						num += val2.ResultGuidCount;
					}
				}
				return num;
			}
		}

		public int RequestCount
		{
			get
			{
				int num = 0;
				foreach (var (camera2, val2) in _Providers)
				{
					if (_Water.ShouldExecuteQueries(camera2))
					{
						num += val2.RequestCount;
					}
				}
				return num;
			}
		}

		public int QueryCount
		{
			get
			{
				int num = 0;
				foreach (var (camera2, val2) in _Providers)
				{
					if (_Water.ShouldExecuteQueries(camera2))
					{
						num += val2.QueryCount;
					}
				}
				return num;
			}
		}

		public QueryPerCamera(WaterRenderer water)
		{
			_Water = water;
			Initialize(water);
		}

		public void CleanUp()
		{
			foreach (T value in _Providers.Values)
			{
				value?.CleanUp();
			}
		}

		public void Initialize(WaterRenderer water)
		{
			Camera camera = water.CurrentCamera;
			if (camera == null)
			{
				camera = water.Viewer;
			}
			if (!(camera == null) && !_Providers.ContainsKey(camera))
			{
				_Providers.Add(camera, new T());
			}
		}

		public void SendReadBack(WaterRenderer water)
		{
			_Providers[water.CurrentCamera].SendReadBack(water);
		}

		public void UpdateQueries(WaterRenderer water)
		{
			_Providers[water.CurrentCamera].UpdateQueries(water);
		}

		public Vector2 FindCenter(Vector3[] queries, Vector3? center)
		{
			if (center.HasValue)
			{
				return center.Value.XZ();
			}
			Vector2 zero = Vector2.zero;
			foreach (Vector3 v in queries)
			{
				zero += v.XZ();
			}
			return new Vector2(zero.x / (float)queries.Length, zero.y / (float)queries.Length);
		}
	}
}
