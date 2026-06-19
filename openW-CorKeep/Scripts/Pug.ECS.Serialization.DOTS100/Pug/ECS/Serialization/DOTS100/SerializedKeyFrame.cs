using UnityEngine;

namespace Pug.ECS.Serialization.DOTS100
{
	internal struct SerializedKeyFrame
	{
		public float Time;

		public float Value;

		public float InTangent;

		public float OutTangent;

		public float InWeight;

		public float OutWeight;

		public int WeightedMode;

		public SerializedKeyFrame(Keyframe kf)
		{
			Time = kf.time;
			Value = kf.value;
			InTangent = kf.inTangent;
			OutTangent = kf.outTangent;
			InWeight = kf.inWeight;
			OutWeight = kf.outWeight;
			WeightedMode = (int)kf.weightedMode;
		}

		public static implicit operator Keyframe(SerializedKeyFrame kf)
		{
			Keyframe result = new Keyframe(kf.Time, kf.Value, kf.InTangent, kf.OutTangent, kf.InWeight, kf.OutWeight);
			result.weightedMode = (WeightedMode)kf.WeightedMode;
			return result;
		}

		public static implicit operator SerializedKeyFrame(Keyframe kf)
		{
			return new SerializedKeyFrame(kf);
		}
	}
}
