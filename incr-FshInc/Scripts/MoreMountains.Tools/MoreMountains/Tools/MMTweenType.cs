using System;
using UnityEngine;

namespace MoreMountains.Tools
{
	[Serializable]
	public class MMTweenType
	{
		public MMTweenDefinitionTypes MMTweenDefinitionType;

		public MMTween.MMTweenCurve MMTweenCurve = MMTween.MMTweenCurve.EaseInCubic;

		public AnimationCurve Curve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public bool Initialized;

		public string ConditionPropertyName = "";

		public string EnumConditionPropertyName = "";

		public bool[] EnumConditions = new bool[32];

		public static MMTweenType DefaultEaseInCubic { get; } = new MMTweenType(MMTween.MMTweenCurve.EaseInCubic, "", "");

		public MMTweenType(MMTween.MMTweenCurve newCurve, string conditionPropertyName = "", string enumConditionPropertyName = "", params int[] enumConditionValues)
		{
			MMTweenCurve = newCurve;
			MMTweenDefinitionType = MMTweenDefinitionTypes.MMTween;
			ConditionPropertyName = conditionPropertyName;
			EnumConditionPropertyName = enumConditionPropertyName;
			for (int i = 0; i < enumConditionValues.Length; i++)
			{
				EnumConditions[enumConditionValues[i]] = true;
			}
		}

		public MMTweenType(AnimationCurve newCurve, string conditionPropertyName = "", string enumConditionPropertyName = "", params int[] enumConditionValues)
		{
			Curve = newCurve;
			MMTweenDefinitionType = MMTweenDefinitionTypes.AnimationCurve;
			ConditionPropertyName = conditionPropertyName;
			EnumConditionPropertyName = enumConditionPropertyName;
			for (int i = 0; i < enumConditionValues.Length; i++)
			{
				EnumConditions[enumConditionValues[i]] = true;
			}
		}

		public float Evaluate(float t)
		{
			return MMTween.Evaluate(t, this);
		}
	}
}
