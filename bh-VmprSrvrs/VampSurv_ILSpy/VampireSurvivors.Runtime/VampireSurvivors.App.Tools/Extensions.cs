using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Rewired;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Tools;

public static class Extensions
{
	private sealed class _003CSplitList_003Ed__3<T> : IEnumerable<List<T>>, IEnumerable, IEnumerator<List<T>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private List<T> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private List<T> locations;

		public List<T> _003C_003E3__locations;

		private int nSize;

		public int _003C_003E3__nSize;

		private int _003Ci_003E5__2;

		List<T> IEnumerator<List<T>>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CSplitList_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			int num = default(int);
			_003C_003El__initialThreadId = num;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0196: Expected I4, but got I8
			//IL_0165: Expected I4, but got O
			//IL_006e: Expected O, but got I
			//IL_00de: Expected O, but got I
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected I4, but got Unknown
			//IL_01cb: Expected O, but got I
			if (_003C_003E1__state == 0)
			{
				_003Ci_003E5__2 = _003C_003E1__state;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0149;
				}
				int num = _003Ci_003E5__2 + nSize;
				_003Ci_003E5__2 = num;
			}
			_003C_003E1__state = -1;
			if (locations != null)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v3 (Il2CppRgctx<VampireSurvivors.App.Tools.Extensions+<SplitList>d__3`1>)+10]");
				object obj = 0;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v123 @ rax_v8] (should have been resolved before IL gen)");
				object obj2 = default(object);
				if (_003Ci_003E5__2 >= (nint)obj2)
				{
					goto IL_0149;
				}
				int num4 = nSize;
				if (locations != null)
				{
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v6 (Il2CppRgctx<VampireSurvivors.App.Tools.Extensions+<SplitList>d__3`1>)+10]");
					object obj3 = 0;
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v231 @ rax_v12] (should have been resolved before IL gen)");
					object obj4 = default(object);
					int num7 = obj4 - _003Ci_003E5__2;
					if (nSize > num7)
					{
						num4 = num7;
					}
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ r9_v2 (Il2CppRgctx<VampireSurvivors.App.Tools.Extensions+<SplitList>d__3`1>)+18]");
					object obj5 = 0;
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v271 @ rax_v17] (should have been resolved before IL gen)");
					List<T> list = default(List<T>);
					_003C_003E2__current = list;
					_003C_003E1__state = 1;
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0149:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}

		IEnumerator<List<T>> IEnumerable<List<T>>.GetEnumerator()
		{
			//IL_0088: Expected O, but got I
			_003CSplitList_003Ed__3<T> obj2;
			if (_003C_003E1__state == -2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
				object obj = default(object);
				if (_003C_003El__initialThreadId == (nint)obj)
				{
					_003C_003E1__state = 0;
					obj2 = this;
					goto IL_00d5;
				}
			}
			nint num = 0;
			_003CSplitList_003Ed__3<T> obj3 = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rcx_v13 (Il2CppRgctx<VampireSurvivors.App.Tools.Extensions+<SplitList>d__3`1>)+20]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v79 @ rax_v19] (should have been resolved before IL gen)");
			obj2 = obj3;
			goto IL_00d5;
			IL_00d5:
			if (obj2 != null)
			{
				obj2.locations = _003C_003E3__locations;
				obj2.nSize = _003C_003E3__nSize;
				return obj2;
			}
			return (IEnumerator<List<T>>)new NullReferenceException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//IL_0016: Expected O, but got I
			//IL_0034: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ r8_v1 (Il2CppRgctx<VampireSurvivors.App.Tools.Extensions+<SplitList>d__3`1>)+30]");
			object obj = 0;
			object obj2 = obj;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rdx_v1 (Il2CppRgctx<VampireSurvivors.App.Tools.Extensions+<SplitList>d__3`1>)+30]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ r8_v2 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	public static void Shuffle<T>(IList<T> list)
	{
		//IL_03e3: Expected I, but got O
		//IL_00b5: Expected O, but got I
		//IL_00be: Expected O, but got I4
		//IL_0442: Expected I, but got O
		//IL_02d1: Expected O, but got I
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_012b: Expected O, but got I
		//IL_0134: Expected O, but got I4
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_04a1: Expected I, but got O
		//IL_0314: Expected O, but got I
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_0200: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_01aa: Expected O, but got I4
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0500: Expected I, but got O
		//IL_0357: Expected O, but got I
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_027e: Expected O, but got I
		//IL_021f: Expected O, but got I
		//IL_0228: Expected O, but got I4
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_03a8: Expected O, but got I
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		int num = default(int);
		if (num <= 1)
		{
			return;
		}
		int num2 = num;
		object obj8 = default(object);
		object obj10 = default(object);
		bool flag;
		do
		{
			int num3 = num2 - 1;
			int num4 = random.Next(num2);
			nint num5 = (nint)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ r10_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_00f5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ r10_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			object obj = 0;
			object obj2 = 0;
			while (true)
			{
				object obj3 = obj2 + obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ r9_v18+v327 @ rax_v68*8]");
				if ((nint)0 == 0)
				{
					break;
				}
				obj2++;
				object obj4 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ r10_v4 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)obj4 < 0)
				{
					continue;
				}
				goto IL_00f5;
			}
			object obj5 = obj2 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ r9_v18+8+v384 @ rcx_v57*8]");
			object obj6 = (nint)0 << 4;
			object obj7 = obj6 + 312;
			obj8 = obj7 + num5;
			goto IL_0104;
			IL_016b:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_017a;
			IL_017a:
			object obj9 = obj10;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ rax_v21] (should have been resolved before IL gen)");
			nint num6 = (nint)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r10_v6 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_01e1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r10_v6 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			obj9 = 0;
			object obj11 = 0;
			while (true)
			{
				object obj12 = obj11 + obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ r9_v14+v553 @ rax_v46*8]");
				if ((nint)0 == 0)
				{
					break;
				}
				obj11++;
				object obj13 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r10_v6 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)obj13 < 0)
				{
					continue;
				}
				goto IL_01e1;
			}
			object obj14 = obj11 + obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ r9_v14+8+v610 @ rcx_v43*8]");
			object obj15 = (nint)0 + (nint)1;
			object obj16 = obj15 << 4;
			object obj17 = obj16 + 312;
			object obj18 = obj17 + num6;
			goto IL_01f0;
			IL_01f0:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ rax_v24+8]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v607 @ rax_v24] (should have been resolved before IL gen)");
			nint num7 = (nint)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ r10_v7 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_025f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ r10_v7 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			obj19 = 0;
			object obj20 = 0;
			while (true)
			{
				object obj21 = obj20 + obj20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ r9_v12+v667 @ rax_v34*8]");
				if ((nint)0 == 0)
				{
					break;
				}
				obj20++;
				object obj22 = obj20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ r10_v7 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)obj22 < 0)
				{
					continue;
				}
				goto IL_025f;
			}
			object obj23 = obj20 + obj20;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ r9_v12+8+v724 @ rcx_v36*8]");
			object obj24 = (nint)0 + (nint)1;
			object obj25 = obj24 << 4;
			object obj26 = obj25 + 312;
			object obj27 = obj26 + num7;
			goto IL_026e;
			IL_00f5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_0104;
			IL_0104:
			object obj28 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v381 @ rax_v18] (should have been resolved before IL gen)");
			nint num8 = (nint)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r10_v5 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_016b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r10_v5 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			obj28 = 0;
			object obj29 = 0;
			while (true)
			{
				object obj30 = obj29 + obj29;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ r9_v16+v440 @ rax_v58*8]");
				if ((nint)0 == 0)
				{
					break;
				}
				obj29++;
				object obj31 = obj29;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r10_v5 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)obj31 < 0)
				{
					continue;
				}
				goto IL_016b;
			}
			object obj32 = obj29 + obj29;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ r9_v16+8+v497 @ rcx_v50*8]");
			object obj33 = (nint)0 << 4;
			object obj34 = obj33 + 312;
			obj10 = obj34 + num8;
			goto IL_017a;
			IL_026e:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rax_v28+8]");
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v721 @ rax_v28] (should have been resolved before IL gen)");
			flag = num3 > 1;
			num2 = num3;
			continue;
			IL_025f:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_026e;
			IL_01e1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_01f0;
		}
		while (flag);
	}

	public static void Shuffle<T>(IList<T> list, Unity.Mathematics.Random random)
	{
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Expected O, but got Unknown
		//IL_0393: Expected I, but got O
		//IL_00b8: Expected O, but got I
		//IL_0059: Expected O, but got I
		//IL_0062: Expected O, but got I4
		//IL_03f2: Expected I, but got O
		//IL_0285: Expected O, but got I
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_0136: Expected O, but got I
		//IL_00d7: Expected O, but got I
		//IL_00e0: Expected O, but got I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0451: Expected I, but got O
		//IL_02c8: Expected O, but got I
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		//IL_01b5: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_015f: Expected O, but got I4
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_04b0: Expected I, but got O
		//IL_030b: Expected O, but got I
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0233: Expected O, but got I
		//IL_01d4: Expected O, but got I
		//IL_01dd: Expected O, but got I4
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_035c: Expected O, but got I
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Expected O, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if ((nint)obj <= 1)
		{
			return;
		}
		object obj2 = obj;
		Unity.Mathematics.Random random2 = random;
		bool flag;
		object obj45 = default(object);
		do
		{
			object obj3 = obj2 * (object)random2;
			object obj4 = (object)random2 << 13;
			obj2--;
			object obj5 = (object)random2 ^ obj4;
			object obj6 = obj3 >> 32;
			object obj7 = obj5 >> 17;
			object obj8 = obj5 ^ obj7;
			object obj9 = obj8 << 5;
			random2 = (Unity.Mathematics.Random)(obj8 ^ obj9);
			nint num = (nint)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ r10_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_0099;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ r10_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			object obj10 = 0;
			object obj11 = 0;
			while (true)
			{
				object obj12 = obj11 + obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ r9_v17+v253 @ rax_v67*8]");
				if ((nint)0 == 0)
				{
					break;
				}
				obj11++;
				object obj13 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ r10_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)obj13 < 0)
				{
					continue;
				}
				goto IL_0099;
			}
			object obj14 = obj11 + obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ r9_v17+8+v307 @ rdx_v22*8]");
			object obj15 = (nint)0 << 4;
			object obj16 = obj15 + 312;
			object obj17 = obj16 + num;
			goto IL_00a8;
			IL_0117:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_0126;
			IL_0126:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v19+8]");
			object obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v423 @ rax_v19] (should have been resolved before IL gen)");
			nint num2 = (nint)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r10_v7 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_0196;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r10_v7 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			obj18 = 0;
			object obj19 = 0;
			while (true)
			{
				object obj20 = obj19 + obj19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ r9_v13+v484 @ rax_v45*8]");
				if ((nint)0 == 0)
				{
					break;
				}
				obj19++;
				object obj21 = obj19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ r10_v7 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)obj21 < 0)
				{
					continue;
				}
				goto IL_0196;
			}
			object obj22 = obj19 + obj19;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ r9_v13+8+v541 @ rcx_v35*8]");
			object obj23 = (nint)0 + (nint)1;
			object obj24 = obj23 << 4;
			object obj25 = obj24 + 312;
			object obj26 = obj25 + num2;
			goto IL_01a5;
			IL_01a5:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v23+8]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v538 @ rax_v23] (should have been resolved before IL gen)");
			nint num3 = (nint)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_0214;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			obj27 = 0;
			object obj28 = 0;
			while (true)
			{
				object obj29 = obj28 + obj28;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ r9_v11+v599 @ rax_v33*8]");
				if ((nint)0 == 0)
				{
					break;
				}
				obj28++;
				object obj30 = obj28;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ r10_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)obj30 < 0)
				{
					continue;
				}
				goto IL_0214;
			}
			object obj31 = obj28 + obj28;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ r9_v11+8+v656 @ rcx_v28*8]");
			object obj32 = (nint)0 + (nint)1;
			object obj33 = obj32 << 4;
			object obj34 = obj33 + 312;
			object obj35 = obj34 + num3;
			goto IL_0223;
			IL_0099:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_00a8;
			IL_00a8:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v15+8]");
			object obj36 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v309 @ rax_v15] (should have been resolved before IL gen)");
			nint num4 = (nint)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r10_v5 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_0117;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r10_v5 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			obj36 = 0;
			object obj37 = 0;
			while (true)
			{
				object obj38 = obj37 + obj37;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r9_v15+v369 @ rax_v57*8]");
				if ((nint)0 == 0)
				{
					break;
				}
				obj37++;
				object obj39 = obj37;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r10_v5 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]");
				if ((nint)obj39 < 0)
				{
					continue;
				}
				goto IL_0117;
			}
			object obj40 = obj37 + obj37;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r9_v15+8+v426 @ rcx_v42*8]");
			object obj41 = (nint)0 << 4;
			object obj42 = obj41 + 312;
			object obj43 = obj42 + num4;
			goto IL_0126;
			IL_0223:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rax_v27+8]");
			obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v653 @ rax_v27] (should have been resolved before IL gen)");
			flag = (nint)obj2 > 1;
			object obj44 = obj45;
			continue;
			IL_0214:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_0223;
			IL_0196:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			goto IL_01a5;
		}
		while (flag);
	}

	public unsafe static string Shuffle(string str)
	{
		//IL_0285: Expected O, but got I
		//IL_0295: Expected O, but got I
		//IL_016a: Expected O, but got I4
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected I, but got Unknown
		//IL_0212: Expected I, but got O
		//IL_02e6: Expected O, but got I
		//IL_01df: Expected O, but got I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_0224: Expected O, but got I
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected I, but got Unknown
		char[] array = str.ToCharArray();
		int seed = default(int);
		System.Random random = new System.Random(seed);
		seed = System.Random.GenerateSeed();
		int num = array.Length;
		if (array.Length <= 1)
		{
			goto IL_0126;
		}
		while (true)
		{
			int num2 = num - 1;
			int num3 = random.Next(num);
			if (num3 >= array.Length || num2 >= array.Length)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v6 (System.Char[])+1E+v317 @ rdi_v4 (System.Int32)*2]");
			array[num3] = '\0';
			if (num2 >= array.Length)
			{
				break;
			}
			_ = array[num3];
			bool flag = num2 > 1;
			num = num2;
			if (flag)
			{
				continue;
			}
			goto IL_0126;
		}
		goto IL_02a7;
		IL_02a7:
		return (string)(object)new IndexOutOfRangeException();
		IL_0126:
		if (array.Length != 0)
		{
			string text = string.FastAllocateString(array.Length);
			object obj = array.Length ^ array.Length;
			object obj2 = array.Length & obj;
			bool flag2 = (nint)obj2 < 0;
			bool flag3 = array.Length < 0;
			bool flag4 = array.Length == 0;
			byte* ptr = (byte*)(nint)(text + 20);
			byte* ptr2;
			if (!flag4)
			{
				bool flag5 = flag3 == flag2;
				object obj3 = !flag5;
				object obj4 = obj3 | flag4;
				if (obj4 != null)
				{
					goto IL_02a7;
				}
				ptr2 = (byte*)(nint)(array + 32);
			}
			else
			{
				ptr2 = (byte*)unchecked((nint)null);
			}
			int num4 = array.Length + array.Length;
			object obj5 = (object)(ptr - (nuint)ptr2);
			if ((nint)obj5 >= num4)
			{
				obj5 = (object)(ptr2 - (nuint)ptr);
				if ((nint)obj5 >= num4)
				{
					Buffer.Memcpy(ptr, ptr2, num4);
					return text;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			return text;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rax_v19+B8]");
		return (string)0;
	}

	public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 30)
	{
		IEnumerable<List<T>> enumerable = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v55 @ r9_v1 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
		if (enumerable != null)
		{
			return enumerable;
		}
		return (IEnumerable<List<T>>)new NullReferenceException();
	}

	public unsafe static void SetPivot(RectTransform rectTransform, Vector2 pivot)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0139: Expected O, but got I
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		Vector2 pivot2 = rectTransform.pivot;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		object obj3 = 0 - pivot;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6B]");
		object obj5 = default(object);
		object obj4 = 0 - obj5;
		_ = 0;
		bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		object obj6 = obj - 105;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Rect*)obj6);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-61]");
		object obj7 = 0 * obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-5D]");
		object obj8 = 0 * obj4;
		_ = 0;
		bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Vector3 ret);
		object obj9 = obj7 * (object)ret;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-7D]");
		object obj10 = obj8 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-79]");
		object obj11 = (nint)0 * (nint)0;
		_ = 0;
		bool flag3 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		object obj12 = obj - 105;
		Transform.get_rotation_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Quaternion*)obj12);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-65]");
		float num = 0f * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-61]");
		float num2 = 0f * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
		float num3 = 0f * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
		float num4 = 0f * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-61]");
		float num5 = 0f * num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
		float num6 = 0f * num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-65]");
		float num7 = 0f * num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-5D]");
		float num8 = 0f * num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-65]");
		float num9 = 0f * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
		float num10 = 0f * num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-5D]");
		float num11 = 0f * num2;
		float num12 = num5 + num9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-5D]");
		float num13 = 0f * num;
		float num14 = num5 + num10;
		float num15 = num9 + num10;
		float num16 = 1f - num12;
		float num17 = num4 - num11;
		float num18 = num11 + num4;
		float num19 = num16 * (float)obj9;
		float num20 = num17 * (float)obj10;
		float num21 = num18 * (float)obj9;
		float num22 = num19 + num20;
		float num23 = num13 + num6;
		float num24 = num6 - num13;
		float num25 = num23 * (float)obj11;
		float num26 = num24 * (float)obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		float num27 = 0f + num25;
		float num28 = 1f - num14;
		float num29 = 1f - num15;
		float num30 = num7 - num8;
		float num31 = num28 * (float)obj10;
		float num32 = num8 + num7;
		float num33 = num29 * (float)obj11;
		float num34 = num31 + num21;
		float num35 = num30 * (float)obj11;
		float num36 = num32 * (float)obj10;
		float num37 = num34 + num35;
		float num38 = num36 + num26;
		float num39 = num38 + num33;
		rectTransform.pivot = pivot;
		_ = 0;
		bool flag4 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out ret);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-79]");
		float num40 = 0f - num39;
		bool flag5 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		object obj13 = obj - 105;
		Transform.set_localPosition_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref *(Vector3*)obj13);
	}

	public static Vector2 GetSize(RectTransform rTrans)
	{
		bool flag = ((UnityEngine.Object)rTrans).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rTrans).m_CachedPtr, out Rect _);
		float scaleFactor = UIHelper.ScaleFactor;
		bool flag2 = ((UnityEngine.Object)rTrans).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rTrans).m_CachedPtr, out Rect _);
		float scaleFactor2 = UIHelper.ScaleFactor;
		Vector2 result = default(Vector2);
		return result;
	}

	public unsafe static Rect RectTransformToScreenSpace(RectTransform transform, Camera cam, bool cutDecimals = false)
	{
		//IL_001b: Expected O, but got I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_01b0: Expected native int or pointer, but got O
		//IL_01bd: Expected native int or pointer, but got O
		//IL_01d7: Expected F4, but got I
		//IL_01d2: Expected native int or pointer, but got O
		//IL_01ec: Expected F4, but got I
		//IL_01e7: Expected native int or pointer, but got O
		//IL_0276->IL027b: Incompatible stack heights: 3 vs 0
		//IL_012e->IL0250: Incompatible stack heights: 5 vs 3
		Vector3[] array = new Vector3[4];
		Vector3[] array2 = new Vector3[4];
		transform.GetWorldCorners(array);
		object obj = 0;
		Vector3 position = default(Vector3);
		do
		{
			bool flag = (nint)obj >= array.Length;
			bool flag2 = ((UnityEngine.Object)cam).m_CachedPtr == (IntPtr)0;
			Camera.WorldToScreenPoint_Injected(((UnityEngine.Object)cam).m_CachedPtr, ref position, Camera.MonoOrStereoscopicEye.Mono, out Vector3 _);
			bool flag3 = (nint)obj >= array2.Length;
			object obj2 = obj * 2;
			object obj3 = obj + obj2;
			_ = 0;
			if (cutDecimals)
			{
				bool flag4 = (nint)obj >= array2.Length;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rdi+rcx*4+20h]\"");
				object obj4 = obj * 2;
				object obj5 = obj + obj4;
				bool flag5 = (nint)obj >= array2.Length;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rdi+rax*4]\"");
				object obj6 = obj + 3;
				object obj7 = obj6 * 2;
				object obj8 = obj6 + obj7;
			}
			obj++;
		}
		while ((nint)obj < 4);
		bool flag6 = array2.Length <= 0;
		bool flag7 = array2.Length <= 2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (UnityEngine.Vector3[])+38]");
		float num = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (UnityEngine.Vector3[])+20]");
		float width = num - 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (UnityEngine.Vector3[])+3C]");
		float num2 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (UnityEngine.Vector3[])+24]");
		float height = num2 - 0f;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_Width = width;
		((Rect*)(nint)rect)->m_Height = height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (UnityEngine.Vector3[])+20]");
		((Rect*)(nint)rect)->m_XMin = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v3 (UnityEngine.Vector3[])+24]");
		((Rect*)(nint)rect)->m_YMin = 0f;
		return rect;
	}

	public unsafe static Rect GetWorldRect(RectTransform rectTransform)
	{
		//IL_00eb: Expected F4, but got I
		//IL_00e6: Expected native int or pointer, but got O
		//IL_00f3: Expected native int or pointer, but got O
		//IL_0100: Expected native int or pointer, but got O
		//IL_010d: Expected native int or pointer, but got O
		Vector3[] fourCornersArray = new Vector3[4];
		rectTransform.GetWorldCorners(fourCornersArray);
		bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_lossyScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Vector3 ret);
		bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect _);
		bool flag3 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_lossyScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Vector3 _);
		bool flag4 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect _);
		object obj = default(object);
		float width = (float)obj * (float)ret;
		object obj2 = default(object);
		object obj3 = default(object);
		float height = (float)obj2 * (float)obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (UnityEngine.Vector3[])+20]");
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = 0f;
		float yMin = default(float);
		((Rect*)(nint)rect)->m_YMin = yMin;
		((Rect*)(nint)rect)->m_Width = width;
		((Rect*)(nint)rect)->m_Height = height;
		return rect;
	}

	public unsafe static Vector3 GetLocalAnchorPosInParent(RectTransform rectTransform, RectTransform parent)
	{
		//IL_022c: Expected O, but got I4
		//IL_0246: Expected O, but got I4
		//IL_032b: Expected I, but got O
		//IL_0349: Expected F4, but got O
		//IL_0344: Expected native int or pointer, but got O
		//IL_035e: Expected F4, but got I
		//IL_0359: Expected native int or pointer, but got O
		//IL_02c7->IL01e7: Incompatible stack heights: 1 vs 0
		//IL_02f1->IL0195: Incompatible stack heights: 1 vs 0
		//IL_0190->IL02f6: Incompatible stack heights: 1 vs 0
		//IL_0195->IL0195: Incompatible stack heights: 1 vs 0
		if ((object)rectTransform != null)
		{
			Transform parent2 = rectTransform.parent;
			if ((object)parent2 != null)
			{
				RectTransform component = parent2.GetComponent<RectTransform>();
				bool flag = (object)parent == null;
				RectTransform rectTransform2 = component;
				Vector3 vector = default(Vector3);
				while (true)
				{
					bool flag2 = (object)rectTransform2 == null;
					object obj = flag & flag2;
					bool flag3 = obj == null;
					object obj2 = !flag3;
					RectTransform rectTransform3 = rectTransform2;
					if (obj2 == null)
					{
						bool flag4;
						if ((object)rectTransform2 != null)
						{
							if ((object)parent != null)
							{
								object obj3 = (object)parent - (object)rectTransform2;
								flag4 = obj3 == null;
							}
							else
							{
								flag4 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
							}
						}
						else
						{
							if ((object)parent == null)
							{
								break;
							}
							flag4 = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
						}
						rectTransform3 = rectTransform2;
						if (!flag4)
						{
							if ((object)rectTransform2 == null)
							{
								break;
							}
							bool flag5 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
							IntPtr parent_Injected = Transform.GetParent_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
							if ((object)transform == null)
							{
								break;
							}
							RectTransform component2 = transform.GetComponent<RectTransform>();
							bool flag6 = (object)component2 == null;
							rectTransform3 = component2;
							if (!flag6)
							{
								bool flag7 = ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0;
								rectTransform3 = component2;
								rectTransform2 = component2;
								if (flag7)
								{
									continue;
								}
							}
						}
					}
					if ((object)rectTransform3 == null || ((UnityEngine.Object)rectTransform3).m_CachedPtr == (IntPtr)0)
					{
						Debug.LogError("Recttransform provided was not a parent of the initial object");
					}
					nint num = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v24 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rax_v25 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					((Vector3*)(nint)vector)->z = 0f;
					return vector;
				}
			}
		}
		throw new NullReferenceException();
	}

	public static T PickRnd<T>(T[] array)
	{
		//IL_0026: Expected O, but got I4
		//IL_0012: Expected O, but got I
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		bool flag = (nint)obj >= array.Length;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [array @ rcx (T[])+20+v63 @ rax_v9*4]");
		return (T)0;
	}

	public static T PickRnd<T>(IList<T> list)
	{
		//IL_0036: Expected I4, but got O
		//IL_003a: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = UnityEngine.Random.RandomRangeInt(0, (int)obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BAD0");
		T result = default(T);
		return result;
	}

	public static void RemoveWhere<T>(ICollection<T> collection, Func<T, bool> condition)
	{
		//IL_01ee: Expected O, but got I
		//IL_006c: Expected O, but got I
		//IL_0185: Expected I, but got O
		//IL_0081: Expected O, but got I
		//IL_008a: Expected O, but got I4
		//IL_00fb: Expected O, but got I
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		IEnumerable<KeyValuePair<System.Int32Enum, object>> enumerable = (IEnumerable<KeyValuePair<System.Int32Enum, object>>)Enumerable.Where(collection, condition);
		if (enumerable != null)
		{
			List<KeyValuePair<System.Int32Enum, object>> list = new List<KeyValuePair<System.Int32Enum, object>>(enumerable);
			object obj2 = default(object);
			object obj13 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ stack_18_v4+38]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1849C4FA0");
				if (obj2 == null)
				{
					return;
				}
				if (collection == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ stack_18_v4+38]");
				object obj3 = 0;
				nint num = (nint)collection;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
				object obj12;
				if ((nint)0 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]");
					object obj4 = 0;
					object obj5 = 0;
					while (true)
					{
						object obj6 = obj5 + obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ r9_v4+v411 @ rax_v34*8]");
						if (0 == (nint)obj3)
						{
							break;
						}
						obj5++;
						object obj7 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v4 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]");
						if ((nint)obj7 < 0)
						{
							continue;
						}
						goto IL_00c1;
					}
					object obj8 = obj5 + obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ r9_v4+8+v466 @ rcx_v26*8]");
					object obj9 = (nint)0 + (nint)6;
					object obj10 = obj9 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + num;
					goto IL_0215;
				}
				goto IL_00c1;
				IL_0215:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v473 @ r8_v10] (should have been resolved before IL gen)");
				continue;
				IL_00c1:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj12 = obj13;
				goto IL_0215;
			}
			throw new NullReferenceException();
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
	{
		if ((object)gameObject != null)
		{
			if (gameObject.TryGetComponent<T>(out var component))
			{
				return component;
			}
			return gameObject.AddComponent<T>();
		}
		return (T)(object)new NullReferenceException();
	}

	public static void RefreshLayoutGroupsImmediateAndRecursive(RectTransform g)
	{
		//IL_001b: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		LayoutGroup[] componentsInChildren = g.GetComponentsInChildren<LayoutGroup>();
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < componentsInChildren.Length)
		{
			RectTransform component = componentsInChildren[obj2].GetComponent<RectTransform>();
			LayoutRebuilder.ForceRebuildLayoutImmediate(component);
			obj2++;
			obj = obj2;
		}
	}

	public unsafe static Vector2 GetProperSize(RectTransform rectTransform)
	{
		//IL_0168: Invalid comparison between F4 and I4
		//IL_0027: Invalid comparison between F4 and I4
		//IL_0192: Invalid comparison between F4 and I4
		//IL_0095: Invalid comparison between F4 and I4
		bool flag = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect _);
		bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		float ret2;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Rect*)(&ret2));
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186C00C2Fh\"");
		float num = default(float);
		if (num == 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186C00B3Eh\"");
			float num2 = default(float);
			bool flag3 = num2 != 0f;
			float num3 = num2;
			float num4 = num;
			if (!flag3)
			{
				float preferredWidth = LayoutUtility.GetPreferredWidth(rectTransform);
				float preferredHeight = LayoutUtility.GetPreferredHeight(rectTransform);
				num3 = preferredHeight;
				num4 = preferredWidth;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186C00C2Fh\"");
			if (num4 == 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186C00C2Fh\"");
				if (num3 == 0f)
				{
					LayoutGroup component = rectTransform.GetComponent<LayoutGroup>();
					if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
					{
						float preferredWidth2 = component.preferredWidth;
						float preferredHeight2 = component.preferredHeight;
					}
				}
			}
		}
		Vector2 result = default(Vector2);
		return result;
	}

	public static bool AnyDown(Player self)
	{
		//IL_0119: Expected I4, but got O
		ReInput.ControllerHelper controllers = ReInput.controllers;
		if (controllers != null)
		{
			if (!ReInput.CheckInitialized())
			{
				return false;
			}
			global::YdgUOjdefzAWTMpEeriKxkUxlwEt ksJXpDsMixBwMhOpfXJXqgrTCMir = ReInput.KsJXpDsMixBwMhOpfXJXqgrTCMir;
			if (ReInput.KsJXpDsMixBwMhOpfXJXqgrTCMir != null)
			{
				if ((ksJXpDsMixBwMhOpfXJXqgrTCMir.aMwhpuuOMnchaJcvJGPccmackicEc == null || !ksJXpDsMixBwMhOpfXJXqgrTCMir.aMwhpuuOMnchaJcvJGPccmackicEc.GetAnyButtonDown()) && !ReInput.KsJXpDsMixBwMhOpfXJXqgrTCMir.dcfKVWQibRXNUCnwoVdQAOAJcFEb<Joystick>((IList<Joystick>)ksJXpDsMixBwMhOpfXJXqgrTCMir.PXpWeTbtLsfbtNqrXzdbhsmbZcrF) && (ksJXpDsMixBwMhOpfXJXqgrTCMir.VVTlfNafEhOSljrOHPkoKvgTzLNC == null || !ksJXpDsMixBwMhOpfXJXqgrTCMir.VVTlfNafEhOSljrOHPkoKvgTzLNC.GetAnyButtonDown()))
				{
					return ReInput.KsJXpDsMixBwMhOpfXJXqgrTCMir.dcfKVWQibRXNUCnwoVdQAOAJcFEb<CustomController>((IList<CustomController>)ksJXpDsMixBwMhOpfXJXqgrTCMir.VtydaFvyssGxKftSvtMrLAMJAjVbA);
				}
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool ContainsFast(ref Rect rect, float x, float y)
	{
		//IL_001d: Expected O, but got I
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_003f: Invalid comparison between O and F4
		//IL_005d: Invalid comparison between F4 and I4
		//IL_0086: Expected O, but got I4
		//IL_008e: Invalid comparison between O and F4
		//IL_00ac: Invalid comparison between F4 and I4
		//IL_00d5: Expected O, but got I4
		//IL_00f2: Invalid comparison between F4 and I
		//IL_012c: Invalid comparison between F4 and O
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected I4, but got Unknown
		//IL_011a: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ rcx (UnityEngine.Rect&)+C]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ rcx (UnityEngine.Rect&)+4]");
		object obj = num + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ rcx (UnityEngine.Rect&)+8]");
		object obj2 = 0 + rect;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y);
		float num2 = (float)obj - y;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj3 = flag4 & flag3;
		bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x);
		float num3 = (float)obj2 - x;
		bool flag6 = num3 == 0f;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		object obj4 = flag8 & flag7;
		object obj5 = obj3 & obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ rcx (UnityEngine.Rect&)+4]");
		bool flag9 = !(y < 0f);
		object obj6 = obj5;
		if (!flag9)
		{
			obj6 = 0;
		}
		Rect rect2 = rect;
		bool flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x) < System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref rect2);
		bool flag11 = !flag10;
		return (byte)((obj6 & flag11) ? 1 : 0) != 0;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool ContainsFast(Rect rect, float2 position)
	{
		//IL_003a: Invalid comparison between F4 and O
		//IL_0058: Invalid comparison between F4 and I4
		//IL_0081: Expected O, but got I4
		//IL_0089: Invalid comparison between F4 and O
		//IL_00a7: Invalid comparison between F4 and I4
		//IL_00d0: Expected O, but got I4
		//IL_00ea: Invalid comparison between O and F4
		//IL_0124: Invalid comparison between O and F4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected I4, but got Unknown
		//IL_0112: Expected O, but got I4
		float num = rect.m_Height + rect.m_YMin;
		float num2 = rect.m_Width + rect.m_XMin;
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num3 = num - (float)obj;
		bool flag2 = num3 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj2 = flag4 & flag3;
		bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position);
		float num4 = num2 - (float)position;
		bool flag6 = num4 == 0f;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		object obj3 = flag8 & flag7;
		object obj4 = obj2 & obj3;
		bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)rect.m_YMin);
		object obj5 = obj4;
		if (!flag9)
		{
			obj5 = 0;
		}
		bool flag10 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)rect.m_XMin);
		bool flag11 = !flag10;
		return (byte)((obj5 & flag11) ? 1 : 0) != 0;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float2 Restrict(ref Rect rect, float2 position)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_007c: Expected O, but got I
		Rect rect2 = rect;
		if (System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref rect2) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ rcx (UnityEngine.Rect&)+8]");
			object obj = 0 + rect;
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ rcx (UnityEngine.Rect&)+4]");
		object obj2 = default(object);
		float2 result = default(float2);
		if (0 <= (nint)obj2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ rcx (UnityEngine.Rect&)+C]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [rect @ rcx (UnityEngine.Rect&)+4]");
			object obj3 = num + 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				return result;
			}
		}
		return result;
	}

	public unsafe static void SetNavigationUp(Selectable origin, Selectable target = null)
	{
		//IL_0082: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			object obj = default(object);
			Selectable selectable = origin.FindSelectable((Vector3)(&obj));
		}
		object obj2 = default(object);
		origin.navigation = (Navigation)(&obj2);
	}

	public unsafe static void SetNavigationDown(Selectable origin, Selectable target = null)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			Vector3 vector = default(Vector3);
			Selectable selectable = origin.FindSelectable((Vector3)(&vector));
		}
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	public unsafe static void SetNavigationLeft(Selectable origin, Selectable target = null)
	{
		//IL_0083: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			Vector3 vector = default(Vector3);
			Selectable selectable = origin.FindSelectable((Vector3)(&vector));
		}
		object obj = default(object);
		origin.navigation = (Navigation)(&obj);
	}

	public unsafe static void SetNavigationRight(Selectable origin, Selectable target = null)
	{
		//IL_0082: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		if ((object)target == null || ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0)
		{
			object obj = default(object);
			Selectable selectable = origin.FindSelectable((Vector3)(&obj));
		}
		object obj2 = default(object);
		origin.navigation = (Navigation)(&obj2);
	}

	public static void SetNavigationMode(Selectable origin, Navigation.Mode mode)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		_ = origin.m_Navigation;
		object obj = default(object);
		Navigation navigation = (Navigation)(obj - 56);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [origin @ rcx (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1 @ rsp-38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [origin @ rcx (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		origin.navigation = navigation;
	}

	public unsafe static void ClearNavigation(Selectable s)
	{
		//IL_0053: Expected O, but got Ref
		_ = 0;
		_ = 0;
		_ = 0;
		_ = s.m_Navigation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [s @ rcx (UnityEngine.UI.Selectable)+38]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [s @ rcx (UnityEngine.UI.Selectable)+48]");
		_ = 0;
		object obj = default(object);
		s.navigation = (Navigation)(&obj);
	}

	public unsafe static string FirstCharToUpper(string input)
	{
		//IL_0141: Expected O, but got I
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Ref, but got Unknown
		//IL_00da: Expected I8, but got I4
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2D68]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (input != null)
		{
			ref byte reference = ref *(byte*)"";
			if ((object)input != "")
			{
				bool flag = "" == null;
				ref byte reference2 = ref *(byte*)"";
				if (!flag)
				{
					int stringLength = input._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rdx_v6 (System.Byte&)+10]");
					bool flag2 = (nint)stringLength != 0;
					reference2 = ref *(byte*)"";
					if (!flag2)
					{
						ref byte first = ref *(byte*)(input + 20);
						ulong length = (ulong)(input._stringLength + input._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length))
						{
							goto IL_01e4;
						}
					}
				}
				if (input._stringLength > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rcx_v21+E4]");
					if ((nint)0 == 0)
					{
					}
					string text = string.FastAllocateString(1);
					text._firstChar = input._firstChar;
					string text2 = text.ToUpperInvariant();
					int length2 = input._stringLength - 1;
					string text3 = input.Substring(1, length2);
					return text2 + text3;
				}
				System.ThrowHelper.ThrowIndexOutOfRangeException();
				string result = default(string);
				return result;
			}
			goto IL_01e4;
		}
		ArgumentNullException ex = new ArgumentNullException("input");
		ex._002Ector("input");
		throw ex;
		IL_01e4:
		ArgumentException ex2 = new ArgumentException("input cannot be empty", "input");
		throw ex2;
	}

	public unsafe static Vector3 GetScreenPosFromAnchorPos(RectTransform r)
	{
		//IL_018a: Expected native int or pointer, but got O
		//IL_0198: Expected native int or pointer, but got O
		//IL_03ae: Expected I, but got O
		//IL_03cc: Expected F4, but got O
		//IL_03c7: Expected native int or pointer, but got O
		//IL_03e1: Expected F4, but got I
		//IL_03dc: Expected native int or pointer, but got O
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_038b: Expected F4, but got I
		//IL_039b: Expected F4, but got I
		//IL_03f7: Expected native int or pointer, but got O
		//IL_0404: Expected native int or pointer, but got O
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_029e: Expected F4, but got I
		//IL_02ae: Expected F4, but got I
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Ref, but got Unknown
		//IL_0315->IL017a: Incompatible stack heights: 1 vs 0
		//IL_0228->IL017a: Incompatible stack heights: 1 vs 0
		//IL_0129->IL017a: Incompatible stack heights: 2 vs 0
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		((Vector3*)(nint)vector)->z = 0f;
		Camera cameraUI = UICamera._cameraUI;
		bool num3;
		object obj2 = default(object);
		bool num4;
		float x;
		float z;
		if ((object)UICamera._cameraUI != null && ((UnityEngine.Object)cameraUI).m_CachedPtr != (IntPtr)0)
		{
			Camera cameraUI2 = UICamera._cameraUI;
			if ((object)r != null)
			{
				Transform transform = r.transform;
				if ((object)transform != null)
				{
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					num3 = flag;
					object obj = obj2 - 80;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
					if ((object)UICamera._cameraUI != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-50]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-48]");
						_ = 0;
						_ = 0;
						_ = 0;
						bool flag2 = ((UnityEngine.Object)cameraUI2).m_CachedPtr == (IntPtr)0;
						num4 = flag2;
						object obj3 = obj2 - 64;
						object obj4 = obj2 - 48;
						Camera.WorldToScreenPoint_Injected(((UnityEngine.Object)cameraUI2).m_CachedPtr, ref *(Vector3*)obj4, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)obj3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
						x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
						z = 0f;
						goto IL_03ef;
					}
				}
			}
		}
		else
		{
			Camera main = Camera.main;
			if ((object)r != null)
			{
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)r).m_CachedPtr == (IntPtr)0;
				num3 = flag3;
				object obj5 = obj2 - 64;
				Transform.get_position_Injected(((UnityEngine.Object)r).m_CachedPtr, out *(Vector3*)obj5);
				if ((object)main != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
					_ = 0;
					_ = 0;
					_ = 0;
					bool flag4 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
					num4 = flag4;
					object obj6 = obj2 - 80;
					object obj7 = obj2 - 48;
					Camera.WorldToScreenPoint_Injected(((UnityEngine.Object)main).m_CachedPtr, ref *(Vector3*)obj7, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)obj6);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-50]");
					x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-48]");
					z = 0f;
					goto IL_03ef;
				}
			}
		}
		goto IL_017a;
		IL_017a:
		throw new NullReferenceException();
		IL_03ef:
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = z;
		Canvas canvas = UIHelper.Canvas;
		if ((object)canvas != null)
		{
			RectTransform component = canvas.GetComponent<RectTransform>();
			Camera main2 = Camera.main;
			Vector2 screenPoint = default(Vector2);
			bool flag5 = RectTransformUtility.ScreenPointToLocalPointInRectangle(component, screenPoint, main2, out *(Vector2*)(obj2 + 32));
			return vector;
		}
		goto IL_017a;
	}

	public static void SetCurveLinear(AnimationCurve curve)
	{
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_02fd: Expected I4, but got O
		//IL_00a7: Expected O, but got I4
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0356: Expected I4, but got O
		//IL_035a: Expected O, but got I4
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_011b: Expected O, but got I
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0172: Expected O, but got I
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01e9: Expected O, but got I
		//IL_02da: Expected O, but got I
		//IL_0375->IL0393: Incompatible stack heights: 5 vs 1
		//IL_01ee->IL0323: Incompatible stack heights: 8 vs 4
		//IL_02e1->IL0375: Incompatible stack heights: 8 vs 4
		bool flag = curve == null;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			Keyframe[] keys = curve.GetKeys();
			bool flag2 = keys == null;
			if ((nint)obj < keys.Length)
			{
				bool flag3 = curve.m_Ptr == (IntPtr)0;
				AnimationCurve.GetKey_Injected(curve.m_Ptr, (int)obj2, out Keyframe ret);
				Keyframe[] keys2 = curve.GetKeys();
				bool flag4 = keys2 == null;
				object obj3 = keys2.Length - 1;
				if (obj2 != null)
				{
					Keyframe[] keys3 = curve.GetKeys();
					bool flag5 = keys3 == null;
					object obj4 = obj2 - 1;
					object obj5 = obj4 * 28;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rcx_v34+20+v276 @ rax_v28 (UnityEngine.Keyframe[])]");
					object obj6 = 0;
					Keyframe[] keys4 = curve.GetKeys();
					bool flag6 = keys4 == null;
					object obj7 = obj2 - 1;
					object obj8 = obj7 * 28;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ rcx_v38+24+v277 @ rax_v29 (UnityEngine.Keyframe[])]");
					object obj9 = 0;
					Keyframe[] keys5 = curve.GetKeys();
					bool flag7 = keys5 == null;
					object obj10 = obj2 * 28;
					Keyframe[] keys6 = curve.GetKeys();
					bool flag8 = keys6 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ rdx_v24+20+v278 @ rax_v30 (UnityEngine.Keyframe[])]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ rcx_v34+20+v276 @ rax_v28 (UnityEngine.Keyframe[])]");
					object obj11 = num - 0;
				}
				if (obj2 != obj3)
				{
					Keyframe[] keys7 = curve.GetKeys();
					bool flag9 = keys7 == null;
					object obj12 = obj2 * 28;
					Keyframe[] keys8 = curve.GetKeys();
					bool flag10 = keys8 == null;
					Keyframe[] keys9 = curve.GetKeys();
					bool flag11 = keys9 == null;
					object obj13 = obj2 + 1;
					object obj14 = obj13 * 28;
					Keyframe[] keys10 = curve.GetKeys();
					bool flag12 = keys10 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ rcx_v26+20+v282 @ rax_v26 (UnityEngine.Keyframe[])]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdx_v16+20+v280 @ rax_v24 (UnityEngine.Keyframe[])]");
					object obj11 = num2 - 0;
				}
				bool flag13 = curve.m_Ptr == (IntPtr)0;
				object obj15 = AnimationCurve.MoveKey_Injected(curve.m_Ptr, (int)obj2, ref ret);
				obj2++;
				obj = obj2;
				continue;
			}
			break;
		}
	}
}
