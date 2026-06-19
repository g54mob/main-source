using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Force.Crc32;
using Sentry.Internal;
using Sentry.Internal.Extensions;
using Sentry.Protocol.Metrics;

namespace Sentry
{
	internal class MetricAggregator : IMetricAggregator, IDisposable
	{
		internal const string DisposingMessage = "Disposing MetricAggregator.";

		internal const string AlreadyDisposedMessage = "Already disposed MetricAggregator.";

		internal const string CancelledMessage = "Stopping the Metric Aggregator due to a cancellation.";

		internal const string ShutdownScheduledMessage = "Shutdown scheduled. Stopping by: {0}.";

		internal const string ShutdownImmediatelyMessage = "Exiting immediately due to 0 shutdown timeout.";

		internal const string FlushShutdownMessage = "Shutdown token triggered. Exiting metric aggregator.";

		private readonly SentryOptions _options;

		private readonly IMetricHub _metricHub;

		private readonly SemaphoreSlim _codeLocationLock = new SemaphoreSlim(1, 1);

		private readonly ReaderWriterLockSlim _bucketsLock = new ReaderWriterLockSlim();

		private readonly CancellationTokenSource _shutdownSource;

		private volatile bool _disposed;

		private readonly Lazy<Dictionary<long, ConcurrentDictionary<string, Metric>>> _buckets = new Lazy<Dictionary<long, ConcurrentDictionary<string, Metric>>>(() => new Dictionary<long, ConcurrentDictionary<string, Metric>>());

		internal long _lastClearedStaleLocations = DateTimeOffset.UtcNow.GetDayBucketKey();

		internal readonly ConcurrentDictionary<long, HashSet<MetricResourceIdentifier>> _seenLocations = new ConcurrentDictionary<long, HashSet<MetricResourceIdentifier>>();

		internal Dictionary<long, Dictionary<MetricResourceIdentifier, SentryStackFrame>> _pendingLocations = new Dictionary<long, Dictionary<MetricResourceIdentifier, SentryStackFrame>>();

		internal readonly Task _loopTask;

		private readonly SemaphoreSlim _flushLock = new SemaphoreSlim(1, 1);

		internal Dictionary<long, ConcurrentDictionary<string, Metric>> Buckets => _buckets.Value;

		internal MetricAggregator(SentryOptions options, IMetricHub metricHub, CancellationTokenSource? shutdownSource = null, bool disableLoopTask = false)
		{
			_options = options;
			_metricHub = metricHub;
			_shutdownSource = shutdownSource ?? new CancellationTokenSource();
			if (disableLoopTask)
			{
				_options.LogDebug("LoopTask disabled.");
				_loopTask = Task.CompletedTask;
			}
			else
			{
				options.LogDebug("Starting MetricsAggregator.");
				_loopTask = Task.Run((Func<Task>)RunLoopAsync);
			}
		}

		public void Increment(string key, double value = 1.0, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
			Emit(MetricType.Counter, key, value, unit, tags, timestamp, stackLevel + 1);
		}

		public void Gauge(string key, double value = 1.0, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
			Emit(MetricType.Gauge, key, value, unit, tags, timestamp, stackLevel + 1);
		}

		public void Distribution(string key, double value = 1.0, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
			Emit(MetricType.Distribution, key, value, unit, tags, timestamp, stackLevel + 1);
		}

		public void Set(string key, int value, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
			Emit(MetricType.Set, key, value, unit, tags, timestamp, stackLevel + 1);
		}

		public void Set(string key, string value, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
			int num = (int)Crc32Algorithm.Compute(Encoding.UTF8.GetBytes(value)) & -1;
			Emit(MetricType.Set, key, num, unit, tags, timestamp, stackLevel + 1);
		}

		public virtual void Timing(string key, double value, MeasurementUnit.Duration unit = MeasurementUnit.Duration.Second, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
			Emit(MetricType.Distribution, key, value, unit, tags, timestamp, stackLevel + 1);
		}

		public IDisposable StartTimer(string key, MeasurementUnit.Duration unit = MeasurementUnit.Duration.Second, IDictionary<string, string>? tags = null, int stackLevel = 1)
		{
			return new Timing(this, _metricHub, _options, key, unit, tags, stackLevel + 1);
		}

