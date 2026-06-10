using System.Collections.Generic;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	public class TarExtendedHeaderReader
	{
		private const byte LENGTH = 0;

		private const byte KEY = 1;

		private const byte VALUE = 2;

		private const byte END = 3;

		private readonly Dictionary<string, string> headers;

		private string[] headerParts;

		private int bbIndex;

		private byte[] byteBuffer;

		private char[] charBuffer;

		private readonly StringBuilder sb;

		private readonly Decoder decoder;

		private int state;

		private static readonly byte[] StateNext;

		public Dictionary<string, string> Headers => null;

		public void Read(byte[] buffer, int length)
		{
		}

		private void Flush()
		{
		}

		private void ResetBuffers()
		{
		}
	}
}
