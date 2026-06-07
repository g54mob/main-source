using System;
using System.Threading.Tasks;

namespace CsvHelper
{
	public interface IFieldReader : IDisposable
	{
		ReadingContext Context { get; }

		bool IsBufferEmpty { get; }

		bool FillBuffer();

		Task<bool> FillBufferAsync();

		int GetChar();

		string GetField();

		void AppendField();

		void SetBufferPosition(int offset = 0);

		void SetFieldStart(int offset = 0);

		void SetFieldEnd(int offset = 0);

		void SetRawRecordStart(int offset);

		void SetRawRecordEnd(int offset);
	}
}
