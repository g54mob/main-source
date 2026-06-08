using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime.EventStreams.Internal
{
	public abstract class EventOutputStream<T, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TE> : IEventOutputStream<T, TE>, IDisposable where T : IEventStreamEvent where TE : EventStreamException, new()
	{
		protected const string UnknownEventKey = "===UNKNOWN===";

		private const string HeaderMessageType = ":message-type";

		private const string HeaderEventType = ":event-type";

		private const string HeaderExceptionType = ":exception-type";

		private const string HeaderErrorCode = ":error-code";

		private const string HeaderErrorMessage = ":error-message";

		private const string EventHeaderMessageTypeValue = "event";

		private const string ExceptionHeaderMessageTypeValue = "exception";

		private const string ErrorHeaderMessageTypeValue = "error";

		private const string WrappedErrorMessage = "Error.";

		private bool _disposed;

		public int BufferSize { get; set; } = 8192;

		protected Stream NetworkStream { get; }

		protected IEventStreamDecoder Decoder { get; }

		protected abstract IDictionary<string, Func<IEventStreamMessage, T>> EventMapping { get; }

		protected abstract IDictionary<string, Func<IEventStreamMessage, TE>> ExceptionMapping { get; }

		protected abstract bool IsProcessing { get; set; }

		public virtual event EventHandler<EventStreamEventReceivedArgs<T>> EventReceived;

		public virtual event EventHandler<EventStreamExceptionReceivedArgs<TE>> ExceptionReceived;

		protected EventOutputStream(Stream stream)
			: this(stream, (IEventStreamDecoder)null)
		{
		}

		protected EventOutputStream(Stream stream, IEventStreamDecoder eventStreamDecoder)
		{
			NetworkStream = stream;
			Decoder = eventStreamDecoder ?? new EventStreamDecoder();
		}

		protected T ConvertMessageToEvent(EventStreamMessage eventStreamMessage)
		{
			Dictionary<string, IEventStreamHeader> headers = eventStreamMessage.Headers;
			string text;
			try
			{
				text = headers[":message-type"].AsString();
			}
			catch (KeyNotFoundException innerException)
			{
				throw new EventStreamValidationException("Message type missing from event stream message.", innerException);
			}
			switch (text)
			{
			case "event":
			{
				string key;
				try
				{
					key = headers[":event-type"].AsString();
				}
				catch (KeyNotFoundException innerException3)
				{
					throw new EventStreamValidationException("Event Type not defined for event.", innerException3);
				}
				try
				{
					return EventMapping[key](eventStreamMessage);
				}
				catch (KeyNotFoundException)
				{
					return EventMapping["===UNKNOWN==="](eventStreamMessage);
				}
			}
			case "exception":
			{
				string text2;
				try
				{
					text2 = headers[":exception-type"].AsString();
				}
				catch (KeyNotFoundException innerException4)
				{
					throw new EventStreamValidationException("Exception Type not defined for exception.", innerException4);
				}
				try
				{
					throw ExceptionMapping[text2](eventStreamMessage);
				}
				catch (KeyNotFoundException)
				{
					throw new UnknownEventStreamException(text2);
				}
			}
			case "error":
			{
				int errorCode;
				try
				{
					errorCode = headers[":error-code"].AsInt32();
				}
				catch (KeyNotFoundException innerException2)
				{
					throw new EventStreamValidationException("Error Code not defined for error.", innerException2);
				}
				IEventStreamHeader value = null;
				bool flag = headers.TryGetValue(":error-message", out value);
				throw new EventStreamErrorCodeException(errorCode, flag ? value.AsString() : string.Empty);
			}
			default:
				throw new UnknownEventStreamMessageTypeException();
			}
		}

		protected void Process()
		{
			Task.Run(() => ProcessLoopAsync());
		}

		private async Task ProcessLoopAsync()
		{
			byte[] buffer = new byte[BufferSize];
			try
			{
				while (IsProcessing)
				{
					await ReadFromStreamAsync(buffer).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception ex)
			{
				IsProcessing = false;
				TE eventStreamException = WrapException(ex);
				this.ExceptionReceived?.Invoke(this, new EventStreamExceptionReceivedArgs<TE>(eventStreamException));
			}
		}

		protected void ReadFromStream(byte[] buffer)
		{
			int num = NetworkStream.Read(buffer, 0, buffer.Length);
			if (num > 0)
			{
				Decoder.ProcessData(buffer, 0, num);
			}
			else
			{
				IsProcessing = false;
			}
		}

		protected Task ReadFromStreamAsync(byte[] buffer)
		{
			return ReadFromStreamAsync(buffer, CancellationToken.None);
		}

		protected async Task ReadFromStreamAsync(byte[] buffer, CancellationToken cancellationToken)
		{
			int num = await NetworkStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (num > 0)
			{
				Decoder.ProcessData(buffer, 0, num);
			}
			else
			{
				IsProcessing = false;
			}
		}

		protected TE WrapException(Exception ex)
		{
			if (ex is TE result)
			{
				return result;
			}
			object[] args = new object[2] { "Error.", ex };
			return (TE)Activator.CreateInstance(typeof(TE), args);
		}

		public virtual void StartProcessing()
		{
			if (!IsProcessing)
			{
				IsProcessing = true;
				Process();
			}
		}

		public virtual async Task StartProcessingAsync()
		{
			if (!IsProcessing)
			{
				IsProcessing = true;
				await ProcessLoopAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					IsProcessing = false;
					NetworkStream?.Dispose();
					Decoder?.Dispose();
				}
				_disposed = true;
			}
		}
	}
}
