using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime
{
	public class AWSTokenProviderChain : IAWSTokenProvider
	{
		private readonly IAWSTokenProvider[] _chain;

		public AWSTokenProviderChain(params IAWSTokenProvider[] providers)
		{
			_chain = providers ?? new IAWSTokenProvider[0];
		}

		public async Task<TryResponse<AWSToken>> TryResolveTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			IAWSTokenProvider[] chain = _chain;
			for (int i = 0; i < chain.Length; i++)
			{
				TryResponse<AWSToken> tryResponse = await chain[i].TryResolveTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (tryResponse.Success)
				{
					return tryResponse;
				}
			}
			return TryResponse<AWSToken>.Failure;
		}
	}
}