		private void Emit(MetricType type, string key, double value = 1.0, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
			DateTimeOffset valueOrDefault = timestamp.GetValueOrDefault();
			if (!timestamp.HasValue)
			{
				valueOrDefault = DateTimeOffset.UtcNow;
				timestamp = valueOrDefault;
			}
			MeasurementUnit valueOrDefault2 = unit.GetValueOrDefault();
			if (!unit.HasValue)
			{
				valueOrDefault2 = MeasurementUnit.None;
				unit = valueOrDefault2;
			}
			Dictionary<string, string> updatedTags = ((tags != null) ? new Dictionary<string, string>(tags) : new Dictionary<string, string>());
			updatedTags.AddIfNotNullOrEmpty("release", _options.Release);
			updatedTags.AddIfNotNullOrEmpty("environment", _options.Environment);
			ISpan span = _metricHub.GetSpan();
			ITransactionTracer transactionTracer = span?.GetTransaction();
			if (transactionTracer != null)
			{
				updatedTags.AddIfNotNullOrEmpty("transaction", transactionTracer.TransactionName);
			}
			Func<string, Metric> addValueFactory = type switch
			{
				MetricType.Counter => (string _) => new CounterMetric(key, value, unit.Value, updatedTags, timestamp), 
				MetricType.Gauge => (string _) => new GaugeMetric(key, value, unit.Value, updatedTags, timestamp), 
				MetricType.Distribution => (string _) => new DistributionMetric(key, value, unit.Value, updatedTags, timestamp), 
				MetricType.Set => (string _) => new SetMetric(key, (int)value, unit.Value, updatedTags, timestamp), 
				_ => throw new ArgumentOutOfRangeException("type", type, "Unknown MetricType"), 
			};
			GetOrAddTimeBucket(timestamp.Value.GetTimeBucketKey()).AddOrUpdate(MetricHelper.GetMetricBucketKey(type, key, unit.Value, updatedTags), addValueFactory, delegate(string _, Metric metric)
			{
				lock (metric)
				{
					metric.Add(value);
					return metric;
				}
			});
			ExperimentalMetricsOptions experimentalMetrics = _options.ExperimentalMetrics;
			if (experimentalMetrics != null && experimentalMetrics.EnableCodeLocations)
			{
				RecordCodeLocation(type, key, unit.Value, stackLevel + 1, timestamp.Value);
			}
			if (!(span is TransactionTracer transactionTracer2))
			{
				if (span is SpanTracer spanTracer)
				{
					spanTracer.MetricsSummary.Add(type, key, value, unit, tags);
				}
			}
			else
			{
				transactionTracer2.MetricsSummary.Add(type, key, value, unit, tags);
			}
		}

		private ConcurrentDictionary<string, Metric> GetOrAddTimeBucket(long bucketKey)
		{
			_bucketsLock.EnterUpgradeableReadLock();
			try
			{
				if (Buckets.TryGetValue(bucketKey, out ConcurrentDictionary<string, Metric> value))
				{
					return value;
				}
				_bucketsLock.EnterWriteLock();
				try
				{
					if (Buckets.TryGetValue(bucketKey, out value))
					{
						return value;
					}
					ConcurrentDictionary<string, Metric> concurrentDictionary = new ConcurrentDictionary<string, Metric>();
					Buckets[bucketKey] = concurrentDictionary;
					return concurrentDictionary;
				}
				finally
				{
					_bucketsLock.ExitWriteLock();
				}
			}
			finally
			{
				_bucketsLock.ExitUpgradeableReadLock();
			}
		}

		internal virtual void RecordCodeLocation(MetricType type, string key, MeasurementUnit unit, int stackLevel, DateTimeOffset timestamp)
		{
			long dayBucketKey = timestamp.GetDayBucketKey();
			MetricResourceIdentifier metricResourceIdentifier = new MetricResourceIdentifier(type, key, unit);
			HashSet<MetricResourceIdentifier> orAdd = _seenLocations.GetOrAdd(dayBucketKey, (long _) => new HashSet<MetricResourceIdentifier>());
			_codeLocationLock.Wait();
			try
			{
				if (!orAdd.Add(metricResourceIdentifier))
				{
					return;
				}
				SentryStackFrame codeLocation = GetCodeLocation(stackLevel + 1);
				if (codeLocation != null)
				{
					if (!_pendingLocations.TryGetValue(dayBucketKey, out Dictionary<MetricResourceIdentifier, SentryStackFrame> value))
					{
						value = new Dictionary<MetricResourceIdentifier, SentryStackFrame>();
						_pendingLocations[dayBucketKey] = value;
					}
					value[metricResourceIdentifier] = codeLocation;
				}
			}
			finally
			{
				_codeLocationLock.Release();
			}
		}

		internal SentryStackFrame? GetCodeLocation(int stackLevel)
		{
			StackTrace stackTrace = new StackTrace(fNeedFileInfo: true);
			IList<SentryStackFrame> frames = DebugStackTrace.Create(_options, stackTrace, isCurrentStackTrace: false).Frames;
			if (frames.Count < stackLevel)
			{
				return null;
			}
			int num = stackLevel + 1;
			return frames[frames.Count - num];
		}

