using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.GameDifficulty;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class Attribute : NSEipix.Base.Model
	{
		[Serializable]
		public class AttributeSkillModifier
		{
			[SerializeField]
			private SkillType skillId;

			[SerializeField]
			private float[] perLevelModifier;

			public SkillType Type => skillId;

			public float[] PerLevelModifier => perLevelModifier;
		}

		private static Attribute dummyAttribute;

		[SerializeField]
		private string id;

		[SerializeField]
		private AttributeType type;

		[SerializeField]
		private float value;

		[SerializeField]
		private string difficultyOptionId;

		[SerializeField]
		private AttributeSkillModifier[] skillModifiers;

		[SerializeField]
		private AttributeApplyType applyType;

		[SerializeField]
		private bool hideInUiSettler;

		[SerializeField]
		private bool hideInUiNpc;

		[SerializeField]
		private bool hideInUiAnimal;

		[SerializeField]
		private string valueSuffix;

		[SerializeField]
		private float valueMultiplier;

		[SerializeField]
		private AttributeGroup group;

		[SerializeField]
		private bool positiveIsNegative;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private bool dontReset;

		private SkillType[] skillModifierTypes;

		public AttributeType Type => type;

		public float Value => value;

		public bool DontReset => dontReset;

		public string DifficultyOptionId => difficultyOptionId;

		public SkillType[] ModifierSkillTypes
		{
			get
			{
				if (skillModifierTypes == null)
				{
					skillModifierTypes = new SkillType[skillModifiers.Length];
					for (int i = 0; i < skillModifiers.Length; i++)
					{
						skillModifierTypes[i] = skillModifiers[i].Type;
					}
				}
				return skillModifierTypes;
			}
		}

		public AttributeSkillModifier[] SkillModifiers => skillModifiers;

		public bool HideInUiSettler => hideInUiSettler;

		public string ValueSuffix => valueSuffix;

		public float ValueMultiplier => valueMultiplier;

		public AttributeGroup Group => group;

		public bool PositiveIsNegative => positiveIsNegative;

		public LocKeys[] LocKeys => locKeys;

		public bool HideInUiNpc => hideInUiNpc;

		public bool HideInUiAnimal => hideInUiAnimal;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			dummyAttribute = null;
		}

		public float GetDifficultyModifier()
		{
			if (!string.IsNullOrEmpty(difficultyOptionId))
			{
				return CurrentGameDifficulty()?.GetById(difficultyOptionId) ?? 1f;
			}
			return 1f;
		}

		private static GameParametersInstance CurrentGameDifficulty()
		{
			if (GlobalSaveController.CurrentVillageData == null)
			{
				return MonoSingleton<GameStartController>.Instance.SelectedGameParameters;
			}
			return GlobalSaveController.CurrentVillageData.GameParametersCurrent;
		}

		public static Attribute DummyAttribute()
		{
			if (dummyAttribute == null)
			{
				dummyAttribute = new Attribute();
			}
			return dummyAttribute;
		}

		public override string GetID()
		{
			if (string.IsNullOrEmpty(id))
			{
				id = type.ToString();
			}
			return id;
		}

		public bool HasSkillModifier(SkillType type)
		{
			return GetAttributeSkillModifier(type) != null;
		}

		public bool HasSkillModifiers()
		{
			if (skillModifiers != null)
			{
				return skillModifiers.Length != 0;
			}
			return false;
		}

		public float GetLevelModifier(SkillType type, int level)
		{
			AttributeSkillModifier attributeSkillModifier = GetAttributeSkillModifier(type);
			if (attributeSkillModifier == null)
			{
				return -1f;
			}
			if (attributeSkillModifier.PerLevelModifier != null && attributeSkillModifier.PerLevelModifier.Length != 0)
			{
				if (level >= attributeSkillModifier.PerLevelModifier.Length)
				{
					level = attributeSkillModifier.PerLevelModifier.Length - 1;
				}
				if (level < 0)
				{
					level = 0;
				}
				return attributeSkillModifier.PerLevelModifier[level];
			}
			return -1f;
		}

		public int GetLevelModifierCount(SkillType type)
		{
			AttributeSkillModifier attributeSkillModifier = GetAttributeSkillModifier(type);
			if (attributeSkillModifier != null)
			{
				return attributeSkillModifier.PerLevelModifier.Length;
			}
			return 0;
		}

		public void CopyPropertiesFrom(Attribute original)
		{
			if (!(original == null))
			{
				locKeys = original.locKeys;
				group = original.group;
				hideInUiSettler = original.hideInUiSettler;
				hideInUiNpc = original.hideInUiNpc;
				hideInUiAnimal = original.hideInUiAnimal;
				valueSuffix = original.valueSuffix;
				valueMultiplier = original.ValueMultiplier;
				positiveIsNegative = original.positiveIsNegative;
			}
		}

		public bool ShouldApply(float value)
		{
			return applyType switch
			{
				AttributeApplyType.Always => true, 
				AttributeApplyType.Negative => value < 0f, 
				AttributeApplyType.Positive => value > 0f, 
				_ => true, 
			};
		}

		private AttributeSkillModifier GetAttributeSkillModifier(SkillType type)
		{
			AttributeSkillModifier[] array = skillModifiers;
			foreach (AttributeSkillModifier attributeSkillModifier in array)
			{
				if (attributeSkillModifier.Type == type)
				{
					return attributeSkillModifier;
				}
			}
			return null;
		}
	}
}
