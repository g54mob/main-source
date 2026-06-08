using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Amazon.Runtime.EventStreams;
using Amazon.Runtime.EventStreams.Internal;

namespace Amazon.S3.Model
{
	public sealed class SelectObjectContentEventStream : EnumerableEventOutputStream<IS3Event, S3EventStreamException>, ISelectObjectContentEventStream, IEnumerableEventOutputStream<IS3Event, S3EventStreamException>, IEventOutputStream<IS3Event, S3EventStreamException>, IDisposable, IEnumerable<IS3Event>, IEnumerable
	{
		private volatile bool _isProcessing;

		protected override IDictionary<string, Func<IEventStreamMessage, IS3Event>> EventMapping { get; } = new Dictionary<string, Func<IEventStreamMessage, IS3Event>>
		{
			{
				"===UNKNOWN===",
				(IEventStreamMessage payload) => new UnknownEventStreamEvent(payload)
			},
			{
				"Records",
				(IEventStreamMessage payload) => new RecordsEvent(payload)
			},
			{
				"Stats",
				(IEventStreamMessage payload) => new StatsEvent(payload)
			},
			{
				"Progress",
				(IEventStreamMessage payload) => new ProgressEvent(payload)
			},
			{
				"Cont",
				(IEventStreamMessage payload) => new ContinuationEvent(payload)
			},
			{
				"End",
				(IEventStreamMessage payload) => new EndEvent(payload)
			}
		};

		protected override IDictionary<string, Func<IEventStreamMessage, S3EventStreamException>> ExceptionMapping { get; } = new Dictionary<string, Func<IEventStreamMessage, S3EventStreamException>>();

		protected override bool IsProcessing
		{
			get
			{
				return _isProcessing;
			}
			set
			{
				_isProcessing = value;
			}
		}

		public override event EventHandler<EventStreamEventReceivedArgs<IS3Event>> EventReceived;

		public override event EventHandler<EventStreamExceptionReceivedArgs<S3EventStreamException>> ExceptionReceived;

		public event EventHandler<EventStreamEventReceivedArgs<RecordsEvent>> RecordsEventReceived;

		public event EventHandler<EventStreamEventReceivedArgs<StatsEvent>> StatsEventReceived;

		public event EventHandler<EventStreamEventReceivedArgs<ProgressEvent>> ProgressEventReceived;

		public event EventHandler<EventStreamEventReceivedArgs<ContinuationEvent>> ContinuationEventReceived;

		public event EventHandler<EventStreamEventReceivedArgs<EndEvent>> EndEventReceived;

		public SelectObjectContentEventStream(Stream selectObjectStream)
			: this(selectObjectStream, null)
		{
		}

		public SelectObjectContentEventStream(Stream selectObjectStream, IEventStreamDecoder eventStreamDecoder)
			: base(selectObjectStream, eventStreamDecoder)
		{
			base.EventReceived += delegate(object sender, EventStreamEventReceivedArgs<IS3Event> args)
			{
				EventReceived?.Invoke(this, args);
			};
			base.ExceptionReceived += delegate(object sender, EventStreamExceptionReceivedArgs<S3EventStreamException> args)
			{
				ExceptionReceived?.Invoke(this, args);
			};
			base.Decoder.MessageReceived += delegate(object sender, EventStreamMessageReceivedEventArgs args)
			{
				IS3Event iS3Event;
				try
				{
					iS3Event = ConvertMessageToEvent(args.Message);
				}
				catch (UnknownEventStreamMessageTypeException)
				{
					return;
				}
				EventReceived?.Invoke(this, new EventStreamEventReceivedArgs<IS3Event>(iS3Event));
				if (RaiseEvent(this.RecordsEventReceived, iS3Event) || RaiseEvent(this.StatsEventReceived, iS3Event) || RaiseEvent(this.ProgressEventReceived, iS3Event) || RaiseEvent(this.ContinuationEventReceived, iS3Event))
				{
					_ = 1;
				}
				else
					RaiseEvent(this.EndEventReceived, iS3Event);
			};
		}

		private bool RaiseEvent<T>(EventHandler<EventStreamEventReceivedArgs<T>> eventHandler, IS3Event ev) where T : class, IS3Event
		{
			if (ev is T eventStreamEvent)
			{
				eventHandler?.Invoke(this, new EventStreamEventReceivedArgs<T>(eventStreamEvent));
				return true;
			}
			return false;
		}
	}
}
