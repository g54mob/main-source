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
	[CreateAssetMenu(fileName = "new FadeHideAnimation", menuName = "TMPEffects/Animations/Hide Animations/Built-in/Fade")]
	public class FadeHideAnimation : TMPHideAnimation
	{
		private class AutoParametersData
		{
			public float duration;

			public AnimationCurve curve;

			public float targetOpacity;

			public Vector3 anchor;

			public Vector3 direction;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully hide the character.\nAliases: duration, dur, d")]
		private float duration = 1f;

		[SerializeField]
		[AutoParameter("curve", new string[] { "crv", "c" })]
		[Tooltip("The curve used for fading out.\nAliases: curve, crv, c")]
		private AnimationCurve curve = AnimationCurveUtility.EaseOutSine();

		[SerializeField]
		[AutoParameter("targetopacity", new string[] { "targetop", "target" })]
		[Tooltip("The opacity that is faded out to.\nAliases: targetopacity, targetop, target")]
		private float targetOpacity;

		[SerializeField]
		[AutoParameter("anchor", new string[] { "anc", "a" })]
		[Tooltip("The anchor that is faded out from.\nAliases: anchor, anc, a")]
		private Vector3 anchor = Vector3.zero;

		[SerializeField]
		[AutoParameter("direction", new string[] { "dir" })]
		[Tooltip("The direction used for fading out.\nAliases: direction, dir")]
		private Vector3 direction = Vector3.up;

		private void FadeOut(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
			Vector2 v = d.anchor;
			FixAnchor(ref v);
			if (v == Vector2.zero)
			{
				for (int i = 0; i < 4; i++)
				{
					float num = Mathf.Lerp((int)cData.info.color.a, d.targetOpacity, t);
					Color32 color = cData.mesh.initial.GetColor(i);
					color.a = (byte)(num / 255f * (float)(int)color.a);
					cData.mesh.SetAlpha(i, (int)(byte)(num / 255f * (float)(int)color.a));
				}
				return;
			}
			Vector2 vector = new Vector2(0f - v.x, 0f - v.y);
			Vector2 vector2 = vector;
			Vector3 vector3 = TMPAnimationUtility.AnchorToPosition(v, cData);
			Vector3 vector4 = TMPAnimationUtility.AnchorToPosition(vector2, cData);
			float magnitude = (vector3 - vector4).magnitude;
			for (int j = 0; j < 4; j++)
			{
				Vector3 vector5 = cData.mesh.initial.GetPosition(j) - vector3;
				vector5.x *= vector.x;
				vector5.y *= vector.y;
				float num2 = vector5.magnitude / magnitude;
				float num3 = Mathf.Lerp((int)cData.info.color.a, d.targetOpacity, t * (2f - num2));
				Color32 color2 = cData.mesh.initial.GetColor(j);
				color2.a = (byte)(num3 / 255f * (float)(int)color2.a);
				cData.mesh.SetAlpha(j, (int)(byte)(num3 / 255f * (float)(int)color2.a));
			}
		}

		private void FixAnchor(ref Vector2 v)
		{
			if (v.x != 0f)
			{
				if (v.x > 0f)
				{
					v.x = 1f;
				}
				else
				{
					v.x = -1f;
				}
			}
			if (v.y != 0f)
			{
				if (v.y > 0f)
				{
					v.y = 1f;
				}
				else
				{
					v.y = -1f;
				}
			}
		}

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			IAnimatorContext animatorContext = context.AnimatorContext;
			float num = ((data.duration > 0f) ? Mathf.Clamp01((animatorContext.PassedTime - animatorContext.StateTime(cData)) / data.duration) : 1f);
			float t = data.curve.Evaluate(num);
			if (num == 1f)
			{
				context.FinishAnimation(cData);
			}
			FadeOut(cData, context, data, t);
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
				targetOpacity = targetOpacity,
				anchor = anchor,
				direction = direction
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
				if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywordDatabase, "targetopacity", "targetop", "target"))
				{
					autoParametersData.targetOpacity = value3;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value4, parameters, keywordDatabase, "anchor", "anc", "a"))
				{
					autoParametersData.anchor = value4;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value5, parameters, keywordDatabase, "direction", "dir"))
				{
					autoParametersData.direction = value5;
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
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "targetopacity", "targetop", "target"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "anchor", "anc", "a"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "direction", "dir"))
			{
				return false;
			}
			return true;
		}
	}
}
