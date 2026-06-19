using System.Collections.Generic;
using TMPEffects.CharacterData;

namespace TMPEffects.Parameters
{
	internal struct OffsetCache
	{
		public float? maxOffset;

		public float? minOffset;

		public Dictionary<CharData, float> offset;

		public void CacheOffset(CharData cData, float cOffset)
		{
			offset[cData] = cOffset;
		}

		public void CacheMinMax(float min, float max)
		{
			minOffset = min;
			maxOffset = max;
		}

		public bool GetOffset(CharData cData, out float cOffset)
		{
			return offset.TryGetValue(cData, out cOffset);
		}

		public bool GetMinMaxOffset(out float min, out float max)
		{
			if (maxOffset.HasValue && minOffset.HasValue)
			{
				min = minOffset.Value;
				max = maxOffset.Value;
				return true;
			}
			min = 0f;
			max = 0f;
			return false;
		}

		public void ClearCache()
		{
			maxOffset = null;
			minOffset = null;
			offset.Clear();
		}
	}
}
