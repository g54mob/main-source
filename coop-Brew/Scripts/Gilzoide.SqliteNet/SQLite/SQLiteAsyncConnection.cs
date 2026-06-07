using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SQLite
{
	public class SQLiteAsyncConnection : ISQLiteAsyncConnection
	{
		private readonly SQLiteConnectionString _connectionString;

		public string DatabasePath => null;

		public int LibVersionNumber => 0;

		public string DateTimeStringFormat => null;

		public bool StoreDateTimeAsTicks => false;

		public bool StoreTimeSpanAsTicks => false;

		public bool Trace
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Action<string> Tracer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool TimeExecution
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public IEnumerable<TableMapping> TableMappings => null;

		public SQLiteAsyncConnection(string databasePath, bool storeDateTimeAsTicks = true)
		{
		}

		public SQLiteAsyncConnection(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks = true)
		{
		}

		public SQLiteAsyncConnection(SQLiteConnectionString connectionString)
		{
		}

		public TimeSpan GetBusyTimeout()
		{
			return default(TimeSpan);
		}

		public Task SetBusyTimeoutAsync(TimeSpan value)
		{
			return null;
		}

		public Task EnableWriteAheadLoggingAsync()
		{
			return null;
		}

		public static void ResetPool()
		{
		}

		public SQLiteConnectionWithLock GetConnection()
		{
			return null;
		}

		private SQLiteConnectionWithLock GetConnectionAndTransactionLock(out object transactionLock)
		{
			transactionLock = null;
			return null;
		}

		public Task CloseAsync()
		{
			return null;
		}

		private Task<T> ReadAsync<T>(Func<SQLiteConnectionWithLock, T> read)
		{
			return null;
		}

		private Task<T> WriteAsync<T>(Func<SQLiteConnectionWithLock, T> write)
		{
			return null;
		}

		private Task<T> TransactAsync<T>(Func<SQLiteConnectionWithLock, T> transact)
		{
			return null;
		}

		public Task EnableLoadExtensionAsync(bool enabled)
		{
			return null;
		}

		public Task<CreateTableResult> CreateTableAsync<T>(CreateFlags createFlags = CreateFlags.None) where T : new()
		{
			return null;
		}

		public Task<CreateTableResult> CreateTableAsync(Type ty, CreateFlags createFlags = CreateFlags.None)
		{
			return null;
		}

		public Task<CreateTablesResult> CreateTablesAsync<T, T2>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new()
		{
			return null;
		}

		public Task<CreateTablesResult> CreateTablesAsync<T, T2, T3>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new()
		{
			return null;
		}

		public Task<CreateTablesResult> CreateTablesAsync<T, T2, T3, T4>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new() where T4 : new()
		{
			return null;
		}

		public Task<CreateTablesResult> CreateTablesAsync<T, T2, T3, T4, T5>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new() where T4 : new() where T5 : new()
		{
			return null;
		}

		public Task<CreateTablesResult> CreateTablesAsync(CreateFlags createFlags = CreateFlags.None, params Type[] types)
		{
			return null;
		}

		public Task<int> DropTableAsync<T>() where T : new()
		{
			return null;
		}

		public Task<int> DropTableAsync(TableMapping map)
		{
			return null;
		}

		public Task<int> CreateIndexAsync(string tableName, string columnName, bool unique = false)
		{
			return null;
		}

		public Task<int> CreateIndexAsync(string indexName, string tableName, string columnName, bool unique = false)
		{
			return null;
		}

		public Task<int> CreateIndexAsync(string tableName, string[] columnNames, bool unique = false)
		{
			return null;
		}

		public Task<int> CreateIndexAsync(string indexName, string tableName, string[] columnNames, bool unique = false)
		{
			return null;
		}

		public Task<int> CreateIndexAsync<T>(Expression<Func<T, object>> property, bool unique = false)
		{
			return null;
		}

		public Task<int> InsertAsync(object obj)
		{
			return null;
		}

		public Task<int> InsertAsync(object obj, Type objType)
		{
			return null;
		}

		public Task<int> InsertAsync(object obj, string extra)
		{
			return null;
		}

		public Task<int> InsertAsync(object obj, string extra, Type objType)
		{
			return null;
		}

		public Task<int> InsertOrReplaceAsync(object obj)
		{
			return null;
		}

		public Task<int> InsertOrReplaceAsync(object obj, Type objType)
		{
			return null;
		}

		public Task<int> UpdateAsync(object obj)
		{
			return null;
		}

		public Task<int> UpdateAsync(object obj, Type objType)
		{
			return null;
		}

		public Task<int> UpdateAllAsync(IEnumerable objects, bool runInTransaction = true)
		{
			return null;
		}

		public Task<int> DeleteAsync(object objectToDelete)
		{
			return null;
		}

		public Task<int> DeleteAsync<T>(object primaryKey)
		{
			return null;
		}

		public Task<int> DeleteAsync(object primaryKey, TableMapping map)
		{
			return null;
		}

		public Task<int> DeleteAllAsync<T>()
		{
			return null;
		}

		public Task<int> DeleteAllAsync(TableMapping map)
		{
			return null;
		}

		public Task BackupAsync(string destinationDatabasePath, string databaseName = "main")
		{
			return null;
		}

		public Task<T> GetAsync<T>(object pk) where T : new()
		{
			return null;
		}

		public Task<object> GetAsync(object pk, TableMapping map)
		{
			return null;
		}

		public Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : new()
		{
			return null;
		}

		public Task<T> FindAsync<T>(object pk) where T : new()
		{
			return null;
		}

		public Task<object> FindAsync(object pk, TableMapping map)
		{
			return null;
		}

		public Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : new()
		{
			return null;
		}

		public Task<T> FindWithQueryAsync<T>(string query, params object[] args) where T : new()
		{
			return null;
		}

		public Task<object> FindWithQueryAsync(TableMapping map, string query, params object[] args)
		{
			return null;
		}

		public Task<TableMapping> GetMappingAsync(Type type, CreateFlags createFlags = CreateFlags.None)
		{
			return null;
		}

		public Task<TableMapping> GetMappingAsync<T>(CreateFlags createFlags = CreateFlags.None) where T : new()
		{
			return null;
		}

		public Task<List<SQLiteConnection.ColumnInfo>> GetTableInfoAsync(string tableName)
		{
			return null;
		}

		public Task<int> ExecuteAsync(string query, params object[] args)
		{
			return null;
		}

		public Task<int> InsertAllAsync(IEnumerable objects, bool runInTransaction = true)
		{
			return null;
		}

		public Task<int> InsertAllAsync(IEnumerable objects, string extra, bool runInTransaction = true)
		{
			return null;
		}

		public Task<int> InsertAllAsync(IEnumerable objects, Type objType, bool runInTransaction = true)
		{
			return null;
		}

		public Task RunInTransactionAsync(Action<SQLiteConnection> action)
		{
			return null;
		}

		public AsyncTableQuery<T> Table<T>() where T : new()
		{
			return null;
		}

		public Task<T> ExecuteScalarAsync<T>(string query, params object[] args)
		{
			return null;
		}

		public Task<List<T>> QueryAsync<T>(string query, params object[] args) where T : new()
		{
			return null;
		}

		public Task<List<T>> QueryScalarsAsync<T>(string query, params object[] args)
		{
			return null;
		}

		public Task<List<object>> QueryAsync(TableMapping map, string query, params object[] args)
		{
			return null;
		}

		public Task<IEnumerable<T>> DeferredQueryAsync<T>(string query, params object[] args) where T : new()
		{
			return null;
		}

		public Task<IEnumerable<object>> DeferredQueryAsync(TableMapping map, string query, params object[] args)
		{
			return null;
		}

		public Task ReKeyAsync(string key)
		{
			return null;
		}

		public Task ReKeyAsync(byte[] key)
		{
			return null;
		}
	}
}
