using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PatientDefinition : CharacterDefinition
	{
		[InspectorTooltip("Wait for room to be built behaviour")]
		public ExternalBehavior _behaviourWaitForRoom;

		[InspectorTooltip("Death behaviour")]
		public ExternalBehavior _behaviourDeath;

		public Sprite DyingIcon;

		public Sprite RageQuitIcon;

		public Sprite SentHomeIcon;

		public Sprite MoreDiagnosisIcon;

		public Sprite TreatmentSucessIcon;

		public Sprite TreatmentIneffectiveIcon;
	}
}
