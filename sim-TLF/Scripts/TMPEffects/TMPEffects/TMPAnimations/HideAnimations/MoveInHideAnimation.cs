using System;
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
	[CreateAssetMenu(fileName = "new MoveInHideAnimation", menuName = "TMPEffects/Animations/Hide Animations/Built-in/MoveIn")]
	public class MoveInHideAnimation : TMPHideAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public TMPParameterTypes.TypedVector3 targetPosition;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully hide the character.\nAliases: duration, dur, d")]
		private float duration = 1f;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for getting the t-value to interpolate between the start and target position.\nAliases: curve, crv, c")]
		private AnimationCurve curve = AnimationCurveUtility.EaseInBack();

		[SerializeField]
		[AutoParameter("targetposition", new string[] { "targetpos", "target" })]
		[Tooltip("The postion to move the character to.\nAliases: targetposition, targetpos, target")]
		private TMPParameterTypes.TypedVector3 targetPosition = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, new Vector3(0f, 1250f, 0f));

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			IAnimatorContext animatorContext = context.AnimatorContext;
			float num = ((data.duration > 0f) ? Mathf.Clamp01((animatorContext.PassedTime - animatorContext.StateTime(cData)) / data.duration) : 1f);
			float t = data.curve.Evaluate(num);
			if (num >= 1f)
			{
				context.FinishAnimation(cData);
				return;
			}
			Vector3 position = Vector3.LerpUnclamped(b: data.targetPosition.type switch
			{
				TMPParameterTypes.VectorType.Position => data.targetPosition.vector, 
				TMPParameterTypes.VectorType.Anchor => TMPAnimationUtility.AnchorToPosition(data.targetPosition.vector, cData), 
				TMPParameterTypes.VectorType.Offset => cData.InitialPosition + data.targetPosition.vector, 
				_ => throw new NotImplementedException("type"), 
			}, a: cData.InitialPosition, t: t);
			cData.SetPosition(position);
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
				targetPosition = targetPosition
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
				if (TMPParameterUtility.TryGetTypedVector3Parameter(out var value3, parameters, keywordDatabase, "targetposition", "targetpos", "target"))
				{
					autoParametersData.targetPosition = value3;
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
			if (TMPParameterUtility.HasNonTypedVector3Parameter(parameters, keywordDatabase, "targetposition", "targetpos", "target"))
			{
				return false;
			}
			return true;
		}
	}
}
