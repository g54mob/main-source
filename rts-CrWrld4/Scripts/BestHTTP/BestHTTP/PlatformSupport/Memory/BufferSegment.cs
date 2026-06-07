using BestHTTP.PlatformSupport.IL2CPP;

namespace BestHTTP.PlatformSupport.Memory
{
	[Il2CppEagerStaticClassConstruction]
	public struct BufferSegment
	{
		public static readonly BufferSegment Empty;

		public readonly byte[] Data;

		public readonly int Offset;

		public readonly int Count;

		public BufferSegment(byte[] data, int offset, int count)
		{
			Data = null;
			Offset = 0;
			Count = 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(BufferSegment other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(BufferSegment left, BufferSegment right)
		{
			return false;
		}

		public static bool operator !=(BufferSegment left, BufferSegment right)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
