namespace Castle.Core.Logging
{
	public interface IExtendedLogger : ILogger
	{
		IContextProperties GlobalProperties { get; }

		IContextProperties ThreadProperties { get; }

		IContextStacks ThreadStacks { get; }
	}
}
