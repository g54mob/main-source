using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Log;

namespace Coherence.Toolkit
{
	public class InputBuffer<T> : IInputBuffer, IInputBufferDebug where T : struct
	{
		private enum UpdateOperation
		{
			Read = 0,
			Write = 1
		}

		private const int DefaultDelay = 3;

		private readonly T[] inputs;

		private readonly long[] frames;

		private bool hasReceivedNonStaleInput;

		private T lastSentInput;

		private int delay;

		private int baseDelay;

		private int head;

		private readonly bool requiresSubsequentFrames;

		private readonly EqualityComparer<T> inputComparer;

		private readonly Logger logger;

		private readonly SortedList<long, T> receiveQueue;

		public int Size => 0;

		public T LastInput => default(T);

		public long LastFrame => 0L;

		public long LastSentFrame { get; private set; }

		public long LastReceivedFrame { get; private set; }

		public long LastAcknowledgedFrame { get; private set; }

		public long LastConsumedFrame { get; private set; }

		public long? MispredictionFrame { get; private set; }

		public int Delay
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		int IInputBuffer.QueueCount => 0;

		public event StaleInputHandler OnStaleInput
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

		public InputBuffer(int bufferSize, int inputDelay = 3, bool requiresSubsequentFrames = false, EqualityComparer<T> comparer = null)
		{
		}

		public void Reset()
		{
		}

		public bool ShouldPause(long currentFrame, long commonReceivedFrame)
		{
			return false;
		}

		public bool DequeueForSending(long currentFrame, out long inputFrame, out T input, out bool differsFromPrevious)
		{
			inputFrame = default(long);
			input = default(T);
			differsFromPrevious = default(bool);
			return false;
		}

		public bool TryGetInput(long frame, out T input, bool clearPredictionMark = true)
		{
			input = default(T);
			return false;
		}

		public bool AddInput(in T input, long frame)
		{
			return false;
		}

		public bool ReceiveInput(in T input, long frame)
		{
			return false;
		}

		private bool ReceiveInputInternal(in T input, long frame)
		{
			return false;
		}

		private void FillWithLastInputForNonSubsequent()
		{
		}

		private bool Rewrite(in T newInput, long frame)
		{
			return false;
		}

		private bool Append(in T input, long frame)
		{
			return false;
		}

		private void Update(long currentFrame, UpdateOperation operation)
		{
		}

		private void MoveHead()
		{
		}

		bool IInputBuffer.TryPeekInput(long frame, out object input)
		{
			input = null;
			return false;
		}

		[Conditional("COHERENCE_LOG_TRACE")]
		private void DebugPrintBuffer(string operationName)
		{
		}

		void IInputBufferDebug.DebugPrint(string operationName, bool includeInputs)
		{
		}
	}
}
