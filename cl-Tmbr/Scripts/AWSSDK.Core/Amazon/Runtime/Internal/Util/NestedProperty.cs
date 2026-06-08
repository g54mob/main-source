using System.Collections.Generic;

namespace Amazon.Runtime.Internal.Util
{
	internal class NestedProperty
	{
		public string ParentKey { get; set; }

		public List<string> SubpropertyKeys { get; set; } = new List<string>();

		public List<string> SubpropertyValues { get; set; } = new List<string>();
	}
}
