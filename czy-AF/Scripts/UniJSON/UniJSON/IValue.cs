using System;

namespace UniJSON
{
	public interface IValue<T>
	{
		ValueNodeType ValueType { get; }

		ArraySegment<byte> Bytes { get; }

		T New(ArraySegment<byte> bytes, ValueNodeType valueType, int parentIndex);

		T Key(Utf8String key, int parentIndex);

		void SetBytesCount(int count);

		bool GetBoolean();

		string GetString();

		Utf8String GetUtf8String();

		sbyte GetSByte();

		short GetInt16();

		int GetInt32();

		long GetInt64();

		byte GetByte();

		ushort GetUInt16();

		uint GetUInt32();

		ulong GetUInt64();

		float GetSingle();

		double GetDouble();

		U GetValue<U>();
	}
}
