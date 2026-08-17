using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncAudioFilterReadTrigger : AsyncTriggerBase<(float[], int)>
{
	private unsafe void OnAudioFilterRead(float[] data, int channels)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0022: Expected O, but got Ref
		TriggerEvent<(float[], int)> triggerEvent = (TriggerEvent<(float[], int)>)(this + 32);
		object obj = default(object);
		((TriggerEvent<(float[], int)>*)triggerEvent)->SetResult(((float[], int))(&obj));
	}

	public IAsyncOnAudioFilterReadHandler GetOnAudioFilterReadAsyncHandler()
	{
		AsyncTriggerHandler<(float[], int)> result = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4970");
		return result;
	}

	public IAsyncOnAudioFilterReadHandler GetOnAudioFilterReadAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<(float[], int)>(this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<(float[], int)> OnAudioFilterReadAsync()
	{
		//IL_0013: Expected O, but got Ref
		AsyncTriggerHandler<(float[], int)> asyncTriggerHandler = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4970");
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<(float[], int)> uniTask = ((IAsyncOnAudioFilterReadHandler)(&obj)).OnAudioFilterReadAsync();
			AsyncAudioFilterReadTrigger asyncAudioFilterReadTrigger = (AsyncAudioFilterReadTrigger)uniTask;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v6 (Cysharp.Threading.Tasks.UniTask`1<System.ValueTuple`2<System.Single[], System.Int32>>)+10]");
			_ = 0;
			return (UniTask<(float[], int)>)this;
		}
		return (UniTask<(float[], int)>)new NullReferenceException();
	}

	public unsafe UniTask<(float[], int)> OnAudioFilterReadAsync(CancellationToken cancellationToken)
	{
		//IL_004e: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<(float[], int)> asyncTriggerHandler = new AsyncTriggerHandler<(float[], int)>((AsyncTriggerBase<(float[], int)>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<(float[], int)> uniTask = ((IAsyncOnAudioFilterReadHandler)(&obj)).OnAudioFilterReadAsync();
			AsyncAudioFilterReadTrigger asyncAudioFilterReadTrigger = (AsyncAudioFilterReadTrigger)uniTask;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v6 (Cysharp.Threading.Tasks.UniTask`1<System.ValueTuple`2<System.Single[], System.Int32>>)+10]");
			_ = 0;
			return (UniTask<(float[], int)>)this;
		}
		return (UniTask<(float[], int)>)new NullReferenceException();
	}

	public AsyncAudioFilterReadTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
