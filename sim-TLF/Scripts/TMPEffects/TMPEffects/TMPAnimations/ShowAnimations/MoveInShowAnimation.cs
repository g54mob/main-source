using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.ShowAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new MoveInShowAnimation", menuName = "TMPEffects/Animations/Show Animations/Built-in/MoveIn")]
	public class MoveInShowAnimation : TMPShowAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public TMPParameterTypes.TypedVector3 startPosition;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully show the character.\nAliases: duration, dur, d")]
		private float duration = 1f;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for getting the t-value to interpolate between the start and target position.\nAliases: curve, crv, c")]
		private AnimationCurve curve = AnimationCurveUtility.EaseOutElastic();

		[SerializeField]
		[AutoParameter("startposition", new string[] { "startpos", "start" })]
		[Tooltip("The postion to move the character in from.\nAliases: startposition, startpos, start")]
		private TMPParameterTypes.TypedVector3 startPosition = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Offset, Vector3.one * 100f);

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			IAnimatorContext animatorContext = context.AnimatorContext;
			float num = ((data.duration > 0f) ? Mathf.Clamp01((animatorContext.PassedTime - animatorContext.StateTime(cData)) / data.duration) : 1f);
			float t = data.curve.Evaluate(num);
			Vector3 position = Vector3.LerpUnclamped(data.startPosition.type switch
			{
				TMPParameterTypes.VectorType.Position => data.startPosition.vector, 
				TMPParameterTypes.VectorType.Anchor => TMPAnimationUtility.AnchorToPosition(data.startPosition.vector, cData), 
				TMPParameterTypes.VectorType.Offset => cData.InitialPosition + data.startPosition.vector, 
				_ => throw new NotImplementedException("type"), 
			}, cData.InitialPosition, t);
			cData.SetPosition(position);
			if (num == 1f)
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
				startPosition = startPosition
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
				if (TMPParameterUtility.TryGetTypedVector3Parameter(out var value3, parameters, keywordDatabase, "startposition", "startpos", "start"))
				{
					autoParametersData.startPosition = value3;
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
			if (TMPParameterUtility.HasNonTypedVector3Parameter(parameters, keywordDatabase, "startposition", "startpos", "start"))
			{
				return false;
			}
			return true;
		}
	}
}
