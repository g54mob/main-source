namespace Castle.Core.Logging
{
	public interface IContextStacks
	{
		IContextStack this[string key] { get; }
	}
}
