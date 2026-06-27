namespace Restory.UI.Presenters.Notifications
{
	public sealed class GUI_MoneyNotification : GUI_NotificationBase
	{
		public void SetMoneyAmount(int moneyAmount)
		{
			text.text = string.Format("+ {0}{1}", "¥", moneyAmount);
		}
	}
}
