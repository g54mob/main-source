using System.Collections;
using System.Collections.Generic;

namespace SaintsField.DropdownBase
{
	public interface IAdvancedDropdownList : IReadOnlyList<IAdvancedDropdownList>, IEnumerable<IAdvancedDropdownList>, IEnumerable, IReadOnlyCollection<IAdvancedDropdownList>
	{
		string displayName { get; }

		object value { get; }

		IReadOnlyList<IAdvancedDropdownList> children { get; }

		bool disabled { get; }

		string icon { get; }

		bool isSeparator { get; }

		int ChildCount();

		int SepCount();
	}
}
