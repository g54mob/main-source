using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.CompilerServices;
using Cysharp.Threading.Tasks.Internal;
using Unity.IL2CPP.Metadata;

namespace Cysharp.Threading.Tasks;

internal sealed class WhenEachEnumerable<T>(IEnumerable<UniTask<T>> source) : IUniTaskAsyncEnumerable<WhenEachResult<T>>
{
	private sealed class Enumerator(IEnumerable<UniTask<T>> source, CancellationToken cancellationToken) : IUniTaskAsyncEnumerator<WhenEachResult<T>>, IUniTaskAsyncDisposable
	{
		[StructLayout((LayoutKind)3)]
		private struct _003CDisposeAsync_003Ed__12 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public Enumerator _003C_003E4__this;

			private UniTask.Awaiter _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_01c6: Expected O, but got I
				//IL_004d: Expected O, but got I4
				//IL_0015: Expected O, but got I
				//IL_0028: Expected O, but got I8
				//IL_023d: Expected O, but got I8
				//IL_006b: Expected O, but got I
				//IL_0205: Expected O, but got I4
				//IL_0139: Expected O, but got I
				//IL_00a9: Expected O, but got I4
				//IL_00c9: Expected O, but got I
				//IL_0255: Expected I4, but got I8
				//IL_00df: Expected O, but got Ref
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.WhenEachEnumerable`1<T>+Enumerator<T>+<DisposeAsync>d__12<T>)+18]");
				object obj = 0;
				object obj2;
				_003CDisposeAsync_003Ed__12 obj3;
				if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.WhenEachEnumerable`1<T>+Enumerator<T>+<DisposeAsync>d__12<T>)+20]");
					obj2 = 0;
					_ = 0;
					obj3 = (_003CDisposeAsync_003Ed__12)4294967295L;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdi_v1+28]");
					bool flag = (nint)0 == 0;
					obj2 = 0;
					if (flag)
					{
						goto IL_00ee;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdi_v1+28]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1842F6520");
					object obj5 = default(object);
					bool flag2 = obj5 == null;
					obj2 = 0;
					if (flag2)
					{
						obj3 = (_003CDisposeAsync_003Ed__12)0;
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v43 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<DisposeAsync>d__12>)+18]");
						object obj6 = 0;
						nint num2 = 0;
						object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v593 @ rcx_v33] (should have been resolved before IL gen)");
						return;
					}
				}
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
					object obj8 = default(object);
					object obj4 = obj8;
				}
				goto IL_00ee;
				IL_00ee:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rdi_v1+34]");
				if ((nint)0 != 2)
				{
					_ = 2;
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v17 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<DisposeAsync>d__12>)+38]");
					object obj9 = 0;
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v497 @ rcx_v12] (should have been resolved before IL gen)");
					OperationCanceledException ex = (OperationCanceledException)new SystemException("The operation was canceled.");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A5C3]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					((Exception)ex)._HResult = -2146233029;
					object obj11 = default(object);
					object obj10 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v601 @ r8_v9+188] (should have been resolved before IL gen)");
				}
				obj3 = (_003CDisposeAsync_003Ed__12)4294967294L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.WhenEachEnumerable`1<T>+Enumerator<T>+<DisposeAsync>d__12<T>)+8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
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

		[StructLayout((LayoutKind)3)]
		private struct _003CRunWhenEachTask_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public UniTask<T> task;

			public Enumerator self;

			public int length;

			private UniTask<T>.Awaiter _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_0008: Expected O, but got Ref
				//IL_0023: Expected O, but got I
				//IL_004b: Expected O, but got I
				//IL_0066: Expected O, but got I
				//IL_0089: Expected O, but got I
				//IL_0afa: Expected O, but got I
				//IL_00b5: Expected O, but got I8
				//IL_0b2b: Expected O, but got Ref
				//IL_0b41: Expected O, but got I
				//IL_0bf1: Unknown result type (might be due to invalid IL or missing references)
				//IL_0bf6: Expected O, but got Unknown
				//IL_0c1b: Expected O, but got I
				//IL_0b85: Expected O, but got I
				//IL_0c69: Expected O, but got I
				//IL_0bc4: Expected O, but got I
				//IL_00d8: Expected O, but got I
				//IL_00ea: Expected O, but got Ref
				//IL_00fa: Expected O, but got I
				//IL_0103: Unknown result type (might be due to invalid IL or missing references)
				//IL_0108: Expected O, but got Unknown
				//IL_034e: Expected O, but got I
				//IL_0360: Expected O, but got Ref
				//IL_0370: Expected O, but got I
				//IL_0379: Unknown result type (might be due to invalid IL or missing references)
				//IL_037e: Expected O, but got Unknown
				//IL_015d: Expected O, but got I
				//IL_016f: Expected O, but got Ref
				//IL_017f: Expected O, but got I
				//IL_0188: Unknown result type (might be due to invalid IL or missing references)
				//IL_018d: Expected O, but got Unknown
				//IL_03c6: Expected O, but got I
				//IL_03e1: Expected O, but got I
				//IL_03f4: Expected O, but got Ref
				//IL_01dd: Expected O, but got I
				//IL_01ef: Expected O, but got Ref
				//IL_01ff: Expected O, but got I
				//IL_0208: Unknown result type (might be due to invalid IL or missing references)
				//IL_020d: Expected O, but got Unknown
				//IL_0423: Expected O, but got I
				//IL_025d: Expected O, but got I
				//IL_026f: Expected O, but got Ref
				//IL_027f: Expected O, but got I
				//IL_0288: Unknown result type (might be due to invalid IL or missing references)
				//IL_028d: Expected O, but got Unknown
				//IL_0cfc: Expected O, but got I8
				//IL_046b: Expected O, but got I
				//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
				//IL_02db: Expected O, but got Unknown
				//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
				//IL_02f7: Expected O, but got Unknown
				//IL_0304: Unknown result type (might be due to invalid IL or missing references)
				//IL_0309: Expected O, but got Unknown
				//IL_0312: Unknown result type (might be due to invalid IL or missing references)
				//IL_0317: Expected O, but got Unknown
				//IL_068f: Expected O, but got I
				//IL_0486: Expected O, but got I
				//IL_04a1: Expected O, but got Ref
				//IL_0e0f: Expected O, but got I4
				//IL_0e1f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0e24: Expected O, but got Unknown
				//IL_06b4: Expected O, but got I
				//IL_04d8: Expected O, but got I
				//IL_04ea: Expected O, but got Ref
				//IL_04fa: Expected O, but got I
				//IL_0503: Unknown result type (might be due to invalid IL or missing references)
				//IL_0508: Expected O, but got Unknown
				//IL_06e2: Expected O, but got I
				//IL_06f4: Expected O, but got Ref
				//IL_0704: Expected O, but got I
				//IL_070d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0712: Expected O, but got Unknown
				//IL_0555: Expected O, but got I
				//IL_05a9: Expected O, but got I
				//IL_05bf: Expected O, but got I
				//IL_061d: Expected O, but got I
				//IL_062b: Expected O, but got Ref
				//IL_0762: Expected O, but got I
				//IL_0774: Expected O, but got Ref
				//IL_0784: Expected O, but got I
				//IL_078d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0792: Expected O, but got Unknown
				//IL_07dd: Expected O, but got I4
				//IL_0800: Expected O, but got I
				//IL_0812: Expected O, but got Ref
				//IL_0822: Expected O, but got I
				//IL_082b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0830: Expected O, but got Unknown
				//IL_09dc: Expected O, but got I
				//IL_09ee: Expected O, but got Ref
				//IL_09fe: Expected O, but got I
				//IL_0a07: Unknown result type (might be due to invalid IL or missing references)
				//IL_0a0c: Expected O, but got Unknown
				//IL_0ded: Expected O, but got I8
				//IL_0885: Expected O, but got I
				//IL_0897: Expected O, but got Ref
				//IL_08a7: Expected O, but got I
				//IL_08b0: Unknown result type (might be due to invalid IL or missing references)
				//IL_08b5: Expected O, but got Unknown
				//IL_0a4f: Expected O, but got I
				//IL_0a61: Expected O, but got Ref
				//IL_0a71: Expected O, but got I
				//IL_0a7a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0a7f: Expected O, but got Unknown
				//IL_0910: Expected O, but got I
				//IL_0922: Expected O, but got Ref
				//IL_0932: Expected O, but got I
				//IL_093b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0940: Expected O, but got Unknown
				//IL_098d: Expected O, but got I
				object obj2 = default(object);
				object obj = (object)(&obj2);
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+58]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
				_ = 0;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+20]");
				object obj4 = 0;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+88]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v6+FC]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
				object obj6 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
				object obj10;
				if ((nint)obj6 > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
					_ = ref obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
					object obj7 = (nint)0 + (nint)15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
					if ((nint)obj7 <= 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
					obj = (object)(&obj2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
					object obj8 = (nint)0 + (nint)15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
					if ((nint)obj8 <= 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
					_ = ref obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
					object obj9 = (nint)0 + (nint)15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
					if ((nint)obj9 <= 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v6+FC]");
					obj10 = (nint)0 + (nint)15;
					object obj11 = obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v6+FC]");
					if ((nint)obj11 > 0)
					{
						goto IL_0be8;
					}
				}
				obj10 = 1152921504606846960L;
				goto IL_0be8;
				IL_0be8:
				object obj12 = obj10 & -16;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				_ = ref obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
				object obj13 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
				if ((nint)obj13 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				_ = ref obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
				object obj14 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
				if ((nint)obj14 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
				_ = 0;
				nint num4 = 0;
				IntPtr intPtr = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rcx_v14 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v3+18]");
				object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v3+10]");
				object obj17 = 0;
				object obj18 = obj16 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v47+28]");
				if ((nint)0 >= (nint)0)
				{
					obj18 = obj16;
				}
				if (obj18 == null)
				{
					nint num5 = 0;
					IntPtr intPtr2 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rcx_v142 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
					object obj19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ r9_v14+B8]");
					object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ r9_v14+B0]");
					object obj21 = 0;
					object obj22 = obj20 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v217+28]");
					if ((nint)0 >= (nint)0)
					{
						obj22 = obj20;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					nint num6 = 0;
					IntPtr intPtr3 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rcx_v148 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
					object obj23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rdx_v52+B8]");
					object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rdx_v52+B0]");
					object obj25 = 0;
					object obj26 = obj24 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v223+28]");
					if ((nint)0 >= (nint)0)
					{
						obj26 = obj24;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
					nint num7 = 0;
					IntPtr intPtr4 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ rcx_v152 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
					object obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rdx_v54+18]");
					object obj28 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rdx_v54+10]");
					object obj29 = 0;
					object obj30 = obj28 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v228+28]");
					if ((nint)0 >= (nint)0)
					{
						obj30 = obj28;
					}
					obj30 = 4294967295L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					if ((nint)0 != 0)
					{
						object obj31 = obj30 >> 12;
						object obj32 = obj31 & 0x1FFFFF;
						object obj33 = obj32 >> 6;
						object obj34 = obj33 * 8;
						object obj35 = 6603577472L + obj34;
						object obj36 = obj32 & 0x3F;
						nint num9;
						do
						{
							object obj37 = 1 << (int)obj36;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r8_v57+462E0]");
							object obj38 = 0 | obj37;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r8_v57+462E0]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r8_v57+462E0]");
							if (num8 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r8_v57+462E0]");
							num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r8_v57+462E0]");
						}
						while (num9 != 0);
					}
				}
				else
				{
					nint num10 = 0;
					IntPtr intPtr5 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v105 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
					object obj39 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v38+58]");
					object obj40 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v38+50]");
					object obj41 = 0;
					object obj42 = obj40 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v168+28]");
					if ((nint)0 >= (nint)0)
					{
						obj42 = obj40;
					}
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v171 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+10]");
					object obj43 = 0;
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rax_v174 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+10]");
					object obj44 = 0;
					_ = ref obj2;
					object obj45 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v376 @ rbx_v22+10] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					nint num13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v180 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+28]");
					object obj46 = 0;
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v455 @ rcx_v114] (should have been resolved before IL gen)");
					object obj47 = default(object);
					if (obj47 == null)
					{
						nint num15 = 0;
						IntPtr intPtr6 = num15;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1A60");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
						nint num16 = 0;
						IntPtr intPtr7 = num16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v705 @ rcx_v121 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
						object obj48 = (nint)0 + (nint)160;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
						nint num17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ rax_v196 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+38]");
						object obj49 = 0;
						nint num18 = 0;
						nint num19 = 0;
						IntPtr intPtr8 = num19;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rcx_v127 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
						object obj50 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ rdx_v47+38]");
						object obj51 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ rdx_v47+30]");
						object obj52 = 0;
						object obj53 = obj51 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v920 @ rax_v203+28]");
						if ((nint)0 >= (nint)0)
						{
							obj53 = obj51;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v763 @ rcx_v124] (should have been resolved before IL gen)");
						return;
					}
				}
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v52 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+50]");
				object obj54 = 0;
				nint num21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v664 @ rax_v55 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+50]");
				object obj55 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
				_ = 0;
				object obj56 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v627 @ rbx_v4+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				nint num22 = 0;
				IntPtr intPtr9 = num22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ rcx_v24 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
				object obj57 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v718 @ rdx_v8+78]");
				object obj58 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v718 @ rdx_v8+70]");
				object obj59 = 0;
				object obj60 = obj58 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rax_v62+28]");
				if ((nint)0 >= (nint)0)
				{
					obj60 = obj58;
				}
				object obj61 = obj60;
				nint num23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v938 @ rax_v83 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+78]");
				object obj62 = 0;
				nint num24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v939 @ rcx_v35] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
				nint num25 = 0;
				nint num26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1225 @ rax_v95 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+58]");
				object obj63 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1226 @ r8_v19+28]");
				object obj64 = (nint)0 >> 31;
				if (obj64 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				}
				else
				{
					object obj65 = obj;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18434D4A0");
				object obj67 = default(object);
				object obj66 = obj67;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1250 @ rcx_v44+180]");
				object obj68 = 0;
				object obj69 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1251 @ rax_v101+10] (should have been resolved before IL gen)");
				nint num27 = 0;
				IntPtr intPtr10 = num27;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1272 @ rcx_v47 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
				object obj70 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rdx_v23+78]");
				object obj71 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1273 @ rdx_v23+70]");
				object obj72 = 0;
				object obj73 = obj71 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1204 @ rax_v106+28]");
				if ((nint)0 >= (nint)0)
				{
					obj73 = obj71;
				}
				if (obj73 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"lock xadd [rdx+30h],ebx\"");
					object obj74 = 1 + 1;
					nint num28 = 0;
					IntPtr intPtr11 = num28;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rcx_v51 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
					object obj75 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ rdx_v25+98]");
					object obj76 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ rdx_v25+90]");
					object obj77 = 0;
					object obj78 = obj76 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1308 @ rax_v110+28]");
					if ((nint)0 >= (nint)0)
					{
						obj78 = obj76;
					}
					if (obj74 == obj78)
					{
						nint num29 = 0;
						IntPtr intPtr12 = num29;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1378 @ rcx_v71 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
						object obj79 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ rdx_v31+78]");
						object obj80 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ rdx_v31+70]");
						object obj81 = 0;
						object obj82 = obj80 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1380 @ rax_v133+28]");
						if ((nint)0 >= (nint)0)
						{
							obj82 = obj80;
						}
						object obj83 = obj82;
						_ = 2;
						nint num30 = 0;
						IntPtr intPtr13 = num30;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1489 @ rcx_v75 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
						object obj84 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rdx_v32+78]");
						object obj85 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rdx_v32+70]");
						object obj86 = 0;
						object obj87 = obj85 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v985 @ rax_v138+28]");
						if ((nint)0 >= (nint)0)
						{
							obj87 = obj85;
						}
						object obj88 = obj87;
						nint num31 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1549 @ rax_v141 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>)+78]");
						object obj89 = 0;
						nint num32 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1550 @ rcx_v79] (should have been resolved before IL gen)");
						object obj91 = default(object);
						object obj90 = obj91;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1566 @ r8_v41+188] (should have been resolved before IL gen)");
					}
					nint num33 = 0;
					IntPtr intPtr14 = num33;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1398 @ rcx_v56 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
					object obj92 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1399 @ rdx_v27+18]");
					object obj93 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1399 @ rdx_v27+10]");
					object obj94 = 0;
					object obj95 = obj93 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1402 @ rax_v115+28]");
					if ((nint)0 < (nint)0)
					{
						obj95 = 4294967294L;
					}
					nint num34 = 0;
					IntPtr intPtr15 = num34;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1527 @ rcx_v61 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator+<RunWhenEachTask>d__11>>)+80]");
					object obj96 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rdx_v29+38]");
					object obj97 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rdx_v29+30]");
					object obj98 = 0;
					object obj99 = obj97 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1529 @ rax_v120+28]");
					if ((nint)0 >= (nint)0)
					{
						obj99 = obj97;
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

		private readonly IEnumerable<UniTask<T>> source = source;

		private CancellationToken cancellationToken;

		private Channel<WhenEachResult<T>> channel;

		private IUniTaskAsyncEnumerator<WhenEachResult<T>> channelEnumerator;

		private int completeCount;

		private WhenEachState state;

		public unsafe WhenEachResult<T> Current
		{
			get
			{
				//IL_0008: Expected O, but got Ref
				//IL_0018: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_004c: Expected O, but got I
				//IL_0062: Expected O, but got I
				//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f7: Expected O, but got Unknown
				//IL_0093: Expected O, but got I8
				//IL_00a8: Expected O, but got I
				//IL_00b8: Expected O, but got I
				object obj2 = default(object);
				object obj = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v1+C0]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9_v1+20]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rax_v2+FC]");
				object obj6 = (nint)0 + (nint)15;
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rax_v2+FC]");
				if ((nint)obj7 <= 0)
				{
					obj6 = 1152921504606846960L;
				}
				object obj8 = obj6 & -16;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.WhenEachEnumerable`1<T>+Enumerator<T>)+28]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8+20]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v6+C0]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1800");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					WhenEachResult<T> result = default(WhenEachResult<T>);
					return result;
				}
				return (WhenEachResult<T>)new NullReferenceException();
			}
		}

		public unsafe UniTask<bool> MoveNextAsync()
		{
			//IL_0013: Expected O, but got I
			//IL_003f: Expected O, but got I4
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			//IL_008b: Expected O, but got I
			//IL_009b: Expected O, but got I
			//IL_00ab: Expected O, but got I
			//IL_0347: Expected O, but got I
			//IL_0357: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_00da: Expected O, but got I
			//IL_00ea: Expected O, but got I
			//IL_00fa: Expected O, but got I
			//IL_010a: Expected O, but got I
			//IL_011a: Expected O, but got I
			//IL_0139: Expected O, but got I
			//IL_018b: Expected O, but got I
			//IL_019b: Expected O, but got I
			//IL_01c4: Expected O, but got I
			//IL_01d4: Expected O, but got I
			//IL_02f7: Expected O, but got I
			//IL_0307: Expected O, but got I
			//IL_0317: Expected O, but got I
			//IL_032a: Expected O, but got I4
			//IL_0213: Expected O, but got I
			//IL_0223: Expected O, but got I
			//IL_0233: Expected O, but got I
			//IL_0243: Expected O, but got I
			//IL_0253: Expected O, but got I
			//IL_026d: Expected O, but got I
			//IL_027d: Expected O, but got I
			//IL_028d: Expected O, but got I
			//IL_029d: Expected O, but got I
			//IL_02ad: Expected O, but got I
			//IL_02ca: Expected O, but got Ref
			//IL_02d2: Expected O, but got Ref
			//IL_02da: Expected O, but got Ref
			nint num = default(nint);
			CancellationToken cancellationToken = (CancellationToken)(num + 24);
			((CancellationToken*)cancellationToken)->ThrowIfCancellationRequested();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+34]");
			bool flag = (nint)0 != 0;
			ArrayPoolUtil.RentArray<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType> rentArray = (ArrayPoolUtil.RentArray<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>)0;
			object obj2 = default(object);
			object obj = obj2;
			if (!flag)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v16+C0]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v10+28]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+20]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v18+C0]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v76 @ rax_v17] (should have been resolved before IL gen)");
				cancellationToken = (CancellationToken)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+20]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v21+C0]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rdx_v7+40]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+20]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rax_v23+C0]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v315 @ rax_v22] (should have been resolved before IL gen)");
				CancellationToken cancellationToken2 = default(CancellationToken);
				bool flag2 = (object)cancellationToken2 == null;
				cancellationToken = (CancellationToken)0;
				if (!flag2)
				{
					CancellationTokenSource cancellationTokenSource = cancellationToken2._source;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v328 @ r8_v7 (System.Threading.CancellationTokenSource)+1B8] (should have been resolved before IL gen)");
					object obj13 = default(object);
					if (obj13 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+20]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rdx_v11+C0]");
						object obj15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18070AB30");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+20]");
						object obj16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rcx_v20+C0]");
						object obj17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj18 = default(object);
						if (obj18 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+20]");
							object obj19 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v476 @ rax_v38+C0]");
							object obj20 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rcx_v25+80]");
							object obj21 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+20]");
							object obj22 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v40+C0]");
							object obj23 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v478 @ rax_v39] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ stack_18_v4+20]");
							object obj24 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rax_v43+C0]");
							object obj25 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rcx_v28+70]");
							object obj26 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ stack_18_v4+20]");
							object obj27 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v45+C0]");
							object obj28 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v492 @ rax_v44] (should have been resolved before IL gen)");
							ArrayPoolUtil.RentArray<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType> rentArray2 = default(ArrayPoolUtil.RentArray<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>);
							rentArray2.Dispose();
							ArrayPoolUtil.RentArray<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType> rentArray3 = (ArrayPoolUtil.RentArray<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>)(&rentArray2);
							rentArray = (ArrayPoolUtil.RentArray<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>)(&rentArray2);
							cancellationToken = (CancellationToken)(&rentArray2);
							object obj29 = default(object);
							obj = obj29;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r8+20]");
							object obj30 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rcx_v23+C0]");
							object obj31 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v36+70]");
							object obj32 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v94 @ r10_v3] (should have been resolved before IL gen)");
							rentArray = (ArrayPoolUtil.RentArray<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>)0;
							obj = obj2;
						}
						goto IL_0381;
					}
				}
				goto IL_0370;
			}
			goto IL_0381;
			IL_0381:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+28]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ stack_18_v2+20]");
				object obj33 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v5+C0]");
				object obj34 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180480F30");
				object obj35 = default(object);
				Enumerator enumerator = (Enumerator)obj35;
				return (UniTask<bool>)this;
			}
			goto IL_0370;
			IL_0370:
			throw new NullReferenceException();
		}

		private unsafe static void ConsumeAll(Enumerator self, UniTask<T>[] array, int length)
		{
			//IL_0028: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Expected O, but got Unknown
			//IL_006f: Expected O, but got I8
			//IL_007d: Expected O, but got I4
			//IL_008a: Expected I, but got O
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			//IL_00df: Expected O, but got I
			//IL_0108: Expected O, but got Ref
			//IL_0122: Expected O, but got I
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			object obj = default(object);
			nint num = (nint)(&obj);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+A0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v2+FC]");
			object obj3 = (nint)0 + (nint)15;
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v2+FC]");
			if ((nint)obj4 <= 0)
			{
				obj3 = 1152921504606846960L;
			}
			object obj5 = obj3 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			if (length > 0)
			{
				object obj6 = 0;
				do
				{
					nint num3 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v11 (Il2CppClass<Cysharp.Threading.Tasks.UniTask`1<T>[]>)+104]");
					object obj7 = 0 * obj6;
					object obj8 = obj7 + 32;
					object obj9 = obj8 + (object)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v16 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+A8]");
					object obj10 = 0;
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1 (Il2CppMethodInfo)+60]");
					num = 0;
					object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 120));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+A8]");
					object obj12 = 0;
					_ = ref obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v100 @ rsi_v5+10] (should have been resolved before IL gen)");
					obj6++;
				}
				while ((nint)obj6 < length);
			}
		}

		private unsafe static UniTaskVoid RunWhenEachTask(Enumerator self, UniTask<T> task, int length)
		{
			//IL_0008: Expected O, but got Ref
			//IL_0028: Expected O, but got I
			//IL_0043: Expected O, but got I
			//IL_0059: Expected O, but got I
			//IL_038c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0391: Expected O, but got Unknown
			//IL_03b1: Expected O, but got I
			//IL_008a: Expected O, but got I8
			//IL_00a5: Expected O, but got I
			//IL_00b5: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_00da: Expected O, but got Ref
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_03f2: Expected O, but got I4
			//IL_0123: Expected O, but got I
			//IL_0133: Expected O, but got I
			//IL_0143: Expected O, but got I
			//IL_0158: Expected O, but got Ref
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Expected O, but got Unknown
			//IL_01ab: Expected O, but got I
			//IL_01c1: Expected O, but got I
			//IL_01e6: Expected O, but got I
			//IL_01f6: Expected O, but got I
			//IL_0206: Expected O, but got I
			//IL_021b: Expected O, but got Ref
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Expected O, but got Unknown
			//IL_0414: Expected O, but got I
			//IL_0264: Expected O, but got I
			//IL_0274: Expected O, but got I
			//IL_0284: Expected O, but got I
			//IL_0299: Expected O, but got Ref
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Expected O, but got Unknown
			//IL_0426: Expected O, but got I8
			//IL_02e2: Expected O, but got I
			//IL_0308: Expected O, but got I
			//IL_0318: Expected O, but got I
			//IL_0328: Expected O, but got I
			//IL_033d: Expected O, but got Ref
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Expected O, but got Unknown
			//IL_0383: Expected O, but got I4
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+B0]");
			object obj3 = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+A0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
			object obj5 = (nint)0 + (nint)15;
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4+FC]");
			if ((nint)obj6 <= 0)
			{
				obj5 = 1152921504606846960L;
			}
			object obj7 = obj5 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v2+FC]");
			object obj8 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v2+FC]");
			if ((nint)obj8 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v16 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+B0]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v10+80]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v3+30]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v3+38]");
			object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj13 = obj12 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v17+28]");
			if ((nint)0 < (nint)0)
			{
				obj13 = 0;
			}
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v21 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+B0]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v15+80]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rdx_v5+70]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rdx_v5+78]");
			object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj18 = obj17 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v22+28]");
			if ((nint)0 < (nint)0)
			{
				obj18 = self;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v27 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+B0]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rcx_v21+80]");
			object obj20 = (nint)0 + (nint)64;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rax_v31 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+B0]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rcx_v24+80]");
			object obj22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rdx_v10+90]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rdx_v10+98]");
			object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj25 = obj24 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v32+28]");
			if ((nint)0 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+50]");
				obj25 = 0;
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rax_v37 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+B0]");
			object obj26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rcx_v29+80]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v12+10]");
			object obj28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rdx_v12+18]");
			object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj30 = obj29 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rax_v38+28]");
			if ((nint)0 < (nint)0)
			{
				obj30 = 4294967295L;
			}
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rax_v42 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+B8]");
			object obj31 = 0;
			nint num9 = 0;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v48 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+B0]");
			object obj32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rcx_v37+80]");
			object obj33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ r9_v2+30]");
			object obj34 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ r9_v2+38]");
			object obj35 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj36 = obj35 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rax_v49+28]");
			if ((nint)0 >= (nint)0)
			{
				obj36 = obj35;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v554 @ rcx_v34] (should have been resolved before IL gen)");
			return (UniTaskVoid)0;
		}

		public unsafe UniTask DisposeAsync()
		{
			//IL_001b: Expected O, but got I
			//IL_0037: Expected native int or pointer, but got O
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1+Enumerator>)+D0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v135 @ rax_v6] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1832216A0");
			UniTask uniTask = default(UniTask);
			object obj2 = default(object);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, obj2);
			return uniTask;
		}
	}

	private IEnumerable<UniTask<T>> source = source;

	public IUniTaskAsyncEnumerator<WhenEachResult<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0026: Expected O, but got I
		nint num = 0;
		IUniTaskAsyncEnumerator<WhenEachResult<T>> result = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.WhenEachEnumerable`1>)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v42 @ r10_v1] (should have been resolved before IL gen)");
		return result;
	}
}
