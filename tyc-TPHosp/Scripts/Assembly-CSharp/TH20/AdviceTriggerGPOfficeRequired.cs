using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerGPOfficeRequired : AdviceTrigger
	{
		public override Advisor.PriorityLevel GetMessagePriority()
		{
			foreach (Patient patient in Level.CharacterManager.Patients)
			{
				if (patient.WaitingForRoom == RoomDefinition.Type.GPOffice)
				{
					return Advisor.PriorityLevel.VeryHigh;
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
