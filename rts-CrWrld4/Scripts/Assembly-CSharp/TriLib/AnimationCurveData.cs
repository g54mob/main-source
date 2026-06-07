using UnityEngine;

namespace TriLib
{
	public class AnimationCurveData
	{
		public readonly Keyframe[] Keyframes;

		private uint _index;

		public AnimationCurve AnimationCurve;

		public AnimationCurveData(uint numKeys)
		{
		}

		public void AddKey(float time, float value)
		{
		}
	}
}
