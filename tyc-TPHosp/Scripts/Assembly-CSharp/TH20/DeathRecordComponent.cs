using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class DeathRecordComponent : EntityComponent
	{
		public string CauseOfDeath { get; private set; }

		public IllnessDefinition Illness { get; private set; }

		protected DeathRecordComponent()
		{
		}

		public void Initialise(Character owner)
		{
			CauseOfDeath = ScriptLocalization.Patient_DeathRecord.Undefined_CS;
			if (owner == null)
			{
				return;
			}
			AttributeFloat attribute = owner.GetCharacterAttributes().GetAttribute(CharacterAttributes.Type.Health);
			if (attribute != null && attribute.Value() <= 0f)
			{
				CauseOfDeath = ScriptLocalization.Patient_DeathRecord.HealthDepleted_CS;
			}
			if (owner is Patient patient)
			{
				Illness = patient.Illness;
				if (patient.TreatmentOutcome == Treatment.Outcome.Death)
				{
					CauseOfDeath = LocalisedString.Replace(ScriptLocalization.Patient_DeathRecord.TreatmentFailed_CS, "{[ILLNESS]}", Illness.Name.Translation);
				}
			}
		}
	}
}
