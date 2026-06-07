using System;
using UnityEngine;

namespace RootMotion
{
	[Serializable]
	public class BakerMuscle
	{
		public AnimationCurve curve;

		private int muscleIndex = -1;

		private string propertyName;

		public BakerMuscle(int muscleIndex)
		{
			this.muscleIndex = muscleIndex;
			propertyName = MuscleNameToPropertyName(HumanTrait.MuscleName[muscleIndex]);
			Reset();
		}

		private string MuscleNameToPropertyName(string n)
		{
			switch (n)
			{
			case "Left Index 1 Stretched":
				return "LeftHand.Index.1 Stretched";
			case "Left Index 2 Stretched":
				return "LeftHand.Index.2 Stretched";
			case "Left Index 3 Stretched":
				return "LeftHand.Index.3 Stretched";
			case "Left Middle 1 Stretched":
				return "LeftHand.Middle.1 Stretched";
			case "Left Middle 2 Stretched":
				return "LeftHand.Middle.2 Stretched";
			case "Left Middle 3 Stretched":
				return "LeftHand.Middle.3 Stretched";
			case "Left Ring 1 Stretched":
				return "LeftHand.Ring.1 Stretched";
			case "Left Ring 2 Stretched":
				return "LeftHand.Ring.2 Stretched";
			case "Left Ring 3 Stretched":
				return "LeftHand.Ring.3 Stretched";
			case "Left Little 1 Stretched":
				return "LeftHand.Little.1 Stretched";
			case "Left Little 2 Stretched":
				return "LeftHand.Little.2 Stretched";
			case "Left Little 3 Stretched":
				return "LeftHand.Little.3 Stretched";
			case "Left Thumb 1 Stretched":
				return "LeftHand.Thumb.1 Stretched";
			case "Left Thumb 2 Stretched":
				return "LeftHand.Thumb.2 Stretched";
			case "Left Thumb 3 Stretched":
				return "LeftHand.Thumb.3 Stretched";
			case "Left Index Spread":
				return "LeftHand.Index.Spread";
			case "Left Middle Spread":
				return "LeftHand.Middle.Spread";
			case "Left Ring Spread":
				return "LeftHand.Ring.Spread";
			case "Left Little Spread":
				return "LeftHand.Little.Spread";
			case "Left Thumb Spread":
				return "LeftHand.Thumb.Spread";
			case "Right Index 1 Stretched":
				return "RightHand.Index.1 Stretched";
			case "Right Index 2 Stretched":
				return "RightHand.Index.2 Stretched";
			case "Right Index 3 Stretched":
				return "RightHand.Index.3 Stretched";
			case "Right Middle 1 Stretched":
				return "RightHand.Middle.1 Stretched";
			case "Right Middle 2 Stretched":
				return "RightHand.Middle.2 Stretched";
			case "Right Middle 3 Stretched":
				return "RightHand.Middle.3 Stretched";
			case "Right Ring 1 Stretched":
				return "RightHand.Ring.1 Stretched";
			case "Right Ring 2 Stretched":
				return "RightHand.Ring.2 Stretched";
			case "Right Ring 3 Stretched":
				return "RightHand.Ring.3 Stretched";
			case "Right Little 1 Stretched":
				return "RightHand.Little.1 Stretched";
			case "Right Little 2 Stretched":
				return "RightHand.Little.2 Stretched";
			case "Right Little 3 Stretched":
				return "RightHand.Little.3 Stretched";
			case "Right Thumb 1 Stretched":
				return "RightHand.Thumb.1 Stretched";
			case "Right Thumb 2 Stretched":
				return "RightHand.Thumb.2 Stretched";
			case "Right Thumb 3 Stretched":
				return "RightHand.Thumb.3 Stretched";
			case "Right Index Spread":
				return "RightHand.Index.Spread";
			case "Right Middle Spread":
				return "RightHand.Middle.Spread";
			case "Right Ring Spread":
				return "RightHand.Ring.Spread";
			case "Right Little Spread":
				return "RightHand.Little.Spread";
			case "Right Thumb Spread":
				return "RightHand.Thumb.Spread";
			default:
				return n;
			}
		}

		public void MultiplyLength(AnimationCurve curve, float mlp)
		{
			Keyframe[] keys = curve.keys;
			for (int i = 0; i < keys.Length; i++)
			{
				keys[i].time *= mlp;
			}
			curve.keys = keys;
		}

		public void SetCurves(ref AnimationClip clip, float maxError, float lengthMlp)
		{
			MultiplyLength(curve, lengthMlp);
			BakerUtilities.ReduceKeyframes(curve, maxError);
			clip.SetCurve(string.Empty, typeof(Animator), propertyName, curve);
		}

		public void Reset()
		{
			curve = new AnimationCurve();
		}

		public void SetKeyframe(float time, float[] muscles)
		{
			curve.AddKey(time, muscles[muscleIndex]);
		}

		public void SetLoopFrame(float time)
		{
			BakerUtilities.SetLoopFrame(time, curve);
		}
	}
}
