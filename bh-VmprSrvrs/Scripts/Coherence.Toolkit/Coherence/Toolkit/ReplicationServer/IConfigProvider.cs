namespace Coherence.Toolkit.ReplicationServer
{
	public interface IConfigProvider
	{
		string ExecutablePath { get; }

		string[] GatherSchemaPaths();
	}
}
