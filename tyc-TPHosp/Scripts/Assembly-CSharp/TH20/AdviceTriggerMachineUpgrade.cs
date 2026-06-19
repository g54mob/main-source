using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerMachineUpgrade : AdviceTrigger
	{
		private string _message;

		private Sprite _icon;

		public override Advisor.PriorityLevel GetMessagePriority()
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
						_message = LocalisedString.Replace(MessageLocalised.Translation, new SubPair[2]
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
			return result;
		}
	}
}
