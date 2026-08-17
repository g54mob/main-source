using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncRenderImageTrigger : AsyncTriggerBase<(RenderTexture, RenderTexture)>
{
	private unsafe void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002e: Expected O, but got Ref
		(RenderTexture, RenderTexture) tuple = (source, destination);
		TriggerEvent<(object, object)> triggerEvent = (TriggerEvent<(object, object)>)(this + 32);
		object obj = default(object);
		((TriggerEvent<(object, object)>*)triggerEvent)->SetResult(((object, object))(&obj));
	}

	public IAsyncOnRenderImageHandler GetOnRenderImageAsyncHandler()
	{
		AsyncTriggerHandler<(RenderTexture, RenderTexture)> result = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4CD0");
		return result;
	}

	public IAsyncOnRenderImageHandler GetOnRenderImageAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<(object, object)>((AsyncTriggerBase<(object, object)>)(object)this, cancellationToken, callOnce: false);
	}

	public unsafe UniTask<(RenderTexture, RenderTexture)> OnRenderImageAsync()
	{
		//IL_0013: Expected O, but got Ref
		AsyncTriggerHandler<(RenderTexture, RenderTexture)> asyncTriggerHandler = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4CD0");
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<(RenderTexture, RenderTexture)> uniTask = ((IAsyncOnRenderImageHandler)(&obj)).OnRenderImageAsync();
			AsyncRenderImageTrigger asyncRenderImageTrigger = (AsyncRenderImageTrigger)uniTask;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v6 (Cysharp.Threading.Tasks.UniTask`1<System.ValueTuple`2<UnityEngine.RenderTexture, UnityEngine.RenderTexture>>)+10]");
			_ = 0;
			return (UniTask<(RenderTexture, RenderTexture)>)this;
		}
		return (UniTask<(RenderTexture, RenderTexture)>)new NullReferenceException();
	}

	public unsafe UniTask<(RenderTexture, RenderTexture)> OnRenderImageAsync(CancellationToken cancellationToken)
	{
		//IL_004e: Expected O, but got I
		//IL_0013: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<(RenderTexture, RenderTexture)> asyncTriggerHandler = (AsyncTriggerHandler<(RenderTexture, RenderTexture)>)(object)new AsyncTriggerHandler<(object, object)>((AsyncTriggerBase<(object, object)>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		if (asyncTriggerHandler != null)
		{
			object obj = default(object);
			UniTask<(RenderTexture, RenderTexture)> uniTask = ((IAsyncOnRenderImageHandler)(&obj)).OnRenderImageAsync();
			AsyncRenderImageTrigger asyncRenderImageTrigger = (AsyncRenderImageTrigger)uniTask;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v6 (Cysharp.Threading.Tasks.UniTask`1<System.ValueTuple`2<UnityEngine.RenderTexture, UnityEngine.RenderTexture>>)+10]");
			_ = 0;
			return (UniTask<(RenderTexture, RenderTexture)>)this;
		}
		return (UniTask<(RenderTexture, RenderTexture)>)new NullReferenceException();
	}

	public AsyncRenderImageTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
