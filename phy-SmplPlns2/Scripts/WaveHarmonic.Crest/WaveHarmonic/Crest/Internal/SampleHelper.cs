using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace WaveHarmonic.Crest.Internal
{
	public abstract class SampleHelper
	{
		private protected readonly Vector3[] _QueryPosition;

		private protected readonly Vector3[] _QueryResult;

		private readonly Dictionary<int, int> _LastFrame = new Dictionary<int, int>();

		private protected SampleHelper(int queryCount = 1)
		{
			_QueryPosition = new Vector3[queryCount];
			_QueryResult = new Vector3[queryCount];
		}

		[Conditional("UNITY_EDITOR")]
		private protected void Validate(bool allowMultipleCallsPerFrame, int id)
		{
			if (!_LastFrame.ContainsKey(id))
			{
				_LastFrame.Add(id, -1);
			}
			if (!Time.inFixedTimeStep && !allowMultipleCallsPerFrame && _LastFrame[id] == Time.frameCount)
			{
				string name = GetType().Name;
				UnityEngine.Debug.LogWarning("Crest: " + name + " sample called multiple times in one frame which is not expected. Each " + name + " object services a single sample per frame. To perform multiple queries, create multiple " + name + " objects or use the query provider API directly.");
			}
			_LastFrame[id] = Time.frameCount;
		}

		private bool Sample(Vector3 position, float minimumLength, CollisionLayer layer)
		{
			return false;
		}
	}
}
