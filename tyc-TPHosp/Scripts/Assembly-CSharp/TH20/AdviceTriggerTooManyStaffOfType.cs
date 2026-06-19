using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerTooManyStaffOfType : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("Too Many Staff")]
		[InspectorTooltip("The staff type we are interested in")]
		[SerializeField]
		private StaffDefinition.Type _staffType;

		[InspectorTooltip("Number of that staff type before we start caring about this")]
		[SerializeField]
		private int _numStaffThreshold = 3;

		[InspectorTooltip("Percentage of staff of this type that will trigger a low priority message")]
		[SerializeField]
		private float _percentIdleLowPri = 0.2f;

		[InspectorTooltip("Percentage of staff of this type that will trigger a medium priority message")]
		[SerializeField]
		private float _percentIdleMedPri = 0.4f;

		[InspectorTooltip("Percentage of staff of this type that will trigger a high priority message")]
		[SerializeField]
		private float _percentIdleHiPri = 0.6f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.CharacterManager.StaffMembers.Count <= 0)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			int num2 = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (staffMember.Definition._type == _staffType)
				{
					num2++;
					if (staffMember.CurrentMode == Staff.Mode.Break)
					{
						num++;
					}
				}
			}
			if (num2 <= 0 || num2 < _numStaffThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			float num3 = (float)num / (float)num2;
			if (num3 < _percentIdleLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num3 < _percentIdleMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num3 < _percentIdleHiPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
