using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.OcclusionCulling
{
	public struct OcclusionChunk
	{
		public const int LinkedListNull = -1;

		public Bounds OccluderBounds;

		public Bounds Bounds;

		public List<IOcclusionObject> Objects;

		public bool IsVisible;

		public int ConsecutiveInvisibleFramesLeft;

		public int PreviousIndex;

		public int NextIndex;

		public bool IsAlive
		{
			get
			{
				if (Objects != null)
				{
					return Objects.Count > 0;
				}
				return false;
			}
		}

		public static OcclusionChunk New()
		{
			OcclusionChunk result = default(OcclusionChunk);
			result.Reset();
			return result;
		}

		public void Reset()
		{
			OccluderBounds = default(Bounds);
			Bounds = default(Bounds);
			Objects?.Clear();
			IsVisible = true;
			PreviousIndex = -1;
			NextIndex = -1;
			ConsecutiveInvisibleFramesLeft = 0;
		}
	}
}
