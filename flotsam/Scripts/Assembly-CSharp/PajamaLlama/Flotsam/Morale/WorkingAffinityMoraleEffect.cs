using System;
using System.Runtime.Serialization;
using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Working Affinity")]
	public class WorkingAffinityMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class WorkingPersistentData : BasePersistentData
		{
			public bool IsWorking;

			[OptionalField(VersionAdded = 2)]
			public int Modifier;

			public int AffinityAmount;

			public WorkingPersistentData(WorkingAffinityMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
				IsWorking = moraleEffect.IsWorking;
				Modifier = moraleEffect._modifier;
			}
		}

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		[FormerlySerializedAs("_thresholdModifiers")]
		[SerializeField]
		private MoraleEffectModifierThreshold[] _modifierThresholds;

		private static AssignmentType[] _assignmentTypes;

		private int _modifier;

		public bool IsWorking { get; private set; }

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			IsWorking = false;
			_modifier = 0;
			if (_assignmentTypes == null)
			{
				_assignmentTypes = (AssignmentType[])Enum.GetValues(typeof(AssignmentType));
			}
			_agent.OnAssignmentUpdatedEvent.AddListener(OnAssignmentUpdated);
			_agent.Attributes.AttributesUpdatedEvent.AddListener(OnUpdateModifier);
		}

		public override void Destroy()
		{
			_agent.OnAssignmentUpdatedEvent.RemoveListener(OnAssignmentUpdated);
			_agent.Attributes.AttributesUpdatedEvent.RemoveListener(OnUpdateModifier);
		}

		private void OnAssignmentUpdated(Agent agent)
		{
			OnUpdateModifier();
		}

		private void OnUpdateModifier()
		{
			if (_agent.Assignment != null)
			{
				_modifier = 0;
				AssignmentType[] assignmentTypes = _assignmentTypes;
				foreach (AssignmentType assignmentType in assignmentTypes)
				{
					if (TryReturnAttributeType(assignmentType, _agent.Assignment, out var attributeType))
					{
						_modifier += ReturnModifier(attributeType) * _agent.Attributes.ReturnAffinityAmount(attributeType);
					}
				}
				if (0 < _modifier)
				{
					Activate();
					return;
				}
			}
			Deactivate();
		}

		protected override void Activate()
		{
			IsWorking = true;
			base.Activate();
		}

		protected override void Deactivate()
		{
			IsWorking = false;
			_modifier = 0;
			base.Deactivate();
		}

		public int ReturnTooltipModifier(int affinityAmount)
		{
			if (!_modifierThresholds.IsNullOrEmpty())
			{
				return _modifierThresholds[0].Modifier * affinityAmount;
			}
			return 0;
		}

		public override bool IsActive()
		{
			return IsWorking;
		}

		public override int ReturnModifier()
		{
			return _modifier;
		}

		public override string ReturnDescription()
		{
			return _description;
		}

		public override Sprite ReturnSprite()
		{
			return _icon;
		}

		public override bool TryReturnAttributeEffect(out DrifterAttributesEffect effect)
		{
			effect = null;
			return false;
		}

		private bool TryReturnAttributeType(AssignmentType assignmentType, ProjectAssignment assignment, out DrifterAttributes.AttributeType attributeType)
		{
			attributeType = DrifterAttributes.AttributeType.None;
			if (assignment == null || assignment.Project == null || (assignment.Project.AssignmentTypes & assignmentType) == 0)
			{
				return false;
			}
			switch (assignmentType)
			{
			case AssignmentType.Constructing:
				attributeType = DrifterAttributes.AttributeType.Construction;
				break;
			case AssignmentType.Hauling:
			case AssignmentType.EelectricityManagement:
				attributeType = DrifterAttributes.AttributeType.Athletics;
				break;
			case AssignmentType.LiquidHandling:
				attributeType = DrifterAttributes.AttributeType.Liquids;
				break;
			case AssignmentType.Crafting:
				attributeType = DrifterAttributes.AttributeType.Recycling;
				break;
			case AssignmentType.Cooking:
				attributeType = DrifterAttributes.AttributeType.Cooking;
				break;
			case AssignmentType.Fishing:
				attributeType = DrifterAttributes.AttributeType.Fishing;
				break;
			case AssignmentType.BuoySalvaging:
			case AssignmentType.LandmarkInteraction:
				attributeType = DrifterAttributes.AttributeType.Salvaging;
				break;
			case AssignmentType.Medicine:
				attributeType = DrifterAttributes.AttributeType.Medicine;
				break;
			case AssignmentType.Researching:
				attributeType = DrifterAttributes.AttributeType.Research;
				break;
			}
			return attributeType != DrifterAttributes.AttributeType.None;
		}

		private int ReturnModifier(DrifterAttributes.AttributeType attributeType)
		{
			int num = _agent.Attributes.ReturnAttributeExpertise(attributeType);
			int result = 0;
			MoraleEffectModifierThreshold[] modifierThresholds = _modifierThresholds;
			for (int i = 0; i < modifierThresholds.Length; i++)
			{
				MoraleEffectModifierThreshold moraleEffectModifierThreshold = modifierThresholds[i];
				if (moraleEffectModifierThreshold.Threshold <= (float)num)
				{
					result = moraleEffectModifierThreshold.Modifier;
				}
			}
			return result;
		}

		public override void Restore(BasePersistentData persistentData)
		{
			if (persistentData.TryReturnCast<WorkingPersistentData>(out var persistentData2))
			{
				IsWorking = persistentData2.IsWorking;
				_modifier = persistentData2.Modifier;
				return;
			}
			throw new NotImplementedException();
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new WorkingPersistentData(this);
		}
	}
}
