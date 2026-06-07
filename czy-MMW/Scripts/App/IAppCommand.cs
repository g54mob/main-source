using Factory;
using Factory.Pools;

[Serializable(1)]
public interface IAppCommand : IReusable
{
	float Timestamp { get; }

	bool Execute(IApp receiver);
}
