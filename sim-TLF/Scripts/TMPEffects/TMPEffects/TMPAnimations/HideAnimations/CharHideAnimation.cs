using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters;
using TMPro;
using UnityEngine;

namespace TMPEffects.TMPAnimations.HideAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new CharHideAnimation", menuName = "TMPEffects/Animations/Hide Animations/Built-in/Char")]
	public class CharHideAnimation : TMPHideAnimation
	{
		[AutoParametersStorage]
		private class AutoParametersData
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
		private float duration = 1f;

		[SerializeField]
		[AutoParameter("characters", new string[] { "chars", "char", "c" })]
		[Tooltip("The pool of characters to change to.\nAliases: characters, chars, char, c")]
		private string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

		[SerializeField]
		[AutoParameter("probability", new string[] { "prob", "p" })]
		[Tooltip("The probability to change to a character different from the original.\nAliases: probability, prob, p")]
		private float probability = 0.95f;

		[SerializeField]
		[AutoParameter("minwait", new string[] { "minw", "min" })]
		[Tooltip("The minimum amount of time to wait once a character changed (or did not change).\nAliases: minwait, minw, min")]
		private float minWait = 0.1f;

		[SerializeField]
		[AutoParameter("maxwait", new string[] { "maxw", "max" })]
		[Tooltip("The maximum amount of time to wait once a character changed (or did not change).\nAliases: maxwait, maxw, max")]
		private float maxWait = 0.1f;

		[SerializeField]
		[AutoParameter("autocase", new string[] { "case" })]
		[Tooltip("Whether to ensure capitalized characters are only changed to other capitalized characters, and vice versa.\nautocase, case")]
		private bool autoCase = true;

		[SerializeField]
		[AutoParameter("waitcurve", new string[] { "waitcrv", "wait" })]
		[Tooltip("The curve that defines the falloff of the wait between each change.\nAliases: waitcurve, waitcrv, waitc")]
		private AnimationCurve waitCurve = AnimationCurveUtility.Linear();

		[SerializeField]
		[AutoParameter("probabilitycurve", new string[] { "probabilitycrv", "probabilityc", "probcurve", "probcrv", "probc" })]
		[Tooltip("The curve that defines the falloff of the probability of changing to a character other than the original.\nAliases: probabilitycurve, probabilitycrv, probabilityc, probcurve, probcrv, probc")]
		private AnimationCurve probabilityCurve = AnimationCurveUtility.Invert(AnimationCurveUtility.Linear());

		private void InitRNGDict(AutoParametersData d, IAnimationContext context)
		{
			int num = (int)(context.AnimatorContext.PassedTime * 1000f);
			d.rngDict = new Dictionary<int, System.Random>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				d.rngDict.Add(i, new System.Random(num + i));
			}
		}

		private void InitLastUpdatedDict(AutoParametersData d, IAnimationContext context)
		{
			d.lastUpdatedDict = new Dictionary<int, float>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				d.lastUpdatedDict.Add(i, context.AnimatorContext.PassedTime);
			}
		}

		private void InitDelayDict(AutoParametersData d, IAnimationContext context)
		{
			d.delayDict = new Dictionary<int, float>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				d.delayDict.Add(i, 0f);
			}
		}

		private void InitCharactersDict(AutoParametersData d, IAnimationContext context)
		{
			d.currentCharacterCache = new Dictionary<int, TMP_Character>(context.SegmentData.Length);
			d.originalCharacterCache = new Dictionary<int, TMP_Character>(context.SegmentData.Length);
		}

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			if (string.IsNullOrWhiteSpace(data.characters) || cData.info.elementType != TMP_TextElementType.Character)
			{
				context.FinishAnimation(cData);
				return;
			}
			if (!data.init)
			{
				data.init = true;
				InitRNGDict(data, context);
				InitLastUpdatedDict(data, context);
				InitDelayDict(data, context);
				InitCharactersDict(data, context);
			}
			int key = context.SegmentData.SegmentIndexOf(cData);
			if (!data.originalCharacterCache.ContainsKey(key))
			{
				if (!cData.info.fontAsset.characterLookupTable.TryGetValue(cData.info.character, out var value))
				{
					return;
				}
				data.originalCharacterCache[key] = value;
				data.currentCharacterCache[key] = value;
			}
			float num = Mathf.Lerp(0f, 1f, (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData)) / data.duration);
			float num2 = data.waitCurve.Evaluate(1f - num);
			float num3 = data.probabilityCurve.Evaluate(1f - num);
			float num4 = data.duration - (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData));
			if (num == 1f)
			{
				data.delayDict[key] = 0f;
				data.lastUpdatedDict[key] = 0f;
				context.FinishAnimation(cData);
				return;
			}
			_ = cData.info.fontAsset.atlasHeight;
			_ = cData.info.fontAsset.atlasWidth;
			if (context.AnimatorContext.PassedTime - data.lastUpdatedDict[key] >= data.delayDict[key])
			{
				if (num4 >= data.minWait * num2)
				{
					bool num5 = data.rngDict[key].NextDouble() * (double)num3 > (double)data.probability;
					float num6 = ((data.maxWait == data.minWait) ? data.maxWait : Mathf.Lerp(data.minWait, data.maxWait, (float)data.rngDict[key].NextDouble()));
					num6 *= num2;
					num6 = Mathf.Clamp(num6, 0f, num4);
					data.delayDict[key] = num6;
					data.lastUpdatedDict[key] = context.AnimatorContext.PassedTime;
					if (num5)
					{
						data.currentCharacterCache[key] = data.originalCharacterCache[key];
						return;
					}
					int index = data.rngDict[key].Next(0, data.characters.Length);
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
				else
				{
					data.currentCharacterCache[key] = data.originalCharacterCache[key];
				}
			}
			else
			{
				TMP_Character newCharacter = data.currentCharacterCache[key];
				TMP_Character originalCharacter = data.originalCharacterCache[key];
				TMPAnimationUtility.SetToCharacter(newCharacter, originalCharacter, cData, context);
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
				duration = duration,
				characters = characters,
				probability = probability,
				minWait = minWait,
				maxWait = maxWait,
				autoCase = autoCase,
				waitCurve = waitCurve,
				probabilityCurve = probabilityCurve
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
				if (TMPParameterUtility.TryGetDefinedParameter(out var value2, parameters, "characters", "chars", "char", "c"))
				{
					autoParametersData.characters = value2;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywordDatabase, "probability", "prob", "p"))
				{
					autoParametersData.probability = value3;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value4, parameters, keywordDatabase, "minwait", "minw", "min"))
				{
					autoParametersData.minWait = value4;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value5, parameters, keywordDatabase, "maxwait", "maxw", "max"))
				{
					autoParametersData.maxWait = value5;
				}
				if (TMPParameterUtility.TryGetBoolParameter(out var value6, parameters, keywordDatabase, "autocase", "case"))
				{
					autoParametersData.autoCase = value6;
				}
				if (TMPParameterUtility.TryGetAnimCurveParameter(out var value7, parameters, keywordDatabase, "waitcurve", "waitcrv", "wait"))
				{
					autoParametersData.waitCurve = value7;
				}
				if (TMPParameterUtility.TryGetAnimCurveParameter(out var value8, parameters, keywordDatabase, "probabilitycurve", "probabilitycrv", "probabilityc", "probcurve", "probcrv", "probc"))
				{
					autoParametersData.probabilityCurve = value8;
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
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywordDatabase, "waitcurve", "waitcrv", "wait"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywordDatabase, "probabilitycurve", "probabilitycrv", "probabilityc", "probcurve", "probcrv", "probc"))
			{
				return false;
			}
			return true;
		}
	}
}
