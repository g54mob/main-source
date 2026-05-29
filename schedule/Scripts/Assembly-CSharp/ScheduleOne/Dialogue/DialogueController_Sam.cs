using ScheduleOne.Quests;

namespace ScheduleOne.Dialogue
{
	public class DialogueController_Sam : DialogueController
	{
		private Quest_DefeatCartel questDefeatCartel;

		protected override void Start()
		{
		}

		public override bool CheckChoice(string choiceLabel, out string invalidReason)
		{
			invalidReason = null;
			return false;
		}

		public override string ModifyDialogueText(string dialogueLabel, string dialogueText)
		{
			return null;
		}

		public override void ChoiceCallback(string choiceLabel)
		{
		}
	}
}
