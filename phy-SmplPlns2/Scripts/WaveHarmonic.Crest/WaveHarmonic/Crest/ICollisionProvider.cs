using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	public interface ICollisionProvider : IQueryProvider
	{
		public sealed class NoneProvider : ICollisionProvider, IQueryProvider
		{
			public int Query(int _0, float _1, Vector3[] _2, Vector3[] result0, Vector3[] result1, Vector3[] result2, CollisionLayer _3 = CollisionLayer.Everything, Vector3? _4 = null)
			{
				if (result0 != null)
				{
					Array.Fill(result0, Vector3.zero);
				}
				if (result1 != null)
				{
					Array.Fill(result1, Vector3.up);
				}
				if (result2 != null)
				{
					Array.Fill(result2, Vector3.zero);
				}
				return 0;
			}

			public int Query(int _0, float _1, Vector3[] _2, float[] result0, Vector3[] result1, Vector3[] result2, CollisionLayer _3 = CollisionLayer.Everything, Vector3? _4 = null)
			{
				if (result0 != null)
				{
					Array.Fill(result0, ManagerBehaviour<WaterRenderer>.Instance.SeaLevel);
				}
				if (result1 != null)
				{
					Array.Fill(result1, Vector3.up);
				}
				if (result2 != null)
				{
					Array.Fill(result2, Vector3.zero);
				}
				return 0;
			}
		}

		internal const string k_LayerTooltip = "Which water collision layer to target.";

		static NoneProvider None { get; }

		internal static ICollisionProvider Create(WaterRenderer water)
		{
			if (!water.IsMultipleViewpointMode)
			{
				return new CollisionQueryWithPasses(water);
			}
			return new CollisionQueryPerCamera(water);
		}

		int Query(int hash, float minimumLength, Vector3[] points, float[] heights, Vector3[] normals, Vector3[] velocities, CollisionLayer layer = CollisionLayer.Everything, Vector3? center = null);

		int Query(int hash, float minimumLength, Vector3[] points, Vector3[] displacements, Vector3[] normals, Vector3[] velocities, CollisionLayer layer = CollisionLayer.Everything, Vector3? center = null);

		static ICollisionProvider()
		{
			None = new NoneProvider();
		}
	}
}
