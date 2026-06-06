using System.Threading;
using Cysharp.Threading.Tasks;

public interface IPageLifecycleListener
{
	UniTask OnAttached(CancellationToken cancellationToken = default(CancellationToken));

	UniTask OnDetached(CancellationToken cancellationToken = default(CancellationToken));
}
