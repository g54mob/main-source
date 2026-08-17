using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.CompilerServices;
using Cysharp.Threading.Tasks.Internal;

namespace Cysharp.Threading.Tasks;

public static class UniTaskObservableExtensions
{
	private class ToUniTaskObserver<T> : IObserver<T>
	{
		private static readonly Action<object> callback;

		private readonly UniTaskCompletionSource<T> promise;

		private readonly SingleAssignmentDisposable disposable;

		private readonly CancellationToken cancellationToken;

		private readonly CancellationTokenRegistration registration;

		private bool hasValue;

		private T latestValue;

		public ToUniTaskObserver(UniTaskCompletionSource<T> promise, SingleAssignmentDisposable disposable, CancellationToken cancellationToken)
		{
			//IL_0250: Expected O, but got I
			//IL_0260: Expected O, but got I
			//IL_0270: Expected O, but got I
			//IL_0280: Expected O, but got I
			//IL_0290: Expected O, but got I
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Expected O, but got Unknown
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Expected O, but got Unknown
			//IL_02e0: Expected O, but got I
			//IL_02f0: Expected O, but got I
			//IL_0300: Expected O, but got I
			//IL_0310: Expected O, but got I
			//IL_0320: Expected O, but got I
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Expected O, but got Unknown
			//IL_033b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Expected O, but got Unknown
			//IL_0370: Expected O, but got I
			//IL_0380: Expected O, but got I
			//IL_0390: Expected O, but got I
			//IL_03a0: Expected O, but got I
			//IL_03b0: Expected O, but got I
			//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Expected O, but got Unknown
			//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Expected O, but got Unknown
			//IL_001a: Expected O, but got I
			//IL_002a: Expected O, but got I
			//IL_003a: Expected O, but got I
			//IL_004a: Expected O, but got I
			//IL_005a: Expected O, but got I
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_00bc: Expected O, but got I
			//IL_00cc: Expected O, but got I
			//IL_00dc: Expected O, but got I
			//IL_00ec: Expected O, but got I
			//IL_00fc: Expected O, but got I
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_0163: Expected O, but got I
			//IL_0173: Expected O, but got I
			//IL_0183: Expected O, but got I
			//IL_0198: Expected O, but got I
			//IL_01bf: Expected O, but got I
			//IL_01cf: Expected O, but got I
			//IL_01df: Expected O, but got I
			//IL_01ef: Expected O, but got I
			//IL_01ff: Expected O, but got I
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Expected O, but got Unknown
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v2+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v2+8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v3+30]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v3+38]");
			object obj6 = 0 + this;
			object obj7 = obj6 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v4+28]");
			if ((nint)0 < (nint)0)
			{
				obj7 = promise;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v6+C0]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v5+8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v7+80]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v6+50]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v6+58]");
			object obj13 = 0 + this;
			object obj14 = obj13 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v8+28]");
			if ((nint)0 < (nint)0)
			{
				obj14 = disposable;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v10+C0]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v8+8]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v11+80]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v9+70]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v9+78]");
			object obj20 = 0 + this;
			object obj21 = obj20 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v12+28]");
			object obj28 = default(object);
			if ((nint)0 < (nint)0)
			{
				obj21 = cancellationToken;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v15+C0]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v12+8]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v16+80]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rcx_v13+70]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rcx_v13+78]");
				object obj27 = 0 + this;
				obj28 = obj27 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v17+28]");
				if ((nint)0 >= (nint)0)
				{
					obj28 = obj27;
				}
			}
			if ((nint)obj28 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
				object obj29 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rax_v19+C0]");
				object obj30 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ rcx_v17+8]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rax_v20+80]");
				object obj32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rcx_v18+70]");
				object obj33 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rcx_v18+78]");
				object obj34 = 0 + this;
				object obj35 = obj34 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v21+28]");
				if ((nint)0 >= (nint)0)
				{
					obj35 = obj34;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
				object obj36 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rax_v26+C0]");
				object obj37 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ rcx_v22+10]");
				object obj38 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rax_v28+B8]");
				object obj39 = 0;
				CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)obj35, (Action<object>)obj39, this);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
				object obj40 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v32+C0]");
				object obj41 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rcx_v26+8]");
				object obj42 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rax_v33+80]");
				object obj43 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rcx_v27+90]");
				object obj44 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rcx_v27+98]");
				object obj45 = 0 + this;
				object obj46 = obj45 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rax_v34+28]");
				if ((nint)0 < (nint)0)
				{
					obj46 = cancellationTokenRegistration.m_callbackInfo;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v31 (System.Threading.CancellationTokenRegistration)+10]");
					_ = 0;
				}
			}
		}

		private static void OnCanceled(object state)
		{
			//IL_001b: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_00c6: Expected O, but got I
			//IL_00d6: Expected O, but got I
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_0028: Expected I, but got O
			//IL_0038: Expected O, but got I
			//IL_014f: Expected O, but got I
			//IL_015f: Expected O, but got I
			//IL_016f: Expected O, but got I
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Expected O, but got Unknown
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_0074: Expected O, but got I
			//IL_01da: Expected O, but got I
			//IL_01ea: Expected O, but got I
			//IL_01fa: Expected O, but got I
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Expected O, but got Unknown
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Expected O, but got Unknown
			//IL_026a: Expected O, but got I
			//IL_028d: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+8]");
			object obj = 0;
			if (state != null)
			{
				nint num2 = (nint)state;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v9 (Il2CppClass<System.Object>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v9 (Il2CppClass<System.Object>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v35+FFFFFFF8+v56 @ rax_v32*8]");
					if (0 == (nint)obj)
					{
						goto IL_00a0;
					}
				}
				goto IL_0297;
			}
			goto IL_00a0;
			IL_00a0:
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v6+80]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v4+50]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v4+58]");
			object obj7 = 0 + state;
			object obj8 = obj7 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v11+28]");
			if ((nint)0 >= (nint)0)
			{
				obj8 = obj7;
			}
			((SingleAssignmentDisposable)obj8).Dispose();
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v15 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rcx_v11+80]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v6+30]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v6+38]");
			object obj12 = 0 + state;
			object obj13 = obj12 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v16+28]");
			if ((nint)0 >= (nint)0)
			{
				obj13 = obj12;
			}
			object obj14 = obj13;
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+8]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rcx_v15+80]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v7+70]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v7+78]");
			object obj18 = 0 + state;
			object obj19 = obj18 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v20+28]");
			if ((nint)0 >= (nint)0)
			{
				obj19 = obj18;
			}
			object obj20 = obj19;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rax_v23 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+18]");
			object obj21 = 0;
			object obj22 = obj21;
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ r8_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+18]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v319 @ rsi_v1 (should have been resolved before IL gen)");
			goto IL_0297;
			IL_0297:
			throw new InvalidCastException();
		}

		public unsafe void OnNext(T value)
		{
			//IL_0008: Expected O, but got Ref
			//IL_0023: Expected O, but got I
			//IL_0039: Expected O, but got I
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_0101: Expected O, but got I
			//IL_0111: Expected O, but got I
			//IL_0121: Expected O, but got I
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Expected O, but got Unknown
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_016a: Expected O, but got I4
			//IL_006a: Expected O, but got I8
			//IL_007d: Expected O, but got Ref
			//IL_0093: Expected O, but got I
			//IL_00a9: Expected O, but got I
			//IL_018f: Expected O, but got I
			//IL_01a5: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rax_v2+FC]");
			object obj4 = (nint)0 + (nint)15;
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rax_v2+FC]");
			if ((nint)obj5 <= 0)
			{
				obj4 = 1152921504606846960L;
			}
			object obj6 = obj4 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v6+80]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v2+B0]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v2+B8]");
			object obj10 = 0 + this;
			object obj11 = obj10 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v7+28]");
			if ((nint)0 >= (nint)0)
			{
			}
			obj11 = 1;
			T val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+20]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v10+28]");
			object obj13 = (nint)0 >> 31;
			if (obj13 != null)
			{
				val = value;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v13+80]");
			object obj15 = (nint)0 + (nint)192;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
		}

		public void OnError(Exception error)
		{
			//IL_0010: Expected O, but got I
			//IL_0020: Expected O, but got I
			//IL_0030: Expected O, but got I
			//IL_0040: Expected O, but got I
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0065: Expected O, but got I
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			//IL_00b5: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_00d5: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_00f5: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ stack_18_v2+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rax_v3+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ rcx_v1+8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v4+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rdx_v1+38]");
			object obj6 = default(object);
			object obj5 = 0 + obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rdx_v1+30]");
			object obj7 = 0;
			object obj8 = obj5 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rax_v5+28]");
			if ((nint)0 >= (nint)0)
			{
				obj8 = obj5;
			}
			object obj9 = obj8;
			if (obj8 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ stack_18_v2+20]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v22+C0]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v7+28]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ stack_18_v2+20]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v24+C0]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v51 @ rax_v23] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E65410");
				return;
			}
			throw new NullReferenceException();
		}

		public unsafe void OnCompleted()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0251: Expected O, but got I
			//IL_0267: Expected O, but got I
			//IL_0494: Unknown result type (might be due to invalid IL or missing references)
			//IL_0499: Expected O, but got Unknown
			//IL_04ab: Expected O, but got Ref
			//IL_04b9: Expected O, but got Ref
			//IL_04cc: Expected O, but got Ref
			//IL_04f4: Expected O, but got I
			//IL_0504: Expected O, but got I
			//IL_0514: Expected O, but got I
			//IL_0524: Expected O, but got I
			//IL_0534: Expected O, but got I
			//IL_0551: Expected O, but got I
			//IL_0561: Expected O, but got I
			//IL_056a: Unknown result type (might be due to invalid IL or missing references)
			//IL_056f: Expected O, but got Unknown
			//IL_029b: Expected O, but got I
			//IL_02ab: Expected O, but got I
			//IL_02bb: Expected O, but got I
			//IL_02cb: Expected O, but got I
			//IL_02db: Expected O, but got I
			//IL_001a: Expected O, but got I8
			//IL_0155: Expected O, but got I
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Expected O, but got Unknown
			//IL_0354: Expected O, but got I
			//IL_0364: Expected O, but got I
			//IL_0374: Expected O, but got I
			//IL_0384: Expected O, but got I
			//IL_03a1: Expected O, but got I
			//IL_03b1: Expected O, but got I
			//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bf: Expected O, but got Unknown
			//IL_0049: Expected O, but got I
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_05b5: Expected O, but got Ref
			//IL_031c: Expected I4, but got I8
			//IL_01b2: Expected O, but got I
			//IL_01c2: Expected O, but got I
			//IL_01d2: Expected O, but got I
			//IL_01e2: Expected O, but got I
			//IL_01f8: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_00a9: Expected O, but got I
			//IL_00b9: Expected O, but got I
			//IL_00c9: Expected O, but got I
			//IL_00d9: Expected O, but got I
			//IL_00e9: Expected O, but got I
			//IL_0101: Expected O, but got Ref
			//IL_0404: Expected O, but got I
			//IL_0414: Expected O, but got I
			//IL_0424: Expected O, but got I
			//IL_0437: Expected O, but got Ref
			//IL_044f: Expected O, but got Ref
			//IL_0228: Expected I, but got O
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3+FC]");
			object obj4 = (nint)0 + (nint)15;
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v3+FC]");
			if ((nint)obj5 <= 0)
			{
				obj4 = 1152921504606846960L;
			}
			object obj6 = obj4 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			SystemException ex = (SystemException)(&obj2);
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+68]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r8_v1+20]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v8+C0]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v6+8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v9+80]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v7+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
			object obj14 = num2 + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v7+B0]");
			object obj15 = 0;
			object obj16 = obj14 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10+28]");
			if ((nint)0 >= (nint)0)
			{
				obj16 = obj14;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r8_v1+20]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v11+C0]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v10+8]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v12+80]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v11+30]");
			object obj21 = 0;
			if (obj16 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v11+38]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
				object obj22 = num3 + 0;
				object obj23 = obj22 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v13+28]");
				if ((nint)0 >= (nint)0)
				{
					obj23 = obj22;
				}
				InvalidOperationException ex2 = (InvalidOperationException)new SystemException("Sequence has no elements");
				((Exception)ex2)._HResult = -2146233079;
				if (obj23 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+68]");
					object obj24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r9_v8+20]");
					object obj25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v35+C0]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ r8_v11+28]");
					object obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r9_v8+20]");
					object obj28 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v37+C0]");
					object obj29 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v202 @ rax_v36] (should have been resolved before IL gen)");
					object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E65410");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
					if ((nint)0 == 0)
					{
						return;
					}
					throw null;
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v11+38]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
			object obj31 = num4 + 0;
			object obj32 = obj31 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v13+28]");
			if ((nint)0 >= (nint)0)
			{
				obj32 = obj31;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r8_v1+20]");
			object obj33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v20+C0]");
			object obj34 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v17+8]");
			object obj35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v21+80]");
			object obj36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v18+D8]");
			object obj37 = num5 + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v18+D0]");
			object obj38 = 0;
			object obj39 = obj37 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v23+28]");
			if ((nint)0 >= (nint)0)
			{
				obj39 = obj37;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			bool flag = obj32 == null;
			SystemException ex3 = (SystemException)(&obj2);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+68]");
				object obj40 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ r8_v6+20]");
				object obj41 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v25+C0]");
				object obj42 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rcx_v20+20]");
				object obj43 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v26+28]");
				object obj44 = (nint)0 >> 31;
				bool flag2 = obj44 != null;
				nint num6 = (nint)(&obj2);
				if (!flag2)
				{
					num6 = (nint)ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ r8_v6+20]");
				object obj45 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v27+C0]");
				object obj46 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v23+30]");
				object obj47 = 0;
				object obj48 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v311 @ rdx_v11+10] (should have been resolved before IL gen)");
				object obj49 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183E65410");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
				if ((nint)0 == 0)
				{
					return;
				}
				throw ex3;
			}
			throw new NullReferenceException();
		}

		static ToUniTaskObserver()
		{
			//IL_003c: Expected O, but got I
			//IL_0051: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+38]");
			Action<object> action = new Action<object>(null, (IntPtr)0);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+38]");
			action._002Ector((object)null, (IntPtr)0);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+ToUniTaskObserver`1>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10+B8]");
			object obj2 = 0;
			obj2 = action;
		}
	}

	private class FirstValueToUniTaskObserver<T> : IObserver<T>
	{
		private static readonly Action<object> callback;

		private readonly UniTaskCompletionSource<T> promise;

		private readonly SingleAssignmentDisposable disposable;

		private readonly CancellationToken cancellationToken;

		private readonly CancellationTokenRegistration registration;

		private bool hasValue;

		public FirstValueToUniTaskObserver(UniTaskCompletionSource<T> promise, SingleAssignmentDisposable disposable, CancellationToken cancellationToken)
		{
			//IL_004c: Expected O, but got I
			//IL_005c: Expected O, but got I
			//IL_006c: Expected O, but got I
			//IL_0081: Expected O, but got I
			//IL_009c: Expected O, but got I
			this.promise = promise;
			this.disposable = disposable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1<T>)+20]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_28+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v369 @ rax_v12+C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rcx_v10+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rax_v14+B8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1<T>)+20]");
				_ = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext((CancellationToken)0, (Action<object>)obj4, this).m_callbackInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v17 (System.Threading.CancellationTokenRegistration)+10]");
				_ = 0;
			}
		}

		private static void OnCanceled(object state)
		{
			//IL_001b: Expected O, but got I
			//IL_0045: Expected I, but got O
			//IL_0055: Expected O, but got I
			//IL_0091: Expected O, but got I
			//IL_00ee: Expected O, but got I
			//IL_012e: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+8]");
			object obj = 0;
			if (state == null)
			{
				goto IL_0143;
			}
			nint num2 = (nint)state;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v5+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v3 (Il2CppClass<System.Object>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v5+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r8_v3 (Il2CppClass<System.Object>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v7+FFFFFFF8+v56 @ rcx_v6*8]");
				if (0 == (nint)obj)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [state @ rcx (System.Object)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [state @ rcx (System.Object)+18]");
						((SingleAssignmentDisposable)0).Dispose();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [state @ rcx (System.Object)+10]");
						if ((nint)0 != 0)
						{
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v13 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+18]");
							object obj4 = 0;
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v199 @ rcx_v10] (should have been resolved before IL gen)");
						}
					}
					goto IL_0143;
				}
			}
			goto IL_0152;
			IL_0152:
			throw new InvalidCastException();
			IL_0143:
			NullReferenceException ex = new NullReferenceException();
			goto IL_0152;
		}

		public unsafe void OnNext(T value)
		{
			//IL_0008: Expected O, but got Ref
			//IL_001e: Expected O, but got I
			//IL_0034: Expected O, but got I
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_015f: Expected O, but got Ref
			//IL_0179: Expected O, but got Ref
			//IL_018e: Expected O, but got I
			//IL_01a4: Expected O, but got I
			//IL_01ba: Expected O, but got I
			//IL_01c8: Expected O, but got Ref
			//IL_020e: Expected O, but got Ref
			//IL_0065: Expected O, but got I8
			//IL_008d: Expected O, but got I
			//IL_00a3: Expected O, but got I
			//IL_0242: Expected O, but got I
			//IL_0255: Expected O, but got Ref
			//IL_0275: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_00e9: Expected O, but got I
			//IL_00d3: Expected I, but got O
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ rax_v2+FC]");
			object obj4 = (nint)0 + (nint)15;
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ rax_v2+FC]");
			if ((nint)obj5 <= 0)
			{
				obj4 = 1152921504606846960L;
			}
			object obj6 = obj4 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			SingleAssignmentDisposable singleAssignmentDisposable = (SingleAssignmentDisposable)(&obj2);
			_ = 1;
			_ = 0;
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+50]");
			object obj8 = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+20]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v8+28]");
			object obj10 = (nint)0 >> 31;
			T val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
			if (obj10 != null)
			{
				val = value;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v6+10]");
			bool flag = (nint)0 == 0;
			SingleAssignmentDisposable singleAssignmentDisposable2 = (SingleAssignmentDisposable)(&obj2);
			if (!flag)
			{
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+20]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v19+28]");
				object obj12 = (nint)0 >> 31;
				bool flag2 = obj12 != null;
				nint num4 = (nint)(&obj2);
				if (!flag2)
				{
					num4 = (nint)singleAssignmentDisposable;
				}
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v13 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+28]");
				object obj13 = 0;
				object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v141 @ rdx_v6+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+50]");
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)((nint)0 + (nint)40);
				((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+50]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v24+18]");
				((SingleAssignmentDisposable)0).Dispose();
				return;
			}
			throw new NullReferenceException();
		}

		public unsafe void OnError(Exception error)
		{
			//IL_003b: Expected O, but got I
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Expected O, but got Unknown
			//IL_0078: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ stack_8_v2+10]");
			if ((nint)0 != 0)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rdx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+30]");
				object obj = 0;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v23 @ rax_v7] (should have been resolved before IL gen)");
				object obj2 = default(object);
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(obj2 + 40);
				((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ stack_8_v2+18]");
				((SingleAssignmentDisposable)0).Dispose();
				return;
			}
			throw new NullReferenceException();
		}

		public unsafe void OnCompleted()
		{
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_0094: Expected O, but got I
			//IL_002b: Expected I4, but got I8
			//IL_0066: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2+40]");
			bool flag = (nint)0 != 0;
			object obj2 = default(object);
			object obj = obj2;
			if (!flag)
			{
				InvalidOperationException ex = (InvalidOperationException)new SystemException("Sequence has no elements");
				((Exception)ex)._HResult = -2146233079;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2+10]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+30]");
				object obj3 = 0;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ rax_v14] (should have been resolved before IL gen)");
				obj = obj2;
			}
			CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(obj + 40);
			((CancellationTokenRegistration*)cancellationTokenRegistration)->Dispose();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ stack_8_v2+18]");
			((SingleAssignmentDisposable)0).Dispose();
		}

		static FirstValueToUniTaskObserver()
		{
			//IL_003c: Expected O, but got I
			//IL_0051: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+38]");
			Action<object> action = new Action<object>(null, (IntPtr)0);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+38]");
			action._002Ector((object)null, (IntPtr)0);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+FirstValueToUniTaskObserver`1>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10+B8]");
			object obj2 = 0;
			obj2 = action;
		}
	}

	private class ReturnObservable<T>(T value) : IObservable<T>
	{
		private readonly T value = value;

		public IDisposable Subscribe(IObserver<T> observer)
		{
			if (observer != null)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805BF990");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				return EmptyDisposable.Instance;
			}
			return (IDisposable)new NullReferenceException();
		}
	}

	private class ThrowObservable<T>(Exception value) : IObservable<T>
	{
		private readonly Exception value = value;

		public IDisposable Subscribe(IObserver<T> observer)
		{
			if (observer != null)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				return EmptyDisposable.Instance;
			}
			return (IDisposable)new NullReferenceException();
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CFire_003Ed__3<T> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public UniTask<T> task;

		public AsyncSubject<T> subject;

		private UniTask<T>.Awaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0023: Expected O, but got I
			//IL_004b: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_087b: Expected O, but got Ref
			//IL_0891: Expected O, but got I
			//IL_009e: Expected O, but got I
			//IL_00b0: Expected O, but got Ref
			//IL_00c0: Expected O, but got I
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			//IL_08d0: Expected O, but got I
			//IL_091e: Expected O, but got I
			//IL_095c: Expected O, but got I
			//IL_0314: Expected O, but got I
			//IL_0326: Expected O, but got Ref
			//IL_0336: Expected O, but got I
			//IL_033f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Expected O, but got Unknown
			//IL_0123: Expected O, but got I
			//IL_0135: Expected O, but got Ref
			//IL_0145: Expected O, but got I
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Expected O, but got Unknown
			//IL_038c: Expected O, but got I
			//IL_03a7: Expected O, but got I
			//IL_03af: Expected O, but got Ref
			//IL_03c9: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_01b5: Expected O, but got Ref
			//IL_01c5: Expected O, but got I
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Expected O, but got Unknown
			//IL_03ee: Expected O, but got I
			//IL_0223: Expected O, but got I
			//IL_0235: Expected O, but got Ref
			//IL_0245: Expected O, but got I
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Expected O, but got Unknown
			//IL_09c6: Expected O, but got I8
			//IL_0436: Expected O, but got I
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Expected O, but got Unknown
			//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Expected O, but got Unknown
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cf: Expected O, but got Unknown
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Expected O, but got Unknown
			//IL_06c0: Expected O, but got I
			//IL_0451: Expected O, but got I
			//IL_0464: Expected O, but got Ref
			//IL_0aa0: Expected O, but got I4
			//IL_0ab0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ab5: Expected O, but got Unknown
			//IL_06e5: Expected O, but got I
			//IL_049b: Expected O, but got I
			//IL_04ad: Expected O, but got Ref
			//IL_04bd: Expected O, but got I
			//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cb: Expected O, but got Unknown
			//IL_0713: Expected O, but got I
			//IL_0725: Expected O, but got Ref
			//IL_0735: Expected O, but got I
			//IL_073e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0743: Expected O, but got Unknown
			//IL_0518: Expected O, but got I
			//IL_052e: Expected O, but got I
			//IL_0548: Expected O, but got Ref
			//IL_0579: Expected O, but got I
			//IL_0594: Expected O, but got I
			//IL_05a7: Expected O, but got Ref
			//IL_05d4: Expected O, but got I
			//IL_05e6: Expected O, but got Ref
			//IL_05f6: Expected O, but got I
			//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0604: Expected O, but got Unknown
			//IL_0651: Expected O, but got I
			//IL_0793: Expected O, but got I
			//IL_07a5: Expected O, but got Ref
			//IL_07b5: Expected O, but got I
			//IL_07be: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c3: Expected O, but got Unknown
			//IL_0a7e: Expected O, but got I8
			//IL_0806: Expected O, but got I
			//IL_0818: Expected O, but got Ref
			//IL_0828: Expected O, but got I
			//IL_0831: Unknown result type (might be due to invalid IL or missing references)
			//IL_0836: Expected O, but got Unknown
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+58]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
			_ = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+20]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
			object obj5 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
			object obj6 = default(object);
			if ((nint)obj5 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				obj6 = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
				object obj7 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
				if ((nint)obj7 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
				object obj8 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
				if ((nint)obj8 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				_ = ref obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
				object obj9 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
				if ((nint)obj9 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				_ = ref obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B8]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
				_ = 0;
			}
			nint num3 = 0;
			IntPtr intPtr = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rcx_v8 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v4+18]");
			object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v4+10]");
			object obj13 = 0;
			object obj14 = obj12 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v29+28]");
			if ((nint)0 >= (nint)0)
			{
				obj14 = obj12;
			}
			if (obj14 == null)
			{
				nint num4 = 0;
				IntPtr intPtr2 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v103 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ r9_v12+98]");
				object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ r9_v12+90]");
				object obj17 = 0;
				object obj18 = obj16 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v154+28]");
				if ((nint)0 >= (nint)0)
				{
					obj18 = obj16;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				nint num5 = 0;
				IntPtr intPtr3 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rcx_v109 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdx_v34+98]");
				object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdx_v34+90]");
				object obj21 = 0;
				object obj22 = obj20 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v160+28]");
				if ((nint)0 >= (nint)0)
				{
					obj22 = obj20;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
				nint num6 = 0;
				IntPtr intPtr4 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rcx_v113 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v36+18]");
				object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v36+10]");
				object obj25 = 0;
				object obj26 = obj24 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v165+28]");
				if ((nint)0 >= (nint)0)
				{
					obj26 = obj24;
				}
				obj26 = 4294967295L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				if ((nint)0 != 0)
				{
					object obj27 = obj26 >> 12;
					object obj28 = obj27 & 0x1FFFFF;
					object obj29 = obj28 >> 6;
					object obj30 = obj29 * 8;
					object obj31 = 6603577472L + obj30;
					object obj32 = obj28 & 0x3F;
					nint num8;
					do
					{
						object obj33 = 1 << (int)obj32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ r8_v36+462E0]");
						object obj34 = 0 | obj33;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ r8_v36+462E0]");
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ r8_v36+462E0]");
						if (num7 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ r8_v36+462E0]");
						num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ r8_v36+462E0]");
					}
					while (num8 != 0);
				}
			}
			else
			{
				nint num9 = 0;
				IntPtr intPtr5 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v66 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
				object obj35 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v20+58]");
				object obj36 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v20+50]");
				object obj37 = 0;
				object obj38 = obj36 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v105+28]");
				if ((nint)0 >= (nint)0)
				{
					obj38 = obj36;
				}
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v108 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+10]");
				object obj39 = 0;
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v111 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+10]");
				object obj40 = 0;
				obj = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v295 @ rbx_v12+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B8]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v117 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+28]");
				object obj41 = 0;
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v375 @ rcx_v75] (should have been resolved before IL gen)");
				object obj42 = default(object);
				if (obj42 == null)
				{
					nint num14 = 0;
					IntPtr intPtr6 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1A60");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					nint num15 = 0;
					IntPtr intPtr7 = num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rcx_v82 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
					object obj43 = --128;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rax_v133 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+38]");
					object obj44 = 0;
					nint num17 = 0;
					nint num18 = 0;
					IntPtr intPtr8 = num18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rcx_v88 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
					object obj45 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdx_v29+38]");
					object obj46 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdx_v29+30]");
					object obj47 = 0;
					object obj48 = obj46 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ rax_v140+28]");
					if ((nint)0 >= (nint)0)
					{
						obj48 = obj46;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v675 @ rcx_v85] (should have been resolved before IL gen)");
					return;
				}
			}
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rax_v34 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+50]");
			object obj49 = 0;
			nint num20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rax_v37 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+50]");
			object obj50 = 0;
			_ = ref obj2;
			object obj51 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v547 @ rbx_v4+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num21 = 0;
			IntPtr intPtr9 = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ rcx_v18 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
			object obj52 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ r8_v8+78]");
			object obj53 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v637 @ r8_v8+70]");
			object obj54 = 0;
			object obj55 = obj53 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v44+28]");
			if ((nint)0 >= (nint)0)
			{
				obj55 = obj53;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			if (obj55 != null)
			{
				nint num22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ rax_v51 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+58]");
				object obj56 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ rcx_v24+28]");
				object obj57 = (nint)0 >> 31;
				bool flag = obj57 != null;
				object obj58 = (object)(&obj2);
				if (!flag)
				{
					obj58 = obj6;
				}
				nint num23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v878 @ rax_v56 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+70]");
				object obj59 = 0;
				nint num24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v920 @ rax_v59 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+70]");
				object obj60 = 0;
				object obj61 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v879 @ rbx_v7+10] (should have been resolved before IL gen)");
				nint num25 = 0;
				IntPtr intPtr10 = num25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v942 @ rcx_v30 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
				object obj62 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ rdx_v12+78]");
				object obj63 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ rdx_v12+70]");
				object obj64 = 0;
				object obj65 = obj63 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v944 @ rax_v65+28]");
				if ((nint)0 >= (nint)0)
				{
					obj65 = obj63;
				}
				nint num26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v972 @ rax_v69 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>)+78]");
				object obj66 = 0;
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v973 @ rcx_v34] (should have been resolved before IL gen)");
				nint num28 = 0;
				IntPtr intPtr11 = num28;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1007 @ rcx_v38 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
				object obj67 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1008 @ rdx_v14+18]");
				object obj68 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1008 @ rdx_v14+10]");
				object obj69 = 0;
				object obj70 = obj68 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v77+28]");
				if ((nint)0 < (nint)0)
				{
					obj70 = 4294967294L;
				}
				nint num29 = 0;
				IntPtr intPtr12 = num29;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1106 @ rcx_v43 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1>>)+80]");
				object obj71 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v16+38]");
				object obj72 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v16+30]");
				object obj73 = 0;
				object obj74 = obj72 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1108 @ rax_v82+28]");
				if ((nint)0 >= (nint)0)
				{
					obj74 = obj72;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844336B0");
				return;
			}
			throw new NullReferenceException();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 9 Invalid \"Jump target not found in method: 0x180AC0570\"");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CFire_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public UniTask task;

		public AsyncSubject<AsyncUnit> subject;

		private UniTask.Awaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0030: Expected O, but got I4
			//IL_003f: Expected I4, but got I8
			//IL_0118: Expected I4, but got I8
			//IL_0123: Expected O, but got Ref
			//IL_012e: Expected O, but got I
			//IL_00b8: Expected O, but got Ref
			UniTask.Awaiter awaiter;
			if (_003C_003E1__state == 0)
			{
				awaiter = _003C_003Eu__1;
				_003C_003Eu__1 = (UniTask.Awaiter)0;
				_003C_003E1__state = -1;
			}
			else
			{
				bool flag = (object)task == null;
				awaiter = (UniTask.Awaiter)task;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw r9d,xmm6,4\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
					object obj = default(object);
					bool flag2 = obj != null;
					awaiter = (UniTask.Awaiter)task;
					if (!flag2)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = (UniTask.Awaiter)task;
						AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						UniTask.Awaiter awaiter2 = default(UniTask.Awaiter);
						((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
						return;
					}
				}
			}
			if ((object)awaiter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm7,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
			}
			subject.OnNext(AsyncUnit.Default);
			subject.OnCompleted();
			_003C_003E1__state = -2;
			AsyncSubject<AsyncUnit> asyncSubject = (AsyncSubject<AsyncUnit>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			asyncSubject.OnNext((AsyncUnit)0);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public unsafe static UniTask<T> ToUniTask<T>(IObservable<T> source, bool useFirstValue = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0008: Expected O, but got Ref
		//IL_001d: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_009c: Expected O, but got I
		//IL_00bf: Expected O, but got I
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_0239: Expected O, but got I
		//IL_0112: Expected O, but got I
		//IL_0122: Expected O, but got I
		//IL_00f0: Expected O, but got I8
		//IL_014f: Expected O, but got I
		//IL_01b9: Expected O, but got I
		//IL_01c9: Expected O, but got I
		//IL_0182: Expected O, but got I
		//IL_0192: Expected O, but got I
		//IL_01e6: Expected O, but got I
		//IL_0298: Expected O, but got I
		//IL_02a8: Expected O, but got I
		//IL_02bb: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+90]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v2+58]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v2+FC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v2+FC]");
		object obj6 = (nint)0 + (nint)15;
		object obj7 = obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v2+FC]");
		if ((nint)obj7 <= 0)
		{
			obj6 = 1152921504606846960L;
		}
		object obj8 = obj6 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
		object obj9 = 0;
		object obj10 = null;
		obj = obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v8+8]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v118 @ rdx_v1] (should have been resolved before IL gen)");
		SingleAssignmentDisposable singleAssignmentDisposable = new SingleAssignmentDisposable();
		object gate = new object();
		singleAssignmentDisposable.gate = gate;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
		object obj13 = 0;
		if (useFirstValue)
		{
			object obj14 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rax_v38+28]");
			object obj16 = 0;
			object obj17 = obj14;
		}
		else
		{
			object obj18 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v33+18]");
			object obj16 = 0;
			object obj17 = obj18;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v261 @ rcx_v14] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+70]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BDF0");
			IDisposable disposable = default(IDisposable);
			singleAssignmentDisposable.Disposable = disposable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rdi_v1+38]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rax_v25+50]");
			object obj22 = 0;
			_ = ref obj2;
			object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v343 @ r10_v2+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			UniTask<T> result = default(UniTask<T>);
			return result;
		}
		return (UniTask<T>)new NullReferenceException();
	}

	public unsafe static IObservable<T> ToObservable<T>(UniTask<T> task)
	{
		//IL_0008: Expected O, but got Ref
		//IL_003a: Expected O, but got I
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_01cf: Expected O, but got Ref
		//IL_01e5: Expected O, but got I
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_0237: Expected O, but got I
		//IL_006b: Expected O, but got I8
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_028e: Expected O, but got I
		//IL_007d: Expected O, but got I8
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_008f: Expected O, but got I8
		//IL_011d: Expected O, but got Ref
		//IL_014a: Expected O, but got Ref
		//IL_00a1: Expected O, but got I8
		//IL_017a: Expected O, but got I
		//IL_0194: Expected O, but got Ref
		//IL_031d: Expected O, but got Ref
		//IL_00f5: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		nint num2 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v2 (Il2CppClass<T>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		object obj4 = obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v2 (Il2CppClass<T>)+FC]");
		if ((nint)obj4 <= 0)
		{
			obj3 = 1152921504606846960L;
		}
		object obj5 = obj3 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		object obj6 = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v1 (Il2CppClass<Cysharp.Threading.Tasks.UniTask`1<T>+Awaiter<T>>)+FC]");
		object obj7 = (nint)0 + (nint)15;
		object obj8 = obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v1 (Il2CppClass<Cysharp.Threading.Tasks.UniTask`1<T>+Awaiter<T>>)+FC]");
		if ((nint)obj8 <= 0)
		{
			obj7 = 1152921504606846960L;
		}
		object obj9 = obj7 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v1 (Il2CppClass<Cysharp.Threading.Tasks.UniTask`1<T>>)+FC]");
		object obj10 = (nint)0 + (nint)15;
		object obj11 = obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v1 (Il2CppClass<Cysharp.Threading.Tasks.UniTask`1<T>>)+FC]");
		if ((nint)obj11 <= 0)
		{
			obj10 = 1152921504606846960L;
		}
		object obj12 = obj10 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v1 (Il2CppClass<Cysharp.Threading.Tasks.UniTask`1<T>+Awaiter<T>>)+FC]");
		object obj13 = (nint)0 + (nint)15;
		object obj14 = obj13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v1 (Il2CppClass<Cysharp.Threading.Tasks.UniTask`1<T>+Awaiter<T>>)+FC]");
		if ((nint)obj14 <= 0)
		{
			obj13 = 1152921504606846960L;
		}
		object obj15 = obj13 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v145 @ rcx_v16 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		object obj16 = default(object);
		IObservable<T> result;
		if (obj16 == null)
		{
			result = null;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ r8_v9 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+70]");
			_ = 0;
			object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v227 @ r10_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		}
		else
		{
			nint num7 = 0;
			_ = ref obj2;
			object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v173 @ rdx_v6 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num8 = 0;
			_ = ref obj2;
			object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v192 @ rdx_v8 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			result = null;
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rcx_v24 (Il2CppClass<T>)+28]");
			object obj20 = (nint)0 >> 31;
			bool flag = obj20 != null;
			object obj21 = (object)(&obj2);
			if (!flag)
			{
				obj21 = obj6;
			}
			nint num10 = 0;
			object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v261 @ rdx_v9 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
		}
		return result;
	}

	public static IObservable<AsyncUnit> ToObservable(UniTask task)
	{
		if (task.source != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
			object obj = default(object);
			if (obj == null)
			{
				AsyncSubject<AsyncUnit> result = null;
				object obj2 = new object();
				_ = EmptyObserver<AsyncUnit>.Instance;
				_003CFire_003Ed__4 obj3 = default(_003CFire_003Ed__4);
				obj3.MoveNext();
				return result;
			}
		}
		if (task.source != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
		}
		ReturnObservable<AsyncUnit> result2 = null;
		_ = AsyncUnit.Default;
		return result2;
	}

	private unsafe static UniTaskVoid Fire<T>(AsyncSubject<T> subject, UniTask<T> task)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0038: Expected O, but got I
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01ed: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_0246: Expected O, but got I
		//IL_025b: Expected O, but got Ref
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0069: Expected O, but got I8
		//IL_0297: Expected O, but got I4
		//IL_02e1: Expected O, but got I
		//IL_02f1: Expected O, but got I
		//IL_0306: Expected O, but got Ref
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_00ae: Expected O, but got I
		//IL_00d3: Expected O, but got I
		//IL_00e3: Expected O, but got I
		//IL_00f8: Expected O, but got Ref
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_02b6: Expected O, but got I8
		//IL_0154: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_0179: Expected O, but got Ref
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_02cb: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v1 (Il2CppClass<Cysharp.Threading.Tasks.UniTask`1<T>>)+FC]");
		object obj3 = (nint)0 + (nint)15;
		object obj4 = obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v1 (Il2CppClass<Cysharp.Threading.Tasks.UniTask`1<T>>)+FC]");
		if ((nint)obj4 <= 0)
		{
			obj3 = 1152921504606846960L;
		}
		object obj5 = obj3 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v2 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1<T>>)+FC]");
		object obj6 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rcx_v2 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1<T>>)+FC]");
		if ((nint)obj6 <= 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v4 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1<T>>)+80]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v3+30]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v3+38]");
		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj10 = obj9 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v12+28]");
		if ((nint)0 >= (nint)0)
		{
			obj10 = obj9;
		}
		obj10 = 0;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v8 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1<T>>)+80]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v5+70]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v5+78]");
		object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj14 = obj13 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v15+28]");
		if ((nint)0 >= (nint)0)
		{
			obj14 = obj13;
		}
		obj14 = subject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rcx_v13 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1<T>>)+80]");
		object obj15 = (nint)0 + (nint)64;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v15 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1<T>>)+80]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v10+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v10+18]");
		object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj19 = obj18 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v21+28]");
		if ((nint)0 >= (nint)0)
		{
			obj19 = obj18;
		}
		obj19 = 4294967295L;
		nint num7 = 0;
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v19 (Il2CppClass<Cysharp.Threading.Tasks.UniTaskObservableExtensions+<Fire>d__3`1<T>>)+80]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ r9_v5+30]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ r9_v5+38]");
		object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj23 = obj22 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rax_v24+28]");
		if ((nint)0 >= (nint)0)
		{
			obj23 = obj22;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v353 @ r11_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		return (UniTaskVoid)0;
	}

	private static UniTaskVoid Fire(AsyncSubject<AsyncUnit> subject, UniTask task)
	{
		//IL_001a: Expected O, but got I4
		_003CFire_003Ed__4 obj = default(_003CFire_003Ed__4);
		obj.MoveNext();
		return (UniTaskVoid)0;
	}
}
