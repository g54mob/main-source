using UnityEngine;

namespace TH20
{
	public class AdvisorTriggerMachineUpgrade : AdvisorTrigger
	{
		[SerializeField]
		private AdvisorTriggerMachineUpgradeDefinition _definition;

		[SerializeField]
		private string _message;

		[SerializeField]
		private Sprite _icon;

		private Vector3 _interestPoint;

		public AdvisorTriggerMachineUpgrade(AdvisorTriggerMachineUpgradeDefinition definition)
			: base(definition)
		{
			_definition = definition;
		}

		protected override Advisor.PriorityLevel GetMessagePriority()
		{
			foreach (Room allRoom in Level.WorldState.AllRooms)
			{
				if (allRoom.Definition.IsHospitalOrBay)
				{
					continue;
				}
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					RoomItemUpgradeDefinition nextUpgrade = item.Definition.GetNextUpgrade(item.UpgradeLevel);
					if (nextUpgrade != null && Level.Metagame.HasUnlocked(nextUpgrade) && Level.FinanceManager.CanAfford(nextUpgrade.Cost) && item.GetComponent<RoomItemUpgradeComponent>() == null)
					{
						QualificationDefinition upgradeQualification = item.UpgradeQualification;
						_icon = item.Icon;
						_interestPoint = item.WorldPosition;
						_message = LocalisedString.Replace(_definition.MessageLocalised.Translation, new SubPair[2]
						{
							new SubPair("{[MACHINE]}", item.LocalisedName),
							new SubPair("{[QUALIFICATION]}", upgradeQualification.NameLocalised.Translation)
						});
						return Advisor.PriorityLevel.High;
					}
				}
			}
			return Advisor.PriorityLevel.DontShow;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			AdvisorMessageDefinition result = base.ConstructAdvisorMessage();
			result.Icon = _icon;
			result.Message = _message;
			result.CameraFocus = _interestPoint;
			return result;
		}
	}
}
