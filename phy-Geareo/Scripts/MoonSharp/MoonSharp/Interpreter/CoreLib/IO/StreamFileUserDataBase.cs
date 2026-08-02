using System.IO;

namespace MoonSharp.Interpreter.CoreLib.IO
{
	internal abstract class StreamFileUserDataBase : FileUserDataBase
	{
		protected Stream m_Stream;

		protected StreamReader m_Reader;

		protected StreamWriter m_Writer;

		protected bool m_Closed;

		protected void Initialize(Stream stream, StreamReader reader, StreamWriter writer)
		{
		}

		private void CheckFileIsNotClosed()
		{
		}

		protected override bool Eof()
		{
			return false;
		}

		protected override string ReadLine()
		{
			return null;
		}

		protected override string ReadToEnd()
		{
			return null;
		}

		protected override string ReadBuffer(int p)
		{
			return null;
		}

		protected override char Peek()
		{
			return '\0';
		}

		protected override void Write(string value)
		{
		}

		protected override string Close()
		{
			return null;
		}

		public override bool flush()
		{
			return false;
		}

		public override long seek(string whence, long offset)
		{
			return 0L;
		}

		public override bool setvbuf(string mode)
		{
			return false;
		}

		protected internal override bool isopen()
		{
			return false;
		}
	}
}
