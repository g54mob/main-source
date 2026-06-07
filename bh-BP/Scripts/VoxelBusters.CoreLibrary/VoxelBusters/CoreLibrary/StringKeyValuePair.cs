using System;

namespace VoxelBusters.CoreLibrary
{
	[Serializable]
	public class StringKeyValuePair : SerializableKeyValuePair<string, string>
	{
		public StringKeyValuePair(string key = null, string value = null)
			: base((string)null, (string)null)
		{
		}
	}
}
