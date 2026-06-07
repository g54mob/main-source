using System;
using System.Collections.Generic;

namespace SQLite
{
	internal class EnumCacheInfo
	{
		public bool IsEnum { get; private set; }

		public bool StoreAsText { get; private set; }

		public Dictionary<int, string> EnumValues { get; private set; }

		public EnumCacheInfo(Type type)
		{
		}
	}
}
