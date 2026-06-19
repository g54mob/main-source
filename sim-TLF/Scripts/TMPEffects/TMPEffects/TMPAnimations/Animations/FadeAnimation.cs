using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new FadeAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Fade")]
	public class FadeAnimation : TMPAnimation
	{
		[AutoParametersStorage]
		private class AutoParametersData
		{
			public readonly float sqrt2 = Mathf.Sqrt(8f);

			public readonly float[] dists = new float[4];

			public float maxOpacity;

			public Vector3 fadeInAnchor;

			public Vector3 fadeInDirection;

			public float minOpacity;

			public Vector3 fadeOutAnchor;

			public Vector3 fadeOutDirection;

			public Wave wave;

			public OffsetBundle waveOffset;
		}

		[SerializeField]
		[AutoParameterBundle("")]
		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		private Wave wave;

		[SerializeField]
		[AutoParameterBundle("")]
		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		private OffsetBundle waveOffset;

		[SerializeField]
		[AutoParameter("maxopacity", new string[] { "maxop", "max" })]
		[Tooltip("The maximum opacity that is reached.\nAliases: maxopacity, maxop, max")]
		[Range(0f, 255f)]
		private float maxOpacity = 255f;

		[SerializeField]
		[AutoParameter("fadeinanchor", new string[] { "fianchor", "fianc", "fia" })]
		[Tooltip("The anchor used for fading in.\nAliases: fadeinanchor, fianchor, fianc, fia")]
		private Vector3 fadeInAnchor = Vector3.zero;

		[SerializeField]
		[AutoParameter("fadeindirection", new string[] { "fidirection", "fidir", "fid" })]
		[Tooltip("The direction to fade in in.\nAliases: fadeindirection, fidirection, fidir, fid")]
		private Vector3 fadeInDirection = Vector3.up;

		[SerializeField]
		[AutoParameter("minopacity", new string[] { "minop", "min" })]
		[Tooltip("The minimum opacity that is reached.\nAliases: minopacity, minop, min")]
		[Range(0f, 255f)]
		private float minOpacity;

		[SerializeField]
		[AutoParameter("fadeoutanchor", new string[] { "foanchor", "foanc", "foa" })]
		[Tooltip("The anchor used for fading out.\nAliases: fadeoutanchor, foanchor, foanc, foa")]
		private Vector3 fadeOutAnchor = Vector3Int.zero;

		[SerializeField]
		[AutoParameter("fadeoutdirection", new string[] { "fodirection", "fodir", "fod" })]
		[Tooltip("The direction to fade out in.\nAliases: fadeoutdirection, fodirection, fodir, fod")]
		private Vector3 fadeOutDirection = Vector3.up;

		private void FadeIn(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
			Vector2 v = d.fadeInAnchor;
			FixAnchor(ref v);
			if (v == Vector2.zero)
			{
				for (int i = 0; i < 4; i++)
				{
					float num = Mathf.Lerp(d.minOpacity, d.maxOpacity, t);
					Color32 color = cData.mesh.initial.GetColor(i);
					color.a = (byte)(num / 255f * (float)(int)color.a);
					cData.mesh.SetAlpha(i, (int)(byte)(num / 255f * (float)(int)color.a));
				}
				return;
			}
			Vector2 vector = new Vector2(0f - v.x, 0f - v.y);
			Vector2 anchor = vector;
			Vector3 vector2 = TMPAnimationUtility.AnchorToPosition(v, cData);
			Vector3 vector3 = TMPAnimationUtility.AnchorToPosition(anchor, cData);
			float magnitude = (vector2 - vector3).magnitude;
			for (int j = 0; j < 4; j++)
			{
				Vector3 vector4 = cData.mesh.initial.GetPosition(j) - vector2;
				vector4.x *= vector.x;
				vector4.y *= vector.y;
				float num2 = vector4.magnitude / magnitude;
				float num3 = Mathf.Lerp(d.minOpacity, d.maxOpacity, t * (2f - num2));
				Color32 color2 = cData.mesh.initial.GetColor(j);
				color2.a = (byte)(num3 / 255f * (float)(int)color2.a);
				cData.mesh.SetAlpha(j, (int)(byte)(num3 / 255f * (float)(int)color2.a));
			}
		}

		private void FadeOut(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
			Vector2 v = d.fadeOutAnchor;
			FixAnchor(ref v);
			if (v == Vector2.zero)
			{
				for (int i = 0; i < 4; i++)
				{
					float num = Mathf.Lerp(d.minOpacity, d.maxOpacity, t);
					Color32 color = cData.mesh.initial.GetColor(i);
					color.a = (byte)(num / 255f * (float)(int)color.a);
					cData.mesh.SetAlpha(i, (int)(byte)(num / 255f * (float)(int)color.a));
				}
				return;
			}
			Vector2 vector = new Vector2(0f - v.x, 0f - v.y);
			Vector2 anchor = vector;
			Vector3 vector2 = TMPAnimationUtility.AnchorToPosition(v, cData);
			Vector3 vector3 = TMPAnimationUtility.AnchorToPosition(anchor, cData);
			float magnitude = (vector2 - vector3).magnitude;
			for (int j = 0; j < 4; j++)
			{
				Vector3 vector4 = cData.mesh.initial.GetPosition(j) - vector2;
				vector4.x *= vector.x;
				vector4.y *= vector.y;
				float num2 = vector4.magnitude / magnitude;
				float num3 = Mathf.Lerp(d.minOpacity, d.maxOpacity, t * (2f - num2));
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
			(float, int) tuple = data.wave.Evaluate(context.AnimatorContext.PassedTime, data.waveOffset.GetOffset(cData, context));
			if (tuple.Item2 > 0)
			{
				FadeIn(cData, context, data, tuple.Item1);
			}
			else
			{
				FadeOut(cData, context, data, tuple.Item1);
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
				maxOpacity = maxOpacity,
				fadeInAnchor = fadeInAnchor,
				fadeInDirection = fadeInDirection,
				minOpacity = minOpacity,
				fadeOutAnchor = fadeOutAnchor,
				fadeOutDirection = fadeOutDirection,
				wave = wave,
				waveOffset = waveOffset
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, "maxopacity", "maxop", "max"))
				{
					autoParametersData.maxOpacity = value;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value2, parameters, keywordDatabase, "fadeinanchor", "fianchor", "fianc", "fia"))
				{
					autoParametersData.fadeInAnchor = value2;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value3, parameters, keywordDatabase, "fadeindirection", "fidirection", "fidir", "fid"))
				{
					autoParametersData.fadeInDirection = value3;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value4, parameters, keywordDatabase, "minopacity", "minop", "min"))
				{
					autoParametersData.minOpacity = value4;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value5, parameters, keywordDatabase, "fadeoutanchor", "foanchor", "foanc", "foa"))
				{
					autoParametersData.fadeOutAnchor = value5;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value6, parameters, keywordDatabase, "fadeoutdirection", "fodirection", "fodir", "fod"))
				{
					autoParametersData.fadeOutDirection = value6;
				}
				autoParametersData.wave = Wave.CreateWave(autoParametersData.wave, Wave.GetWaveParameters(parameters, keywordDatabase));
				autoParametersData.waveOffset = OffsetBundle.CreateOffsetBundle(autoParametersData.waveOffset, OffsetBundle.GetOffsetBundleParameters(parameters, keywordDatabase));
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "maxopacity", "maxop", "max"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "fadeinanchor", "fianchor", "fianc", "fia"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "fadeindirection", "fidirection", "fidir", "fid"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "minopacity", "minop", "min"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "fadeoutanchor", "foanchor", "foanc", "foa"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "fadeoutdirection", "fodirection", "fodir", "fod"))
			{
				return false;
			}
			if (!Wave.ValidateWaveParameters(parameters, keywordDatabase))
			{
				return false;
			}
			if (!OffsetBundle.ValidateOffsetBundleParameters(parameters, keywordDatabase))
			{
				return false;
			}
			return true;
		}
	}
}
