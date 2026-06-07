using System;

namespace Sirenix.OdinInspector
{
	public sealed class DictionaryDrawerSettings : Attribute
	{
		public string KeyLabel = "Key";

		public string ValueLabel = "Value";

		public DictionaryDisplayOptions DisplayMode;

		public bool IsReadOnly;
	}
}
