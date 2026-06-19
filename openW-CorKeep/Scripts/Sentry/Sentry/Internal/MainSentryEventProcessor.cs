using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using Sentry.Extensibility;
using Sentry.Protocol;
using Sentry.Reflection;

namespace Sentry.Internal
{
	internal class MainSentryEventProcessor : ISentryEventProcessor
	{
		internal const string CultureInfoKey = "Current Culture";

		internal const string CurrentUiCultureKey = "Current UI Culture";

		internal const string MemoryInfoKey = "Memory Info";

		internal const string ThreadPoolInfoKey = "ThreadPool Info";

		internal const string IsDynamicCodeKey = "Dynamic Code";

		internal const string IsDynamicCodeCompiledKey = "Compiled";

		internal const string IsDynamicCodeSupportedKey = "Supported";

		private readonly Enricher _enricher;

		private readonly SentryOptions _options;

		internal Func<ISentryStackTraceFactory> SentryStackTraceFactoryAccessor { get; }

		internal string? Release => _options.SettingLocator.GetRelease();

		internal string? Distribution => _options.Distribution;

		public MainSentryEventProcessor(SentryOptions options, Func<ISentryStackTraceFactory> sentryStackTraceFactoryAccessor)
		{
			_options = options;
			SentryStackTraceFactoryAccessor = sentryStackTraceFactoryAccessor;
			_enricher = new Enricher(options);
		}

		public SentryEvent Process(SentryEvent @event)
		{
			_options.LogDebug("Running main event processor on: Event {0}", @event.EventId);
			TimeZoneInfo local = TimeZoneInfo.Local;
			if (local != null)
			{
				@event.Contexts.Device.Timezone = local;
			}
			IDictionary<string, string> cultureInfoMapped = null;
			if (!@event.Contexts.ContainsKey("Current Culture"))
			{
				IDictionary<string, string> dictionary = CultureInfoToDictionary(CultureInfo.CurrentCulture);
				if (dictionary != null)
				{
					cultureInfoMapped = dictionary;
					@event.Contexts["Current Culture"] = dictionary;
				}
			}
			if (!@event.Contexts.ContainsKey("Current UI Culture"))
			{
				IDictionary<string, string> dictionary2 = CultureInfoToDictionary(CultureInfo.CurrentUICulture);
				if (dictionary2 != null && (cultureInfoMapped == null || dictionary2.Any((KeyValuePair<string, string> p) => !cultureInfoMapped.Contains(p))))
				{
					@event.Contexts["Current UI Culture"] = dictionary2;
				}
			}
			AddMemoryInfo(@event.Contexts);
			AddThreadPoolInfo(@event.Contexts);
			if (@event.ServerName == null)
			{
				if (!string.IsNullOrEmpty(_options.ServerName))
				{
					@event.ServerName = _options.ServerName;
				}
				else if (_options.SendDefaultPii)
				{
					@event.ServerName = Environment.MachineName;
				}
			}
			SentryEvent sentryEvent = @event;
			SentryLevel? level = sentryEvent.Level;
			SentryLevel valueOrDefault = level.GetValueOrDefault();
			if (!level.HasValue)
			{
				valueOrDefault = SentryLevel.Error;
				SentryEvent sentryEvent2 = sentryEvent;
				SentryLevel? level2 = valueOrDefault;
				sentryEvent2.Level = level2;
			}
			sentryEvent = @event;
			if (sentryEvent.Release == null)
			{
				string text = (sentryEvent.Release = Release);
			}
			sentryEvent = @event;
			if (sentryEvent.Distribution == null)
			{
				string text = (sentryEvent.Distribution = Distribution);
			}
			if (@event.Exception?.StackTrace == null)
			{
				SentryStackTrace sentryStackTrace = @event.SentryExceptions?.FirstOrDefault()?.Stacktrace ?? SentryStackTraceFactoryAccessor().Create();
				if (sentryStackTrace != null)
				{
					Thread currentThread = Thread.CurrentThread;
					SentryThread sentryThread = new SentryThread
					{
						Crashed = false,
						Current = true,
						Name = currentThread.Name,
						Id = currentThread.ManagedThreadId,
						Stacktrace = sentryStackTrace
					};
					IEnumerable<SentryThread>? sentryThreads = @event.SentryThreads;
					IEnumerable<SentryThread> sentryThreads2;
					if (sentryThreads == null || !sentryThreads.Any())
					{
						sentryThreads2 = new SentryThread[1] { sentryThread }.AsEnumerable();
					}
					else
					{
						IEnumerable<SentryThread> enumerable = new List<SentryThread>(@event.SentryThreads) { sentryThread };
						sentryThreads2 = enumerable;
					}
					@event.SentryThreads = sentryThreads2;
					if (sentryStackTrace is DebugStackTrace debugStackTrace)
					{
						debugStackTrace.MergeDebugImagesInto(@event);
					}
				}
			}
			IEnumerable<SentryException> sentryExceptions = @event.SentryExceptions;
			if (sentryExceptions != null)
			{
				foreach (SentryException item in sentryExceptions)
				{
					if (item.Stacktrace is DebugStackTrace debugStackTrace2)
					{
						debugStackTrace2.MergeDebugImagesInto(@event);
					}
				}
			}
			if (_options.ReportAssembliesMode != ReportAssembliesMode.None)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					if (assembly.IsDynamic)
					{
						continue;
					}
					AssemblyName name = assembly.GetName();
					if (name.Name != null)
					{
						string value = _options.ReportAssembliesMode switch
						{
							ReportAssembliesMode.Version => name.Version?.ToString() ?? string.Empty, 
							ReportAssembliesMode.InformationalVersion => assembly.GetVersion() ?? string.Empty, 
							_ => throw new ArgumentOutOfRangeException($"Report assemblies mode '{_options.ReportAssembliesMode}' is not yet supported"), 
						};
						if (!string.IsNullOrWhiteSpace(value))
						{
							@event.Modules[name.Name] = value;
						}
					}
				}
			}
			_enricher.Apply(@event);
			return @event;
		}

		private static void AddMemoryInfo(SentryContexts contexts)
		{
		}

		private static void AddThreadPoolInfo(SentryContexts contexts)
		{
			ThreadPool.GetMinThreads(out var workerThreads, out var completionPortThreads);
			ThreadPool.GetMaxThreads(out var workerThreads2, out var completionPortThreads2);
			ThreadPool.GetAvailableThreads(out var workerThreads3, out var completionPortThreads3);
			contexts["ThreadPool Info"] = new ThreadPoolInfo(workerThreads, completionPortThreads, workerThreads2, completionPortThreads2, workerThreads3, completionPortThreads3);
		}

		private static IDictionary<string, string>? CultureInfoToDictionary(CultureInfo cultureInfo)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!string.IsNullOrWhiteSpace(cultureInfo.Name))
			{
				dictionary.Add("name", cultureInfo.Name);
			}
			if (!string.IsNullOrWhiteSpace(cultureInfo.DisplayName))
			{
				dictionary.Add("display_name", cultureInfo.DisplayName);
			}
			Calendar calendar = cultureInfo.Calendar;
			if (calendar != null)
			{
				dictionary.Add("calendar", calendar.GetType().Name);
			}
			if (dictionary.Count <= 0)
			{
				return null;
			}
			return dictionary;
		}
	}
}
