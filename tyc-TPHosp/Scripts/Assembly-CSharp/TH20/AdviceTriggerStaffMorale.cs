using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerStaffMorale : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("Staff Morale")]
		[InspectorTooltip("The minimum number of staff until we start caring about this advice")]
		[SerializeField]
		private int _minStaffThreshold = 6;

		[InspectorTooltip("If your staff morale falls below this value then trigger a low priority message.")]
		[SerializeField]
		private float _lowPriThreshold = 0.35f;

		[InspectorTooltip("If your staff morale falls below this value then trigger a medium priority message.")]
		[SerializeField]
		private float _medPriThreshold = 0.25f;

		[InspectorTooltip("If your staff morale falls below this value then trigger a high priority message.")]
		[SerializeField]
		private float _highPriThreshold = 0.2f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (Level.CharacterManager.StaffMembers.Count < _minStaffThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			float staffMorale = Level.CharacterManager.StaffMorale;
			if (staffMorale > _lowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (staffMorale > _medPriThreshold)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (staffMorale > _highPriThreshold)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
