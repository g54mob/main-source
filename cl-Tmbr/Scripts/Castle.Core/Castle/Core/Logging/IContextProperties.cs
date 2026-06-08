namespace Castle.Core.Logging
{
	public interface IContextProperties
	{
		object this[string key] { get; set; }
	}
}
