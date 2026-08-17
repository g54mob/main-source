using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks.Sources;
using Cpp2ILInjected;
using Unity.IL2CPP.Metadata;

namespace Cysharp.Threading.Tasks;

[Serializable]
public class AsyncReactiveProperty<T> : IAsyncReactiveProperty<T>, IReadOnlyAsyncReactiveProperty<T>, IUniTaskAsyncEnumerable<T>, IDisposable
{
	private sealed class WaitAsyncSource : IUniTaskSource<T>, IUniTaskSource, IValueTaskSource, IValueTaskSource<T>, ITriggerHandler<T>, ITaskPoolNode<WaitAsyncSource>
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9;

			static _003C_003Ec()
			{
				//IL_0030: Expected O, but got I
				//IL_0060: Expected O, but got I
				//IL_0075: Expected O, but got I
				nint num = 0;
				object obj = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource+<>c>)+8]");
				object obj2 = 0;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v62 @ rcx_v5] (should have been resolved before IL gen)");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v15 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource+<>c>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v17+B8]");
				object obj4 = 0;
				obj4 = obj;
			}

			internal int _003C_002Ecctor_003Eb__5_0()
			{
				//IL_0020: Expected O, but got I
				//IL_003e: Expected O, but got I
				//IL_004e: Expected O, but got I
				//IL_0069: Expected O, but got I
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource+<>c>)+30]");
				object obj = 0;
				object obj2 = obj;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource+<>c>)+28]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource+<>c>)+30]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v9+B8]");
				object obj5 = (nint)0 + (nint)8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v48 @ rdi_v1 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: 'this' local not found (operand: rcx)");
				/*Error: End of method reached without returning.*/;
			}
		}

		private static Action<object> cancellationCallback;

		private static TaskPool<WaitAsyncSource> pool;

		private WaitAsyncSource nextNode;

		private AsyncReactiveProperty<T> parent;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private UniTaskCompletionSourceCore<T> core;

		private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002EPrev_003Ek__BackingField;

		private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002ENext_003Ek__BackingField;

		unsafe ref WaitAsyncSource ITaskPoolNode<WaitAsyncSource>.NextNode
		{
			get
			{
				//IL_001e: Expected O, but got I
				//IL_002e: Expected O, but got I
				//IL_003b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0040: Expected Ref, but got Unknown
				nint num = 0;
				IntPtr intPtr = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+50]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+58]");
				ref WaitAsyncSource reference = ref *(WaitAsyncSource*)(0 + this);
				ref WaitAsyncSource result = ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref reference, 16);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
				if ((nint)0 >= (nint)0)
				{
					result = ref reference;
				}
				return ref result;
			}
		}

		ITriggerHandler<T> ITriggerHandler<T>.Prev
		{
			get
			{
				//IL_001e: Expected O, but got I
				//IL_002e: Expected O, but got I
				//IL_003b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0040: Expected O, but got Unknown
				//IL_0049: Unknown result type (might be due to invalid IL or missing references)
				//IL_004e: Expected O, but got Unknown
				nint num = 0;
				IntPtr intPtr = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+F0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+F8]");
				object obj3 = 0 + this;
				object result = obj3 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
				if ((nint)0 >= (nint)0)
				{
					result = obj3;
				}
				return (ITriggerHandler<T>)result;
			}
			set
			{
				//IL_001e: Expected O, but got I
				//IL_002b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0030: Expected O, but got Unknown
				//IL_0040: Expected O, but got I
				//IL_0049: Unknown result type (might be due to invalid IL or missing references)
				//IL_004e: Expected O, but got Unknown
				nint num = 0;
				IntPtr intPtr = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+F8]");
				object obj2 = this + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+F0]");
				object obj3 = 0;
				object obj4 = obj2 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rax_v4+28]");
				if ((nint)0 < (nint)0)
				{
					obj4 = value;
				}
			}
		}

		ITriggerHandler<T> ITriggerHandler<T>.Next
		{
			get
			{
				//IL_001e: Expected O, but got I
				//IL_002e: Expected O, but got I
				//IL_003b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0040: Expected O, but got Unknown
				//IL_0049: Unknown result type (might be due to invalid IL or missing references)
				//IL_004e: Expected O, but got Unknown
				nint num = 0;
				IntPtr intPtr = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+110]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+118]");
				object obj3 = 0 + this;
				object result = obj3 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
				if ((nint)0 >= (nint)0)
				{
					result = obj3;
				}
				return (ITriggerHandler<T>)result;
			}
			set
			{
				//IL_001e: Expected O, but got I
				//IL_002b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0030: Expected O, but got Unknown
				//IL_0040: Expected O, but got I
				//IL_0049: Unknown result type (might be due to invalid IL or missing references)
				//IL_004e: Expected O, but got Unknown
				nint num = 0;
				IntPtr intPtr = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+118]");
				object obj2 = this + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+110]");
				object obj3 = 0;
				object obj4 = obj2 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rax_v4+28]");
				if ((nint)0 < (nint)0)
				{
					obj4 = value;
				}
			}
		}

		static WaitAsyncSource()
		{
			//IL_003c: Expected O, but got I
			//IL_0051: Expected O, but got I
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_00e0: Expected O, but got I
			//IL_00f5: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+10]");
			Action<object> action = new Action<object>(null, (IntPtr)0);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+10]");
			action._002Ector((object)null, (IntPtr)0);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v10+B8]");
			object obj2 = 0;
			obj2 = action;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rbx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+20]");
			Type type;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj4 = default(object);
				object obj3 = obj4 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type type2 = default(Type);
				type = type2;
			}
			else
			{
				type = null;
			}
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v30 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+30]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v32+B8]");
			object obj6 = 0;
			Func<int> getSize = null;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003B10");
			TaskPool.RegisterSizeGetter(type, getSize);
		}

		private WaitAsyncSource()
		{
		}

		public unsafe static IUniTaskSource<T> Create(AsyncReactiveProperty<T> parent, CancellationToken cancellationToken, out short token)
		{
			//IL_03ff: Expected O, but got I
			//IL_0077: Expected O, but got I
			//IL_009d: Expected O, but got I
			//IL_00b8: Expected O, but got I
			//IL_016a: Expected O, but got I
			//IL_0112: Expected O, but got I
			//IL_01ba: Expected O, but got I
			//IL_04e2: Expected O, but got I
			//IL_04f2: Expected O, but got I
			//IL_0502: Unknown result type (might be due to invalid IL or missing references)
			//IL_0507: Expected O, but got Unknown
			//IL_0510: Unknown result type (might be due to invalid IL or missing references)
			//IL_0515: Expected O, but got Unknown
			//IL_0296: Expected O, but got I
			//IL_02bc: Expected O, but got I
			//IL_02cc: Expected O, but got I
			//IL_02dc: Expected O, but got I
			//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Expected O, but got Unknown
			//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Expected O, but got Unknown
			//IL_0210: Expected O, but got I
			//IL_0225: Expected O, but got I
			//IL_0347: Expected O, but got I
			//IL_0375: Expected O, but got I
			//IL_0385: Expected O, but got I
			//IL_0395: Unknown result type (might be due to invalid IL or missing references)
			//IL_039a: Expected O, but got Unknown
			//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a8: Expected O, but got Unknown
			//IL_046c: Expected O, but got I
			//IL_047c: Expected O, but got I
			//IL_048c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0491: Expected O, but got Unknown
			//IL_049a: Unknown result type (might be due to invalid IL or missing references)
			//IL_049f: Expected O, but got Unknown
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [cancellationToken @ rdx (System.Threading.CancellationToken)+20]");
				if ((nint)0 >= (nint)2)
				{
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rax_v134 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+40]");
					object obj = 0;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v229 @ rcx_v97] (should have been resolved before IL gen)");
					IUniTaskSource<T> result = default(IUniTaskSource<T>);
					return result;
				}
			}
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+60]");
			object obj2 = 0;
			nint num4 = 0;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v18 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v20+B8]");
			object obj4 = (nint)0 + (nint)8;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ rcx_v9] (should have been resolved before IL gen)");
			object obj5 = default(object);
			IUniTaskSource<T> uniTaskSource = default(IUniTaskSource<T>);
			IUniTaskSource<T> uniTaskSource2;
			if (obj5 == null)
			{
				nint num6 = 0;
				uniTaskSource = null;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rax_v111 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+70]");
				object obj6 = 0;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v556 @ rcx_v78] (should have been resolved before IL gen)");
				uniTaskSource2 = uniTaskSource;
			}
			else
			{
				IUniTaskSource<T> uniTaskSource3 = default(IUniTaskSource<T>);
				uniTaskSource2 = uniTaskSource3;
			}
			if (uniTaskSource2 != null)
			{
				nint num9 = 0;
				IntPtr intPtr = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rdx_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
				object obj7 = (nint)0 + (nint)96;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
				if (uniTaskSource != null)
				{
					nint num10 = 0;
					IntPtr intPtr2 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v581 @ rdx_v8 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
					object obj8 = --128;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804EC8C0");
					if ((object)cancellationToken != null)
					{
						nint num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v786 @ rax_v77 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+18]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v79+B8]");
						object callback = 0;
						CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, (Action<object>)callback, uniTaskSource);
						if (uniTaskSource == null)
						{
							goto IL_0419;
						}
						nint num12 = 0;
						IntPtr intPtr3 = num12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v920 @ rcx_v59 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rdx_v16+B0]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rdx_v16+B8]");
						object obj12 = 0 + uniTaskSource;
						object obj13 = obj12 - 16;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rax_v86+28]");
						if ((nint)0 >= (nint)0)
						{
							obj13 = obj12;
						}
						obj13 = cancellationTokenRegistration.m_callbackInfo;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v82 (System.Threading.CancellationTokenRegistration)+10]");
						_ = 0;
					}
					nint num13 = 0;
					IntPtr intPtr4 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rcx_v24 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rdx_v12+70]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rdx_v12+78]");
					object obj16 = 0 + uniTaskSource;
					object obj17 = obj16 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ rax_v38+28]");
					if ((nint)0 >= (nint)0)
					{
						obj17 = obj16;
					}
					nint num14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v41 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+88]");
					object obj18 = 0;
					nint num15 = 0;
					nint num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rax_v47 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+78]");
					object obj19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rcx_v31+80]");
					object obj20 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ r9_v4+10]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ r9_v4+18]");
					object obj22 = 0 + obj17;
					object obj23 = obj22 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ rax_v48+28]");
					if ((nint)0 >= (nint)0)
					{
						obj23 = obj22;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v770 @ rcx_v28] (should have been resolved before IL gen)");
					nint num17 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v874 @ rax_v52 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+A8]");
					object obj24 = 0;
					nint num18 = 0;
					nint num19 = 0;
					IntPtr intPtr5 = num19;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ rcx_v38 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
					object obj25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ r8_v10+D0]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ r8_v10+D8]");
					object obj27 = 0 + uniTaskSource;
					object obj28 = obj27 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v941 @ rax_v59+28]");
					if ((nint)0 >= (nint)0)
					{
						obj28 = obj27;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v875 @ rcx_v35] (should have been resolved before IL gen)");
					object obj29 = default(object);
					ref short reference = ref *(short*)obj29;
					return uniTaskSource;
				}
			}
			goto IL_0419;
			IL_0419:
			return (IUniTaskSource<T>)new NullReferenceException();
		}

		private unsafe bool TryReturn()
		{
			//IL_001e: Expected O, but got I
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_0046: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			//IL_01a9: Expected O, but got I
			//IL_01b9: Expected O, but got I
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Expected O, but got Unknown
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d9: Expected O, but got Unknown
			//IL_0353: Expected O, but got I
			//IL_0363: Expected O, but got I
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Expected O, but got Unknown
			//IL_037e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0383: Expected O, but got Unknown
			//IL_0207: Expected O, but got I4
			//IL_022b: Expected O, but got I
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Expected O, but got Unknown
			//IL_0253: Expected O, but got I
			//IL_0263: Expected O, but got I
			//IL_0273: Expected O, but got I
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Expected O, but got Unknown
			//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b8: Expected O, but got Unknown
			//IL_03ce: Expected O, but got I
			//IL_03de: Expected O, but got I
			//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ec: Expected O, but got Unknown
			//IL_02ce: Expected O, but got I
			//IL_02de: Expected O, but got I
			//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Expected O, but got Unknown
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fe: Expected O, but got Unknown
			//IL_041a: Expected O, but got I4
			//IL_0327: Expected O, but got I4
			//IL_00db: Expected O, but got I
			//IL_00eb: Expected O, but got I
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_0146: Expected O, but got I
			//IL_015c: Expected O, but got I
			//IL_0177: Expected O, but got I
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
			object obj = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r9_v1+D8]");
			object obj2 = 0 + this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r9_v1+D0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ r8_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+C0]");
			object obj4 = 0;
			object obj5 = obj2 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rax_v4+28]");
			if ((nint)0 >= (nint)0)
			{
				obj5 = obj2;
			}
			object obj17 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v21 @ r10_v1] (should have been resolved before IL gen)");
				nint num3 = 0;
				IntPtr intPtr2 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v7 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v4+B0]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v4+B8]");
				CancellationTokenRegistration cancellationTokenRegistration = (CancellationTokenRegistration)(0 + this);
				CancellationTokenRegistration cancellationTokenRegistration2 = (CancellationTokenRegistration)(cancellationTokenRegistration - 16);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v8+28]");
				if ((nint)0 >= (nint)0)
				{
					cancellationTokenRegistration2 = cancellationTokenRegistration;
				}
				((CancellationTokenRegistration*)cancellationTokenRegistration2)->Dispose();
				nint num4 = 0;
				IntPtr intPtr3 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v11 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v8+B0]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v8+B8]");
				object obj10 = 0 + this;
				object obj11 = obj10 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v12+28]");
				if ((nint)0 < (nint)0)
				{
					obj11 = 0;
					_ = 0;
					nint num5 = 0;
					IntPtr intPtr4 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v15 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
					object obj12 = 0;
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v7+78]");
					object obj13 = 0 + this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+78]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v17+80]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v7+70]");
					object obj16 = 0;
					obj17 = obj13 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v18+28]");
					if ((nint)0 >= (nint)0)
					{
						obj17 = obj13;
					}
				}
				object obj18 = obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r10_v2+18]");
				object obj19 = obj18 + 0;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r10_v2+10]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+C8]");
				object obj21 = 0;
				object obj22 = obj19 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v20+28]");
				if ((nint)0 >= (nint)0)
				{
					obj22 = obj19;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v204 @ r9_v3] (should have been resolved before IL gen)");
				nint num8 = 0;
				IntPtr intPtr5 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v23 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v18+70]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v18+78]");
				object obj25 = 0 + this;
				object obj26 = obj25 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v24+28]");
				object obj30;
				if ((nint)0 < (nint)0)
				{
					obj26 = 0;
					nint num9 = 0;
					IntPtr intPtr6 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v27 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
					object obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v21+90]");
					object obj28 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v21+98]");
					object obj29 = 0 + this;
					obj30 = obj29 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v28+28]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0130;
					}
				}
				obj30 = 0;
				goto IL_0130;
				IL_0130:
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rcx_v27 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+D0]");
				object obj31 = 0;
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rcx_v28 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+18]");
				object obj32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rax_v38+B8]");
				object obj33 = (nint)0 + (nint)8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v284 @ rax_v35] (should have been resolved before IL gen)");
			}
		}

		private static void CancellationCallback(object state)
		{
			//IL_0086: Expected O, but got I
			//IL_0096: Expected O, but got I
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_0106: Expected O, but got I
			//IL_0129: Expected O, but got I
			nint num = 0;
			bool flag = state == null;
			object obj = null;
			if (!flag)
			{
				bool flag2 = (nint)state != num;
				obj = null;
				if (!flag2)
				{
					obj = state;
				}
				if (obj == null)
				{
					goto IL_0133;
				}
			}
			nint num2 = 0;
			IntPtr intPtr = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v5 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v2+90]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v2+98]");
			object obj4 = 0 + obj;
			object obj5 = obj4 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v11+28]");
			if ((nint)0 >= (nint)0)
			{
				obj5 = obj4;
			}
			object obj6 = obj5;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v14 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+D8]");
			object obj7 = 0;
			object obj8 = obj7;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+D8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v176 @ rbp_v1 (should have been resolved before IL gen)");
			goto IL_0133;
			IL_0133:
			throw new InvalidCastException();
		}

		public unsafe T GetResult(short token)
		{
			//IL_0008: Expected O, but got Ref
			//IL_0018: Expected O, but got I
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_005e: Expected O, but got I
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_00e6: Expected O, but got I
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Expected O, but got Unknown
			//IL_013f: Expected O, but got Ref
			//IL_0152: Expected O, but got Ref
			//IL_017a: Expected O, but got I
			//IL_018a: Expected O, but got I
			//IL_019a: Expected O, but got I
			//IL_01b2: Expected O, but got I
			//IL_01cf: Expected O, but got I
			//IL_01df: Expected O, but got I
			//IL_01ef: Expected O, but got I
			//IL_01ff: Expected O, but got I
			//IL_0212: Expected O, but got Ref
			//IL_022c: Expected O, but got I
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Expected O, but got Unknown
			//IL_008f: Expected O, but got I8
			//IL_026d: Expected O, but got Ref
			//IL_0291: Expected O, but got I
			//IL_02a1: Expected O, but got I
			//IL_02b1: Expected O, but got I
			//IL_02c1: Expected O, but got I
			//IL_02d1: Expected O, but got I
			//IL_02e1: Expected O, but got I
			//IL_00a1: Expected O, but got I8
			object obj2 = default(object);
			object obj = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ r9+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v1+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rcx_v1+E8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rax_v2+FC]");
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rax_v2+FC]");
			object obj6 = (nint)0 + (nint)15;
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rax_v2+FC]");
			if ((nint)obj7 <= 0)
			{
				obj6 = 1152921504606846960L;
			}
			object obj8 = obj6 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rax_v2+FC]");
			object obj9 = (nint)0 + (nint)15;
			object obj10 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ rax_v2+FC]");
			if ((nint)obj10 <= 0)
			{
				obj9 = 1152921504606846960L;
			}
			object obj11 = obj9 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
			object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+A8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v3+20]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v10+C0]");
			object obj16 = 0;
			object obj17 = obj16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v11+80]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r8_v2+D8]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+90]");
			object obj19 = num + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v3+20]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v12+C0]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v10+E0]");
			object obj22 = 0;
			object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r8_v2+D0]");
			object obj24 = 0;
			object obj25 = obj19 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rax_v14+28]");
			if ((nint)0 >= (nint)0)
			{
				obj25 = obj19;
			}
			object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v90 @ r11_v1+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+A8]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v6+20]");
			object obj28 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v17+C0]");
			object obj29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v13+F0]");
			object obj30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v6+20]");
			object obj31 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v19+C0]");
			object obj32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v122 @ rax_v18] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			T result = default(T);
			return result;
		}

		unsafe void IUniTaskSource.GetResult(short token)
		{
			//IL_0008: Expected O, but got Ref
			//IL_0028: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_0080: Expected O, but got Ref
			//IL_009d: Expected O, but got I
			//IL_00b3: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+E8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
			object obj4 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
			if ((nint)obj4 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			nint num2 = 0;
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			obj = obj5;
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+F8]");
			object obj6 = 0;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+F8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v46 @ r10_v1+10] (should have been resolved before IL gen)");
		}

		public void OnCompleted(Action<object> continuation, object state, short token)
		{
			//IL_0010: Expected O, but got I
			//IL_0020: Expected O, but got I
			//IL_0038: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Expected O, but got Unknown
			//IL_006a: Expected O, but got I
			//IL_007a: Expected O, but got I
			//IL_008a: Expected O, but got I
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v1+C0]");
			object obj2 = 0;
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rax_v2+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ stack_28+20]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r10_v2+D8]");
			object obj6 = 0 + this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v3+C0]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r10_v2+D0]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rcx_v1+100]");
			object obj9 = 0;
			object obj10 = obj6 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v4+28]");
			if ((nint)0 >= (nint)0)
			{
			}
			object obj11 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v40 @ rax_v6 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}

		public UniTaskStatus GetStatus(short token)
		{
			//IL_0016: Expected O, but got I
			//IL_003c: Expected O, but got I
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_0064: Expected O, but got I
			//IL_0074: Expected O, but got I
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+108]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			IntPtr intPtr = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v4 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9_v3+D8]");
			object obj4 = 0 + this;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r9_v3+D0]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+108]");
			object obj6 = 0;
			object obj7 = obj4 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v6+28]");
			if ((nint)0 >= (nint)0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ r11_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}

		public UniTaskStatus UnsafeGetStatus()
		{
			//IL_0016: Expected O, but got I
			//IL_003c: Expected O, but got I
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_0064: Expected O, but got I
			//IL_0074: Expected O, but got I
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+110]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			IntPtr intPtr = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rax_v4 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8_v3+D8]");
			object obj4 = 0 + this;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ r8_v3+D0]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+110]");
			object obj6 = 0;
			object obj7 = obj4 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v6+28]");
			if ((nint)0 >= (nint)0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ r10_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}

		public void OnCanceled(CancellationToken cancellationToken)
		{
			//IL_001e: Expected O, but got I
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0046: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r9_v2+D8]");
			object obj2 = 0 + this;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r9_v2+D0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+118]");
			object obj4 = 0;
			object obj5 = obj2 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v4+28]");
			if ((nint)0 >= (nint)0)
			{
				obj5 = obj2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ r11_v1] (should have been resolved before IL gen)");
		}

		public void OnCompleted()
		{
			//IL_0023: Expected O, but got I
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected O, but got Unknown
			//IL_004b: Expected O, but got I
			//IL_005b: Expected O, but got I
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v4 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
			object obj = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v1+D8]");
			object obj2 = 0 + this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rdx_v1+D0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+118]");
			object obj4 = 0;
			object obj5 = obj2 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v6+28]");
			if ((nint)0 >= (nint)0)
			{
				obj5 = obj2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v56 @ r10_v1] (should have been resolved before IL gen)");
		}

		public void OnError(Exception ex)
		{
			//IL_001e: Expected O, but got I
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0046: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			nint num = 0;
			IntPtr intPtr = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r9_v2+D8]");
			object obj2 = 0 + this;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r9_v2+D0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+120]");
			object obj4 = 0;
			object obj5 = obj2 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v4+28]");
			if ((nint)0 >= (nint)0)
			{
				obj5 = obj2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ r11_v1] (should have been resolved before IL gen)");
		}

		public unsafe void OnNext(T value)
		{
			//IL_0008: Expected O, but got Ref
			//IL_0028: Expected O, but got I
			//IL_003e: Expected O, but got I
			//IL_009c: Expected O, but got Ref
			//IL_00a4: Expected O, but got Ref
			//IL_00ba: Expected O, but got I
			//IL_00d0: Expected O, but got I
			//IL_010d: Expected O, but got I
			//IL_0123: Expected O, but got I
			//IL_013d: Expected O, but got Ref
			//IL_016e: Expected O, but got I
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0196: Expected O, but got I
			//IL_01a6: Expected O, but got I
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Expected O, but got Unknown
			//IL_01e7: Expected O, but got Ref
			//IL_01fd: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+E8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
			object obj4 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rax_v2+FC]");
			object obj5 = default(object);
			T val;
			if ((nint)obj4 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
				obj5 = (object)(&obj2);
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+E8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v8+28]");
				object obj7 = (nint)0 >> 31;
				if (obj7 == null)
				{
					goto IL_00ed;
				}
			}
			val = value;
			goto IL_00ed;
			IL_00ed:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rcx_v5 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+E8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v11+28]");
			object obj9 = (nint)0 >> 31;
			bool flag = obj9 != null;
			object obj10 = (object)(&obj2);
			if (!flag)
			{
				obj10 = obj5;
			}
			nint num4 = 0;
			IntPtr intPtr = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v13 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>>)+80]");
			object obj11 = 0;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v3+D8]");
			object obj12 = 0 + this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v3+D0]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+128]");
			object obj14 = 0;
			object obj15 = obj12 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v15+28]");
			if ((nint)0 >= (nint)0)
			{
				obj15 = obj12;
			}
			object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WaitAsyncSource>)+128]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v93 @ r10_v1+10] (should have been resolved before IL gen)");
		}
	}

	private sealed class WithoutCurrentEnumerable(AsyncReactiveProperty<T> parent) : IUniTaskAsyncEnumerable<T>
	{
		private readonly AsyncReactiveProperty<T> parent = parent;

		public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			//IL_0026: Expected O, but got I
			nint num = 0;
			IUniTaskAsyncEnumerator<T> result = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+WithoutCurrentEnumerable>)+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v43 @ r10_v1] (should have been resolved before IL gen)");
			return result;
		}
	}

	private sealed class Enumerator : MoveNextSource, IUniTaskAsyncEnumerator<T>, IUniTaskAsyncDisposable, ITriggerHandler<T>
	{
		private static Action<object> cancellationCallback;

		private readonly AsyncReactiveProperty<T> parent;

		private readonly CancellationToken cancellationToken;

		private readonly CancellationTokenRegistration cancellationTokenRegistration;

		private T value;

		private bool isDisposed;

		private bool firstCall;

		private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002EPrev_003Ek__BackingField;

		private ITriggerHandler<T> _003CCysharp_002EThreading_002ETasks_002EITriggerHandler_003CT_003E_002ENext_003Ek__BackingField;

		public unsafe T Current
		{
			get
			{
				//IL_0008: Expected O, but got Ref
				//IL_0018: Expected O, but got I
				//IL_0037: Expected O, but got I
				//IL_0047: Expected O, but got I
				//IL_005d: Expected O, but got I
				//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Expected O, but got Unknown
				//IL_00c8: Expected O, but got I
				//IL_00d8: Expected O, but got I
				//IL_00e8: Expected O, but got I
				//IL_00f8: Expected O, but got I
				//IL_0108: Expected O, but got I
				//IL_0115: Unknown result type (might be due to invalid IL or missing references)
				//IL_011a: Expected O, but got Unknown
				//IL_0123: Unknown result type (might be due to invalid IL or missing references)
				//IL_0128: Expected O, but got Unknown
				//IL_008e: Expected O, but got I8
				object obj2 = default(object);
				object obj = (object)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v1+C0]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9_v1+38]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
				object obj6 = (nint)0 + (nint)15;
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
				if ((nint)obj7 <= 0)
				{
					obj6 = 1152921504606846960L;
				}
				object obj8 = obj6 & -16;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8+20]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v5+C0]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v1+8]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v6+80]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+90]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+98]");
				object obj14 = 0 + this;
				object obj15 = obj14 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v7+28]");
				if ((nint)0 >= (nint)0)
				{
					obj15 = obj14;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				T result = default(T);
				return result;
			}
		}

		ITriggerHandler<T> ITriggerHandler<T>.Prev
		{
			get
			{
				//IL_0016: Expected O, but got I
				//IL_0026: Expected O, but got I
				//IL_0036: Expected O, but got I
				//IL_0043: Unknown result type (might be due to invalid IL or missing references)
				//IL_0048: Expected O, but got Unknown
				//IL_0051: Unknown result type (might be due to invalid IL or missing references)
				//IL_0056: Expected O, but got Unknown
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2+80]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+F0]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+F8]");
				object obj4 = 0 + this;
				object result = obj4 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
				if ((nint)0 >= (nint)0)
				{
					result = obj4;
				}
				return (ITriggerHandler<T>)result;
			}
			set
			{
				//IL_0016: Expected O, but got I
				//IL_0026: Expected O, but got I
				//IL_0033: Unknown result type (might be due to invalid IL or missing references)
				//IL_0038: Expected O, but got Unknown
				//IL_0048: Expected O, but got I
				//IL_0051: Unknown result type (might be due to invalid IL or missing references)
				//IL_0056: Expected O, but got Unknown
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2+80]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+F8]");
				object obj3 = this + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+F0]");
				object obj4 = 0;
				object obj5 = obj3 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rax_v4+28]");
				if ((nint)0 < (nint)0)
				{
					obj5 = value;
				}
			}
		}

		ITriggerHandler<T> ITriggerHandler<T>.Next
		{
			get
			{
				//IL_0016: Expected O, but got I
				//IL_0026: Expected O, but got I
				//IL_0036: Expected O, but got I
				//IL_0043: Unknown result type (might be due to invalid IL or missing references)
				//IL_0048: Expected O, but got Unknown
				//IL_0051: Unknown result type (might be due to invalid IL or missing references)
				//IL_0056: Expected O, but got Unknown
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2+80]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+110]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rdx_v2+118]");
				object obj4 = 0 + this;
				object result = obj4 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v3+28]");
				if ((nint)0 >= (nint)0)
				{
					result = obj4;
				}
				return (ITriggerHandler<T>)result;
			}
			set
			{
				//IL_0016: Expected O, but got I
				//IL_0026: Expected O, but got I
				//IL_0033: Unknown result type (might be due to invalid IL or missing references)
				//IL_0038: Expected O, but got Unknown
				//IL_0048: Expected O, but got I
				//IL_0051: Unknown result type (might be due to invalid IL or missing references)
				//IL_0056: Expected O, but got Unknown
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2+80]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+118]");
				object obj3 = this + 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+110]");
				object obj4 = 0;
				object obj5 = obj3 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rax_v4+28]");
				if ((nint)0 < (nint)0)
				{
					obj5 = value;
				}
			}
		}

		public Enumerator(AsyncReactiveProperty<T> parent, CancellationToken cancellationToken, bool publishCurrentValue)
		{
			//IL_01f6: Expected O, but got I
			//IL_0206: Expected O, but got I
			//IL_0216: Expected O, but got I
			//IL_0226: Expected O, but got I
			//IL_0236: Expected O, but got I
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Expected O, but got Unknown
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Expected O, but got Unknown
			//IL_0286: Expected O, but got I
			//IL_0296: Expected O, but got I
			//IL_02a6: Expected O, but got I
			//IL_02b6: Expected O, but got I
			//IL_02c6: Expected O, but got I
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Expected O, but got Unknown
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e6: Expected O, but got Unknown
			//IL_0316: Expected O, but got I
			//IL_0326: Expected O, but got I
			//IL_0336: Expected O, but got I
			//IL_0346: Expected O, but got I
			//IL_0356: Expected O, but got I
			//IL_0363: Unknown result type (might be due to invalid IL or missing references)
			//IL_0368: Expected O, but got Unknown
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_0376: Expected O, but got Unknown
			//IL_03e6: Expected O, but got I4
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			//IL_003d: Expected O, but got I
			//IL_004d: Expected O, but got I
			//IL_005d: Expected O, but got I
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0082: Expected O, but got I
			//IL_0092: Expected O, but got I
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_0109: Expected O, but got I
			//IL_0119: Expected O, but got I
			//IL_0129: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_0185: Expected O, but got I
			//IL_0195: Expected O, but got I
			//IL_01a5: Expected O, but got I
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Expected O, but got Unknown
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
				obj7 = parent;
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
				obj14 = cancellationToken;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v10+C0]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v8+8]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v11+80]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v9+D0]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v9+D8]");
			object obj20 = 0 + this;
			object obj21 = obj20 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v12+28]");
			if ((nint)0 < (nint)0)
			{
				obj21 = publishCurrentValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rax_v14+C0]");
				object obj23 = 0;
				object obj24 = obj23;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v15+80]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rax_v16+C0]");
				object obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdx_v10+18]");
				object obj28 = 0 + parent;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdx_v10+10]");
				object obj29 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v12+18]");
				object obj30 = 0;
				object obj31 = obj28 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v17+28]");
				if ((nint)0 >= (nint)0)
				{
					obj31 = obj28;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v305 @ r10_v1] (should have been resolved before IL gen)");
			if ((object)cancellationToken != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
				object obj32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rax_v25+C0]");
				object obj33 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rcx_v20+30]");
				object obj34 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v27+B8]");
				object callback = 0;
				CancellationTokenRegistration cancellationTokenRegistration = CancellationTokenExtensions.RegisterWithoutCaptureExecutionContext(cancellationToken, (Action<object>)callback, this);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ stack_28+20]");
				object obj35 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v31+C0]");
				object obj36 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rcx_v24+8]");
				object obj37 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ rax_v32+80]");
				object obj38 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v25+70]");
				object obj39 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v25+78]");
				object obj40 = 0 + this;
				object obj41 = obj40 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ rax_v33+28]");
				if ((nint)0 < (nint)0)
				{
					obj41 = cancellationTokenRegistration.m_callbackInfo;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rax_v30 (System.Threading.CancellationTokenRegistration)+10]");
					_ = 0;
				}
			}
		}

		public unsafe UniTask<bool> MoveNextAsync()
		{
			//IL_0008: Expected O, but got Ref
			//IL_026b: Expected O, but got I
			//IL_027b: Expected O, but got I
			//IL_028b: Expected O, but got I
			//IL_02a1: Expected O, but got I
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			//IL_032c: Expected O, but got Unknown
			//IL_0346: Expected O, but got I
			//IL_0356: Expected O, but got I
			//IL_0366: Expected O, but got I
			//IL_0376: Expected O, but got I
			//IL_0386: Expected O, but got I
			//IL_039b: Expected O, but got I
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a9: Expected O, but got Unknown
			//IL_0029: Expected O, but got I8
			//IL_0083: Expected O, but got I
			//IL_0093: Expected O, but got I
			//IL_00a3: Expected O, but got I
			//IL_00b3: Expected O, but got I
			//IL_00c3: Expected O, but got I
			//IL_00d8: Expected O, but got I
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_02ee: Expected O, but got I4
			//IL_0116: Expected O, but got I
			//IL_0126: Expected O, but got I
			//IL_0136: Expected O, but got I
			//IL_0146: Expected O, but got I
			//IL_0156: Expected O, but got I
			//IL_016b: Expected O, but got I
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Expected O, but got Unknown
			//IL_0049: Expected O, but got I
			//IL_0060: Expected O, but got I
			//IL_01bb: Expected O, but got I
			//IL_01c9: Expected O, but got Ref
			//IL_01de: Expected O, but got I
			//IL_01ee: Expected O, but got I
			//IL_0208: Expected O, but got I
			//IL_0218: Expected O, but got I
			//IL_0228: Expected O, but got I
			//IL_023e: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ r8+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v2+38]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3+FC]");
			object obj6 = (nint)0 + (nint)15;
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v3+FC]");
			if ((nint)obj7 <= 0)
			{
				obj6 = 1152921504606846960L;
			}
			object obj8 = obj6 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ r8+20]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v6+C0]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v6+8]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v7+80]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v7+D0]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v7+D8]");
			nint num = default(nint);
			object obj14 = 0 + num;
			object obj15 = obj14 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v8+28]");
			if ((nint)0 >= (nint)0)
			{
				obj15 = obj14;
			}
			if (obj15 == null)
			{
				UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(num + 16);
				((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->Reset();
				_ = 0;
				Enumerator enumerator = (Enumerator)num;
				_ = 0;
				_ = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ r8+20]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v11+C0]");
				object obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rcx_v11+8]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v12+80]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v12+D0]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v12+D8]");
				object obj21 = 0 + num;
				object obj22 = obj21 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v13+28]");
				if ((nint)0 < (nint)0)
				{
					obj22 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ r8+20]");
				object obj23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rax_v15+C0]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v14+8]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v16+80]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v15+30]");
				object obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rcx_v15+38]");
				object obj28 = 0 + num;
				object obj29 = obj28 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v17+28]");
				if ((nint)0 >= (nint)0)
				{
					obj29 = obj28;
				}
				if (obj29 == null)
				{
					return (UniTask<bool>)new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ r8+20]");
				object obj30 = 0;
				object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
				_ = ref obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rax_v19+C0]");
				object obj32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rcx_v18+40]");
				object obj33 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v271 @ r10_v2+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ r8+20]");
				object obj34 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rax_v21+C0]");
				object obj35 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v385 @ rcx_v20+8]");
				object obj36 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rax_v22+80]");
				object obj37 = --128;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
				Enumerator enumerator = (Enumerator)CompletedTasks.True;
			}
			return (UniTask<bool>)this;
		}

		public unsafe UniTask DisposeAsync()
		{
			//IL_013a: Expected native int or pointer, but got O
			//IL_0155: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Expected O, but got Unknown
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Expected O, but got Unknown
			//IL_01bf: Expected native int or pointer, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Expected O, but got Unknown
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_01d2: Expected O, but got I4
			//IL_009e: Expected O, but got I
			//IL_00ae: Expected O, but got I
			//IL_00be: Expected O, but got I
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected O, but got Unknown
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Expected O, but got Unknown
			//IL_01fe: Expected O, but got I
			//IL_020e: Expected O, but got I
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Expected O, but got Unknown
			//IL_023e: Expected O, but got I
			//IL_024e: Expected O, but got I
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Expected O, but got Unknown
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_0296: Expected O, but got Unknown
			//IL_02ac: Expected O, but got I
			//IL_02bc: Expected O, but got I
			//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ca: Expected O, but got Unknown
			UniTask uniTask = default(UniTask);
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v3+80]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v3+B0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v3+B8]");
			object obj4 = 0 + this;
			object obj5 = obj4 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v4+28]");
			if ((nint)0 >= (nint)0)
			{
				obj5 = obj4;
			}
			if (obj5 == null)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v8+80]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8+B0]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v8+B8]");
				object obj9 = 0 + this;
				object obj10 = obj9 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v9+28]");
				if ((nint)0 < (nint)0)
				{
					obj10 = 1;
				}
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v12+80]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v13+50]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v13+58]");
				object obj14 = 0 + this;
				UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
				object obj15 = obj14 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v13+28]");
				if ((nint)0 >= (nint)0)
				{
					obj15 = obj14;
				}
				bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetCanceled((CancellationToken)obj15);
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v15 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
				object obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v16+80]");
				object obj17 = 0;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rdx_v10+38]");
				object obj18 = 0 + this;
				IntPtr intPtr = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v18 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>>)+80]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rdx_v10+30]");
				object obj20 = 0;
				object obj21 = obj18 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v19+28]");
				if ((nint)0 >= (nint)0)
				{
					obj21 = obj18;
				}
				object obj22 = obj21;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r10_v2+18]");
				object obj23 = obj22 + 0;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r10_v2+10]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rcx_v18 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+48]");
				object obj25 = 0;
				object obj26 = obj23 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v21+28]");
				if ((nint)0 >= (nint)0)
				{
					obj26 = obj23;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v91 @ r9_v2] (should have been resolved before IL gen)");
			}
			System.Runtime.CompilerServices.Unsafe.Write(&((UniTask*)(nint)uniTask)->source, null);
			return uniTask;
		}

		public unsafe void OnNext(T value)
		{
			//IL_0008: Expected O, but got Ref
			//IL_0040: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_00ef: Expected O, but got Ref
			//IL_0105: Expected O, but got I
			//IL_011b: Expected O, but got I
			//IL_0095: Expected O, but got I
			//IL_00ab: Expected O, but got I
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected O, but got Unknown
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+38]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3+FC]");
			object obj4 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3+FC]");
			if ((nint)obj4 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				T val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+38]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v9+28]");
				object obj6 = (nint)0 >> 31;
				if (obj6 != null)
				{
					val = value;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v6 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v12+80]");
			object obj8 = --128;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetResult(result: true);
		}

		public unsafe void OnCanceled(CancellationToken cancellationToken)
		{
			//IL_0016: Expected O, but got I
			//IL_002f: Expected O, but got Ref
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rdx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+50]");
			object obj = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3 @ rax_v2] (should have been resolved before IL gen)");
			object obj2 = default(object);
			UniTaskExtensions.Forget((UniTask)(&obj2));
		}

		public unsafe void OnCompleted()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetResult(result: false);
		}

		public unsafe void OnError(Exception ex)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			UniTaskCompletionSourceCore<bool> uniTaskCompletionSourceCore = (UniTaskCompletionSourceCore<bool>)(this + 16);
			bool flag = ((UniTaskCompletionSourceCore<bool>*)uniTaskCompletionSourceCore)->TrySetException(ex);
		}

		private unsafe static void CancellationCallback(object state)
		{
			//IL_0081: Expected O, but got I
			//IL_00e8: Expected O, but got Ref
			nint num = 0;
			if (state != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
				bool flag = state != null;
				object obj = null;
				if (!flag)
				{
					obj = state;
				}
				if (obj == null)
				{
					goto IL_0132;
				}
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v13 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+50]");
				object obj2 = 0;
				nint num3 = 0;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v19 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+8]");
				bool flag2 = state != null;
				object obj3 = null;
				if (!flag2)
				{
					obj3 = state;
				}
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v164 @ rcx_v10] (should have been resolved before IL gen)");
					object obj4 = default(object);
					UniTaskExtensions.Forget((UniTask)(&obj4));
					return;
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
			}
			InvalidCastException ex2 = new InvalidCastException();
			goto IL_0132;
			IL_0132:
			throw new InvalidCastException();
		}

		static Enumerator()
		{
			//IL_003c: Expected O, but got I
			//IL_0051: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+58]");
			Action<object> action = new Action<object>(null, (IntPtr)0);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+58]");
			action._002Ector((object)null, (IntPtr)0);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1+Enumerator>)+30]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v10+B8]");
			object obj2 = 0;
			obj2 = action;
		}
	}

	private TriggerEvent<T> triggerEvent;

	private T latestValue;

	private static bool isValueType;

	public unsafe T Value
	{
		get
		{
			//IL_0008: Expected O, but got Ref
			//IL_0018: Expected O, but got I
			//IL_0037: Expected O, but got I
			//IL_0047: Expected O, but got I
			//IL_005d: Expected O, but got I
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected O, but got Unknown
			//IL_00c8: Expected O, but got I
			//IL_00d8: Expected O, but got I
			//IL_00f0: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_008e: Expected O, but got I8
			object obj2 = default(object);
			object obj = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v1+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r9_v1+8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
			object obj6 = (nint)0 + (nint)15;
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v2+FC]");
			if ((nint)obj7 <= 0)
			{
				obj6 = 1152921504606846960L;
			}
			object obj8 = obj6 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8+20]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v5+C0]");
			object obj10 = 0;
			object obj11 = obj10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v6+80]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+30]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v2+38]");
			object obj14 = 0 + this;
			object obj15 = obj14 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v7+28]");
			if ((nint)0 >= (nint)0)
			{
				obj15 = obj14;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			T result = default(T);
			return result;
		}
		set
		{
			//IL_0008: Expected O, but got Ref
			//IL_002d: Expected O, but got I
			//IL_0043: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_00ed: Expected O, but got Ref
			//IL_00f5: Expected O, but got Ref
			//IL_010b: Expected O, but got I
			//IL_0121: Expected O, but got I
			//IL_016c: Expected O, but got I
			//IL_0184: Expected O, but got Ref
			//IL_019a: Expected O, but got I
			//IL_01b0: Expected O, but got I
			//IL_01ed: Expected O, but got I
			//IL_0203: Expected O, but got I
			//IL_021d: Expected O, but got Ref
			//IL_024e: Expected O, but got I
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Expected O, but got Unknown
			//IL_0276: Expected O, but got I
			//IL_0286: Expected O, but got I
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Expected O, but got Unknown
			//IL_02c7: Expected O, but got Ref
			//IL_02dd: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
			object obj4 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
			object obj6 = default(object);
			T val;
			if ((nint)obj4 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
				object obj5 = (nint)0 + (nint)15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
				if ((nint)obj5 <= 0)
				{
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
				obj6 = (object)(&obj2);
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v12+28]");
				object obj8 = (nint)0 >> 31;
				if (obj8 == null)
				{
					goto IL_013e;
				}
			}
			val = value;
			goto IL_013e;
			IL_013e:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num3 = 0;
			IntPtr intPtr = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v15 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>>)+80]");
			object obj9 = (nint)0 + (nint)32;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
			T val2 = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v18+28]");
			object obj11 = (nint)0 >> 31;
			if (obj11 != null)
			{
				val2 = value;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v21+28]");
			object obj13 = (nint)0 >> 31;
			bool flag = obj13 != null;
			object obj14 = (object)(&obj2);
			if (!flag)
			{
				obj14 = obj6;
			}
			nint num6 = 0;
			IntPtr intPtr2 = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v23 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>>)+80]");
			object obj15 = 0;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v7+18]");
			object obj16 = 0 + this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v7+10]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v16 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+18]");
			object obj18 = 0;
			object obj19 = obj16 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v25+28]");
			if ((nint)0 >= (nint)0)
			{
				obj19 = obj16;
			}
			object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v17 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+18]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v151 @ r10_v1+10] (should have been resolved before IL gen)");
		}
	}

	public unsafe AsyncReactiveProperty(T value)
	{
		//IL_0008: Expected O, but got Ref
		//IL_002d: Expected O, but got I
		//IL_0043: Expected O, but got I
		//IL_0087: Expected O, but got Ref
		//IL_009d: Expected O, but got I
		//IL_00b3: Expected O, but got I
		//IL_00fe: Expected O, but got I
		//IL_0126: Expected O, but got I
		//IL_0136: Expected O, but got I
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_017f: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ r9_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
		object obj4 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rax_v2+FC]");
		T val;
		if ((nint)obj4 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			val = (T)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v8+28]");
			object obj6 = (nint)0 >> 31;
			if (obj6 == null)
			{
				goto IL_00d0;
			}
		}
		val = value;
		goto IL_00d0;
		IL_00d0:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		nint num3 = 0;
		IntPtr intPtr = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v11 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>>)+80]");
		object obj7 = (nint)0 + (nint)32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
		nint num4 = 0;
		IntPtr intPtr2 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v14 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>>)+80]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v8+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v8+18]");
		object obj10 = 0 + this;
		object obj11 = obj10 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v15+28]");
		if ((nint)0 >= (nint)0)
		{
		}
		obj11 = 0;
		_ = 0;
	}

	public IUniTaskAsyncEnumerable<T> WithoutCurrent()
	{
		//IL_0026: Expected O, but got I
		nint num = 0;
		IUniTaskAsyncEnumerable<T> result = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+30]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v37 @ r9_v1] (should have been resolved before IL gen)");
		return result;
	}

	public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken)
	{
		//IL_0026: Expected O, but got I
		nint num = 0;
		IUniTaskAsyncEnumerator<T> result = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+48]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v43 @ r10_v1] (should have been resolved before IL gen)");
		return result;
	}

	public void Dispose()
	{
		//IL_001e: Expected O, but got I
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0046: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		nint num = 0;
		IntPtr intPtr = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ rax_v2 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>>)+80]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+18]");
		object obj2 = 0 + this;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ r8_v2+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rcx_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+58]");
		object obj4 = 0;
		object obj5 = obj2 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v4+28]");
		if ((nint)0 >= (nint)0)
		{
			obj5 = obj2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v11 @ r9_v1] (should have been resolved before IL gen)");
	}

	public unsafe static implicit operator T(AsyncReactiveProperty<T> value)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_0037: Expected O, but got I
		//IL_0047: Expected O, but got I
		//IL_005d: Expected O, but got I
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_008e: Expected O, but got I8
		//IL_00a3: Expected O, but got I
		//IL_00b8: Expected O, but got I
		//IL_00c8: Expected O, but got I
		//IL_00d8: Expected O, but got I
		//IL_00ed: Expected O, but got I
		//IL_00fb: Expected O, but got Ref
		//IL_0110: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2+C0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v3+8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2+FC]");
		object obj6 = (nint)0 + (nint)15;
		object obj7 = obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2+FC]");
		if ((nint)obj7 <= 0)
		{
			obj6 = 1152921504606846960L;
		}
		object obj8 = obj6 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		if (value != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8+20]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v8+C0]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v9+60]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8+20]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v11+C0]");
			object obj13 = 0;
			object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v12+60]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v89 @ r14_v1+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			T result = default(T);
			return result;
		}
		return (T)new NullReferenceException();
	}

	public unsafe override string ToString()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0023: Expected O, but got I
		//IL_0039: Expected O, but got I
		//IL_0054: Expected O, but got I
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_04e2: Expected O, but got I
		//IL_008f: Expected O, but got I
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_050c: Expected O, but got I
		//IL_054b: Expected O, but got I
		//IL_0553: Expected O, but got Ref
		//IL_00cf: Expected O, but got I
		//IL_0592: Expected O, but got I
		//IL_059a: Expected O, but got Ref
		//IL_00e4: Expected O, but got I
		//IL_05e3: Expected O, but got I
		//IL_0431: Expected O, but got I
		//IL_044e: Expected O, but got I
		//IL_045e: Expected O, but got I
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_04b8: Expected O, but got I
		//IL_0133: Expected O, but got I
		//IL_0149: Expected O, but got I
		//IL_028f: Expected O, but got I
		//IL_02ac: Expected O, but got I
		//IL_02bc: Expected O, but got I
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_0204: Expected O, but got I
		//IL_0221: Expected O, but got I
		//IL_0231: Expected O, but got I
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_01a1: Expected O, but got I
		//IL_0312: Expected O, but got I
		//IL_0328: Expected O, but got I
		//IL_03fa: Expected O, but got I
		//IL_0685: Expected O, but got Ref
		//IL_0364: Expected O, but got Ref
		//IL_0388: Expected O, but got I
		//IL_039f: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ r8_v1 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
		object obj3 = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ r8_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rax_v5+FC]");
		object obj5 = (nint)0 + (nint)16;
		object obj6 = obj5 + 15;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v3 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
			object obj7 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v15+FC]");
		object obj8 = (nint)0 + (nint)16;
		object obj9 = obj8 + 15;
		object obj12 = default(object);
		object obj14 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			object obj10 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			if ((nint)obj10 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			object obj11 = (nint)0 + (nint)15;
			obj12 = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			if ((nint)obj11 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			object obj13 = (nint)0 + (nint)15;
			obj14 = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			if ((nint)obj13 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			object obj15 = (nint)0 + (nint)15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rax_v2+FC]");
			if ((nint)obj15 <= 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		}
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rcx_v11 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+68]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v47+B8]");
		object obj17 = 0;
		bool flag;
		if (obj17 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rcx_v23 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rdx_v9+28]");
			object obj19 = (nint)0 >> 31;
			if (obj19 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rdx_v9+60]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rdx_v9+135]");
					object obj20 = (nint)0 & (nint)8;
					if (obj20 != null)
					{
						flag = obj12 == null;
						goto IL_061b;
					}
				}
				goto IL_01e6;
			}
			flag = obj12 == null;
			goto IL_061b;
		}
		nint num6 = 0;
		IntPtr intPtr = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v51 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>>)+80]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+40]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v15+38]");
		object obj22 = num7 + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v15+30]");
		object obj23 = 0;
		object obj24 = obj22 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v53+28]");
		if ((nint)0 >= (nint)0)
		{
			obj24 = obj22;
		}
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB8900");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+48]");
		return (string)0;
		IL_01e6:
		nint num9 = 0;
		IntPtr intPtr2 = num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rax_v87 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>>)+80]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+40]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rcx_v38+38]");
		object obj26 = num10 + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rcx_v38+30]");
		object obj27 = 0;
		object obj28 = obj26 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rax_v89+28]");
		if ((nint)0 >= (nint)0)
		{
			obj28 = obj26;
		}
		goto IL_03d5;
		IL_03d5:
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB8900");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+50]");
		return (string)0;
		IL_0667:
		bool flag3;
		bool flag2 = !flag3;
		bool flag4 = !flag2;
		obj28 = (object)(&obj2);
		if (flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			return null;
		}
		goto IL_03d5;
		IL_061b:
		if (flag)
		{
			nint num12 = 0;
			IntPtr intPtr3 = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rax_v67 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>>)+80]");
			object obj29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ rcx_v25+38]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+40]");
			object obj30 = num13 + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ rcx_v25+30]");
			object obj31 = 0;
			object obj32 = obj30 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rax_v68+28]");
			if ((nint)0 >= (nint)0)
			{
				obj32 = obj30;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rcx_v29 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+8]");
			object obj33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rdx_v14+28]");
			object obj34 = (nint)0 >> 31;
			if (obj34 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rdx_v14+60]");
				bool flag5 = (nint)0 == 0;
				obj28 = (object)(&obj2);
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rdx_v14+135]");
					object obj35 = (nint)0 & (nint)8;
					bool flag6 = obj35 == null;
					obj28 = (object)(&obj2);
					if (!flag6)
					{
						flag3 = obj14 == null;
						goto IL_0667;
					}
				}
				goto IL_03d5;
			}
			flag3 = obj14 == null;
			goto IL_0667;
		}
		goto IL_01e6;
	}

	public unsafe UniTask<T> WaitAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_0032: Expected O, but got I
		//IL_0042: Expected O, but got I
		//IL_0058: Expected O, but got I
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0089: Expected O, but got I8
		//IL_00a3: Expected O, but got I
		//IL_00b1: Expected O, but got Ref
		//IL_00c1: Expected O, but got I
		//IL_00d1: Expected O, but got I
		//IL_00e1: Expected O, but got I
		//IL_00f1: Expected O, but got I
		//IL_0115: Expected O, but got I
		//IL_0125: Expected O, but got I
		UniTask<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType> uniTask = default(UniTask<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>);
		object obj = (object)(&uniTask);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r9+20]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rax_v1+C0]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rdx_v1+90]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
		object obj5 = (nint)0 + (nint)15;
		object obj6 = obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v2+FC]");
		if ((nint)obj6 <= 0)
		{
			obj5 = 1152921504606846960L;
		}
		object obj7 = obj5 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r9+20]");
		object obj8 = 0;
		object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref uniTask, 56));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v10+C0]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v4+78]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r9+20]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v12+C0]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v89 @ rax_v11] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ r9+20]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v8+C0]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		IUniTaskSource<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType> source = default(IUniTaskSource<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>);
		uniTask = new UniTask<Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType>(source, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		UniTask<T> result = default(UniTask<T>);
		return result;
	}

	static AsyncReactiveProperty()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0069: Expected O, but got I
		//IL_007e: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		object obj3 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v129 @ rdx_v3+5F8] (should have been resolved before IL gen)");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v12 (Il2CppRgctx<Cysharp.Threading.Tasks.AsyncReactiveProperty`1>)+68]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v14+B8]");
		object obj6 = 0;
		object obj7 = default(object);
		obj6 = obj7;
	}
}
