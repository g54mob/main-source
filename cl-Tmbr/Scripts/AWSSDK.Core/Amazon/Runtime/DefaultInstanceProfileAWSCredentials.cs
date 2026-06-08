using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.UserAgent;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime
{
	internal class DefaultInstanceProfileAWSCredentials : AWSCredentials, IDisposable
	{
		private static readonly object _instanceLock = new object();

		private readonly ReaderWriterLockSlim _credentialsLock = new ReaderWriterLockSlim();

		private readonly Timer _credentialsRetrieverTimer;

		private RefreshingAWSCredentials.CredentialsRefreshState _lastRetrievedCredentials;

		private Logger _logger;

		private static readonly TimeSpan _neverTimespan = TimeSpan.FromMilliseconds(-1.0);

		private static readonly TimeSpan _refreshRate = TimeSpan.FromMinutes(2.0);

		private const string FailedToGetCredentialsMessage = "Failed to retrieve credentials from EC2 Instance Metadata Service.";

		private static readonly TimeSpan _credentialsLockTimeout = TimeSpan.FromMinutes(1.0);

		private static volatile bool _imdsRefreshFailed = false;

		private const string _usingExpiredCredentialsFromIMDS = "Attempting credential expiration extension due to a credential service availability issue. A refresh of these credentials will be attempted again in 5-10 minutes.";

		private static DefaultInstanceProfileAWSCredentials _instance;

		private bool _isDisposed;

		public static DefaultInstanceProfileAWSCredentials Instance
		{
			get
			{
				CheckIsIMDSEnabled();
				if (_instance == null)
				{
					lock (_instanceLock)
					{
						if (_instance == null)
						{
							_instance = new DefaultInstanceProfileAWSCredentials();
						}
					}
				}
				return _instance;
			}
		}

		private DefaultInstanceProfileAWSCredentials()
		{
			if (EC2InstanceMetadata.IsIMDSEnabled)
			{
				_logger = Logger.GetLogger(typeof(DefaultInstanceProfileAWSCredentials));
				_credentialsRetrieverTimer = new Timer(RenewCredentials, null, TimeSpan.Zero, _neverTimespan);
				base.FeatureIdSources.Add(UserAgentFeatureId.CREDENTIALS_IMDS);
			}
		}

		public override ImmutableCredentials GetCredentials()
		{
			CheckIsIMDSEnabled();
			ImmutableCredentials immutableCredentials = null;
			if (_credentialsLock.TryEnterReadLock(_credentialsLockTimeout))
			{
				try
				{
					if (_lastRetrievedCredentials != null)
					{
						if (_lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero) && !_imdsRefreshFailed)
						{
							_imdsRefreshFailed = true;
							_lastRetrievedCredentials = FetchCredentials();
						}
						if (_lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero))
						{
							_logger.InfoFormat("Attempting credential expiration extension due to a credential service availability issue. A refresh of these credentials will be attempted again in 5-10 minutes.");
						}
						else
						{
							_imdsRefreshFailed = false;
						}
						return _lastRetrievedCredentials?.Credentials.Copy();
					}
				}
				finally
				{
					_credentialsLock.ExitReadLock();
				}
			}
			if (_credentialsLock.TryEnterWriteLock(_credentialsLockTimeout))
			{
				try
				{
					if (_lastRetrievedCredentials == null)
					{
						_lastRetrievedCredentials = FetchCredentials();
					}
					if (_lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero) && !_imdsRefreshFailed)
					{
						_imdsRefreshFailed = true;
						_lastRetrievedCredentials = FetchCredentials();
					}
					if (_lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero))
					{
						_logger.InfoFormat("Attempting credential expiration extension due to a credential service availability issue. A refresh of these credentials will be attempted again in 5-10 minutes.");
					}
					else
					{
						_imdsRefreshFailed = false;
					}
					immutableCredentials = _lastRetrievedCredentials.Credentials?.Copy();
				}
				finally
				{
					_credentialsLock.ExitWriteLock();
				}
			}
			if (immutableCredentials == null)
			{
				throw new AmazonServiceException("Failed to retrieve credentials from EC2 Instance Metadata Service.");
			}
			return immutableCredentials;
		}

		public override async Task<ImmutableCredentials> GetCredentialsAsync()
		{
			CheckIsIMDSEnabled();
			ImmutableCredentials immutableCredentials = null;
			if (_credentialsLock.TryEnterReadLock(_credentialsLockTimeout))
			{
				try
				{
					if (_lastRetrievedCredentials != null)
					{
						if (_lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero) && !_imdsRefreshFailed)
						{
							_imdsRefreshFailed = true;
							_lastRetrievedCredentials = await FetchCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false);
						}
						if (_lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero))
						{
							_logger.InfoFormat("Attempting credential expiration extension due to a credential service availability issue. A refresh of these credentials will be attempted again in 5-10 minutes.");
						}
						else
						{
							_imdsRefreshFailed = false;
						}
						return _lastRetrievedCredentials?.Credentials.Copy();
					}
				}
				finally
				{
					_credentialsLock.ExitReadLock();
				}
			}
			if (_credentialsLock.TryEnterWriteLock(_credentialsLockTimeout))
			{
				try
				{
					if (_lastRetrievedCredentials == null)
					{
						_lastRetrievedCredentials = await FetchCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false);
					}
					if (_lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero) && !_imdsRefreshFailed)
					{
						_imdsRefreshFailed = true;
						_lastRetrievedCredentials = await FetchCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false);
					}
					if (_lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero))
					{
						_logger.InfoFormat("Attempting credential expiration extension due to a credential service availability issue. A refresh of these credentials will be attempted again in 5-10 minutes.");
					}
					else
					{
						_imdsRefreshFailed = false;
					}
					immutableCredentials = _lastRetrievedCredentials.Credentials?.Copy();
				}
				finally
				{
					_credentialsLock.ExitWriteLock();
				}
			}
			if (immutableCredentials == null)
			{
				throw new AmazonServiceException("Failed to retrieve credentials from EC2 Instance Metadata Service.");
			}
			return immutableCredentials;
		}

		private void RenewCredentials(object unused)
		{
			TimeSpan dueTime = _refreshRate;
			try
			{
				_lastRetrievedCredentials = FetchCredentials();
				if (!_imdsRefreshFailed && _lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero))
				{
					_imdsRefreshFailed = true;
					_lastRetrievedCredentials = FetchCredentials();
				}
				if (_lastRetrievedCredentials.IsExpiredWithin(TimeSpan.Zero))
				{
					dueTime = TimeSpan.FromMinutes(new Random().Next(5, 11));
				}
				else
				{
					_imdsRefreshFailed = false;
				}
			}
			catch (OperationCanceledException exception)
			{
				_logger.Error(exception, "RenewCredentials task canceled");
			}
			catch (Exception exception2)
			{
				_logger.Error(exception2, "Failed to retrieve credentials from EC2 Instance Metadata Service.");
			}
			finally
			{
				_credentialsRetrieverTimer.Change(dueTime, _neverTimespan);
			}
		}

		private static RefreshingAWSCredentials.CredentialsRefreshState FetchCredentials()
		{
			IAMSecurityCredentialMetadata metadataFromSecurityCredentials = GetMetadataFromSecurityCredentials(EC2InstanceMetadata.IAMSecurityCredentials ?? throw new AmazonServiceException("Unable to get IAM security credentials from EC2 Instance Metadata Service."));
			return new RefreshingAWSCredentials.CredentialsRefreshState(new ImmutableCredentials(metadataFromSecurityCredentials.AccessKeyId, metadataFromSecurityCredentials.SecretAccessKey, metadataFromSecurityCredentials.Token), metadataFromSecurityCredentials.Expiration);
		}

		private static async Task<RefreshingAWSCredentials.CredentialsRefreshState> FetchCredentialsAsync()
		{
			IAMSecurityCredentialMetadata metadataFromSecurityCredentials = GetMetadataFromSecurityCredentials((await EC2InstanceMetadata.GetIAMSecurityCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false)) ?? throw new AmazonServiceException("Unable to get IAM security credentials from EC2 Instance Metadata Service."));
			return new RefreshingAWSCredentials.CredentialsRefreshState(new ImmutableCredentials(metadataFromSecurityCredentials.AccessKeyId, metadataFromSecurityCredentials.SecretAccessKey, metadataFromSecurityCredentials.Token), metadataFromSecurityCredentials.Expiration);
		}

		private static IAMSecurityCredentialMetadata GetMetadataFromSecurityCredentials(IDictionary<string, IAMSecurityCredentialMetadata> securityCredentials)
		{
			string text = null;
			using (IEnumerator<string> enumerator = securityCredentials.Keys.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					text = enumerator.Current;
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				throw new AmazonServiceException("Unable to get EC2 instance role from EC2 Instance Metadata Service.");
			}
			return securityCredentials[text] ?? throw new AmazonServiceException("Unable to get credentials for role \"" + text + "\" from EC2 Instance Metadata Service.");
		}

		private static void CheckIsIMDSEnabled()
		{
			if (!EC2InstanceMetadata.IsIMDSEnabled)
			{
				throw new AmazonServiceException("Unable to retrieve credentials.");
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_isDisposed)
			{
				return;
			}
			if (disposing)
			{
				lock (_instanceLock)
				{
					_credentialsRetrieverTimer.Dispose();
					_logger = null;
					_instance = null;
				}
			}
			_isDisposed = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
