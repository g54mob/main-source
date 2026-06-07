namespace ModApi.Scripts.State.Validation
{
	public class ValidationMessage
	{
		public ClickAction ClickAction { get; set; }

		public string Message { get; set; }

		public ValidationMessageType MessageType { get; set; }

		public int PartID { get; set; }

		public int Priority { get; set; }
	}
}
