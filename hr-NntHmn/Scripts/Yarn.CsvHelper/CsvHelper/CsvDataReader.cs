using System;
using System.Data;

namespace CsvHelper
{
	public class CsvDataReader : IDataReader, IDataRecord, IDisposable
	{
		private readonly CsvReader csv;

		private bool skipNextRead;

		public object this[int i] => null;

		public object this[string name] => null;

		public int Depth => 0;

		public bool IsClosed { get; private set; }

		public int RecordsAffected => 0;

		public int FieldCount => 0;

		public CsvDataReader(CsvReader csv)
		{
		}

		public void Close()
		{
		}

		public void Dispose()
		{
		}

		public bool GetBoolean(int i)
		{
			return false;
		}

		public byte GetByte(int i)
		{
			return 0;
		}

		public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
		{
			return 0L;
		}

		public char GetChar(int i)
		{
			return '\0';
		}

		public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
		{
			return 0L;
		}

		public IDataReader GetData(int i)
		{
			return null;
		}

		public string GetDataTypeName(int i)
		{
			return null;
		}

		public DateTime GetDateTime(int i)
		{
			return default(DateTime);
		}

		public decimal GetDecimal(int i)
		{
			return default(decimal);
		}

		public double GetDouble(int i)
		{
			return 0.0;
		}

		public Type GetFieldType(int i)
		{
			return null;
		}

		public float GetFloat(int i)
		{
			return 0f;
		}

		public Guid GetGuid(int i)
		{
			return default(Guid);
		}

		public short GetInt16(int i)
		{
			return 0;
		}

		public int GetInt32(int i)
		{
			return 0;
		}

		public long GetInt64(int i)
		{
			return 0L;
		}

		public string GetName(int i)
		{
			return null;
		}

		public int GetOrdinal(string name)
		{
			return 0;
		}

		public DataTable GetSchemaTable()
		{
			return null;
		}

		public string GetString(int i)
		{
			return null;
		}

		public object GetValue(int i)
		{
			return null;
		}

		public int GetValues(object[] values)
		{
			return 0;
		}

		public bool IsDBNull(int i)
		{
			return false;
		}

		public bool NextResult()
		{
			return false;
		}

		public bool Read()
		{
			return false;
		}
	}
}
