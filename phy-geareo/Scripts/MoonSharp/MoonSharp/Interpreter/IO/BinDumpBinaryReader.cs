using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MoonSharp.Interpreter.IO
{
	public class BinDumpBinaryReader : BinaryReader
	{
		private List<string> m_Strings;

		public BinDumpBinaryReader(Stream s)
			: base(null)
		{
		}

		public BinDumpBinaryReader(Stream s, Encoding e)
			: base(null)
		{
		}

		public override int ReadInt32()
		{
			return 0;
		}

		public override uint ReadUInt32()
		{
			return 0u;
		}

		public override string ReadString()
		{
			return null;
		}
	}
}
