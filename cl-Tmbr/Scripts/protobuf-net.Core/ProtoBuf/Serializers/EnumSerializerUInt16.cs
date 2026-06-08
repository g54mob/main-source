using System.Runtime.CompilerServices;

namespace ProtoBuf.Serializers
{
	internal sealed class EnumSerializerUInt16<T> : EnumSerializer<T, ushort> where T : unmanaged
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override ushort Read(ref ProtoReader.State state)
		{
			return state.ReadUInt16();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void Write(ref ProtoWriter.State state, ushort value)
		{
			state.WriteUInt16(value);
		}

		public override int MeasureVarint(ushort value)
		{
			return ProtoWriter.MeasureUInt32(value);
		}
	}
}
