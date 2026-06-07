namespace ModApi.Craft.Program
{
	public class LogMessage
	{
		public bool Error { get; set; }

		public string Message { get; set; }

		public string Source { get; internal set; }

		public int? ThreadId { get; set; }

		public override string ToString()
		{
			return string.Format("{0}> {1}{2}", ThreadId.HasValue ? ThreadId.ToString() : ">", (Source != null) ? (Source + ": ") : string.Empty, Message);
		}
	}
}
