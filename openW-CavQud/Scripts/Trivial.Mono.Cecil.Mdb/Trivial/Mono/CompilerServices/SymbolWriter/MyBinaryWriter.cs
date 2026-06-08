using System.IO;

namespace Trivial.Mono.CompilerServices.SymbolWriter
{
	internal sealed class MyBinaryWriter : BinaryWriter
	{
		public MyBinaryWriter(Stream stream)
			: base(stream)
		{
		}

		public void WriteLeb128(int value)
		{
			Write7BitEncodedInt(value);
		}
	}
}
