using System;
using System.Collections.Generic;

public interface INavigation
{
	IPage ActivePage { get; }

	IReadOnlyCollection<IPage> Pages { get; }

	event Action<IPage> OnPageAttached;

	event Action<IPage> OnPageDetached;

	event Action<(IPage previous, IPage current)> OnNavigating;

	event Action<(IPage previous, IPage current)> OnNavigated;
}
