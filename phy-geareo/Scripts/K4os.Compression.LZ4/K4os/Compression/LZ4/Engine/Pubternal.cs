using K4os.Compression.LZ4.Internal;

namespace K4os.Compression.LZ4.Engine
{
	public static class Pubternal
	{
		public class FastContext : UnmanagedResources
		{
			internal unsafe LL.LZ4_stream_t* Context { get; }

			protected override void ReleaseUnmanaged()
			{
			}
		}

		public unsafe static int CompressFast(FastContext context, byte* source, byte* target, int sourceLength, int targetLength, int acceleration)
		{
			return 0;
		}
	}
}
