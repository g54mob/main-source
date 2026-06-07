using System;
using System.Collections;
using System.Text;

namespace VoxelBusters.CoreLibrary.Parser
{
	public class JsonWriter
	{
		private const int kBufferLength = 512;

		private StringBuilder m_stringBuilder;

		public JsonWriter(int bufferLength = 512)
		{
		}

		public string Serialise(object objectValue)
		{
			return null;
		}

		public void WriteObjectValue(object objectVal)
		{
		}

		public void WriteDictionary(IDictionary dict)
		{
		}

		public void WriteArray(Array array)
		{
		}

		public void WriteList(IList list)
		{
		}

		public void WritePrimitive(object value)
		{
		}

		public void WriteEnum(object value)
		{
		}

		public void WriteNullValue()
		{
		}

		public void WriteString(string stringVal)
		{
		}

		public void WriteDictionaryStart()
		{
		}

		public void WriteKeyValuePair(string key, object value, bool appendSeperator = false)
		{
		}

		public void WriteKeyValuePairSeperator()
		{
		}

		public void WriteDictionaryEnd()
		{
		}

		public void WriteArrayStart()
		{
		}

		public void WriteArrayEnd()
		{
		}

		public void WriteElementSeperator()
		{
		}
	}
}
