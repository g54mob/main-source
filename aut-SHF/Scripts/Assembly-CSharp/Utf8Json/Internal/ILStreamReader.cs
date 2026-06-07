using System.IO;
using System.Reflection.Emit;

namespace Utf8Json.Internal
{
	internal class ILStreamReader : BinaryReader
	{
		private static readonly OpCode[] oneByteOpCodes;

		private static readonly OpCode[] twoByteOpCodes;

		private int endPosition;

		public int CurrentPosition => 0;

		public bool EndOfStream => false;

		static ILStreamReader()
		{
		}

		public ILStreamReader(byte[] ilByteArray)
			: base(null)
		{
		}

		public OpCode ReadOpCode()
		{
			return default(OpCode);
		}

		public int ReadMetadataToken()
		{
			return 0;
		}
	}
}
