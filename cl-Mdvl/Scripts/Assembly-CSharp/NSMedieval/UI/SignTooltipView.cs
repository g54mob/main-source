namespace NSMedieval.UI
{
	public class SignTooltipView : TooltipViewNew
	{
		private string message = string.Empty;

		public void SetTooltipData(string message)
		{
			if (!this.message.Equals(message))
			{
				this.message = message;
				ClearLines();
				AppendLine(message, TooltipStyles.TooltipSign);
			}
		}
	}
}
