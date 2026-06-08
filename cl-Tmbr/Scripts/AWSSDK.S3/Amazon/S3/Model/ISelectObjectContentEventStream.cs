using System;
using System.Collections;
using System.Collections.Generic;
using Amazon.Runtime.EventStreams;
using Amazon.Runtime.EventStreams.Internal;

namespace Amazon.S3.Model
{
	public interface ISelectObjectContentEventStream : IEnumerableEventOutputStream<IS3Event, S3EventStreamException>, IEventOutputStream<IS3Event, S3EventStreamException>, IDisposable, IEnumerable<IS3Event>, IEnumerable
	{
		new event EventHandler<EventStreamEventReceivedArgs<IS3Event>> EventReceived;

		new event EventHandler<EventStreamExceptionReceivedArgs<S3EventStreamException>> ExceptionReceived;

		event EventHandler<EventStreamEventReceivedArgs<RecordsEvent>> RecordsEventReceived;

		event EventHandler<EventStreamEventReceivedArgs<StatsEvent>> StatsEventReceived;

		event EventHandler<EventStreamEventReceivedArgs<ProgressEvent>> ProgressEventReceived;

		event EventHandler<EventStreamEventReceivedArgs<ContinuationEvent>> ContinuationEventReceived;

		event EventHandler<EventStreamEventReceivedArgs<EndEvent>> EndEventReceived;
	}
}
