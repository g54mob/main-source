using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Util;

namespace Amazon.Runtime
{
	public class StaticTokenProvider : IAWSTokenProvider
	{
		private readonly string _token;

		private readonly DateTime? _expiration;

		public StaticTokenProvider(string token, DateTime? expiration = null)
		{
			_token = token;
			_expiration = expiration;
		}

		public Task<TryResponse<AWSToken>> TryResolveTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			bool flag = IsTokenUnexpired();
			return Task.FromResult(new TryResponse<AWSToken>
			{
				Success = flag,
				Value = (flag ? new AWSToken
				{
					Token = _token,
					Expiration = _expiration
				} : null)
			});
		}

		private bool IsTokenUnexpired()
		{
			if (_expiration.HasValue)
			{
				return _expiration.Value < AWSSDKUtils.CorrectedUtcNow;
			}
			return true;
		}
	}
}
