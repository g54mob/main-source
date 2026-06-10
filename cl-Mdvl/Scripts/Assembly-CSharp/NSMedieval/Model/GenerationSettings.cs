using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class GenerationSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private List<float> defaultHeight;

		[SerializeField]
		private FloatRange heightFactor;

		[SerializeField]
		private FloatRange heightNormalRange;

		[SerializeField]
		private FloatRange weightNormalRange;

		[SerializeField]
		private FloatRange weightCoefficientRange;

		[SerializeField]
		private IntRange ageRange;

		[SerializeField]
		private IntRange heightRange;

		[SerializeField]
		private IntRange weightRange;

		[SerializeField]
		private int baseSkillCount;

		[SerializeField]
		private int npcSkillCount;

		[SerializeField]
		private int pseudonymChance;

		[SerializeField]
		private int pseudonymLimit;

		[SerializeField]
		private FloatRange birthdayPerkChance;

		[SerializeField]
		private List<AgeCategory> ageCategories;

		[SerializeField]
		private List<IntRange> passions;

		[SerializeField]
		private int maxCreationPoints;

		public List<float> DefaultHeight => defaultHeight;

		public FloatRange HeightFactor => heightFactor;

		public FloatRange WeightCoefficientRange => weightCoefficientRange;

		public IntRange AgeRange => ageRange;

		public int BaseSkillCount => baseSkillCount;

		public int NpcSkillCount => npcSkillCount;

		public int PseudonymChance => pseudonymChance;

		public int PseudonymLimit => pseudonymLimit;

		public List<AgeCategory> AgeCategories => ageCategories;

		public List<IntRange> Passions => passions;

		public IntRange HeightRange => heightRange;

		public IntRange WeightRange => weightRange;

		public FloatRange HeightNormalRange => heightNormalRange;

		public FloatRange WeightNormalRange => weightNormalRange;

		public FloatRange BirthdayPerkChance => birthdayPerkChance;

		public int MaxCreationPoints => maxCreationPoints;

		public override string GetID()
		{
			return string.Empty;
		}
	}
}
