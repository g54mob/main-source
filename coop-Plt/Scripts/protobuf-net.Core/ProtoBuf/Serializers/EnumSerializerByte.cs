using System.Runtime.CompilerServices;

namespace ProtoBuf.Serializers
{
	internal sealed class EnumSerializerByte<T> : EnumSerializer<T, byte> where T : unmanaged
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override byte Read(ref ProtoReader.State state)
		{
			return state.ReadByte();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void Write(ref ProtoWriter.State state, byte value)
		{
			state.WriteByte(value);
		}

		public override int MeasureVarint(byte value)
		{
			return ProtoWriter.MeasureUInt32(value);
		}
	}
}
