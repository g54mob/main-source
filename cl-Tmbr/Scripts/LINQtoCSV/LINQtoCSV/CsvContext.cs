using System;
using System.Collections.Generic;
using System.IO;

namespace LINQtoCSV
{
	public class CsvContext
	{
		public IEnumerable<T> Read<T>(string fileName, CsvFileDescription fileDescription) where T : class, new()
		{
			return ReadData<T>(fileName, null, fileDescription);
		}

		public IEnumerable<T> Read<T>(StreamReader stream) where T : class, new()
		{
			return Read<T>(stream, new CsvFileDescription());
		}

		public IEnumerable<T> Read<T>(string fileName) where T : class, new()
		{
			return Read<T>(fileName, new CsvFileDescription());
		}

		public IEnumerable<T> Read<T>(StreamReader stream, CsvFileDescription fileDescription) where T : class, new()
		{
			return ReadData<T>(null, stream, fileDescription);
		}

		private IEnumerable<T> ReadData<T>(string fileName, StreamReader stream, CsvFileDescription fileDescription) where T : class, new()
		{
			bool readingRawDataRows = typeof(IDataRow).IsAssignableFrom(typeof(T));
			FieldMapper_Reading<T> fm = null;
			if (!readingRawDataRows)
			{
				fm = new FieldMapper_Reading<T>(fileDescription, fileName, writingFile: false);
			}
			bool readingFile = !string.IsNullOrEmpty(fileName);
			if (readingFile)
			{
				stream = new StreamReader(fileName, fileDescription.TextEncoding, fileDescription.DetectEncodingFromByteOrderMarks);
			}
			else
			{
				if (stream == null || !stream.BaseStream.CanSeek)
				{
					throw new BadStreamException();
				}
				stream.BaseStream.Seek(0L, SeekOrigin.Begin);
			}
			CsvStream cs = new CsvStream(stream, null, fileDescription.SeparatorChar, fileDescription.IgnoreTrailingSeparatorChar);
			IDataRow row = ((!readingRawDataRows) ? new DataRow() : (new T() as IDataRow));
			AggregatedException ae = new AggregatedException(typeof(T).ToString(), fileName, fileDescription.MaximumNbrExceptions);
			try
			{
				List<int> charLengths = null;
				if (!readingRawDataRows)
				{
					charLengths = fm.GetCharLengths();
				}
				bool firstRow = true;
				while (cs.ReadRow(row, charLengths))
				{
					if (row.Count == 1 && (row[0].Value == null || string.IsNullOrEmpty(row[0].Value.Trim())))
					{
						continue;
					}
					if (firstRow && fileDescription.FirstLineHasColumnNames)
					{
						if (!readingRawDataRows)
						{
							fm.ReadNames(row);
						}
					}
					else
					{
						T obj = null;
						try
						{
							obj = ((!readingRawDataRows) ? fm.ReadObject(row, ae) : (row as T));
						}
						catch (AggregatedException ex)
						{
							throw ex;
						}
						catch (Exception e)
						{
							ae.AddException(e);
						}
						yield return obj;
					}
					firstRow = false;
				}
			}
			finally
			{
				if (readingFile)
				{
					stream.Close();
				}
				ae.ThrowIfExceptionsStored();
			}
		}

		public void Write<T>(IEnumerable<T> values, string fileName, CsvFileDescription fileDescription)
		{
			using StreamWriter stream = new StreamWriter(fileName, append: false, fileDescription.TextEncoding);
			WriteData(values, fileName, stream, fileDescription);
		}

		public void Write<T>(IEnumerable<T> values, TextWriter stream)
		{
			Write(values, stream, new CsvFileDescription());
		}

		public void Write<T>(IEnumerable<T> values, string fileName)
		{
			Write(values, fileName, new CsvFileDescription());
		}

		public void Write<T>(IEnumerable<T> values, TextWriter stream, CsvFileDescription fileDescription)
		{
			WriteData(values, null, stream, fileDescription);
		}

		private void WriteData<T>(IEnumerable<T> values, string fileName, TextWriter stream, CsvFileDescription fileDescription)
		{
			FieldMapper<T> fieldMapper = new FieldMapper<T>(fileDescription, fileName, writingFile: true);
			CsvStream csvStream = new CsvStream(null, stream, fileDescription.SeparatorChar, fileDescription.IgnoreTrailingSeparatorChar);
			List<string> row = new List<string>();
			if (fileDescription.FirstLineHasColumnNames)
			{
				fieldMapper.WriteNames(row);
				csvStream.WriteRow(row, fileDescription.QuoteAllFields);
			}
			foreach (T value in values)
			{
				fieldMapper.WriteObject(value, row);
				csvStream.WriteRow(row, fileDescription.QuoteAllFields);
			}
		}
	}
}
