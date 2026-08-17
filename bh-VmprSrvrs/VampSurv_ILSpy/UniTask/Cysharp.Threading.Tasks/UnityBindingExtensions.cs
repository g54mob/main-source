using System;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Cysharp.Threading.Tasks;

public static class UnityBindingExtensions
{
	[StructLayout((LayoutKind)3)]
	private struct _003CBindToCore_003Ed__12<TSource, TObject> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public IUniTaskAsyncEnumerable<TSource> source;

		public CancellationToken cancellationToken;

		public bool rebindOnError;

		public Action<TObject, TSource> bindAction;

		public TObject bindTarget;

		private bool _003Crepeat_003E5__2;

		private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

		private object _003C_003E7__wrap3;

		private int _003C_003E7__wrap4;

		private UniTask<bool>.Awaiter _003C_003Eu__1;

		private UniTask.Awaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_002d: Expected O, but got I
			//IL_0055: Expected O, but got I
			//IL_006b: Expected O, but got I
			//IL_1849: Unknown result type (might be due to invalid IL or missing references)
			//IL_184e: Expected O, but got Unknown
			//IL_1873: Expected O, but got I
			//IL_18a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_18a5: Expected O, but got Unknown
			//IL_009c: Expected O, but got I8
			//IL_00d1: Expected O, but got I
			//IL_00e3: Expected O, but got Ref
			//IL_00f3: Expected O, but got I
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected O, but got Unknown
			//IL_00ae: Expected O, but got I8
			//IL_0306: Expected O, but got I4
			//IL_1b66: Expected O, but got I
			//IL_1b76: Expected O, but got I
			//IL_048b: Expected O, but got I
			//IL_04a3: Expected O, but got I
			//IL_04b5: Expected O, but got Ref
			//IL_04c5: Expected O, but got I
			//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d3: Expected O, but got Unknown
			//IL_02e3: Expected O, but got I
			//IL_02f7: Expected O, but got I4
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Expected O, but got Unknown
			//IL_0188: Expected O, but got I4
			//IL_0320: Expected O, but got I
			//IL_0338: Expected O, but got I
			//IL_034a: Expected O, but got Ref
			//IL_035a: Expected O, but got I
			//IL_0363: Unknown result type (might be due to invalid IL or missing references)
			//IL_0368: Expected O, but got Unknown
			//IL_01c3: Expected O, but got I
			//IL_01d5: Expected O, but got Ref
			//IL_01e5: Expected O, but got I
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_11a4: Expected O, but got I
			//IL_11b6: Expected O, but got Ref
			//IL_11c6: Expected O, but got I
			//IL_11cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_11d4: Expected O, but got Unknown
			//IL_03b8: Expected O, but got I
			//IL_03ca: Expected O, but got Ref
			//IL_03da: Expected O, but got I
			//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e8: Expected O, but got Unknown
			//IL_0243: Expected O, but got I
			//IL_0255: Expected O, but got Ref
			//IL_0265: Expected O, but got I
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Expected O, but got Unknown
			//IL_1939: Expected O, but got I4
			//IL_0426: Expected O, but got I
			//IL_0438: Expected O, but got Ref
			//IL_0448: Expected O, but got I
			//IL_0451: Unknown result type (might be due to invalid IL or missing references)
			//IL_0456: Expected O, but got Unknown
			//IL_1224: Expected O, but got I
			//IL_1236: Expected O, but got Ref
			//IL_1246: Expected O, but got I
			//IL_124f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1254: Expected O, but got Unknown
			//IL_190d: Expected O, but got I4
			//IL_02b5: Expected O, but got I4
			//IL_195f: Expected O, but got I8
			//IL_1968: Expected O, but got I4
			//IL_1053: Expected O, but got I
			//IL_1a18: Expected O, but got Ref
			//IL_052e: Expected O, but got I4
			//IL_067e: Expected O, but got I
			//IL_0640: Expected O, but got I
			//IL_0657: Unknown result type (might be due to invalid IL or missing references)
			//IL_065c: Expected O, but got Unknown
			//IL_06a1: Expected O, but got I
			//IL_06b3: Expected O, but got Ref
			//IL_06c3: Expected O, but got I
			//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d1: Expected O, but got Unknown
			//IL_109a: Expected O, but got I
			//IL_10ac: Expected O, but got Ref
			//IL_10bc: Expected O, but got I
			//IL_10c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_10ca: Expected O, but got Unknown
			//IL_0594: Expected O, but got Ref
			//IL_05b9: Expected O, but got I4
			//IL_053c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0541: Expected O, but got Unknown
			//IL_1a3e: Expected O, but got I4
			//IL_12af: Expected O, but got I4
			//IL_1753: Expected I, but got O
			//IL_1761: Expected I, but got O
			//IL_1771: Expected O, but got I
			//IL_0ac8: Expected O, but got I
			//IL_0ada: Expected O, but got Ref
			//IL_0aea: Expected O, but got I
			//IL_0af3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0af8: Expected O, but got Unknown
			//IL_0c54: Expected O, but got I
			//IL_0c66: Expected O, but got Ref
			//IL_0c76: Expected O, but got I
			//IL_0c7f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c84: Expected O, but got Unknown
			//IL_131b: Expected O, but got I
			//IL_132d: Expected O, but got Ref
			//IL_133d: Expected O, but got I
			//IL_1346: Unknown result type (might be due to invalid IL or missing references)
			//IL_134b: Expected O, but got Unknown
			//IL_1b9f: Expected O, but got I4
			//IL_1bdf: Expected O, but got I4
			//IL_0731: Expected O, but got I
			//IL_0743: Expected O, but got Ref
			//IL_0753: Expected O, but got I
			//IL_075c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0761: Expected O, but got Unknown
			//IL_14b7: Expected O, but got I
			//IL_14c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_14c5: Expected O, but got Unknown
			//IL_17ad: Expected O, but got I
			//IL_111f: Expected O, but got I
			//IL_1131: Expected O, but got Ref
			//IL_1141: Expected O, but got I
			//IL_114a: Unknown result type (might be due to invalid IL or missing references)
			//IL_114f: Expected O, but got Unknown
			//IL_0b3b: Expected O, but got I
			//IL_0b4d: Expected O, but got Ref
			//IL_0b5d: Expected O, but got I
			//IL_0b66: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b6b: Expected O, but got Unknown
			//IL_138e: Expected O, but got I
			//IL_13a0: Expected O, but got Ref
			//IL_13b0: Expected O, but got I
			//IL_13b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_13be: Expected O, but got Unknown
			//IL_12bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_12c2: Expected O, but got Unknown
			//IL_1bb4: Expected O, but got I
			//IL_0cc7: Expected O, but got I
			//IL_0cd9: Expected O, but got Ref
			//IL_0ce9: Expected O, but got I
			//IL_0cf2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cf7: Expected O, but got Unknown
			//IL_07b1: Expected O, but got I
			//IL_07c3: Expected O, but got Ref
			//IL_07d3: Expected O, but got I
			//IL_07dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e1: Expected O, but got Unknown
			//IL_1dfd: Expected O, but got I4
			//IL_0ba6: Expected O, but got I
			//IL_1401: Expected O, but got I
			//IL_1413: Expected O, but got Ref
			//IL_1423: Expected O, but got I
			//IL_142c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1431: Expected O, but got Unknown
			//IL_0831: Expected O, but got I
			//IL_0843: Expected O, but got Ref
			//IL_0853: Expected O, but got I
			//IL_085c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0861: Expected O, but got Unknown
			//IL_1e0b: Expected O, but got I4
			//IL_1e1b: Expected O, but got I
			//IL_1474: Expected O, but got I
			//IL_147d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1482: Expected O, but got Unknown
			//IL_1602: Expected O, but got I
			//IL_1614: Expected O, but got Ref
			//IL_1624: Expected O, but got I
			//IL_162d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1632: Expected O, but got Unknown
			//IL_0bd4: Expected O, but got I
			//IL_0be6: Expected O, but got Ref
			//IL_0bf6: Expected O, but got I
			//IL_0bff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c04: Expected O, but got Unknown
			//IL_1a8b: Expected O, but got I
			//IL_1e2e: Expected O, but got Ref
			//IL_1e7d: Expected O, but got I8
			//IL_1517: Expected O, but got I
			//IL_1529: Expected O, but got Ref
			//IL_1539: Expected O, but got I
			//IL_1542: Unknown result type (might be due to invalid IL or missing references)
			//IL_1547: Expected O, but got Unknown
			//IL_1bc7: Expected O, but got Ref
			//IL_0d4c: Expected O, but got I
			//IL_0d5e: Expected O, but got Ref
			//IL_0d6e: Expected O, but got I
			//IL_0d77: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d7c: Expected O, but got Unknown
			//IL_1675: Expected O, but got I
			//IL_1687: Expected O, but got Ref
			//IL_1697: Expected O, but got I
			//IL_16a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_16a5: Expected O, but got Unknown
			//IL_1e5d: Expected O, but got I4
			//IL_1c0e: Expected I, but got O
			//IL_1e8b: Expected O, but got I4
			//IL_158a: Expected O, but got I
			//IL_159c: Expected O, but got Ref
			//IL_15ac: Expected O, but got I
			//IL_15b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_15ba: Expected O, but got Unknown
			//IL_16e8: Expected O, but got I
			//IL_16fa: Expected O, but got Ref
			//IL_170a: Expected O, but got I
			//IL_1713: Unknown result type (might be due to invalid IL or missing references)
			//IL_1718: Expected O, but got Unknown
			//IL_1e6b: Expected O, but got I4
			//IL_0db6: Expected O, but got I
			//IL_1c7c: Expected O, but got I
			//IL_1ca1: Expected I, but got O
			//IL_0dee: Expected O, but got I
			//IL_0df7: Expected O, but got I4
			//IL_1b1c: Expected O, but got I
			//IL_1b39: Expected O, but got I
			//IL_08bc: Expected O, but got I4
			//IL_0925: Expected O, but got I
			//IL_093b: Expected O, but got I
			//IL_095d: Expected O, but got I
			//IL_09f9: Expected O, but got I
			//IL_0a02: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a07: Expected O, but got Unknown
			//IL_0e05: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e0a: Expected O, but got Unknown
			//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_08cf: Expected O, but got Unknown
			//IL_098e: Expected O, but got I
			//IL_09a4: Expected O, but got I
			//IL_0eb1: Expected O, but got I
			//IL_0ec3: Expected O, but got Ref
			//IL_0ed3: Expected O, but got I
			//IL_0edc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ee1: Expected O, but got Unknown
			//IL_0a29: Expected O, but got I
			//IL_1cb8: Expected O, but got I4
			//IL_09d1: Expected O, but got I
			//IL_0a4c: Expected O, but got I
			//IL_0f36: Expected O, but got I
			//IL_0f48: Expected O, but got Ref
			//IL_0f58: Expected O, but got I
			//IL_0f61: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f66: Expected O, but got Unknown
			//IL_0a67: Expected O, but got I
			//IL_0a99: Expected O, but got I
			//IL_1ccd: Expected O, but got I
			//IL_0fb3: Expected O, but got I
			//IL_0fe1: Expected O, but got I
			//IL_0ff3: Expected O, but got Ref
			//IL_1003: Expected O, but got I
			//IL_100c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1011: Expected O, but got Unknown
			//IL_1ce0: Expected O, but got Ref
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
			_ = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+50]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v5+FC]");
			object obj5 = (nint)0 + (nint)15;
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v5+FC]");
			if ((nint)obj6 <= 0)
			{
				obj5 = 1152921504606846960L;
			}
			object obj7 = obj5 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
			object obj8 = (nint)0 + (nint)15;
			object obj9 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
			if ((nint)obj9 <= 0)
			{
				obj8 = 1152921504606846960L;
			}
			object obj10 = obj8 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			nint num3 = 0;
			IntPtr intPtr = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v13 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v2+18]");
			object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v2+10]");
			object obj13 = 0;
			object obj14 = obj12 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v20+28]");
			if ((nint)0 >= (nint)0)
			{
				obj14 = obj12;
			}
			object obj15 = obj14;
			object obj26;
			if (obj14 != null)
			{
				nint num4 = 0;
				if ((nint)obj14 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v427 (Il2CppClass<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+135]");
					object obj16 = 0 & obj14;
					bool flag = obj16 == null;
					object obj17 = !flag;
					if (obj17 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
					}
					nint num5 = 0;
					IntPtr intPtr2 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v354 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdx_v126+198]");
					object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdx_v126+190]");
					object obj20 = 0;
					object obj21 = obj19 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v434+28]");
					if ((nint)0 >= (nint)0)
					{
						obj21 = obj19;
					}
					nint num6 = 0;
					IntPtr intPtr3 = num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rcx_v358 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
					object obj22 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rdx_v127+198]");
					object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rdx_v127+190]");
					object obj24 = 0;
					object obj25 = obj23 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rax_v438+28]");
					if ((nint)0 < (nint)0)
					{
						obj25 = 0;
						_ = 4294967295L;
						_ = 4294967295L;
					}
					nint num7 = 0;
					IntPtr intPtr4 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1A60");
					obj26 = 0;
					goto IL_1043;
				}
				nint num8 = 0;
				IntPtr intPtr5 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v350 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj27 = (nint)0 + (nint)224;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1A00");
				obj26 = 0;
				goto IL_1186;
			}
			obj26 = 0;
			goto IL_1b56;
			IL_1b56:
			nint num14 = default(nint);
			object obj72 = default(object);
			object obj98 = default(object);
			object obj99 = default(object);
			object obj102 = default(object);
			object obj101;
			nint num12;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+70]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v26+20]");
				object obj29 = 0;
				if (obj15 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rax_v197+C0]");
					object obj30 = 0;
					object obj31 = obj30;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rcx_v215+80]");
					object obj32 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rdx_v79+178]");
					object obj33 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rdx_v79+170]");
					object obj34 = 0;
					object obj35 = obj33 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v270+28]");
					if ((nint)0 >= (nint)0)
					{
						obj35 = obj33;
					}
					nint num9 = 0;
					IntPtr intPtr6 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rcx_v219 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
					object obj36 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v588 @ rdx_v80+178]");
					object obj37 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v588 @ rdx_v80+170]");
					object obj38 = 0;
					object obj39 = obj37 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v274+28]");
					if ((nint)0 < (nint)0)
					{
						obj39 = 0;
						_ = 4294967295L;
						_ = 4294967295L;
					}
					nint num10 = 0;
					IntPtr intPtr7 = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v742 @ rcx_v223 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
					object obj40 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v743 @ rdx_v81+18]");
					object obj41 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v743 @ rdx_v81+10]");
					object obj42 = 0;
					object obj43 = obj41 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ rax_v278+28]");
					if ((nint)0 < (nint)0)
					{
						obj43 = 4294967295L;
						obj26 = 0;
						goto IL_05c7;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ rax_v197+C0]");
				object obj44 = 0;
				object obj45 = obj44;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rcx_v157+80]");
				object obj46 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rdx_v7+118]");
				object obj47 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rdx_v7+110]");
				object obj48 = 0;
				object obj49 = obj47 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v199+28]");
				if ((nint)0 >= (nint)0)
				{
					obj49 = obj47;
				}
				object obj50 = obj49;
				object obj59;
				if (obj49 != null)
				{
					nint num11 = 0;
					object obj51 = obj50;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ r10_v10+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0565;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ r10_v10+B0]");
					num12 = 0;
					object obj52 = 0;
					while (true)
					{
						object obj53 = obj52 + obj52;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3149 @ r9_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+v857 @ rax_v264*8]");
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rax_v202 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+18]");
						if (num13 == 0)
						{
							break;
						}
						obj52++;
						object obj54 = obj52;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ r10_v10+12E]");
						if ((nint)obj54 < 0)
						{
							continue;
						}
						goto IL_0565;
					}
					object obj55 = obj52 + obj52;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3149 @ r9_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+8+v1215 @ rcx_v206*8]");
					object obj56 = (nint)0 + (nint)1;
					object obj57 = obj56 << 4;
					object obj58 = obj57 + 312;
					obj59 = obj58 + obj51;
					goto IL_1a0a;
				}
				throw new NullReferenceException();
				IL_1b0c:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+78]");
				object obj60 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+78]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3298 @ rdx_v50+8]");
				object obj61 = 0;
				num14 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3311 @ rcx_v120+10] (should have been resolved before IL gen)");
				nint num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3379 @ rax_v149 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+50]");
				object obj62 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3380 @ rcx_v123+28]");
				object obj63 = (nint)0 >> 31;
				bool flag2 = obj63 != null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+78]");
				object obj64 = 0;
				if (!flag2)
				{
					obj64 = obj60;
				}
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3495 @ rax_v154 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+40]");
				object obj65 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3496 @ rcx_v125+28]");
				object obj66 = (nint)0 >> 31;
				if (obj66 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+50]");
					object obj67 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+50]");
					object obj68 = 0;
					object obj67 = obj68;
				}
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3540 @ rax_v160 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+58]");
				object obj69 = 0;
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3548 @ rax_v163 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+58]");
				object obj70 = 0;
				num12 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3541 @ rdi_v11+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+160]");
				obj15 = 0;
				continue;
				IL_05c7:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+40]");
				object obj71;
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
					obj71 = obj72;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+4A]");
					num12 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+48]");
					obj71 = 0;
				}
				nint num19 = 0;
				IntPtr intPtr8 = num19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1441 @ rcx_v28 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj73 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ rdx_v10+F8]");
				object obj74 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ rdx_v10+F0]");
				object obj75 = 0;
				object obj76 = obj74 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1445 @ rax_v39+28]");
				if ((nint)0 < (nint)0)
				{
					obj76 = 0;
				}
				if (obj71 == null)
				{
					break;
				}
				nint num20 = 0;
				IntPtr intPtr9 = num20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1884 @ rcx_v103 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj77 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1885 @ rdx_v42+B8]");
				object obj78 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1885 @ rdx_v42+B0]");
				object obj79 = 0;
				object obj80 = obj78 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1888 @ rax_v128+28]");
				if ((nint)0 >= (nint)0)
				{
					obj80 = obj78;
				}
				nint num21 = 0;
				IntPtr intPtr10 = num21;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2136 @ rcx_v107 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj81 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2137 @ rdx_v43+D8]");
				object obj82 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2137 @ rdx_v43+D0]");
				object obj83 = 0;
				object obj84 = obj82 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2141 @ rax_v132+28]");
				if ((nint)0 >= (nint)0)
				{
					obj84 = obj82;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				nint num22 = 0;
				IntPtr intPtr11 = num22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2615 @ rcx_v112 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj85 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2616 @ rdx_v46+118]");
				object obj86 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2616 @ rdx_v46+110]");
				object obj87 = 0;
				object obj88 = obj86 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2619 @ rax_v137+28]");
				if ((nint)0 >= (nint)0)
				{
					obj88 = obj86;
				}
				object obj89 = obj88;
				bool flag3 = obj88 == null;
				obj47 = obj88;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3298 @ rdx_v50+8]");
				obj46 = 0;
				object obj97;
				if (!flag3)
				{
					nint num23 = 0;
					object obj90 = obj89;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3110 @ r10_v8+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_08f3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3110 @ r10_v8+B0]");
					num12 = 0;
					object obj91 = 0;
					while (true)
					{
						object obj92 = obj91 + obj91;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3149 @ r9_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+v3151 @ rax_v175*8]");
						nint num24 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3007 @ rax_v142 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+18]");
						if (num24 == 0)
						{
							break;
						}
						obj91++;
						object obj93 = obj91;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3110 @ r10_v8+12E]");
						if ((nint)obj93 < 0)
						{
							continue;
						}
						goto IL_08f3;
					}
					object obj94 = obj91 + obj91;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3149 @ r9_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+8+v3291 @ rcx_v138*8]");
					object obj95 = (nint)0 << 4;
					object obj96 = obj95 + 312;
					obj97 = obj96 + obj90;
					goto IL_1b0c;
				}
				num12 = num14;
				throw new NullReferenceException();
				IL_0565:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj59 = obj98;
				goto IL_1a0a;
				IL_08f3:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj97 = obj99;
				goto IL_1b0c;
				IL_1a0a:
				object obj100 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1222 @ r8_v67] (should have been resolved before IL gen)");
				obj101 = obj102;
				_ = 0;
				UniTask<bool> uniTask = (UniTask<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
				UniTaskStatus status = ((UniTask<bool>*)uniTask)->Status;
				bool flag4 = status == UniTaskStatus.Pending;
				obj26 = 0;
				if (!flag4)
				{
					goto IL_05c7;
				}
				_ = 0;
				nint num25 = 0;
				IntPtr intPtr12 = num25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1930 @ rcx_v170 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj103 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1931 @ rdx_v69+18]");
				object obj104 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1931 @ rdx_v69+10]");
				object obj105 = 0;
				object obj106 = obj104 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1934 @ rax_v217+28]");
				if ((nint)0 < (nint)0)
				{
					obj106 = 0;
				}
				nint num26 = 0;
				IntPtr intPtr13 = num26;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2352 @ rcx_v175 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj107 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2353 @ rdx_v71+178]");
				object obj108 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2353 @ rdx_v71+170]");
				object obj109 = 0;
				object obj110 = obj108 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2356 @ rax_v222+28]");
				if ((nint)0 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+40]");
					obj110 = 0;
				}
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2810 @ rax_v226 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+28]");
				object obj111 = 0;
				nint num28 = 0;
				nint num29 = 0;
				IntPtr intPtr14 = num29;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3024 @ rcx_v183 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj112 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3025 @ rdx_v73+38]");
				object obj113 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3025 @ rdx_v73+30]");
				object obj114 = 0;
				object obj115 = obj113 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3028 @ rax_v233+28]");
				if ((nint)0 >= (nint)0)
				{
					obj115 = obj113;
				}
				object obj116 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2811 @ rcx_v180] (should have been resolved before IL gen)");
				return;
			}
			nint num30 = 0;
			IntPtr intPtr15 = num30;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1907 @ rcx_v33 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
			object obj117 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1908 @ rdx_v12+158]");
			object obj118 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1908 @ rdx_v12+150]");
			object obj119 = 0;
			object obj120 = obj118 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1911 @ rax_v44+28]");
			if ((nint)0 < (nint)0)
			{
				obj120 = 2;
			}
			nint num31 = 0;
			IntPtr intPtr16 = num31;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2455 @ rcx_v38 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
			object obj121 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1261 @ rdx_v14+118]");
			object obj122 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1261 @ rdx_v14+110]");
			object obj123 = 0;
			object obj124 = obj122 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1263 @ rax_v49+28]");
			if ((nint)0 >= (nint)0)
			{
				obj124 = obj122;
			}
			object obj127 = default(object);
			object obj129 = default(object);
			Exception ex2;
			if (obj124 != null)
			{
				nint num32 = 0;
				IntPtr intPtr17 = num32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2888 @ rcx_v42 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj125 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdx_v15+118]");
				Exception ex = (Exception)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rdx_v15+110]");
				object obj126 = 0;
				ex2 = (Exception)(ex - 16);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rax_v53+28]");
				if ((nint)0 >= (nint)0)
				{
					ex2 = ex;
				}
				nint num33 = (nint)ex2;
				if (ex2 != null)
				{
					obj127 = num33;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ r10_v6+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0e2e;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ r10_v6+B0]");
					object obj128 = 0;
					obj129 = 0;
					while (true)
					{
						object obj130 = obj129 + obj129;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3179 @ r8_v39+v3182 @ rax_v115*8]");
						if (0 == (nint)typeof(IUniTaskAsyncDisposable))
						{
							break;
						}
						obj129++;
						object obj131 = obj129;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ r10_v6+12E]");
						if ((nint)obj131 < 0)
						{
							continue;
						}
						goto IL_0e2e;
					}
					goto IL_1451;
				}
				throw new NullReferenceException();
			}
			goto IL_107c;
			IL_12e6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj133 = default(object);
			object obj132 = obj133;
			goto IL_1e45;
			IL_1186:
			nint num34 = 0;
			IntPtr intPtr18 = num34;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rcx_v242 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
			object obj134 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v91+58]");
			object obj135 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v91+50]");
			object obj136 = 0;
			object obj137 = obj135 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rax_v301+28]");
			if ((nint)0 >= (nint)0)
			{
				obj137 = obj135;
			}
			object obj138 = obj137;
			nint num35 = 0;
			IntPtr intPtr19 = num35;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ rcx_v246 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
			object obj139 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v720 @ rdx_v92+78]");
			ex2 = (Exception)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v720 @ rdx_v92+70]");
			object obj140 = 0;
			Exception ex3 = (Exception)(ex2 - 16);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v723 @ rax_v305+28]");
			if ((nint)0 >= (nint)0)
			{
				ex3 = ex2;
			}
			if (obj137 != null)
			{
				nint num36 = 0;
				object obj141 = obj138;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ r10_v16+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_12e6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ r10_v16+B0]");
				num12 = 0;
				object obj142 = 0;
				while (true)
				{
					object obj143 = obj142 + obj142;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3149 @ r9_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+v1402 @ rax_v352*8]");
					nint num37 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1127 @ rax_v308 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+8]");
					if (num37 == 0)
					{
						break;
					}
					obj142++;
					object obj144 = obj142;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ r10_v16+12E]");
					if ((nint)obj144 < 0)
					{
						continue;
					}
					goto IL_12e6;
				}
				object obj145 = obj142 + obj142;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3149 @ r9_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+8+v1632 @ rcx_v284*8]");
				object obj146 = (nint)0 << 4;
				object obj147 = obj146 + 312;
				obj132 = obj147 + obj141;
				goto IL_1e45;
			}
			throw new NullReferenceException();
			IL_1e20:
			object obj148 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3320 @ r8_v21] (should have been resolved before IL gen)");
			object obj149 = default(object);
			obj101 = obj149;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+30]");
			object obj150 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+30]");
			bool flag5 = (nint)0 == 0;
			num12 = (nint)typeof(IUniTaskAsyncDisposable);
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+38]");
				num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
				object obj151 = default(object);
				if (obj151 == null)
				{
					nint num38 = 0;
					IntPtr intPtr20 = num38;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3566 @ rcx_v55 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
					object obj152 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3567 @ rdx_v21+18]");
					object obj153 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3567 @ rdx_v21+10]");
					object obj154 = 0;
					object obj155 = obj153 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3570 @ rax_v66+28]");
					if ((nint)0 >= (nint)0)
					{
						obj155 = obj153;
					}
					obj155 = 1;
					nint num39 = 0;
					IntPtr intPtr21 = num39;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3665 @ rcx_v60 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
					object obj156 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3666 @ rdx_v25+198]");
					object obj157 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3666 @ rdx_v25+190]");
					object obj158 = 0;
					object obj159 = obj157 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3669 @ rax_v71+28]");
					if ((nint)0 >= (nint)0)
					{
						obj159 = obj157;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+30]");
					obj159 = 0;
					nint num40 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3764 @ rax_v75 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>)+60]");
					object obj160 = 0;
					nint num41 = 0;
					nint num42 = 0;
					IntPtr intPtr22 = num42;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3797 @ rcx_v68 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
					object obj161 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3798 @ rdx_v29+38]");
					object obj162 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3798 @ rdx_v29+30]");
					object obj163 = 0;
					object obj164 = obj162 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3801 @ rax_v82+28]");
					if ((nint)0 >= (nint)0)
					{
						obj164 = obj162;
					}
					object obj165 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3765 @ rcx_v65] (should have been resolved before IL gen)");
					return;
				}
				goto IL_1043;
			}
			goto IL_1cef;
			IL_1451:
			object obj166 = obj129 + obj129;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3179 @ r8_v39+8+v3315 @ rcx_v92*8]");
			object obj167 = (nint)0 << 4;
			object obj168 = obj167 + 312;
			object obj169 = obj168 + obj127;
			goto IL_1e20;
			IL_0e2e:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj170 = default(object);
			obj169 = obj170;
			goto IL_1e20;
			IL_1cef:
			if (obj150 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+38]");
				num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
			}
			goto IL_107c;
			IL_1043:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+30]");
			obj150 = 0;
			goto IL_1cef;
			IL_107c:
			nint num43 = 0;
			IntPtr intPtr23 = num43;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rcx_v293 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
			object obj171 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1382 @ rdx_v106+138]");
			object obj172 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1382 @ rdx_v106+130]");
			object obj173 = 0;
			object obj174 = obj172 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1385 @ rax_v361+28]");
			if ((nint)0 >= (nint)0)
			{
				obj174 = obj172;
			}
			ex2 = (Exception)obj174;
			if (obj174 == null)
			{
				nint num44 = 0;
				IntPtr intPtr24 = num44;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1717 @ rcx_v298 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj175 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v108+158]");
				object obj176 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v108+150]");
				object obj177 = 0;
				object obj178 = obj176 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1719 @ rax_v367+28]");
				if ((nint)0 >= (nint)0)
				{
					obj178 = obj176;
				}
				if ((nint)obj178 == 1)
				{
					goto IL_1186;
				}
				if ((nint)obj178 != 2)
				{
					nint num45 = 0;
					IntPtr intPtr25 = num45;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2241 @ rcx_v327 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
					object obj179 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2242 @ rdx_v117+138]");
					object obj180 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2242 @ rdx_v117+130]");
					object obj181 = 0;
					object obj182 = obj180 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2245 @ rax_v403+28]");
					if ((nint)0 < (nint)0)
					{
						obj182 = 0;
					}
					nint num46 = 0;
					IntPtr intPtr26 = num46;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2703 @ rcx_v332 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
					object obj183 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2704 @ rdx_v119+118]");
					object obj184 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2704 @ rdx_v119+110]");
					object obj185 = 0;
					object obj186 = obj184 - 16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2707 @ rax_v408+28]");
					if ((nint)0 < (nint)0)
					{
						obj186 = 0;
					}
				}
				nint num47 = 0;
				IntPtr intPtr27 = num47;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2264 @ rcx_v303 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj187 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2265 @ rdx_v110+18]");
				object obj188 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2265 @ rdx_v110+10]");
				object obj189 = 0;
				object obj190 = obj188 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2268 @ rax_v373+28]");
				if ((nint)0 < (nint)0)
				{
					obj190 = 4294967294L;
				}
				nint num48 = 0;
				IntPtr intPtr28 = num48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2745 @ rcx_v308 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj191 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2746 @ rdx_v112+118]");
				object obj192 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2746 @ rdx_v112+110]");
				object obj193 = 0;
				object obj194 = obj192 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2749 @ rax_v378+28]");
				if ((nint)0 < (nint)0)
				{
					obj194 = 0;
				}
				nint num49 = 0;
				IntPtr intPtr29 = num49;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3085 @ rcx_v313 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
				object obj195 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3086 @ rdx_v114+38]");
				object obj196 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3086 @ rdx_v114+30]");
				object obj197 = 0;
				object obj198 = obj196 - 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3089 @ rax_v383+28]");
				if ((nint)0 >= (nint)0)
				{
					obj198 = obj196;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844336B0");
				return;
			}
			nint num50 = (nint)ex2;
			nint num51 = (nint)typeof(Exception);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ r8_v146 (Il2CppClass<System.Exception>)+130]");
			object obj199 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1145 @ r9_v31 (Il2CppClass<System.Exception>)+130]");
			nint num52 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1148 @ r8_v146 (Il2CppClass<System.Exception>)+130]");
			if (num52 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1145 @ r9_v31 (Il2CppClass<System.Exception>)+C8]");
				object obj200 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1154 @ rax_v363+FFFFFFF8+v1557 @ rax_v362*8]");
				if (0 == (nint)typeof(Exception))
				{
					ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex2);
					throw new NullReferenceException();
				}
			}
			ExceptionDispatchInfo exceptionDispatchInfo2 = default(ExceptionDispatchInfo);
			throw exceptionDispatchInfo2;
			IL_1e45:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1637 @ r8_v115] (should have been resolved before IL gen)");
			nint num53 = 0;
			IntPtr intPtr30 = num53;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1738 @ rcx_v255 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
			object obj201 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1739 @ rdx_v96+118]");
			object obj202 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1739 @ rdx_v96+110]");
			object obj203 = 0;
			object obj204 = obj202 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1742 @ rax_v316+28]");
			if ((nint)0 < (nint)0)
			{
				object obj205 = default(object);
				obj204 = obj205;
			}
			nint num54 = 0;
			IntPtr intPtr31 = num54;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2113 @ rcx_v260 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
			object obj206 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2114 @ rdx_v98+138]");
			object obj207 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2114 @ rdx_v98+130]");
			object obj208 = 0;
			object obj209 = obj207 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2117 @ rax_v321+28]");
			if ((nint)0 < (nint)0)
			{
				obj209 = 0;
			}
			nint num55 = 0;
			IntPtr intPtr32 = num55;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2596 @ rcx_v265 (Il2CppClass<Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__12`2>>)+80]");
			object obj210 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rdx_v100+158]");
			object obj211 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref this));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rdx_v100+150]");
			object obj212 = 0;
			object obj213 = obj211 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v326+28]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_1451;
			}
			obj213 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+160]");
			obj15 = 0;
			goto IL_1b56;
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
	private struct _003CBindToCore_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public IUniTaskAsyncEnumerable<string> source;

		public CancellationToken cancellationToken;

		public bool rebindOnError;

		public Text text;

		private bool _003Crepeat_003E5__2;

		private IUniTaskAsyncEnumerator<string> _003Ce_003E5__3;

		private object _003C_003E7__wrap3;

		private int _003C_003E7__wrap4;

		private UniTask<bool>.Awaiter _003C_003Eu__1;

		private UniTask.Awaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_00bd: Expected O, but got I4
			//IL_00cc: Expected I4, but got I8
			//IL_00e2: Expected I4, but got I8
			//IL_00eb: Expected O, but got I4
			//IL_0121: Expected I, but got O
			//IL_004d: Expected O, but got I4
			//IL_005c: Expected I4, but got I8
			//IL_006a: Expected I4, but got I8
			//IL_0073: Expected O, but got I4
			//IL_09b5: Expected O, but got I
			//IL_0159: Expected O, but got I
			//IL_065c: Expected I, but got O
			//IL_0269: Expected O, but got I
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Expected O, but got Unknown
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Expected O, but got Unknown
			//IL_02e9: Expected I, but got O
			//IL_0b5a: Expected O, but got I
			//IL_0b76: Expected I, but got O
			//IL_0694: Expected O, but got I
			//IL_0805: Expected I, but got O
			//IL_0813: Expected I, but got O
			//IL_0823: Expected O, but got I
			//IL_05ce: Expected I, but got O
			//IL_01e1: Expected I, but got O
			//IL_01ea: Expected O, but got I4
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_0462: Expected I, but got O
			//IL_02ff: Expected I, but got O
			//IL_0700: Expected I, but got O
			//IL_076b: Expected O, but got I
			//IL_0774: Unknown result type (might be due to invalid IL or missing references)
			//IL_0779: Expected O, but got Unknown
			//IL_0781: Unknown result type (might be due to invalid IL or missing references)
			//IL_0786: Expected O, but got Unknown
			//IL_085f: Expected O, but got I
			//IL_043d: Expected O, but got Ref
			//IL_0386: Expected O, but got I4
			//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ac: Expected O, but got Unknown
			//IL_07d6: Expected I4, but got I8
			//IL_049a: Expected O, but got I
			//IL_0337: Expected O, but got I
			//IL_07ed: Expected O, but got Ref
			//IL_04f5: Expected I, but got O
			//IL_039b: Expected I, but got O
			//IL_03bb: Expected O, but got I
			//IL_03c8: Expected O, but got I
			//IL_0728: Expected O, but got I
			//IL_0731: Unknown result type (might be due to invalid IL or missing references)
			//IL_0736: Expected O, but got Unknown
			//IL_073e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0743: Expected O, but got Unknown
			//IL_03f8: Expected O, but got I
			//IL_0401: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Expected O, but got Unknown
			//IL_040e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Expected O, but got Unknown
			//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b2: Expected O, but got Unknown
			//IL_034a: Unknown result type (might be due to invalid IL or missing references)
			//IL_034f: Expected O, but got Unknown
			//IL_0aa2: Expected I, but got O
			//IL_0543: Expected I, but got O
			//IL_0551: Expected I, but got O
			//IL_058c: Expected O, but got Ref
			int num = _003C_003E1__state;
			if (_003C_003E1__state == 0)
			{
				goto IL_0088;
			}
			UniTask.Awaiter awaiter;
			if (_003C_003E1__state == 1)
			{
				awaiter = _003C_003Eu__2;
				_003C_003Eu__2 = (UniTask.Awaiter)0;
				_003C_003E1__state = -1;
				num = -1;
				UniTask.Awaiter awaiter2 = (UniTask.Awaiter)0;
				goto IL_0ab8;
			}
			_003Crepeat_003E5__2 = false;
			goto IL_0621;
			IL_06d0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj2 = default(object);
			object obj = obj2;
			goto IL_0b4a;
			IL_0621:
			IUniTaskAsyncEnumerable<string> uniTaskAsyncEnumerable = source;
			CancellationToken cancellationToken = this.cancellationToken;
			if (source != null)
			{
				nint num2 = (nint)uniTaskAsyncEnumerable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r10_v6 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<System.String>>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_06d0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r10_v6 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<System.String>>)+B0]");
				object obj3 = 0;
				object obj4 = null;
				while (true)
				{
					object obj5 = obj4 + obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v21+v607 @ rax_v37*8]");
					if (0 == (nint)typeof(IUniTaskAsyncEnumerable<string>))
					{
						break;
					}
					obj4++;
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r10_v6 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<System.String>>)+12E]");
					if ((nint)obj6 < 0)
					{
						continue;
					}
					goto IL_06d0;
				}
				object obj7 = obj4 + obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v21+8+v866 @ rcx_v27*8]");
				object obj8 = (nint)0 << 4;
				object obj9 = obj8 + 312;
				obj = obj9 + num2;
				goto IL_0b4a;
			}
			Exception ex = (Exception)cancellationToken;
			throw new NullReferenceException();
			IL_0088:
			nint num3;
			UniTask.Awaiter awaiter4 = default(UniTask.Awaiter);
			object obj20 = default(object);
			object obj21 = default(object);
			object obj22 = default(object);
			UniTask<bool> uniTask = default(UniTask<bool>);
			UniTask<bool>.Awaiter awaiter6 = default(UniTask<bool>.Awaiter);
			IntPtr intPtr = default(IntPtr);
			UniTask<bool>.Awaiter awaiter7 = default(UniTask<bool>.Awaiter);
			nint num6 = default(nint);
			nint num8;
			UniTask.Awaiter awaiter5;
			nint num4 = default(nint);
			while (true)
			{
				UniTask<bool>.Awaiter awaiter3;
				UniTask.Awaiter awaiter2;
				if (num == 0)
				{
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = (UniTask<bool>.Awaiter)0;
					_003C_003E1__state = -1;
					num3 = num4;
					num = -1;
					awaiter2 = (UniTask.Awaiter)0;
					goto IL_01f8;
				}
				IUniTaskAsyncEnumerator<string> uniTaskAsyncEnumerator = _003Ce_003E5__3;
				object obj18;
				if (_003Ce_003E5__3 != null)
				{
					nint num5 = (nint)uniTaskAsyncEnumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ r10_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.String>>)+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0195;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ r10_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.String>>)+B0]");
					object obj10 = 0;
					object obj11 = null;
					while (true)
					{
						object obj12 = obj11 + obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ r8_v93+v527 @ rax_v160*8]");
						if (0 == (nint)typeof(IUniTaskAsyncEnumerator<string>))
						{
							break;
						}
						obj11++;
						object obj13 = obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ r10_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.String>>)+12E]");
						if ((nint)obj13 < 0)
						{
							continue;
						}
						goto IL_0195;
					}
					object obj14 = obj11 + obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ r8_v93+8+v778 @ rcx_v116*8]");
					object obj15 = (nint)0 + (nint)1;
					object obj16 = obj15 << 4;
					object obj17 = obj16 + 312;
					obj18 = obj17 + num5;
					goto IL_09a5;
				}
				throw new NullReferenceException();
				IL_0373:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				awaiter4 = (UniTask.Awaiter)0;
				object obj19 = obj20;
				goto IL_0a03;
				IL_0195:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj18 = obj21;
				goto IL_09a5;
				IL_09a5:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ r8_v77+8]");
				awaiter5 = (UniTask.Awaiter)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v785 @ r8_v77] (should have been resolved before IL gen)");
				awaiter3 = (UniTask<bool>.Awaiter)obj22;
				UniTaskStatus status = uniTask.Status;
				bool flag = status == UniTaskStatus.Pending;
				num6 = 0;
				num3 = (nint)typeof(IUniTaskAsyncEnumerator<string>);
				awaiter2 = (UniTask.Awaiter)0;
				if (!flag)
				{
					goto IL_01f8;
				}
				_003C_003E1__state = 0;
				_003C_003Eu__1 = (UniTask<bool>.Awaiter)obj22;
				AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter6, ref this);
				return;
				IL_0a03:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1530 @ rdx_v47] (should have been resolved before IL gen)");
				Text text;
				nint num7 = (nint)text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1593 @ r8_v71 (Il2CppClass<UnityEngine.UI.Text>)+5E8]");
				num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1593 @ r8_v71 (Il2CppClass<UnityEngine.UI.Text>)+5F0]");
				awaiter5 = (UniTask.Awaiter)0;
				text.text = (string)(nint)intPtr;
				num6 = intPtr;
				continue;
				IL_01f8:
				if ((object)awaiter3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw r9d,xmm6,5\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
					awaiter5 = (UniTask.Awaiter)awaiter3;
					num8 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					num8 = num6;
					awaiter7 = awaiter3;
				}
				_003Crepeat_003E5__2 = false;
				if ((object)awaiter7 == null)
				{
					break;
				}
				text = this.text;
				uniTaskAsyncEnumerator = _003Ce_003E5__3;
				bool flag2 = _003Ce_003E5__3 == null;
				num4 = (nint)typeof(IUniTaskAsyncEnumerator<string>);
				if (!flag2)
				{
					nint num9 = (nint)uniTaskAsyncEnumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v14 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.String>>)+12E]");
					if ((nint)0 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v14 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.String>>)+B0]");
						awaiter4 = (UniTask.Awaiter)0;
						object obj23 = null;
						while (true)
						{
							object obj24 = obj23 + obj23;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ r8_v69 (Cysharp.Threading.Tasks.UniTask+Awaiter)+v1063 @ rax_v119*8]");
							if (0 == (nint)typeof(IUniTaskAsyncEnumerator<string>))
							{
								break;
							}
							obj23++;
							object obj25 = obj23;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v14 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.String>>)+12E]");
							if ((nint)obj25 < 0)
							{
								continue;
							}
							goto IL_0373;
						}
						object obj26 = obj23 + obj23;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ r8_v69 (Cysharp.Threading.Tasks.UniTask+Awaiter)+8+v1525 @ rcx_v89*8]");
						object obj27 = (nint)0 << 4;
						object obj28 = obj27 + 312;
						obj19 = obj28 + num9;
						goto IL_0a03;
					}
					goto IL_0373;
				}
				awaiter5 = awaiter4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1530 @ rdx_v47+8]");
				num6 = 0;
				throw new NullReferenceException();
			}
			_003C_003E7__wrap4 = 2;
			bool flag3 = _003Ce_003E5__3 == null;
			num4 = num3;
			if (flag3)
			{
				goto IL_05d3;
			}
			IUniTaskAsyncEnumerator<string> uniTaskAsyncEnumerator2 = _003Ce_003E5__3;
			nint num10 = (nint)uniTaskAsyncEnumerator2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ r10_v12 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.String>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_04d6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ r10_v12 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.String>>)+B0]");
			object obj29 = 0;
			object obj30 = null;
			while (true)
			{
				object obj31 = obj30 + obj30;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1281 @ r8_v64+v1308 @ rax_v107*8]");
				if (0 == (nint)typeof(IUniTaskAsyncDisposable))
				{
					break;
				}
				obj30++;
				object obj32 = obj30;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ r10_v12 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.String>>)+12E]");
				if ((nint)obj32 < 0)
				{
					continue;
				}
				goto IL_04d6;
			}
			object obj33 = obj30 + obj30;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1281 @ r8_v64+8+v1596 @ rcx_v78*8]");
			object obj34 = (nint)0 << 4;
			object obj35 = obj34 + 312;
			object obj36 = obj35 + num10;
			goto IL_0b3b;
			IL_0ab8:
			bool flag4 = (object)awaiter == null;
			awaiter5 = awaiter;
			num8 = num6;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw r9d,xmm7,4\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
				awaiter5 = awaiter;
				num8 = (nint)typeof(IUniTaskSource);
			}
			goto IL_05d3;
			IL_0b4a:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ r8_v6+8]");
			awaiter5 = (UniTask.Awaiter)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v871 @ r8_v6] (should have been resolved before IL gen)");
			IUniTaskAsyncEnumerator<string> uniTaskAsyncEnumerator3 = default(IUniTaskAsyncEnumerator<string>);
			_003Ce_003E5__3 = uniTaskAsyncEnumerator3;
			num6 = (nint)cancellationToken;
			_003C_003E7__wrap3 = null;
			_003C_003E7__wrap4 = 0;
			num4 = (nint)typeof(IUniTaskAsyncEnumerable<string>);
			goto IL_0088;
			IL_05d3:
			ExceptionDispatchInfo exceptionDispatchInfo = (ExceptionDispatchInfo)_003C_003E7__wrap3;
			if (_003C_003E7__wrap3 == null)
			{
				if (_003C_003E7__wrap4 == 1)
				{
					goto IL_0621;
				}
				if (_003C_003E7__wrap4 != 2)
				{
					_003C_003E7__wrap3 = null;
					_003Ce_003E5__3 = null;
				}
				_003C_003E1__state = -2;
				_003Ce_003E5__3 = null;
				object obj37 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844336B0");
				return;
			}
			nint num11 = (nint)exceptionDispatchInfo;
			nint num12 = (nint)typeof(Exception);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rcx_v30 (Il2CppClass<System.Exception>)+130]");
			object obj38 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ r8_v27 (Il2CppClass<System.Runtime.ExceptionServices.ExceptionDispatchInfo>)+130]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rcx_v30 (Il2CppClass<System.Exception>)+130]");
			if (num13 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ r8_v27 (Il2CppClass<System.Runtime.ExceptionServices.ExceptionDispatchInfo>)+C8]");
				object obj39 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rax_v40+FFFFFFF8+v721 @ rax_v39*8]");
				if (0 == (nint)typeof(Exception))
				{
					ex = (Exception)_003C_003E7__wrap3;
					ExceptionDispatchInfo exceptionDispatchInfo2 = ExceptionDispatchInfo.Capture(ex);
					throw new NullReferenceException();
				}
			}
			throw _003C_003E7__wrap3;
			IL_04d6:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj40 = default(object);
			obj36 = obj40;
			goto IL_0b3b;
			IL_0b3b:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1601 @ r8_v50] (should have been resolved before IL gen)");
			num6 = (nint)uniTaskAsyncEnumerator2;
			object obj41 = default(object);
			bool flag5 = obj41 == null;
			UniTask.Awaiter awaiter8 = (UniTask.Awaiter)obj41;
			uniTask = (UniTask<bool>)obj41;
			num4 = (nint)typeof(IUniTaskAsyncDisposable);
			awaiter = (UniTask.Awaiter)obj41;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw r9d,xmm6,4\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
				object obj42 = default(object);
				bool flag6 = obj42 != null;
				awaiter8 = (UniTask.Awaiter)obj41;
				uniTask = (UniTask<bool>)obj41;
				num6 = (nint)typeof(IUniTaskSource);
				num4 = (nint)typeof(IUniTaskAsyncDisposable);
				awaiter = (UniTask.Awaiter)obj41;
				if (!flag6)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = (UniTask.Awaiter)obj41;
					AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder2 = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter8, ref this);
					return;
				}
			}
			goto IL_0ab8;
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
	private struct _003CBindToCore_003Ed__6<T> : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public IUniTaskAsyncEnumerable<T> source;

		public CancellationToken cancellationToken;

		public bool rebindOnError;

		public Text text;

		private bool _003Crepeat_003E5__2;

		private IUniTaskAsyncEnumerator<T> _003Ce_003E5__3;

		private object _003C_003E7__wrap3;

		private int _003C_003E7__wrap4;

		private UniTask<bool>.Awaiter _003C_003Eu__1;

		private UniTask.Awaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0028: Expected O, but got I
			//IL_0050: Expected O, but got I
			//IL_006b: Expected O, but got I
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_0a43: Expected O, but got I
			//IL_009d: Expected O, but got I8
			//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a75: Expected O, but got Unknown
			//IL_0aa0: Expected O, but got I
			//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ad2: Expected O, but got Unknown
			//IL_0afc: Expected O, but got Ref
			//IL_0b1a: Expected O, but got I
			//IL_0b23: Expected O, but got I4
			//IL_0b28: Expected I, but got O
			//IL_00af: Expected O, but got I8
			//IL_01c4: Expected O, but got I
			//IL_0167: Expected O, but got I
			//IL_0191: Expected O, but got I8
			//IL_019a: Expected O, but got I4
			//IL_01a7: Expected O, but got I8
			//IL_014a: Expected O, but got I4
			//IL_0152: Expected O, but got Ref
			//IL_00e1: Expected O, but got I
			//IL_010b: Expected O, but got I8
			//IL_0118: Expected O, but got I8
			//IL_0128: Expected O, but got I
			//IL_0131: Expected O, but got I4
			//IL_0136: Expected I, but got O
			//IL_0376: Expected O, but got I
			//IL_0718: Expected O, but got I
			//IL_0bf6: Expected O, but got I
			//IL_0c04: Expected O, but got Ref
			//IL_0212: Expected O, but got I4
			//IL_038b: Expected O, but got I
			//IL_039b: Expected O, but got I
			//IL_030a: Expected O, but got I
			//IL_0914: Expected I, but got O
			//IL_0922: Expected I, but got O
			//IL_0932: Expected O, but got I
			//IL_0703: Expected I, but got O
			//IL_09c0: Expected O, but got I
			//IL_0338: Expected O, but got I
			//IL_034f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0354: Expected O, but got Unknown
			//IL_056f: Expected O, but got I
			//IL_0e50: Expected O, but got I
			//IL_07ba: Expected O, but got I4
			//IL_096e: Expected O, but got I
			//IL_0278: Expected O, but got Ref
			//IL_029d: Expected O, but got I4
			//IL_0220: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Expected O, but got Unknown
			//IL_08e6: Expected O, but got I8
			//IL_04f7: Expected O, but got I4
			//IL_0e29: Expected O, but got Ref
			//IL_05a7: Expected O, but got I
			//IL_05b0: Expected O, but got I4
			//IL_0879: Expected O, but got I
			//IL_0882: Unknown result type (might be due to invalid IL or missing references)
			//IL_0887: Expected O, but got Unknown
			//IL_088f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0894: Expected O, but got Unknown
			//IL_08fc: Expected O, but got Ref
			//IL_07c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_07cd: Expected O, but got Unknown
			//IL_0524: Expected O, but got I
			//IL_0836: Expected O, but got I
			//IL_083f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0844: Expected O, but got Unknown
			//IL_0cc7: Expected O, but got I
			//IL_0cd5: Expected O, but got Ref
			//IL_03e9: Expected O, but got I4
			//IL_053d: Expected O, but got Ref
			//IL_0548: Expected O, but got Ref
			//IL_05be: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c3: Expected O, but got Unknown
			//IL_04c8: Expected O, but got I
			//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d6: Expected O, but got Unknown
			//IL_0d64: Expected O, but got I
			//IL_0d89: Expected I, but got O
			//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fc: Expected O, but got Unknown
			//IL_0475: Expected O, but got I
			//IL_06c8: Expected O, but got I
			//IL_06d6: Expected I, but got O
			//IL_0658: Expected O, but got I4
			//IL_0685: Expected O, but got I
			//IL_069e: Expected O, but got Ref
			//IL_06a9: Expected O, but got Ref
			object obj2 = default(object);
			object obj = (object)(&obj2);
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
			_ = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v7 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1>)+40]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v9+FC]");
			object obj5 = (nint)0 + (nint)16;
			object obj6 = obj5 + 15;
			object obj7;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				_ = ref obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
				obj7 = (nint)0 + (nint)15;
				object obj8 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
				if ((nint)obj8 > 0)
				{
					goto IL_0a67;
				}
			}
			obj7 = 1152921504606846960L;
			goto IL_0a67;
			IL_0708:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+40]");
			Exception ex = (Exception)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+40]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+48]");
				if ((nint)0 == 1)
				{
					goto IL_0768;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+48]");
				if ((nint)0 != 2)
				{
					_ = 0;
					_ = 0;
				}
				_003CBindToCore_003Ed__6<T> obj9 = (_003CBindToCore_003Ed__6<T>)4294967294L;
				_ = 0;
				object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844336B0");
				return;
			}
			nint num3 = (nint)ex;
			nint num4 = (nint)typeof(Exception);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ r8_v86 (Il2CppClass<System.Exception>)+130]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ r9_v30 (Il2CppClass<System.Exception>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v708 @ r8_v86 (Il2CppClass<System.Exception>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ r9_v30 (Il2CppClass<System.Exception>)+C8]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ rax_v203+FFFFFFF8+v797 @ rax_v202*8]");
				if (0 == (nint)typeof(Exception))
				{
					ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(ex);
					throw new NullReferenceException();
				}
			}
			ExceptionDispatchInfo exceptionDispatchInfo2 = default(ExceptionDispatchInfo);
			throw exceptionDispatchInfo2;
			IL_0768:
			int num6 = _003C_003E1__state;
			object obj19;
			nint num8;
			if (_003C_003E1__state != 0)
			{
				nint num7 = 0;
				int value = ((int*)num6)->m_value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ r10_v15 (System.Int32)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_07f1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ r10_v15 (System.Int32)+B0]");
				num8 = 0;
				object obj13 = 0;
				while (true)
				{
					object obj14 = obj13 + obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1532 @ r9_v13 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+v922 @ rax_v198*8]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rax_v173 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1>)+8]");
					if (num9 == 0)
					{
						break;
					}
					obj13++;
					object obj15 = obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ r10_v15 (System.Int32)+12E]");
					if ((nint)obj15 < 0)
					{
						continue;
					}
					goto IL_07f1;
				}
				object obj16 = obj13 + obj13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1532 @ r9_v13 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+8+v1283 @ rcx_v141*8]");
				object obj17 = (nint)0 << 4;
				object obj18 = obj17 + 312;
				obj19 = obj18 + value;
				goto IL_0e40;
			}
			throw new NullReferenceException();
			IL_0a67:
			object obj20 = obj7 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
			object obj21 = (nint)0 + (nint)15;
			object obj22 = obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
			if ((nint)obj22 <= 0)
			{
				obj21 = 1152921504606846960L;
			}
			object obj23 = obj21 & -16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
			_ = 0;
			_ = 0;
			object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			bool flag = System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3+FC]");
			object obj25 = 0;
			object obj26 = 0;
			nint num10 = unchecked((nint)null);
			if (flag)
			{
				goto IL_0c8a;
			}
			nint num11;
			if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref this) == (void*)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+60]");
				object obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+60]");
				_ = 0;
				_ = 0;
				_ = 4294967295L;
				_003CBindToCore_003Ed__6<T> obj9 = (_003CBindToCore_003Ed__6<T>)4294967295L;
				obj24 = 4294967295L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+60]");
				obj25 = 0;
				obj26 = 0;
				num11 = unchecked((nint)null);
				goto IL_0e74;
			}
			_ = 0;
			obj26 = 0;
			ex = (Exception)(&obj2);
			goto IL_0768;
			IL_0c8a:
			object obj39 = default(object);
			object obj40 = default(object);
			object obj43 = default(object);
			object obj51 = default(object);
			object obj42;
			nint num12;
			while (true)
			{
				_003CBindToCore_003Ed__6<T> obj9;
				if (obj24 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+50]");
					obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+50]");
					_ = 0;
					_ = 0;
					_ = 4294967295L;
					obj9 = (_003CBindToCore_003Ed__6<T>)4294967295L;
					object obj27 = 0;
					obj24 = 4294967295L;
					num12 = num10;
					goto IL_02b1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+38]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+38]");
				object obj37;
				if ((nint)0 != 0)
				{
					nint num13 = 0;
					object obj29 = obj28;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ r10_v9+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0249;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ r10_v9+B0]");
					num8 = 0;
					object obj30 = 0;
					while (true)
					{
						object obj31 = obj30 + obj30;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1532 @ r9_v13 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+v850 @ rax_v156*8]");
						nint num14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v626 @ rax_v116 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1>)+18]");
						if (num14 == 0)
						{
							break;
						}
						obj30++;
						object obj32 = obj30;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ r10_v9+12E]");
						if ((nint)obj32 < 0)
						{
							continue;
						}
						goto IL_0249;
					}
					object obj33 = obj30 + obj30;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1532 @ r9_v13 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+8+v1095 @ rcx_v108*8]");
					object obj34 = (nint)0 + (nint)1;
					object obj35 = obj34 << 4;
					object obj36 = obj35 + 312;
					obj37 = obj36 + obj29;
					goto IL_0be6;
				}
				throw new NullReferenceException();
				IL_0420:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				object obj38 = obj39;
				goto IL_0caa;
				IL_0249:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj37 = obj40;
				goto IL_0be6;
				IL_0be6:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1102 @ r8_v40+8]");
				obj25 = 0;
				object obj41 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1102 @ r8_v40] (should have been resolved before IL gen)");
				obj42 = obj43;
				_ = 0;
				UniTask<bool> uniTask = (UniTask<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
				UniTaskStatus status = ((UniTask<bool>*)uniTask)->Status;
				bool flag2 = status == UniTaskStatus.Pending;
				obj26 = 0;
				num12 = 0;
				if (!flag2)
				{
					goto IL_02b1;
				}
				_ = 0;
				obj9 = (_003CBindToCore_003Ed__6<T>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+40]");
				_ = 0;
				nint num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2065 @ rax_v131 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1>)+28]");
				object obj44 = 0;
				nint num16 = 0;
				object obj45 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
				object obj46 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2066 @ rcx_v92] (should have been resolved before IL gen)");
				return;
				IL_0caa:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+60]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1814 @ rdx_v25+8]");
				object obj47 = 0;
				object obj48 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1829 @ rcx_v56+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				nint num17 = 0;
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB8900");
				object obj50;
				object obj49 = obj50;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2084 @ r8_v35+5F0]");
				obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+80]");
				num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2084 @ r8_v35+5E8] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+68]");
				num8 = 0;
				continue;
				IL_02b1:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+40]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+4A]");
					num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+40]");
					obj25 = 0;
					num12 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+48]");
					obj51 = 0;
				}
				_ = 0;
				if (obj51 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+28]");
				obj50 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+38]");
				object obj52 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+38]");
				if ((nint)0 != 0)
				{
					nint num19 = 0;
					object obj53 = obj52;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1324 @ r10_v7+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0420;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1324 @ r10_v7+B0]");
					num8 = 0;
					object obj54 = 0;
					while (true)
					{
						object obj55 = obj54 + obj54;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1532 @ r9_v13 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+v1534 @ rax_v101*8]");
						nint num20 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1069 @ rax_v77 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1>)+18]");
						if (num20 == 0)
						{
							break;
						}
						obj54++;
						object obj56 = obj54;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1324 @ r10_v7+12E]");
						if ((nint)obj56 < 0)
						{
							continue;
						}
						goto IL_0420;
					}
					object obj57 = obj54 + obj54;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1532 @ r9_v13 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncDisposable>)+8+v1807 @ rcx_v72*8]");
					object obj58 = (nint)0 << 4;
					object obj59 = obj58 + 312;
					obj38 = obj59 + obj53;
					goto IL_0caa;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+68]");
				num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+78]");
				obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1924 @ rax_v84 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1>)+48]");
				num10 = 0;
				throw new NullReferenceException();
			}
			_ = 2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+38]");
			if ((nint)0 == 0)
			{
				goto IL_0708;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+38]");
			nint num21 = 0;
			object obj60 = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ r10_v5+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_05e7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ r10_v5+B0]");
			object obj61 = 0;
			object obj62 = 0;
			while (true)
			{
				object obj63 = obj62 + obj62;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ r8_v23+v1341 @ rax_v72*8]");
				if (0 == (nint)typeof(IUniTaskAsyncDisposable))
				{
					break;
				}
				obj62++;
				object obj64 = obj62;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ r10_v5+12E]");
				if ((nint)obj64 < 0)
				{
					continue;
				}
				goto IL_05e7;
			}
			object obj65 = obj62 + obj62;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1338 @ r8_v23+8+v1722 @ rcx_v49*8]");
			object obj66 = (nint)0 << 4;
			object obj67 = obj66 + 312;
			object obj68 = obj67 + obj60;
			goto IL_0e1b;
			IL_07f1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj69 = default(object);
			obj19 = obj69;
			goto IL_0e40;
			IL_0e40:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1288 @ r8_v67+8]");
			obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1288 @ r8_v67] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1<T>)+18]");
			num10 = 0;
			_ = 0;
			_ = 0;
			goto IL_0c8a;
			IL_05e7:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj70 = default(object);
			obj68 = obj70;
			goto IL_0e1b;
			IL_0e1b:
			object obj71 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1727 @ r8_v7] (should have been resolved before IL gen)");
			object obj72 = default(object);
			obj42 = obj72;
			num11 = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+30]");
			obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+30]");
			bool flag3 = (nint)0 == 0;
			num8 = (nint)typeof(IUniTaskAsyncDisposable);
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+38]");
				num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
				object obj73 = default(object);
				if (obj73 == null)
				{
					_003CBindToCore_003Ed__6<T> obj9 = (_003CBindToCore_003Ed__6<T>)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+30]");
					_ = 0;
					nint num22 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2162 @ rax_v45 (Il2CppRgctx<Cysharp.Threading.Tasks.UnityBindingExtensions+<BindToCore>d__6`1>)+50]");
					object obj74 = 0;
					nint num23 = 0;
					object obj75 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
					object obj76 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2163 @ rcx_v32] (should have been resolved before IL gen)");
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+30]");
				obj25 = 0;
				num11 = (nint)typeof(IUniTaskSource);
			}
			goto IL_0e74;
			IL_0e74:
			bool flag4 = obj25 == null;
			num12 = num11;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+38]");
				num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
				num12 = (nint)typeof(IUniTaskSource);
			}
			goto IL_0708;
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
	private struct _003CBindToCore_003Ed__9 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

		public IUniTaskAsyncEnumerable<bool> source;

		public CancellationToken cancellationToken;

		public bool rebindOnError;

		public Selectable selectable;

		private bool _003Crepeat_003E5__2;

		private IUniTaskAsyncEnumerator<bool> _003Ce_003E5__3;

		private object _003C_003E7__wrap3;

		private int _003C_003E7__wrap4;

		private UniTask<bool>.Awaiter _003C_003Eu__1;

		private UniTask.Awaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_00bd: Expected O, but got I4
			//IL_00cc: Expected I4, but got I8
			//IL_00e2: Expected I4, but got I8
			//IL_00eb: Expected O, but got I4
			//IL_0121: Expected I, but got O
			//IL_004d: Expected O, but got I4
			//IL_005c: Expected I4, but got I8
			//IL_006a: Expected I4, but got I8
			//IL_0073: Expected O, but got I4
			//IL_09a4: Expected O, but got I
			//IL_0159: Expected O, but got I
			//IL_0643: Expected I, but got O
			//IL_0269: Expected O, but got I
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Expected O, but got Unknown
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Expected O, but got Unknown
			//IL_02df: Expected I, but got O
			//IL_0b49: Expected O, but got I
			//IL_0b65: Expected I4, but got O
			//IL_067b: Expected O, but got I
			//IL_07ec: Expected I, but got O
			//IL_07fa: Expected I, but got O
			//IL_080a: Expected O, but got I
			//IL_05b5: Expected I, but got O
			//IL_01e1: Expected I, but got O
			//IL_01ea: Expected O, but got I4
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_0449: Expected I, but got O
			//IL_02f5: Expected I, but got O
			//IL_06e7: Expected I, but got O
			//IL_0752: Expected O, but got I
			//IL_075b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0760: Expected O, but got Unknown
			//IL_0768: Unknown result type (might be due to invalid IL or missing references)
			//IL_076d: Expected O, but got Unknown
			//IL_0846: Expected O, but got I
			//IL_0424: Expected O, but got Ref
			//IL_037c: Expected O, but got I4
			//IL_068e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0693: Expected O, but got Unknown
			//IL_07bd: Expected I4, but got I8
			//IL_0481: Expected O, but got I
			//IL_032d: Expected O, but got I
			//IL_07d4: Expected O, but got Ref
			//IL_04dc: Expected I, but got O
			//IL_03a1: Expected O, but got I4
			//IL_03b7: Expected I, but got O
			//IL_070f: Expected O, but got I
			//IL_0718: Unknown result type (might be due to invalid IL or missing references)
			//IL_071d: Expected O, but got Unknown
			//IL_0725: Unknown result type (might be due to invalid IL or missing references)
			//IL_072a: Expected O, but got Unknown
			//IL_03df: Expected O, but got I
			//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ed: Expected O, but got Unknown
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Expected O, but got Unknown
			//IL_0494: Unknown result type (might be due to invalid IL or missing references)
			//IL_0499: Expected O, but got Unknown
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_0345: Expected O, but got Unknown
			//IL_0a91: Expected I, but got O
			//IL_052a: Expected I, but got O
			//IL_0538: Expected I, but got O
			//IL_0573: Expected O, but got Ref
			int num = _003C_003E1__state;
			bool flag = _003C_003E1__state == 0;
			nint num2 = default(nint);
			bool flag2 = (byte)num2 != 0;
			if (flag)
			{
				goto IL_0088;
			}
			UniTask.Awaiter awaiter;
			if (_003C_003E1__state == 1)
			{
				awaiter = _003C_003Eu__2;
				_003C_003Eu__2 = (UniTask.Awaiter)0;
				_003C_003E1__state = -1;
				num = -1;
				UniTask.Awaiter awaiter2 = (UniTask.Awaiter)0;
				goto IL_0aa7;
			}
			_003Crepeat_003E5__2 = false;
			goto IL_0608;
			IL_06b7:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj2 = default(object);
			object obj = obj2;
			goto IL_0b39;
			IL_0608:
			IUniTaskAsyncEnumerable<bool> uniTaskAsyncEnumerable = source;
			CancellationToken cancellationToken = this.cancellationToken;
			if (source != null)
			{
				nint num3 = (nint)uniTaskAsyncEnumerable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r10_v6 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<System.Boolean>>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_06b7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r10_v6 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<System.Boolean>>)+B0]");
				object obj3 = 0;
				object obj4 = null;
				while (true)
				{
					object obj5 = obj4 + obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v21+v607 @ rax_v37*8]");
					if (0 == (nint)typeof(IUniTaskAsyncEnumerable<bool>))
					{
						break;
					}
					obj4++;
					object obj6 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r10_v6 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<System.Boolean>>)+12E]");
					if ((nint)obj6 < 0)
					{
						continue;
					}
					goto IL_06b7;
				}
				object obj7 = obj4 + obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ r8_v21+8+v866 @ rcx_v27*8]");
				object obj8 = (nint)0 << 4;
				object obj9 = obj8 + 312;
				obj = obj9 + num3;
				goto IL_0b39;
			}
			Exception ex = (Exception)cancellationToken;
			throw new NullReferenceException();
			IL_0088:
			nint num4;
			UniTask.Awaiter awaiter4 = default(UniTask.Awaiter);
			object obj20 = default(object);
			object obj21 = default(object);
			object obj22 = default(object);
			UniTask<bool> uniTask = default(UniTask<bool>);
			UniTask<bool>.Awaiter awaiter6 = default(UniTask<bool>.Awaiter);
			bool flag4 = default(bool);
			UniTask<bool>.Awaiter awaiter7 = default(UniTask<bool>.Awaiter);
			nint num7;
			UniTask.Awaiter awaiter5;
			nint num5 = default(nint);
			while (true)
			{
				UniTask<bool>.Awaiter awaiter3;
				UniTask.Awaiter awaiter2;
				if (num == 0)
				{
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = (UniTask<bool>.Awaiter)0;
					_003C_003E1__state = -1;
					num4 = num5;
					num = -1;
					awaiter2 = (UniTask.Awaiter)0;
					goto IL_01f8;
				}
				IUniTaskAsyncEnumerator<bool> uniTaskAsyncEnumerator = _003Ce_003E5__3;
				object obj18;
				if (_003Ce_003E5__3 != null)
				{
					nint num6 = (nint)uniTaskAsyncEnumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ r10_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.Boolean>>)+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0195;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ r10_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.Boolean>>)+B0]");
					object obj10 = 0;
					object obj11 = null;
					while (true)
					{
						object obj12 = obj11 + obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ r8_v92+v527 @ rax_v160*8]");
						if (0 == (nint)typeof(IUniTaskAsyncEnumerator<bool>))
						{
							break;
						}
						obj11++;
						object obj13 = obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ r10_v15 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.Boolean>>)+12E]");
						if ((nint)obj13 < 0)
						{
							continue;
						}
						goto IL_0195;
					}
					object obj14 = obj11 + obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ r8_v92+8+v778 @ rcx_v116*8]");
					object obj15 = (nint)0 + (nint)1;
					object obj16 = obj15 << 4;
					object obj17 = obj16 + 312;
					obj18 = obj17 + num6;
					goto IL_0994;
				}
				throw new NullReferenceException();
				IL_0369:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				awaiter4 = (UniTask.Awaiter)0;
				object obj19 = obj20;
				goto IL_09f2;
				IL_0195:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj18 = obj21;
				goto IL_0994;
				IL_0994:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ r8_v76+8]");
				awaiter5 = (UniTask.Awaiter)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v785 @ r8_v76] (should have been resolved before IL gen)");
				awaiter3 = (UniTask<bool>.Awaiter)obj22;
				UniTaskStatus status = uniTask.Status;
				bool flag3 = status == UniTaskStatus.Pending;
				flag2 = false;
				num4 = (nint)typeof(IUniTaskAsyncEnumerator<bool>);
				awaiter2 = (UniTask.Awaiter)0;
				if (!flag3)
				{
					goto IL_01f8;
				}
				_003C_003E1__state = 0;
				_003C_003Eu__1 = (UniTask<bool>.Awaiter)obj22;
				AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter6, ref this);
				return;
				IL_09f2:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1529 @ rdx_v47] (should have been resolved before IL gen)");
				selectable.interactable = flag4;
				awaiter5 = (UniTask.Awaiter)0;
				flag2 = flag4;
				num5 = (nint)typeof(IUniTaskAsyncEnumerator<bool>);
				continue;
				IL_01f8:
				if ((object)awaiter3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw r9d,xmm6,5\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
					awaiter5 = (UniTask.Awaiter)awaiter3;
					num7 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					num7 = (flag2 ? 1 : 0);
					awaiter7 = awaiter3;
				}
				_003Crepeat_003E5__2 = false;
				if ((object)awaiter7 == null)
				{
					break;
				}
				uniTaskAsyncEnumerator = _003Ce_003E5__3;
				bool flag5 = _003Ce_003E5__3 == null;
				num5 = (nint)typeof(IUniTaskAsyncEnumerator<bool>);
				if (!flag5)
				{
					nint num8 = (nint)uniTaskAsyncEnumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v14 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.Boolean>>)+12E]");
					if ((nint)0 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v14 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.Boolean>>)+B0]");
						awaiter4 = (UniTask.Awaiter)0;
						object obj23 = null;
						while (true)
						{
							object obj24 = obj23 + obj23;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ r8_v69 (Cysharp.Threading.Tasks.UniTask+Awaiter)+v1062 @ rax_v119*8]");
							if (0 == (nint)typeof(IUniTaskAsyncEnumerator<bool>))
							{
								break;
							}
							obj23++;
							object obj25 = obj23;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r10_v14 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.Boolean>>)+12E]");
							if ((nint)obj25 < 0)
							{
								continue;
							}
							goto IL_0369;
						}
						object obj26 = obj23 + obj23;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ r8_v69 (Cysharp.Threading.Tasks.UniTask+Awaiter)+8+v1524 @ rcx_v89*8]");
						object obj27 = (nint)0 << 4;
						object obj28 = obj27 + 312;
						obj19 = obj28 + num8;
						goto IL_09f2;
					}
					goto IL_0369;
				}
				awaiter5 = awaiter4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1529 @ rdx_v47+8]");
				flag2 = false;
				throw new NullReferenceException();
			}
			_003C_003E7__wrap4 = 2;
			bool flag6 = _003Ce_003E5__3 == null;
			num5 = num4;
			if (flag6)
			{
				goto IL_05ba;
			}
			IUniTaskAsyncEnumerator<bool> uniTaskAsyncEnumerator2 = _003Ce_003E5__3;
			nint num9 = (nint)uniTaskAsyncEnumerator2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ r10_v12 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.Boolean>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_04bd;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ r10_v12 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.Boolean>>)+B0]");
			object obj29 = 0;
			object obj30 = null;
			while (true)
			{
				object obj31 = obj30 + obj30;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1280 @ r8_v64+v1307 @ rax_v107*8]");
				if (0 == (nint)typeof(IUniTaskAsyncDisposable))
				{
					break;
				}
				obj30++;
				object obj32 = obj30;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ r10_v12 (Il2CppClass<Cysharp.Threading.Tasks.IUniTaskAsyncEnumerator`1<System.Boolean>>)+12E]");
				if ((nint)obj32 < 0)
				{
					continue;
				}
				goto IL_04bd;
			}
			object obj33 = obj30 + obj30;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1280 @ r8_v64+8+v1594 @ rcx_v78*8]");
			object obj34 = (nint)0 << 4;
			object obj35 = obj34 + 312;
			object obj36 = obj35 + num9;
			goto IL_0b2a;
			IL_0aa7:
			bool flag7 = (object)awaiter == null;
			awaiter5 = awaiter;
			num7 = num2;
			if (!flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw r9d,xmm7,4\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180006070");
				awaiter5 = awaiter;
				num7 = (nint)typeof(IUniTaskSource);
			}
			goto IL_05ba;
			IL_0b39:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v871 @ r8_v6+8]");
			awaiter5 = (UniTask.Awaiter)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v871 @ r8_v6] (should have been resolved before IL gen)");
			IUniTaskAsyncEnumerator<bool> uniTaskAsyncEnumerator3 = default(IUniTaskAsyncEnumerator<bool>);
			_003Ce_003E5__3 = uniTaskAsyncEnumerator3;
			flag2 = (byte)(int)cancellationToken != 0;
			_003C_003E7__wrap3 = null;
			_003C_003E7__wrap4 = 0;
			num5 = (nint)typeof(IUniTaskAsyncEnumerable<bool>);
			goto IL_0088;
			IL_05ba:
			ExceptionDispatchInfo exceptionDispatchInfo = (ExceptionDispatchInfo)_003C_003E7__wrap3;
			if (_003C_003E7__wrap3 == null)
			{
				if (_003C_003E7__wrap4 == 1)
				{
					goto IL_0608;
				}
				if (_003C_003E7__wrap4 != 2)
				{
					_003C_003E7__wrap3 = null;
					_003Ce_003E5__3 = null;
				}
				_003C_003E1__state = -2;
				_003Ce_003E5__3 = null;
				object obj37 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1844336B0");
				return;
			}
			nint num10 = (nint)exceptionDispatchInfo;
			nint num11 = (nint)typeof(Exception);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rcx_v30 (Il2CppClass<System.Exception>)+130]");
			object obj38 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ r8_v27 (Il2CppClass<System.Runtime.ExceptionServices.ExceptionDispatchInfo>)+130]");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rcx_v30 (Il2CppClass<System.Exception>)+130]");
			if (num12 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ r8_v27 (Il2CppClass<System.Runtime.ExceptionServices.ExceptionDispatchInfo>)+C8]");
				object obj39 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rax_v40+FFFFFFF8+v721 @ rax_v39*8]");
				if (0 == (nint)typeof(Exception))
				{
					ex = (Exception)_003C_003E7__wrap3;
					ExceptionDispatchInfo exceptionDispatchInfo2 = ExceptionDispatchInfo.Capture(ex);
					throw new NullReferenceException();
				}
			}
			throw _003C_003E7__wrap3;
			IL_04bd:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj40 = default(object);
			obj36 = obj40;
			goto IL_0b2a;
			IL_0b2a:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1599 @ r8_v50] (should have been resolved before IL gen)");
			num2 = (nint)uniTaskAsyncEnumerator2;
			object obj41 = default(object);
			bool flag8 = obj41 == null;
			UniTask.Awaiter awaiter8 = (UniTask.Awaiter)obj41;
			uniTask = (UniTask<bool>)obj41;
			num5 = (nint)typeof(IUniTaskAsyncDisposable);
			awaiter = (UniTask.Awaiter)obj41;
			if (!flag8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"pextrw r9d,xmm6,4\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180486000");
				object obj42 = default(object);
				bool flag9 = obj42 != null;
				awaiter8 = (UniTask.Awaiter)obj41;
				uniTask = (UniTask<bool>)obj41;
				num2 = (nint)typeof(IUniTaskSource);
				num5 = (nint)typeof(IUniTaskAsyncDisposable);
				awaiter = (UniTask.Awaiter)obj41;
				if (!flag9)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = (UniTask.Awaiter)obj41;
					AsyncUniTaskVoidMethodBuilder asyncUniTaskVoidMethodBuilder2 = (AsyncUniTaskVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncUniTaskVoidMethodBuilder*)asyncUniTaskVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter8, ref this);
					return;
				}
			}
			goto IL_0aa7;
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

	public static void BindTo(IUniTaskAsyncEnumerable<string> source, Text text, bool rebindOnError = true)
	{
		CancellationToken destroyCancellationToken = text.destroyCancellationToken;
		UniTaskVoid uniTaskVoid = BindToCore(source, text, destroyCancellationToken, rebindOnError);
	}

	public static void BindTo(IUniTaskAsyncEnumerable<string> source, Text text, CancellationToken cancellationToken, bool rebindOnError = true)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1 Invalid \"Jump target not found in method: 0x185D82410\"");
	}

	private static UniTaskVoid BindToCore(IUniTaskAsyncEnumerable<string> source, Text text, CancellationToken cancellationToken, bool rebindOnError)
	{
		//IL_001a: Expected O, but got I4
		_003CBindToCore_003Ed__2 obj = default(_003CBindToCore_003Ed__2);
		obj.MoveNext();
		return (UniTaskVoid)0;
	}

	public static void BindTo<T>(IUniTaskAsyncEnumerable<T> source, Text text, bool rebindOnError = true)
	{
		CancellationToken destroyCancellationToken = text.destroyCancellationToken;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v54 @ r10_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
	}

	public static void BindTo<T>(IUniTaskAsyncEnumerable<T> source, Text text, CancellationToken cancellationToken, bool rebindOnError = true)
	{
		//IL_0047: Expected O, but got I
		//IL_0057: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2+8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v45 @ r10_v1] (should have been resolved before IL gen)");
	}

	public static void BindTo<T>(AsyncReactiveProperty<T> source, Text text, bool rebindOnError = true)
	{
		CancellationToken destroyCancellationToken = text.destroyCancellationToken;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v54 @ r10_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
	}

	private static UniTaskVoid BindToCore<T>(IUniTaskAsyncEnumerable<T> source, Text text, CancellationToken cancellationToken, bool rebindOnError)
	{
		//IL_004c: Expected O, but got I
		//IL_005c: Expected O, but got I
		//IL_006c: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v7+10]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v305 @ r9_v2] (should have been resolved before IL gen)");
		return (UniTaskVoid)0;
	}

	public static void BindTo(IUniTaskAsyncEnumerable<bool> source, Selectable selectable, bool rebindOnError = true)
	{
		CancellationToken destroyCancellationToken = selectable.destroyCancellationToken;
		UniTaskVoid uniTaskVoid = BindToCore(source, selectable, destroyCancellationToken, rebindOnError);
	}

	public static void BindTo(IUniTaskAsyncEnumerable<bool> source, Selectable selectable, CancellationToken cancellationToken, bool rebindOnError = true)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1 Invalid \"Jump target not found in method: 0x185D82690\"");
	}

	private static UniTaskVoid BindToCore(IUniTaskAsyncEnumerable<bool> source, Selectable selectable, CancellationToken cancellationToken, bool rebindOnError)
	{
		//IL_001a: Expected O, but got I4
		_003CBindToCore_003Ed__9 obj = default(_003CBindToCore_003Ed__9);
		obj.MoveNext();
		return (UniTaskVoid)0;
	}

	public static void BindTo<TSource, TObject>(IUniTaskAsyncEnumerable<TSource> source, TObject monoBehaviour, Action<TObject, TSource> bindAction, bool rebindOnError = true) where TObject : MonoBehaviour
	{
		//IL_0054: Expected O, but got I
		//IL_0064: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		CancellationToken destroyCancellationToken = monoBehaviour.destroyCancellationToken;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_28+38]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v3+18]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v63 @ r10_v1+10] (should have been resolved before IL gen)");
	}

	public unsafe static void BindTo<TSource, TObject>(IUniTaskAsyncEnumerable<TSource> source, TObject bindTarget, Action<TObject, TSource> bindAction, CancellationToken cancellationToken, bool rebindOnError = true)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_0079: Expected O, but got I
		//IL_0089: Expected O, but got I
		//IL_009f: Expected O, but got I
		//IL_00f0: Expected O, but got Ref
		//IL_0100: Expected O, but got I
		//IL_0108: Expected O, but got Ref
		//IL_0118: Expected O, but got I
		//IL_012e: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_0175: Expected O, but got I
		//IL_018b: Expected O, but got I
		//IL_01a5: Expected O, but got Ref
		//IL_01c3: Expected O, but got I
		//IL_01e5: Expected O, but got I
		//IL_0200: Expected O, but got Ref
		//IL_0213: Expected O, but got Ref
		//IL_0228: Expected O, but got I
		//IL_023d: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+88]");
		IUniTaskAsyncEnumerable<TSource> uniTaskAsyncEnumerable = (IUniTaskAsyncEnumerable<TSource>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		bool flag = (nint)0 != 0;
		IUniTaskAsyncEnumerable<TSource> uniTaskAsyncEnumerable2 = source;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			uniTaskAsyncEnumerable2 = uniTaskAsyncEnumerable;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2+8]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v1+FC]");
		object obj5 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v1+FC]");
		object obj7 = default(object);
		TObject val;
		if ((nint)obj5 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			val = (TObject)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
			object obj6 = 0;
			obj7 = (object)(&obj2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v7+8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v2+28]");
			object obj9 = (nint)0 >> 31;
			if (obj9 == null)
			{
				goto IL_014b;
			}
		}
		val = bindTarget;
		goto IL_014b;
		IL_014b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v11+8]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v4+28]");
		object obj12 = (nint)0 >> 31;
		bool flag2 = obj12 != null;
		object obj13 = (object)(&obj2);
		if (!flag2)
		{
			obj13 = obj7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj14 = 0;
		obj = source;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v14+18]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
		_ = 0;
		object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
		object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rax_v18+18]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v108 @ r10_v1+10] (should have been resolved before IL gen)");
	}

	private unsafe static UniTaskVoid BindToCore<TSource, TObject>(IUniTaskAsyncEnumerable<TSource> source, TObject bindTarget, Action<TObject, TSource> bindAction, CancellationToken cancellationToken, bool rebindOnError)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0018: Expected O, but got I
		//IL_0074: Expected O, but got I
		//IL_0084: Expected O, but got I
		//IL_009a: Expected O, but got I
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0203: Expected O, but got I
		//IL_0221: Expected O, but got I
		//IL_0264: Expected O, but got I
		//IL_027c: Expected O, but got I
		//IL_028c: Expected O, but got I
		//IL_02a1: Expected O, but got Ref
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_00cb: Expected O, but got I8
		//IL_02d8: Expected O, but got I4
		//IL_0410: Expected O, but got I
		//IL_0428: Expected O, but got I
		//IL_0438: Expected O, but got I
		//IL_044d: Expected O, but got Ref
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_048b: Expected O, but got I
		//IL_04a3: Expected O, but got I
		//IL_04b3: Expected O, but got I
		//IL_04c8: Expected O, but got Ref
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Expected O, but got Unknown
		//IL_00e0: Expected O, but got I
		//IL_00ee: Expected O, but got Ref
		//IL_00fe: Expected O, but got I
		//IL_0114: Expected O, but got I
		//IL_0506: Expected O, but got I
		//IL_051e: Expected O, but got I
		//IL_052e: Expected O, but got I
		//IL_0543: Expected O, but got Ref
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Expected O, but got Unknown
		//IL_0304: Expected O, but got I
		//IL_0322: Expected O, but got I
		//IL_033c: Expected O, but got I
		//IL_0354: Expected O, but got I
		//IL_0364: Expected O, but got I
		//IL_0379: Expected O, but got Ref
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_03d9: Expected O, but got I
		//IL_0581: Expected O, but got I
		//IL_0599: Expected O, but got I
		//IL_05a9: Expected O, but got I
		//IL_05be: Expected O, but got Ref
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Expected O, but got Unknown
		//IL_03b7: Expected O, but got I
		//IL_03eb: Expected O, but got I8
		//IL_014e: Expected O, but got I
		//IL_0166: Expected O, but got I
		//IL_0176: Expected O, but got I
		//IL_0186: Expected O, but got I
		//IL_019b: Expected O, but got Ref
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_0400: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+68]");
		IUniTaskAsyncEnumerable<TSource> uniTaskAsyncEnumerable = (IUniTaskAsyncEnumerable<TSource>)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		bool flag = (nint)0 != 0;
		IUniTaskAsyncEnumerable<TSource> uniTaskAsyncEnumerable2 = source;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			uniTaskAsyncEnumerable2 = uniTaskAsyncEnumerable;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r9_v1+FC]");
		object obj5 = (nint)0 + (nint)15;
		object obj6 = obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ r9_v1+FC]");
		if ((nint)obj6 <= 0)
		{
			obj5 = 1152921504606846960L;
		}
		object obj7 = obj5 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj8 = 0;
		object obj9 = obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v2+FC]");
		object obj10 = (nint)0 + (nint)15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v2+FC]");
		if ((nint)obj10 <= 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj11 = 0;
		object obj12 = obj11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v4+80]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v5+30]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v5+38]");
		object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj16 = obj15 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v12+28]");
		if ((nint)0 >= (nint)0)
		{
		}
		obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj17 = 0;
		object obj18 = obj17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v9+80]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v7+50]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v7+58]");
		object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj22 = obj21 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v15+28]");
		if ((nint)0 < (nint)0)
		{
			obj22 = source;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
			object obj23 = 0;
			TObject val = (TObject)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v17+10]");
			object obj24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rcx_v13+28]");
			object obj25 = (nint)0 >> 31;
			if (obj25 != null)
			{
				val = bindTarget;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
			object obj26 = 0;
			object obj27 = obj26;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rcx_v15+80]");
			object obj28 = (nint)0 + (nint)192;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7170");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
			object obj29 = 0;
			object obj30 = obj29;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ rcx_v17+80]");
			object obj31 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rdx_v13+B0]");
			object obj32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rdx_v13+B8]");
			object obj33 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj34 = obj33 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v24+28]");
			if ((nint)0 >= (nint)0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+50]");
			obj34 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj35 = 0;
		object obj36 = obj35;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rcx_v21+80]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdx_v15+70]");
		object obj38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ rdx_v15+78]");
		object obj39 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj40 = obj39 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rax_v28+28]");
		if ((nint)0 < (nint)0)
		{
			obj40 = cancellationToken;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj41 = 0;
		object obj42 = obj41;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v25+80]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rdx_v19+90]");
		object obj44 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rdx_v19+98]");
		object obj45 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj46 = obj45 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v31+28]");
		if ((nint)0 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+60]");
			obj46 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
		object obj47 = 0;
		object obj48 = obj47;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rcx_v29+80]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rdx_v23+10]");
		object obj50 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rdx_v23+18]");
		object obj51 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
		object obj52 = obj51 - 16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v35+28]");
		if ((nint)0 < (nint)0)
		{
			obj52 = 4294967295L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rdi_v1 (Cysharp.Threading.Tasks.IUniTaskAsyncEnumerable`1<TSource>)+38]");
			object obj53 = 0;
			object obj54 = obj53;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rax_v37+20]");
			object obj55 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v641 @ rcx_v33+80]");
			object obj56 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r9_v10+30]");
			object obj57 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r9_v10+38]");
			object obj58 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(byteOffset: 0, source: ref obj2));
			object obj59 = obj58 - 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v38+28]");
			if ((nint)0 >= (nint)0)
			{
				obj59 = obj58;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v642 @ r11_v1] (should have been resolved before IL gen)");
			return (UniTaskVoid)0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-20), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}
}
