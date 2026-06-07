using System;
using System.Collections;
using System.Collections.Generic;

namespace Ludiq
{
	public interface IMergedCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable
	{
		bool Includes<TI>() where TI : T;

		bool Includes(Type elementType);
	}
}
