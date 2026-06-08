public class CustomQuestsConfirmationAbandon : TwoChoiceDialog
{
	private readonly string TEMPLATE_MESSAGE = "tid_quest_label_21";

	public void Setup(string currentActiveQuestName)
	{
		string format = Te.xt(TEMPLATE_MESSAGE);
		format = string.Format(format, currentActiveQuestName);
		SetMessage(format);
	}
}
