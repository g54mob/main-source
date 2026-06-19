using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffDefinition : CharacterDefinition
	{
		[UsedImplicitly]
		public enum Type
		{
			None = -1,
			Doctor = 0,
			Nurse = 1,
			Assistant = 2,
			Janitor = 3
		}

		public enum Satisfaction
		{
			VeryUnhappy = 0,
			Unhappy = 1,
			Satisfied = 2,
			Happy = 3,
			VeryHappy = 4
		}

		private static readonly Type[] _allTypes = new Type[4]
		{
			Type.Doctor,
			Type.Nurse,
			Type.Assistant,
			Type.Janitor
		};

		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Staff Data")]
		[InspectorTooltip("Type of staff member")]
		public Type _type;

		[InspectorTooltip("Are we a special member of staff that can't be fired?")]
		public bool _cantBeFired;

		[InspectorTooltip("Are we a special member of staff that can't be fired?")]
		public bool _cantReassignJobs;

		[InspectorTooltip("Are we a special member of staff that can't be renamed by the player?")]
		public bool _cantRename;

		[InspectorTooltip("Whether this staff member should have a special icon")]
		public Sprite _staffTypeSpriteOverride;

		public Character.Sex _forcedGender = Character.Sex.None;

		public readonly string _animGraphPostfixOverride;

		[InspectorTooltip("Rank")]
		public StaffRank[] _rank = new StaffRank[5];

		public SharedInstance<StaffCommonDefinition> Common;

		public ExternalBehavior _behaviourTakeBreak => Common.Instance._behaviourTakeBreak;

		public ExternalBehavior _behaviourMaintenance => Common.Instance._behaviourMaintenance;

		public ExternalBehavior _behaviourJobFailure => Common.Instance._behaviourJobFailure;

		public ExternalBehavior _behaviourWaitForJob => Common.Instance._behaviourWaitForJob;

		public ExternalBehavior _behaviourGoToAmbulance => Common.Instance._behaviourGoToAmbulance;

		public float HappinessRateOfChange => Common.Instance.HappinessRateOfChange;

		public float HappinessPromotion => Common.Instance.HappinessPromotion;

		public float HappinessQualification => Common.Instance.HappinessQualification;

		public float HappinessEmptyTrainingSlot => Common.Instance.HappinessEmptyTrainingSlot;

		public float HappinessReadyForPromotion => Common.Instance.HappinessReadyForPromotion;

		public SharedInstance<NotificationMessages.Definition> ResignationWarningMessage => Common.Instance.ResignationWarningMessage;

		public SharedInstance<NotificationMessages.Definition> ResignationLetterMessage => Common.Instance.ResignationLetterMessage;

		public SharedInstance<NotificationMessages.Definition> ResignationSuccessMessage => Common.Instance.ResignationSuccessMessage;

		public float PaySatisfactionVeryUnhappy => Common.Instance.PaySatisfactionVeryUnhappy;

		public float PaySatisfactionUnhappy => Common.Instance.PaySatisfactionUnhappy;

		public float PaySatisfactionSatisfied => Common.Instance.PaySatisfactionSatisfied;

		public float PaySatisfactionHappy => Common.Instance.PaySatisfactionHappy;

		public float PaySatisfactionVeryHappy => Common.Instance.PaySatisfactionVeryHappy;

		public SharedInstance<CharacterStatusEffectDefinition> PromotedStatusEffect => Common.Instance.PromotedStatusEffect;

		public float DizzyVelocity => Common.Instance.DizzyVelocity;

		public float DizzyIncrement => Common.Instance.DizzyIncrement;

		public float DizzyDecrement => Common.Instance.DizzyDecrement;

		public float DizzyEffectTime => Common.Instance.DizzyEffectTime;

		public SharedInstance<CharacterStatusEffectDefinition> DizzyStatusEffect => Common.Instance.DizzyStatusEffect;

		public float EnergyThresholdEnergised => Common.Instance.EnergyThresholdEnergised;

		public float EnergyThresholdTired => Common.Instance.EnergyThresholdTired;

		public float EnergyThresholdExhausted => Common.Instance.EnergyThresholdExhausted;

		public float HappinessEnergised => Common.Instance.HappinessEnergised;

		public float HappinessTired => Common.Instance.HappinessTired;

		public float HappinessExhausted => Common.Instance.HappinessExhausted;

		public SharedInstance<CharacterStatusEffectDefinition> StatusEffectFasterRun => Common.Instance._statusEffectFasterRun;

		public Sprite OnBreakIcon => Common.Instance.OnBreakIcon;

		public Sprite OnBreakOnCallIcon => Common.Instance.OnBreakOnCallIcon;

		public Sprite LookingForWorkIcon => Common.Instance.LookingForWorkIcon;

		public Sprite FiredIcon => Common.Instance.FiredIcon;

		public Sprite TrainingRoomIcon => Common.Instance.TrainingRoomIcon;

		public Sprite ResignedIcon => Common.Instance.ResignedIcon;

		public bool IsUniqueVehicularMechanic => _name == "DLC7VIP";

		public static Type[] AllTypes => _allTypes;

		public static int GetNumTypes()
		{
			return 4;
		}

		public int GetSalary(int rank, float xp)
		{
			if (!_rank.ValidIndex(rank))
			{
				return 99999999;
			}
			return _rank[rank].GetSalary(xp);
		}
	}
}
