namespace ModApi.Craft.Program
{
	public interface ILogService
	{
		int? ActiveThreadId { get; set; }

		void Log(string message, IThreadContext context = null, ProgramNode node = null);

		void LogError(string message, IThreadContext context = null, ProgramNode node = null);
	}
}
