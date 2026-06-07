using Mirror;
using UnityEngine;

namespace Mirage.NetworkProfiler
{
	[DefaultExecutionOrder(int.MaxValue)]
	public class NetworkProfilerRecorder : MonoBehaviour
	{
		public delegate void FrameUpdate(int tick);

		internal static CountRecorder _sentCounter;

		internal static CountRecorder _receivedCounter;

		internal const int FRAME_COUNT = 300;

		private int _lastProcessedFrame = -1;

		public static NetworkProfilerRecorder Instance { get; private set; }

		public static event FrameUpdate AfterSample;

		private void Start()
		{
			if (Instance == null)
			{
				NetworkInfoProvider provider = new NetworkInfoProvider();
				_sentCounter = new CountRecorder(null, provider, Counters.SentCount, Counters.SentBytes, Counters.SentPerSecond);
				_receivedCounter = new CountRecorder(null, provider, Counters.ReceiveCount, Counters.ReceiveBytes, Counters.ReceivePerSecond);
				NetworkDiagnostics.InMessageEvent += _receivedCounter.OnMessage;
				NetworkDiagnostics.OutMessageEvent += _sentCounter.OnMessage;
				Instance = this;
				Object.DontDestroyOnLoad(this);
			}
		}

		private void OnDestroy()
		{
			if (Instance == this)
			{
				if (_receivedCounter != null)
				{
					NetworkDiagnostics.InMessageEvent -= _receivedCounter.OnMessage;
				}
				if (_sentCounter != null)
				{
					NetworkDiagnostics.OutMessageEvent -= _sentCounter.OnMessage;
				}
				Instance = null;
			}
		}

		private void LateUpdate()
		{
			if (NetworkServer.active || NetworkClient.active)
			{
				SampleCounts();
				SampleMessages(0);
			}
		}

		private void SampleCounts()
		{
			_ = NetworkServer.active;
		}

		private void SampleMessages(int frame)
		{
			_sentCounter.EndFrame(frame);
			_receivedCounter.EndFrame(frame);
			NetworkProfilerRecorder.AfterSample?.Invoke(frame);
		}
	}
}
