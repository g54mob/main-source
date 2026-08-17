using System;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public abstract class MoveNextSource : IUniTaskSource<bool>, IUniTaskSource, IValueTaskSource, IValueTaskSource<bool>
{
	protected UniTaskCompletionSourceCore<bool> completionSource;

	public unsafe bool GetResult(short token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
		return ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->GetResult(token);
	}

	public unsafe UniTaskStatus GetStatus(short token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
		return ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->GetStatus(token);
	}

	public unsafe void OnCompleted(Action<object> continuation, object state, short token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
		((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->OnCompleted(continuation, state, token);
	}

	public unsafe UniTaskStatus UnsafeGetStatus()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
		return ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->UnsafeGetStatus();
	}

	unsafe void IUniTaskSource.GetResult(short token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
		bool result = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->GetResult(token);
	}

	protected unsafe bool TryGetResult<T>(UniTask<T>.Awaiter awaiter, out T result)
	{
		//IL_0008: Expected O, but got Ref
		//IL_003b: Expected O, but got I
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_00a1: Expected O, but got Ref
		//IL_006c: Expected O, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2 (Il2CppClass<T>)+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2 (Il2CppClass<T>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		object obj4 = obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2 (Il2CppClass<T>)+FC]");
		if ((nint)obj4 <= 0)
		{
			obj3 = 1152921504606846960L;
		}
		object obj5 = obj3 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		nint num2 = 0;
		obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v68 @ rdx_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		return true;
	}

	protected bool TryGetResult(UniTask.Awaiter awaiter)
	{
		if ((object)awaiter.task != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
		}
		return true;
	}
}
