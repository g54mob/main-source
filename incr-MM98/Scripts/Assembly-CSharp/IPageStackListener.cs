using System.Threading;
using Cysharp.Threading.Tasks;

public interface IPageStackListener
{
	UniTask OnPush(NavigationContext context, CancellationToken cancellationToken = default(CancellationToken));

	UniTask OnPop(NavigationContext context, CancellationToken cancellationToken = default(CancellationToken));
}
