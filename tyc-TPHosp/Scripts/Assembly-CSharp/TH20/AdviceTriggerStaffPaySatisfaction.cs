using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerStaffPaySatisfaction : AdviceTrigger
	{
		[SerializeField]
		[InspectorTooltip("The minimum number of staff with below satisfied pay...")]
		private int _minStaffThreshold = 8;

		[SerializeField]
		[InspectorTooltip("The priority level of the message.")]
		private Advisor.PriorityLevel _priorityLevel = Advisor.PriorityLevel.High;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			int num = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (!staffMember.IsSatisfiedWithSalary)
				{
					num++;
				}
			}
			if (num < _minStaffThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			return _priorityLevel;
		}
	}
}
