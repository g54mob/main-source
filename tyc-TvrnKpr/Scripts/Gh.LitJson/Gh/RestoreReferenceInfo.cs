using System;

namespace Gh
{
	public class RestoreReferenceInfo
	{
		public ReferencableLookupKey reference;

		public Action<object> assign;

		public string targetFieldName;

		public bool allowBrokenReference;
	}
}
