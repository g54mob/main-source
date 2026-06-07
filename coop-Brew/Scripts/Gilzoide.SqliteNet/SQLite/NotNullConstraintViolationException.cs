using System.Collections.Generic;

namespace SQLite
{
	public class NotNullConstraintViolationException : SQLiteException
	{
		public IEnumerable<TableMapping.Column> Columns { get; protected set; }

		protected NotNullConstraintViolationException(SQLite3.Result r, string message)
			: base(default(SQLite3.Result), null)
		{
		}

		protected NotNullConstraintViolationException(SQLite3.Result r, string message, TableMapping mapping, object obj)
			: base(default(SQLite3.Result), null)
		{
		}

		public new static NotNullConstraintViolationException New(SQLite3.Result r, string message)
		{
			return null;
		}

		public static NotNullConstraintViolationException New(SQLite3.Result r, string message, TableMapping mapping, object obj)
		{
			return null;
		}

		public static NotNullConstraintViolationException New(SQLiteException exception, TableMapping mapping, object obj)
		{
			return null;
		}
	}
}
