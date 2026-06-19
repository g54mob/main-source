using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerStaffPromotions : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("Staff Promotions")]
		[InspectorTooltip("The minimum number of staff until we start caring about this... Must be greater than 0!")]
		[SerializeField]
		private int _minStaffThreshold = 8;

		[InspectorTooltip("If this proportion of staff or more are waiting for promotion then trigger a low priority message.")]
		[SerializeField]
		private float _lowPriThreshold = 0.18f;

		[InspectorTooltip("If this proportion of staff or more are waiting for promotion then trigger a medium priority message.")]
		[SerializeField]
		private float _medPriThreshold = 0.24f;

		[InspectorTooltip("If this proportion of staff or more are waiting for promotion then trigger a high priority message.")]
		[SerializeField]
		private float _highPriThreshold = 0.3f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			int count = Level.CharacterManager.StaffMembers.Count;
			if (count < _minStaffThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			int num = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (staffMember.IsReadyForPromotion)
				{
					num++;
				}
			}
			float num2 = (float)num / (float)count;
			if (num2 < _lowPriThreshold)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if (num2 < _medPriThreshold)
			{
				return Advisor.PriorityLevel.Low;
			}
			if (num2 < _highPriThreshold)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
