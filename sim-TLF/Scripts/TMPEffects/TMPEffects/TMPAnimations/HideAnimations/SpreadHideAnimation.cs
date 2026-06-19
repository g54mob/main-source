using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.HideAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new SpreadHideAnimation", menuName = "TMPEffects/Animations/Hide Animations/Built-in/Spread")]
	public class SpreadHideAnimation : TMPHideAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public TMPParameterTypes.TypedVector2 anchor;

			public Vector3 direction;

			public float startPercentage;

			public float targetPercentage;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully hide the character.\nAliases: duration, dur, d")]
		private float duration = 1f;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for getting the t-value to interpolate between the percentages.\nAliases: curve, crv, c")]
		private AnimationCurve curve = AnimationCurveUtility.EaseOutElastic();

		[SerializeField]
		[AutoParameter("anchor", new string[] { "anc", "a" })]
		[Tooltip("The anchor from where the character spreads.\nAliases: anchor, anc, a")]
		private TMPParameterTypes.TypedVector2 anchor = new TMPParameterTypes.TypedVector2(TMPParameterTypes.VectorType.Anchor, Vector2.zero);

		[SerializeField]
		[AutoParameter("direction", new string[] { "dir" })]
		[Tooltip("The direction in which the character spreads.\nAliases: direction, dir")]
		private Vector3 direction = Vector3.up;

		[SerializeField]
		[AutoParameter("startpercentage", new string[] { "start" })]
		[Tooltip("The start percentage of the spread, 0 being fully hidden.\nAliases: startpercentage, start")]
		private float startPercentage = 1f;

		[SerializeField]
		[AutoParameter("targetpercentage", new string[] { "target" })]
		[Tooltip("The target percentage of the spread, 1 being fully shown.\nAliases: targetpercentage, target")]
		private float targetPercentage;

		private void Grow(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
			float t2 = Mathf.LerpUnclamped(d.startPercentage, d.targetPercentage, t);
			Vector2 vector = new Vector2(0f - d.direction.y, d.direction.x);
			Vector3 lineStart;
			Vector3 lineEnd;
			switch (d.anchor.type)
			{
			case TMPParameterTypes.VectorType.Offset:
				lineStart = cData.InitialPosition + (Vector3)(d.anchor.vector - vector * 2f);
				lineEnd = cData.InitialPosition + (Vector3)(d.anchor.vector + vector * 2f);
				break;
			case TMPParameterTypes.VectorType.Anchor:
				lineStart = TMPAnimationUtility.AnchorToPosition(d.anchor.vector - vector * 2f, cData);
				lineEnd = TMPAnimationUtility.AnchorToPosition(d.anchor.vector + vector * 2f, cData);
				break;
			case TMPParameterTypes.VectorType.Position:
				lineStart = d.anchor.vector - vector * 2f;
				lineEnd = d.anchor.vector + vector * 2f;
				break;
			default:
				throw new NotImplementedException("type");
			}
			for (int i = 0; i < 4; i++)
			{
				Vector3 position = Vector3.LerpUnclamped(TMPAnimationUtility.ClosestPointOnLine(lineStart, lineEnd, cData.mesh.initial.GetPosition(i)), cData.mesh.initial.GetPosition(i), t2);
				TMPAnimationUtility.SetVertexRaw(i, position, cData, context);
			}
		}

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			float num = Mathf.Lerp(data.startPercentage, data.targetPercentage, (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData)) / data.duration);
			float t = data.curve.Evaluate(1f - num);
			if (Mathf.Lerp(0f, 1f, (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData)) / data.duration) >= 1f)
			{
				context.FinishAnimation(cData);
			}
			Grow(cData, context, data, t);
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
				anchor = anchor,
				direction = direction,
				startPercentage = startPercentage,
				targetPercentage = targetPercentage
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
				if (TMPParameterUtility.TryGetTypedVector2Parameter(out var value3, parameters, keywordDatabase, "anchor", "anc", "a"))
				{
					autoParametersData.anchor = value3;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value4, parameters, keywordDatabase, "direction", "dir"))
				{
					autoParametersData.direction = value4;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value5, parameters, keywordDatabase, "startpercentage", "start"))
				{
					autoParametersData.startPercentage = value5;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value6, parameters, keywordDatabase, "targetpercentage", "target"))
				{
					autoParametersData.targetPercentage = value6;
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
			if (TMPParameterUtility.HasNonTypedVector2Parameter(parameters, keywordDatabase, "anchor", "anc", "a"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "direction", "dir"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "startpercentage", "start"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "targetpercentage", "target"))
			{
				return false;
			}
			return true;
		}
	}
}
