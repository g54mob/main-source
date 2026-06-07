using System.Collections;
using System.Collections.Generic;

namespace SaintsField.DropdownBase
{
	public interface IDropdownList : IEnumerable<(string, object, bool, bool)>, IEnumerable
	{
	}
}
