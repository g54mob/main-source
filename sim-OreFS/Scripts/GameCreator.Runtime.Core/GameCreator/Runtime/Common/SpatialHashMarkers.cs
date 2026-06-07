using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class SpatialHashMarkers
	{
		[field: NonSerialized]
		private static SpatialHash Value { get; set; }

		public static void Insert(ISpatialHash spatialHash)
		{
			if (Value == null)
			{
				Value = new SpatialHash();
			}
			Value.Insert(spatialHash);
		}

		public static void Remove(ISpatialHash spatialHash)
		{
			if (Value == null)
			{
				Value = new SpatialHash();
			}
			Value.Remove(spatialHash);
		}

		public static void Find(Vector3 point, float radius, List<ISpatialHash> results, ISpatialHash except = null)
		{
			if (Value == null)
			{
				Value = new SpatialHash();
			}
			Value.Find(point, radius, results, except);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void OnSubsystemsInit()
		{
			Value = null;
		}
	}
}
