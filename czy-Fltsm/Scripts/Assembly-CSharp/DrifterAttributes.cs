using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using I2.Loc;
using PajamaLlama.Flotsam.Morale;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PajamaLlama;

[CreateAssetMenu(menuName = "Flotsam/Agent/Attributes")]
public class DrifterAttributes : ScriptableObject
{
	public enum AttributeType
	{
		None = 0,
		Construction = 1,
		Athletics = 2,
		Liquids = 4,
		Recycling = 5,
		Research = 6,
		Cooking = 7,
		Fishing = 8,
		Salvaging = 9,
		Farming = 10,
		Medicine = 11,
		Botany = 12,
		Engineering = 13,
		Architect = 14
	}

	[Serializable]
	public class Attribute
	{
		[Serializable]
		public class PersistentData
		{
			[OptionalField(VersionAdded = 2)]
			public AttributeType AttributeType;

			public int Expertise;

			public PersistentData(Attribute attribute)
			{
				AttributeType = attribute.Type;
				Expertise = attribute.Expertise;
			}

			public void Restore(Attribute attribute)
			{
				attribute.Expertise = Expertise;
			}
		}

		public AttributeType Type;

		public float Modifier;

		public LocalizedString Name = null;

		public LocalizedString Description = null;

		public LocalizedString ModifierTooltip = null;

		public LocalizedString MoraleTooltip = null;

		public LocalizedString AffectedAssignmentsTooltip = null;

		public AssignmentType[] AffectedAssignments;

		public bool ShowInRerollDropdown = true;

		public Sprite Icon;

		public string AnimationParameter;

		public int Expertise { get; set; }

		public string SurvivalGuideLink => $"Attribute_{Type}";

		public bool ReturnAffectsAssignment(Assignment assignment)
		{
			return ReturnAffectsAssignment(assignment.Type);
		}

		public bool ReturnAffectsAssignment(AssignmentSetting assignment)
		{
			return ReturnAffectsAssignment(assignment.Type);
		}

		public bool ReturnAffectsAssignment(AssignmentType assignmentType)
		{
			AssignmentType[] affectedAssignments = AffectedAssignments;
			foreach (AssignmentType assignmentType2 in affectedAssignments)
			{
				if (assignmentType == assignmentType2)
				{
					return true;
				}
			}
			return false;
		}
	}

	[Serializable]
	public class PersistentData
	{
		[OptionalField(VersionAdded = 2)]
		public Attribute.PersistentData[] AttributesData;

		public Attribute.PersistentData Construction;

		public Attribute.PersistentData Athletics;

		public Attribute.PersistentData Desalination;

		public Attribute.PersistentData Crafting;

		public Attribute.PersistentData Research;

		public Attribute.PersistentData Cooking;

		public Attribute.PersistentData Fishing;

		public Attribute.PersistentData Salvaging;

		public Attribute.PersistentData Architect;

		[OptionalField(VersionAdded = 2)]
		public float Experience;

		[OptionalField(VersionAdded = 2)]
		public int Level;

		[OptionalField(VersionAdded = 2)]
		public int SpendablePoints;

		public Attribute.PersistentData Nautics;

		[OptionalField(VersionAdded = 2)]
		public DrifterAffinity[] Affinities;

		public PersistentData(DrifterAttributes attributes)
		{
			int num = attributes._attributes.Length;
			AttributesData = new Attribute.PersistentData[num];
			for (int i = 0; i < num; i++)
			{
				AttributesData[i] = new Attribute.PersistentData(attributes._attributes[i]);
			}
			Experience = attributes.Experience;
			Level = attributes.Level;
			SpendablePoints = attributes.SpendablePoints;
		}

