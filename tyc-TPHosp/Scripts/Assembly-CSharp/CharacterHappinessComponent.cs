using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using JetBrains.Annotations;
using TH20;
using UnityEngine;

[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
public class CharacterHappinessComponent : EntityTickComponent
{
	public struct StatModifier
	{
		public float Value;

		public string Term;

		public bool HideInGUI;
	}

	[SerializeField]
	private float VisibleInGUIThreshold;

	private Character Character;

	private float _lastProcessTime;

	private float _nextProcessTime;

	protected readonly List<StatModifier> Stats = new List<StatModifier>(32);

	private CharacterAttributes.Needs _tempNeeds = new CharacterAttributes.Needs();

	protected override Type ValidEntityType()
	{
		return typeof(Character);
	}

	internal override void InitializeComponent()
	{
		base.InitializeComponent();
		Character = GetOwner<Character>();
		SetNextProcessTime();
	}

	private void SetNextProcessTime()
	{
		_lastProcessTime = GameTime.time;
		_nextProcessTime = _lastProcessTime + RandomUtils.GlobalRandomInstance.NextFloat(1f, 2f);
	}

	public override void Tick()
	{
		base.Tick();
		float time = GameTime.time;
		if (time > _nextProcessTime)
		{
			float deltaTime = time - _lastProcessTime;
			SetNextProcessTime();
			TickInternal(deltaTime);
			if (Character.Happiness != null && Character.Happiness.Value() >= GameAlgorithms.Config.PatientLowHappiness)
			{
				base.Level.StatusIconManager.HideStatusIcon(Character, StatusIcon.Type.Unhappy);
			}
		}
	}

	protected virtual void TickInternal(float deltaTime)
	{
		if (Character.AttributesEnabled && Character.Happiness != null)
		{
			float num = CalculateHappinessModifier();
			Character.Happiness.Modify(num * deltaTime, Character.GetAttributeMultiplier(CharacterAttributes.Type.Happiness));
		}
	}

	private float CalculateHappinessModifier()
	{
		Stats.Clear();
		CalculateNeedsModifier();
		CalculateEnvironmentalModifier();
		CalculateStatusEffectsModifier();
		float num = 0f;
		foreach (StatModifier stat in Stats)
		{
			num += stat.Value;
		}
		return num;
	}

	protected void CalculateNeedsModifier()
	{
		Character.GetCharacterAttributes().GetNeeds(GameAlgorithms.Config.OpportunisticNeedThreshold, ref _tempNeeds);
		foreach (KeyValuePair<CharacterAttributes.Type, AttributeFloat> tempNeed in _tempNeeds)
		{
			float value;
			bool flag;
			if (tempNeed.Value.Value() >= GameAlgorithms.Config.UrgentNeedThreshold)
			{
				value = Character.Definition.GetUrgentNeedHappinessModifer(tempNeed.Key);
				flag = true;
			}
			else
			{
				value = Character.Definition.GetOpportunisticNeedHappinessModifer(tempNeed.Key);
				flag = false;
			}
			string text = string.Empty;
			switch (tempNeed.Key)
			{
			case CharacterAttributes.Type.Hunger:
				text = (flag ? "Staff/UnhappyFlavour/Needs_Hunger_Urgent_CS" : "Staff/UnhappyFlavour/Needs_Hunger_CS");
				break;
			case CharacterAttributes.Type.Thirst:
				text = (flag ? "Staff/UnhappyFlavour/Needs_Thirst_Urgent_CS" : "Staff/UnhappyFlavour/Needs_Thirst_CS");
				break;
			case CharacterAttributes.Type.Toilet:
				text = (flag ? "Staff/UnhappyFlavour/Needs_Toilet_Urgent_CS" : "Staff/UnhappyFlavour/Needs_Toilet_CS");
				break;
			case CharacterAttributes.Type.Boredom:
				text = (flag ? "Staff/UnhappyFlavour/Needs_Boredom_Urgent_CS" : "Staff/UnhappyFlavour/Needs_Boredom_CS");
				break;
			case CharacterAttributes.Type.Litter:
				text = (flag ? "Staff/UnhappyFlavour/Needs_Litter_Urgent_CS" : "Staff/UnhappyFlavour/Needs_Litter_CS");
				break;
			case CharacterAttributes.Type.Nausea:
				text = (flag ? "Staff/UnhappyFlavour/Needs_Nausea_Urgent_CS" : "Staff/UnhappyFlavour/Needs_Nausea_CS");
				break;
			case CharacterAttributes.Type.Hygiene:
				text = (flag ? "Staff/UnhappyFlavour/Needs_Hygiene_Urgent_CS" : "Staff/UnhappyFlavour/Needs_Hygiene_CS");
				break;
			}
			if (!string.IsNullOrEmpty(text))
			{
				Stats.Add(new StatModifier
				{
					Term = text,
					Value = value
				});
			}
		}
	}

	protected void CalculateStatusEffectsModifier()
	{
		if (Character.ModifiersComponent == null)
		{
			return;
		}
		Character.Sex gender = Character.Gender;
		foreach (KeyValuePair<CharacterStatusEffectDefinition, float> statusEffect in Character.ModifiersComponent.StatusEffects)
		{
			CharacterModifierHappiness characterModifierHappiness = null;
			CharacterModifier[] modifiers = statusEffect.Key.Modifiers;
			for (int i = 0; i < modifiers.Length; i++)
			{
				characterModifierHappiness = modifiers[i] as CharacterModifierHappiness;
				if (characterModifierHappiness != null)
				{
					if (characterModifierHappiness.IsValidFor(Character))
					{
						break;
					}
					characterModifierHappiness = null;
				}
			}
			if (characterModifierHappiness != null)
			{
				LocalisedString localisedString = ((gender == Character.Sex.Male) ? statusEffect.Key.NameLocalisedMale : statusEffect.Key.NameLocalisedFemale);
				Stats.Add(new StatModifier
				{
					Term = localisedString.Term,
					Value = characterModifierHappiness.Percent
				});
			}
		}
	}

	protected void CalculateEnvironmentalModifier()
	{
		if (Character.AttractivenessValue > 0f)
		{
			Stats.Add(new StatModifier
			{
				Term = "Staff/UnhappyFlavour/EnvironmentAttractive_CS",
				Value = Character.AttractivenessComfort
			});
		}
		else
		{
			Stats.Add(new StatModifier
			{
				Term = "Staff/UnhappyFlavour/EnvironmentUgly_CS",
				Value = Character.AttractivenessComfort
			});
		}
		CharacterDefinition.EnvironmentHappiness environmentHappinessModifier = Character.Definition.GetEnvironmentHappinessModifier(HospitalAttributeMap.Attribute.Temperature);
		if (Character.TemperatureValue < environmentHappinessModifier.StableMin)
		{
			Stats.Add(new StatModifier
			{
				Term = "Staff/UnhappyFlavour/EnvironmentCold_CS",
				Value = Character.TemperatureComfort
			});
		}
		else if (Character.TemperatureValue > environmentHappinessModifier.StableMax)
		{
			Stats.Add(new StatModifier
			{
				Term = "Staff/UnhappyFlavour/EnvironmentHot_CS",
				Value = Character.TemperatureComfort
			});
		}
	}

	protected virtual string FixupStatName(string statName)
	{
		return statName;
	}

	public string GetTranslatedStatName(string term)
	{
		string term2 = term + ((Character.Gender == Character.Sex.Male) ? "_M" : "_F");
		if (LocalisedString.DoesTermExist(term2))
		{
			return FixupStatName(LocalizationManager.GetTranslation(term2));
		}
		return FixupStatName(LocalizationManager.GetTranslation(term));
	}

	public List<string> GetTopComplaints(int numStats, bool showHidden = true)
	{
		List<string> list = new List<string>();
		List<StatModifier> list2 = Stats.ToList();
		list2.Sort((StatModifier pair, StatModifier valuePair) => pair.Value.CompareTo(valuePair.Value));
		foreach (StatModifier item in list2)
		{
			if (item.Value < 0f - VisibleInGUIThreshold && list.Count < numStats && (showHidden || !item.HideInGUI))
			{
				list.Add(GetTranslatedStatName(item.Term));
			}
		}
		return list;
	}

	public List<string> GetTopPositives(int numStats, bool showHidden = true)
	{
		List<string> list = new List<string>();
		List<StatModifier> list2 = Stats.ToList();
		list2.Sort((StatModifier pair, StatModifier valuePair) => valuePair.Value.CompareTo(pair.Value));
		foreach (StatModifier item in list2)
		{
			if (item.Value > VisibleInGUIThreshold && list.Count < numStats && (showHidden || !item.HideInGUI))
			{
				list.Add(GetTranslatedStatName(item.Term));
			}
		}
		return list;
	}

	public List<StatModifier> GetTopComplaintsStatModifiers(int numStats, bool showHidden = true)
	{
		List<StatModifier> list = new List<StatModifier>();
		List<StatModifier> list2 = Stats.ToList();
		list2.Sort((StatModifier pair, StatModifier valuePair) => pair.Value.CompareTo(valuePair.Value));
		foreach (StatModifier item in list2)
		{
			if (item.Value < 0f - VisibleInGUIThreshold && list.Count < numStats && (showHidden || !item.HideInGUI))
			{
				list.Add(item);
			}
		}
		return list;
	}

	public List<StatModifier> GetTopPositivesStatModifiers(int numStats, bool showHidden = true)
	{
		List<StatModifier> list = new List<StatModifier>();
		List<StatModifier> list2 = Stats.ToList();
		list2.Sort((StatModifier pair, StatModifier valuePair) => valuePair.Value.CompareTo(pair.Value));
		foreach (StatModifier item in list2)
		{
			if (item.Value > VisibleInGUIThreshold && list.Count < numStats && (showHidden || !item.HideInGUI))
			{
				list.Add(item);
			}
		}
		return list;
	}
}
