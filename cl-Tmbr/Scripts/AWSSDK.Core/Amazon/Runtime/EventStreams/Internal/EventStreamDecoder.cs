using System;
using System.Globalization;
using System.Net;
using Amazon.Runtime.Internal.Util;
using ThirdParty.Ionic.Zlib;

namespace Amazon.Runtime.EventStreams.Internal
{
	public class EventStreamDecoder : IEventStreamDecoder, IDisposable
	{
		private delegate int ProcessRead(byte[] data, int offset, int length);

		private enum DecoderState
		{
			Start = 0,
			ReadPrelude = 1,
			ProcessPrelude = 2,
			ReadMessage = 3,
			Error = 4
		}

		private ProcessRead[] _stateFns;

		private DecoderState _state;

		private int _currentMessageLength;

		private int _amountBytesRead;

		private byte[] _workingMessage;

		private byte[] _workingBuffer;

		private CrcCalculatorStream _runningChecksumStream;

		private bool disposedValue;

		public object MessageReceivedContext { get; set; }

		public event EventHandler<EventStreamMessageReceivedEventArgs> MessageReceived;

		public EventStreamDecoder()
		{
			_workingBuffer = new byte[12];
			_stateFns = new ProcessRead[5] { Start, ReadPrelude, ProcessPrelude, ReadMessage, Error };
			_state = DecoderState.Start;
		}

		private int Start(byte[] data, int offset, int length)
		{
			_workingMessage = null;
			_amountBytesRead = 0;
			if (_runningChecksumStream != null)
			{
				_runningChecksumStream.Dispose();
			}
			_runningChecksumStream = new CrcCalculatorStream(new NullStream());
			_currentMessageLength = 0;
			_state = DecoderState.ReadPrelude;
			return 0;
		}

		private int ReadPrelude(byte[] data, int offset, int length)
		{
			int num = 0;
			if (_amountBytesRead < 12)
			{
				num = Math.Min(length - offset, 12 - _amountBytesRead);
				Buffer.BlockCopy(data, offset, _workingBuffer, _amountBytesRead, num);
				_amountBytesRead += num;
			}
			if (_amountBytesRead == 12)
			{
				_state = DecoderState.ProcessPrelude;
			}
			return num;
		}

		private int ProcessPrelude(byte[] data, int offset, int length)
		{
			_runningChecksumStream.Write(_workingBuffer, 0, 8);
			int num = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(_workingBuffer, 8));
			if (num != _runningChecksumStream.Crc32)
			{
				_state = DecoderState.Error;
				throw new EventStreamChecksumFailureException(string.Format(CultureInfo.InvariantCulture, "Message Prelude Checksum failure. Expected {0} but was {1}", num, _runningChecksumStream.Crc32));
			}
			_runningChecksumStream.Write(_workingBuffer, 8, 4);
			_currentMessageLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(_workingBuffer, 0));
			_workingMessage = new byte[_currentMessageLength];
			Buffer.BlockCopy(_workingBuffer, 0, _workingMessage, 0, 12);
			_state = DecoderState.ReadMessage;
			return 0;
		}

		private int ReadMessage(byte[] data, int offset, int length)
		{
			int num = 0;
			if (_amountBytesRead < _currentMessageLength)
			{
				num = Math.Min(length - offset, _currentMessageLength - _amountBytesRead);
				Buffer.BlockCopy(data, offset, _workingMessage, _amountBytesRead, num);
				_amountBytesRead += num;
			}
			if (_amountBytesRead == _currentMessageLength)
			{
				ProcessMessage();
			}
			return num;
		}

		private void ProcessMessage()
		{
			try
			{
				EventStreamMessage message = EventStreamMessage.FromBuffer(_workingMessage, 0, _currentMessageLength);
				this.MessageReceived?.Invoke(this, new EventStreamMessageReceivedEventArgs(message, MessageReceivedContext));
				_state = DecoderState.Start;
			}
			catch (Exception)
			{
				_state = DecoderState.Error;
				throw;
			}
		}

		private int Error(byte[] data, int offset, int length)
		{
			throw new EventStreamDecoderIllegalStateException("Event stream decoder is in an error state. Create a new instance, and use a new stream to continue");
		}

		public void ProcessData(byte[] data, int offset, int length)
		{
			int num = length - offset;
			while (offset < num)
			{
				offset += _stateFns[(int)_state](data, offset, length);
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposedValue)
			{
				return;
			}
			if (disposing)
			{
				if (_runningChecksumStream != null)
				{
					_runningChecksumStream.Dispose();
					_runningChecksumStream = null;
				}
				_workingMessage = null;
			}
			disposedValue = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
