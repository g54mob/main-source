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
	[CreateAssetMenu(fileName = "new WaveAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Wave")]
	public class WaveAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public OffsetBundle offsetProvider;

			public Wave wave;
		}

		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		[SerializeField]
		[AutoParameterBundle("")]
		private OffsetBundle offsetProvider = new OffsetBundle();

		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		[SerializeField]
		[AutoParameterBundle("")]
		private Wave wave = new Wave(AnimationCurveUtility.EaseInOutSine(), AnimationCurveUtility.EaseInOutSine(), 0.5f, 0.5f, 1f, 0f, 0f);

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			float item = data.wave.Evaluate(context.AnimatorContext.PassedTime, data.offsetProvider.GetOffset(cData, context)).Value;
			cData.PositionDelta = Vector3.up * item;
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
				offsetProvider = offsetProvider,
				wave = wave
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData obj = (AutoParametersData)customData;
				obj.offsetProvider = OffsetBundle.CreateOffsetBundle(obj.offsetProvider, OffsetBundle.GetOffsetBundleParameters(parameters, keywordDatabase));
				obj.wave = Wave.CreateWave(obj.wave, Wave.GetWaveParameters(parameters, keywordDatabase));
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (!OffsetBundle.ValidateOffsetBundleParameters(parameters, keywordDatabase))
			{
				return false;
			}
			if (!Wave.ValidateWaveParameters(parameters, keywordDatabase))
			{
				return false;
			}
			return true;
		}
	}
}
