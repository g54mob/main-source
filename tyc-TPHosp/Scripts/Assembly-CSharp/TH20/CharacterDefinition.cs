using System;
using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterDefinition : EntityDefinition
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public struct EnvironmentHappiness
		{
			public float StableValue;

			public float StableMin;

			public float StableMax;

			public float MultiplierBelow;

			public float MultiplierAbove;
		}

		[InspectorOrder(0.0)]
		public readonly string _name;

		public readonly LocalisedString _characterFirstNameOverride;

		public readonly LocalisedString _characterLastNameOverride;

		public readonly Sprite _icon;

		public RuntimeAnimatorController[] _locomotionAnimGraph = new RuntimeAnimatorController[2];

		public RuntimeAnimatorController[] _pickedUpAnimGraph = new RuntimeAnimatorController[2];

		public RuntimeAnimatorController[] _teleportAnimationGraph = new RuntimeAnimatorController[2];

		public RuntimeAnimatorController[] _turnToFaceAnimGraph;

		[InspectorMargin(8)]
		[InspectorHeader("Appearance Assets")]
		public readonly GameObject Prefab;

		public readonly Avatar _avatar;

		public readonly GameObject RigPrefab;

		public readonly CharModule RootModule;

		public readonly ModularSkinMaterialSelection EyeMaterialSelection;

		public readonly ModularSkinMaterialSelection SkinHairMaterialDatabase;

		public readonly ModularSkinMaterialSelection EyeLidsSkinMaterialSelection;

		public readonly bool DisallowModularMasks;

		[InspectorMargin(8)]
		[InspectorHeader("Appearance")]
		[SerializeField]
		private readonly CharModule.Category _moduleCategory;

		[InspectorMargin(8)]
		[InspectorHeader("Navigation")]
		public float _maxSpeed = 1f;

		public float _walkSpeed = 1f;

		public float _turnSpeed = 4f;

		public float _accelerationSpeed = 10f;

		public readonly ObstacleAvoidanceType ObstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;

		[InspectorMargin(8)]
		[InspectorTooltip("First behaviour after check-in")]
		public ExternalBehavior _behaviourPostCheckIn;

		[InspectorTooltip("Idle behaviour")]
		public ExternalBehavior _behaviourIdle;

		[InspectorTooltip("Go to room behaviour")]
		public ExternalBehavior _behaviourGotoRoom;

		[InspectorTooltip("Leave hospital behaviour")]
		public ExternalBehavior _behaviourLeaveHospital;

		[InspectorTooltip("Exclude from staff morale calculations")]
		public bool _excludeFromStaffMoraleCalculations;

		[InspectorTooltip("Attributes")]
		public CharacterAttributes.Definition[] _attributes;

		[InspectorTooltip("Hover menu prefab override")]
		public GameObject _hoverMenuPrefab;

		[InspectorTooltip("Select menu prefab override")]
		public GameObject _selectMenuPrefab;

		[InspectorTooltip("Pixelated UI prefab")]
		public GameObject PixelatedPrefab;

		[InspectorMargin(8)]
		[InspectorTooltip("Hunger attribute modifier")]
		public float _needHungerModifer;

		[InspectorTooltip("Thirst attribute modifier")]
		public float _needThirstModifer;

		[InspectorTooltip("Toilet attribute modifier")]
		public float _needToiletModifer;

		[InspectorTooltip("Boredom attribute modifier")]
		public float _needBoredomModifer;

		[InspectorTooltip("Health attribute modifier")]
		public float _needHealthModifer;

		[InspectorTooltip("Happiness attribute modifier")]
		public float _needHappinessModifier;

		[InspectorTooltip("Opportunistic need happiness modifier")]
		public float _happinessModifierOpportunisticNeed;

		[InspectorTooltip("Urgent need happiness modifier")]
		public float _happinessModifierUrgentNeed;

		[InspectorMargin(8)]
		[InspectorTooltip("Satisfy hunger behaviour")]
		public ExternalBehavior _behaviourSatisfyHunger;

		[InspectorTooltip("Satisfy thirst behaviour")]
		public ExternalBehavior _behaviourSatisfyThirst;

		[InspectorTooltip("Satisfy toilet behaviour")]
		public ExternalBehavior _behaviourSatisfyToilet;

		[InspectorTooltip("Satisfy boredom behaviour")]
		public ExternalBehavior _behaviourSatisfyBoredom;

		[InspectorTooltip("Satisfy litter behaviour")]
		public ExternalBehavior _behaviourSatisfyLitter;

		[InspectorTooltip("Satisfy nausea behaviour")]
		public ExternalBehavior _behaviourSatisfyNausea;

		[InspectorTooltip("Satisfy failure toilet behaviour")]
		public ExternalBehavior _behaviourSatisfyFailureToilet;

		[InspectorTooltip("Satisfy failure litter behaviour")]
		public ExternalBehavior _behaviourSatisfyFailureLitter;

		[InspectorTooltip("Satisfy failure nausea behaviour")]
		public ExternalBehavior _behaviourSatisfyFailureNausea;

		[InspectorMargin(8)]
		[InspectorTooltip("Character Modifiers to add by default on construction")]
		public CharacterModifier[] _defaultCharacterModifiers;

		[InspectorMargin(8)]
		[InspectorTooltip("Happiness temperature modifier")]
		public EnvironmentHappiness HappinessEnvironmentTemperature;

		[InspectorMargin(8)]
		[InspectorTooltip("Happiness attractiveness modifier")]
		public EnvironmentHappiness HappinessEnvironmentAttractiveness;

		[InspectorTooltip("Temperature environment multiplier")]
		public float EnvironmentTemperatureMultiplier = 1f;

		[InspectorMargin(8)]
		[InspectorTooltip("Hygiene environment multiplier")]
		public float EnvironmentHygieneMultiplier = 1f;

		[InspectorTooltip("Hygiene health modification threshold")]
		public float HygieneHealthModificationThreshold = 50f;

		[InspectorTooltip("Hygiene health modification value")]
		public float HygieneHealthModificationValue = 0.1f;

		[InspectorTooltip("Low hygiene status effect threshold")]
		public float HygieneLowStatusEffectThreshold = 10f;

		public bool FuturePatient;

		public CharModule.Category GetModularCategory(Character.Sex sex)
		{
			if (sex == Character.Sex.Female)
			{
				return (_moduleCategory & ~CharModule.Category.Male) | CharModule.Category.Female;
			}
			return (_moduleCategory & ~CharModule.Category.Female) | CharModule.Category.Male;
		}

		public float GetAttributeModifer(CharacterAttributes.Type type)
		{
			return type switch
			{
				CharacterAttributes.Type.Hunger => _needHungerModifer, 
				CharacterAttributes.Type.Thirst => _needThirstModifer, 
				CharacterAttributes.Type.Toilet => _needToiletModifer, 
				CharacterAttributes.Type.Boredom => _needBoredomModifer, 
				CharacterAttributes.Type.Health => _needHealthModifer, 
				CharacterAttributes.Type.Happiness => _needHappinessModifier, 
				_ => 0f, 
			};
		}

		public float GetUrgentNeedHappinessModifer(CharacterAttributes.Type type)
		{
			return type switch
			{
				CharacterAttributes.Type.Hunger => _happinessModifierUrgentNeed, 
				CharacterAttributes.Type.Thirst => _happinessModifierUrgentNeed, 
				CharacterAttributes.Type.Toilet => _happinessModifierUrgentNeed, 
				CharacterAttributes.Type.Boredom => _happinessModifierUrgentNeed, 
				_ => 0f, 
			};
		}

		public float GetOpportunisticNeedHappinessModifer(CharacterAttributes.Type type)
		{
			return type switch
			{
				CharacterAttributes.Type.Hunger => _happinessModifierOpportunisticNeed, 
				CharacterAttributes.Type.Thirst => _happinessModifierOpportunisticNeed, 
				CharacterAttributes.Type.Toilet => _happinessModifierOpportunisticNeed, 
				CharacterAttributes.Type.Boredom => _happinessModifierOpportunisticNeed, 
				_ => 0f, 
			};
		}

		public ExternalBehavior GetSatisfactionBehaviour(CharacterAttributes.Type type)
		{
			return type switch
			{
				CharacterAttributes.Type.Hunger => _behaviourSatisfyHunger, 
				CharacterAttributes.Type.Thirst => _behaviourSatisfyThirst, 
				CharacterAttributes.Type.Toilet => _behaviourSatisfyToilet, 
				CharacterAttributes.Type.Boredom => _behaviourSatisfyBoredom, 
				CharacterAttributes.Type.Litter => _behaviourSatisfyLitter, 
				CharacterAttributes.Type.Nausea => _behaviourSatisfyNausea, 
				_ => null, 
			};
		}

		public ExternalBehavior GetSatisfactionFailureBehaviour(CharacterAttributes.Type type)
		{
			if (DebugVars.AllowNeedsFailure.Value)
			{
				switch (type)
				{
				case CharacterAttributes.Type.Toilet:
					return _behaviourSatisfyFailureToilet;
				case CharacterAttributes.Type.Litter:
					return _behaviourSatisfyFailureLitter;
				case CharacterAttributes.Type.Nausea:
					return _behaviourSatisfyFailureNausea;
				}
			}
			return null;
		}

		public EnvironmentHappiness GetEnvironmentHappinessModifier(HospitalAttributeMap.Attribute attribute)
		{
			return attribute switch
			{
				HospitalAttributeMap.Attribute.Temperature => HappinessEnvironmentTemperature, 
				HospitalAttributeMap.Attribute.Attractiveness => HappinessEnvironmentAttractiveness, 
				_ => throw new ArgumentOutOfRangeException("attribute", attribute, null), 
			};
		}
	}
}
