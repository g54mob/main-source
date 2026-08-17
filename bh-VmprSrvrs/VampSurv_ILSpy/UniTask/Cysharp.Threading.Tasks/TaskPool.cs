using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public static class TaskPool
{
	private sealed class _003CGetCacheSizeInfo_003Ed__4 : IEnumerable<(Type, int)>, IEnumerable, IEnumerator<(Type, int)>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private (Type, int) _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private Dictionary<Type, Func<int>> _003C_003E7__wrap1;

		private bool _003C_003E7__wrap2;

		private Dictionary<Type, Func<int>>.Enumerator _003C_003E7__wrap3;

		(Type, int) IEnumerator<(Type, int)>.Current
		{
			get
			{
				//IL_0010: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+18]");
				_003CGetCacheSizeInfo_003Ed__4 obj = (_003CGetCacheSizeInfo_003Ed__4)0;
				return ((Type, int))this;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				object obj = default(object);
				return ((Type, int))obj;
			}
		}

		public _003CGetCacheSizeInfo_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			_003C_003El__initialThreadId = num;
		}

		void IDisposable.Dispose()
		{
			//IL_001a: Expected O, but got I4
			//IL_0140: Expected O, but got I
			//IL_00fb: Expected O, but got I
			int num = _003C_003E1__state;
			object obj = _003C_003E1__state + 4;
			if ((nint)obj > 1 && _003C_003E1__state != 1)
			{
				return;
			}
			if (num != -4 && num != 1)
			{
				_ = 4294967295L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v3+38]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v3+30]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
						num = 0;
						object obj2 = default(object);
						throw obj2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ stack_8_v3+30]");
					Monitor.Exit(0);
				}
				return;
			}
			_ = 4294967293L;
			_ = 4294967295L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_8_v5+38]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_8_v5+30]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
					object obj3 = default(object);
					throw obj3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_8_v5+30]");
				Monitor.Exit(0);
			}
		}

		private unsafe bool MoveNext()
		{
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Expected O, but got Unknown
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Expected O, but got Unknown
			//IL_00d4: Expected O, but got I
			//IL_0145: Expected O, but got I4
			//IL_004a: Expected O, but got I
			//IL_01b8: Expected O, but got I4
			//IL_016a: Expected O, but got I
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_0082: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+10]");
			object obj2 = default(object);
			if ((nint)0 == 0)
			{
				_ = 4294967295L;
				_ = sizes;
				object obj = obj2 + 48;
				_ = 0;
				_ = 4294967293L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+38]");
				if ((nint)0 != 0)
				{
					Monitor.ThrowLockTakenException();
					goto IL_01cc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+30]");
				if ((nint)0 == 0)
				{
					ArgumentNullException ex = new ArgumentNullException("obj");
					ex._002Ector("obj");
					nint num = 0;
					obj = 0;
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+30]");
				Monitor.Enter(0);
				_ = sizes;
				_ = 0;
				_ = 2;
				obj = obj2 + 64;
				object obj3 = 2;
				object obj4 = obj2;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+10]");
				if ((nint)0 != 1)
				{
					return false;
				}
				object obj4 = obj2;
			}
			_ = 4294967292L;
			Dictionary<object, object>.Enumerator enumerator = (Dictionary<object, object>.Enumerator)(obj2 + 64);
			if (((Dictionary<object, object>.Enumerator*)enumerator)->MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+58]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+58]");
				bool flag = (nint)0 == 0;
				nint num = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v482 @ rcx_v17+18] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+50]");
					_ = 0;
					_ = 1;
					return true;
				}
				goto IL_01cc;
			}
			_ = 4294967293L;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 4294967295L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+38]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+30]");
				bool flag2 = (nint)0 == 0;
				object obj3 = 0;
				nint num = 0;
				if (flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
					object obj6 = default(object);
					throw obj6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ stack_8_v2+30]");
				Monitor.Exit(0);
			}
			_ = 0;
			return false;
			IL_01cc:
			throw new NullReferenceException();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			//IL_0020: Expected I4, but got I8
			bool flag = !_003C_003E7__wrap2;
			_003C_003E1__state = -1;
			if (!flag)
			{
				if (_003C_003E7__wrap1 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
					object obj = default(object);
					throw obj;
				}
				Monitor.Exit(_003C_003E7__wrap1);
			}
		}

		private void _003C_003Em__Finally2()
		{
			//IL_004d: Expected I4, but got I8
			//IL_003d: Expected I4, but got I8
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189992DF7]");
			if ((nint)0 == 0)
			{
				_ = 1;
				_003C_003E1__state = -3;
			}
			else
			{
				_003C_003E1__state = -3;
			}
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}

		IEnumerator<(Type, int)> IEnumerable<(Type, int)>.GetEnumerator()
		{
			if (_003C_003E1__state == -2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
				object obj = default(object);
				if (_003C_003El__initialThreadId == (nint)obj)
				{
					_003C_003E1__state = 0;
					return this;
				}
			}
			_003CGetCacheSizeInfo_003Ed__4 obj2 = null;
			obj2._003C_003E1__state = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			obj2._003C_003El__initialThreadId = num;
			return obj2;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (_003C_003E1__state == -2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
				object obj = default(object);
				if (_003C_003El__initialThreadId == (nint)obj)
				{
					_003C_003E1__state = 0;
					return this;
				}
			}
			_003CGetCacheSizeInfo_003Ed__4 obj2 = null;
			obj2._003C_003E1__state = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			obj2._003C_003El__initialThreadId = num;
			return obj2;
		}
	}

	internal static int MaxPoolSize;

	private static Dictionary<Type, Func<int>> sizes;

	unsafe static TaskPool()
	{
		//IL_004b: Expected O, but got Ref
		Dictionary<Type, Func<int>> dictionary = new Dictionary<Type, Func<int>>();
		sizes = dictionary;
		string text = Environment.internalGetEnvironmentVariable("UNITASK_MAX_POOLSIZE");
		if (text != null)
		{
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			object obj = default(object);
			if (System.Number.TryParseInt32((ReadOnlySpan<char>)(&obj), NumberStyles.Integer, currentInfo, out int result))
			{
				MaxPoolSize = result;
				return;
			}
		}
		MaxPoolSize = 2147483647;
	}

	public static void SetMaxPoolSize(int maxPoolSize)
	{
		MaxPoolSize = maxPoolSize;
	}

	public static IEnumerable<(Type, int)> GetCacheSizeInfo()
	{
		//IL_001c: Expected I4, but got I8
		_003CGetCacheSizeInfo_003Ed__4 obj = null;
		obj._003C_003E1__state = -2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
		int num = default(int);
		obj._003C_003El__initialThreadId = num;
		return obj;
	}

	public static void RegisterSizeGetter(Type type, Func<int> getSize)
	{
		//IL_00da: Expected O, but got I
		object obj = default(object);
		if (obj == null)
		{
			object obj2 = default(object);
			if (obj2 != null)
			{
				object obj4;
				object obj5;
				if (obj == null)
				{
					Monitor.Enter(obj2);
					bool flag = ((Dictionary<object, object>)(object)sizes).TryInsert((object)type, (object)getSize, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
					object obj3 = default(object);
					if (obj3 != null)
					{
						bool flag2 = obj2 == null;
						obj4 = getSize;
						obj5 = type;
						if (flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180ACF6C0");
							object obj6 = default(object);
							throw obj6;
						}
						Monitor.Exit(obj2);
					}
					return;
				}
				ArgumentException ex = new ArgumentException();
				IntPtr intPtr = default(IntPtr);
				obj4 = (nint)intPtr;
				obj5 = null;
				throw ex;
			}
			ArgumentNullException ex2 = new ArgumentNullException("obj");
			throw ex2;
		}
		Monitor.ThrowLockTakenException();
		throw null;
	}
}
[StructLayout((LayoutKind)3)]
public struct TaskPool<T> where T : class, ITaskPoolNode<T>
{
	private int gate;

