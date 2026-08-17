using System;
using System.Collections.Generic;
using Cpp2ILInjected;

internal static class ListExtensions
{
	public static List<T> Splice<T>(List<T> list, int index, int count)
	{
		if (list != null)
		{
			List<T> range = list.GetRange(index, count);
			list.RemoveRange(index, count);
			return range;
		}
		return (List<T>)(object)new NullReferenceException();
	}

	public static List<T> Splice<T>(List<T> list, int index, int count, List<T> target = null)
	{
		//IL_01a8: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_01ff: Expected O, but got I
		//IL_0219: Expected O, but got I
		//IL_0061: Expected O, but got I4
		//IL_0181: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		if (target != null)
		{
			object obj = index + count;
			if (index < (nint)obj)
			{
				int num = index;
				List<T> result = default(List<T>);
				do
				{
					if (num < list._size)
					{
						T[] items = list._items;
						T[] items2 = target._items;
						int version = target._version + 1;
						target._version = version;
						if (target._size >= items2.Length)
						{
							((List<object>)(object)target).AddWithResize((object)items[num]);
						}
						else
						{
							int size = target._size + 1;
							target._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						num++;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return result;
				}
				while (num < (nint)obj);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1837339C0");
			return target;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v9+8]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdi_v7+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdi_v7+38]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183732C10");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdi_v7+38]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1837339C0");
		List<T> result2 = default(List<T>);
		return result2;
	}

	public static T Pop<T>(List<T> list)
	{
		//IL_003a: Expected O, but got I4
		//IL_0083: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_010c: Expected O, but got I
		if (list._size != 0)
		{
			object obj = list._size - 1;
			if ((nint)obj < list._size)
			{
				T[] items = list._items;
				object obj2 = list._size - 1;
				object obj3 = list._size - 1;
				if ((nint)obj3 < list._size)
				{
					int size = list._size - 1;
					list._size = size;
					int version = list._version + 1;
					list._version = version;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v6 (T[])+20+v148 @ rax_v10*4]");
					return (T)0;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			T result = default(T);
			return result;
		}
		return (T)null;
	}

	public static List<T> Slice<T>(List<T> list, int from = 0, int until = -1)
	{
		int num;
		if (until == -1)
		{
			if (list != null)
			{
				num = list._size;
				goto IL_0079;
			}
		}
		else
		{
			bool flag = list == null;
			num = until;
			if (!flag)
			{
				goto IL_0079;
			}
		}
		return (List<T>)(object)new NullReferenceException();
		IL_0079:
		int count = num - from;
		return list.GetRange(from, count);
	}

	public static List<T> Slice<T>(List<T> list, int from = 0, int until = -1, List<T> target = null)
	{
		//IL_0197: Expected O, but got I
		//IL_01a7: Expected O, but got I
		//IL_022d: Expected O, but got I
		//IL_023a: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		if (target != null)
		{
			bool flag = until != -1;
			int num = until;
			if (!flag)
			{
				num = list._size;
			}
			if (from < num)
			{
				int num2 = from;
				List<T> result = default(List<T>);
				do
				{
					if (num2 < list._size)
					{
						T[] items = list._items;
						T[] items2 = target._items;
						int version = target._version + 1;
						target._version = version;
						if (target._size >= items2.Length)
						{
							((List<object>)(object)target).AddWithResize((object)items[num2]);
						}
						else
						{
							int size = target._size + 1;
							target._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						num2++;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return result;
				}
				while (num2 < num);
			}
			return target;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9+8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v7+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		int num3 = ((until != -1) ? until : list._size);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v7+38]");
		object obj3 = 0;
		object obj4 = num3 - from;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183732C10");
		List<T> result2 = default(List<T>);
		return result2;
	}
}
