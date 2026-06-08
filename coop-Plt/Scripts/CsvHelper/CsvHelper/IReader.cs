using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsvHelper
{
	public interface IReader : IReaderRow, IDisposable
	{
		bool ReadHeader();

		bool Read();

		Task<bool> ReadAsync();

		IEnumerable<T> GetRecords<T>();

		IEnumerable<T> GetRecords<T>(T anonymousTypeDefinition);

		IEnumerable<object> GetRecords(Type type);

		IEnumerable<T> EnumerateRecords<T>(T record);
	}
}
