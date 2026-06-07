namespace ModApi.Craft.Program
{
	public class LogService : ILogService
	{
		public int? ActiveThreadId { get; set; }

		public event LogMessageDelegate LogAdded;

		public void Log(string message, IThreadContext context = null, ProgramNode node = null)
		{
			AddMessage(message, error: false, context, null);
		}

		public void LogError(string message, IThreadContext context = null, ProgramNode node = null)
		{
			AddMessage(message, error: true, context, node);
		}

		private void AddMessage(string message, bool error, IThreadContext context, ProgramNode node)
		{
			string text = string.Empty;
			if (error && context?.NextInstruction != null)
			{
				text = context.NextInstruction.ToString();
				if (context.NextInstruction != node && node != null)
				{
					text = text + " : " + node.ToString();
				}
			}
			LogMessage message2 = new LogMessage
			{
				Message = message,
				Error = error,
				ThreadId = ActiveThreadId,
				Source = text
			};
			this.LogAdded?.Invoke(message2);
		}
	}
}
