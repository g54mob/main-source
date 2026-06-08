using System;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class CharSerializer : UInt16Serializer
	{
		internal new static readonly CharSerializer Instance = new CharSerializer();

		private static readonly Type expectedType = typeof(char);

		public override Type ExpectedType => expectedType;

		private CharSerializer()
		{
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteUInt16((char)value);
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			return (char)state.ReadUInt16();
		}
	}
}
