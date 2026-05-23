using System;
using System.Collections;
using System.Collections.Generic;

public interface hw<a, b> : IDisposable, IEnumerable<KeyValuePair<a, b>>, IEnumerable where a : struct, IEquatable<a> where b : struct
{
	int wxg { get; }

	int wxh { get; }

	b this[a key] { get; set; }

	bool elr(a a, b b);

	bool els(a a);

	bool elt(a a, out b b);

	bool elu(a a);

	void elv();
}