		public void Restore(DrifterAttributes attributes)
		{
			RestoreAttribute(attributes.ReturnAttribute(AttributeType.Construction), Construction);
			RestoreAttribute(attributes.ReturnAttribute(AttributeType.Athletics), Athletics);
			RestoreAttribute(attributes.ReturnAttribute(AttributeType.Liquids), Desalination);
			RestoreAttribute(attributes.ReturnAttribute(AttributeType.Recycling), Crafting);
			RestoreAttribute(attributes.ReturnAttribute(AttributeType.Research), Research);
			RestoreAttribute(attributes.ReturnAttribute(AttributeType.Cooking), Cooking);
			RestoreAttribute(attributes.ReturnAttribute(AttributeType.Fishing), Fishing);
			RestoreAttribute(attributes.ReturnAttribute(AttributeType.Salvaging), Salvaging);
			if (!AttributesData.IsNullOrEmpty())
			{
				Attribute.PersistentData[] attributesData = AttributesData;
				foreach (Attribute.PersistentData persistentData in attributesData)
				{
					if (persistentData.AttributeType != AttributeType.None)
					{
						persistentData.Restore(attributes.ReturnAttribute(persistentData.AttributeType));
					}
				}
			}
			attributes.Experience = Experience;
			attributes.Level = Level;
			attributes.SpendablePoints = SpendablePoints;
			attributes.AttributesUpdatedEvent?.Invoke();
			attributes.LevelIncreasedEvent?.Invoke();
			attributes.AvailableSpendingPointsUpdatedEvent?.Invoke();
		}

		private void RestoreAttribute(Attribute attribute, Attribute.PersistentData data)
		{
			data?.Restore(attribute);
		}
	}

	[NamedArrayElement(new string[] { "Type" })]
	[SerializeField]
	private Attribute[] _attributes;

	[Space]
	[SerializeField]
	private RangedFloat _modifierLimits;

	[SerializeField]
	private ExpertiseProperties _expertiseProperties;

	[SerializeField]
	private WorkingAffinityMoraleEffect _workingAffinityMoraleEffect;

	private Agent _agent;

	private static AttributeType[] _attributeTypes;

	public Attribute[] Attributes => _attributes;

	public UnityEvent AttributesUpdatedEvent { get; private set; } = new UnityEvent();

	public UnityEvent LevelIncreasedEvent { get; private set; } = new UnityEvent();

	public UnityEvent AvailableSpendingPointsUpdatedEvent { get; private set; } = new UnityEvent();

	public int Construction => ReturnTotalAttributePoints(AttributeType.Construction);

	public int Athletics => ReturnTotalAttributePoints(AttributeType.Athletics);

	public int Liquids => ReturnTotalAttributePoints(AttributeType.Liquids);

	public int Recycling => ReturnTotalAttributePoints(AttributeType.Recycling);

	public int Research => ReturnTotalAttributePoints(AttributeType.Research);

	public int Cooking => ReturnTotalAttributePoints(AttributeType.Cooking);

	public int Fishing => ReturnTotalAttributePoints(AttributeType.Fishing);

	public int Salvaging => ReturnTotalAttributePoints(AttributeType.Salvaging);

	public int Level { get; private set; }

	public float NormalizedLevel => (float)Level / (float)MaximumDrifterLevel;

	public int MaximumAttributeLevel => _expertiseProperties.MaximumLevel;

	public int MaximumDrifterLevel => MaximumAttributeLevel * 8;

	public int AttributeTypeAmount { get; private set; }

	public float Experience { get; private set; }

	public int SpendablePoints { get; private set; }

	public List<DrifterAttributesEffect> Effects { get; private set; }

	public void Initialize(Agent agent)
	{
		_agent = agent;
		Effects = new List<DrifterAttributesEffect>();
		AttributeTypeAmount = ReturnAttributeTypes().Length - 1;
	}

	public void AddEffect(DrifterAttributesEffect effect)
	{
		if (Effects.AddUnique(effect))
		{
			AttributesUpdatedEvent.Invoke();
		}
	}

	public void RemoveEffect(DrifterAttributesEffect effect)
	{
		if (Effects.Remove(effect))
		{
			AttributesUpdatedEvent.Invoke();
		}
	}

	public void SetExpertise(AttributeType attributeType, int points)
	{
		if (TryReturnAttribute(attributeType, out var attribute))
		{
			attribute.Expertise = points;
			AttributesUpdatedEvent.Invoke();
		}
	}

	public void AddExpertise(AttributeType attributeType, int amount)
	{
		if (TryReturnAttribute(attributeType, out var attribute))
		{
			attribute.Expertise += amount;
			AttributesUpdatedEvent.Invoke();
		}
	}

