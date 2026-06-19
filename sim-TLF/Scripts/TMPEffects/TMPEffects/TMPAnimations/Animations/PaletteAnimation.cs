using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new PaletteAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Palette")]
	public class PaletteAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public Color[] colors;

			public Wave wave;

			public OffsetBundle waveOffset;
		}

		[SerializeField]
		[AutoParameterBundle("")]
		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about Wave, see the section on it in the documentation.")]
		private Wave wave;

		[SerializeField]
		[AutoParameterBundle("")]
		[Tooltip("The way the offset for the wave is calculated.\nFor more information about Wave, see the section on it in the documentation.\nAliases: waveoffset, woffset, waveoff, woff")]
		private OffsetBundle waveOffset;

		[SerializeField]
		[AutoParameter("colors", new string[] { "clrs" })]
		[Tooltip("The colors to cycle through.\nAliases: colors, clrs")]
		private Color[] colors;

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			(float, int) tuple = data.wave.Evaluate(context.AnimatorContext.PassedTime, data.waveOffset.GetOffset(cData, context));
			float num = Mathf.Abs((float)data.colors.Length * ((data.wave.Amplitude == 0f) ? 0f : (tuple.Item1 / data.wave.Amplitude)));
			int num2 = (int)num;
			if (num == 0f)
			{
				for (int i = 0; i < 4; i++)
				{
					cData.mesh.SetColor(i, data.colors[0], ignoreAlpha: true);
				}
				return;
			}
			if (num == (float)data.colors.Length)
			{
				for (int j = 0; j < 4; j++)
				{
					cData.mesh.SetColor(j, data.colors[0], ignoreAlpha: true);
				}
				return;
			}
			Color color;
			if (tuple.Item2 == 1)
			{
				float t = num % 1f;
				Color a = data.colors[num2];
				Color b = ((num2 != data.colors.Length - 1) ? data.colors[num2 + 1] : data.colors[0]);
				color = Color.Lerp(a, b, t);
			}
			else
			{
				if (tuple.Item2 != -1)
				{
					throw new Exception("Shouldnt be possible");
				}
				float t = num % 1f;
				Color a2 = data.colors[data.colors.Length - 1 - num2];
				Color b = ((num2 != 0) ? data.colors[data.colors.Length - num2] : data.colors[0]);
				color = Color.Lerp(a2, b, 1f - t);
			}
			for (int k = 0; k < 4; k++)
			{
				cData.mesh.SetColor(k, color, ignoreAlpha: true);
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
				colors = colors,
				wave = wave,
				waveOffset = waveOffset
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetArrayParameter(out Color[] value, parameters, (TMPParameterUtility.ParseDelegate<string, Color, ITMPKeywordDatabase, bool>)ParameterParsing.StringToColor, keywordDatabase, "colors", "clrs"))
				{
					autoParametersData.colors = value;
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
			if (TMPParameterUtility.HasNonArrayParameter<Color>(parameters, ParameterParsing.StringToColor, keywordDatabase, "colors", new string[1] { "clrs" }))
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
