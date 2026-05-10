using System.Collections.Generic;
using ScheduleOne.Property;

namespace ScheduleOne.Dialogue
{
	public class DialogueController_Employee : DialogueController
	{
		private ScheduleOne.Property.Property selectedProperty;

		private void Awake()
		{
		}

		public override void ChoiceCallback(string choiceLabel)
		{
		}

		public override void ModifyChoiceList(string dialogueLabel, ref List<DialogueChoiceData> existingChoices)
		{
		}

		private List<DialogueChoiceData> GetChoices()
		{
			return null;
		}

		private ScheduleOne.Property.Property GetPropertyByCode(string code)
		{
			return null;
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
	}
}
