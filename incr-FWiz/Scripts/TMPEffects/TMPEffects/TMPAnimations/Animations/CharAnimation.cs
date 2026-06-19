using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPro;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new CharAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Char")]
	public class CharAnimation : TMPAnimation
	{
		[AutoParametersStorage]
		private class Data
		{
			public Dictionary<int, float> waitingSince;

			public Dictionary<int, float> waitDuration;

			public Dictionary<int, TMP_Character> currentCharacterCache;

			public Dictionary<int, TMP_Character> originalCharacterCache;

			public System.Random random;

			public string characters;

			public float probability;

			public float minWait;

			public float maxWait;

			public bool autoCase;
		}

		[SerializeField]
		[AutoParameter("characters", new string[] { "chars", "char", "c" })]
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

		private void Init(CharData cData, Data d, IAnimationContext context)
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
