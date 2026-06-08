using System;

namespace Amazon.Runtime.EventStreams
{
	public interface IEventStreamHeader
	{
		string Name { get; }

		EventStreamHeaderType HeaderType { get; }

		int GetWireSize();

		int WriteToBuffer(byte[] buffer, int offset);

		bool AsBool();

		void SetBool(bool value);

		sbyte AsSByte();

		void SetSByte(sbyte value);

		short AsInt16();

		void SetInt16(short value);

		int AsInt32();

		void SetInt32(int value);

		long AsInt64();

		void SetInt64(long value);

		byte[] AsByteBuf();

		void SetByteBuf(byte[] value);

		string AsString();

		void SetString(string value);

		DateTime AsTimestamp();

		void SetTimestamp(DateTime value);

		Guid AsUUID();

		void SetUUID(Guid value);
	}
}
