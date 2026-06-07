using System.Collections.Generic;
using System.Threading;
using Data.FactoryFloor;

public static class FactoryObjectInputBufferSystem
{
	public class System
	{
		private struct QueuedPair
		{
			public FactoryObjectInputBuffer Buffer;

			public int InputIndex;

			public QueuedPair(FactoryObjectInputBuffer buffer, int inputIndex)
			{
				Buffer = buffer;
				InputIndex = inputIndex;
			}
		}

		private readonly Queue<QueuedPair> _queuedBuffers = new Queue<QueuedPair>();

		private bool _isRunning;

		public void QueueClearInputBuffer(FactoryObjectInputBuffer inputBuffer, int inputIndex)
		{
			if (_isRunning)
			{
				_queuedBuffers.Enqueue(new QueuedPair(inputBuffer, inputIndex));
				return;
			}
			_isRunning = true;
			inputBuffer.CallClearedInputBufferEvent(inputIndex);
			ClearQueueInline();
			_isRunning = false;
		}

		public void ClearQueueInline()
		{
			while (_queuedBuffers.Count > 0)
			{
				QueuedPair queuedPair = _queuedBuffers.Dequeue();
				queuedPair.Buffer.CallClearedInputBufferEvent(queuedPair.InputIndex);
			}
		}
	}

	private static readonly Dictionary<int, System> _queuedBuffers = new Dictionary<int, System>();

	public static void QueueClearInputBuffer(FactoryObjectInputBuffer inputBuffer, int inputIndex)
	{
		if (!_queuedBuffers.TryGetValue(Thread.CurrentThread.ManagedThreadId, out var value))
		{
			value = new System();
			lock (_queuedBuffers)
			{
				_queuedBuffers.Add(Thread.CurrentThread.ManagedThreadId, value);
			}
		}
		value.QueueClearInputBuffer(inputBuffer, inputIndex);
	}
}
