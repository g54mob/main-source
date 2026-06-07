using Coherence.Log;

namespace Coherence.Toolkit.ReplicationServer
{
	public struct LogTargetConfig
	{
		public LogTarget Target;

		public LogFormat Format;

		public LogLevel LogLevel;

		public string FilePath;
	}
}
