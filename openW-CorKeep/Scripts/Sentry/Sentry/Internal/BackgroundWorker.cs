using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;
using Sentry.Internal.Http;
using Sentry.Protocol.Envelopes;

namespace Sentry.Internal
{
	internal class BackgroundWorker : IBackgroundWorker, IDisposable
	{
		private readonly ITransport _transport;

		private readonly SentryOptions _options;

		private readonly ConcurrentQueueLite<Envelope> _queue;

		private readonly int _maxItems;

		private readonly CancellationTokenSource _shutdownSource;

		private readonly SemaphoreSlim _queuedEnvelopeSemaphore;

		private volatile bool _disposed;

		private int _currentItems;

		internal Task WorkerTask { get; }

		public int QueuedItems => _queue.Count;

		internal event EventHandler? OnFlushObjectReceived;

		public BackgroundWorker(ITransport transport, SentryOptions options, CancellationTokenSource? shutdownSource = null, ConcurrentQueueLite<Envelope>? queue = null)
		{
			_transport = transport;
			_options = options;
			_queue = queue ?? new ConcurrentQueueLite<Envelope>();
			_maxItems = options.MaxQueueItems;
			_shutdownSource = shutdownSource ?? new CancellationTokenSource();
			_queuedEnvelopeSemaphore = new SemaphoreSlim(0, _maxItems);
			options.LogDebug("Starting BackgroundWorker.");
			WorkerTask = Task.Run((Func<Task>)DoWorkAsync);
		}

		public bool EnqueueEnvelope(Envelope envelope)
		{
			return EnqueueEnvelope(envelope, process: true);
		}

		public bool EnqueueEnvelope(Envelope envelope, bool process)
		{
			if (_disposed)
			{
				throw new ObjectDisposedException("BackgroundWorker");
			}
			SentryId? arg = envelope.TryGetEventId(_options.DiagnosticLogger);
			if (Interlocked.Increment(ref _currentItems) > _maxItems)
			{
				Interlocked.Decrement(ref _currentItems);
				_options.ClientReportRecorder.RecordDiscardedEvents(DiscardReason.QueueOverflow, envelope);
				_options.LogInfo("Discarding envelope {0} because the queue is full.", arg);
				return false;
			}
			_options.LogDebug("Enqueuing envelope {0}", arg);
			_queue.Enqueue(envelope);
			if (process)
			{
				_queuedEnvelopeSemaphore.Release();
			}
			return true;
		}

		public void ProcessQueuedItems(int count)
		{
			_queuedEnvelopeSemaphore.Release(count);
		}

		private async Task DoWorkAsync()
		{
			_options.LogDebug("BackgroundWorker Started.");
			using CancellationTokenSource shutdownTimeout = new CancellationTokenSource();
			bool shutdownRequested = false;
			try
			{
				while (!shutdownTimeout.IsCancellationRequested)
				{
					if (!shutdownRequested)
					{
						try
						{
							await _queuedEnvelopeSemaphore.WaitAsync(_shutdownSource.Token).ConfigureAwait(continueOnCapturedContext: false);
						}
						catch (OperationCanceledException) when (_options.ShutdownTimeout == TimeSpan.Zero)
						{
							_options.LogDebug("Exiting immediately due to 0 shutdown timeout. {0} items in queue.", _queue.Count);
							shutdownTimeout.Cancel();
							break;
						}
						catch (OperationCanceledException)
						{
							_options.LogDebug("Shutdown scheduled. Stopping by: {0}. {1} items in queue.", _options.ShutdownTimeout, _queue.Count);
							shutdownTimeout.CancelAfterSafe(_options.ShutdownTimeout);
							shutdownRequested = true;
						}
					}
					if (_queue.TryPeek(out Envelope envelope))
					{
						SentryId? eventId = envelope.TryGetEventId(_options.DiagnosticLogger);
						try
						{
							using (envelope)
							{
								Task task = _transport.SendEnvelopeAsync(envelope, shutdownTimeout.Token);
								_options.LogDebug("Envelope handed off to transport (event ID: '{0}'). {1} items in queue.", eventId, _queue.Count);
								await task.ConfigureAwait(continueOnCapturedContext: false);
							}
						}
						catch (OperationCanceledException) when (shutdownTimeout.IsCancellationRequested)
						{
							_options.LogInfo("Shutdown token triggered. Time to exit. {0} items in queue.", _queue.Count);
							break;
						}
						catch (Exception exception)
						{
							_options.LogError(exception, "Error while processing envelope (event ID: '{0}'). {1} items in queue.", eventId, _queue.Count);
						}
						finally
						{
							_options.LogDebug("De-queueing event {0}", eventId);
							_queue.TryDequeue(out Envelope _);
							Interlocked.Decrement(ref _currentItems);
							this.OnFlushObjectReceived?.Invoke(envelope, EventArgs.Empty);
						}
						envelope = null;
						continue;
					}
					_options.LogInfo("Exiting the worker with an empty queue.");
					break;
				}
			}
			catch (Exception exception2)
			{
				_options.LogFatal(exception2, "Exception in the background worker.");
				throw;
			}
		}

