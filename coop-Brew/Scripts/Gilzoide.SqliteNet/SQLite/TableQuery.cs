using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SQLite
{
	public class TableQuery<T> : BaseTableQuery, IEnumerable<T>, IEnumerable
	{
		private class CompileResult
		{
			public string CommandText { get; set; }

			public object Value { get; set; }
		}

		private Expression _where;

		private List<Ordering> _orderBys;

		private int? _limit;

		private int? _offset;

		private BaseTableQuery _joinInner;

		private Expression _joinInnerKeySelector;

		private BaseTableQuery _joinOuter;

		private Expression _joinOuterKeySelector;

		private Expression _joinSelector;

		private Expression _selector;

		private bool _deferred;

		public SQLiteConnection Connection { get; private set; }

		public TableMapping Table { get; private set; }

		private TableQuery(SQLiteConnection conn, TableMapping table)
		{
		}

		public TableQuery(SQLiteConnection conn)
		{
		}

		public TableQuery<U> Clone<U>()
		{
			return null;
		}

		public TableQuery<T> Where(Expression<Func<T, bool>> predExpr)
		{
			return null;
		}

		public int Delete()
		{
			return 0;
		}

		public int Delete(Expression<Func<T, bool>> predExpr)
		{
			return 0;
		}

		public TableQuery<T> Take(int n)
		{
			return null;
		}

		public TableQuery<T> Skip(int n)
		{
			return null;
		}

		public T ElementAt(int index)
		{
			return default(T);
		}

		public TableQuery<T> Deferred()
		{
			return null;
		}

		public TableQuery<T> OrderBy<U>(Expression<Func<T, U>> orderExpr)
		{
			return null;
		}

		public TableQuery<T> OrderByDescending<U>(Expression<Func<T, U>> orderExpr)
		{
			return null;
		}

		public TableQuery<T> ThenBy<U>(Expression<Func<T, U>> orderExpr)
		{
			return null;
		}

		public TableQuery<T> ThenByDescending<U>(Expression<Func<T, U>> orderExpr)
		{
			return null;
		}

		private TableQuery<T> AddOrderBy<U>(Expression<Func<T, U>> orderExpr, bool asc)
		{
			return null;
		}

		private void AddWhere(Expression pred)
		{
		}

		private SQLiteCommand GenerateCommand(string selectionList)
		{
			return null;
		}

		private CompileResult CompileExpr(Expression expr, List<object> queryArgs)
		{
			return null;
		}

		private static object ConvertTo(object obj, Type t)
		{
			return null;
		}

		private string CompileNullBinaryExpression(BinaryExpression expression, CompileResult parameter)
		{
			return null;
		}

		private string GetSqlName(Expression expr)
		{
			return null;
		}

		public int Count()
		{
			return 0;
		}

		public int Count(Expression<Func<T, bool>> predExpr)
		{
			return 0;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public List<T> ToList()
		{
			return null;
		}

		public T[] ToArray()
		{
			return null;
		}

		public T First()
		{
			return default(T);
		}

		public T FirstOrDefault()
		{
			return default(T);
		}

		public T First(Expression<Func<T, bool>> predExpr)
		{
			return default(T);
		}

		public T FirstOrDefault(Expression<Func<T, bool>> predExpr)
		{
			return default(T);
		}
	}
}
