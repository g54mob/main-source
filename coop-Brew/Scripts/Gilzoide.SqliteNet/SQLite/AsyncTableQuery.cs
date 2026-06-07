using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SQLite
{
	public class AsyncTableQuery<T> where T : new()
	{
		private TableQuery<T> _innerQuery;

		public AsyncTableQuery(TableQuery<T> innerQuery)
		{
		}

		private Task<U> ReadAsync<U>(Func<SQLiteConnectionWithLock, U> read)
		{
			return null;
		}

		private Task<U> WriteAsync<U>(Func<SQLiteConnectionWithLock, U> write)
		{
			return null;
		}

		public AsyncTableQuery<T> Where(Expression<Func<T, bool>> predExpr)
		{
			return null;
		}

		public AsyncTableQuery<T> Skip(int n)
		{
			return null;
		}

		public AsyncTableQuery<T> Take(int n)
		{
			return null;
		}

		public AsyncTableQuery<T> OrderBy<U>(Expression<Func<T, U>> orderExpr)
		{
			return null;
		}

		public AsyncTableQuery<T> OrderByDescending<U>(Expression<Func<T, U>> orderExpr)
		{
			return null;
		}

		public AsyncTableQuery<T> ThenBy<U>(Expression<Func<T, U>> orderExpr)
		{
			return null;
		}

		public AsyncTableQuery<T> ThenByDescending<U>(Expression<Func<T, U>> orderExpr)
		{
			return null;
		}

		public Task<List<T>> ToListAsync()
		{
			return null;
		}

		public Task<T[]> ToArrayAsync()
		{
			return null;
		}

		public Task<int> CountAsync()
		{
			return null;
		}

		public Task<int> CountAsync(Expression<Func<T, bool>> predExpr)
		{
			return null;
		}

		public Task<T> ElementAtAsync(int index)
		{
			return null;
		}

		public Task<T> FirstAsync()
		{
			return null;
		}

		public Task<T> FirstOrDefaultAsync()
		{
			return null;
		}

		public Task<T> FirstAsync(Expression<Func<T, bool>> predExpr)
		{
			return null;
		}

		public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predExpr)
		{
			return null;
		}

		public Task<int> DeleteAsync(Expression<Func<T, bool>> predExpr)
		{
			return null;
		}

		public Task<int> DeleteAsync()
		{
			return null;
		}
	}
}
