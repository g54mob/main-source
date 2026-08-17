using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;

namespace Cysharp.Threading.Tasks;

public static class UnityAwaitableExtensions
{
	[StructLayout((LayoutKind)3)]
	private struct _003CAsUniTask_003Ed__0 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public Awaitable awaitable;

		private Awaitable.Awaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_007d: Expected I4, but got I8
			//IL_00b9: Expected O, but got Ref
			Awaitable awaitable;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (Awaitable.Awaiter)0;
				_003C_003E1__state = -1;
				awaitable = (Awaitable)_003C_003Eu__1;
			}
			else
			{
				bool isCompleted = this.awaitable.IsCompleted;
				bool flag = !isCompleted;
				awaitable = this.awaitable;
				if (flag)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (Awaitable.Awaiter)this.awaitable;
					AsyncUniTaskMethodBuilder asyncUniTaskMethodBuilder = (AsyncUniTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					Awaitable.Awaiter awaiter = default(Awaitable.Awaiter);
					((AsyncUniTaskMethodBuilder*)asyncUniTaskMethodBuilder)->AwaitOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			awaitable.PropagateExceptionAndRelease();
			_003C_003E1__state = -2;
			if ((object)_003C_003Et__builder != null)
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
	private struct _003CAsUniTask_003Ed__1<T> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

		public Awaitable<T> awaitable;

		private Awaitable<T>.Awaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0023: Expected O, but got I
			//IL_0039: Expected O, but got I
			//IL_0747: Expected O, but got Ref
			//IL_075d: Expected O, but got I
			//IL_0076: Expected O, but got I
			//IL_0088: Expected O, but got Ref
			//IL_0098: Expected O, but got I
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected O, but got Unknown
			//IL_02da: Expected O, but got I
			//IL_02ec: Expected O, but got Ref
			//IL_02fc: Expected O, but got I
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_030a: Expected O, but got Unknown
			//IL_00fb: Expected O, but got I
			//IL_010d: Expected O, but got Ref
			//IL_011d: Expected O, but got I
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_0357: Expected O, but got I
			//IL_017b: Expected O, but got I
			//IL_018d: Expected O, but got Ref
			//IL_019d: Expected O, but got I
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Expected O, but got Unknown
			//IL_038c: Expected O, but got I
			//IL_07ce: Expected O, but got I4
			//IL_01e9: Expected O, but got I
			//IL_01fb: Expected O, but got Ref
			//IL_020b: Expected O, but got I
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Expected O, but got Unknown
			//IL_03a5: Expected O, but got Ref
			//IL_07e0: Expected O, but got I8
			//IL_03e2: Expected O, but got I
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Expected O, but got Unknown
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Expected O, but got Unknown
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Expected O, but got Unknown
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Expected O, but got Unknown
			//IL_063a: Expected O, but got I
			//IL_064c: Expected O, but got Ref
			//IL_065c: Expected O, but got I
			//IL_0665: Unknown result type (might be due to invalid IL or missing references)
			//IL_066a: Expected O, but got Unknown
			//IL_03fd: Expected O, but got I
			//IL_0410: Expected O, but got Ref
			//IL_041e: Expected O, but got Ref
			//IL_0895: Expected O, but got I4
			//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_08aa: Expected O, but got Unknown
			//IL_0865: Expected O, but got I
			//IL_0455: Expected O, but got I
			//IL_0467: Expected O, but got Ref
			//IL_0477: Expected O, but got I
			//IL_0480: Unknown result type (might be due to invalid IL or missing references)
			//IL_0485: Expected O, but got Unknown
			//IL_06a5: Expected O, but got I
			//IL_0846: Expected O, but got I8
			//IL_06d3: Expected O, but got I
			//IL_06e5: Expected O, but got Ref
			//IL_06f5: Expected O, but got I
			//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0703: Expected O, but got Unknown
			//IL_04dc: Expected O, but got I
			//IL_04f2: Expected O, but got I
			//IL_050c: Expected O, but got Ref
			//IL_0878: Expected O, but got Ref
			//IL_0545: Expected O, but got I
			//IL_0557: Expected O, but got Ref
			//IL_0567: Expected O, but got I
			//IL_0570: Unknown result type (might be due to invalid IL or missing references)
			//IL_0575: Expected O, but got Unknown
			//IL_05bd: Expected O, but got I
			//IL_05dd: Expected O, but got I
			//IL_05eb: Expected O, but got Ref
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+60]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
			object obj4 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
			object obj5 = default(object);
			if ((nint)obj4 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				obj5 = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
				object obj6 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
				if ((nint)obj6 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
				_ = 0;
			}
			nint num2 = 0;
			IntPtr intPtr = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rcx_v6 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v2+18]");
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v2+10]");
			object obj9 = 0;
			object obj10 = obj8 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v16+28]");
			if ((nint)0 >= (nint)0)
			{
				obj10 = obj8;
			}
			if (obj10 == null)
			{
				nint num3 = 0;
				IntPtr intPtr2 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v85 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v23+78]");
				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v23+70]");
				object obj13 = 0;
				object obj14 = obj12 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v121+28]");
				if ((nint)0 >= (nint)0)
				{
					obj14 = obj12;
				}
				nint num4 = 0;
				IntPtr intPtr3 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rcx_v89 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdx_v24+78]");
				object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdx_v24+70]");
				object obj17 = 0;
				object obj18 = obj16 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v126+28]");
				if ((nint)0 < (nint)0)
				{
					obj18 = 0;
				}
				nint num5 = 0;
				IntPtr intPtr4 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v93 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rdx_v25+18]");
				object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rdx_v25+10]");
				object obj21 = 0;
				object obj22 = obj20 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v131+28]");
				if ((nint)0 >= (nint)0)
				{
					obj22 = obj20;
				}
				obj22 = 4294967295L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				if ((nint)0 != 0)
				{
					object obj23 = obj22 >> 12;
					object obj24 = obj23 & 0x1FFFFF;
					object obj25 = obj24 >> 6;
					object obj26 = obj25 * 8;
					object obj27 = 6603577472L + obj26;
					object obj28 = obj24 & 0x3F;
					nint num7;
					do
					{
						object obj29 = 1 << (int)obj28;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rdx_v26+462E0]");
						object obj30 = 0 | obj29;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rdx_v26+462E0]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rdx_v26+462E0]");
						if (num6 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rdx_v26+462E0]");
						num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rdx_v26+462E0]");
					}
					while (num7 != 0);
				}
			}
			else
			{
				nint num8 = 0;
				IntPtr intPtr5 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v44 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
				object obj31 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v13+58]");
				object obj32 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rdx_v13+50]");
				object obj33 = 0;
				object obj34 = obj32 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v67+28]");
				if ((nint)0 >= (nint)0)
				{
					obj34 = obj32;
				}
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v71 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+10]");
				object obj35 = 0;
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v284 @ rcx_v48] (should have been resolved before IL gen)");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rax_v78 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+20]");
				object obj36 = 0;
				nint num12 = 0;
				object obj37 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v407 @ rcx_v52] (should have been resolved before IL gen)");
				object obj38 = default(object);
				if (obj38 == null)
				{
					nint num13 = 0;
					IntPtr intPtr6 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1A60");
					nint num14 = 0;
					IntPtr intPtr7 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rcx_v58 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
					object obj39 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rdx_v18+78]");
					object obj40 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rdx_v18+70]");
					object obj41 = 0;
					object obj42 = obj40 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v90+28]");
					if ((nint)0 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+70]");
						obj42 = 0;
					}
					nint num15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v94 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+38]");
					object obj43 = 0;
					nint num16 = 0;
					nint num17 = 0;
					IntPtr intPtr8 = num17;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ rcx_v66 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
					object obj44 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ rdx_v20+38]");
					object obj45 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v861 @ rdx_v20+30]");
					object obj46 = 0;
					object obj47 = obj45 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v864 @ rax_v101+28]");
					if ((nint)0 >= (nint)0)
					{
						obj47 = obj45;
					}
					object obj48 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v777 @ rcx_v63] (should have been resolved before IL gen)");
					return;
				}
			}
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rax_v22 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+58]");
			object obj49 = 0;
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rax_v25 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+58]");
			object obj50 = 0;
			_ = ref obj2;
			object obj51 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
			object obj52 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v538 @ rsi_v4+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num20 = 0;
			IntPtr intPtr9 = num20;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rcx_v17 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
			object obj53 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rdx_v8+18]");
			object obj54 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rdx_v8+10]");
			object obj55 = 0;
			object obj56 = obj54 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v32+28]");
			if ((nint)0 >= (nint)0)
			{
				obj56 = obj54;
			}
			obj56 = 4294967294L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ rax_v37 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+60]");
			object obj57 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rcx_v23+28]");
			object obj58 = (nint)0 >> 31;
			bool flag = obj58 != null;
			object obj59 = (object)(&obj2);
			if (!flag)
			{
				obj59 = obj5;
			}
			nint num22 = 0;
			IntPtr intPtr10 = num22;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rcx_v25 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
			object obj60 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdx_v10+38]");
			object obj61 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rdx_v10+30]");
			object obj62 = 0;
			object obj63 = obj61 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ rax_v43+28]");
			if ((nint)0 >= (nint)0)
			{
				obj63 = obj61;
			}
			nint num23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rax_v46 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+70]");
			object obj64 = 0;
			nint num24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v964 @ rax_v49 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+70]");
			object obj65 = 0;
			object obj66 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v924 @ rbx_v4+10] (should have been resolved before IL gen)");
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_001b: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_0071: Expected O, but got I
			//IL_0083: Expected O, but got Ref
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+78]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>)+78]");
			object obj3 = 0;
			nint num3 = 0;
			IntPtr intPtr = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityAwaitableExtensions+<AsUniTask>d__1`1>>)+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v1+30]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v1+38]");
			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			object obj7 = obj6 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v10+28]");
			if ((nint)0 >= (nint)0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v38 @ rsi_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public unsafe static UniTask AsUniTask(Awaitable awaitable)
	{
		//IL_002b: Expected native int or pointer, but got O
		_003CAsUniTask_003Ed__0 obj = default(_003CAsUniTask_003Ed__0);
		obj.MoveNext();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1832216A0");
		UniTask uniTask = default(UniTask);
		object source = default(object);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
		return uniTask;
	}

	public unsafe static UniTask<T> AsUniTask<T>(Awaitable<T> awaitable)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		//IL_0074: Expected O, but got I
		//IL_008a: Expected O, but got I
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_0235: Expected O, but got I
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0281: Expected O, but got I
		//IL_0291: Expected O, but got I
		//IL_02a7: Expected O, but got I
		//IL_00bb: Expected O, but got I8
		//IL_02ea: Expected O, but got I
		//IL_02f8: Expected O, but got Ref
		//IL_031f: Expected O, but got I
		//IL_032f: Expected O, but got I
		//IL_0345: Expected O, but got I
		//IL_00cd: Expected O, but got I8
		//IL_00e2: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_0102: Expected O, but got I
		//IL_0112: Expected O, but got I
		//IL_0127: Expected O, but got Ref
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0165: Expected O, but got I
		//IL_0175: Expected O, but got I
		//IL_0185: Expected O, but got I
		//IL_0195: Expected O, but got I
		//IL_01a5: Expected O, but got I
		//IL_01ba: Expected O, but got Ref
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0448: Expected O, but got I
		//IL_0458: Expected O, but got I
		//IL_0468: Expected O, but got I
		//IL_0478: Expected O, but got I
		//IL_048d: Expected O, but got Ref
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_038d: Expected O, but got I
		//IL_039b: Expected O, but got Ref
		//IL_03b0: Expected O, but got I
		//IL_03c0: Expected O, but got I
		//IL_03d0: Expected O, but got I
		//IL_03e0: Expected O, but got I
		//IL_03f5: Expected O, but got Ref
		//IL_0405: Expected O, but got I
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Expected O, but got Unknown
		//IL_036e: Expected O, but got I8
		//IL_04cb: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2+40]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r9_v1+FC]");
		object obj6 = (nint)0 + (nint)15;
		object obj7 = obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r9_v1+FC]");
		if ((nint)obj7 <= 0)
		{
			obj6 = 1152921504606846960L;
		}
		object obj8 = obj6 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v1+FC]");
		object obj9 = (nint)0 + (nint)15;
		object obj10 = obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v1+FC]");
		if ((nint)obj10 <= 0)
		{
			obj9 = 1152921504606846960L;
		}
		object obj11 = obj9 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7+18]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v8+FC]");
		object obj14 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v8+FC]");
		if ((nint)obj14 <= 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
		object obj15 = 0;
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = ref obj2;
		object obj17 = obj15;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v125 @ r10_v1+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v15+18]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v11+80]");
		object obj20 = (nint)0 + (nint)32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v17+18]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v13+80]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v6+50]");
		object obj24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v6+58]");
		object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj26 = obj25 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v18+28]");
		if ((nint)0 < (nint)0)
		{
			obj26 = awaitable;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v20+18]");
			object obj28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v17+80]");
			object obj29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v8+10]");
			object obj30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rdx_v8+18]");
			object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj32 = obj31 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v21+28]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_04bb;
			}
			obj32 = 4294967295L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v23+18]");
		object obj34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v23+28]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v21+80]");
		object obj36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v10+30]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v10+38]");
		object obj38 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj39 = obj38 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rax_v24+28]");
		if ((nint)0 >= (nint)0)
		{
			obj39 = obj38;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v295 @ r10_v3] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
		object obj40 = 0;
		object obj41 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rax_v26+18]");
		object obj42 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rax_v26+38]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rcx_v24+80]");
		object obj44 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rdx_v12+30]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rdx_v12+38]");
		object obj46 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r8+38]");
		object obj47 = 0;
		object obj48 = obj46 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v27+28]");
		if ((nint)0 >= (nint)0)
		{
			obj48 = obj46;
		}
		goto IL_04bb;
		IL_04bb:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rax_v28+38]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v341 @ r10_v4+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		UniTask<T> result = default(UniTask<T>);
		return result;
	}
}
