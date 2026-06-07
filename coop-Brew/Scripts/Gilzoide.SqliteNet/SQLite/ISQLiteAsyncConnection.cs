using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SQLite
{
	public interface ISQLiteAsyncConnection
	{
		string DatabasePath { get; }

		int LibVersionNumber { get; }

		string DateTimeStringFormat { get; }

		bool StoreDateTimeAsTicks { get; }

		bool StoreTimeSpanAsTicks { get; }

		bool Trace { get; set; }

		Action<string> Tracer { get; set; }

		bool TimeExecution { get; set; }

		IEnumerable<TableMapping> TableMappings { get; }

		Task BackupAsync(string destinationDatabasePath, string databaseName = "main");

		Task CloseAsync();

		Task<int> CreateIndexAsync(string tableName, string columnName, bool unique = false);

		Task<int> CreateIndexAsync(string indexName, string tableName, string columnName, bool unique = false);

		Task<int> CreateIndexAsync(string tableName, string[] columnNames, bool unique = false);

		Task<int> CreateIndexAsync(string indexName, string tableName, string[] columnNames, bool unique = false);

		Task<int> CreateIndexAsync<T>(Expression<Func<T, object>> property, bool unique = false);

		Task<CreateTableResult> CreateTableAsync<T>(CreateFlags createFlags = CreateFlags.None) where T : new();

		Task<CreateTableResult> CreateTableAsync(Type ty, CreateFlags createFlags = CreateFlags.None);

		Task<CreateTablesResult> CreateTablesAsync<T, T2>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new();

		Task<CreateTablesResult> CreateTablesAsync<T, T2, T3>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new();

		Task<CreateTablesResult> CreateTablesAsync<T, T2, T3, T4>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new() where T4 : new();

		Task<CreateTablesResult> CreateTablesAsync<T, T2, T3, T4, T5>(CreateFlags createFlags = CreateFlags.None) where T : new() where T2 : new() where T3 : new() where T4 : new() where T5 : new();

		Task<CreateTablesResult> CreateTablesAsync(CreateFlags createFlags = CreateFlags.None, params Type[] types);

		Task<IEnumerable<T>> DeferredQueryAsync<T>(string query, params object[] args) where T : new();

		Task<IEnumerable<object>> DeferredQueryAsync(TableMapping map, string query, params object[] args);

		Task<int> DeleteAllAsync<T>();

		Task<int> DeleteAllAsync(TableMapping map);

		Task<int> DeleteAsync(object objectToDelete);

		Task<int> DeleteAsync<T>(object primaryKey);

		Task<int> DeleteAsync(object primaryKey, TableMapping map);

		Task<int> DropTableAsync<T>() where T : new();

		Task<int> DropTableAsync(TableMapping map);

		Task EnableLoadExtensionAsync(bool enabled);

		Task EnableWriteAheadLoggingAsync();

		Task<int> ExecuteAsync(string query, params object[] args);

		Task<T> ExecuteScalarAsync<T>(string query, params object[] args);

		Task<T> FindAsync<T>(object pk) where T : new();

		Task<object> FindAsync(object pk, TableMapping map);

		Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : new();

		Task<T> FindWithQueryAsync<T>(string query, params object[] args) where T : new();

		Task<object> FindWithQueryAsync(TableMapping map, string query, params object[] args);

		Task<T> GetAsync<T>(object pk) where T : new();

		Task<object> GetAsync(object pk, TableMapping map);

		Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : new();

		TimeSpan GetBusyTimeout();

		SQLiteConnectionWithLock GetConnection();

		Task<TableMapping> GetMappingAsync(Type type, CreateFlags createFlags = CreateFlags.None);

		Task<TableMapping> GetMappingAsync<T>(CreateFlags createFlags = CreateFlags.None) where T : new();

		Task<List<SQLiteConnection.ColumnInfo>> GetTableInfoAsync(string tableName);

		Task<int> InsertAllAsync(IEnumerable objects, bool runInTransaction = true);

		Task<int> InsertAllAsync(IEnumerable objects, string extra, bool runInTransaction = true);

		Task<int> InsertAllAsync(IEnumerable objects, Type objType, bool runInTransaction = true);

		Task<int> InsertAsync(object obj);

		Task<int> InsertAsync(object obj, Type objType);

		Task<int> InsertAsync(object obj, string extra);

		Task<int> InsertAsync(object obj, string extra, Type objType);

		Task<int> InsertOrReplaceAsync(object obj);

		Task<int> InsertOrReplaceAsync(object obj, Type objType);

		Task<List<T>> QueryAsync<T>(string query, params object[] args) where T : new();

		Task<List<object>> QueryAsync(TableMapping map, string query, params object[] args);

		Task<List<T>> QueryScalarsAsync<T>(string query, params object[] args);

		Task ReKeyAsync(string key);

		Task ReKeyAsync(byte[] key);

		Task RunInTransactionAsync(Action<SQLiteConnection> action);

		Task SetBusyTimeoutAsync(TimeSpan value);

		AsyncTableQuery<T> Table<T>() where T : new();

		Task<int> UpdateAllAsync(IEnumerable objects, bool runInTransaction = true);

		Task<int> UpdateAsync(object obj);

		Task<int> UpdateAsync(object obj, Type objType);
	}
}
