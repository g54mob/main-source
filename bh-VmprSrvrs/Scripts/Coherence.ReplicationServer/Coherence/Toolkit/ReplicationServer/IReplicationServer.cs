namespace Coherence.Toolkit.ReplicationServer
{
	public interface IReplicationServer
	{
		event LogHandler OnLog;

		event ExitHandler OnExit;

		bool Start();

		bool Stop(int timeoutMs = 0);
	}
}
