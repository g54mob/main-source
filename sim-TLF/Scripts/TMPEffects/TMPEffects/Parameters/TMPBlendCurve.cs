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
		private OffsetTypePowerEnum offsetProvider = new OffsetTypePowerEnum();

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
				return _provider ?? offsetProvider;
			}
			set
			{
				_provider = value;
			}
		}

		public TMPBlendCurve()
		{
		}

		public TMPBlendCurve(TMPBlendCurve crv)
		{
			curve = crv.curve;
			uniformity = crv.uniformity;
			_provider = crv._provider;
			offsetProvider = crv.offsetProvider;
			ignoreAnimatorScaling = crv.ignoreAnimatorScaling;
			finishWholeSegmentInTime = crv.finishWholeSegmentInTime;
		}

		public float EvaluateIn(float timeValue, float totalDuration, float minOffset, float maxOffset, float offset)
		{
			offset -= minOffset;
			maxOffset -= minOffset;
			if (uniformity < 0f)
			{
				offset = maxOffset - offset;
			}
			if (finishWholeSegmentInTime)
			{
				float num = maxOffset * Mathf.Abs(uniformity) / totalDuration + 1f;
				num = 1f / num;
				timeValue -= offset * num * Mathf.Abs(uniformity);
				return curve.Evaluate(timeValue / totalDuration / num);
			}
			timeValue -= offset * Mathf.Abs(uniformity);
			return curve.Evaluate(timeValue / totalDuration);
		}

		public float EvaluateIn(float timeValue, float totalDuration, CharData cData, IAnimatorDataProvider animatorData, ITMPSegmentData segmentData)
		{
			float offset = provider.GetOffset(cData, segmentData, animatorData, ignoreAnimatorScaling);
			provider.GetMinMaxOffset(out var min, out var max, segmentData, animatorData);
			return EvaluateIn(timeValue, totalDuration, min, max, offset);
		}

		public float EvaluateIn(float timeValue, float duration, CharData cData, IAnimationContext context)
		{
			return EvaluateIn(timeValue, duration, cData, context.AnimatorContext, context.SegmentData);
		}

		public float EvaluateOut(float timeValue, float totalDuration, float preTime, float minOffset, float maxOffset, float offset)
		{
			offset -= minOffset;
			maxOffset -= minOffset;
			if (uniformity < 0f)
			{
				offset = maxOffset - offset;
			}
			if (finishWholeSegmentInTime)
			{
				float num = maxOffset * Mathf.Abs(uniformity) / totalDuration + 1f;
				num = 1f / num;
				timeValue -= offset * num * Mathf.Abs(uniformity);
				return curve.Evaluate(1f - (timeValue - preTime) / totalDuration / num);
			}
			timeValue -= offset * Mathf.Abs(uniformity);
			return curve.Evaluate(1f - (timeValue - preTime) / totalDuration);
		}

		public float EvaluateOut(float timeValue, float totalDuration, float preTime, CharData cData, IAnimatorDataProvider animatorData, ITMPSegmentData segmentData)
		{
			float offset = provider.GetOffset(cData, segmentData, animatorData, ignoreAnimatorScaling);
			provider.GetMinMaxOffset(out var min, out var max, segmentData, animatorData);
			return EvaluateOut(timeValue, totalDuration, preTime, min, max, offset);
		}

		public float EvaluateOut(float timeValue, float duration, float preTime, CharData cData, IAnimationContext context)
		{
			return EvaluateOut(timeValue, duration, preTime, cData, context.AnimatorContext, context.SegmentData);
		}

		public static bool ValidateBlendCurveParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywords, prefix + "curve", prefix + "crv"))
			{
				return false;
			}
			if (ITMPOffsetProvider.HasNonOffsetProviderParameter(parameters, keywords, prefix + "offset", prefix + "off"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywords, prefix + "uniformity", prefix + "uni"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonBoolParameter(parameters, keywords, prefix + "ignorescaling", prefix + "ignorescl", prefix + "ignscl", prefix + "ignscaling"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonBoolParameter(parameters, keywords, prefix + "ignoresegmentlength", prefix + "ignoresegmentlen", prefix + "ignoreseglen", prefix + "ignseglen", prefix + "ignsegmentlength", prefix + "ignsegmentlen"))
			{
				return false;
			}
			return true;
		}

		public static BlendCurveParameters GetBlendCurveParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywords = null, string prefix = "")
		{
			BlendCurveParameters result = default(BlendCurveParameters);
			if (parameters == null)
			{
				return result;
			}
			if (TMPParameterUtility.TryGetAnimCurveParameter(out var value, parameters, keywords, prefix + "curve", prefix + "crv"))
			{
				result.curve = value;
			}
			if (ITMPOffsetProvider.TryGetOffsetProviderParameter(out var value2, parameters, keywords, prefix + "offset", prefix + "off"))
			{
				result._provider = value2;
			}
			if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywords, prefix + "uniformity", prefix + "uni"))
			{
				result.uniformity = value3;
			}
			if (TMPParameterUtility.TryGetBoolParameter(out var value4, parameters, keywords, prefix + "ignorescaling", prefix + "ignorescl", prefix + "ignscl", prefix + "ignscaling"))
			{
				result.ignoreAnimatorScaling = value4;
			}
			if (TMPParameterUtility.TryGetBoolParameter(out var value5, parameters, keywords, prefix + "ignoresegmentlength", prefix + "ignoresegmentlen", prefix + "ignoreseglen", prefix + "ignseglen", prefix + "ignsegmentlength", prefix + "ignsegmentlen"))
			{
				result.finishWholeSegmentInTime = value5;
			}
			return result;
		}

		public static TMPBlendCurve CreateBlendCurve(TMPBlendCurve TMPBlendCurveInstance, BlendCurveParameters parameters)
		{
			return new TMPBlendCurve
			{
				curve = (parameters.curve ?? TMPBlendCurveInstance.curve),
				_provider = (parameters._provider ?? TMPBlendCurveInstance._provider),
				uniformity = (parameters.uniformity ?? TMPBlendCurveInstance.uniformity),
				ignoreAnimatorScaling = (parameters.ignoreAnimatorScaling ?? TMPBlendCurveInstance.ignoreAnimatorScaling),
				finishWholeSegmentInTime = (parameters.finishWholeSegmentInTime ?? TMPBlendCurveInstance.finishWholeSegmentInTime)
			};
		}
	}
}
