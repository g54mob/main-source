using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
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
		private string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

		[SerializeField]
		[AutoParameter("probability", new string[] { "prob", "p" })]
		[Tooltip("The probability to change to a character different from the original.\nAliases: probability, prob, p")]
		private float probability = 0.15f;

		[SerializeField]
		[AutoParameter("minwait", new string[] { "minw", "min" })]
		[Tooltip("The minimum amount of time to wait once a character changed (or did not change).\nAliases: minwait, minw, min")]
		private float minWait = 0.5f;

		[SerializeField]
		[AutoParameter("maxwait", new string[] { "maxw", "max" })]
		[Tooltip("The maximum amount of time to wait once a character changed (or did not change).\nAliases: maxwait, maxw, max")]
		private float maxWait = 2.5f;

		[SerializeField]
		[AutoParameter("autocase", new string[] { "case" })]
		[Tooltip("Whether to ensure capitalized characters are only changed to other capitalized characters, and vice versa.\nautocase, case")]
		private bool autoCase = true;

		private void Init(CharData cData, Data d, IAnimationContext context)
		{
			d.random = new System.Random((int)(context.AnimatorContext.PassedTime * 1000f));
			if (cData.info.fontAsset.atlasPopulationMode == AtlasPopulationMode.Dynamic)
			{
				cData.info.fontAsset.TryAddCharacters(d.characters);
			}
			d.waitingSince = new Dictionary<int, float>(context.SegmentData.Length);
			d.waitDuration = new Dictionary<int, float>(context.SegmentData.Length);
			d.originalCharacterCache = new Dictionary<int, TMP_Character>(context.SegmentData.Length);
			d.currentCharacterCache = new Dictionary<int, TMP_Character>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				d.waitDuration[i] = -1f;
				d.waitingSince[i] = -1f;
			}
		}

		private void Animate(CharData cData, Data data, IAnimationContext context)
		{
			if (string.IsNullOrWhiteSpace(data.characters) || cData.info.elementType != TMP_TextElementType.Character)
			{
				return;
			}
			int key = context.SegmentData.SegmentIndexOf(cData);
			if (data.waitingSince == null)
			{
				Init(cData, data, context);
			}
			if (!data.originalCharacterCache.ContainsKey(key))
			{
				if (!cData.info.fontAsset.characterLookupTable.TryGetValue(cData.info.character, out var value))
				{
					return;
				}
				data.originalCharacterCache[key] = value;
				data.currentCharacterCache[key] = value;
			}
			if (data.waitingSince[key] != -1f)
			{
				if (!(context.AnimatorContext.PassedTime - data.waitingSince[key] >= data.waitDuration[key]))
				{
					TMP_Character newCharacter = data.currentCharacterCache[key];
					TMP_Character originalCharacter = data.originalCharacterCache[key];
					TMPAnimationUtility.SetToCharacter(newCharacter, originalCharacter, cData, context);
					return;
				}
				data.waitingSince[key] = -1f;
			}
			if (data.random.NextDouble() > (double)data.probability)
			{
				data.currentCharacterCache[key] = data.originalCharacterCache[key];
				TMP_Character newCharacter2 = data.currentCharacterCache[key];
				TMP_Character originalCharacter2 = data.originalCharacterCache[key];
				TMPAnimationUtility.SetToCharacter(newCharacter2, originalCharacter2, cData, context);
			}
			else
			{
				int index = data.random.Next(0, data.characters.Length);
				char c = data.characters[index];
				if (data.autoCase && char.IsLetter(cData.info.character) && char.IsLetter(c))
				{
					if (char.IsUpper(cData.info.character))
					{
						c = char.ToUpper(c);
					}
					else if (char.IsLower(cData.info.character))
					{
						c = char.ToLower(c);
					}
				}
				if (cData.info.fontAsset.characterLookupTable.TryGetValue(c, out var value2))
				{
					data.currentCharacterCache[key] = value2;
					TMPAnimationUtility.SetToCharacter(value2, data.originalCharacterCache[key], cData, context);
				}
				else
				{
					Debug.LogError($"Failed to get character {c} from lookup table");
				}
			}
			data.waitingSince[key] = context.AnimatorContext.PassedTime;
			data.waitDuration[key] = Mathf.Lerp(data.minWait, data.maxWait, (float)data.random.NextDouble());
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			Animate(cData, data, context);
		}

		public override object GetNewCustomData()
		{
			return new Data
			{
				characters = characters,
				probability = probability,
				minWait = minWait,
				maxWait = maxWait,
				autoCase = autoCase
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				Data data = (Data)customData;
				if (TMPParameterUtility.TryGetDefinedParameter(out var value, parameters, "characters", "chars", "char", "c"))
				{
					data.characters = value;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value2, parameters, keywordDatabase, "probability", "prob", "p"))
				{
					data.probability = value2;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywordDatabase, "minwait", "minw", "min"))
				{
					data.minWait = value3;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value4, parameters, keywordDatabase, "maxwait", "maxw", "max"))
				{
					data.maxWait = value4;
				}
				if (TMPParameterUtility.TryGetBoolParameter(out var value5, parameters, keywordDatabase, "autocase", "case"))
				{
					data.autoCase = value5;
				}
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "probability", "prob", "p"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "minwait", "minw", "min"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "maxwait", "maxw", "max"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonBoolParameter(parameters, keywordDatabase, "autocase", "case"))
			{
				return false;
			}
			return true;
		}
	}
}
