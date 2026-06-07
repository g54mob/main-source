using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	public sealed class RayCastHelper : SampleHelper
	{
		private readonly float _RayStepSize;

		private readonly float _MinimumLength;

		public RayCastHelper(float rayLength, float rayStepSize = 2f)
			: base(ComputeQueryCount(rayLength, ref rayStepSize))
		{
			_RayStepSize = rayStepSize;
			_MinimumLength = _RayStepSize * 4f;
		}

		private static int ComputeQueryCount(float rayLength, ref float rayStepSize)
		{
			int num = Mathf.CeilToInt(rayLength / rayStepSize) + 1;
			int num2 = 128;
			if (num > num2)
			{
				num = num2;
				rayStepSize = rayLength / ((float)num - 1f);
				Debug.LogWarning($"Crest: RayTraceHelper: ray steps exceed maximum ({num2}), step size increased to {rayStepSize} to reduce step count.");
			}
			return num;
		}

		public bool RayCast(Vector3 origin, Vector3 direction, out float distance, CollisionLayer layer = CollisionLayer.Everything)
		{
			distance = -1f;
			int hashCode = GetHashCode();
			WaterRenderer instance = ManagerBehaviour<WaterRenderer>.Instance;
			ICollisionProvider collisionProvider = ((instance == null) ? null : instance.AnimatedWavesLod.Provider);
			if (collisionProvider == null)
			{
				return false;
			}
			for (int i = 0; i < _QueryPosition.Length; i++)
			{
				_QueryPosition[i] = origin + (float)i * _RayStepSize * direction;
			}
			int status = collisionProvider.Query(hashCode, _MinimumLength, _QueryPosition, _QueryResult, null, null, layer);
			if (!collisionProvider.RetrieveSucceeded(status))
			{
				return false;
			}
			for (int j = 1; j < _QueryPosition.Length; j++)
			{
				float f = _QueryResult[j - 1].y + instance.SeaLevel - _QueryPosition[j - 1].y;
				float f2 = _QueryResult[j].y + instance.SeaLevel - _QueryPosition[j].y;
				if (Mathf.Sign(f) != Mathf.Sign(f2))
				{
					float num = Mathf.Abs(f) / (Mathf.Abs(f) + Mathf.Abs(f2));
					distance = ((float)(j - 1) + num) * _RayStepSize;
					break;
				}
			}
			return distance >= 0f;
		}
	}
}
