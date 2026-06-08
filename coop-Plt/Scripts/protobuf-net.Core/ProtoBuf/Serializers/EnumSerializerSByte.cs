using System.Runtime.CompilerServices;

namespace ProtoBuf.Serializers
{
	internal sealed class EnumSerializerSByte<T> : EnumSerializer<T, sbyte> where T : unmanaged
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override sbyte Read(ref ProtoReader.State state)
		{
			return state.ReadSByte();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override void Write(ref ProtoWriter.State state, sbyte value)
		{
			state.WriteSByte(value);
		}

		public override int MeasureVarint(sbyte value)
		{
			if (value >= 0)
			{
				return ProtoWriter.MeasureUInt32((uint)value);
			}
			return 10;
		}

		public override int MeasureSignedVarint(sbyte value)
		{
			return ProtoWriter.MeasureUInt32(ProtoWriter.Zig(value));
		}
	}
}
