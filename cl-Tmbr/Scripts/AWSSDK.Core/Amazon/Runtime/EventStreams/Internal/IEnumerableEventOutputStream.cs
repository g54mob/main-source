using System;
using System.Collections;
using System.Collections.Generic;

namespace Amazon.Runtime.EventStreams.Internal
{
	public interface IEnumerableEventOutputStream<T, TE> : IEventOutputStream<T, TE>, IDisposable, IEnumerable<T>, IEnumerable where T : IEventStreamEvent where TE : EventStreamException, new()
	{
	}
}
