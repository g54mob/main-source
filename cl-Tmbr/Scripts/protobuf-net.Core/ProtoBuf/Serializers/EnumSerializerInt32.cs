using System.Runtime.CompilerServices;

namespace ProtoBuf.Serializers
{
	internal sealed class EnumSerializerInt32<T> : EnumSerializer<T, int> where T : unmanaged
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override int Read(ref ProtoReader.State state)
		{
			return state.ReadInt32();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void Write(ref ProtoWriter.State state, int value)
		{
			state.WriteInt32(value);
		}

		public override int MeasureVarint(int value)
		{
			if (value >= 0)
			{
				return ProtoWriter.MeasureUInt32((uint)value);
			}
			return 10;
		}

		public override int MeasureSignedVarint(int value)
		{
			return ProtoWriter.MeasureUInt32(ProtoWriter.Zig(value));
		}
	}
}
