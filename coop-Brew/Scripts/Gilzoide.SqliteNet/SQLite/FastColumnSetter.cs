using System;

namespace SQLite
{
	internal class FastColumnSetter
	{
		internal static Action<object, IntPtr, int> GetFastSetter<T>(SQLiteConnection conn, TableMapping.Column column)
		{
			return null;
		}

		private static Action<object, IntPtr, int> CreateNullableTypedSetterDelegate<ObjectType, ColumnMemberType>(TableMapping.Column column, Func<IntPtr, int, ColumnMemberType> getColumnValue) where ColumnMemberType : struct
		{
			return null;
		}

		private static Action<object, IntPtr, int> CreateTypedSetterDelegate<ObjectType, ColumnMemberType>(TableMapping.Column column, Func<IntPtr, int, ColumnMemberType> getColumnValue)
		{
			return null;
		}
	}
}
