using System.IO;

namespace Antlr4.Runtime
{
	public class AntlrInputStream : BaseInputCharStream
	{
		protected internal char[] data;

		public AntlrInputStream()
		{
		}

		public AntlrInputStream(string input)
		{
			data = input.ToCharArray();
			n = input.Length;
		}

		public AntlrInputStream(char[] data, int numberOfActualCharsInArray)
		{
			this.data = data;
			n = numberOfActualCharsInArray;
		}

		public AntlrInputStream(TextReader r)
			: this(r, 1024, 1024)
		{
		}

		public AntlrInputStream(TextReader r, int initialSize)
			: this(r, initialSize, 1024)
		{
		}

		public AntlrInputStream(TextReader r, int initialSize, int readChunkSize)
		{
			Load(r, initialSize, readChunkSize);
		}

		public AntlrInputStream(Stream input)
			: this(new StreamReader(input), 1024)
		{
		}

		public AntlrInputStream(Stream input, int initialSize)
			: this(new StreamReader(input), initialSize)
		{
		}

		public AntlrInputStream(Stream input, int initialSize, int readChunkSize)
			: this(new StreamReader(input), initialSize, readChunkSize)
		{
		}

		public virtual void Load(TextReader r, int size, int readChunkSize)
		{
			if (r != null)
			{
				data = r.ReadToEnd().ToCharArray();
				n = data.Length;
			}
		}

		protected override int ValueAt(int i)
		{
			return data[i];
		}

		protected override string ConvertDataToString(int start, int count)
		{
			return new string(data, start, count);
		}
	}
}
