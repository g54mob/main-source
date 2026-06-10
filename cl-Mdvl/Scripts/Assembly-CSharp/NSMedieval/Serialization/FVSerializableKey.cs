using System;

namespace NSMedieval.Serialization
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
	public sealed class FVSerializableKey : Attribute
	{
		public string Key { get; }

		public string FormerKey { get; }

		public FVSerializableKey(string key, string formerKey = "")
		{
			Key = key;
			FormerKey = formerKey;
		}
	}
}
