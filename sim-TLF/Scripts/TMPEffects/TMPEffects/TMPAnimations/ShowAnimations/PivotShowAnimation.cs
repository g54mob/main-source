using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.ShowAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new PivotShowAnimation", menuName = "TMPEffects/Animations/Show Animations/Built-in/Pivot")]
	public class PivotShowAnimation : TMPShowAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public TMPParameterTypes.TypedVector2 pivot;

			public Vector3 startAngle;

			public Vector3 targetAngle;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully hide the character.\nAliases: duration, dur, d")]
		private float duration = 1f;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for getting the t-value to interpolate between the angles.\nAliases: curve, crv, c")]
		private AnimationCurve curve = AnimationCurveUtility.EaseOutBack();

		[SerializeField]
		[AutoParameter("pivot", new string[] { "pv", "p" })]
		[Tooltip("The pivot position of the rotation.\nAliases: pivot, pv, p")]
		private TMPParameterTypes.TypedVector2 pivot = new TMPParameterTypes.TypedVector2(TMPParameterTypes.VectorType.Anchor, Vector3.zero);

		[SerializeField]
		[AutoParameter("startangle", new string[] { "start" })]
		[Tooltip("The start euler angles.\nAliases: startangle, start")]
		private Vector3 startAngle = new Vector3(0f, 0f, 210f);

		[SerializeField]
		[AutoParameter("targetangle", new string[] { "target" })]
		[Tooltip("The start euler angles.\nAliases: targetangle, target")]
		private Vector3 targetAngle = Vector3.zero;

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			float num = Mathf.Lerp(0f, 1f, (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData)) / data.duration);
			if (num >= 1f)
			{
				context.FinishAnimation(cData);
			}
			float t = data.curve.Evaluate(num);
			Vector3 eulerAngles = Vector3.LerpUnclamped(data.startAngle, data.targetAngle, t);
			cData.AddRotation(eulerAngles, data.pivot.ToPosition(cData, context));
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
				pivot = pivot,
				startAngle = startAngle,
				targetAngle = targetAngle
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
				if (TMPParameterUtility.TryGetTypedVector2Parameter(out var value3, parameters, keywordDatabase, "pivot", "pv", "p"))
				{
					autoParametersData.pivot = value3;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value4, parameters, keywordDatabase, "startangle", "start"))
				{
					autoParametersData.startAngle = value4;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value5, parameters, keywordDatabase, "targetangle", "target"))
				{
					autoParametersData.targetAngle = value5;
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
			if (TMPParameterUtility.HasNonTypedVector2Parameter(parameters, keywordDatabase, "pivot", "pv", "p"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "startangle", "start"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "targetangle", "target"))
			{
				return false;
			}
			return true;
		}
	}
}
