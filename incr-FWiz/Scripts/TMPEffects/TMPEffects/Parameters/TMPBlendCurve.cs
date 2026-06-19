using System;
using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Databases;
using TMPEffects.Parameters.Attributes;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Parameters
{
	[Serializable]
	[TMPParameterBundle("BlendCurve")]
	public class TMPBlendCurve
	{
		public struct BlendCurveParameters
		{
			public AnimationCurve curve;

			public ITMPOffsetProvider _provider;

			public float? uniformity;

			public bool? ignoreAnimatorScaling;

			public bool? finishWholeSegmentInTime;
		}

		[TMPParameterBundleField("curve", new string[] { "crv" })]
		public AnimationCurve curve;

		[TMPParameterBundleField("offset", new string[] { "off" })]
		private ITMPOffsetProvider _provider;

		[SerializeField]
		private OffsetTypePowerEnum offsetProvider;

		[TMPParameterBundleField("uniformity", new string[] { "uni" })]
		public float uniformity;

		[TMPParameterBundleField("ignorescaling", new string[] { "ignorescl", "ignscl", "ignscaling" })]
		public bool ignoreAnimatorScaling;

		[TMPParameterBundleField("ignoresegmentlength", new string[] { "ignoresegmentlen", "ignoreseglen", "ignseglen", "ignsegmentlength", "ignsegmentlen" })]
		public bool finishWholeSegmentInTime;

		public ITMPOffsetProvider provider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TMPBlendCurve()
		{
		}

		public TMPBlendCurve(TMPBlendCurve crv)
		{
		}

		public float EvaluateIn(float timeValue, float totalDuration, float minOffset, float maxOffset, float offset)
		{
			return 0f;
		}

		public float EvaluateIn(float timeValue, float totalDuration, CharData cData, IAnimatorDataProvider animatorData, ITMPSegmentData segmentData)
		{
			return 0f;
		}

		public float EvaluateIn(float timeValue, float duration, CharData cData, IAnimationContext context)
		{
			return 0f;
		}

		public float EvaluateOut(float timeValue, float totalDuration, float preTime, float minOffset, float maxOffset, float offset)
		{
			return 0f;
		}

		public float EvaluateOut(float timeValue, float totalDuration, float preTime, CharData cData, IAnimatorDataProvider animatorData, ITMPSegmentData segmentData)
		{
			return 0f;
		}

		public float EvaluateOut(float timeValue, float duration, float preTime, CharData cData, IAnimationContext context)
		{
			return 0f;
		}

		public static bool ValidateBlendCurveParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			return false;
		}

		public static BlendCurveParameters GetBlendCurveParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			return default(BlendCurveParameters);
		}

		public static TMPBlendCurve CreateBlendCurve(TMPBlendCurve TMPBlendCurveInstance, BlendCurveParameters parameters)
		{
			return null;
		}
	}
}
