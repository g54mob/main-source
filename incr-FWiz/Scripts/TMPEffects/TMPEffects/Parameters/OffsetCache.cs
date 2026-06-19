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
		}

		public void CacheMinMax(float min, float max)
		{
		}

		public bool GetOffset(CharData cData, out float cOffset)
		{
			cOffset = default(float);
			return false;
		}

		public bool GetMinMaxOffset(out float min, out float max)
		{
			min = default(float);
			max = default(float);
			return false;
		}

		public void ClearCache()
		{
		}
	}
}
