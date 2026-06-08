using System.Runtime.CompilerServices;

namespace ProtoBuf.Serializers
{
	internal sealed class EnumSerializerUInt32<T> : EnumSerializer<T, uint> where T : unmanaged
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override uint Read(ref ProtoReader.State state)
		{
			return state.ReadUInt32();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void Write(ref ProtoWriter.State state, uint value)
		{
			state.WriteUInt32(value);
		}

		public override int MeasureVarint(uint value)
		{
			return ProtoWriter.MeasureUInt32(value);
		}
	}
}