		public async Task FlushAsync(TimeSpan timeout)
		{
			if (_disposed)
			{
				_options.LogDebug("Worker disposed. Nothing to flush.");
				return;
			}
			using CancellationTokenSource timeoutSource = new CancellationTokenSource();
			using CancellationTokenSource timeoutWithShutdown = CancellationTokenSource.CreateLinkedTokenSource(timeoutSource.Token, _shutdownSource.Token);
			timeoutSource.CancelAfterSafe(timeout);
			try
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				await DoFlushAsync(timeoutWithShutdown.Token).ConfigureAwait(continueOnCapturedContext: false);
				while (!_shutdownSource.IsCancellationRequested && _queue.Count > 0 && stopwatch.Elapsed < timeout)
				{
					await Task.Delay(10, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			finally
			{
				await SendFinalClientReportAsync(timeoutWithShutdown.Token).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private async Task DoFlushAsync(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				_options.LogDebug("Timeout or shutdown already requested. Exiting.");
				return;
			}
			TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();
			cancellationToken.Register(delegate
			{
				completionSource.TrySetCanceled();
			});
			int counter = 0;
			int depth = int.MaxValue;
			OnFlushObjectReceived += EventFlushedCallback;
			try
			{
				int count = _queue.Count;
				if (count != 0)
				{
					Interlocked.Exchange(ref depth, count);
					_options.LogDebug("Tracking depth: {0}.", count);
					if (counter < depth)
					{
						await completionSource.Task.ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				_options.LogDebug("Successfully flushed all events up to call to FlushAsync.");
				if (_transport is CachingTransport cachingTransport && !cancellationToken.IsCancellationRequested)
				{
					_options.LogDebug("Flushing caching transport with remaining flush time.");
					await cachingTransport.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (OperationCanceledException)
			{
				_options.LogDebug("Timeout when trying to flush queue.");
			}
			finally
			{
				OnFlushObjectReceived -= EventFlushedCallback;
			}
			void EventFlushedCallback(object? _, EventArgs __)
			{
				if (Interlocked.Increment(ref counter) >= depth)
				{
					_options.LogDebug("Signaling flush completed.");
					completionSource.TrySetResult(result: true);
				}
			}
		}

		private async Task SendFinalClientReportAsync(CancellationToken cancellationToken)
		{
			ClientReport clientReport = _options.ClientReportRecorder.GenerateClientReport();
			if (clientReport == null)
			{
				return;
			}
			_options.LogDebug("Sending client report after flushing queue.");
			using Envelope envelope = Envelope.FromClientReport(clientReport);
			try
			{
				await _transport.SendEnvelopeAsync(envelope, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
				_options.LogInfo("Timeout or shutdown while trying to send final client report. Exiting.");
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Error while sending final client report (event ID: '{0}').", envelope.TryGetEventId(_options.DiagnosticLogger));
			}
		}

		public void Dispose()
		{
			_options.LogDebug("Disposing BackgroundWorker.");
			if (_disposed)
			{
				_options.LogDebug("Already disposed BackgroundWorker.");
				return;
			}
			_disposed = true;
			try
			{
				_shutdownSource.Cancel();
				WorkerTask.Wait();
			}
			catch (OperationCanceledException)
			{
				_options.LogDebug("Stopping the background worker due to a cancellation.");
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Stopping the background worker threw an exception.");
			}
			finally
			{
				if (!_queue.IsEmpty)
				{
					_options.LogWarning("Worker stopped while {0} were still in the queue.", _queue.Count);
				}
				_queuedEnvelopeSemaphore.Dispose();
				_shutdownSource.Dispose();
				(_transport as IDisposable)?.Dispose();
			}
		}
	}
}
