using System;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Runtime;

namespace Coherence.Cloud
{
	internal interface IAuthClientInternal : IAuthClient
	{
		PlayerAccount PlayerAccount { get; set; }

		PlayerAccountId PlayerAccountId { get; }

		SessionToken SessionToken { get; }

		event Action<PlayerAccount> OnLoggingIn;

		event Action<PlayerAccount> OnLoggingOut;

		Task<LoginResult> Login(LoginInfo info, CancellationToken cancellationToken = default(CancellationToken));

		PlayerAccountOperation PlayerAccountOperationAsync<TRequest>(PlayerAccountOperationInfo<TRequest> info, CancellationToken cancellationToken, Action onCompletingSuccessfully) where TRequest : struct, IPlayerAccountOperationRequest
		{
			return null;
		}

		PlayerAccountOperation<TResult> PlayerAccountOperationAsync<TRequest, TResponse, TResult>(PlayerAccountOperationInfo<TRequest> info, Func<TResponse, TResult> resultFactory, CancellationToken cancellationToken, Action onCompletingSuccessfully) where TRequest : struct, IPlayerAccountOperationRequest where TResponse : IPlayerAccountOperationResponse;
	}
}
