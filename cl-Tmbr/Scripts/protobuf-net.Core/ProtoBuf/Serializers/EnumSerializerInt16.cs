using System.Runtime.CompilerServices;

namespace ProtoBuf.Serializers
{
	internal sealed class EnumSerializerInt16<T> : EnumSerializer<T, short> where T : unmanaged
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override short Read(ref ProtoReader.State state)
		{
			return state.ReadInt16();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void Write(ref ProtoWriter.State state, short value)
		{
			state.WriteInt16(value);
		}

		public override int MeasureVarint(short value)
		{
			if (value >= 0)
			{
				return ProtoWriter.MeasureUInt32((uint)value);
			}
			return 10;
		}

		public override int MeasureSignedVarint(short value)
		{
			return ProtoWriter.MeasureUInt32(ProtoWriter.Zig(value));
		}
	}
}
