using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks;

public abstract class ChannelReader<T>
{
	[StructLayout((LayoutKind)3)]
	private struct _003CReadAsyncCore_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

		public ChannelReader<T> _003C_003E4__this;

		public CancellationToken cancellationToken;

		private UniTask<bool>.Awaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0028: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_075d: Expected O, but got Ref
			//IL_0773: Expected O, but got I
			//IL_007b: Expected O, but got I
			//IL_008d: Expected O, but got Ref
			//IL_009d: Expected O, but got I
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_07c7: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_010d: Expected O, but got Ref
			//IL_011d: Expected O, but got I
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_02e1: Expected O, but got I
			//IL_02f3: Expected O, but got Ref
			//IL_0303: Expected O, but got I
			//IL_030c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0311: Expected O, but got Unknown
			//IL_035b: Expected O, but got I
			//IL_0369: Expected O, but got Ref
			//IL_0180: Expected O, but got I
			//IL_0192: Expected O, but got Ref
			//IL_01a2: Expected O, but got I
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Expected O, but got Unknown
			//IL_0200: Expected O, but got I
			//IL_0212: Expected O, but got Ref
			//IL_0222: Expected O, but got I
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected O, but got Unknown
			//IL_0390: Expected O, but got Ref
			//IL_03b5: Expected O, but got I4
			//IL_0844: Expected O, but got I4
			//IL_026e: Expected O, but got I
			//IL_0280: Expected O, but got Ref
			//IL_0290: Expected O, but got I
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Expected O, but got Unknown
			//IL_0856: Expected O, but got I8
			//IL_085f: Expected O, but got I4
			//IL_062b: Expected O, but got I
			//IL_063d: Expected O, but got Ref
			//IL_064d: Expected O, but got I
			//IL_0656: Unknown result type (might be due to invalid IL or missing references)
			//IL_065b: Expected O, but got Unknown
			//IL_0431: Expected O, but got I
			//IL_0439: Expected O, but got Ref
			//IL_08a5: Expected O, but got I
			//IL_0696: Expected O, but got I
			//IL_040c: Expected O, but got I
			//IL_041c: Expected O, but got I
			//IL_06c4: Expected O, but got I
			//IL_06d6: Expected O, but got Ref
			//IL_06e6: Expected O, but got I
			//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f4: Expected O, but got Unknown
			//IL_08b8: Expected O, but got Ref
			//IL_04cd: Expected O, but got I
			//IL_04e3: Expected O, but got I
			//IL_04fd: Expected O, but got Ref
			//IL_0536: Expected O, but got I
			//IL_0548: Expected O, but got Ref
			//IL_0558: Expected O, but got I
			//IL_0561: Unknown result type (might be due to invalid IL or missing references)
			//IL_0566: Expected O, but got Unknown
			//IL_05ae: Expected O, but got I
			//IL_05ce: Expected O, but got I
			//IL_05dc: Expected O, but got Ref
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>)+58]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
			object obj4 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
			object obj5 = default(object);
			if ((nint)obj4 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				obj5 = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
				object obj6 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
				if ((nint)obj6 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				_ = ref obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
				object obj7 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
				if ((nint)obj7 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				_ = ref obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			}
			nint num2 = 0;
			IntPtr intPtr = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v7 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v3+18]");
			object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v3+10]");
			object obj10 = 0;
			object obj11 = obj9 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v23+28]");
			if ((nint)0 >= (nint)0)
			{
				obj11 = obj9;
			}
			nint num3 = 0;
			IntPtr intPtr2 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rcx_v11 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdx_v4+58]");
			object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdx_v4+50]");
			object obj14 = 0;
			object obj15 = obj13 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v27+28]");
			if ((nint)0 >= (nint)0)
			{
				obj15 = obj13;
			}
			object obj16 = obj15;
			object obj29;
			if (obj11 == null)
			{
				nint num4 = 0;
				IntPtr intPtr3 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rcx_v87 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
				object obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v34+98]");
				object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v34+90]");
				object obj19 = 0;
				object obj20 = obj18 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v134+28]");
				if ((nint)0 >= (nint)0)
				{
					obj20 = obj18;
				}
				nint num5 = 0;
				IntPtr intPtr4 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rcx_v91 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdx_v35+98]");
				object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rdx_v35+90]");
				object obj23 = 0;
				object obj24 = obj22 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rax_v138+28]");
				if ((nint)0 < (nint)0)
				{
					obj24 = 0;
				}
				nint num6 = 0;
				IntPtr intPtr5 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rcx_v95 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rdx_v36+18]");
				object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rdx_v36+10]");
				object obj27 = 0;
				object obj28 = obj26 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v142+28]");
				if ((nint)0 < (nint)0)
				{
					obj28 = 4294967295L;
					obj29 = 0;
					goto IL_03c3;
				}
			}
			nint num7 = 0;
			IntPtr intPtr6 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rcx_v50 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
			object obj30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rdx_v21+78]");
			object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rdx_v21+70]");
			object obj32 = 0;
			object obj33 = obj31 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rax_v82+28]");
			if ((nint)0 >= (nint)0)
			{
				obj33 = obj31;
			}
			object obj34 = obj16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r9_v7+190]");
			object obj35 = 0;
			object obj36 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v341 @ r9_v7+188] (should have been resolved before IL gen)");
			UniTask<bool> uniTask = (UniTask<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
			UniTaskStatus status = ((UniTask<bool>*)uniTask)->Status;
			bool flag = status == UniTaskStatus.Pending;
			obj29 = 0;
			if (!flag)
			{
				goto IL_03c3;
			}
			nint num8 = 0;
			IntPtr intPtr7 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1A60");
			nint num9 = 0;
			IntPtr intPtr8 = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rcx_v61 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
			object obj37 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rdx_v28+98]");
			object obj38 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v805 @ rdx_v28+90]");
			object obj39 = 0;
			object obj40 = obj38 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rax_v99+28]");
			if ((nint)0 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+20]");
				obj40 = 0;
			}
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v922 @ rax_v103 (Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>)+20]");
			object obj41 = 0;
			nint num11 = 0;
			nint num12 = 0;
			IntPtr intPtr9 = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ rcx_v69 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
			object obj42 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ rdx_v30+38]");
			object obj43 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v971 @ rdx_v30+30]");
			object obj44 = 0;
			object obj45 = obj43 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v974 @ rax_v110+28]");
			if ((nint)0 >= (nint)0)
			{
				obj45 = obj43;
			}
			object obj46 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v923 @ rcx_v66] (should have been resolved before IL gen)");
			return;
			IL_03c3:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+20]");
			object obj48 = default(object);
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B0]");
				object obj47 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+2A]");
				obj35 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+28]");
				obj48 = 0;
				object obj47 = (object)(&obj2);
			}
			if (obj48 != null)
			{
				object obj49 = obj16;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v795 @ r8_v12+178] (should have been resolved before IL gen)");
				object obj50 = default(object);
				if (obj50 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					nint num13 = 0;
					IntPtr intPtr10 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1A60");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1008 @ rax_v51 (Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>)+58]");
					object obj51 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rcx_v30+28]");
					object obj52 = (nint)0 >> 31;
					bool flag2 = obj52 != null;
					object obj53 = (object)(&obj2);
					if (!flag2)
					{
						obj53 = obj5;
					}
					nint num15 = 0;
					IntPtr intPtr11 = num15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rcx_v32 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
					object obj54 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rdx_v18+38]");
					object obj55 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ rdx_v18+30]");
					object obj56 = 0;
					object obj57 = obj55 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1071 @ rax_v57+28]");
					if ((nint)0 >= (nint)0)
					{
						obj57 = obj55;
					}
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1097 @ rax_v60 (Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>)+50]");
					object obj58 = 0;
					nint num17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1104 @ rax_v63 (Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>)+50]");
					object obj59 = 0;
					object obj60 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1027 @ rdi_v9+10] (should have been resolved before IL gen)");
					return;
				}
			}
			ChannelClosedException ex = new ChannelClosedException();
			throw ex;
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>)+60]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>)+60]");
			object obj3 = 0;
			nint num3 = 0;
			IntPtr intPtr = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.ChannelReader`1+<ReadAsyncCore>d__5>>)+80]");
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

	public abstract UniTask Completion { get; }

	public abstract bool TryRead(out T item);

	public abstract UniTask<bool> WaitToReadAsync(CancellationToken cancellationToken = default(CancellationToken));

	public unsafe virtual UniTask<T> ReadAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0008: Expected O, but got Ref
		//IL_017a: Expected O, but got I
		//IL_018a: Expected O, but got I
		//IL_019a: Expected O, but got I
		//IL_01aa: Expected O, but got I
		//IL_01ba: Expected O, but got I
		//IL_01ca: Expected O, but got I
		//IL_01e0: Expected O, but got I
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0354: Expected O, but got I
		//IL_035c: Expected O, but got Ref
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_0232: Expected O, but got I
		//IL_001f: Expected O, but got I8
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0288: Expected O, but got I
		//IL_0031: Expected O, but got I8
		//IL_0043: Expected O, but got I8
		//IL_00ff: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_011f: Expected O, but got I
		//IL_0135: Expected O, but got I
		//IL_014f: Expected O, but got Ref
		//IL_0058: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_007d: Expected O, but got I
		//IL_008b: Expected O, but got Ref
		//IL_00a3: Expected O, but got I
		//IL_00b3: Expected O, but got I
		//IL_00c3: Expected O, but got I
		//IL_00d3: Expected O, but got I
		//IL_02e8: Expected O, but got I
		//IL_0300: Expected O, but got I
		//IL_0310: Expected O, but got I
		//IL_0321: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ r9+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2+C0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v1+20]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ r9+20]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v4+C0]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v2+28]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3+FC]");
		object obj9 = (nint)0 + (nint)15;
		object obj10 = obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3+FC]");
		if ((nint)obj10 <= 0)
		{
			obj9 = 1152921504606846960L;
		}
		object obj11 = obj9 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v5+FC]");
		object obj12 = (nint)0 + (nint)15;
		object obj13 = (object)(&obj2);
		object obj14 = obj12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v5+FC]");
		if ((nint)obj14 <= 0)
		{
			obj12 = 1152921504606846960L;
		}
		object obj15 = obj12 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3+FC]");
		object obj16 = (nint)0 + (nint)15;
		object obj17 = obj16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3+FC]");
		if ((nint)obj17 <= 0)
		{
			obj16 = 1152921504606846960L;
		}
		object obj18 = obj16 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+50]");
		object obj19 = 0;
		object obj20 = obj19;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v129 @ r8_v2+178] (should have been resolved before IL gen)");
		object obj21 = default(object);
		if (obj21 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ r9+20]");
			object obj22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+50]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v24+C0]");
			object obj24 = 0;
			object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
			obj = obj25;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ r9+20]");
			object obj26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v23+30]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v26+C0]");
			object obj28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rcx_v24+30]");
			object obj29 = 0;
			object obj30 = obj29;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ r9+20]");
			object obj31 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v20+C0]");
			object obj32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v18+20]");
			object obj33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v21+28]");
			object obj34 = (nint)0 >> 31;
			bool flag = obj34 != null;
			object obj35 = (object)(&obj2);
			if (!flag)
			{
				obj35 = obj13;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ r9+20]");
			object obj36 = 0;
			obj = obj35;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v22+C0]");
			object obj37 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v21+18]");
			object obj27 = 0;
			object obj30 = obj27;
			object obj23 = 0;
		}
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v157 @ r10_v1+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		UniTask<T> result = default(UniTask<T>);
		return result;
	}

	private unsafe UniTask<T> ReadAsyncCore(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_002d: Expected O, but got I
		//IL_003d: Expected O, but got I
		//IL_004d: Expected O, but got I
		//IL_005d: Expected O, but got I
		//IL_006d: Expected O, but got I
		//IL_0083: Expected O, but got I
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_026e: Expected O, but got I
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_02bf: Expected O, but got I
		//IL_02cf: Expected O, but got I
		//IL_02df: Expected O, but got I
		//IL_02f5: Expected O, but got I
		//IL_00b4: Expected O, but got I8
		//IL_0338: Expected O, but got I
		//IL_0346: Expected O, but got Ref
		//IL_035b: Expected O, but got I
		//IL_036b: Expected O, but got I
		//IL_0385: Expected O, but got I
		//IL_0395: Expected O, but got I
		//IL_03a5: Expected O, but got I
		//IL_03bb: Expected O, but got I
		//IL_00c6: Expected O, but got I8
		//IL_00db: Expected O, but got I
		//IL_00eb: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_010b: Expected O, but got I
		//IL_011b: Expected O, but got I
		//IL_0130: Expected O, but got Ref
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_016e: Expected O, but got I
		//IL_017e: Expected O, but got I
		//IL_018e: Expected O, but got I
		//IL_019e: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_01be: Expected O, but got I
		//IL_01d3: Expected O, but got Ref
		//IL_01e3: Expected O, but got I
		//IL_01f3: Expected O, but got I
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_04f2: Expected O, but got I
		//IL_0502: Expected O, but got I
		//IL_0512: Expected O, but got I
		//IL_0522: Expected O, but got I
		//IL_0532: Expected O, but got I
		//IL_0547: Expected O, but got Ref
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		//IL_040d: Expected O, but got I
		//IL_042a: Expected O, but got I
		//IL_043a: Expected O, but got I
		//IL_044a: Expected O, but got I
		//IL_045a: Expected O, but got I
		//IL_046a: Expected O, but got I
		//IL_047f: Expected O, but got Ref
		//IL_048f: Expected O, but got I
		//IL_049f: Expected O, but got I
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Expected O, but got Unknown
		//IL_04bd: Expected O, but got I
		//IL_0585: Expected O, but got I
		//IL_0595: Expected O, but got I
		//IL_05a5: Expected O, but got I
		//IL_05b5: Expected O, but got I
		//IL_05c5: Expected O, but got I
		//IL_05da: Expected O, but got Ref
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_0616: Expected O, but got Ref
		//IL_0626: Expected O, but got I
		//IL_0636: Expected O, but got I
		//IL_03ee: Expected O, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v1+C0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ rdx_v1+48]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rax_v3+C0]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v2+28]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
		object obj9 = (nint)0 + (nint)15;
		object obj10 = obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+FC]");
		if ((nint)obj10 <= 0)
		{
			obj9 = 1152921504606846960L;
		}
		object obj11 = obj9 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v4+FC]");
		object obj12 = (nint)0 + (nint)15;
		object obj13 = obj12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v4+FC]");
		if ((nint)obj13 <= 0)
		{
			obj12 = 1152921504606846960L;
		}
		object obj14 = obj12 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v10+C0]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v4+50]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v11+FC]");
		object obj18 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v11+FC]");
		if ((nint)obj18 <= 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj19 = 0;
		object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v17+C0]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v6+38]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v115 @ r10_v1+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v19+C0]");
		object obj24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v8+50]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v20+80]");
		object obj26 = (nint)0 + (nint)32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v22+C0]");
		object obj28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rcx_v10+50]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v23+80]");
		object obj30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v11+50]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rcx_v11+58]");
		object obj32 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj33 = obj32 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v24+28]");
		if ((nint)0 < (nint)0)
		{
			obj33 = this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
			object obj34 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rax_v26+C0]");
			object obj35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v13+50]");
			object obj36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v27+80]");
			object obj37 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v14+70]");
			object obj38 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v14+78]");
			object obj39 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj40 = obj39 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v28+28]");
			if ((nint)0 < (nint)0)
			{
				obj40 = cancellationToken;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
			object obj41 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v30+C0]");
			object obj42 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rcx_v16+50]");
			object obj43 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rax_v31+80]");
			object obj44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v17+10]");
			object obj45 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v17+18]");
			object obj46 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj47 = obj46 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rax_v32+28]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_0608;
			}
			obj47 = 4294967295L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj48 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v34+C0]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rcx_v19+50]");
		object obj50 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rax_v35+80]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj52 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rax_v36+C0]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdx_v19+38]");
		object obj54 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdx_v19+30]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rcx_v20+58]");
		object obj56 = 0;
		object obj57 = obj54 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rax_v37+28]");
		if ((nint)0 >= (nint)0)
		{
			obj57 = obj54;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v385 @ r10_v3] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj58 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rax_v39+C0]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rcx_v23+50]");
		object obj60 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ rax_v40+80]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj62 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v41+C0]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rdx_v21+38]");
		object obj64 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rdx_v21+30]");
		object obj65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rcx_v24+68]");
		object obj66 = 0;
		object obj67 = obj64 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ r9+20]");
		object obj68 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v42+28]");
		if ((nint)0 >= (nint)0)
		{
			obj67 = obj64;
		}
		goto IL_0608;
		IL_0608:
		object obj69 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rax_v43+C0]");
		object obj70 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v25+68]");
		object obj71 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v433 @ r10_v4+10] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		UniTask<T> result = default(UniTask<T>);
		return result;
	}

	public abstract IUniTaskAsyncEnumerable<T> ReadAllAsync(CancellationToken cancellationToken = default(CancellationToken));
}
