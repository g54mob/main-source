using System;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime
{
	public class DefaultAWSTokenProviderChain : IAWSTokenProvider
	{
		private readonly Lazy<IAWSTokenProvider> _chain;

		public string ProfileName { get; set; }

		public DefaultAWSTokenProviderChain()
		{
			Func<IAWSTokenProvider> valueFactory = () => new AWSTokenProviderChain(new ProfileTokenProvider(ProfileName));
			_chain = new Lazy<IAWSTokenProvider>(valueFactory);
		}

		public async Task<TryResponse<AWSToken>> TryResolveTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _chain.Value.TryResolveTokenAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
}
