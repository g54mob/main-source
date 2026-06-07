using System;
using System.Collections.Generic;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class DropdownNest1
	{
		[Dropdown("StringValues")]
		public string stringValue;

		public DropdownNest2 nest2;

		private List<string> StringValues => new List<string> { "A", "B", "C" };
	}
}
