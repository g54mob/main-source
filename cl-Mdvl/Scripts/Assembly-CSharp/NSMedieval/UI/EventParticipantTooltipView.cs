using System.Collections.Generic;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.State;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class EventParticipantTooltipView : TooltipViewNew
	{
		private CreatureBase participant;

		private bool locked;

		public void SetData(IEventParticipant participant, bool locked = false)
		{
			this.participant = (CreatureBase)participant;
			this.locked = locked;
		}

		protected override List<string> GetLinesToShow()
		{
			ClearLines();
			AppendLine(participant.GetFullName(), TooltipStyles.TooltipTitle);
			CreatureBase creatureBase = participant;
			if (!(creatureBase is HumanoidInstance humanoidInstance))
			{
				if (creatureBase is AnimalInstance { PetOwner: not null } animalInstance)
				{
					AppendLine(UiUtils.Localize.GetText("owner_name") + ": " + animalInstance.PetOwner.GetFullName());
				}
			}
			else
			{
				AppendLine(HumanoidUtils.GetReligiousThresholdLocalized(humanoidInstance));
				if (humanoidInstance.WorkerBehaviour == null)
				{
					AppendLine(NpcUtils.GetLocalizedFactionName(humanoidInstance));
					AppendLine(NpcUtils.GetLocalizedFactionFriendliness(humanoidInstance));
					AppendLine(NpcUtils.GetLocalizedFactionAlignment(humanoidInstance));
				}
				else
				{
					AppendLine(" ");
					AppendLine("worker_skills".ToLocalized(), TooltipStyles.TooltipSubtitleLineStyle);
					AppendLine(HumanoidUtils.GetSkillsListLocalized(humanoidInstance));
				}
			}
			if (locked)
			{
				AppendLine(UiUtils.Localize.GetText("cant_access_event") ?? "", TooltipStyles.DefaultRed);
			}
			return lines;
		}
	}
}
