using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;
using UnityEngine.Rendering;

namespace Cysharp.Threading.Tasks;

public class AutoResetUniTaskCompletionSource : IUniTaskSource, IValueTaskSource, ITaskPoolNode<AutoResetUniTaskCompletionSource>, IPromise, IResolvePromise, IRejectPromise, ICancelPromise
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003C_002Ecctor_003Eb__4_0()
		{
			//IL_0013: Expected I, but got O
			nint num = (nint)typeof(AutoResetUniTaskCompletionSource);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppStaticFields<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource>)+4]");
			return 0;
		}
	}

	private static TaskPool<AutoResetUniTaskCompletionSource> pool;

	private AutoResetUniTaskCompletionSource nextNode;

	private UniTaskCompletionSourceCore<AsyncUnit> core;

	private short version;

	public unsafe ref AutoResetUniTaskCompletionSource NextNode
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected Ref, but got Unknown
			return ref *(AutoResetUniTaskCompletionSource*)(this + 16);
		}
	}

	public unsafe UniTask Task
	{
		get
		{
			//IL_0028: Expected native int or pointer, but got O
			//IL_0032: Expected native int or pointer, but got O
			//IL_0015: Expected native int or pointer, but got O
			UniTask uniTask = default(UniTask);
			((UniTask*)(nint)uniTask)->token = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, this);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
			((UniTask*)(nint)uniTask)->token = 0;
			return uniTask;
		}
	}

	static AutoResetUniTaskCompletionSource()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type2 = default(Type);
		Type type = type2;
		Func<int> getSize = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
		TaskPool.RegisterSizeGetter(type, getSize);
	}

	private AutoResetUniTaskCompletionSource()
	{
	}

	public unsafe static AutoResetUniTaskCompletionSource Create()
	{
		//IL_005e: Expected I, but got O
		nint num = (nint)typeof(AutoResetUniTaskCompletionSource);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v3 (Il2CppClass<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource>)+B8]");
		AutoResetUniTaskCompletionSource autoResetUniTaskCompletionSource = default(AutoResetUniTaskCompletionSource);
		AutoResetUniTaskCompletionSource autoResetUniTaskCompletionSource2;
		if (!((TaskPool<AutoResetUniTaskCompletionSource>*)null)->TryPop(out var result))
		{
			autoResetUniTaskCompletionSource = new AutoResetUniTaskCompletionSource();
			autoResetUniTaskCompletionSource2 = autoResetUniTaskCompletionSource;
		}
		else
		{
			autoResetUniTaskCompletionSource2 = result;
		}
		if (autoResetUniTaskCompletionSource2 != null)
		{
			AutoResetUniTaskCompletionSource autoResetUniTaskCompletionSource3 = autoResetUniTaskCompletionSource2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v5 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
			autoResetUniTaskCompletionSource3.version = 0;
			return autoResetUniTaskCompletionSource;
		}
		return (AutoResetUniTaskCompletionSource)(object)new NullReferenceException();
	}

	public unsafe static AutoResetUniTaskCompletionSource CreateFromCanceled(CancellationToken cancellationToken, out short token)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		AutoResetUniTaskCompletionSource autoResetUniTaskCompletionSource = Create();
		if (autoResetUniTaskCompletionSource != null)
		{
			short num = autoResetUniTaskCompletionSource.version;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
			if ((nint)num == 0)
			{
				UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(autoResetUniTaskCompletionSource + 24);
				bool flag = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetCanceled(cancellationToken);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
			ref short reference = ref *(short*)null;
			return autoResetUniTaskCompletionSource;
		}
		return (AutoResetUniTaskCompletionSource)(object)new NullReferenceException();
	}

	public unsafe static AutoResetUniTaskCompletionSource CreateFromException(Exception exception, out short token)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		AutoResetUniTaskCompletionSource autoResetUniTaskCompletionSource = Create();
		if (autoResetUniTaskCompletionSource != null)
		{
			short num = autoResetUniTaskCompletionSource.version;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
			if ((nint)num == 0)
			{
				UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(autoResetUniTaskCompletionSource + 24);
				bool flag = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetException(exception);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
			ref short reference = ref *(short*)null;
			return autoResetUniTaskCompletionSource;
		}
		return (AutoResetUniTaskCompletionSource)(object)new NullReferenceException();
	}

	public unsafe static AutoResetUniTaskCompletionSource CreateCompleted(out short token)
	{
		AutoResetUniTaskCompletionSource autoResetUniTaskCompletionSource = Create();
		if (autoResetUniTaskCompletionSource != null)
		{
			bool flag = autoResetUniTaskCompletionSource.TrySetResult();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
			ref short reference = ref *(short*)null;
			return autoResetUniTaskCompletionSource;
		}
		return (AutoResetUniTaskCompletionSource)(object)new NullReferenceException();
	}

	public unsafe bool TrySetResult()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		short num = version;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
		if ((nint)num != 0)
		{
			return false;
		}
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 24);
		return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetResult(AsyncUnit.Default);
	}

	public unsafe bool TrySetCanceled(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		short num = version;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
		if ((nint)num != 0)
		{
			return false;
		}
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 24);
		return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetCanceled(cancellationToken);
	}

	public unsafe bool TrySetException(Exception exception)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		short num = version;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource)+28]");
		if ((nint)num != 0)
		{
			return false;
		}
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 24);
		return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->TrySetException(exception);
	}

	public unsafe void GetResult(short token)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_0066: Expected O, but got I4
		object obj = default(object);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(obj + 24);
		AsyncUnit result = ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->GetResult(token);
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore2 = default(UniTaskCompletionSourceCore<AsyncUnit>);
		AsyncUnit result2 = uniTaskCompletionSourceCore2.GetResult(token);
		object obj2 = 0;
	}

	public unsafe UniTaskStatus GetStatus(short token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 24);
		return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->GetStatus(token);
	}

	public unsafe UniTaskStatus UnsafeGetStatus()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 24);
		return ((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
	}

	public unsafe void OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 24);
		((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
	}

	private unsafe bool TryReturn()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0027: Expected I, but got O
		UniTaskCompletionSourceCore<AsyncUnit> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncUnit>)(this + 24);
		((UniTaskCompletionSourceCore<AsyncUnit>*)uniTaskCompletionSourceCore)->Reset();
		nint num = (nint)typeof(AutoResetUniTaskCompletionSource);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource>)+B8]");
		return ((TaskPool<object>*)null)->TryPush(this);
	}
}
public class AutoResetUniTaskCompletionSource<T> : IUniTaskSource<T>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T>, ITaskPoolNode<AutoResetUniTaskCompletionSource<T>>, IPromise<T>, IResolvePromise<T>, IRejectPromise, ICancelPromise
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		static _003C_003Ec()
		{
			//IL_0035: Expected O, but got I
			//IL_004a: Expected O, but got I
			nint num = 0;
			object obj = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1+<>c>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v12+B8]");
			object obj3 = 0;
			obj3 = obj;
		}

		internal int _003C_002Ecctor_003Eb__4_0()
		{
			//IL_0020: Expected O, but got I
			//IL_0036: Expected O, but got I
			//IL_008a: Expected O, but got I
			//IL_0063: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1+<>c>)+28]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v5+135]");
			object obj2 = (nint)0 & (nint)1;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v5+B8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v9+4]");
				return 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v6+B8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v7+4]");
			return 0;
		}
	}

	private static TaskPool<AutoResetUniTaskCompletionSource<T>> pool;

	private AutoResetUniTaskCompletionSource<T> nextNode;

	private UniTaskCompletionSourceCore<T> core;

	private short version;

	public unsafe ref AutoResetUniTaskCompletionSource<T> NextNode
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected Ref, but got Unknown
			return ref *(AutoResetUniTaskCompletionSource<T>*)(this + 16);
		}
	}

	public UniTask<T> Task
	{
		get
		{
			//IL_001b: Expected O, but got I
			_ = 0;
			nextNode = null;
			_ = 0;
			IntPtr intPtr = default(IntPtr);
			AutoResetUniTaskCompletionSource<T> autoResetUniTaskCompletionSource = (AutoResetUniTaskCompletionSource<T>)(nint)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+30]");
			_ = 0;
			_ = 0;
			return (UniTask<T>)this;
		}
	}

	static AutoResetUniTaskCompletionSource()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0078: Expected O, but got I
		//IL_008d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rbx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1>)+10]");
		Type type;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type2 = default(Type);
			type = type2;
		}
		else
		{
			type = null;
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1>)+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v16+B8]");
		object obj4 = 0;
		Func<int> getSize = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
		TaskPool.RegisterSizeGetter(type, getSize);
	}

	private AutoResetUniTaskCompletionSource()
	{
	}

	public static AutoResetUniTaskCompletionSource<T> Create()
	{
		//IL_0035: Expected O, but got I
		nint num = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1>)+38]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183AEA500");
		object obj2 = default(object);
		AutoResetUniTaskCompletionSource<T> autoResetUniTaskCompletionSource = default(AutoResetUniTaskCompletionSource<T>);
		AutoResetUniTaskCompletionSource<T> autoResetUniTaskCompletionSource2;
		if (obj2 == null)
		{
			nint num3 = 0;
			autoResetUniTaskCompletionSource = null;
			autoResetUniTaskCompletionSource2 = autoResetUniTaskCompletionSource;
		}
		else
		{
			AutoResetUniTaskCompletionSource<T> autoResetUniTaskCompletionSource3 = default(AutoResetUniTaskCompletionSource<T>);
			autoResetUniTaskCompletionSource2 = autoResetUniTaskCompletionSource3;
		}
		if (autoResetUniTaskCompletionSource2 != null && autoResetUniTaskCompletionSource2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v2 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
			_ = 0;
			return autoResetUniTaskCompletionSource;
		}
		return (AutoResetUniTaskCompletionSource<T>)(object)new NullReferenceException();
	}

	public unsafe static AutoResetUniTaskCompletionSource<T> CreateFromCanceled(CancellationToken cancellationToken, out short token)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844B65D0");
		AutoResetUniTaskCompletionSource<T> autoResetUniTaskCompletionSource = default(AutoResetUniTaskCompletionSource<T>);
		if (autoResetUniTaskCompletionSource != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+48]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
			if (num2 == 0)
			{
				UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(autoResetUniTaskCompletionSource + 24);
				bool flag = ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->TrySetCanceled(cancellationToken);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
			ref short reference = ref *(short*)null;
			return autoResetUniTaskCompletionSource;
		}
		return (AutoResetUniTaskCompletionSource<T>)(object)new NullReferenceException();
	}

	public unsafe static AutoResetUniTaskCompletionSource<T> CreateFromException(Exception exception, out short token)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844B65D0");
		AutoResetUniTaskCompletionSource<T> autoResetUniTaskCompletionSource = default(AutoResetUniTaskCompletionSource<T>);
		if (autoResetUniTaskCompletionSource != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+48]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
			if (num2 == 0)
			{
				UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(autoResetUniTaskCompletionSource + 24);
				bool flag = ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->TrySetException(exception);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
			ref short reference = ref *(short*)null;
			return autoResetUniTaskCompletionSource;
		}
		return (AutoResetUniTaskCompletionSource<T>)(object)new NullReferenceException();
	}

	public unsafe static AutoResetUniTaskCompletionSource<T> CreateFromResult(T result, out short token)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844B65D0");
		AutoResetUniTaskCompletionSource<T> autoResetUniTaskCompletionSource = default(AutoResetUniTaskCompletionSource<T>);
		if (autoResetUniTaskCompletionSource != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+48]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
			if (num2 == 0)
			{
				object obj = autoResetUniTaskCompletionSource + 24;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807058F0");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
			ref short reference = ref *(short*)null;
			return autoResetUniTaskCompletionSource;
		}
		return (AutoResetUniTaskCompletionSource<T>)(object)new NullReferenceException();
	}

	public bool TrySetResult(T result)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+48]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
		if (num != 0)
		{
			return false;
		}
		object obj = this + 24;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807058F0");
		bool result2 = default(bool);
		return result2;
	}

	public unsafe bool TrySetCanceled(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+48]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
		if (num != 0)
		{
			return false;
		}
		UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 24);
		return ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->TrySetCanceled(cancellationToken);
	}

	public unsafe bool TrySetException(Exception exception)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+48]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1<T>)+30]");
		if (num != 0)
		{
			return false;
		}
		UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 24);
		return ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->TrySetException(exception);
	}

	public T GetResult(short token)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0025: Expected O, but got I4
		//IL_0035: Expected O, but got I
		//IL_0045: Expected O, but got I
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_007d: Expected O, but got I4
		AutoResetUniTaskCompletionSource<T> autoResetUniTaskCompletionSource = (AutoResetUniTaskCompletionSource<T>)0;
		object obj2 = default(object);
		object obj = obj2 + 16;
		object obj3 = token + 24;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ r9+20]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rcx_v1+C0]");
		object obj5 = 0;
		object obj6 = obj2 - 48;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183EF7880");
		autoResetUniTaskCompletionSource = (AutoResetUniTaskCompletionSource<T>)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844B6BF0");
		object obj7 = 0;
		return (T)this;
	}

	void IUniTaskSource.GetResult(short token)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844B6B30");
	}

	public unsafe UniTaskStatus GetStatus(short token)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 24);
		return ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->GetStatus(token);
	}

	public unsafe UniTaskStatus UnsafeGetStatus()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 24);
		return ((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
	}

	public unsafe void OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 24);
		((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
	}

	private unsafe bool TryReturn()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0035: Expected O, but got I
		UniTaskCompletionSourceCore<AsyncGPUReadbackRequest> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>)(this + 24);
		((UniTaskCompletionSourceCore<AsyncGPUReadbackRequest>*)uniTaskCompletionSourceCore)->Reset();
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.AutoResetUniTaskCompletionSource`1>)+38]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v9+B8]");
		return ((TaskPool<object>*)null)->TryPush(this);
	}
}
