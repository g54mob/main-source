using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	public class ChildGameObjectsOnlyAttribute : Attribute
	{
		public bool IncludeSelf;

		public bool IncludeInactive;
	}
}
