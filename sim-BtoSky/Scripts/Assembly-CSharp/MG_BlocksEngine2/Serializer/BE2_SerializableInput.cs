using System;

namespace MG_BlocksEngine2.Serializer
{
	[Serializable]
	public class BE2_SerializableInput
	{
		public bool isOperation;

		public string value;

		public BE2_SerializableBlock operation;
	}
}
