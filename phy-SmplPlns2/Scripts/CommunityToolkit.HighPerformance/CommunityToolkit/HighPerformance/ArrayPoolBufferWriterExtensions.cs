using System.IO;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance.Buffers;
using CommunityToolkit.HighPerformance.Streams;

namespace CommunityToolkit.HighPerformance
{
	public static class ArrayPoolBufferWriterExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Stream AsStream(this ArrayPoolBufferWriter<byte> writer)
		{
			return new IBufferWriterStream<ArrayBufferWriterOwner>(new ArrayBufferWriterOwner(writer));
		}
	}
}
