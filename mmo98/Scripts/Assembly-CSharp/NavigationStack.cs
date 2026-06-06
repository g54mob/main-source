using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class NavigationStack : MonoBehaviour, INavigationStack, INavigation
{
	private readonly NavigationStackCore _core = new NavigationStackCore();

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

	public UniTask PopAsync(NavigationContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _core.PopAsync(context, cancellationToken);
	}

	public UniTask PushAsync(IPage page, NavigationContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _core.PushAsync(() => new UniTask<IPage>(page), context, cancellationToken);
	}

	public UniTask PushAsync(Func<UniTask<IPage>> factory, NavigationContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return _core.PushAsync(factory, context, cancellationToken);
	}
}
