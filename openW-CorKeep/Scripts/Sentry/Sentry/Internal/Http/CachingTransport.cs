using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;
using Sentry.Protocol.Envelopes;

namespace Sentry.Internal.Http
{
	internal class CachingTransport : ITransport, IDisposable
	{
		private const string EnvelopeFileExt = "envelope";

		private const string ProcessingFolder = "__processing";

		private readonly ITransport _innerTransport;

		private readonly SentryOptions _options;

		private readonly bool _failStorage;

		private readonly string _isolatedCacheDirectoryPath;

		private readonly int _keepCount;

		private readonly string _processingDirectoryPath;

		private readonly Signal _workerSignal = new Signal(isReleasedInitially: true);

		private readonly Signal _processingSignal = new Signal(isReleasedInitially: true);

		private readonly Lock _cacheDirectoryLock = new Lock();

		private readonly CancellationTokenSource _workerCts = new CancellationTokenSource();

		private Task _worker;

		private ManualResetEventSlim? _initCacheResetEvent = new ManualResetEventSlim();

		private ManualResetEventSlim? _preInitCacheResetEvent = new ManualResetEventSlim();

		private readonly IFileSystem _fileSystem;

		internal ITransport InnerTransport => _innerTransport;

		public static CachingTransport Create(ITransport innerTransport, SentryOptions options, bool startWorker = true, bool failStorage = false)
		{
			CachingTransport cachingTransport = new CachingTransport(innerTransport, options, failStorage);
			cachingTransport.Initialize(startWorker);
			return cachingTransport;
		}

		private CachingTransport(ITransport innerTransport, SentryOptions options, bool failStorage)
		{
			_innerTransport = innerTransport;
			_options = options;
			_failStorage = failStorage;
			_fileSystem = options.FileSystem;
			_keepCount = ((_options.MaxCacheItems >= 1) ? (_options.MaxCacheItems - 1) : 0);
			_isolatedCacheDirectoryPath = options.TryGetProcessSpecificCacheDirectoryPath() ?? throw new InvalidOperationException("Cache directory or DSN is not set.");
			_processingDirectoryPath = Path.Combine(_isolatedCacheDirectoryPath, "__processing");
		}

		private void Initialize(bool startWorker)
		{
			MoveUnprocessedFilesBackToCache();
			_fileSystem.CreateDirectory(_isolatedCacheDirectoryPath);
			_fileSystem.CreateDirectory(_processingDirectoryPath);
			if (startWorker)
			{
				_options.LogDebug("Starting CachingTransport worker.");
				_worker = Task.Run((Func<Task>)CachedTransportBackgroundTaskAsync);
			}
			else
			{
				_worker = Task.CompletedTask;
			}
			if (!startWorker || !(_options.InitCacheFlushTimeout > TimeSpan.Zero))
			{
				return;
			}
			_options.LogDebug("Blocking initialization to flush the cache.");
			try
			{
				_preInitCacheResetEvent.Wait(_workerCts.Token);
				if (_initCacheResetEvent.Wait(_options.InitCacheFlushTimeout, _workerCts.Token))
				{
					_options.LogDebug("Completed flushing the cache. Resuming initialization.");
				}
				else
				{
					_options.LogDebug($"InitCacheFlushTimeout of {_options.InitCacheFlushTimeout} reached. " + "Resuming initialization. Cache will continue flushing in the background.");
				}
			}
			finally
			{
				_preInitCacheResetEvent.Dispose();
				_initCacheResetEvent.Dispose();
				_preInitCacheResetEvent = null;
				_initCacheResetEvent = null;
			}
		}

