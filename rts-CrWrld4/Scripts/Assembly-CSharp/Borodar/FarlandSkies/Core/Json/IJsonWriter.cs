namespace Borodar.FarlandSkies.Core.Json
{
	public interface IJsonWriter
	{
		void WriteStartObject(int propertyCount);

		void WritePropertyKey(string key);

		void WriteEndObject();

		void WriteStartArray(int arrayLength);

		void WriteEndArray();

		void WriteNull();

		void WriteInteger(long value);

		void WriteDouble(double value);

		void WriteString(string value);

		void WriteBoolean(bool value);

		void WriteBinary(byte[] value);
	}
}