	public void RemoveExpertise(AttributeType attributeType, int amount)
	{
		if (TryReturnAttribute(attributeType, out var attribute))
		{
			attribute.Expertise -= amount;
			AttributesUpdatedEvent.Invoke();
		}
	}

	public void AddTotalExperience(float experience, bool addResearchPoints)
	{
		if (Level >= MaximumDrifterLevel)
		{
			return;
		}
		Experience += experience;
		float num = ExpertiseManager.ReturnDrifterLevelRequirement(Level);
		while (Experience >= num)
		{
			Experience -= num;
			AddLevel(1, addResearchPoints);
			num = ExpertiseManager.ReturnDrifterLevelRequirement(Level);
			if (Level >= MaximumDrifterLevel)
			{
				Experience = 0f;
				break;
			}
		}
		new AgentFloatEvent(GameEventType.AgentExperienceGained, _agent, experience).Dispatch();
	}

	public void AddLevel(int amount = 1, bool addResearchPoints = true, bool addSpendablePoints = true, bool sendNotification = true)
	{
		if (Level < MaximumDrifterLevel)
		{
			Level += amount;
			if (addSpendablePoints)
			{
				SpendablePoints += amount;
				AvailableSpendingPointsUpdatedEvent.Invoke();
			}
			if (addResearchPoints)
			{
				_agent.Community.Research.AddResearchPoints(amount);
			}
			LevelIncreasedEvent.Invoke();
			if (sendNotification)
			{
				GameManager.UIManager.NotificationHandler.AddNotification(GameManager.Settings.UISettings.LevelUpNotification, new AgentObjectOfInterest(_agent));
			}
			GameEventDispatcher.Dispatch(GameEventType.AgentLevelGained);
		}
	}

	public bool TryLevelAttribute(AttributeType type)
	{
		if (SpendablePoints == 0)
		{
			return false;
		}
		if (!TryReturnAttribute(type, out var _))
		{
			return false;
		}
		if (IsMaximumLevel(type))
		{
			return false;
		}
		SpendablePoints--;
		AddExpertise(type, 1);
		AvailableSpendingPointsUpdatedEvent.Invoke();
		new AttributeEvent(GameEventType.AgentAttributeLeveled, type, _agent).Dispatch();
		return true;
	}

	public Attribute ReturnAttribute(AttributeType type)
	{
		Attribute[] attributes = _attributes;
		foreach (Attribute attribute in attributes)
		{
			if (attribute.Type == type)
			{
				return attribute;
			}
		}
		if (type != AttributeType.None)
		{
			Debug.LogErrorFormat("Attribute of type {0} is not implemented.", type.ToString());
		}
		return null;
	}

	public bool TryReturnAttribute(AttributeType type, out Attribute attribute)
	{
		attribute = ReturnAttribute(type);
		return attribute != null;
	}

	public int ReturnTotalAttributePoints(AttributeType type)
	{
		if (TryReturnAttribute(type, out var attribute))
		{
			return attribute.Expertise + ReturnAttributeEffectPoints(type);
		}
		return 0;
	}

	public int ReturnAttributeEffectPoints(AttributeType type)
	{
		int num = 0;
		foreach (DrifterAttributesEffect effect in Effects)
		{
			num += effect.ReturnModifier(type);
		}
		return num;
	}

	public int ReturnAttributeExpertise(AttributeType type)
	{
		if (TryReturnAttribute(type, out var attribute))
		{
			return attribute.Expertise;
		}
		return 0;
	}

	public float ReturnAttributeModifier(Attribute attribute)
	{
		if (AgentDevTools.OverrideAthleticsModifier && attribute.Type == AttributeType.Athletics)
		{
			return AgentDevTools.AthleticsModifier;
		}
		float value = (float)(attribute.Expertise + ReturnAttributeEffectPoints(attribute.Type)) * attribute.Modifier;
		return (1f + Mathf.Clamp(value, _modifierLimits.Minimum, _modifierLimits.Maximum)) * _agent.Morale.SpeedMultiplier;
	}

