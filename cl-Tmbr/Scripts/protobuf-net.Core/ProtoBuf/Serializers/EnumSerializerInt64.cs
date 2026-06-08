using System.Runtime.CompilerServices;

namespace ProtoBuf.Serializers
{
	internal sealed class EnumSerializerInt64<T> : EnumSerializer<T, long> where T : unmanaged
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override long Read(ref ProtoReader.State state)
		{
			return state.ReadInt64();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void Write(ref ProtoWriter.State state, long value)
		{
			state.WriteInt64(value);
		}

		public override int MeasureVarint(long value)
		{
			return ProtoWriter.MeasureUInt64((ulong)value);
		}

		public override int MeasureSignedVarint(long value)
		{
			return ProtoWriter.MeasureUInt64(ProtoWriter.Zig(value));
		}
	}
}
