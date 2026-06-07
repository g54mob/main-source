namespace VoxelBusters.CoreLibrary.Parser
{
	public class JsonReader
	{
		internal JsonString JSONString { get; private set; }

		private JsonReader()
		{
		}

		public JsonReader(string stringValue)
		{
		}

		public object Deserialise()
		{
			return null;
		}

		public object Deserialise(ref int errorIndex)
		{
			return null;
		}

		private object ReadValue(ref int index)
		{
			return null;
		}

		private object ReadObject(ref int index)
		{
			return null;
		}

		private int ReadKeyValuePair(ref int index, out string key, out object value)
		{
			key = null;
			value = null;
			return 0;
		}

		private object ReadArray(ref int index)
		{
			return null;
		}

		private string ReadString(ref int index)
		{
			return null;
		}

		private object ReadNumber(ref int index)
		{
			return null;
		}

		private JsonToken LookAhead(int index)
		{
			return default(JsonToken);
		}

		private JsonToken NextToken(ref int index)
		{
			return default(JsonToken);
		}

		private void RemoveWhiteSpace(ref int index)
		{
		}
	}
}
