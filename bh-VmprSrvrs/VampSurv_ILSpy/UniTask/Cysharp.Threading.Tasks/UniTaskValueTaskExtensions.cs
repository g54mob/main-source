using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks;

public static class UniTaskValueTaskExtensions
{
	[StructLayout((LayoutKind)3)]
	private struct _003CAsUniTask_003Ed__2<T> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

		public ValueTask<T> task;

		private ValueTaskAwaiter<T> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0023: Expected O, but got I
			//IL_004b: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_0761: Expected O, but got Ref
			//IL_0777: Expected O, but got I
			//IL_009e: Expected O, but got I
			//IL_00b0: Expected O, but got Ref
			//IL_00c0: Expected O, but got I
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			//IL_07b6: Expected O, but got I
			//IL_0804: Expected O, but got I
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
			//IL_087b: Expected O, but got I
			//IL_03a7: Expected O, but got I
			//IL_03af: Expected O, but got Ref
			//IL_01a3: Expected O, but got I
			//IL_01b5: Expected O, but got Ref
			//IL_01c5: Expected O, but got I
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Expected O, but got Unknown
			//IL_03de: Expected O, but got I
			//IL_0223: Expected O, but got I
			//IL_0235: Expected O, but got Ref
			//IL_0245: Expected O, but got I
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Expected O, but got Unknown
			//IL_08a6: Expected O, but got I8
			//IL_0420: Expected O, but got I
			//IL_043b: Expected O, but got I
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Expected O, but got Unknown
			//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Expected O, but got Unknown
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cf: Expected O, but got Unknown
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Expected O, but got Unknown
			//IL_069a: Expected O, but got I
			//IL_0456: Expected O, but got I
			//IL_0469: Expected O, but got Ref
			//IL_093d: Expected O, but got I4
			//IL_094d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0952: Expected O, but got Unknown
			//IL_06bf: Expected O, but got I
			//IL_04a0: Expected O, but got I
			//IL_04b2: Expected O, but got Ref
			//IL_04c2: Expected O, but got I
			//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d0: Expected O, but got Unknown
			//IL_0911: Expected O, but got I8
			//IL_06ed: Expected O, but got I
			//IL_06ff: Expected O, but got Ref
			//IL_070f: Expected O, but got I
			//IL_0718: Unknown result type (might be due to invalid IL or missing references)
			//IL_071d: Expected O, but got Unknown
			//IL_0527: Expected O, but got I
			//IL_053d: Expected O, but got I
			//IL_0557: Expected O, but got Ref
			//IL_0590: Expected O, but got I
			//IL_05a2: Expected O, but got Ref
			//IL_05b2: Expected O, but got I
			//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c0: Expected O, but got Unknown
			//IL_0608: Expected O, but got I
			//IL_0628: Expected O, but got I
			//IL_0636: Expected O, but got Ref
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+68]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+FC]");
			_ = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+20]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			}
			nint num3 = 0;
			IntPtr intPtr = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v8 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v3+18]");
			object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v3+10]");
			object obj12 = 0;
			object obj13 = obj11 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v30+28]");
			if ((nint)0 >= (nint)0)
			{
				obj13 = obj11;
			}
			if (obj13 == null)
			{
				nint num4 = 0;
				IntPtr intPtr2 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v83 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
				object obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ r9_v16+78]");
				object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ r9_v16+70]");
				object obj16 = 0;
				object obj17 = obj15 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v130+28]");
				if ((nint)0 >= (nint)0)
				{
					obj17 = obj15;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+88]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				nint num5 = 0;
				IntPtr intPtr3 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rcx_v89 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdx_v28+78]");
				object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdx_v28+70]");
				object obj21 = 0;
				object obj22 = obj20 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rax_v136+28]");
				if ((nint)0 >= (nint)0)
				{
					obj22 = obj20;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
				nint num6 = 0;
				IntPtr intPtr4 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rcx_v93 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v30+18]");
				object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rdx_v30+10]");
				object obj25 = 0;
				object obj26 = obj24 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v141+28]");
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ r8_v25+462E0]");
						object obj34 = 0 | obj33;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ r8_v25+462E0]");
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ r8_v25+462E0]");
						if (num7 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ r8_v25+462E0]");
						num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ r8_v25+462E0]");
					}
					while (num8 != 0);
				}
			}
			else
			{
				nint num9 = 0;
				IntPtr intPtr5 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rcx_v46 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
				object obj35 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdx_v14+58]");
				object obj36 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdx_v14+50]");
				object obj37 = 0;
				object obj38 = obj36 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v81+28]");
				if ((nint)0 >= (nint)0)
				{
					obj38 = obj36;
				}
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v84 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+10]");
				object obj39 = 0;
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v87 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+10]");
				object obj40 = 0;
				obj = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v295 @ rbx_v10+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v93 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+28]");
				object obj41 = 0;
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v375 @ rcx_v55] (should have been resolved before IL gen)");
				object obj42 = default(object);
				if (obj42 == null)
				{
					nint num14 = 0;
					IntPtr intPtr6 = num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1A60");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					nint num15 = 0;
					IntPtr intPtr7 = num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rcx_v62 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
					object obj43 = (nint)0 + (nint)96;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rax_v109 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+40]");
					object obj44 = 0;
					nint num17 = 0;
					nint num18 = 0;
					IntPtr intPtr8 = num18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rcx_v68 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
					object obj45 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v755 @ rdx_v23+38]");
					object obj46 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v755 @ rdx_v23+30]");
					object obj47 = 0;
					object obj48 = obj46 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v116+28]");
					if ((nint)0 >= (nint)0)
					{
						obj48 = obj46;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v671 @ rcx_v65] (should have been resolved before IL gen)");
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+88]");
				object obj18 = 0;
			}
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rax_v37 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+60]");
			object obj49 = 0;
			nint num20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ rax_v40 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+60]");
			object obj50 = 0;
			_ = ref obj2;
			object obj51 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v571 @ rbx_v7+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num21 = 0;
			IntPtr intPtr9 = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rcx_v20 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
			object obj52 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rdx_v10+18]");
			object obj53 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ rdx_v10+10]");
			object obj54 = 0;
			object obj55 = obj53 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ rax_v47+28]");
			if ((nint)0 >= (nint)0)
			{
				obj55 = obj53;
			}
			obj55 = 4294967294L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rax_v52 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+68]");
			object obj56 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v813 @ rcx_v26+28]");
			object obj57 = (nint)0 >> 31;
			bool flag = obj57 != null;
			object obj58 = (object)(&obj2);
			if (!flag)
			{
				obj58 = obj6;
			}
			nint num23 = 0;
			IntPtr intPtr10 = num23;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v897 @ rcx_v28 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
			object obj59 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdx_v12+38]");
			object obj60 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdx_v12+30]");
			object obj61 = 0;
			object obj62 = obj60 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v901 @ rax_v58+28]");
			if ((nint)0 >= (nint)0)
			{
				obj62 = obj60;
			}
			nint num24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v927 @ rax_v61 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+78]");
			object obj63 = 0;
			nint num25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v934 @ rax_v64 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+78]");
			object obj64 = 0;
			object obj65 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v847 @ rbx_v9+10] (should have been resolved before IL gen)");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+80]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>)+80]");
			object obj3 = 0;
			nint num3 = 0;
			IntPtr intPtr = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UniTaskValueTaskExtensions+<AsUniTask>d__2`1>>)+80]");
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

	[StructLayout((LayoutKind)3)]
	private struct _003CAsUniTask_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder _003C_003Et__builder;

		public ValueTask task;

		private ValueTaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0091: Expected I4, but got I8
			//IL_00cd: Expected O, but got Ref
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (ValueTaskAwaiter)0;
				_003C_003E1__state = -1;
				ValueTaskAwaiter valueTaskAwaiter = _003C_003Eu__1;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A50EC0");
				object obj = default(object);
				bool flag = obj == null;
				ValueTaskAwaiter valueTaskAwaiter = (ValueTaskAwaiter)task;
				if (flag)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (ValueTaskAwaiter)task;
					AsyncUniTaskMethodBuilder asyncUniTaskMethodBuilder = (AsyncUniTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncUniTaskMethodBuilder*)asyncUniTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref valueTaskAwaiter, ref this);
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A50F70");
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

	public unsafe static ValueTask AsValueTask([In] ref UniTask task)
	{
		//IL_0048: Expected native int or pointer, but got O
		//IL_0039: Expected native int or pointer, but got O
		ValueTask valueTask = default(ValueTask);
		if ((object)task != null)
		{
			System.Runtime.CompilerServices.Unsafe.Write(&((ValueTask*)(nint)valueTask)->_obj, (object)task);
			return valueTask;
		}
		System.Runtime.CompilerServices.Unsafe.Write(&((ValueTask*)(nint)valueTask)->_obj, null);
		return valueTask;
	}

	public unsafe static ValueTask<T> AsValueTask<T>([In] ref UniTask<T> task)
	{
		//IL_0008: Expected O, but got Ref
		//IL_006e: Expected O, but got I
		//IL_007e: Expected O, but got I
		//IL_0094: Expected O, but got I
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00f2: Expected O, but got I
		//IL_00fa: Expected O, but got Ref
		//IL_010a: Expected O, but got I
		//IL_00c5: Expected O, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ r8 (Cysharp.Threading.Tasks.UniTask`1<T>&)+38]");
		bool flag = (nint)0 != 0;
		ref UniTask<T> reference = ref task;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			ref UniTask<T> reference2 = default(ref UniTask<T>);
			reference = ref reference2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ r8 (Cysharp.Threading.Tasks.UniTask`1<T>&)+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2+18]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ r9_v1+FC]");
		object obj5 = (nint)0 + (nint)15;
		object obj6 = obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ r9_v1+FC]");
		if ((nint)obj6 <= 0)
		{
			obj5 = 1152921504606846960L;
		}
		object obj7 = obj5 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ r8 (Cysharp.Threading.Tasks.UniTask`1<T>&)+38]");
		object obj8 = 0;
		obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref task);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v5+8]");
		object obj9 = 0;
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v65 @ r10_v1+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		ValueTask<T> result = default(ValueTask<T>);
		return result;
	}

	public unsafe static UniTask<T> AsUniTask<T>(ValueTask<T> task)
	{
		//IL_0008: Expected O, but got Ref
		//IL_004f: Expected O, but got I
		//IL_005f: Expected O, but got I
		//IL_006f: Expected O, but got I
		//IL_007f: Expected O, but got I
		//IL_0095: Expected O, but got I
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_028f: Expected O, but got I
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02e6: Expected O, but got I
		//IL_00c6: Expected O, but got I8
		//IL_0317: Expected O, but got Ref
		//IL_0327: Expected O, but got I
		//IL_0337: Expected O, but got I
		//IL_034d: Expected O, but got I
		//IL_00d8: Expected O, but got I8
		//IL_038e: Expected O, but got Ref
		//IL_039e: Expected O, but got I
		//IL_03cd: Expected O, but got I
		//IL_03dd: Expected O, but got I
		//IL_03f3: Expected O, but got I
		//IL_00f7: Expected O, but got I
		//IL_0107: Expected O, but got I
		//IL_011d: Expected O, but got I
		//IL_013c: Expected O, but got I
		//IL_014c: Expected O, but got I
		//IL_015c: Expected O, but got I
		//IL_016c: Expected O, but got I
		//IL_0181: Expected O, but got Ref
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_040f: Expected O, but got I8
		//IL_01bf: Expected O, but got I
		//IL_01cf: Expected O, but got I
		//IL_01df: Expected O, but got I
		//IL_01ef: Expected O, but got I
		//IL_01ff: Expected O, but got I
		//IL_0214: Expected O, but got Ref
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_042e: Expected O, but got I
		//IL_043c: Expected O, but got Ref
		//IL_0451: Expected O, but got I
		//IL_0461: Expected O, but got I
		//IL_0471: Expected O, but got I
		//IL_0481: Expected O, but got I
		//IL_0496: Expected O, but got Ref
		//IL_04a6: Expected O, but got I
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_04e9: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2+40]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v2+20]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r9_v1+FC]");
		object obj7 = (nint)0 + (nint)15;
		object obj8 = obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r9_v1+FC]");
		if ((nint)obj8 <= 0)
		{
			obj7 = 1152921504606846960L;
		}
		object obj9 = obj7 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v2+FC]");
		object obj10 = (nint)0 + (nint)15;
		_ = ref obj2;
		object obj11 = obj10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v2+FC]");
		if ((nint)obj11 <= 0)
		{
			obj10 = 1152921504606846960L;
		}
		object obj12 = obj10 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1+FC]");
		object obj13 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1+FC]");
		if ((nint)obj13 <= 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v13+18]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v9+FC]");
		object obj16 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v9+FC]");
		if ((nint)obj16 <= 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+70]");
		_ = 0;
		object obj19 = obj18;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v150 @ r10_v1+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v21+18]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v12+80]");
		object obj22 = (nint)0 + (nint)32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v24+18]");
		object obj24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v15+80]");
		object obj25 = (nint)0 + (nint)64;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		object obj26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v26+18]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v17+80]");
		object obj28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdx_v10+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdx_v10+18]");
		object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj31 = obj30 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v27+28]");
		if ((nint)0 < (nint)0)
		{
			obj31 = 4294967295L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		object obj32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v29+18]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rax_v29+28]");
		object obj34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v21+80]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdx_v12+30]");
		object obj36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdx_v12+38]");
		object obj37 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj38 = obj37 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v30+28]");
		if ((nint)0 >= (nint)0)
		{
			obj38 = obj37;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v243 @ r10_v2] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		object obj39 = 0;
		object obj40 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v32+18]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v32+38]");
		object obj42 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rcx_v24+80]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rdx_v14+30]");
		object obj44 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rdx_v14+38]");
		object obj45 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r8+38]");
		object obj46 = 0;
		object obj47 = obj45 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v33+28]");
		if ((nint)0 >= (nint)0)
		{
			obj47 = obj45;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v34+38]");
		object obj48 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v289 @ r10_v3+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		UniTask<T> result = default(UniTask<T>);
		return result;
	}

	public unsafe static UniTask AsUniTask(ValueTask task)
	{
		//IL_002b: Expected native int or pointer, but got O
		_003CAsUniTask_003Ed__3 obj = default(_003CAsUniTask_003Ed__3);
		obj.MoveNext();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1832216A0");
		UniTask uniTask = default(UniTask);
		object source = default(object);
		System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, source);
		return uniTask;
	}
}
