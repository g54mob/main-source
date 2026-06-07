using System.Collections;
using System.Collections.Generic;

namespace ExternalPropertyAttributes
{
	public interface IDropdownList : IEnumerable<KeyValuePair<string, object>>, IEnumerable
	{
	}
}