		private async Task RunLoopAsync()
		{
			_options.LogDebug("MetricsAggregator Started.");
			using CancellationTokenSource shutdownTimeout = new CancellationTokenSource();
			bool shutdownRequested = false;
			try
			{
				while (!shutdownTimeout.IsCancellationRequested)
				{
					try
					{
						await Task.Delay(_options.ShutdownTimeout, _shutdownSource.Token).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (OperationCanceledException) when (_options.ShutdownTimeout == TimeSpan.Zero)
					{
						_options.LogDebug("Exiting immediately due to 0 shutdown timeout.");
						await shutdownTimeout.CancelAsync().ConfigureAwait(continueOnCapturedContext: false);
						break;
					}
					catch (OperationCanceledException)
					{
						_options.LogDebug("Shutdown scheduled. Stopping by: {0}.", _options.ShutdownTimeout);
						shutdownTimeout.CancelAfterSafe(_options.ShutdownTimeout);
						shutdownRequested = true;
					}
					await FlushAsync(shutdownRequested, shutdownTimeout.Token).ConfigureAwait(continueOnCapturedContext: false);
					if (shutdownRequested)
					{
						break;
					}
				}
			}
			catch (Exception exception)
			{
				_options.LogFatal(exception, "Exception in the Metric Aggregator.");
				throw;
			}
		}

		public async Task FlushAsync(bool force = true, CancellationToken cancellationToken = default(CancellationToken))
		{
			try
			{
				await _flushLock.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				foreach (long flushableBucket in GetFlushableBuckets(force))
				{
					cancellationToken.ThrowIfCancellationRequested();
					_options.LogDebug("Flushing metrics for bucket {0}", flushableBucket);
					_bucketsLock.EnterWriteLock();
					ConcurrentDictionary<string, Metric> concurrentDictionary;
					try
					{
						if (!Buckets.ContainsKey(flushableBucket))
						{
							continue;
						}
						concurrentDictionary = Buckets[flushableBucket];
						Buckets.Remove(flushableBucket);
						goto IL_010c;
					}
					finally
					{
						_bucketsLock.ExitWriteLock();
					}
					IL_010c:
					_metricHub.CaptureMetrics(concurrentDictionary.Values);
					_options.LogDebug("Metric flushed for bucket {0}", flushableBucket);
				}
				foreach (var (num2, locations) in FlushableLocations())
				{
					cancellationToken.ThrowIfCancellationRequested();
					_options.LogDebug("Flushing code locations: ", num2);
					CodeLocations codeLocations = new CodeLocations(num2, locations);
					_metricHub.CaptureCodeLocations(codeLocations);
					_options.LogDebug("Code locations flushed: ", num2);
				}
				ClearStaleLocations();
			}
			catch (OperationCanceledException)
			{
				_options.LogInfo("Shutdown token triggered. Exiting metric aggregator.");
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Error processing metrics.");
			}
			finally
			{
				if (_flushLock.CurrentCount < 1)
				{
					_flushLock.Release();
				}
			}
		}

		internal IEnumerable<long> GetFlushableBuckets(bool force = false)
		{
			if (!_buckets.IsValueCreated)
			{
				yield break;
			}
			_bucketsLock.EnterReadLock();
			long[] array;
			try
			{
				array = Buckets.Keys.ToArray();
			}
			finally
			{
				_bucketsLock.ExitReadLock();
			}
			long[] array2;
			if (force)
			{
				array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					yield return array2[i];
				}
				yield break;
			}
			DateTimeOffset cutoff = MetricHelper.GetCutoff();
			array2 = array;
			foreach (long num in array2)
			{
				if (DateTimeOffset.FromUnixTimeSeconds(num) < cutoff)
				{
					yield return num;
				}
			}
		}

		private Dictionary<long, Dictionary<MetricResourceIdentifier, SentryStackFrame>> FlushableLocations()
		{
			_codeLocationLock.Wait();
			try
			{
				Dictionary<long, Dictionary<MetricResourceIdentifier, SentryStackFrame>> pendingLocations = _pendingLocations;
				_pendingLocations = new Dictionary<long, Dictionary<MetricResourceIdentifier, SentryStackFrame>>();
				return pendingLocations;
			}
			finally
			{
				_codeLocationLock.Release();
			}
		}

		internal void ClearStaleLocations(DateTimeOffset? testNow = null)
		{
			DateTimeOffset timestamp = testNow ?? DateTimeOffset.UtcNow;
			long dayBucketKey = timestamp.GetDayBucketKey();
			if (_lastClearedStaleLocations == dayBucketKey || timestamp.Minute < 1)
			{
				return;
			}
			long[] array = _seenLocations.Keys.ToArray();
			foreach (long num in array)
			{
				if (num < dayBucketKey)
				{
					_seenLocations.TryRemove(num, out HashSet<MetricResourceIdentifier> _);
				}
			}
			_lastClearedStaleLocations = dayBucketKey;
		}

		public async ValueTask DisposeAsync()
		{
			_options.LogDebug("Disposing MetricAggregator.");
			if (_disposed)
			{
				_options.LogDebug("Already disposed MetricAggregator.");
				return;
			}
			_disposed = true;
			try
			{
				await _shutdownSource.CancelAsync().ConfigureAwait(continueOnCapturedContext: false);
				await _loopTask.ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
				_options.LogDebug("Stopping the Metric Aggregator due to a cancellation.");
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Async Disposing the Metric Aggregator threw an exception.");
			}
			finally
			{
				_flushLock.Dispose();
				_shutdownSource.Dispose();
				_loopTask.Dispose();
			}
		}

		public void Dispose()
		{
			try
			{
				DisposeAsync().AsTask().GetAwaiter().GetResult();
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Disposing the Metric Aggregator threw an exception.");
			}
		}
	}
}
