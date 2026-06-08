using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime.EventStreams.Internal
{
	public abstract class EnumerableEventOutputStream<T, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TE> : EventOutputStream<T, TE>, IEnumerableEventOutputStream<T, TE>, IEventOutputStream<T, TE>, IDisposable, IEnumerable<T>, IEnumerable, IAsyncEnumerable<T> where T : IEventStreamEvent where TE : EventStreamException, new()
	{
		private const string MutuallyExclusiveExceptionMessage = "Stream has already begun processing. Event-driven and Enumerable traversals of the stream are mutually exclusive. You can either use the event driven or enumerable interface, but not both.";

		protected bool IsEnumerated { get; set; }

		protected EnumerableEventOutputStream(Stream stream)
			: this(stream, (IEventStreamDecoder)null)
		{
		}

		protected EnumerableEventOutputStream(Stream stream, IEventStreamDecoder eventStreamDecoder)
			: base(stream, eventStreamDecoder)
		{
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (IsProcessing)
			{
				throw new InvalidOperationException("Stream has already begun processing. Event-driven and Enumerable traversals of the stream are mutually exclusive. You can either use the event driven or enumerable interface, but not both.");
			}
			Queue<T> events = new Queue<T>();
			IsEnumerated = true;
			IsProcessing = true;
			EventReceived += delegate(object sender, EventStreamEventReceivedArgs<T> args)
			{
				events.Enqueue(args.EventStreamEvent);
			};
			byte[] buffer = new byte[base.BufferSize];
			while (IsProcessing)
			{
				if (events.Count > 0)
				{
					T val = events.Dequeue();
					if (val is IEventStreamTerminalEvent)
					{
						IsProcessing = false;
						Dispose();
					}
					yield return val;
				}
				else
				{
					try
					{
						ReadFromStream(buffer);
					}
					catch (Exception ex)
					{
						IsProcessing = false;
						Dispose();
						throw WrapException(ex);
					}
				}
			}
		}

		public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken)
		{
			if (IsProcessing)
			{
				throw new InvalidOperationException("Stream has already begun processing. Event-driven and Enumerable traversals of the stream are mutually exclusive. You can either use the event driven or enumerable interface, but not both.");
			}
			Queue<T> events = new Queue<T>();
			IsEnumerated = true;
			IsProcessing = true;
			EventReceived += delegate(object sender, EventStreamEventReceivedArgs<T> args)
			{
				events.Enqueue(args.EventStreamEvent);
			};
			byte[] buffer = new byte[base.BufferSize];
			while (IsProcessing)
			{
				if (events.Count > 0)
				{
					T val = events.Dequeue();
					if (val is IEventStreamTerminalEvent)
					{
						IsProcessing = false;
						Dispose();
					}
					yield return val;
				}
				else
				{
					try
					{
						await ReadFromStreamAsync(buffer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception ex)
					{
						IsProcessing = false;
						Dispose();
						throw WrapException(ex);
					}
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override void StartProcessing()
		{
			if (IsEnumerated)
			{
				throw new InvalidOperationException("Stream has already begun processing. Event-driven and Enumerable traversals of the stream are mutually exclusive. You can either use the event driven or enumerable interface, but not both.");
			}
			base.StartProcessing();
		}

		public override async Task StartProcessingAsync()
		{
			if (IsEnumerated)
			{
				throw new InvalidOperationException("Stream has already begun processing. Event-driven and Enumerable traversals of the stream are mutually exclusive. You can either use the event driven or enumerable interface, but not both.");
			}
			await base.StartProcessingAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
