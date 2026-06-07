using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Coherence.Log;
using Coherence.RSL;
using Coherence.Toolkit.ReplicationServer;
using Unity.Profiling;

namespace Coherence
{
	public class ReplicationServerLite : IReplicationServer
	{
		private ReplicationServer rsl;

		private IExtendedDefinition root;

		private ReplicationServerConfig config;

		private CancellationTokenSource cts;

		private Thread runThread;

		private Thread autoShutdownThread;

		private Logger logger;

		private bool running;

		private readonly ProfilerMarker tickProfilerMarker;

		private const int TICK_INTERVAL_MS = 16;

		private const int EMPTY_RS_TICKER_MS = 10000;

		public event LogHandler OnLog
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event ExitHandler OnExit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public ReplicationServerLite(IExtendedDefinition root, ReplicationServerConfig config)
		{
		}

		public bool Start()
		{
			return false;
		}

		private void RunAutoShutdown()
		{
		}

		private void Run()
		{
		}

		public bool Stop(int timeoutMs = 10000)
		{
			return false;
		}

		[Conditional("COHERENCE_RSL_PROFILING")]
		private void StartThreadProfiling()
		{
		}

		[Conditional("COHERENCE_RSL_PROFILING")]
		private void StopThreadProfiling()
		{
		}

		[Conditional("COHERENCE_RSL_PROFILING")]
		private void StartTickProfiling()
		{
		}

		[Conditional("COHERENCE_RSL_PROFILING")]
		private void StopTickProfiling()
		{
		}
	}
}
