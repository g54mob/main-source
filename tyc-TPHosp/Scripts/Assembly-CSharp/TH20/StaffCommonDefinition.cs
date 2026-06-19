using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffCommonDefinition
	{
		[InspectorMargin(8)]
		[InspectorHeader("Behaviours")]
		[InspectorTooltip("Take a break behaviour")]
		public ExternalBehavior _behaviourTakeBreak;

		[InspectorTooltip("Maintenance behaviour")]
		public ExternalBehavior _behaviourMaintenance;

		[InspectorTooltip("Job failure behaviour")]
		public ExternalBehavior _behaviourJobFailure;

		[InspectorTooltip("Wait for job to be free behaviour")]
		public ExternalBehavior _behaviourWaitForJob;

		[InspectorTooltip("Walk to an ambulance and embark")]
		public ExternalBehavior _behaviourGoToAmbulance;

		[InspectorMargin(8)]
		[InspectorHeader("Happiness Modifiers")]
		public float HappinessRateOfChange = 0.1f;

		public float HappinessPromotion = 100f;

		public float HappinessQualification = 50f;

		public float HappinessEmptyTrainingSlot = -5f;

		public float HappinessReadyForPromotion = -10f;

		public float HappinessEnergised = 25f;

		public float HappinessTired = -25f;

		public float HappinessExhausted = -50f;

		public SharedInstance<NotificationMessages.Definition> ResignationWarningMessage;

		public SharedInstance<NotificationMessages.Definition> ResignationLetterMessage;

		public SharedInstance<NotificationMessages.Definition> ResignationSuccessMessage;

		[InspectorMargin(8)]
		[InspectorHeader("Pay Satisfaction")]
		public float PaySatisfactionVeryUnhappy = -50f;

		public float PaySatisfactionUnhappy = -25f;

		public float PaySatisfactionSatisfied;

		public float PaySatisfactionHappy = 25f;

		public float PaySatisfactionVeryHappy = 50f;

		[InspectorMargin(8)]
		[InspectorHeader("Promotion Settings")]
		public readonly SharedInstance<CharacterStatusEffectDefinition> PromotedStatusEffect;

		[InspectorMargin(8)]
		[InspectorHeader("Picked Up Dizzy Effect")]
		public float DizzyVelocity = 0.7f;

		public float DizzyIncrement = 0.2f;

		public float DizzyDecrement = 2f;

		public float DizzyEffectTime = 2f;

		public SharedInstance<CharacterStatusEffectDefinition> DizzyStatusEffect;

		[InspectorMargin(8)]
		[InspectorHeader("Energy Status Effects")]
		public readonly float EnergyThresholdEnergised = 80f;

		public readonly float EnergyThresholdTired = 50f;

		public readonly float EnergyThresholdExhausted = 10f;

		[InspectorMargin(8)]
		[InspectorHeader("Treatment Status Effects")]
		[SerializeField]
		private SharedInstance<CharacterStatusEffectDefinition> _statusEffectCured;

		[SerializeField]
		private SharedInstance<CharacterStatusEffectDefinition> _statusEffectIneffective;

		[SerializeField]
		private SharedInstance<CharacterStatusEffectDefinition> _statusEffectDeath;

		[InspectorMargin(8)]
		[InspectorHeader("General Status Effects")]
		[SerializeField]
		public SharedInstance<CharacterStatusEffectDefinition> _statusEffectFasterRun;

		[InspectorMargin(8)]
		[InspectorHeader("Status Icons")]
		public Sprite OnBreakIcon;

		public Sprite OnBreakOnCallIcon;

		public Sprite LookingForWorkIcon;

		public Sprite FiredIcon;

		public Sprite TrainingRoomIcon;

		public Sprite ResignedIcon;

		public void ApplyTreatmentStatusEffect(Staff staff, Treatment.Outcome outcome)
		{
			CharacterStatusEffectDefinition characterStatusEffectDefinition = null;
			switch (outcome)
			{
			case Treatment.Outcome.Cured:
				characterStatusEffectDefinition = (_statusEffectCured.NotNull() ? _statusEffectCured.Instance : null);
				break;
			case Treatment.Outcome.Ineffective:
				characterStatusEffectDefinition = (_statusEffectIneffective.NotNull() ? _statusEffectIneffective.Instance : null);
				break;
			case Treatment.Outcome.Death:
				characterStatusEffectDefinition = (_statusEffectDeath.NotNull() ? _statusEffectDeath.Instance : null);
				break;
			}
			if (characterStatusEffectDefinition != null && staff.ModifiersComponent != null)
			{
				staff.ModifiersComponent.AddStatusEffect(characterStatusEffectDefinition);
			}
		}
	}
}
