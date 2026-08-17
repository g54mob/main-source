using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Coherence;

[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
	private List<TKey> keys;

	private List<TValue> values;

	public unsafe void OnBeforeSerialize()
	{
		//IL_0010: Expected O, but got I
		//IL_008d: Expected O, but got I
		//IL_0078: Expected O, but got I
		//IL_00f5: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_012e: Expected O, but got Ref
		//IL_020b: Expected O, but got I
		//IL_01c5: Expected O, but got I
		//IL_02a9: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rcx_v1+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rcx_v1+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rcx_v1+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rcx_v1+18]");
			Array.Clear((Array)num, 0, 0);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+58]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v4+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v4+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v4+10]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v4+18]");
			Array.Clear((Array)num2, 0, 0);
		}
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
				List<object> list = (List<object>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
				bool flag = (nint)0 == 0;
				Dictionary<object, object>.Enumerator enumerator2 = (Dictionary<object, object>.Enumerator)(&enumerator);
				if (!flag)
				{
					int version = list._version + 1;
					list._version = version;
					object[] items = list._items;
					if (list._items != null)
					{
						if (list._size >= items.Length)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
							((List<object>)0).AddWithResize((object)null);
						}
						else
						{
							int size = list._size + 1;
							list._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+58]");
						List<object> list2 = (List<object>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+58]");
						if ((nint)0 == 0)
						{
							break;
						}
						int version2 = list2._version + 1;
						list2._version = version2;
						Dictionary<object, object>.Enumerator items2 = (Dictionary<object, object>.Enumerator)list2._items;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
						if (list2._size >= items2._version)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+58]");
							((List<object>)0).AddWithResize((object)null);
						}
						else
						{
							int size2 = list2._size + 1;
							list2._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			return;
		}
		throw new NullReferenceException();
	}

	public void OnAfterDeserialize()
	{
		//IL_004a: Expected O, but got I
		//IL_007f: Expected O, but got I
		//IL_00d8: Expected I, but got O
		//IL_00dd: Expected I, but got O
		//IL_00ed: Expected O, but got I
		//IL_0146: Expected O, but got I
		//IL_01a2: Expected O, but got I
		//IL_01fe: Expected O, but got I
		//IL_026d: Expected O, but got I
		//IL_026d: Expected O, but got I
		//IL_0281: Expected O, but got I
		//IL_02de: Expected O, but got I
		if (this != null)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ rdx_v8 (Il2CppRgctx<Coherence.SerializableDictionary`2>)+98]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1847763D0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+58]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+58]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v15+18]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v18+18]");
					if (num3 != 0)
					{
						goto IL_0320;
					}
					nint num4 = unchecked((nint)null);
					num2 = unchecked((nint)null);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
					object obj3 = 0;
					while (true)
					{
						nint intPtr = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v15+18]");
						if (intPtr >= 0)
						{
							return;
						}
						if (obj3 == null)
						{
							break;
						}
						nint intPtr2 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v21+18]");
						if (intPtr2 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v21+10]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v21+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							nint intPtr3 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r11_v6+18]");
							if (intPtr3 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+58]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+58]");
								if ((nint)0 == 0)
								{
									break;
								}
								nint intPtr4 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v22+18]");
								if (intPtr4 >= 0)
								{
									goto IL_032f;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v22+10]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v22+10]");
								if ((nint)0 == 0)
								{
									break;
								}
								nint intPtr5 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ r10_v6+18]");
								if (intPtr5 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r11_v6+20+v44 @ rbx_v8 (Il2CppMethodInfo)*8]");
									nint num5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ r10_v6+20+v44 @ rbx_v8 (Il2CppMethodInfo)*8]");
									bool flag = TryInsert((object)num5, (object)0, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
									obj3 = 0;
									num4++;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
									bool flag2 = (nint)0 == 0;
									System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
									num2 = num4;
									if (flag2)
									{
										break;
									}
									insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.SerializableDictionary`2<TKey, TValue>)+50]");
									obj = 0;
									num2 = num4;
									continue;
								}
							}
							throw new IndexOutOfRangeException();
						}
						goto IL_032f;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_032f:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0320;
		IL_0320:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6860");
		string message = default(string);
		Exception ex = new Exception(message);
		throw ex;
	}

	public SerializableDictionary()
	{
		nint num = 0;
		object obj = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183731620");
		nint num3 = 0;
		object obj2 = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183731620");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184880480");
	}
}
