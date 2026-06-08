public class CustomQuestsConfirmationChange : TwoChoiceDialog
{
	private readonly string TEMPLATE_MESSAGE = "tid_quest_change_epic_message";

	public void Setup(string currentActiveQuestName, string selectedQuestName)
	{
		string format = Te.xt(TEMPLATE_MESSAGE);
		format = string.Format(format, currentActiveQuestName, selectedQuestName);
		SetMessage(format);
	}
}
