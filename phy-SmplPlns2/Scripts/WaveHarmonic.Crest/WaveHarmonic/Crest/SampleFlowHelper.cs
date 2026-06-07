using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	public sealed class SampleFlowHelper : SampleHelper
	{
		public bool Sample(Vector3 position, out Vector2 flow, float minimumLength = 0f)
		{
			WaterRenderer instance = ManagerBehaviour<WaterRenderer>.Instance;
			IFlowProvider flowProvider = ((instance == null) ? null : instance.FlowLod.Provider);
			if (flowProvider == null)
			{
				flow = Vector2.zero;
				return false;
			}
			int hashCode = GetHashCode();
			_QueryPosition[0] = position;
			int status = flowProvider.Query(hashCode, minimumLength, _QueryPosition, _QueryResult, position);
			if (!flowProvider.RetrieveSucceeded(status))
			{
				flow = Vector2.zero;
				return false;
			}
			flow.x = _QueryResult[0].x;
			flow.y = _QueryResult[0].z;
			return true;
		}
	}
}
