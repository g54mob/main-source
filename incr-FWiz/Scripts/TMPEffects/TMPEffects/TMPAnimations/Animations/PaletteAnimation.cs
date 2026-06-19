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
		[AutoParameterBundle(null)]
		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about Wave, see the section on it in the documentation.")]
		private Wave wave;

		[SerializeField]
		[AutoParameterBundle(null)]
		[Tooltip("The way the offset for the wave is calculated.\nFor more information about Wave, see the section on it in the documentation.\nAliases: waveoffset, woffset, waveoff, woff")]
		private OffsetBundle waveOffset;

		[SerializeField]
		[AutoParameter("colors", new string[] { "clrs" })]
		[Tooltip("The colors to cycle through.\nAliases: colors, clrs")]
		private Color[] colors;

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
		}

		public override object GetNewCustomData()
		{
			return null;
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}
	}
}
