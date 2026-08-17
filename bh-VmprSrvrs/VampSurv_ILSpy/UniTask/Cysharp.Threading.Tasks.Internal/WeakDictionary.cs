using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal class WeakDictionary<TKey, TValue> where TKey : class
{
	private class Entry
	{
		public WeakReference<TKey> Key;

		public TValue Value;

		public int Hash;

		public Entry Prev;

		public Entry Next;

		public unsafe override string ToString()
		{
			//IL_013c: Expected O, but got Ref
			//IL_00ea: Expected O, but got I
			//IL_011f: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189988A2F]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (Key != null)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184225380");
				object obj = default(object);
				if (obj == null)
				{
					return "(Dead)";
				}
				object obj2 = default(object);
				string text;
				if (obj2 != null)
				{
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v185 @ rdx_v7+168] (should have been resolved before IL gen)");
					string text2 = default(string);
					text = text2;
				}
				else
				{
					text = null;
				}
				Entry entry = this;
				Entry entry2 = this;
				int num2 = 1;
				object obj4 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
					if ((nint)0 != 0)
					{
						num2++;
						if (entry2 == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbx_v3 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
						entry2 = (Entry)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbx_v3 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rbx_v3 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
						entry = (Entry)0;
						continue;
					}
					string text3 = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&obj4), null);
					return text + "(" + text3 + ")";
				}
			}
			return (string)(object)new NullReferenceException();
		}

		private int Count()
		{
			//IL_00dd: Expected I4, but got O
			//IL_0090: Expected O, but got I
			//IL_00c5: Expected O, but got I
			bool flag = this == null;
			Entry entry = this;
			int num = 1;
			if (!flag)
			{
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdx_v3 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
					if ((nint)0 != 0)
					{
						num++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v2 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v2 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
						Entry entry2 = (Entry)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v2 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
						if ((nint)0 == 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rcx_v2 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
						entry = (Entry)0;
						continue;
					}
					return num;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private Entry[] buckets;

	private int size;

	private SpinLock gate;

	private readonly float loadFactor;

	private readonly IEqualityComparer<TKey> keyEqualityComparer;

	public WeakDictionary(int capacity = 4, float loadFactor = 0.75f, IEqualityComparer<TKey> keyComparer = null)
	{
		//IL_0018: Expected O, but got I4
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_0154: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_00d6: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		object obj = capacity - 1;
		object obj2 = obj >> 1;
		object obj3 = obj | obj2;
		object obj4 = obj3 >> 2;
		object obj5 = obj3 | obj4;
		object obj6 = obj5 >> 4;
		object obj7 = obj5 | obj6;
		object obj8 = obj7 >> 8;
		object obj9 = obj7 | obj8;
		object obj10 = obj9 >> 16;
		object obj11 = obj10 | obj9;
		object obj12 = obj11 + 1;
		if ((nint)obj12 < 8)
		{
			obj12 = 8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ stack_28+20]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v10+C0]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
		Entry[] array = default(Entry[]);
		buckets = array;
		_ = 2147483648L;
		bool flag = keyComparer != null;
		EqualityComparer<object> equalityComparer = (EqualityComparer<object>)keyComparer;
		if (!flag)
		{
			EqualityComparer<object> equalityComparer2 = EqualityComparer<object>.Default;
			equalityComparer = equalityComparer2;
		}
	}

	public unsafe bool TryAdd(TKey key, TValue value)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		object obj = default(object);
		SpinLock spinLock = (SpinLock)(obj + 28);
		bool lockTaken = default(bool);
		((SpinLock*)spinLock)->Enter(ref lockTaken);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184222510");
		if (lockTaken)
		{
			SpinLock spinLock2 = (SpinLock)(obj + 28);
			((SpinLock*)spinLock2)->Exit(useMemoryBarrier: false);
		}
		bool result = default(bool);
		return result;
	}

	public unsafe bool TryGetValue(TKey key, out TValue value)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0036: Expected O, but got I
		//IL_0046: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00a1: Expected O, but got I
		//IL_00f4: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_013d: Expected O, but got I
		//IL_060d: Expected O, but got Ref
		//IL_0169: Expected O, but got I
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_0786: Expected O, but got I4
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Expected O, but got Unknown
		//IL_063c: Expected O, but got Ref
		//IL_0740: Expected O, but got I8
		//IL_064a: Unknown result type (might be due to invalid IL or missing references)
		//IL_064f: Expected O, but got Unknown
		//IL_0214: Expected O, but got I
		//IL_0224: Expected O, but got I
		//IL_04d1: Expected O, but got I
		//IL_04e1: Expected O, but got I
		//IL_050f: Expected I, but got O
		//IL_055b: Expected I, but got O
		//IL_0593: Expected O, but got Ref
		//IL_040f: Expected O, but got I
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Expected I, but got Unknown
		//IL_033a: Expected O, but got I
		//IL_05c2: Expected O, but got Ref
		//IL_0464: Expected O, but got I
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected I, but got Unknown
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Expected O, but got Unknown
		object obj = default(object);
		SpinLock spinLock = (SpinLock)(obj + 28);
		bool lockTaken = default(bool);
		((SpinLock*)spinLock)->Enter(ref lockTaken);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.WeakDictionary`2>)+60]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+28]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+28]");
		bool flag = (nint)0 == 0;
		nint num2 = 0;
		object obj10;
		TKey val2;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r13_v1+20]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v10+C0]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BDF0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+10]");
			bool flag2 = (nint)0 == 0;
			num2 = 1;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v2+18]");
				object obj7 = -1;
				object obj9 = default(object);
				object obj8 = obj7 & obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v2+20+v175 @ r12_v6*8]");
				obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v2+20+v175 @ r12_v6*8]");
				object obj11 = 0;
				TKey val = key;
				val2 = key;
				if (!flag3)
				{
					object obj12 = (nint)(&obj11) >> 12;
					object obj13 = obj12 & 0x1FFFFF;
					object obj14 = obj13 >> 6;
					object obj15 = obj14 * 8;
					object obj16 = 6603577472L + obj15;
					object obj17 = obj13 & 0x3F;
					bool flag4;
					do
					{
						object obj18 = 1 << (int)obj17;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v33+462E0]");
						object obj19 = 0 | obj18;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v33+462E0]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v33+462E0]");
						if (num3 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v33+462E0]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rdx_v33+462E0]");
						flag4 = num4 != 0;
						val = (TKey)6603577472L;
						val2 = key;
					}
					while (flag4);
					goto IL_01c2;
				}
				goto IL_06f5;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
		IL_01c2:
		obj10 = obj10;
		goto IL_06f5;
		IL_06f5:
		ref TValue reference;
		if (obj10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+10]");
			num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r13_v1+20]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ rax_v47+C0]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184225380");
				object obj22 = default(object);
				if (obj22 == null)
				{
					if (obj10 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+40]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+48]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+10]");
							num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+18]");
							_ = -1;
							goto IL_0525;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+40]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+10]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+48]");
							obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+10]");
							if ((nint)0 == 0)
							{
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+48]");
							if ((nint)0 != 0)
							{
								IntPtr intPtr = num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj23 = default(object);
								if (obj23 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+10]");
							num2 = 0;
							val2 = key;
						}
					}
					if (obj10 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+40]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+40]");
						object obj24 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+48]");
						_ = 0;
						num2 = (nint)(obj24 + 72);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+48]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+48]");
						object obj25 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+40]");
						_ = 0;
						num2 = (nint)(obj25 + 64);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+18]");
					_ = -1;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ stack_8_v2+28]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r13_v1+20]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v53+C0]");
					object obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C0A0");
					object obj28 = default(object);
					bool flag5 = obj28 != null;
					TKey val = val2;
					num2 = unchecked((nint)null);
					object obj29 = default(object);
					obj4 = obj29;
					if (flag5)
					{
						bool flag6 = obj10 == null;
						num2 = unchecked((nint)null);
						if (!flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+18]");
							reference = ref *(TValue*)null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ rax_v38+28]");
							_ = 0;
							object obj30 = (object)(&lockTaken);
							if (obj30 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
								object obj31 = (object)(&lockTaken);
								SpinLock spinLock2 = (SpinLock)(obj31 + 28);
								((SpinLock*)spinLock2)->Exit(useMemoryBarrier: false);
							}
							return true;
						}
						throw new NullReferenceException();
					}
				}
				goto IL_0525;
			}
			throw new NullReferenceException();
		}
		reference = ref *(TValue*)null;
		_ = 0;
		object obj32 = (object)(&lockTaken);
		if (obj32 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			object obj33 = (object)(&lockTaken);
			SpinLock spinLock3 = (SpinLock)(obj33 + 28);
			((SpinLock*)spinLock3)->Exit(useMemoryBarrier: false);
		}
		return false;
		IL_0525:
		if (obj10 != null)
		{
			goto IL_01c2;
		}
		throw new NullReferenceException();
	}

	public unsafe bool TryRemove(TKey key)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0036: Expected O, but got I
		//IL_0046: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00a1: Expected O, but got I
		//IL_00f4: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_0146: Expected O, but got I
		//IL_070f: Expected O, but got Ref
		//IL_016a: Expected O, but got I
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_08a0: Expected O, but got I4
		//IL_08b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Expected O, but got Unknown
		//IL_073e: Expected O, but got Ref
		//IL_087f: Expected O, but got I8
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0751: Expected O, but got Unknown
		//IL_0205: Expected O, but got I
		//IL_0215: Expected O, but got I
		//IL_0441: Expected O, but got I
		//IL_0451: Expected O, but got I
		//IL_04a9: Expected I, but got O
		//IL_039b: Expected O, but got I
		//IL_03e2: Expected O, but got I
		//IL_02f9: Expected O, but got I
		//IL_06a4: Expected O, but got Ref
		//IL_0630: Expected O, but got I
		//IL_056c: Expected I, but got O
		//IL_0677: Expected O, but got I
		//IL_06d3: Expected O, but got Ref
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Expected O, but got Unknown
		object obj = default(object);
		SpinLock spinLock = (SpinLock)(obj + 28);
		bool lockTaken = default(bool);
		((SpinLock*)spinLock)->Enter(ref lockTaken);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rcx_v4 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.WeakDictionary`2>)+60]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+28]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+28]");
		bool flag = (nint)0 == 0;
		nint num2 = 0;
		object obj10;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r13_v1+20]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v10+C0]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BDF0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+10]");
			bool flag2 = (nint)0 == 0;
			num2 = 1;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v2+18]");
				object obj7 = -1;
				object obj9 = default(object);
				object obj8 = obj7 & obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v2+20+v175 @ r15_v5*8]");
				obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag3 = (nint)0 == 0;
				bool flag4 = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rbx_v2+20+v175 @ r15_v5*8]");
				object obj11 = 0;
				TKey val = key;
				if (!flag3)
				{
					object obj12 = (nint)(&obj11) >> 12;
					object obj13 = obj12 & 0x1FFFFF;
					object obj14 = obj13 >> 6;
					object obj15 = obj14 * 8;
					object obj16 = 6603577472L + obj15;
					object obj17 = obj13 & 0x3F;
					bool flag5;
					do
					{
						object obj18 = 1 << (int)obj17;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v45+462E0]");
						object obj19 = 0 | obj18;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v45+462E0]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v45+462E0]");
						if (num3 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v45+462E0]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v45+462E0]");
						flag5 = num4 != 0;
						flag4 = false;
						val = (TKey)6603577472L;
					}
					while (flag5);
					goto IL_01c3;
				}
				goto IL_082b;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
		IL_01c3:
		obj10 = obj10;
		goto IL_082b;
		IL_082b:
		if (obj10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r13_v1+20]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rax_v56+C0]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184225380");
				object obj22 = default(object);
				if (obj22 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+18]");
							_ = -1;
							goto IL_01c3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+10]");
							bool flag4 = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
							obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
							if ((nint)0 != 0)
							{
								bool value = ((bool*)(flag4 ? 1 : 0))->m_value;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj23 = default(object);
								if (obj23 == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
						object obj24 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
						object obj25 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+18]");
					_ = -1;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+28]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r13_v1+20]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ rax_v62+C0]");
					object obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C0A0");
					object obj28 = default(object);
					bool flag6 = obj28 != null;
					TKey val = key;
					object obj29 = default(object);
					obj4 = obj29;
					if (flag6)
					{
						bool flag7 = obj10 == null;
						num2 = unchecked((nint)null);
						if (!flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									goto IL_0689;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+10]");
									nint num5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+10]");
									bool flag8 = (nint)0 == 0;
									num2 = unchecked((nint)null);
									if (flag8)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
									if ((nint)0 != 0)
									{
										IntPtr intPtr = num5;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj30 = default(object);
										if (obj30 == null)
										{
											ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
											throw ex2;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
							}
							if (obj10 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
									object obj31 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
									_ = 0;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+48]");
									object obj32 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v47+40]");
									_ = 0;
								}
								goto IL_0689;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
				}
				goto IL_01c3;
			}
			throw new NullReferenceException();
		}
		object obj33 = (object)(&lockTaken);
		if (obj33 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			object obj34 = (object)(&lockTaken);
			SpinLock spinLock2 = (SpinLock)(obj34 + 28);
			((SpinLock*)spinLock2)->Exit(useMemoryBarrier: false);
		}
		return false;
		IL_0689:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ stack_8_v2+18]");
		_ = -1;
		object obj35 = (object)(&lockTaken);
		if (obj35 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			object obj36 = (object)(&lockTaken);
			SpinLock spinLock3 = (SpinLock)(obj36 + 28);
			((SpinLock*)spinLock3)->Exit(useMemoryBarrier: false);
		}
		return true;
	}

	private bool TryAddInternal(TKey key, TValue value)
	{
		//IL_0010: Expected O, but got I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00fb: Expected O, but got I4
		//IL_013f: Expected O, but got I4
		//IL_0267: Expected I4, but got O
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		object obj = size + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>)+20]");
		TValue val = (TValue)(obj / 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r10d,xmm0\"");
		object obj3 = default(object);
		object obj2 = obj3 - 1;
		object obj4 = obj2 >> 1;
		object obj5 = obj2 | obj4;
		object obj6 = obj5 >> 2;
		object obj7 = obj5 | obj6;
		object obj8 = obj7 >> 4;
		object obj9 = obj7 | obj8;
		object obj10 = obj9 >> 8;
		object obj11 = obj9 | obj10;
		object obj12 = obj11 >> 16;
		object obj13 = obj12 | obj11;
		Entry[] array = (Entry[])(obj13 + 1);
		if ((nint)array < 8)
		{
			array = (Entry[])8;
		}
		Entry[] array2 = buckets;
		Entry[] array4 = default(Entry[]);
		while (array2.Length < (nint)array)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
			object obj14 = 0;
			while (true)
			{
				Entry[] array3 = buckets;
				if ((nint)obj14 >= array3.Length)
				{
					break;
				}
				if ((nint)obj14 < array3.Length)
				{
					bool flag = array3[obj14] == null;
					Entry entry = array3[obj14];
					if (!flag)
					{
						bool flag2;
						do
						{
							val = entry.Value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184222770");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rbx_v10 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
							flag2 = (nint)0 != 0;
							TValue value2 = entry.Value;
							value2 = entry.Value;
						}
						while (flag2);
					}
					obj14++;
					continue;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				return (byte)(int)ex != 0;
			}
			buckets = array4;
			array2 = buckets;
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BDF0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184222770");
		bool flag3 = default(bool);
		if (flag3)
		{
			int num3 = size + 1;
			size = num3;
		}
		return flag3;
	}

	private bool AddToBuckets(Entry[] targetBuckets, TKey newKey, TValue value, int keyHash)
	{
		//IL_002a: Expected O, but got I4
		//IL_0360: Expected I4, but got O
		//IL_0291: Expected O, but got I
		//IL_02a1: Expected O, but got I
		//IL_02bb: Expected O, but got I
		//IL_02cb: Expected O, but got I
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_00ab: Expected O, but got I
		//IL_00bb: Expected O, but got I
		//IL_014a: Expected O, but got I
		//IL_015a: Expected O, but got I
		//IL_0313: Expected I, but got O
		//IL_026e: Expected O, but got I
		//IL_01a6: Expected O, but got I
		//IL_01b6: Expected O, but got I
		//IL_01d0: Expected O, but got I
		//IL_01e0: Expected O, but got I
		//IL_0247: Expected O, but got I
		_ = 0;
		object obj = targetBuckets.Length - 1;
		object obj3 = default(object);
		object obj2 = obj & obj3;
		TValue val2 = default(TValue);
		TValue val = val2;
		object value2 = default(object);
		object obj10 = default(object);
		object obj15 = default(object);
		object obj18 = default(object);
		TValue val3 = default(TValue);
		while (true)
		{
			IL_0360:
			if ((nint)obj2 < targetBuckets.Length)
			{
				if (targetBuckets[obj2] == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ stack_30+20]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rax_v12+C0]");
					object obj5 = 0;
					object obj6 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ stack_30+20]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rcx_v10+C0]");
					object obj8 = 0;
					object obj9 = null;
					_ = 0;
					GCHandle gCHandle = GCHandle.Alloc(value2, GCHandleType.Weak);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rsi_v10 (TValue)+10]");
					_ = 0;
					nint num = (nint)targetBuckets;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (obj10 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					return true;
				}
				Entry entry = targetBuckets[obj2];
				object obj11 = obj2 * 8;
				object obj12 = (object)targetBuckets + obj11;
				while (true)
				{
					if (entry != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ stack_30+20]");
						object obj13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v47+C0]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184225380");
						if (obj15 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807BC3F0");
							if ((nint)obj2 >= targetBuckets.Length)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r12_v7+20]");
							if ((nint)0 == 0)
							{
								goto IL_0360;
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ stack_30+20]");
							object obj16 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rax_v65+C0]");
							object obj17 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C0A0");
							if (obj18 != null)
							{
								goto IL_0273;
							}
							val = val3;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v10 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ stack_30+20]");
							object obj19 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rax_v50+C0]");
							object obj20 = 0;
							object obj21 = null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ stack_30+20]");
							object obj22 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rcx_v33+C0]");
							object obj23 = 0;
							object obj24 = null;
							_ = 0;
							GCHandle gCHandle2 = GCHandle.Alloc(value2, GCHandleType.Weak);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v649 @ stack_20 (TValue)+10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v10 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
							object obj25 = 0;
							val = val3;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v10 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
							entry = (Entry)0;
						}
						continue;
					}
					goto IL_0273;
					IL_0273:
					return false;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private unsafe bool TryGetEntry(TKey key, out int hashIndex, out Entry entry)
	{
		//IL_001f: Expected O, but got I
		//IL_002f: Expected O, but got I
		//IL_0053: Expected O, but got I4
		//IL_01de: Expected I4, but got O
		//IL_00d5: Expected O, but got I
		//IL_00e5: Expected O, but got I
		//IL_012e: Expected O, but got I
		//IL_013e: Expected O, but got I
		Entry[] array = buckets;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ stack_28+20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v5+C0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BDF0");
		object obj3 = array.Length - 1;
		object obj5 = default(object);
		object obj4 = obj3 & obj5;
		ref int reference = ref *(int*)obj4;
		if ((nint)obj4 < array.Length)
		{
			ref Entry reference2 = ref *(Entry*)array[obj4];
			bool flag = entry == null;
			TKey val = key;
			if (!flag)
			{
				object obj8 = default(object);
				object obj11 = default(object);
				do
				{
					Entry entry2 = entry;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ stack_28+20]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rax_v14+C0]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184225380");
					if (obj8 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807BC3F0");
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ stack_28+20]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rax_v20+C0]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C0A0");
						bool flag2 = obj11 != null;
						val = key;
						if (flag2)
						{
							return true;
						}
					}
					Entry entry3 = entry;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v17 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
					reference2 = ref *(Entry*)null;
				}
				while (entry != null);
			}
			return false;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private void Remove(int hashIndex, Entry entry)
	{
		//IL_012e: Expected O, but got I
		//IL_0175: Expected O, but got I
		//IL_00c3: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+40]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				goto IL_0187;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+40]");
			if ((nint)0 == 0)
			{
				Entry[] array = buckets;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
				if ((nint)0 != 0)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj = default(object);
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+40]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+40]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+48]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [entry @ r8 (Cysharp.Threading.Tasks.Internal.WeakDictionary`2<TKey, TValue>+Entry<TKey, TValue>)+40]");
			_ = 0;
		}
		goto IL_0187;
		IL_0187:
		int num2 = size - 1;
		size = num2;
	}

	public List<KeyValuePair<TKey, TValue>> ToList()
	{
		nint num = 0;
		List<KeyValuePair<TKey, TValue>> result = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1837316E0");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184222F50");
		return result;
	}

	public unsafe int ToList(ref List<KeyValuePair<TKey, TValue>> list, bool clear = true)
	{
		//IL_00ad: Expected O, but got I4
		//IL_00c7: Expected O, but got Ref
		//IL_039b: Expected O, but got I
		//IL_02c4: Expected O, but got Ref
		//IL_0090: Expected O, but got I
		//IL_0096: Expected I, but got O
		//IL_02f3: Expected O, but got Ref
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_01bf: Expected O, but got Ref
		//IL_0292: Expected O, but got I4
		//IL_02a3: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_023b: Expected O, but got I4
		if (clear)
		{
			List<KeyValuePair<TKey, TValue>> list2 = list;
			if (list == null)
			{
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v4 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v4 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v4 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v4 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+18]");
				Array.Clear((Array)num, 0, 0);
				nint num2 = unchecked((nint)null);
			}
		}
		int num3 = 0;
		object obj = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = default(int);
		object obj2 = (object)(&num6);
		object obj4 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ stack_8_v6 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ stack_8_v6 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+10]");
			if ((nint)0 != 0)
			{
				int num7 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v16+18]");
				if ((nint)num7 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v16+20+v132 @ rsi_v6 (System.Int32)*8]");
					int num8 = 0;
					while (num8 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v12 (System.Int32)+10]");
						if ((nint)0 != 0)
						{
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184225380");
							if (obj4 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1807BC3F0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v12 (System.Int32)+48]");
								num8 = 0;
								continue;
							}
							nint num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ r9_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.WeakDictionary`2>)+F0]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1836519F0");
							List<KeyValuePair<TKey, TValue>> list3 = list;
							bool flag = list == null;
							List<KeyValuePair<TKey, TValue>> list2 = (List<KeyValuePair<TKey, TValue>>)(&obj);
							if (!flag)
							{
								int num11 = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rax_v31 (System.Collections.Generic.List`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+18]");
								if ((nint)num11 >= (nint)0)
								{
									nint num12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805C1390");
									num3++;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v12 (System.Int32)+48]");
									num8 = 0;
									object obj5 = 0;
									object obj6 = obj;
									obj2 = 0;
								}
								else
								{
									int num13 = num3 + 1;
									nint num14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ r9_v10 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.WeakDictionary`2>)+108]");
									num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18373FFA0");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v12 (System.Int32)+48]");
									num8 = 0;
									num3 = num13;
									object obj5 = 0;
									object obj6 = obj;
									obj2 = 0;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					num5++;
					continue;
				}
				object obj7 = (object)(&num6);
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj8 = (object)(&num6);
					SpinLock spinLock = (SpinLock)(obj8 + 28);
					((SpinLock*)spinLock)->Exit(useMemoryBarrier: false);
				}
				break;
			}
			throw new NullReferenceException();
		}
		return num3;
	}

	private static int CalculateCapacity(int collectionSize, float loadFactor)
	{
		//IL_0018: Expected O, but got I4
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		object obj = collectionSize - 1;
		object obj2 = obj >> 1;
		object obj3 = obj | obj2;
		object obj4 = obj3 >> 2;
		object obj5 = obj3 | obj4;
		object obj6 = obj5 >> 4;
		object obj7 = obj5 | obj6;
		object obj8 = obj7 >> 8;
		object obj9 = obj7 | obj8;
		object obj10 = obj9 >> 16;
		object obj11 = obj10 | obj9;
		int num = obj11 + 1;
		if (num < 8)
		{
			num = 8;
		}
		return num;
	}
}
