using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

public class NavigationStackCore
{
	private readonly ConcurrentStack<IPage> _pageStack = new ConcurrentStack<IPage>();

	private IPage _activePage;

	private bool _isTransitioning;

	public IReadOnlyCollection<IPage> Pages => _pageStack;

	public IPage ActivePage => _activePage;

	public event Action<IPage> OnPageAttached;

	public event Action<IPage> OnPageDetached;

	public event Action<(IPage Previous, IPage Current)> OnNavigating;

	public event Action<(IPage Previous, IPage Current)> OnNavigated;

	public async UniTask PopAsync(NavigationContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		NavigationContext copiedContext = context._003CClone_003E_0024();
		if (_isTransitioning)
		{
			switch (copiedContext.AwaitOperation)
			{
			case NavigationAwaitOperation.Sequential:
				await UniTask.WaitWhile(() => _isTransitioning, PlayerLoopTiming.Update, cancellationToken);
				break;
			case NavigationAwaitOperation.Drop:
				return;
			case NavigationAwaitOperation.Error:
				throw new InvalidOperationException("Navigation is currently in transition.");
			}
		}
		_isTransitioning = true;
		try
		{
			if (_pageStack.Count == 0)
			{
				throw new InvalidOperationException("Empty stack");
			}
			_pageStack.TryPop(out var page);
			if (page is IPageStackListener pageStackListener)
			{
				await pageStackListener.OnPop(copiedContext, cancellationToken);
			}
			_pageStack.TryPeek(out _activePage);
			UniTask uniTask = page.OnNavigatedFrom(copiedContext, cancellationToken);
			UniTask uniTask2 = _activePage?.OnNavigatedTo(copiedContext, cancellationToken) ?? UniTask.CompletedTask;
			this.OnNavigating?.Invoke((page, _activePage));
			await UniTask.WhenAll(uniTask, uniTask2);
			this.OnNavigated?.Invoke((page, _activePage));
			this.OnPageDetached?.Invoke(page);
			if (page is IPageLifecycleListener pageLifecycleListener)
			{
				await pageLifecycleListener.OnDetached(cancellationToken);
			}
		}
		finally
		{
			_isTransitioning = false;
		}
	}

	public async UniTask PushAsync(Func<UniTask<IPage>> pageFactory, NavigationContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		NavigationContext copiedContext = context._003CClone_003E_0024();
		if (_isTransitioning)
		{
			switch (copiedContext.AwaitOperation)
			{
			case NavigationAwaitOperation.Sequential:
				await UniTask.WaitWhile(() => _isTransitioning, PlayerLoopTiming.Update, cancellationToken);
				break;
			case NavigationAwaitOperation.Drop:
				return;
			case NavigationAwaitOperation.Error:
				throw new InvalidOperationException("Navigation is currently in transition.");
			}
		}
		_isTransitioning = true;
		try
		{
			IPage page = await pageFactory();
			this.OnPageAttached?.Invoke(page);
			if (page is IPageLifecycleListener pageLifecycleListener)
			{
				await pageLifecycleListener.OnAttached(cancellationToken);
			}
			_pageStack.Push(page);
			if (page is IPageStackListener pageStackListener)
			{
				await pageStackListener.OnPush(copiedContext, cancellationToken);
			}
			IPage prevPage = _activePage;
			_activePage = page;
			UniTask uniTask = prevPage?.OnNavigatedFrom(copiedContext, cancellationToken) ?? UniTask.CompletedTask;
			UniTask uniTask2 = _activePage.OnNavigatedTo(copiedContext, cancellationToken);
			this.OnNavigating?.Invoke((prevPage, _activePage));
			await UniTask.WhenAll(uniTask, uniTask2);
			this.OnNavigated?.Invoke((prevPage, _activePage));
		}
		finally
		{
			_isTransitioning = false;
		}
	}
}
