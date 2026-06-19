using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters;
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
		private float duration = 1f;

		[SerializeField]
		[AutoParameter("chars", new string[] { "char", "c" })]
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
		[AutoParameter("waitcurve", new string[] { "waitcrv", "waitc" })]
		[Tooltip("The curve that defines the falloff of the wait between each change.\nAliases: waitcurve, waitcrv, waitc")]
		private AnimationCurve waitCurve = AnimationCurveUtility.Linear();

		[SerializeField]
		[AutoParameter("probabilitycurve", new string[] { "probabilitycrv", "probabilityc", "probcurve", "probcrv", "probc" })]
		[Tooltip("The curve that defines the falloff of the probability of changing to a character other than the original.\nAliases: probabilitycurve, probabilitycrv, probabilityc, probcurve, probcrv, probc")]
		private AnimationCurve probabilityCurve = AnimationCurveUtility.Invert(AnimationCurveUtility.Linear());

		private void InitRNGDict(IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			int num = (int)(context.AnimatorContext.PassedTime * 1000f);
			data.rngDict = new Dictionary<int, System.Random>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				data.rngDict.Add(i, new System.Random(num + i));
			}
		}

		private void InitLastUpdatedDict(IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			data.lastUpdatedDict = new Dictionary<int, float>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				data.lastUpdatedDict.Add(i, context.AnimatorContext.PassedTime);
			}
		}

		private void InitDelayDict(IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			data.delayDict = new Dictionary<int, float>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				data.delayDict.Add(i, 0f);
			}
		}

		private void InitCharactersDict(IAnimationContext context)
		{
			Data obj = context.CustomData as Data;
			obj.currentCharacterCache = new Dictionary<int, TMP_Character>(context.SegmentData.Length);
			obj.originalCharacterCache = new Dictionary<int, TMP_Character>(context.SegmentData.Length);
		}

		private void GetNewCustomData_Hook(object obj, IAnimationContext context)
		{
			Data obj2 = (Data)obj;
			obj2.lastUpdatedDict = null;
			obj2.delayDict = null;
			obj2.rngDict = null;
		}

		private void Animate(CharData cData, Data data, IAnimationContext context)
		{
			Data data2 = context.CustomData as Data;
			if (string.IsNullOrWhiteSpace(data2.characters) || cData.info.elementType != TMP_TextElementType.Character)
			{
				context.FinishAnimation(cData);
				return;
			}
			if (!data2.init)
			{
				data2.init = true;
				InitRNGDict(context);
				InitLastUpdatedDict(context);
				InitDelayDict(context);
				InitCharactersDict(context);
			}
			int key = context.SegmentData.SegmentIndexOf(cData);
			if (!data2.originalCharacterCache.ContainsKey(key))
			{
				if (!cData.info.fontAsset.characterLookupTable.TryGetValue(cData.info.character, out var value))
				{
					return;
				}
				data2.originalCharacterCache[key] = value;
				data2.currentCharacterCache[key] = value;
			}
			float num = ((data2.duration > 0f) ? Mathf.Lerp(0f, 1f, (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData)) / data2.duration) : 1f);
			float num2 = data2.waitCurve.Evaluate(num);
			float num3 = data2.probabilityCurve.Evaluate(num);
			float num4 = data2.duration - (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData));
			if (num == 1f)
			{
				data2.delayDict[key] = 0f;
				data2.lastUpdatedDict[key] = 0f;
				context.FinishAnimation(cData);
			}
			else if (context.AnimatorContext.PassedTime - data2.lastUpdatedDict[key] >= data2.delayDict[key])
			{
				if (num4 >= data2.minWait * num2)
				{
					bool num5 = data2.rngDict[key].NextDouble() * (double)num3 > (double)data2.probability;
					float num6 = ((data2.maxWait == data2.minWait) ? data2.maxWait : Mathf.Lerp(data2.minWait, data2.maxWait, (float)data2.rngDict[key].NextDouble()));
					num6 *= num2;
					num6 = Mathf.Clamp(num6, data2.delayDict[key], num4);
					data2.delayDict[key] = num6;
					data2.lastUpdatedDict[key] = context.AnimatorContext.PassedTime;
					if (num5)
					{
						data2.currentCharacterCache[key] = data2.originalCharacterCache[key];
						return;
					}
					int index = data2.rngDict[key].Next(0, data2.characters.Length);
					char c = data2.characters[index];
					if (data2.autoCase && char.IsLetter(cData.info.character) && char.IsLetter(c))
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
						data2.currentCharacterCache[key] = value2;
						TMPAnimationUtility.SetToCharacter(value2, data2.originalCharacterCache[key], cData, context);
					}
					else
					{
						Debug.LogError($"Failed to get character {c} from lookup table");
					}
				}
				else
				{
					data2.currentCharacterCache[key] = data2.originalCharacterCache[key];
				}
			}
			else
			{
				TMP_Character newCharacter = data2.currentCharacterCache[key];
				TMP_Character originalCharacter = data2.originalCharacterCache[key];
				TMPAnimationUtility.SetToCharacter(newCharacter, originalCharacter, cData, context);
			}
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
				Data data = (Data)customData;
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, "duration", "dur", "d"))
				{
					data.duration = value;
				}
				if (TMPParameterUtility.TryGetDefinedParameter(out var value2, parameters, "chars", "char", "c"))
				{
					data.characters = value2;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywordDatabase, "probability", "prob", "p"))
				{
					data.probability = value3;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value4, parameters, keywordDatabase, "minwait", "minw", "min"))
				{
					data.minWait = value4;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value5, parameters, keywordDatabase, "maxwait", "maxw", "max"))
				{
					data.maxWait = value5;
				}
				if (TMPParameterUtility.TryGetBoolParameter(out var value6, parameters, keywordDatabase, "autocase", "case"))
				{
					data.autoCase = value6;
				}
				if (TMPParameterUtility.TryGetAnimCurveParameter(out var value7, parameters, keywordDatabase, "waitcurve", "waitcrv", "waitc"))
				{
					data.waitCurve = value7;
				}
				if (TMPParameterUtility.TryGetAnimCurveParameter(out var value8, parameters, keywordDatabase, "probabilitycurve", "probabilitycrv", "probabilityc", "probcurve", "probcrv", "probc"))
				{
					data.probabilityCurve = value8;
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
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywordDatabase, "waitcurve", "waitcrv", "waitc"))
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
