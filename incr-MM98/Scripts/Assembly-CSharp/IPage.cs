using System.Threading;
using Cysharp.Threading.Tasks;

public interface IPage
{
	UniTask OnNavigatedFrom(NavigationContext ctx, CancellationToken cancellationToken = default(CancellationToken));

	UniTask OnNavigatedTo(NavigationContext ctx, CancellationToken cancellationToken = default(CancellationToken));
}
