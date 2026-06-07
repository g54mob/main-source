using Factory;
using Factory.Pools;

[Serializable(1)]
public abstract class AppCommand : IAppCommand, IReusable
{
	[Serialize(true, null)]
	public float Timestamp { get; protected set; }

	public abstract bool Execute(IApp receiver);

	public abstract void Reset();
}
