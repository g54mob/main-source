using System;
using System.Threading;
using Cysharp.Threading.Tasks;

public interface INavigationStack : INavigation
{
	UniTask PushAsync(IPage page, NavigationContext context, CancellationToken cancellationToken = default(CancellationToken));

	UniTask PushAsync(Func<UniTask<IPage>> factory, NavigationContext context, CancellationToken cancellationToken = default(CancellationToken));

	UniTask PopAsync(NavigationContext context, CancellationToken cancellationToken = default(CancellationToken));
}
