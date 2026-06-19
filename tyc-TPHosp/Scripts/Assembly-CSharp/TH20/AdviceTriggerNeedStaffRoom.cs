using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerNeedStaffRoom : AdviceTrigger
	{
		[InspectorMargin(8)]
		[InspectorHeader("Need Staff Room")]
		[InspectorTooltip("If we have this or more staff having a break without finding a staff room then trigger a low prioirty message")]
		[SerializeField]
		private float _numWaitingLowPri = 1f;

		[InspectorTooltip("If we have this or more staff having a break without finding a staff room then trigger a medium prioirty message")]
		[SerializeField]
		private float _numWaitingMedPri = 2f;

		[InspectorTooltip("If we have this or more staff having a break without finding a staff room then trigger a high prioirty message")]
		[SerializeField]
		private float _numWaitingHiPri = 5f;

		public override Advisor.PriorityLevel GetMessagePriority()
		{
			int num = 0;
			foreach (Staff staffMember in Level.CharacterManager.StaffMembers)
			{
				if (staffMember.CurrentMode == Staff.Mode.Break && staffMember.GoingToRoom == null && staffMember.RoomUsing != null && staffMember.RoomUsing.Definition._type != RoomDefinition.Type.StaffRoom)
				{
					num++;
				}
			}
			if ((float)num < _numWaitingLowPri)
			{
				return Advisor.PriorityLevel.DontShow;
			}
			if ((float)num < _numWaitingMedPri)
			{
				return Advisor.PriorityLevel.Low;
			}
			if ((float)num < _numWaitingHiPri)
			{
				return Advisor.PriorityLevel.Medium;
			}
			return Advisor.PriorityLevel.High;
		}
	}
}
