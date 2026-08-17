using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

[StructLayout((LayoutKind)3)]
public struct UniTaskCompletionSourceCore<TResult>
{
	private TResult result;

	private object error;

	private short version;

	private bool hasUnhandledError;

	private int completedCount;

	private Action<object> continuation;

	private object continuationState;

	public short Version
	{
		get
		{
			//IL_0007: Expected I4, but got O
			return (short)(int)error;
		}
	}

	public void Reset()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_003e: Expected O, but got I4
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF7040");
		object obj = error + 1;
		error = obj;
		_ = 0;
		UniTaskCompletionSourceCore<TResult> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<TResult>)0;
		result = (TResult)null;
		_ = 0;
		version = 0;
		continuation = null;
	}

	private void ReportUnhandledError()
	{
		//IL_0036: Expected I, but got O
		//IL_0044: Expected I, but got O
		//IL_0054: Expected O, but got I
		//IL_00d4: Expected O, but got I4
		//IL_0090: Expected O, but got I
		//IL_00c6: Expected O, but got I4
		//IL_00f6: Expected I, but got O
		//IL_0106: Expected O, but got I
		//IL_0186: Expected O, but got I4
		//IL_0142: Expected O, but got I
		//IL_0178: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UniTaskCompletionSourceCore`1<TResult>)+1A]");
		if ((nint)0 == 0)
		{
			return;
		}
		TResult val = result;
		if (result == null)
		{
			return;
		}
		nint num = (nint)val;
		nint num2 = (nint)typeof(OperationCanceledException);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r8_v3 (Il2CppClass<System.OperationCanceledException>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v3 (Il2CppClass<TResult>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r8_v3 (Il2CppClass<System.OperationCanceledException>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v3 (Il2CppClass<TResult>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v22+FFFFFFF8+v102 @ rax_v4*8]");
			if (0 == (nint)typeof(OperationCanceledException))
			{
				obj3 = 1;
				goto IL_0202;
			}
		}
		obj3 = 0;
		goto IL_0202;
		IL_0202:
		bool flag = obj3 == null;
		Exception ex = null;
		if (!flag)
		{
			ex = (Exception)result;
		}
		object obj6;
		if (ex == null)
		{
			nint num4 = (nint)typeof(ExceptionHolder);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v5 (Il2CppClass<Cysharp.Threading.Tasks.ExceptionHolder>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v3 (Il2CppClass<TResult>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v5 (Il2CppClass<Cysharp.Threading.Tasks.ExceptionHolder>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r9_v3 (Il2CppClass<TResult>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v18+FFFFFFF8+v258 @ rax_v9*8]");
				if (0 == (nint)typeof(ExceptionHolder))
				{
					obj6 = 1;
					goto IL_0224;
				}
			}
			obj6 = 0;
			goto IL_0224;
		}
		UniTaskScheduler.PublishUnobservedTaskException(ex);
		return;
		IL_0224:
		bool flag2 = obj6 == null;
		ExceptionHolder exceptionHolder = null;
		if (!flag2)
		{
			exceptionHolder = (ExceptionHolder)result;
		}
		if (exceptionHolder != null)
		{
			ExceptionDispatchInfo exception = exceptionHolder.GetException();
			UniTaskScheduler.PublishUnobservedTaskException(exception.m_Exception);
		}
	}

	internal void MarkHandled()
	{
		_ = 0;
	}

	public bool TrySetResult(TResult result)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"lock xadd [rbx+1Ch],eax\"");
		return false;
	}

	public bool TrySetException(Exception error)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"lock xadd [rsi+1Ch],eax\"");
		return false;
	}

	public bool TrySetCanceled(CancellationToken cancellationToken = default(CancellationToken))
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"lock xadd [rsi+1Ch],eax\"");
		return false;
	}

	[MethodImpl((MethodImplOptions)256)]
	public UniTaskStatus GetStatus(short token)
	{
		//IL_00aa: Expected I, but got O
		//IL_00b2: Expected I, but got O
		//IL_00c2: Expected O, but got I
		//IL_00fe: Expected O, but got I
		if (token == (nint)error)
		{
			if (version != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UniTaskCompletionSourceCore`1<TResult>)+1C]");
				if ((nint)0 != 0)
				{
					if (result == null)
					{
						return UniTaskStatus.Succeeded;
					}
					TResult val = result;
					nint num = (nint)typeof(OperationCanceledException);
					nint num2 = (nint)val;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v3 (Il2CppClass<System.OperationCanceledException>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v2 (Il2CppClass<TResult>)+130]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v3 (Il2CppClass<System.OperationCanceledException>)+130]");
					if (num3 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v2 (Il2CppClass<TResult>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rax_v15+FFFFFFF8+v176 @ rax_v12*8]");
						if (0 == (nint)typeof(OperationCanceledException))
						{
							return UniTaskStatus.Canceled;
						}
					}
					return UniTaskStatus.Faulted;
				}
			}
			return UniTaskStatus.Pending;
		}
		object obj3 = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj3;
	}

	[MethodImpl((MethodImplOptions)256)]
	public UniTaskStatus UnsafeGetStatus()
	{
		//IL_006a: Expected I, but got O
		//IL_0072: Expected I, but got O
		//IL_0082: Expected O, but got I
		//IL_00be: Expected O, but got I
		if (version != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UniTaskCompletionSourceCore`1<TResult>)+1C]");
			if ((nint)0 != 0)
			{
				if (result == null)
				{
					return UniTaskStatus.Succeeded;
				}
				TResult val = result;
				nint num = (nint)typeof(OperationCanceledException);
				nint num2 = (nint)val;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v1 (Il2CppClass<System.OperationCanceledException>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r8_v1 (Il2CppClass<TResult>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v1 (Il2CppClass<System.OperationCanceledException>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r8_v1 (Il2CppClass<TResult>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v7+FFFFFFF8+v122 @ rax_v4*8]");
					if (0 == (nint)typeof(OperationCanceledException))
					{
						return UniTaskStatus.Canceled;
					}
				}
				return UniTaskStatus.Faulted;
			}
		}
		return UniTaskStatus.Pending;
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe TResult GetResult(short token)
	{
		//IL_0098: Expected O, but got I
		//IL_0193: Expected O, but got I
		//IL_0086: Expected O, but got I4
		//IL_0088: Expected O, but got Ref
		//IL_00d9: Expected I, but got O
		//IL_01de: Expected O, but got I
		//IL_0169: Expected O, but got I4
		//IL_025e: Expected O, but got I4
		//IL_0312: Expected O, but got I4
		//IL_0125: Expected O, but got I
		//IL_0351: Expected O, but got I4
		//IL_021a: Expected O, but got I
		//IL_0398: Expected O, but got I4
		//IL_017e: Expected O, but got I
		//IL_015b: Expected O, but got I4
		//IL_0273: Expected O, but got I
		//IL_0250: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [token @ rdx (System.Int16)+18]");
		IntPtr intPtr = default(IntPtr);
		object obj2;
		if (intPtr == (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [token @ rdx (System.Int16)+1C]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [token @ rdx (System.Int16)+10]");
				if ((nint)0 == 0)
				{
					UniTaskCompletionSourceCore<TResult> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<TResult>)((short*)token)->m_value;
					return (TResult)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [token @ rdx (System.Int16)+10]");
				UniTaskCompletionSourceCore<TResult> uniTaskCompletionSourceCore2 = (UniTaskCompletionSourceCore<TResult>)0;
				_ = 0;
				object typeFromHandle = typeof(OperationCanceledException);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [token @ rdx (System.Int16)+10]");
				if ((nint)0 == 0)
				{
					goto IL_0183;
				}
				nint num = (nint)uniTaskCompletionSourceCore2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v28+130]");
				short num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ r8_v10 (Il2CppMethodInfo)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v28+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ r8_v10 (Il2CppMethodInfo)+C8]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v38+FFFFFFF8+v170 @ rcx_v32 (System.Int16)*8]");
					if (0 == (nint)typeof(OperationCanceledException))
					{
						obj2 = 1;
						goto IL_02fa;
					}
				}
				obj2 = 0;
				goto IL_02fa;
			}
			object obj3 = new InvalidOperationException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
			throw obj3;
		}
		UniTaskCompletionSourceCore<TResult> uniTaskCompletionSourceCore3 = (UniTaskCompletionSourceCore<TResult>)new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw uniTaskCompletionSourceCore3;
		IL_0183:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [token @ rdx (System.Int16)+10]");
		UniTaskCompletionSourceCore<TResult> uniTaskCompletionSourceCore4 = (UniTaskCompletionSourceCore<TResult>)0;
		object typeFromHandle2 = typeof(ExceptionHolder);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [token @ rdx (System.Int16)+10]");
		if ((nint)0 == 0)
		{
			goto IL_032b;
		}
		object obj4 = uniTaskCompletionSourceCore4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v30+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ r8_v9+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rax_v30+130]");
		object obj7;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ r8_v9+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rcx_v31+FFFFFFF8+v282 @ rcx_v28*8]");
			if (0 == (nint)typeof(ExceptionHolder))
			{
				obj7 = 1;
				goto IL_0339;
			}
		}
		obj7 = 0;
		goto IL_0339;
		IL_02fa:
		bool flag = obj2 == null;
		UniTaskCompletionSourceCore<TResult> uniTaskCompletionSourceCore5 = (UniTaskCompletionSourceCore<TResult>)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [token @ rdx (System.Int16)+10]");
			uniTaskCompletionSourceCore5 = (UniTaskCompletionSourceCore<TResult>)0;
		}
		bool flag2 = (object)uniTaskCompletionSourceCore5 != null;
		UniTaskCompletionSourceCore<TResult> uniTaskCompletionSourceCore6 = (UniTaskCompletionSourceCore<TResult>)0;
		if (flag2)
		{
			throw uniTaskCompletionSourceCore5;
		}
		goto IL_0183;
		IL_032b:
		object obj8 = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj8;
		IL_0339:
		bool flag3 = obj7 == null;
		uniTaskCompletionSourceCore6 = (UniTaskCompletionSourceCore<TResult>)0;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [token @ rdx (System.Int16)+10]");
			uniTaskCompletionSourceCore6 = (UniTaskCompletionSourceCore<TResult>)0;
		}
		if ((object)uniTaskCompletionSourceCore6 != null)
		{
			throw new NullReferenceException();
		}
		goto IL_032b;
	}

	[MethodImpl((MethodImplOptions)256)]
	public unsafe void OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_0015: Expected O, but got I
		//IL_002a: Expected O, but got I
		//IL_007a: Expected O, but got Ref
		if (continuation != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ stack_28+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v14+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180704850");
			short num = version;
			if (version == 0)
			{
				this.continuation = (Action<object>)state;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 32));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F6860");
				short num2 = default(short);
				bool flag = num2 == 0;
				num = num2;
				if (flag)
				{
					return;
				}
			}
			if (num == (nint)UniTaskCompletionSourceCoreShared.s_sentinel)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [continuation @ rdx (System.Action`1<System.Object>)+18] (should have been resolved before IL gen)");
				return;
			}
			object obj4 = new InvalidOperationException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
			throw obj4;
		}
		ArgumentNullException ex = new ArgumentNullException("continuation");
		throw ex;
	}

	[MethodImpl((MethodImplOptions)256)]
	private void ValidateToken(short token)
	{
		if (token == (nint)error)
		{
			return;
		}
		object obj = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj;
	}
}
