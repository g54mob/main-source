using Restory.Data.Email;
using Restory.Gameplay.Quests;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public class EmailButtonRemoveQuestItemHandler : EmailBlockableButtonHandlerBase<EmailButtonRemoveQuestItemSettings>
	{
		private readonly QuestItemService questItemService;

		public EmailButtonRemoveQuestItemHandler(QuestItemService questItemService)
		{
			this.questItemService = questItemService;
		}

		protected override void HandleButtonPress(EmailButtonRemoveQuestItemSettings buttonSettings)
		{
			questItemService.DestroyPlacedQuestItem(buttonSettings.QuestItemToRemove);
		}

		protected override bool ShouldButtonBeEnabled(EmailButtonRemoveQuestItemSettings buttonSettings)
		{
			return questItemService.IsQuestItemPlaced(buttonSettings.QuestItemToRemove);
		}
	}
}
