using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	public interface IFlowProvider : IQueryProvider
	{
		internal sealed class NoneProvider : IFlowProvider, IQueryProvider
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

		internal static IFlowProvider Create(WaterRenderer water)
		{
			if (!water.IsMultipleViewpointMode)
			{
				return new FlowQuery(water);
			}
			return new FlowQueryPerCamera(water);
		}

		int Query(int hash, float minimumLength, Vector3[] points, Vector3[] results, Vector3? center = null);

		static IFlowProvider()
		{
			None = new NoneProvider();
		}
	}
}
