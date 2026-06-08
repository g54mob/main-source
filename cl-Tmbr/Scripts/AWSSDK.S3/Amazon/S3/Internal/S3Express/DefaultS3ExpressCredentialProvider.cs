using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Model;
using Amazon.Util;

namespace Amazon.S3.Internal.S3Express
{
	internal class DefaultS3ExpressCredentialProvider : IS3ExpressCredentialProvider, IDisposable
	{
		private class SessionCredentialsLruItem
		{
			private const int DefaultExpirationTime = 300;

			public SessionCredentials SessionCredentials { get; }

			public DateTime CreatedAt { get; }

			public DateTime ExpirationDate { get; }

			public SessionCredentialsLruItem(SessionCredentials sessionCredentials)
			{
				SessionCredentials = sessionCredentials;
				CreatedAt = AWSSDKUtils.CorrectedUtcNow;
				ExpirationDate = sessionCredentials.Expiration.GetValueOrDefault().ToUniversalTime();
				if (AWSConfigs.ManualClockCorrection.HasValue)
				{
					ExpirationDate += AWSConfigs.ManualClockCorrection.Value;
				}
			}
		}

		private readonly AmazonS3Client _s3Client;

		private readonly LruCache<string, SessionCredentialsLruItem> _cache;

		private DateTime _lastRefreshedTime;

		private readonly SemaphoreSlim _cacheLock = new SemaphoreSlim(1, 1);

		private readonly Timer _refreshCredentialsTimer;

		private bool _timerStarted;

		private Logger _logger;

		private static readonly TimeSpan _neverTimespan = TimeSpan.FromMilliseconds(-1.0);

		private const int MaxCacheSize = 25;

		private const int RequestTime = 15;

		private const int PrefetchTime = 60;

		private bool _isDisposed;

		public DefaultS3ExpressCredentialProvider(AmazonS3Client s3Client)
		{
			_s3Client = s3Client;
			_logger = Logger.GetLogger(typeof(DefaultS3ExpressCredentialProvider));
			_cache = new LruCache<string, SessionCredentialsLruItem>(25);
			_refreshCredentialsTimer = new Timer(RefreshCredentials);
		}

		public SessionCredentials ResolveSessionCredentials(string bucketName)
		{
			SessionCredentials sessionCredentialsFromCache = GetSessionCredentialsFromCache(bucketName);
			if (sessionCredentialsFromCache == null)
			{
				_cacheLock.Wait();
				try
				{
					if (_cache.TryGetValue(bucketName, out var value))
					{
						return value.SessionCredentials;
					}
					CreateSessionRequest request = new CreateSessionRequest
					{
						BucketName = bucketName
					};
					CreateSessionResponse createSessionResponse = _s3Client.CreateSession(request);
					CacheSessionCredentials(bucketName, createSessionResponse.Credentials);
					return createSessionResponse.Credentials;
				}
				catch (NoSuchBucketException exception)
				{
					_logger.Error(exception, "Bucket: " + bucketName + " doesn't exist or was removed");
					_cache.Evict(bucketName);
				}
				finally
				{
					_cacheLock.Release();
				}
			}
			return sessionCredentialsFromCache;
		}

		public async Task<SessionCredentials> ResolveSessionCredentialsAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			SessionCredentials sessionCredentials = GetSessionCredentialsFromCache(bucketName);
			if (sessionCredentials == null)
			{
				await _cacheLock.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
				try
				{
					if (_cache.TryGetValue(bucketName, out var value))
					{
						return value.SessionCredentials;
					}
					CreateSessionRequest request = new CreateSessionRequest
					{
						BucketName = bucketName
					};
					CreateSessionResponse createSessionResponse = await _s3Client.CreateSessionAsync(request).ConfigureAwait(continueOnCapturedContext: false);
					CacheSessionCredentials(bucketName, createSessionResponse.Credentials);
					return createSessionResponse.Credentials;
				}
				catch (NoSuchBucketException exception)
				{
					_logger.Error(exception, "Bucket: " + bucketName + " doesn't exist or was removed");
					_cache.Evict(bucketName);
				}
				finally
				{
					_cacheLock.Release();
				}
			}
			return sessionCredentials;
		}

