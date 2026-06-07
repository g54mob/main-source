using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	public interface IDepthProvider : IQueryProvider
	{
		internal sealed class NoneProvider : IDepthProvider, IQueryProvider
		{
			public int Query(int _0, float _1, Vector3[] _2, Vector3[] result, Vector3? _3 = null)
			{
				if (result != null)
				{
					Array.Clear(result, 0, result.Length);
				}
				return 0;
			}
		}

		internal static NoneProvider None { get; }

		internal static IDepthProvider Create(WaterRenderer water)
		{
			if (!water.IsMultipleViewpointMode)
			{
				return new DepthQuery(water);
			}
			return new DepthQueryPerCamera(water);
		}

		int Query(int hash, float minimumLength, Vector3[] points, Vector3[] results, Vector3? center = null);

		static IDepthProvider()
		{
			None = new NoneProvider();
		}
	}
}
