using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance.Streams;

namespace CommunityToolkit.HighPerformance
{
	public static class IMemoryOwnerExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Stream AsStream(this IMemoryOwner<byte> memoryOwner)
		{
			return CommunityToolkit.HighPerformance.Streams.MemoryStream.Create(memoryOwner);
		}
	}
}
