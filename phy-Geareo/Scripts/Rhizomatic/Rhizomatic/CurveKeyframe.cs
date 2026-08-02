using System;
using UnityEngine;

namespace Rhizomatic
{
	[Serializable]
	public class CurveKeyframe
	{
		public float time;

		public float value;

		public float inTangent;

		public float outTangent;

		public float inWeight;

		public float outWeight;

		public bool inWeighted;

		public bool outWeighted;

		public bool inLinear;

		public bool outLinear;

		public bool auto;

		public CurveKeyframe()
		{
		}

		public CurveKeyframe(float time, float value)
		{
		}

		public static CurveKeyframe FromKeyframe(Keyframe keyframe)
		{
			return null;
		}

		public Keyframe ToKeyframe()
		{
			return default(Keyframe);
		}

		public WeightedMode GetWeightedMode()
		{
			return default(WeightedMode);
		}

		public CurveKeyframeData Serialize()
		{
			return null;
		}

		public void Deserialize(CurveKeyframeData data)
		{
		}
	}
}
