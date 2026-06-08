using System.Runtime.CompilerServices;

namespace ProtoBuf.Serializers
{
	internal sealed class EnumSerializerUInt64<T> : EnumSerializer<T, ulong> where T : unmanaged
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override ulong Read(ref ProtoReader.State state)
		{
			return state.ReadUInt64();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void Write(ref ProtoWriter.State state, ulong value)
		{
			state.WriteUInt64(value);
		}

		public override int MeasureVarint(ulong value)
		{
			return ProtoWriter.MeasureUInt64(value);
		}
	}
}
