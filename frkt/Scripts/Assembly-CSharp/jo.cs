using System;
using System.Collections.Generic;
using JetBrains.Annotations;

public interface jo
{
	[CanBeNull]
	IEnumerable<jt<bjg>> xam { get; }

	int xan { get; }

	int xao { get; }

	event Action<bjg, int> yeh;

	event Action<bjg, int> yei;

	event Action<int> yej;

	event Action<int> yek;

	event Action<jj> yel;
}
