using System;
using System.Collections.Generic;
using System.Linq;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;
using Sentry.Protocol;

namespace Sentry.Internal
{
	internal class MainExceptionProcessor : ISentryEventExceptionProcessor
	{
		private class Counter
		{
			private int _value;

			public int GetNextValue()
			{
				return _value++;
			}
		}

		private const string ExceptionDataKeyPrefix = "sentry:";

		internal const string ExceptionDataTagKey = "sentry:tag:";

		internal const string ExceptionDataContextKey = "sentry:context:";

		private readonly SentryOptions _options;

		internal Func<ISentryStackTraceFactory> SentryStackTraceFactoryAccessor { get; }

		public MainExceptionProcessor(SentryOptions options, Func<ISentryStackTraceFactory> sentryStackTraceFactoryAccessor)
		{
			_options = options;
			SentryStackTraceFactoryAccessor = sentryStackTraceFactoryAccessor;
		}

		public void Process(Exception exception, SentryEvent sentryEvent)
		{
			_options.LogDebug("Running processor on exception: {0}", exception.Message);
			IReadOnlyList<SentryException> sentryExceptions = CreateSentryExceptions(exception);
			MoveExceptionDataToEvent(sentryEvent, sentryExceptions);
			sentryEvent.SentryExceptions = sentryExceptions;
		}

		internal IReadOnlyList<SentryException> CreateSentryExceptions(Exception exception)
		{
			List<SentryException> list = WalkExceptions(exception).Reverse().ToList();
			if (list.Count == 1)
			{
				Mechanism mechanism = list[0].Mechanism;
				if (mechanism != null)
				{
					mechanism.ExceptionId = null;
					mechanism.ParentId = null;
					if (mechanism.IsDefaultOrEmpty())
					{
						list[0].Mechanism = null;
					}
				}
			}
			return list;
		}

		private IEnumerable<SentryException> WalkExceptions(Exception exception)
		{
			return WalkExceptions(exception, new Counter(), null, null);
		}

		private IEnumerable<SentryException> WalkExceptions(Exception exception, Counter counter, int? parentId, string? source)
		{
			Exception ex = exception;
			while (ex != null)
			{
				int id = counter.GetNextValue();
				yield return BuildSentryException(ex, id, parentId, source);
				if (ex is AggregateException aex)
				{
					for (int i = 0; i < aex.InnerExceptions.Count; i++)
					{
						ex = aex.InnerExceptions[i];
						source = string.Format("{0}[{1}]", "InnerExceptions", i);
						IEnumerable<SentryException> enumerable = WalkExceptions(ex, counter, id, source);
						foreach (SentryException item in enumerable)
						{
							yield return item;
						}
					}
					break;
				}
				ex = ex.InnerException;
				parentId = id;
				source = "InnerException";
			}
		}

		private static void MoveExceptionDataToEvent(SentryEvent sentryEvent, IEnumerable<SentryException> sentryExceptions)
		{
			List<string> list = new List<string>();
			int num = 0;
			foreach (SentryException sentryException in sentryExceptions)
			{
				IDictionary<string, object> dictionary = sentryException.Mechanism?.Data;
				if (dictionary == null || dictionary.Count == 0)
				{
					num++;
					continue;
				}
				foreach (KeyValuePair<string, object> item in dictionary)
				{
					PolyfillExtensions.Deconstruct(item, out var key, out var value);
					string text = key;
					object obj = value;
					if (text.Length > "sentry:tag:".Length && obj is string value2 && text.StartsWith("sentry:tag:", StringComparison.OrdinalIgnoreCase))
					{
						key = text;
						int length = "sentry:tag:".Length;
						sentryEvent.SetTag(key.Substring(length, key.Length - length), value2);
						list.Add(text);
					}
					else if (text.Length > "sentry:context:".Length && !obj.IsNull() && text.StartsWith("sentry:context:", StringComparison.OrdinalIgnoreCase))
					{
						SentryContexts contexts = sentryEvent.Contexts;
						key = text;
						int length = "sentry:context:".Length;
						contexts[key.Substring(length, key.Length - length)] = obj;
						list.Add(text);
					}
					else if (text.StartsWith("sentry:", StringComparison.OrdinalIgnoreCase))
					{
						sentryEvent.SetExtra($"Exception[{num}][{text}]", obj);
						list.Add(text);
					}
				}
				foreach (string item2 in list)
				{
					dictionary.Remove(item2);
				}
				list.Clear();
				num++;
			}
		}

		private SentryException BuildSentryException(Exception exception, int id, int? parentId, string? source)
		{
			SentryException ex = new SentryException
			{
				Type = exception.GetType().FullName,
				Module = exception.GetType().Assembly.FullName,
				Value = ((exception is AggregateException exception2) ? exception2.GetRawMessage() : exception.Message),
				ThreadId = Environment.CurrentManagedThreadId
			};
			Mechanism mechanism = GetMechanism(exception, id, parentId, source);
			if (!mechanism.IsDefaultOrEmpty())
			{
				ex.Mechanism = mechanism;
			}
			SentryException ex2 = ex;
			if (ex2.Stacktrace == null)
			{
				SentryStackTrace sentryStackTrace = (ex2.Stacktrace = SentryStackTraceFactoryAccessor().Create(exception));
			}
			return ex;
		}

		private static Mechanism GetMechanism(Exception exception, int id, int? parentId, string? source)
		{
			Mechanism mechanism = new Mechanism();
			if (exception.HelpLink != null)
			{
				mechanism.HelpLink = exception.HelpLink;
			}
			if (exception.Data[Mechanism.HandledKey] is bool value)
			{
				mechanism.Handled = value;
				exception.Data.Remove(Mechanism.HandledKey);
			}
			else if (exception.StackTrace != null)
			{
				mechanism.Handled = true;
			}
			else
			{
				mechanism.Handled = null;
			}
			if (exception.Data[Mechanism.MechanismKey] is string type)
			{
				mechanism.Type = type;
				exception.Data.Remove(Mechanism.MechanismKey);
			}
			if (exception.Data[Mechanism.DescriptionKey] is string description)
			{
				mechanism.Description = description;
				exception.Data.Remove(Mechanism.DescriptionKey);
			}
			foreach (string item in exception.Data.Keys.OfType<string>())
			{
				mechanism.Data[item] = exception.Data[item];
			}
			mechanism.ExceptionId = id;
			mechanism.ParentId = parentId;
			mechanism.Source = source;
			mechanism.IsExceptionGroup = exception is AggregateException;
			if (source != null)
			{
				mechanism.Type = "chained";
			}
			return mechanism;
		}
	}
}