		private async Task CachedTransportBackgroundTaskAsync()
		{
			_options.LogDebug("CachingTransport worker has started.");
			while (!_workerCts.IsCancellationRequested)
			{
				try
				{
					await _workerSignal.WaitAsync(_workerCts.Token).ConfigureAwait(continueOnCapturedContext: false);
					_options.LogDebug("CachingTransport worker signal triggered.");
					await ProcessCacheAsync(_workerCts.Token).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (OperationCanceledException) when (_workerCts.IsCancellationRequested)
				{
					break;
				}
				catch (Exception exception)
				{
					_options.LogError(exception, "Exception in CachingTransport worker.");
					try
					{
						await Task.Delay(500, _workerCts.Token).ConfigureAwait(continueOnCapturedContext: false);
						goto end_IL_017b;
					}
					catch (OperationCanceledException)
					{
					}
					break;
					end_IL_017b:;
				}
			}
			_options.LogDebug("CachingTransport worker stopped.");
		}

		private void MoveUnprocessedFilesBackToCache()
		{
			if (!_fileSystem.DirectoryExists(_processingDirectoryPath))
			{
				return;
			}
			foreach (string item in _fileSystem.EnumerateFiles(_processingDirectoryPath))
			{
				string text = Path.Combine(_isolatedCacheDirectoryPath, Path.GetFileName(item));
				_options.LogDebug("Moving unprocessed file back to cache: {0} to {1}.", item, text);
				for (int i = 1; i <= 3; i++)
				{
					try
					{
						_fileSystem.MoveFile(item, text);
					}
					catch (Exception exception)
					{
						if (!_fileSystem.FileExists(item))
						{
							_options.LogDebug("Failed to move unprocessed file back to cache (attempt {0}), but the file no longer exists so it must have been handled by another process: {1}", i, item);
							break;
						}
						if (i < 3)
						{
							_options.LogDebug("Failed to move unprocessed file back to cache (attempt {0}, retrying.): {1}", i, item);
							Thread.Sleep(200);
						}
						else
						{
							_options.LogError(exception, "Failed to move unprocessed file back to cache (attempt {0}, done.): {1}", i, item);
						}
						continue;
					}
					break;
				}
			}
		}

		private void EnsureFreeSpaceInCache()
		{
			string[] array = GetCacheFilePaths().SkipLast(_keepCount).ToArray();
			foreach (string text in array)
			{
				try
				{
					_fileSystem.DeleteFile(text);
					_options.LogDebug("Deleted cached file {0}.", text);
				}
				catch (FileNotFoundException)
				{
					_options.LogWarning("Cached envelope '{0}' has already been deleted.", text);
				}
			}
		}

		private IEnumerable<string> GetCacheFilePaths()
		{
			return from f in _fileSystem.EnumerateFiles(_isolatedCacheDirectoryPath, "*.envelope")
				orderby _fileSystem.GetFileCreationTime(f)
				select f;
		}

		private async Task ProcessCacheAsync(CancellationToken cancellation)
		{
			_ = 2;
			try
			{
				await _processingSignal.WaitAsync(cancellation).ConfigureAwait(continueOnCapturedContext: false);
				_preInitCacheResetEvent?.Set();
				INetworkStatusListener networkStatusListener = _options.NetworkStatusListener;
				if (networkStatusListener != null && !networkStatusListener.Online)
				{
					MoveUnprocessedFilesBackToCache();
				}
				_options.LogDebug("Flushing cached envelopes.");
				while (true)
				{
					string text = await TryPrepareNextCacheFileAsync(cancellation).ConfigureAwait(continueOnCapturedContext: false);
					if (text == null)
					{
						break;
					}
					await InnerProcessCacheAsync(text, cancellation).ConfigureAwait(continueOnCapturedContext: false);
				}
				_initCacheResetEvent?.Set();
			}
			finally
			{
				_processingSignal.Release();
			}
		}

		private static bool IsNetworkError(Exception exception)
		{
			if (exception is HttpRequestException || exception is WebException || exception is IOException || exception is SocketException)
			{
				return true;
			}
			return false;
		}

		private async Task InnerProcessCacheAsync(string file, CancellationToken cancellation)
		{
			INetworkStatusListener networkStatusListener = _options.NetworkStatusListener;
			if (networkStatusListener != null && !networkStatusListener.Online)
			{
				_options.LogDebug("The network is offline. Pausing processing.");
				await networkStatusListener.WaitForNetworkOnlineAsync(cancellation).ConfigureAwait(continueOnCapturedContext: false);
				_options.LogDebug("The network is back online. Resuming processing.");
			}
			_options.LogDebug("Reading cached envelope: {0}", file);
			try
			{
				Stream stream = _fileSystem.OpenFileForReading(file);
				using (stream)
				{
					using Envelope envelope = await Envelope.DeserializeAsync(stream, cancellation).ConfigureAwait(continueOnCapturedContext: false);
					cancellation.ThrowIfCancellationRequested();
					try
					{
						_options.LogDebug("Sending cached envelope: {0}", envelope.TryGetEventId(_options.DiagnosticLogger));
						await _innerTransport.SendEnvelopeAsync(envelope, cancellation).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (OperationCanceledException arg)
					{
						_options.LogDebug("Canceled sending cached envelope: {0}, retrying after a delay.", arg, file);
						throw;
					}
					catch (Exception exception) when (IsNetworkError(exception))
					{
						if (_options.NetworkStatusListener is PollingNetworkStatusListener pollingNetworkStatusListener)
						{
							pollingNetworkStatusListener.Online = false;
						}
						_options.LogError(exception, "Failed to send cached envelope: {0}, retrying after a delay.", file);
						throw;
					}
					catch (Exception ex) when (ex.Source == "FakeFailingTransport")
					{
						return;
					}
					catch (Exception ex2)
					{
						_options.ClientReportRecorder.RecordDiscardedEvents(DiscardReason.CacheOverflow, envelope);
						LogFailureWithDiscard(file, ex2);
					}
				}
			}
			catch (JsonException ex3)
			{
				LogFailureWithDiscard(file, ex3);
			}
			_fileSystem.DeleteFile(file);
		}

		private void LogFailureWithDiscard(string file, Exception ex)
		{
			string text = null;
			try
			{
				if (_fileSystem.FileExists(file))
				{
					text = _fileSystem.ReadAllTextFromFile(file);
				}
			}
			catch
			{
			}
			if (text == null)
			{
				_options.LogError(ex, "Failed to send cached envelope: {0}, discarding cached envelope.", file);
			}
			else
			{
				_options.LogError(ex, "Failed to send cached envelope: {0}, discarding cached envelope. Envelope contents: {1}", file, text);
			}
		}

		private async Task<string?> TryPrepareNextCacheFileAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			using (await _cacheDirectoryLock.AcquireAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				string text = GetCacheFilePaths().FirstOrDefault();
				if (string.IsNullOrWhiteSpace(text))
				{
					_options.LogDebug("No cached file to process.");
					return null;
				}
				string text2 = Path.Combine(_processingDirectoryPath, Path.GetFileName(text));
				_fileSystem.MoveFile(text, text2, overwrite: true);
				return text2;
			}
		}

		private async Task StoreToCacheAsync(Envelope envelope, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (_failStorage)
			{
				throw new Exception("Simulated failure writing to storage (for testing).");
			}
			string envelopeFilePath = Path.Combine(_isolatedCacheDirectoryPath, $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}_" + $"{Guid.NewGuid().GetHashCode() % 10000}_" + $"{envelope.TryGetEventId(_options.DiagnosticLogger)}_" + $"{envelope.GetHashCode()}" + ".envelope");
			_options.LogDebug("Storing file {0}.", envelopeFilePath);
			using (await _cacheDirectoryLock.AcquireAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false))
			{
				EnsureFreeSpaceInCache();
				if (!_options.FileSystem.CreateFileForWriting(envelopeFilePath, out Stream fileStream))
				{
					_options.LogDebug("Failed to store to cache.");
					return;
				}
				using (fileStream)
				{
					await envelope.SerializeAsync(fileStream, _options.DiagnosticLogger, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				_workerSignal.Release();
			}
		}

		internal int GetCacheLength()
		{
			return GetCacheFilePaths().Count();
		}

		public async Task SendEnvelopeAsync(Envelope envelope, CancellationToken cancellationToken = default(CancellationToken))
		{
			ClientReport clientReport = _options.ClientReportRecorder.GenerateClientReport();
			if (clientReport != null)
			{
				envelope = envelope.WithItem(EnvelopeItem.FromClientReport(clientReport));
				_options.LogDebug("Attached client report to envelope {0}.", envelope.TryGetEventId(_options.DiagnosticLogger));
			}
			try
			{
				await StoreToCacheAsync(envelope, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch
			{
				if (clientReport != null)
				{
					_options.ClientReportRecorder.Load(clientReport);
				}
				throw;
			}
		}

		public Task StopWorkerAsync()
		{
			if (_worker.IsCompleted)
			{
				return Task.CompletedTask;
			}
			_options.LogDebug("Stopping CachingTransport worker.");
			_workerCts.Cancel();
			return _worker;
		}

		public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			_options.LogDebug("CachingTransport received request to flush the cache.");
			return ProcessCacheAsync(cancellationToken);
		}

		public async ValueTask DisposeAsync()
		{
			try
			{
				await StopWorkerAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Error stopping worker during dispose.");
			}
			_workerSignal.Dispose();
			_workerCts.Dispose();
			_worker.Dispose();
			_cacheDirectoryLock.Dispose();
			_preInitCacheResetEvent?.Dispose();
			_initCacheResetEvent?.Dispose();
			(_innerTransport as IDisposable)?.Dispose();
		}

		public void Dispose()
		{
			DisposeAsync().GetAwaiter().GetResult();
		}
	}
}