	public float ReturnAttributeModifier(AttributeType type)
	{
		if (TryReturnAttribute(type, out var attribute))
		{
			return ReturnAttributeModifier(attribute);
		}
		return 1f;
	}

	public float ReturnAttributeModifier(AttributeType type, int count)
	{
		if (TryReturnAttribute(type, out var attribute))
		{
			return Mathf.Clamp(attribute.Modifier * (float)count, _modifierLimits.Minimum, _modifierLimits.Maximum);
		}
		return 0f;
	}

	public AttributeType ReturnHighestAttribute()
	{
		AttributeType[] array = ReturnAttributeTypes();
		List<AttributeType> list = ListPool<AttributeType>.Get(array.Length);
		int num = 0;
		AttributeType[] array2 = array;
		foreach (AttributeType attributeType in array2)
		{
			int num2 = ReturnTotalAttributePoints(attributeType);
			if (num2 >= num)
			{
				if (num < num2)
				{
					num = num2;
					list.Clear();
				}
				list.Add(attributeType);
			}
		}
		AttributeType result = FlotsamGame.Random(list);
		list.Dispose();
		return result;
	}

	public LocalizedString ReturnAttributeName(AttributeType type)
	{
		if (TryReturnAttribute(type, out var attribute))
		{
			return attribute.Name;
		}
		return null;
	}

	public int ReturnAssignmentAffinityAmount(Assignment assignment)
	{
		int num = 0;
		foreach (DrifterAttributesEffect effect in Effects)
		{
			DrifterAttributeModifier[] modifiers = effect.Modifiers;
			foreach (DrifterAttributeModifier drifterAttributeModifier in modifiers)
			{
				if (TryReturnAttribute(drifterAttributeModifier.Type, out var attribute) && attribute.ReturnAffectsAssignment(assignment))
				{
					num += drifterAttributeModifier.Affinity;
				}
			}
		}
		return num;
	}

	public int ReturnAffinityAmount(AttributeType type)
	{
		int num = 0;
		foreach (DrifterAttributesEffect effect in Effects)
		{
			num += effect.ReturnAffinity(type);
		}
		return num;
	}

	public AttributeType ReturnAssignmentAttribute(Assignment assignment)
	{
		AttributeType[] array = ReturnAttributeTypes();
		foreach (AttributeType attributeType in array)
		{
			if (TryReturnAttribute(attributeType, out var attribute) && attribute.ReturnAffectsAssignment(assignment))
			{
				return attributeType;
			}
		}
		return AttributeType.None;
	}

	public bool TryReturnAttribute(AssignmentType assignmentType, out Attribute attribute)
	{
		AttributeType[] array = ReturnAttributeTypes();
		foreach (AttributeType type in array)
		{
			if (TryReturnAttribute(type, out attribute) && attribute.ReturnAffectsAssignment(assignmentType))
			{
				return true;
			}
		}
		attribute = null;
		return false;
	}

	public bool ReturnAttributeAffectsAssignment(AttributeType type, AssignmentSetting assignment)
	{
		if (TryReturnAttribute(type, out var attribute) && attribute.ReturnAffectsAssignment(assignment))
		{
			return true;
		}
		return false;
	}

	public int ReturnAssignmentAttributePoints(Assignment assignment)
	{
		AttributeType[] array = ReturnAttributeTypes();
		int num = 0;
		AttributeType[] array2 = array;
		foreach (AttributeType type in array2)
		{
			if (TryReturnAttribute(type, out var attribute) && attribute.ReturnAffectsAssignment(assignment))
			{
				num += ReturnTotalAttributePoints(type);
			}
		}
		return num;
	}

	public bool TryReturnAffectedAssignmentText(AttributeType type, out string text)
	{
		text = "";
		if (TryReturnAttribute(type, out var attribute))
		{
			if (attribute.AffectedAssignments.Length == 0)
			{
				return false;
			}
			bool flag = false;
			AssignmentType[] affectedAssignments = attribute.AffectedAssignments;
			foreach (AssignmentType assignmentType in affectedAssignments)
			{
				AssignmentSetting assignmentSetting = GameSettings.Instance.ProjectSettings.ReturnAssignmentSetting(assignmentType);
				if (flag)
				{
					text += ", ";
				}
				text += assignmentSetting.Name;
				flag = true;
			}
		}
		return true;
	}

