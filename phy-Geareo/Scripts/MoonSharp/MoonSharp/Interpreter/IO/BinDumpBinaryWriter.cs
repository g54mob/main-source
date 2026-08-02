using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MoonSharp.Interpreter.IO
{
	public class BinDumpBinaryWriter : BinaryWriter
	{
		private Dictionary<string, int> m_StringMap;

		public BinDumpBinaryWriter(Stream s)
		{
		}

		public BinDumpBinaryWriter(Stream s, Encoding e)
		{
		}

		public override void Write(uint value)
		{
		}

		public override void Write(int value)
		{
		}

		public override void Write(string value)
		{
		}
	}
}
