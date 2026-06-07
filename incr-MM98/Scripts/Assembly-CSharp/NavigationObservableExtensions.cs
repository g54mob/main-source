using System;
using System.Threading;
using R3;

public static class NavigationObservableExtensions
{
	public static Observable<IPage> OnPageAttachedAsObservable(this INavigation navigation, CancellationToken cancellationToken = default(CancellationToken))
	{
		return Observable.FromEvent(delegate(Action<IPage> x)
		{
			navigation.OnPageAttached += x;
		}, delegate(Action<IPage> x)
		{
			navigation.OnPageAttached -= x;
		}, cancellationToken);
	}

	public static Observable<IPage> OnPageDetachedAsObservable(this INavigation navigation, CancellationToken cancellationToken = default(CancellationToken))
	{
		return Observable.FromEvent(delegate(Action<IPage> x)
		{
			navigation.OnPageDetached += x;
		}, delegate(Action<IPage> x)
		{
			navigation.OnPageDetached -= x;
		}, cancellationToken);
	}

	public static Observable<(IPage Previous, IPage Current)> OnNavigatingAsObservable(this INavigation navigation, CancellationToken cancellationToken = default(CancellationToken))
	{
		return Observable.FromEvent(delegate(Action<(IPage, IPage)> x)
		{
			navigation.OnNavigating += x;
		}, delegate(Action<(IPage, IPage)> x)
		{
			navigation.OnNavigating -= x;
		}, cancellationToken);
	}

	public static Observable<(IPage Previous, IPage Current)> OnNavigatedAsObservable(this INavigation navigation, CancellationToken cancellationToken = default(CancellationToken))
	{
		return Observable.FromEvent(delegate(Action<(IPage, IPage)> x)
		{
			navigation.OnNavigated += x;
		}, delegate(Action<(IPage, IPage)> x)
		{
			navigation.OnNavigated -= x;
		}, cancellationToken);
	}
}