	public bool TryReturnAffectedAttributesText(AssignmentSetting setting, out string text)
	{
		text = "";
		bool flag = true;
		AttributeType[] array = ReturnAttributeTypes();
		foreach (AttributeType attributeType in array)
		{
			if (attributeType != AttributeType.None && TryReturnAttribute(attributeType, out var attribute) && attribute.ReturnAffectsAssignment(setting))
			{
				if (!flag)
				{
					text += ", ";
				}
				text += attribute.Name;
				flag = false;
			}
		}
		return !flag;
	}

	public static AttributeType[] ReturnAttributeTypes()
	{
		if (_attributeTypes == null)
		{
			_attributeTypes = Enum.GetValues(typeof(AttributeType)) as AttributeType[];
		}
		return _attributeTypes;
	}

	public int ReturnExpertise(AttributeType type)
	{
		if (TryReturnAttribute(type, out var attribute))
		{
			return attribute.Expertise + ReturnBackgroundExpertise(type);
		}
		return 0;
	}

	public int ReturnExpertise(Assignment assignment)
	{
		if (assignment.Enabled)
		{
			Attribute[] attributes = _attributes;
			foreach (Attribute attribute in attributes)
			{
				if (attribute.AffectedAssignments.Contains(assignment.Type))
				{
					return attribute.Expertise + ReturnBackgroundExpertise(attribute.Type);
				}
			}
		}
		return 0;
	}

	public float ReturnNormalizedExperience()
	{
		return Experience / ExpertiseManager.ReturnDrifterLevelRequirement(Level);
	}

	public bool IsMaximumLevel(AttributeType type)
	{
		if (TryReturnAttribute(type, out var attribute))
		{
			return attribute.Expertise >= MaximumAttributeLevel;
		}
		return true;
	}

	public int ReturnMoraleImpact(int affinity)
	{
		return _workingAffinityMoraleEffect.ReturnTooltipModifier(affinity);
	}

	private int ReturnBackgroundExpertise(AttributeType type)
	{
		int num = 0;
		if (_agent != null)
		{
			AgentDescriptor descriptor = _agent.Descriptor;
			if (descriptor.PastBackground != null)
			{
				num += descriptor.PastBackground.ReturnModifier(type);
			}
			if (descriptor.PresentBackground != null)
			{
				num += descriptor.PresentBackground.ReturnModifier(type);
			}
		}
		return num;
	}

	public static string ReturnDetailedTooltipText(DrifterAttributes attributes, Attribute attribute, AttributeType type)
	{
		return ReturnDetailedTooltipText(attributes, attribute, type, attributes.ReturnTotalAttributePoints(type), attributes.ReturnAffinityAmount(type));
	}

	public static string ReturnDetailedTooltipText(DrifterAttributes attributes, Attribute attribute, AttributeType type, int modifierAmount, int affinityAmount)
	{
		string text = ReplaceModifiers(attribute.ModifierTooltip, attributes, type, modifierAmount);
		if (affinityAmount != 0)
		{
			text = text + "\n" + attribute.MoraleTooltip;
			text = ReplaceMorale(text, attributes.ReturnMoraleImpact(affinityAmount));
		}
		if (attributes.TryReturnAffectedAssignmentText(type, out var text2))
		{
			text = text + "\n\n" + Regex.Replace(attribute.AffectedAssignmentsTooltip, "%ASSIGNMENTS%", text2, RegexOptions.IgnoreCase);
		}
		return text;
	}

	public static string ReplaceModifiers(string text, DrifterAttributes attributes, AttributeType type, int count)
	{
		float num = attributes.ReturnAttributeModifier(type, count);
		text = Regex.Replace(text, "%ATTRIBUTE%", $"{num:0%}".AddSign(num), RegexOptions.IgnoreCase);
		return text;
	}

	public static string ReplaceMorale(string text, int count)
	{
		return Regex.Replace(text, "%MORALE%", count.ToString().AddSign(count), RegexOptions.IgnoreCase);
	}
}
