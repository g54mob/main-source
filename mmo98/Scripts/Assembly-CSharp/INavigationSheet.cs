using System.Threading;
using Cysharp.Threading.Tasks;

public interface INavigationSheet : INavigation
{
	UniTask AddAsync(IPage page, CancellationToken cancellationToken = default(CancellationToken));

	UniTask RemoveAsync(IPage page, CancellationToken cancellationToken = default(CancellationToken));

	UniTask RemoveAllAsync(CancellationToken cancellationToken = default(CancellationToken));

	UniTask ShowAsync(int index, NavigationContext context, CancellationToken cancellationToken = default(CancellationToken));

	UniTask HideAsync(NavigationContext context, CancellationToken cancellationToken = default(CancellationToken));
}
