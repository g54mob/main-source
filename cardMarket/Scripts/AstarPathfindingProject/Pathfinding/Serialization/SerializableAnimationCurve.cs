using Pathfinding.Util;
using UnityEngine;

namespace Pathfinding.Serialization
{
	[Preserve]
	internal class SerializableAnimationCurve
	{
		public WrapMode preWrapMode;

		public WrapMode postWrapMode;

		public Keyframe[] keys;
	}
}
