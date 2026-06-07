using System;
using System.Collections.Generic;
using System.Reflection;

namespace SQLite
{
	public class TableMapping
	{
		public class Column
		{
			private MemberInfo _member;

			public string Name { get; private set; }

			public PropertyInfo PropertyInfo => null;

			public string PropertyName => null;

			public Type ColumnType { get; private set; }

			public string Collation { get; private set; }

			public bool IsAutoInc { get; private set; }

			public bool IsAutoGuid { get; private set; }

			public bool IsPK { get; private set; }

			public IEnumerable<IndexedAttribute> Indices { get; set; }

			public bool IsNullable { get; private set; }

			public int? MaxStringLength { get; private set; }

			public bool StoreAsText { get; private set; }

			public Column(MemberInfo member, CreateFlags createFlags = CreateFlags.None)
			{
			}

			public Column(PropertyInfo member, CreateFlags createFlags = CreateFlags.None)
			{
			}

			public void SetValue(object obj, object val)
			{
			}

			public object GetValue(object obj)
			{
				return null;
			}

			private static Type GetMemberType(MemberInfo m)
			{
				return null;
			}
		}

		internal enum MapMethod
		{
			ByName = 0,
			ByPosition = 1
		}

		private readonly Column _autoPk;

		private readonly Column[] _insertColumns;

		private readonly Column[] _insertOrReplaceColumns;

		public Type MappedType { get; private set; }

		public string TableName { get; private set; }

		public bool WithoutRowId { get; private set; }

		public Column[] Columns { get; private set; }

		public Column PK { get; private set; }

		public string GetByPrimaryKeySql { get; private set; }

		public CreateFlags CreateFlags { get; private set; }

		internal MapMethod Method { get; private set; }

		public bool HasAutoIncPK { get; private set; }

		public Column[] InsertColumns => null;

		public Column[] InsertOrReplaceColumns => null;

		public TableMapping(Type type, CreateFlags createFlags = CreateFlags.None)
		{
		}

		private IReadOnlyCollection<MemberInfo> GetPublicMembers(Type type)
		{
			return null;
		}

		private IReadOnlyCollection<MemberInfo> GetFieldsFromValueTuple(Type type)
		{
			return null;
		}

		public void SetAutoIncPK(object obj, long id)
		{
		}

		public Column FindColumnWithPropertyName(string propertyName)
		{
			return null;
		}

		public Column FindColumn(string columnName)
		{
			return null;
		}
	}
}
