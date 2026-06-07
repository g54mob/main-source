using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

public class NavigationSheetCore
{
	private readonly List<IPage> _pages = new List<IPage>();

	private bool _isTransitioning;

	public IPage ActivePage { get; private set; }

	public IReadOnlyCollection<IPage> Pages => _pages;

	public event Action<IPage> OnPageAttached;

	public event Action<IPage> OnPageDetached;

	public event Action<(IPage Previous, IPage Current)> OnNavigating;

	public event Action<(IPage Previous, IPage Current)> OnNavigated;

	public async UniTask AddAsync(IPage page, CancellationToken cancellationToken = default(CancellationToken))
	{
		this.OnPageAttached?.Invoke(page);
		if (page is IPageLifecycleListener pageLifecycleListener)
		{
			await pageLifecycleListener.OnAttached(cancellationToken);
		}
		_pages.Add(page);
	}

	public async UniTask RemoveAsync(IPage page, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (page == null)
		{
			throw new ArgumentNullException("page");
		}
		if (_pages.Remove(page))
		{
			this.OnPageDetached?.Invoke(page);
			if (page is IPageLifecycleListener pageLifecycleListener)
			{
				await pageLifecycleListener.OnDetached(cancellationToken);
			}
		}
	}

	public UniTask RemoveAllAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		UniTask[] array = new UniTask[_pages.Count];
		for (int i = 0; i < _pages.Count; i++)
		{
			IPage page = _pages[i];
			this.OnPageDetached?.Invoke(page);
			array[i] = ((page is IPageLifecycleListener pageLifecycleListener) ? pageLifecycleListener.OnDetached(cancellationToken) : UniTask.CompletedTask);
		}
		ActivePage = null;
		_pages.Clear();
		return UniTask.WhenAll(array);
	}

	public async UniTask ShowAsync(int index, NavigationContext context, CancellationToken cancellationToken = default(CancellationToken))
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
			IPage page = _pages[index];
			if (ActivePage != page)
			{
				IPage prevPage = ActivePage;
				ActivePage = page;
				UniTask uniTask = prevPage?.OnNavigatedFrom(copiedContext, cancellationToken) ?? UniTask.CompletedTask;
				UniTask uniTask2 = ActivePage.OnNavigatedTo(copiedContext, cancellationToken);
				this.OnNavigating?.Invoke((prevPage, ActivePage));
				await UniTask.WhenAll(uniTask, uniTask2);
				this.OnNavigated?.Invoke((prevPage, ActivePage));
			}
		}
		finally
		{
			_isTransitioning = false;
		}
	}

	public async UniTask HideAsync(NavigationContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		NavigationContext copiedContext = context._003CClone_003E_0024();
		if (ActivePage == null)
		{
			return;
		}
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
			IPage prevPage = ActivePage;
			ActivePage = null;
			if (prevPage != null)
			{
				this.OnNavigating?.Invoke((null, prevPage));
				await prevPage.OnNavigatedFrom(copiedContext, cancellationToken);
				this.OnNavigated?.Invoke((null, prevPage));
			}
		}
		finally
		{
			_isTransitioning = false;
		}
	}
}