	private int size;

	private T root;

	public int Size
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TaskPool`1<T>)+4]");
			return 0;
		}
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe bool TryPop(out T result)
	{
		//IL_0026: Expected O, but got I4
		//IL_0084: Expected O, but got I
		//IL_009e: Expected O, but got I4
		//IL_0063: Expected O, but got I
		//IL_011e: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		if (null == System.Runtime.CompilerServices.Unsafe.AsPointer(ref this))
		{
			TaskPool<T> taskPool = (TaskPool<T>)1;
		}
		ref T reference;
		if (null == System.Runtime.CompilerServices.Unsafe.AsPointer(ref this))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TaskPool`1<T>)+8]");
			TaskPool<T> taskPool;
			if ((nint)0 != 0)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v4 (Il2CppClass<Cysharp.Threading.Tasks.TaskPool`1>)+135]");
				object obj = (nint)0 & (nint)1;
				bool flag = obj == null;
				object obj2 = !flag;
				nint num2 = 1;
				if (obj2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
					num2 = 0;
				}
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180481500");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TaskPool`1<T>)+4]");
				_ = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TaskPool`1<T>)+8]");
				reference = ref *(T*)null;
				taskPool = (TaskPool<T>)0;
				return true;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TaskPool`1<T>)+8]");
			taskPool = (TaskPool<T>)0;
		}
		reference = ref *(T*)null;
		return false;
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe bool TryPush(T item)
	{
		//IL_000e: Expected O, but got I4
		//IL_00a2: Expected I4, but got O
		//IL_0021: Expected O, but got I4
		//IL_006d: Expected O, but got I
		//IL_008e: Expected O, but got I4
		if (null == System.Runtime.CompilerServices.Unsafe.AsPointer(ref this))
		{
			TaskPool<T> taskPool = (TaskPool<T>)1;
		}
		if (null == System.Runtime.CompilerServices.Unsafe.AsPointer(ref this))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TaskPool`1<T>)+4]");
			TaskPool<T> taskPool;
			if ((nint)0 < (nint)TaskPool.MaxPoolSize)
			{
				if (item != null)
				{
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180481500");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TaskPool`1<T>)+8]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.TaskPool`1<T>)+4]");
					_ = (nint)0 + (nint)1;
					taskPool = (TaskPool<T>)0;
					return true;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			taskPool = (TaskPool<T>)0;
		}
		return false;
	}
}
