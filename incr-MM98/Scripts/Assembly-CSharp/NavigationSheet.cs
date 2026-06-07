using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class NavigationSheet : MonoBehaviour, INavigationSheet, INavigation
{
	private readonly NavigationSheetCore _core = new NavigationSheetCore();

	public IPage ActivePage => _core.ActivePage;

	public IReadOnlyCollection<IPage> Pages => _core.Pages;

	public event Action<IPage> OnPageAttached
	{
		add
		{
			_core.OnPageAttached += value;
		}
		remove
		{
			_core.OnPageAttached -= value;
		}
	}

	public event Action<IPage> OnPageDetached
	{
		add
		{
			_core.OnPageDetached += value;
		}
		remove
		{
			_core.OnPageDetached -= value;
		}
	}

	public event Action<(IPage previous, IPage current)> OnNavigating
	{
		add
		{
			_core.OnNavigating += value;
		}
		remove
		{
			_core.OnNavigating -= value;
		}
	}

	public event Action<(IPage previous, IPage current)> OnNavigated
	{
		add
		{
			_core.OnNavigated += value;
		}
		remove
		{
			_core.OnNavigated -= value;
		}
	}

	public UniTask AddAsync(IPage page, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _core.AddAsync(page, cancellationToken);
	}

	public UniTask HideAsync(NavigationContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _core.HideAsync(context, cancellationToken);
	}

	public UniTask RemoveAllAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		return _core.RemoveAllAsync(cancellationToken);
	}

	public UniTask RemoveAsync(IPage page, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _core.RemoveAsync(page, cancellationToken);
	}

	public UniTask ShowAsync(int index, NavigationContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _core.ShowAsync(index, context, cancellationToken);
	}
}
