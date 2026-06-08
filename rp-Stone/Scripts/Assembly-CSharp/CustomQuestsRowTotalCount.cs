public class CustomQuestsRowTotalCount : DialogButton
{
	private const string PROGRESS_TEXT = "tid_quest_label_20";

	private const string COMPLETED_TEXT = "tid_quest_label_20b";

	public void Setup(int amountCompleted, int totalAmount)
	{
		base.HasFocus = false;
		if (amountCompleted < totalAmount)
		{
			string format = Te.xt("tid_quest_label_20");
			format = string.Format(format, amountCompleted, totalAmount);
			label.SetValue(format);
		}
		else
		{
			label.SetValue(Te.xt("tid_quest_label_20b"));
		}
	}
}
