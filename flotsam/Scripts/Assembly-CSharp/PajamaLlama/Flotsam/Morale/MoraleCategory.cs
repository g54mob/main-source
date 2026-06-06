using System;
using System.Collections.Generic;
using I2.Loc;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace PajamaLlama.Flotsam.Morale
{
	[Serializable]
	public class MoraleCategory
	{
		public MoraleCategoryId Id;

		[MinMaxRangeInt(0, 100)]
		public RangedInt Size;

		[FormerlySerializedAs("ExpertiseModifier")]
		public float ExperienceMultiplier = 1f;

		public float SpeedMultiplier = 1f;

		public Color Color = Color.white;

		public int MinimumLevel;

		public Sprite Icon;

		[Header("Text")]
		public LocalizedString Name = "";

		public LocalizedString EffectTooltip = "";

		public LocalizedString RangeTooltip = "";

		public bool IsAvailable(int currentLevel)
		{
			return currentLevel >= MinimumLevel;
		}

		public int ReturnCurrentSize(float lerp)
		{
			return Mathf.RoundToInt(Mathf.Lerp(Size.Minimum, Size.Maximum, lerp));
		}

		public int ReturnRelativeSize(int level, int maxLevel, IReadOnlyList<MoraleCategory> moraleCategories, RangedInt moraleRange)
		{
			float lerp = (float)level / (float)maxLevel;
			int num = ReturnCurrentSize(lerp);
			int num2 = ReturnSize(moraleCategories, level, maxLevel);
			int num3 = moraleRange.ReturnSize();
			return Mathf.RoundToInt((float)num / (float)num2 * (float)num3);
		}

		public static int ReturnSize(IReadOnlyList<MoraleCategory> moraleCategories, int currentLevel, int maximumLevel)
		{
			float lerp = (float)currentLevel / (float)maximumLevel;
			int num = 0;
			int count = moraleCategories.Count;
			for (int i = 0; i < count; i++)
			{
				MoraleCategory moraleCategory = moraleCategories[i];
				if (moraleCategory.IsAvailable(currentLevel))
				{
					num += moraleCategory.ReturnCurrentSize(lerp);
				}
			}
			return num;
		}
	}
}
