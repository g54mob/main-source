using System;
using UnityEngine;

namespace EngineCore
{
	[Serializable]
	public class FogTargetTransitionParams
	{
		[Tooltip("The time it takes to move to the new viewtarget. <=0 means instant.")]
		public float BlendTime;

		public EFogTargetTransitionMode TransitionMode;

		[ConditionalEnumHide("TransitionMode", 1, false, EnumValue2 = 2, HideInInspector = true)]
		public float TransitionBlendExponent = 2f;

		[ConditionalEnumHide("TransitionMode", 3, false, HideInInspector = true)]
		public AnimationCurve TransitionCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public FogTargetTransitionParams()
		{
		}

		public FogTargetTransitionParams(float blendTime, bool lockOutGoing = true, EFogTargetTransitionMode transitionMode = EFogTargetTransitionMode.Linear, float transitionBlendExponent = 2f)
		{
			BlendTime = blendTime;
			TransitionMode = transitionMode;
			TransitionBlendExponent = transitionBlendExponent;
		}

		public void CopyFrom(FogTargetTransitionParams source)
		{
			BlendTime = source.BlendTime;
			TransitionMode = source.TransitionMode;
			TransitionBlendExponent = source.TransitionBlendExponent;
			TransitionCurve.keys = source.TransitionCurve.keys;
		}
	}
}
