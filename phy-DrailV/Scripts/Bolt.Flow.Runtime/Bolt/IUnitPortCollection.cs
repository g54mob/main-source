using System.Collections;
using System.Collections.Generic;
using Ludiq;

namespace Bolt
{
	public interface IUnitPortCollection<TPort> : IKeyedCollection<string, TPort>, ICollection<TPort>, IEnumerable<TPort>, IEnumerable where TPort : IUnitPort
	{
		TPort Single();
	}
}
