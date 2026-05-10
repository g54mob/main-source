using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	public sealed class DictionaryDrawerSettings : Attribute
	{
		public string KeyLabel;

		public string ValueLabel;

		public DictionaryDisplayOptions DisplayMode;

		public bool IsReadOnly;

		public float KeyColumnWidth;
	}
}
