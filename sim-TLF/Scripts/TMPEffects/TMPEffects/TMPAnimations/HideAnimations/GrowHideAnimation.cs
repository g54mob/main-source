using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.HideAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new GrowHideAnimation", menuName = "TMPEffects/Animations/Hide Animations/Built-in/Grow")]
	public class GrowHideAnimation : TMPHideAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public Vector3 targetScale;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully show the character.\nAliases: duration, dur, d")]
		private float duration = 0.15f;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for getting the t-value to interpolate between the scales.\nAliases: curve, crv, c")]
		private AnimationCurve curve = AnimationCurveUtility.EaseOutSine();

		[SerializeField]
		[AutoParameter("targetscale", new string[] { "targetscl", "target" })]
		[Tooltip("The scale to grow to from the initial scale.\nAliases: targetscale, targetscl, target")]
		private Vector3 targetScale = Vector3.one * 2f;

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			IAnimatorContext animatorContext = context.AnimatorContext;
			float num = ((data.duration > 0f) ? Mathf.Clamp01((animatorContext.PassedTime - animatorContext.StateTime(cData)) / data.duration) : 1f);
			float t = data.curve.Evaluate(num);
			Vector3 scale = Vector3.LerpUnclamped(cData.InitialScale, data.targetScale, t);
			cData.SetScale(scale);
			if (num >= 1f)
			{
				context.FinishAnimation(cData);
			}
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
			AutoParametersData data = context.CustomData as AutoParametersData;
			Animate(cData, data, context);
		}

		public override object GetNewCustomData()
		{
			return new AutoParametersData
			{
				duration = duration,
				curve = curve,
				targetScale = targetScale
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, "duration", "dur", "d"))
				{
					autoParametersData.duration = value;
				}
				if (TMPParameterUtility.TryGetAnimCurveParameter(out var value2, parameters, keywordDatabase, "curve", "crv", "c"))
				{
					autoParametersData.curve = value2;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value3, parameters, keywordDatabase, "targetscale", "targetscl", "target"))
				{
					autoParametersData.targetScale = value3;
				}
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "duration", "dur", "d"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywordDatabase, "curve", "crv", "c"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "targetscale", "targetscl", "target"))
			{
				return false;
			}
			return true;
		}
	}
}
