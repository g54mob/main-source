using System;

namespace MG_BlocksEngine2.Serializer
{
	[Serializable]
	public class DefineItem
	{
		public string type;

		public string value;

		public DefineItem(string type, string value)
		{
			this.type = type;
			this.value = value;
		}
	}
}
