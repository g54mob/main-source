using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace SQLite
{
	[Preserve(AllMembers = true)]
	public class SQLiteConnection : ISQLiteConnection, IDisposable
	{
		private struct IndexedColumn
		{
			public int Order;

			public string ColumnName;
		}

		private struct IndexInfo
		{
			public string IndexName;

			public string TableName;

			public bool Unique;

			public List<IndexedColumn> Columns;
		}

		[Preserve(AllMembers = true)]
		public class ColumnInfo
		{
			[Column("name")]
			public string Name { get; set; }

			public int notnull { get; set; }

			public override string ToString()
			{
				return null;
			}
		}

		private bool _open;

		private TimeSpan _busyTimeout;

		private static readonly Dictionary<string, TableMapping> _mappings;

		private Stopwatch _sw;

		private long _elapsedMilliseconds;

		private int _transactionDepth;

		private Random _rand;

		private static readonly IntPtr NullHandle;

		private static readonly IntPtr NullBackupHandle;

		private readonly Dictionary<Tuple<string, string>, PreparedSqlLiteInsertCommand> _insertCommandMap;

		public IntPtr Handle { get; private set; }

		public string DatabasePath { get; private set; }

		public int LibVersionNumber { get; private set; }

		public bool TimeExecution { get; set; }

		public bool Trace { get; set; }

		public Action<string> Tracer { get; set; }

		public bool StoreDateTimeAsTicks { get; private set; }

		public bool StoreTimeSpanAsTicks { get; private set; }

		public string DateTimeStringFormat { get; private set; }

		internal DateTimeStyles DateTimeStyle { get; private set; }

		public TimeSpan BusyTimeout
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public IEnumerable<TableMapping> TableMappings => null;

		public bool IsInTransaction => false;

		public event EventHandler<NotifyTableChangedEventArgs> TableChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public SQLiteConnection(string databasePath, bool storeDateTimeAsTicks = true)
		{
		}

		public SQLiteConnection(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks = true)
		{
		}

		public SQLiteConnection(SQLiteConnectionString connectionString)
		{
		}

		public void EnableWriteAheadLogging()
		{
		}

		public static string Quote(string unsafeString)
		{
			return null;
		}

		private void SetKey(string key)
		{
		}

		private void SetKey(byte[] key)
		{
		}

		public void ReKey(string key)
		{
		}

		public void ReKey(byte[] key)
		{
		}

		public void EnableLoadExtension(bool enabled)
		{
		}

		private static byte[] GetNullTerminatedUtf8(string s)
		{
			return null;
		}

		public TableMapping GetMapping(Type type, CreateFlags createFlags = CreateFlags.None)
		{
			return null;
		}

		public TableMapping GetMapping<T>(CreateFlags createFlags = CreateFlags.None)
		{
			return null;
		}

		public int DropTable<T>()
		{
			return 0;
		}

		public int DropTable(TableMapping map)
		{
			return 0;
		}

		public CreateTableResult CreateTable<T>(CreateFlags createFlags = CreateFlags.None)
		{
			return default(CreateTableResult);
		}

		public CreateTableResult CreateTable(Type ty, CreateFlags createFlags = CreateFlags.None)
		{
			return default(CreateTableResult);
		}

		public CreateTablesResult CreateTables<T, T2>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new()
		{
			return null;
		}

		public CreateTablesResult CreateTables<T, T2, T3>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new()
		{
			return null;
		}

		public CreateTablesResult CreateTables<T, T2, T3, T4>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new() where T4 : new()
		{
			return null;
		}

		public CreateTablesResult CreateTables<T, T2, T3, T4, T5>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new() where T4 : new() where T5 : new()
		{
			return null;
		}

		public CreateTablesResult CreateTables(CreateFlags createFlags = CreateFlags.None, params Type[] types)
		{
			return null;
		}

		public int CreateIndex(string indexName, string tableName, string[] columnNames, bool unique = false)
		{
			return 0;
		}

		public int CreateIndex(string indexName, string tableName, string columnName, bool unique = false)
		{
			return 0;
		}

		public int CreateIndex(string tableName, string columnName, bool unique = false)
		{
			return 0;
		}

		public int CreateIndex(string tableName, string[] columnNames, bool unique = false)
		{
			return 0;
		}

		public int CreateIndex<T>(Expression<Func<T, object>> property, bool unique = false)
		{
			return 0;
		}

		public List<ColumnInfo> GetTableInfo(string tableName)
		{
			return null;
		}

		private void MigrateTable(TableMapping map, List<ColumnInfo> existingCols)
		{
		}

		protected virtual SQLiteCommand NewCommand()
		{
			return null;
		}

		public SQLiteCommand CreateCommand(string cmdText, params object[] ps)
		{
			return null;
		}

		public SQLiteCommand CreateCommand(string cmdText, Dictionary<string, object> args)
		{
			return null;
		}

		public int Execute(string query, params object[] args)
		{
			return 0;
		}

		public T ExecuteScalar<T>(string query, params object[] args)
		{
			return default(T);
		}

		public List<T> Query<T>(string query, params object[] args) where T : new()
		{
			return null;
		}

		public List<T> QueryScalars<T>(string query, params object[] args)
		{
			return null;
		}

		public IEnumerable<T> DeferredQuery<T>(string query, params object[] args) where T : new()
		{
			return null;
		}

		public List<object> Query(TableMapping map, string query, params object[] args)
		{
			return null;
		}

		public IEnumerable<object> DeferredQuery(TableMapping map, string query, params object[] args)
		{
			return null;
		}

		public TableQuery<T> Table<T>() where T : new()
		{
			return null;
		}

		public T Get<T>(object pk) where T : new()
		{
			return default(T);
		}

		public object Get(object pk, TableMapping map)
		{
			return null;
		}

		public T Get<T>(Expression<Func<T, bool>> predicate) where T : new()
		{
			return default(T);
		}

		public T Find<T>(object pk) where T : new()
		{
			return default(T);
		}

		public object Find(object pk, TableMapping map)
		{
			return null;
		}

		public T Find<T>(Expression<Func<T, bool>> predicate) where T : new()
		{
			return default(T);
		}

		public T FindWithQuery<T>(string query, params object[] args) where T : new()
		{
			return default(T);
		}

		public object FindWithQuery(TableMapping map, string query, params object[] args)
		{
			return null;
		}

		public void BeginTransaction()
		{
		}

		public string SaveTransactionPoint()
		{
			return null;
		}

		public void Rollback()
		{
		}

		public void RollbackTo(string savepoint)
		{
		}

		private void RollbackTo(string savepoint, bool noThrow)
		{
		}

		public void Release(string savepoint)
		{
		}

		private void DoSavePointExecute(string savepoint, string cmd)
		{
		}

		public void Commit()
		{
		}

		public void RunInTransaction(Action action)
		{
		}

		public int InsertAll(IEnumerable objects, bool runInTransaction = true)
		{
			return 0;
		}

		public int InsertAll(IEnumerable objects, string extra, bool runInTransaction = true)
		{
			return 0;
		}

		public int InsertAll(IEnumerable objects, Type objType, bool runInTransaction = true)
		{
			return 0;
		}

		public int Insert(object obj)
		{
			return 0;
		}

		public int InsertOrReplace(object obj)
		{
			return 0;
		}

		public int Insert(object obj, Type objType)
		{
			return 0;
		}

		public int InsertOrReplace(object obj, Type objType)
		{
			return 0;
		}

		public int Insert(object obj, string extra)
		{
			return 0;
		}

		public int Insert(object obj, string extra, Type objType)
		{
			return 0;
		}

		private PreparedSqlLiteInsertCommand GetInsertCommand(TableMapping map, string extra)
		{
			return null;
		}

		private PreparedSqlLiteInsertCommand CreateInsertCommand(TableMapping map, string extra)
		{
			return null;
		}

		public int Update(object obj)
		{
			return 0;
		}

		public int Update(object obj, Type objType)
		{
			return 0;
		}

		public int UpdateAll(IEnumerable objects, bool runInTransaction = true)
		{
			return 0;
		}

		public int Delete(object objectToDelete)
		{
			return 0;
		}

		public int Delete<T>(object primaryKey)
		{
			return 0;
		}

		public int Delete(object primaryKey, TableMapping map)
		{
			return 0;
		}

		public int DeleteAll<T>()
		{
			return 0;
		}

		public int DeleteAll(TableMapping map)
		{
			return 0;
		}

		public void Backup(string destinationDatabasePath, string databaseName = "main")
		{
		}

		~SQLiteConnection()
		{
		}

		public void Dispose()
		{
		}

		public void Close()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		private void OnTableChanged(TableMapping table, NotifyTableChangedAction action)
		{
		}
	}
}
