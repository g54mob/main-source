using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Sentry.Extensibility;

namespace Sentry.Internal
{
	internal class DuplicateEventDetectionEventProcessor : ISentryEventProcessor
	{
		private readonly SentryOptions _options;

		private readonly ConditionalWeakTable<object, object?> _capturedObjects = new ConditionalWeakTable<object, object>();

		public DuplicateEventDetectionEventProcessor(SentryOptions options)
		{
			_options = options;
		}

		public SentryEvent? Process(SentryEvent @event)
		{
			if (_options.DeduplicateMode.HasFlag(DeduplicateMode.SameEvent))
			{
				if (_capturedObjects.TryGetValue(@event, out object _))
				{
					_options.LogDebug("Same event instance detected and discarded. EventId: {0}", @event.EventId);
					return null;
				}
				_capturedObjects.Add(@event, null);
			}
			if (@event.Exception == null || !IsDuplicate(@event.Exception, @event.EventId, debugLog: true))
			{
				return @event;
			}
			return null;
		}

		private bool IsDuplicate(Exception ex, SentryId eventId, bool debugLog)
		{
			if (_options.DeduplicateMode.HasFlag(DeduplicateMode.SameExceptionInstance))
			{
				if (_capturedObjects.TryGetValue(ex, out object _))
				{
					if (debugLog)
					{
						_options.LogDebug("Duplicate Exception: 'SameExceptionInstance'. Event {0} will be discarded.", eventId);
					}
					return true;
				}
				_capturedObjects.Add(ex, null);
			}
			if (_options.DeduplicateMode.HasFlag(DeduplicateMode.AggregateException) && ex is AggregateException ex2)
			{
				bool num = ex2.InnerExceptions.Any((Exception e) => IsDuplicate(e, eventId, debugLog: false));
				if (num)
				{
					_options.LogDebug("Duplicate Exception: 'AggregateException'. Event {0} will be discarded.", eventId);
				}
				return num;
			}
			if (_options.DeduplicateMode.HasFlag(DeduplicateMode.InnerException) && ex.InnerException != null && IsDuplicate(ex.InnerException, eventId, debugLog: false))
			{
				_options.LogDebug("Duplicate Exception: 'SameExceptionInstance'. Event {0} will be discarded.", eventId);
				return true;
			}
			return false;
		}
	}
}
