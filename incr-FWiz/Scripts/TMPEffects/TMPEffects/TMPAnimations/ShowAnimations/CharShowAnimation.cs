using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPro;
using UnityEngine;

namespace TMPEffects.TMPAnimations.ShowAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new CharShowAnimation", menuName = "TMPEffects/Animations/Show Animations/Built-in/Char")]
	public class CharShowAnimation : TMPShowAnimation
	{
		[AutoParametersStorage]
		private class Data
		{
			public bool init;

			public System.Random random;

			public Dictionary<int, TMP_Character> currentCharacterCache;

			public Dictionary<int, TMP_Character> originalCharacterCache;

			public Dictionary<int, float> lastUpdatedDict;

			public Dictionary<int, float> delayDict;

			public Dictionary<int, System.Random> rngDict;

			public float duration;

			public string characters;

			public float probability;

			public float minWait;

			public float maxWait;

			public bool autoCase;

			public AnimationCurve waitCurve;

			public AnimationCurve probabilityCurve;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully hide the character.\nAliases: duration, dur, d")]
		private float duration;

		[SerializeField]
		[AutoParameter("chars", new string[] { "char", "c" })]
		[Tooltip("The pool of characters to change to.\nAliases: characters, chars, char, c")]
		private string characters;

		[SerializeField]
		[AutoParameter("probability", new string[] { "prob", "p" })]
		[Tooltip("The probability to change to a character different from the original.\nAliases: probability, prob, p")]
		private float probability;

		[SerializeField]
		[AutoParameter("minwait", new string[] { "minw", "min" })]
		[Tooltip("The minimum amount of time to wait once a character changed (or did not change).\nAliases: minwait, minw, min")]
		private float minWait;

		[SerializeField]
		[AutoParameter("maxwait", new string[] { "maxw", "max" })]
		[Tooltip("The maximum amount of time to wait once a character changed (or did not change).\nAliases: maxwait, maxw, max")]
		private float maxWait;

		[SerializeField]
		[AutoParameter("autocase", new string[] { "case" })]
		[Tooltip("Whether to ensure capitalized characters are only changed to other capitalized characters, and vice versa.\nautocase, case")]
		private bool autoCase;

		[SerializeField]
		[AutoParameter("waitcurve", new string[] { "waitcrv", "waitc" })]
		[Tooltip("The curve that defines the falloff of the wait between each change.\nAliases: waitcurve, waitcrv, waitc")]
		private AnimationCurve waitCurve;

		[SerializeField]
		[AutoParameter("probabilitycurve", new string[] { "probabilitycrv", "probabilityc", "probcurve", "probcrv", "probc" })]
		[Tooltip("The curve that defines the falloff of the probability of changing to a character other than the original.\nAliases: probabilitycurve, probabilitycrv, probabilityc, probcurve, probcrv, probc")]
		private AnimationCurve probabilityCurve;

		private void InitRNGDict(IAnimationContext context)
		{
		}

		private void InitLastUpdatedDict(IAnimationContext context)
		{
		}

		private void InitDelayDict(IAnimationContext context)
		{
		}

		private void InitCharactersDict(IAnimationContext context)
		{
		}

		private void GetNewCustomData_Hook(object obj, IAnimationContext context)
		{
		}

		private void Animate(CharData cData, Data data, IAnimationContext context)
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
