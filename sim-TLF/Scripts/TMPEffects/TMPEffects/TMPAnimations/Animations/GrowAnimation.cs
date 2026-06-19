using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new GrowAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Grow")]
	public class GrowAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public float maxScale;

			public float minScale;

			public Wave wave;

			public OffsetBundle offsetProvider;
		}

		[SerializeField]
		[AutoParameterBundle("")]
		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		private Wave wave = new Wave(AnimationCurveUtility.EaseInOutSine(), AnimationCurveUtility.EaseInOutSine(), 0.3f, 0.3f, 1f, 0f, 1f);

		[SerializeField]
		[AutoParameterBundle("")]
		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		private OffsetBundle offsetProvider;

		[SerializeField]
		[AutoParameter("maxscale", new string[] { "maxscl", "max" })]
		[Tooltip("The maximum scale to grow to.\nAliases: maxscale, maxscl, max")]
		private float maxScale = 1.25f;

		[SerializeField]
		[AutoParameter("minscale", new string[] { "minscl", "min" })]
		[Tooltip("The minimum scale to shrink to.\nAliases: minscale, minscl, min")]
		private float minScale = 1f;

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			(float, int) tuple = data.wave.Evaluate(context.AnimatorContext.PassedTime, data.offsetProvider.GetOffset(cData, context));
			float num = Mathf.LerpUnclamped(data.minScale, data.maxScale, tuple.Item1);
			cData.SetScale(Vector3.one * num);
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
				maxScale = maxScale,
				minScale = minScale,
				wave = wave,
				offsetProvider = offsetProvider
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, "maxscale", "maxscl", "max"))
				{
					autoParametersData.maxScale = value;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value2, parameters, keywordDatabase, "minscale", "minscl", "min"))
				{
					autoParametersData.minScale = value2;
				}
				autoParametersData.wave = Wave.CreateWave(autoParametersData.wave, Wave.GetWaveParameters(parameters, keywordDatabase));
				autoParametersData.offsetProvider = OffsetBundle.CreateOffsetBundle(autoParametersData.offsetProvider, OffsetBundle.GetOffsetBundleParameters(parameters, keywordDatabase));
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "maxscale", "maxscl", "max"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "minscale", "minscl", "min"))
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
