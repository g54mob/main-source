using System;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

namespace Cysharp.Threading.Tasks.Triggers;

public sealed class AsyncParticleUpdateJobScheduledTrigger : AsyncTriggerBase<ParticleSystemJobData>
{
	private unsafe void OnParticleUpdateJobScheduled(ParticleSystemJobData particles)
	{
		//IL_008f: Expected O, but got Ref
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_0012: Expected O, but got I4
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0085: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemJobData particleSystemJobData = particles;
		object obj3 = default(object);
		obj = obj3;
		ParticleSystemJobData particleSystemJobData2 = default(ParticleSystemJobData);
		particleSystemJobData = particleSystemJobData2;
		do
		{
			obj += 128;
			particleSystemJobData = (ParticleSystemJobData)(particleSystemJobData + 128);
			_ = particleSystemJobData._003Ccount_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)-60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)-30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)-20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)-10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999316D]");
		}
		while ((nint)0 != 0);
		obj = particleSystemJobData._003Ccount_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)+40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rbx_v2 (UnityEngine.ParticleSystemJobs.ParticleSystemJobData)+70]");
		_ = 0;
		TriggerEvent<ParticleSystemJobData> triggerEvent = (TriggerEvent<ParticleSystemJobData>)(this + 32);
		((TriggerEvent<ParticleSystemJobData>*)triggerEvent)->SetResult((ParticleSystemJobData)(&obj2));
	}

	public IAsyncOnParticleUpdateJobScheduledHandler GetOnParticleUpdateJobScheduledAsyncHandler()
	{
		AsyncTriggerHandler<ParticleSystemJobData> result = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4BB0");
		return result;
	}

	public IAsyncOnParticleUpdateJobScheduledHandler GetOnParticleUpdateJobScheduledAsyncHandler(CancellationToken cancellationToken)
	{
		return new AsyncTriggerHandler<ParticleSystemJobData>(this, cancellationToken, callOnce: false);
	}

	public UniTask<ParticleSystemJobData> OnParticleUpdateJobScheduledAsync()
	{
		//IL_001d: Expected O, but got I
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_00f7: Expected O, but got I4
		AsyncTriggerHandler<ParticleSystemJobData> asyncTriggerHandler = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F4BB0");
		bool flag = asyncTriggerHandler == null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F5AD0");
			AsyncParticleUpdateJobScheduledTrigger asyncParticleUpdateJobScheduledTrigger = this;
			IntPtr intPtr = default(IntPtr);
			asyncParticleUpdateJobScheduledTrigger = (AsyncParticleUpdateJobScheduledTrigger)(nint)intPtr;
			object obj2 = default(object);
			object obj = obj2;
			object obj3;
			do
			{
				asyncParticleUpdateJobScheduledTrigger = (AsyncParticleUpdateJobScheduledTrigger)(asyncParticleUpdateJobScheduledTrigger + 128);
				obj += 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6-50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6-10]");
				_ = 0;
				obj3 = !flag;
			}
			while (obj3 != null);
			asyncParticleUpdateJobScheduledTrigger = (AsyncParticleUpdateJobScheduledTrigger)obj;
			return (UniTask<ParticleSystemJobData>)this;
		}
		return (UniTask<ParticleSystemJobData>)new NullReferenceException();
	}

	public UniTask<ParticleSystemJobData> OnParticleUpdateJobScheduledAsync(CancellationToken cancellationToken)
	{
		//IL_0055: Expected O, but got I
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00ff: Expected O, but got I4
		IntPtr intPtr = default(IntPtr);
		AsyncTriggerHandler<ParticleSystemJobData> asyncTriggerHandler = new AsyncTriggerHandler<ParticleSystemJobData>((AsyncTriggerBase<ParticleSystemJobData>)cancellationToken, (CancellationToken)(nint)intPtr, callOnce: true);
		bool flag = asyncTriggerHandler == null;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F5AD0");
			AsyncParticleUpdateJobScheduledTrigger asyncParticleUpdateJobScheduledTrigger = this;
			asyncParticleUpdateJobScheduledTrigger = (AsyncParticleUpdateJobScheduledTrigger)cancellationToken;
			object obj2 = default(object);
			object obj = obj2;
			object obj3;
			do
			{
				asyncParticleUpdateJobScheduledTrigger = (AsyncParticleUpdateJobScheduledTrigger)(asyncParticleUpdateJobScheduledTrigger + 128);
				obj += 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v6+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v6-60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v6-50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v6-40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v6-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v6-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v6-10]");
				_ = 0;
				obj3 = !flag;
			}
			while (obj3 != null);
			asyncParticleUpdateJobScheduledTrigger = (AsyncParticleUpdateJobScheduledTrigger)obj;
			return (UniTask<ParticleSystemJobData>)this;
		}
		return (UniTask<ParticleSystemJobData>)new NullReferenceException();
	}

	public AsyncParticleUpdateJobScheduledTrigger()
	{
		//IL_001a: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
