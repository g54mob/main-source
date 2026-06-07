using System.Collections.Generic;
using Mirror;
using Unity.Profiling;
using UnityEngine;

namespace Mirage.NetworkProfiler
{
	internal class CountRecorder
	{
		private readonly ProfilerCounter<int> _profilerCount;

		private readonly ProfilerCounter<int> _profilerBytes;

		private readonly ProfilerCounter<int> _profilerPerSecond;

		private readonly object _instance;

		private readonly INetworkInfoProvider _provider;

		internal readonly Frames _frames;

		private int _count;

		private int _bytes;

		private int _perSecond;

		private readonly Queue<(float time, int bytes)> _perSecondQueue = new Queue<(float, int)>();

		private int _frameIndex = -1;

		public CountRecorder(object instance, INetworkInfoProvider provider, ProfilerCounter<int> profilerCount, ProfilerCounter<int> profilerBytes, ProfilerCounter<int> profilerPerSecond)
		{
			_provider = provider;
			_instance = instance;
			_profilerCount = profilerCount;
			_profilerBytes = profilerBytes;
			_profilerPerSecond = profilerPerSecond;
			_frames = new Frames();
		}

		public void OnMessage(NetworkDiagnostics.MessageInfo obj)
		{
			if (_frameIndex != -1)
			{
				_count += obj.count;
				_bytes += obj.bytes * obj.count;
				Frame frame = _frames.GetFrame(_frameIndex);
				frame.Messages.Add(new MessageInfo(obj, _provider, frame.Messages.Count));
				frame.Bytes++;
			}
		}

		public void EndFrame(int frameIndex)
		{
			CaclulatePerSecond(Time.time, _bytes);
			_count = 0;
			_bytes = 0;
			_frameIndex = frameIndex + 1;
			Frame frame = _frames.GetFrame(_frameIndex);
			frame.Messages.Clear();
			frame.Bytes = 0;
		}

		private void CaclulatePerSecond(float now, int bytes)
		{
			_perSecond += bytes;
			_perSecondQueue.Enqueue((now, bytes));
			float num = now - 1f;
			while (_perSecondQueue.Peek().time < num)
			{
				_perSecond -= _perSecondQueue.Dequeue().bytes;
			}
		}
	}
}
