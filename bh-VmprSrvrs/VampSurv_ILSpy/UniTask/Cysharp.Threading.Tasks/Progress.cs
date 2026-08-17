using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

public static class Progress
{
	private sealed class NullProgress<T> : IProgress<T>
	{
		public static readonly IProgress<T> Instance;

		private NullProgress()
		{
		}

		public void Report(T value)
		{
		}

		static NullProgress()
		{
			//IL_0030: Expected O, but got I
			//IL_0060: Expected O, but got I
			//IL_0075: Expected O, but got I
			nint num = 0;
			object obj = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+NullProgress`1>)+8]");
			object obj2 = 0;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rcx_v5] (should have been resolved before IL gen)");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v15 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+NullProgress`1>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v17+B8]");
			object obj4 = 0;
			obj4 = obj;
		}
	}

	private sealed class AnonymousProgress<T>(Action<T> action) : IProgress<T>
	{
		private readonly Action<T> action = action;

		public unsafe void Report(T value)
		{
			//IL_0008: Expected O, but got Ref
			//IL_0028: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_00e3: Expected O, but got Ref
			//IL_00f1: Expected O, but got Ref
			//IL_0101: Expected O, but got I
			//IL_0117: Expected O, but got I
			//IL_0080: Expected O, but got I
			//IL_0096: Expected O, but got I
			//IL_00b0: Expected O, but got Ref
			//IL_0151: Expected O, but got Ref
			//IL_016c: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+AnonymousProgress`1>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rax_v2+FC]");
			object obj4 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rax_v2+FC]");
			object obj5 = default(object);
			T val;
			if ((nint)obj4 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
				nint num2 = 0;
				obj5 = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+AnonymousProgress`1>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v8+28]");
				object obj7 = (nint)0 >> 31;
				if (obj7 == null)
				{
					goto IL_0134;
				}
			}
			val = value;
			goto IL_0134;
			IL_0134:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+AnonymousProgress`1>)+10]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v12+28]");
			object obj9 = (nint)0 >> 31;
			bool flag = obj9 != null;
			object obj10 = (object)(&obj2);
			if (!flag)
			{
				obj10 = obj5;
			}
			object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+AnonymousProgress`1>)+18]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v100 @ r10_v1+10] (should have been resolved before IL gen)");
		}
	}

	private sealed class OnlyValueChangedProgress<T> : IProgress<T>
	{
		private readonly Action<T> action;

		private readonly IEqualityComparer<T> comparer;

		private bool isFirstCall;

		private T latestValue;

		public OnlyValueChangedProgress(Action<T> action, IEqualityComparer<T> comparer)
		{
			//IL_0016: Expected O, but got I
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_00b5: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_00d5: Expected O, but got I
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected O, but got Unknown
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Expected O, but got Unknown
			//IL_012b: Expected O, but got I
			//IL_013b: Expected O, but got I
			//IL_014b: Expected O, but got I
			//IL_0158: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Expected O, but got Unknown
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_009a: Expected O, but got I4
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ r10_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rax_v2+80]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r10_v2+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ r10_v2+18]");
			object obj4 = 0 + this;
			object obj5 = obj4 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v3+28]");
			if ((nint)0 < (nint)0)
			{
				obj5 = action;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v6+80]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v3+30]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v3+38]");
				object obj9 = 0 + this;
				object obj10 = obj9 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v7+28]");
				if ((nint)0 < (nint)0)
				{
					obj10 = comparer;
				}
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+8]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v10+80]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v6+50]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v6+58]");
				object obj14 = 0 + this;
				object obj15 = obj14 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v11+28]");
				if ((nint)0 >= (nint)0)
				{
					/*Error: End of method reached without returning.*/;
				}
				obj15 = 1;
			}
		}

		public unsafe void Report(T value)
		{
			//IL_0008: Expected O, but got Ref
			//IL_0023: Expected O, but got I
			//IL_0033: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_029e: Expected O, but got I
			//IL_02dd: Expected O, but got Ref
			//IL_02ed: Expected O, but got I
			//IL_02fd: Expected O, but got I
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Expected O, but got Unknown
			//IL_0325: Expected O, but got I
			//IL_032e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Expected O, but got Unknown
			//IL_0368: Expected O, but got I
			//IL_0378: Expected O, but got I
			//IL_0199: Expected O, but got I
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Expected O, but got Unknown
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Expected O, but got Unknown
			//IL_0417: Expected O, but got I4
			//IL_01e9: Expected O, but got I
			//IL_0092: Expected O, but got I
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_0430: Expected O, but got Ref
			//IL_0446: Expected O, but got I
			//IL_045c: Expected O, but got I
			//IL_03a6: Expected O, but got Ref
			//IL_03c1: Expected O, but got I
			//IL_03d7: Expected O, but got I
			//IL_05ad: Expected O, but got I
			//IL_05c3: Expected O, but got I
			//IL_05e3: Expected O, but got I
			//IL_05f3: Expected O, but got I
			//IL_0603: Expected O, but got I
			//IL_0610: Unknown result type (might be due to invalid IL or missing references)
			//IL_0615: Expected O, but got Unknown
			//IL_061e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0623: Expected O, but got Unknown
			//IL_0528: Expected O, but got I
			//IL_0538: Expected O, but got I
			//IL_0548: Expected O, but got I
			//IL_0555: Unknown result type (might be due to invalid IL or missing references)
			//IL_055a: Expected O, but got Unknown
			//IL_0563: Unknown result type (might be due to invalid IL or missing references)
			//IL_0568: Expected O, but got Unknown
			//IL_0487: Expected O, but got Ref
			//IL_049d: Expected O, but got I
			//IL_04b3: Expected O, but got I
			//IL_0114: Expected O, but got I
			//IL_012a: Expected O, but got I
			//IL_0233: Expected O, but got I
			//IL_0249: Expected O, but got I
			//IL_0263: Expected O, but got Ref
			//IL_04de: Expected O, but got Ref
			//IL_04f9: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
			object obj5 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
			nint num2 = default(nint);
			object obj7 = default(object);
			object obj10 = default(object);
			object obj12;
			if ((nint)obj5 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
				object obj6 = (nint)0 + (nint)15;
				num2 = (nint)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
				if ((nint)obj6 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				nint num3 = 0;
				obj7 = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+8]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v12+80]");
				object obj9 = 0;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+58]");
				obj10 = 0 + this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v3+50]");
				object obj11 = 0;
				obj12 = obj10 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14+28]");
				if ((nint)0 < (nint)0)
				{
					goto IL_0358;
				}
			}
			obj12 = obj10;
			goto IL_0358;
			IL_0358:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+8]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v15+80]");
			object obj14 = 0;
			IntPtr intPtr = default(IntPtr);
			nint num9;
			if (obj12 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v6+30]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v6+38]");
				object obj16 = 0 + this;
				object obj17 = obj16 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v43+28]");
				if ((nint)0 >= (nint)0)
				{
					obj17 = obj16;
				}
				T val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v36 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+18]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v46+28]");
				object obj19 = (nint)0 >> 31;
				if (obj19 != null)
				{
					val = value;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rcx_v40 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+8]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v49+80]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rcx_v41+70]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rcx_v41+78]");
				object obj23 = 0 + this;
				object obj24 = obj23 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rax_v50+28]");
				if ((nint)0 >= (nint)0)
				{
					obj24 = obj23;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v43 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+18]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v53+28]");
				object obj26 = (nint)0 >> 31;
				intPtr = ((obj26 == null) ? ((IntPtr)num2) : ((IntPtr)(nint)(&obj2)));
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804DAC30");
				object obj27 = default(object);
				if (obj27 != null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v6+50]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v6+58]");
				object obj29 = 0 + this;
				object obj30 = obj29 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v35+28]");
				if ((nint)0 < (nint)0)
				{
					obj30 = 0;
					num9 = 0;
					goto IL_0422;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+40]");
			obj4 = 0;
			num9 = intPtr;
			goto IL_0422;
			IL_0422:
			T val2 = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+18]");
			object obj31 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v18+28]");
			object obj32 = (nint)0 >> 31;
			if (obj32 != null)
			{
				val2 = value;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rcx_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+8]");
			object obj33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v21+80]");
			object obj34 = (nint)0 + (nint)96;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+8]");
			object obj35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v24+80]");
			object obj36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v15+10]");
			object obj37 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v15+18]");
			object obj38 = 0 + this;
			object obj39 = obj38 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v25+28]");
			if ((nint)0 >= (nint)0)
			{
				obj39 = obj38;
			}
			T val3 = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rcx_v18 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+18]");
			object obj40 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rax_v27+28]");
			object obj41 = (nint)0 >> 31;
			if (obj41 != null)
			{
				val3 = value;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rcx_v22 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+18]");
			object obj42 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v30+28]");
			object obj43 = (nint)0 >> 31;
			bool flag = obj43 != null;
			object obj44 = (object)(&obj2);
			if (!flag)
			{
				obj44 = obj7;
			}
			object obj45 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v512 @ rcx_v25 (Il2CppRgctx<Cysharp.Threading.Tasks.Progress+OnlyValueChangedProgress`1>)+28]");
			object obj46 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v513 @ r10_v1+10] (should have been resolved before IL gen)");
		}
	}

	public static IProgress<T> Create<T>(Action<T> handler)
	{
		if (handler != null)
		{
			IProgress<T> result = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ r9_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
			return result;
		}
		return NullProgress<T>.Instance;
	}

	public static IProgress<T> CreateOnlyValueChanged<T>(Action<T> handler, IEqualityComparer<T> comparer = null)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		if (handler != null)
		{
			bool flag = comparer != null;
			IEqualityComparer<T> equalityComparer = comparer;
			if (!flag)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ rcx_v16 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
				IEqualityComparer<T> equalityComparer2 = default(IEqualityComparer<T>);
				equalityComparer = equalityComparer2;
			}
			IProgress<T> result = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ r10_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
			return result;
		}
		return NullProgress<T>.Instance;
	}
}
