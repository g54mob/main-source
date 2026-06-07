using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	public sealed class SampleDepthHelper : SampleHelper
	{
		internal bool Sample(int id, Vector3 position, out Vector2 result, bool allowMultipleCallsPerFrame = false)
		{
			WaterRenderer instance = ManagerBehaviour<WaterRenderer>.Instance;
			IDepthProvider depthProvider = ((instance == null) ? null : instance.DepthLod.Provider);
			if (depthProvider == null)
			{
				result = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
				return false;
			}
			_QueryPosition[0] = position;
			int status = depthProvider.Query(id, 0f, _QueryPosition, _QueryResult, position);
			if (!depthProvider.RetrieveSucceeded(status))
			{
				result = new Vector2(float.PositiveInfinity, float.PositiveInfinity);
				return false;
			}
			result = _QueryResult[0];
			return true;
		}

		private bool Sample(Vector3 position, out Vector2 result)
		{
			return Sample(GetHashCode(), position, out result);
		}

		internal bool Sample(Vector3 position, out float depth, out float distance)
		{
			Vector2 result2;
			bool result = Sample(position, out result2);
			depth = result2.x;
			distance = result2.y;
			return result;
		}

		private bool SampleWaterDepth(Vector3 position, out float depth)
		{
			Vector2 result2;
			bool result = Sample(position, out result2);
			depth = result2.x;
			return result;
		}

		public bool SampleDistanceToWaterEdge(Vector3 position, out float distance)
		{
			return SampleDistanceToWaterEdge(GetHashCode(), position, out distance);
		}

		internal bool SampleDistanceToWaterEdge(int id, Vector3 position, out float distance)
		{
			Vector2 result2;
			bool result = Sample(id, position, out result2);
			distance = result2.y;
			return result;
		}
	}
}
