using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomPrestigeLevel
	{
		public int Points;

		[InspectorName("Staff Happiness Modifier")]
		public float HappinessModifier;

		public float PatientHappinessModifier;

		public float StaffRoomEnergyMultiplier = 1f;

		public LocalisedString HappinessDescription;
	}
}
