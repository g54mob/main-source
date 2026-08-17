using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

[StructLayout((LayoutKind)3)]
public struct UniTaskCancelableAsyncEnumerable<T>
{
	[StructLayout((LayoutKind)3)]
	public struct Enumerator
	{
		private readonly IUniTaskAsyncEnumerator<T> enumerator;

		public unsafe T Current
		{
			get
			{
				//IL_0008: Expected O, but got Ref
				//IL_0018: Expected O, but got I
				//IL_003c: Expected O, but got I
				//IL_004c: Expected O, but got I
				//IL_0062: Expected O, but got I
				//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fc: Expected O, but got Unknown
				//IL_0093: Expected O, but got I8
				//IL_00a8: Expected O, but got I
				//IL_00bd: Expected O, but got I
				object obj2 = default(object);
				object obj = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2+C0]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3+18]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v2+FC]");
				object obj6 = (nint)0 + (nint)15;
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rcx_v2+FC]");
				if ((nint)obj7 <= 0)
				{
					obj6 = 1152921504606846960L;
				}
				object obj8 = obj6 & -16;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8+20]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v8+C0]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1800");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					T result = default(T);
					return result;
				}
				return (T)new NullReferenceException();
			}
		}

		internal Enumerator(IUniTaskAsyncEnumerator<T> enumerator)
		{
		}

		public unsafe UniTask<bool> MoveNextAsync()
		{
			//IL_002d: Expected O, but got I
			//IL_0042: Expected O, but got I
			//IL_005b: Expected O, but got Ref
			IntPtr intPtr = default(IntPtr);
			if (intPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v3+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
				object obj3 = default(object);
				Enumerator enumerator = (Enumerator)obj3;
				return (UniTask<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			}
			return (UniTask<bool>)new NullReferenceException();
		}

		public unsafe UniTask DisposeAsync()
		{
			//IL_0017: Expected native int or pointer, but got O
			if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
				UniTask uniTask = default(UniTask);
				object source = default(object);
				System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
				return uniTask;
			}
			return (UniTask)new NullReferenceException();
		}
	}

	private readonly IUniTaskAsyncEnumerable<T> enumerable;

	private readonly CancellationToken cancellationToken;

	internal UniTaskCancelableAsyncEnumerable(IUniTaskAsyncEnumerable<T> enumerable, CancellationToken cancellationToken)
	{
	}

	public unsafe Enumerator GetAsyncEnumerator()
	{
		if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18070AB30");
			Enumerator result = default(Enumerator);
			return result;
		}
		return (Enumerator)new NullReferenceException();
	}
}
