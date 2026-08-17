using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;

public class ProcessQueue<T>
{
	private List<T> _pending;

	private List<KeyValuePair<T, int>> _pendingInserts;

	private List<T> _active;

	private List<T> _destroy;

	private int _toProcess;

	private bool _checkQueue;

	private static readonly ProfilerMarker s_processQueueMarker;

	public ProcessQueue()
	{
		nint num = 0;
		List<T> pending = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183731620");
		_pending = pending;
		nint num3 = 0;
		List<KeyValuePair<T, int>> pendingInserts = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183731620");
		_pendingInserts = pendingInserts;
		nint num5 = 0;
		List<T> active = null;
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183731620");
		_active = active;
		nint num7 = 0;
		List<T> list = null;
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183731620");
		_destroy = list;
		_checkQueue = false;
		_toProcess = 0;
	}

	public T add(T item)
	{
		List<object> pending = (List<object>)(object)_pending;
		if (_pending != null)
		{
			object[] items = pending._items;
			int version = pending._version + 1;
			pending._version = version;
			if (pending._items != null)
			{
				if (pending._size >= items.Length)
				{
					((List<object>)(object)_pending).AddWithResize((object)item);
					int toProcess = _toProcess + 1;
					_toProcess = toProcess;
					return item;
				}
				int size = pending._size + 1;
				pending._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int toProcess2 = _toProcess + 1;
				_toProcess = toProcess2;
				return item;
			}
		}
		return (T)new NullReferenceException();
	}

	public T insert(T item, int position)
	{
		if (_pendingInserts != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829C22B0");
			int toProcess = _toProcess + 1;
			_toProcess = toProcess;
			return item;
		}
		return (T)new NullReferenceException();
	}

