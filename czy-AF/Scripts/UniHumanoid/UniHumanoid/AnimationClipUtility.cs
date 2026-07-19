using System.Collections.Generic;
using UnityEngine;

namespace UniHumanoid
{
	public static class AnimationClipUtility
	{
		private static Dictionary<string, string> TraitPropMap = new Dictionary<string, string>
		{
			{ "Left Thumb 1 Stretched", "LeftHand.Thumb.1 Stretched" },
			{ "Left Thumb Spread", "LeftHand.Thumb Spread" },
			{ "Left Thumb 2 Stretched", "LeftHand.Thumb.2 Stretched" },
			{ "Left Thumb 3 Stretched", "LeftHand.Thumb.3 Stretched" },
			{ "Left Index 1 Stretched", "LeftHand.Index.1 Stretched" },
			{ "Left Index Spread", "LeftHand.Index Spread" },
			{ "Left Index 2 Stretched", "LeftHand.Index.2 Stretched" },
			{ "Left Index 3 Stretched", "LeftHand.Index.3 Stretched" },
			{ "Left Middle 1 Stretched", "LeftHand.Middle.1 Stretched" },
			{ "Left Middle Spread", "LeftHand.Middle Spread" },
			{ "Left Middle 2 Stretched", "LeftHand.Middle.2 Stretched" },
			{ "Left Middle 3 Stretched", "LeftHand.Middle.3 Stretched" },
			{ "Left Ring 1 Stretched", "LeftHand.Ring.1 Stretched" },
			{ "Left Ring Spread", "LeftHand.Ring Spread" },
			{ "Left Ring 2 Stretched", "LeftHand.Ring.2 Stretched" },
			{ "Left Ring 3 Stretched", "LeftHand.Ring.3 Stretched" },
			{ "Left Little 1 Stretched", "LeftHand.Little.1 Stretched" },
			{ "Left Little Spread", "LeftHand.Little Spread" },
			{ "Left Little 2 Stretched", "LeftHand.Little.2 Stretched" },
			{ "Left Little 3 Stretched", "LeftHand.Little.3 Stretched" },
			{ "Right Thumb 1 Stretched", "RightHand.Thumb.1 Stretched" },
			{ "Right Thumb Spread", "RightHand.Thumb Spread" },
			{ "Right Thumb 2 Stretched", "RightHand.Thumb.2 Stretched" },
			{ "Right Thumb 3 Stretched", "RightHand.Thumb.3 Stretched" },
			{ "Right Index 1 Stretched", "RightHand.Index.1 Stretched" },
			{ "Right Index Spread", "RightHand.Index Spread" },
			{ "Right Index 2 Stretched", "RightHand.Index.2 Stretched" },
			{ "Right Index 3 Stretched", "RightHand.Index.3 Stretched" },
			{ "Right Middle 1 Stretched", "RightHand.Middle.1 Stretched" },
			{ "Right Middle Spread", "RightHand.Middle Spread" },
			{ "Right Middle 2 Stretched", "RightHand.Middle.2 Stretched" },
			{ "Right Middle 3 Stretched", "RightHand.Middle.3 Stretched" },
			{ "Right Ring 1 Stretched", "RightHand.Ring.1 Stretched" },
			{ "Right Ring Spread", "RightHand.Ring Spread" },
			{ "Right Ring 2 Stretched", "RightHand.Ring.2 Stretched" },
			{ "Right Ring 3 Stretched", "RightHand.Ring.3 Stretched" },
			{ "Right Little 1 Stretched", "RightHand.Little.1 Stretched" },
			{ "Right Little Spread", "RightHand.Little Spread" },
			{ "Right Little 2 Stretched", "RightHand.Little.2 Stretched" },
			{ "Right Little 3 Stretched", "RightHand.Little.3 Stretched" }
		};

		public static AnimationClip CreateAnimationClipFromHumanPose(HumanPose pose)
		{
			AnimationClip animationClip = new AnimationClip();
			AnimationCurve curve = new AnimationCurve(new Keyframe(0f, pose.bodyPosition.x));
			string propertyName = "RootT.x";
			animationClip.SetCurve(null, typeof(Animator), propertyName, curve);
			AnimationCurve curve2 = new AnimationCurve(new Keyframe(0f, pose.bodyPosition.y));
			string propertyName2 = "RootT.y";
			animationClip.SetCurve(null, typeof(Animator), propertyName2, curve2);
			AnimationCurve curve3 = new AnimationCurve(new Keyframe(0f, pose.bodyPosition.z));
			string propertyName3 = "RootT.z";
			animationClip.SetCurve(null, typeof(Animator), propertyName3, curve3);
			AnimationCurve curve4 = new AnimationCurve(new Keyframe(0f, pose.bodyRotation.x));
			string propertyName4 = "RootQ.x";
			animationClip.SetCurve(null, typeof(Animator), propertyName4, curve4);
			AnimationCurve curve5 = new AnimationCurve(new Keyframe(0f, pose.bodyRotation.y));
			string propertyName5 = "RootQ.y";
			animationClip.SetCurve(null, typeof(Animator), propertyName5, curve5);
			AnimationCurve curve6 = new AnimationCurve(new Keyframe(0f, pose.bodyRotation.z));
			string propertyName6 = "RootQ.z";
			animationClip.SetCurve(null, typeof(Animator), propertyName6, curve6);
			AnimationCurve curve7 = new AnimationCurve(new Keyframe(0f, pose.bodyRotation.w));
			string propertyName7 = "RootQ.w";
			animationClip.SetCurve(null, typeof(Animator), propertyName7, curve7);
			for (int i = 0; i < HumanTrait.MuscleCount; i++)
			{
				AnimationCurve curve8 = new AnimationCurve(new Keyframe(0f, pose.muscles[i]));
				string text = HumanTrait.MuscleName[i];
				if (TraitPropMap.ContainsKey(text))
				{
					text = TraitPropMap[text];
				}
				animationClip.SetCurve(null, typeof(Animator), text, curve8);
			}
			return animationClip;
		}
	}
}
