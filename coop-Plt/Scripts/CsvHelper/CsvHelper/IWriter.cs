using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CsvHelper
{
	public interface IWriter : IWriterRow, IDisposable
	{
		void Flush();

		Task FlushAsync();

		void NextRecord();

		Task NextRecordAsync();

		void WriteRecords(IEnumerable records);

		void WriteRecords<T>(IEnumerable<T> records);

		Task WriteRecordsAsync(IEnumerable records, CancellationToken cancellationToken = default(CancellationToken));

		Task WriteRecordsAsync<T>(IEnumerable<T> records, CancellationToken cancellationToken = default(CancellationToken));
	}
}
