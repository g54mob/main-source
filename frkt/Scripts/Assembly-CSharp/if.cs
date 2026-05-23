using System;
using System.Collections;
using System.Collections.Generic;

public interface @if<a> : IDisposable, IEnumerable<a>, IEnumerable where a : struct, IEquatable<a>
{
	int wxy { get; }

	int wxz { get; }

	bool enw(a a);

	bool env(a a);

	bool enx(a a);

	void eny();
}
