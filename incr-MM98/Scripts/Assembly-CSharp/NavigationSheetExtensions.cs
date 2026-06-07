using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class NavigationSheetExtensions
{
	public static UniTask ShowAsync(this INavigationSheet navigationSheet, int index, CancellationToken cancellationToken = default(CancellationToken))
	{
		return navigationSheet.ShowAsync(index, new NavigationContext(), cancellationToken);
	}

	public static UniTask HideAsync(this INavigationSheet navigationSheet, CancellationToken cancellationToken = default(CancellationToken))
	{
		return navigationSheet.HideAsync(new NavigationContext(), cancellationToken);
	}

	public static UniTask AddNewObjectAsync<T>(this INavigationSheet navigationSheet, T prefab, CancellationToken cancellationToken = default(CancellationToken)) where T : Object, IPage
	{
		T val = Object.Instantiate(prefab);
		if (val is Component component)
		{
			component.GetCancellationTokenOnDestroy().RegisterWithoutCaptureExecutionContext(delegate(object x)
			{
				if (x != null)
				{
					Object.Destroy((Object)x);
				}
			}, val);
		}
		return navigationSheet.AddAsync(val, cancellationToken);
	}
}
