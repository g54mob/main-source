using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using BestHTTP.Core;
using BestHTTP.Extensions;
using BestHTTP.Logger;

namespace BestHTTP.Connections.HTTP2
{
	public sealed class HTTP2Handler : IHTTPRequestHandler, IDisposable
	{
		private static readonly byte[] MAGIC;

		public const uint MaxValueFor31Bits = 2147483647u;

		public HTTP2SettingsManager settings;

		public HPACKEncoder HPACKEncoder;

		private DateTime lastPingSent;

		private TimeSpan pingFrequency;

		public static int RTTBufferCapacity;

		private CircularBuffer<double> rtts;

		private bool isRunning;

		private AutoResetEvent newFrameSignal;

		private ConcurrentQueue<HTTPRequest> requestQueue;

		private List<HTTP2Stream> clientInitiatedStreams;

		private ConcurrentQueue<HTTP2FrameHeaderAndPayload> newFrames;

		private List<HTTP2FrameHeaderAndPayload> outgoingFrames;

		private uint remoteWindow;

		private DateTime lastInteraction;

		private DateTime goAwaySentAt;

		private HTTPConnection conn;

		private int threadExitCount;

		private long LastStreamId;

		public bool HasCustomRequestProcessor => false;

		public KeepAliveHeader KeepAlive => null;

		public bool CanProcessMultiple => false;

		public double Latency { get; private set; }

		public LoggingContext Context { get; private set; }

		private TimeSpan MaxGoAwayWaitTime => default(TimeSpan);

		public ShutdownTypes ShutdownType { get; private set; }

		public HTTP2Handler(HTTPConnection conn)
		{
		}

		public void Process(HTTPRequest request)
		{
		}

		public void SignalRunnerThread()
		{
		}

		public void RunHandler()
		{
		}

		private void OnRemoteSettingChanged(HTTP2SettingsRegistry registry, HTTP2Settings setting, uint oldValue, uint newValue)
		{
		}

		private void ReadThread()
		{
		}

		private void TryToCleanup()
		{
		}

		private double CalculateLatency()
		{
			return 0.0;
		}

		private HTTP2Stream FindStreamById(uint streamId)
		{
			return null;
		}

		public void Shutdown(ShutdownTypes type)
		{
		}

		public void Dispose()
		{
		}

		private void Dispose(bool disposing)
		{
		}

		~HTTP2Handler()
		{
		}
	}
}
