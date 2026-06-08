using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime
{
	public abstract class RefreshingAWSCredentials : AWSCredentials, IDisposable
	{
		public class CredentialsRefreshState
		{
			public ImmutableCredentials Credentials { get; set; }

			public DateTime Expiration { get; set; }

			public CredentialsRefreshState()
			{
			}

			public CredentialsRefreshState(ImmutableCredentials credentials, DateTime expiration)
			{
				Credentials = credentials;
				Expiration = expiration;
			}

			internal bool IsExpiredWithin(TimeSpan preemptExpiryTime)
			{
				DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
				DateTime dateTime = Expiration.ToUniversalTime();
				return correctedUtcNow > dateTime - preemptExpiryTime;
			}

			internal TimeSpan GetTimeToLive(TimeSpan preemptExpiryTime)
			{
				DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
				return Expiration.ToUniversalTime() - correctedUtcNow + preemptExpiryTime;
			}
		}

		private Logger _logger = Logger.GetLogger(typeof(RefreshingAWSCredentials));

		protected CredentialsRefreshState currentState;

		private TimeSpan _preemptExpiryTime = TimeSpan.FromMinutes(0.0);

		private bool _disposed;

		private readonly SemaphoreSlim _updateGeneratedCredentialsSemaphore = new SemaphoreSlim(1, 1);

		public override DateTime? Expiration
		{
			get
			{
				if (currentState == null)
				{
					return null;
				}
				return currentState.Expiration.ToUniversalTime();
			}
		}

		public TimeSpan PreemptExpiryTime
		{
			get
			{
				return _preemptExpiryTime;
			}
			set
			{
				if (value < TimeSpan.Zero)
				{
					throw new ArgumentOutOfRangeException("value", "PreemptExpiryTime cannot be negative");
				}
				_preemptExpiryTime = value;
			}
		}

		protected bool ShouldUpdate => ShouldUpdateState(currentState);

		public sealed override ImmutableCredentials GetCredentials()
		{
			CredentialsRefreshState credentialsRefreshState = currentState;
			TimeSpan? timeSpan = credentialsRefreshState?.GetTimeToLive(PreemptExpiryTime);
			if (timeSpan > TimeSpan.Zero)
			{
				TimeSpan? timeSpan2 = timeSpan;
				TimeSpan preemptExpiryTime = PreemptExpiryTime;
				if (timeSpan2.HasValue && timeSpan2.GetValueOrDefault() < preemptExpiryTime && _updateGeneratedCredentialsSemaphore.Wait(0))
				{
					Task.Run((Func<CredentialsRefreshState>)GenerateCredentialsAndUpdateState);
				}
			}
			else
			{
				_updateGeneratedCredentialsSemaphore.Wait();
				credentialsRefreshState = GenerateCredentialsAndUpdateState();
			}
			return credentialsRefreshState.Credentials.Copy();
			CredentialsRefreshState GenerateCredentialsAndUpdateState()
			{
				try
				{
					CredentialsRefreshState credentialsRefreshState2 = currentState;
					if (ShouldUpdateState(credentialsRefreshState2))
					{
						credentialsRefreshState2 = GenerateNewCredentials();
						UpdateToGeneratedCredentials(credentialsRefreshState2);
						currentState = credentialsRefreshState2;
					}
					return credentialsRefreshState2;
				}
				finally
				{
					_updateGeneratedCredentialsSemaphore.Release();
				}
			}
		}

		public sealed override async Task<ImmutableCredentials> GetCredentialsAsync()
		{
			CredentialsRefreshState credentialsRefreshState = currentState;
			TimeSpan? timeSpan = credentialsRefreshState?.GetTimeToLive(PreemptExpiryTime);
			if (timeSpan > TimeSpan.Zero)
			{
				if (timeSpan < PreemptExpiryTime && _updateGeneratedCredentialsSemaphore.Wait(0))
				{
					GenerateCredentialsAndUpdateStateAsync();
				}
			}
			else
			{
				await _updateGeneratedCredentialsSemaphore.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
				credentialsRefreshState = await GenerateCredentialsAndUpdateStateAsync().ConfigureAwait(continueOnCapturedContext: false);
			}
			return credentialsRefreshState.Credentials.Copy();
			async Task<CredentialsRefreshState> GenerateCredentialsAndUpdateStateAsync()
			{
				try
				{
					CredentialsRefreshState credentialsRefreshState2 = currentState;
					if (ShouldUpdateState(credentialsRefreshState2))
					{
						credentialsRefreshState2 = await GenerateNewCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false);
						UpdateToGeneratedCredentials(credentialsRefreshState2);
						currentState = credentialsRefreshState2;
					}
					return credentialsRefreshState2;
				}
				finally
				{
					_updateGeneratedCredentialsSemaphore.Release();
				}
			}
		}

		private void UpdateToGeneratedCredentials(CredentialsRefreshState state)
		{
			if (ShouldUpdateState(state))
			{
				string message = ((state != null) ? string.Format(CultureInfo.InvariantCulture, "The retrieved credentials have already expired: Now = {0}, Credentials expiration = {1}", AWSSDKUtils.CorrectedUtcNow, state.Expiration) : "Unable to generate temporary credentials");
				throw new AmazonClientException(message);
			}
			state.Expiration -= PreemptExpiryTime;
			if (ShouldUpdateState(state))
			{
				Logger.GetLogger(typeof(RefreshingAWSCredentials)).InfoFormat("The preempt expiry time is set too high: Current time = {0}, Credentials expiry time = {1}, Preempt expiry time = {2}.", AWSSDKUtils.CorrectedUtcNow, state.Expiration, PreemptExpiryTime);
			}
		}

		private bool ShouldUpdateState(CredentialsRefreshState state)
		{
			bool? flag = state?.IsExpiredWithin(TimeSpan.Zero);
			if (flag == true)
			{
				Logger.GetLogger(typeof(RefreshingAWSCredentials)).InfoFormat("Determined refreshing credentials should update. Expiration time: {0}, Current time: {1}", state.Expiration.Add(PreemptExpiryTime).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.f ffffffK", CultureInfo.InvariantCulture), AWSSDKUtils.CorrectedUtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
			}
			return flag ?? true;
		}

		protected virtual CredentialsRefreshState GenerateNewCredentials()
		{
			throw new NotImplementedException();
		}

		protected virtual Task<CredentialsRefreshState> GenerateNewCredentialsAsync()
		{
			return Task.Run(() => GenerateNewCredentials());
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_updateGeneratedCredentialsSemaphore.Dispose();
				}
				_disposed = true;
			}
		}

		public virtual void ClearCredentials()
		{
			currentState = null;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