		private SessionCredentials GetSessionCredentialsFromCache(string bucketName)
		{
			if (_cache.TryGetValue(bucketName, out var value))
			{
				if (!IsExpiredSessionCredentials(value))
				{
					return value.SessionCredentials;
				}
				_cacheLock.Wait();
				try
				{
					_cache.Evict(bucketName);
				}
				finally
				{
					_cacheLock.Release();
				}
			}
			return null;
		}

		private void CacheSessionCredentials(string bucketName, SessionCredentials credentials)
		{
			SessionCredentialsLruItem sessionCredentialsLruItem = new SessionCredentialsLruItem(credentials);
			_cache.AddOrUpdate(bucketName, sessionCredentialsLruItem);
			ResetCredentialsTimer(sessionCredentialsLruItem.ExpirationDate);
		}

		private async void RefreshCredentials(object _)
		{
			try
			{
				_logger.InfoFormat("Refreshing session credentials started in the background.");
				List<string> list = new List<string>();
				_cacheLock.Wait();
				try
				{
					for (LruListItem<string, SessionCredentialsLruItem> lruListItem = _cache.FindOldestItem(); lruListItem != null; lruListItem = lruListItem.Previous)
					{
						if (_lastRefreshedTime == DateTime.MinValue)
						{
							if (lruListItem.LastTouchedTimestamp > lruListItem.Value.CreatedAt.AddSeconds(15.0))
							{
								list.Add(lruListItem.Key);
							}
						}
						else if (lruListItem.LastTouchedTimestamp > _lastRefreshedTime)
						{
							list.Add(lruListItem.Key);
						}
					}
				}
				finally
				{
					_cacheLock.Release();
				}
				DateTime resetTime = DateTime.MinValue;
				foreach (string key in list)
				{
					CreateSessionResponse createSessionResponse;
					try
					{
						createSessionResponse = await _s3Client.CreateSessionAsync(new CreateSessionRequest
						{
							BucketName = key
						}).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (NoSuchBucketException exception)
					{
						_logger.Error(exception, "Bucket: " + key + " doesn't exist or was removed");
						_cacheLock.Wait();
						try
						{
							_cache.Evict(key);
						}
						finally
						{
							_cacheLock.Release();
						}
						continue;
					}
					SessionCredentialsLruItem value = new SessionCredentialsLruItem(createSessionResponse.Credentials);
					if (resetTime == DateTime.MinValue)
					{
						resetTime = createSessionResponse.Credentials.Expiration.GetValueOrDefault().ToUniversalTime();
					}
					_cacheLock.Wait();
					try
					{
						_cache.AddOrUpdate(key, value);
					}
					finally
					{
						_cacheLock.Release();
					}
				}
				_timerStarted = false;
				if (resetTime == DateTime.MinValue)
				{
					_logger.InfoFormat("Refreshing session credentials stopped since none were used recently.");
					return;
				}
				_lastRefreshedTime = AWSSDKUtils.CorrectedUtcNow;
				ResetCredentialsTimer(resetTime);
			}
			catch (Exception exception2)
			{
				_logger.Error(exception2, "An unhandled exception occurred while trying to refresh session credentials.");
				_timerStarted = true;
				_refreshCredentialsTimer.Change(TimeSpan.FromSeconds(60.0), _neverTimespan);
				throw;
			}
		}

		private static bool IsExpiredSessionCredentials(SessionCredentialsLruItem sessionCredentialsLruItem)
		{
			return AWSSDKUtils.CorrectedUtcNow > sessionCredentialsLruItem.ExpirationDate - TimeSpan.FromSeconds(15.0);
		}

		private void ResetCredentialsTimer(DateTime resetTime)
		{
			DateTime dateTime = resetTime.AddSeconds(-60.0);
			if (!_timerStarted)
			{
				_refreshCredentialsTimer.Change(dateTime - AWSSDKUtils.CorrectedUtcNow, _neverTimespan);
				_timerStarted = true;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_isDisposed)
			{
				if (disposing)
				{
					_refreshCredentialsTimer.Dispose();
					_logger = null;
				}
				_isDisposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
