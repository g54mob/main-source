using System.Runtime.CompilerServices;

namespace Google.Protobuf
{
	internal static class WritingPrimitivesMessages
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteMessage(ref WriteContext ctx, IMessage value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteGroup(ref WriteContext ctx, IMessage value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteRawMessage(ref WriteContext ctx, IMessage message)
		{
		}
	}
}