	public T remove(T item)
	{
		List<object> list = (List<object>)(object)_destroy;
		if (_destroy != null)
		{
			object[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)_destroy).AddWithResize((object)item);
					int toProcess = _toProcess + 1;
					_toProcess = toProcess;
					return item;
				}
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int toProcess2 = _toProcess + 1;
				_toProcess = toProcess2;
				return item;
			}
		}
		return (T)new NullReferenceException();
	}

	public ProcessQueue<T> removeAll()
	{
		//IL_0022: Expected O, but got I4
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		List<T> active = _active;
		object obj = active._size - 1;
		if (active._size != 0)
		{
			List<T> list = _destroy;
			bool flag;
			ProcessQueue<T> result = default(ProcessQueue<T>);
			do
			{
				if ((nint)obj < active._size)
				{
					T[] items = active._items;
					T[] items2 = list._items;
					int version = list._version + 1;
					list._version = version;
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)items[obj]);
					}
					else
					{
						int size = list._size + 1;
						list._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int toProcess = _toProcess + 1;
					_toProcess = toProcess;
					object obj2 = obj - 1;
					flag = obj != null;
					obj = obj2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
			while (flag);
		}
		return this;
	}

	public List<T> Update()
	{
		//IL_0020: Expected O, but got I
		//IL_0035: Expected O, but got I
		//IL_007b: Expected O, but got I4
		//IL_061d: Expected I, but got O
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_02f2: Expected I4, but got O
		//IL_05a2: Expected O, but got I
		//IL_0418: Expected O, but got I
		//IL_02be: Expected I4, but got O
		//IL_042b: Expected O, but got I4
		//IL_0515: Expected O, but got I
		//IL_04d1: Expected O, but got I
		//IL_015a->IL0085: Incompatible stack heights: 2 vs 1
		//IL_05d3->IL0646: Incompatible stack heights: 3 vs 0
		//IL_030a->IL0216: Incompatible stack heights: 3 vs 2
		//IL_053f->IL03be: Incompatible stack heights: 4 vs 3
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v3 (Il2CppRgctx<ProcessQueue`1>)+60]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v7+B8]");
		object obj2 = 0;
		if (obj2 != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)obj2);
		}
		List<object> active = (List<object>)(object)_active;
		List<T> active2;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (_toProcess != 0)
		{
			List<T> list = _destroy;
			bool flag = _destroy == null;
			object obj3 = 0;
			int num2 = default(int);
			while ((nint)obj3 < list._size)
			{
				bool flag2 = (nint)obj3 >= list._size;
				T[] items = list._items;
				int size = active._size;
				num2 = Array.IndexOf(active._items, items[obj3], 0, active._size);
				if (num2 != -1)
				{
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1838145F0");
				}
				obj3++;
			}
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			bool flag3 = list._size <= 0;
			int num4 = num2;
			if (!flag3)
			{
				Array.Clear(list._items, 0, list._size);
				int size = 0;
				num4 = 0;
			}
			List<T> pending = _pending;
			bool flag4 = _pending == null;
			object obj4 = default(object);
			for (int i = 0; i < pending._size; i++)
			{
				bool flag5 = i >= pending._size;
				T[] items2 = pending._items;
				if (_checkQueue)
				{
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BE9E0");
					bool flag6 = (nint)obj4 != -1;
					num4 = (int)items2[i];
					if (flag6)
					{
						continue;
					}
				}
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002390");
				num4 = (int)items2[i];
			}
			int version2 = pending._version + 1;
			pending._version = version2;
			pending._size = 0;
			if (pending._size > 0)
			{
				Array.Clear(pending._items, 0, pending._size);
				int size = 0;
				num4 = 0;
			}
			List<KeyValuePair<T, int>> pendingInserts = _pendingInserts;
			bool flag7 = _pendingInserts == null;
			int num7 = 0;
			object obj8 = default(object);
			while (true)
			{
				int num8 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ r14_v7 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+18]");
				if ((nint)num8 >= (nint)0)
				{
					break;
				}
				int num9 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ r14_v7 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+18]");
				bool flag8 = (nint)num9 >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ r14_v7 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+10]");
				object obj5 = 0;
				object obj6 = num7 + 2;
				object obj7 = obj6 + obj6;
				int num11;
				object item;
				if (_checkQueue)
				{
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BE9E0");
					bool flag9 = (nint)obj8 != -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rcx_v18+v1014 @ rax_v27*8]");
					num4 = 0;
					if (flag9)
					{
						goto IL_052c;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rcx_v18+v1014 @ rax_v27*8]");
					num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rcx_v18+v1014 @ rax_v27*8]");
					num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rcx_v18+v1014 @ rax_v27*8]");
					item = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rcx_v18+v1014 @ rax_v27*8]");
					num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rcx_v18+v1014 @ rax_v27*8]");
					num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rcx_v18+v1014 @ rax_v27*8]");
					item = 0;
				}
				if (num11 > active._size)
				{
					num4 = active._size;
				}
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1216 @ r9_v10 (Il2CppRgctx<ProcessQueue`1>)+A0]");
				int size = 0;
				((List<object>)(object)_active).Insert(num4, item);
				goto IL_052c;
				IL_052c:
				num7++;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ r14_v7 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ r14_v7 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ r14_v7 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+10]");
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ r14_v7 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+18]");
				Array.Clear((Array)num13, 0, 0);
				num4 = 0;
			}
			_toProcess = 0;
			active2 = _active;
			autoScope.Dispose();
		}
		else
		{
			autoScope.Dispose();
			active2 = _active;
		}
		return active2;
	}

	private List<T> getActive()
	{
		return _active;
	}

	private int length()
	{
		//IL_0041: Expected I4, but got O
		List<T> active = _active;
		if (_active != null)
		{
			return active._size;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public void destroy()
	{
		//IL_0100: Expected O, but got I
		_toProcess = 0;
		List<T> pending = _pending;
		int version = pending._version + 1;
		pending._version = version;
		pending._size = 0;
		if (pending._size > 0)
		{
			Array.Clear(pending._items, 0, pending._size);
		}
		List<KeyValuePair<T, int>> pendingInserts = _pendingInserts;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v4 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v4 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v4 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v4 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<T, System.Int32>>)+18]");
			Array.Clear((Array)num, 0, 0);
		}
		List<T> active = _active;
		int version2 = active._version + 1;
		active._version = version2;
		active._size = 0;
		if (active._size > 0)
		{
			Array.Clear(active._items, 0, active._size);
		}
		List<T> list = _destroy;
		int version3 = list._version + 1;
		list._version = version3;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
	}

	static ProcessQueue()
	{
		//IL_0049: Expected O, but got I
		//IL_005f: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_00b7: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_0094: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899850D2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("ProcessQueue.Update", 5, MarkerFlags.Default, 0);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v5 (Il2CppRgctx<ProcessQueue`1>)+60]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v4+135]");
		object obj2 = (nint)0 & (nint)1;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v4+B8]");
			object obj3 = 0;
			obj3 = (nint)intPtr;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v6+B8]");
			object obj4 = 0;
			obj4 = (nint)intPtr;
		}
	}
}
