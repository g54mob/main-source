using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Tools;

public abstract class UnitySerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
	private List<TKey> keyData;

	private List<TValue> valueData;

	void ISerializationCallbackReceiver.OnAfterDeserialize()
	{
		//IL_0020: Expected O, but got I
		//IL_002e: Expected O, but got I4
		//IL_0037: Expected O, but got I4
		//IL_0047: Expected O, but got I
		//IL_005c: Expected O, but got I
		//IL_00bf: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0137: Expected O, but got I
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_0162: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1847763D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+50]");
		object obj = 0;
		object obj2 = 0;
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+50]");
		object obj4 = 0;
		while (true)
		{
			object obj5 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v6+18]");
			if ((nint)obj5 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+58]");
				object obj6 = 0;
				object obj7 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v8+18]");
				if ((nint)obj7 < 0)
				{
					object obj8 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v10+18]");
					if ((nint)obj8 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v10+10]");
					object obj9 = 0;
					object obj10 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v8+18]");
					if ((nint)obj10 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v8+10]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ r10_v5+20+v53 @ rbx_v5*4]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rbx_v5+20+v34 @ r11_v5]");
					bool flag = TryInsert((System.Int32Enum)num2, false, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+50]");
					obj4 = 0;
					obj3++;
					obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+50]");
					obj = 0;
					continue;
				}
				return;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	unsafe void ISerializationCallbackReceiver.OnBeforeSerialize()
	{
		//IL_0010: Expected O, but got I
		//IL_003e: Expected O, but got I
		//IL_035b: Expected O, but got I
		//IL_036b: Expected O, but got I
		//IL_0071: Expected O, but got I
		//IL_0090: Expected O, but got Ref
		//IL_00ae: Expected O, but got I
		//IL_00be: Expected O, but got I
		//IL_00e2: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_0186: Expected O, but got I
		//IL_015b: Expected O, but got I
		//IL_016b: Expected O, but got I
		//IL_0326: Expected O, but got I
		//IL_01ab: Expected O, but got I
		//IL_01bb: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_01ee: Expected O, but got I
		//IL_01fe: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_025f: Expected O, but got I
		//IL_026f: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+50]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rcx_v1+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+58]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rcx_v3+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		object obj5 = default(object);
		UnitySerializedDictionary<TKey, TValue> unitySerializedDictionary = default(UnitySerializedDictionary<TKey, TValue>);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_10_v3+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rcx_v6+C0]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184A14B20");
			if (obj5 == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+50]");
			List<System.Int32Enum> list = (List<System.Int32Enum>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+50]");
			bool flag = (nint)0 == 0;
			List<System.Int32Enum> list2 = (List<System.Int32Enum>)(&unitySerializedDictionary);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_10_v3+20]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdx_v6+C0]");
				list2 = (List<System.Int32Enum>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r9_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r9_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r9_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r9_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r9_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ r8_v5+18]");
					if (num >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+50]");
						((List<System.Int32Enum>)0).AddWithResize((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+50]");
						list2 = (List<System.Int32Enum>)0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ r9_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						list2 = (List<System.Int32Enum>)((nint)0 + (nint)1);
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+58]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.App.Tools.UnitySerializedDictionary`2<TKey, TValue>)+58]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ stack_10_v3+20]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rcx_v14+C0]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v22+B0]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r9_v8+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r9_v8+10]");
						object obj13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r9_v8+18]");
						list2 = (List<System.Int32Enum>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r9_v8+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r9_v8+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v11+18]");
							if (num2 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r8_v9+20]");
								object obj14 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v25+C0]");
								object obj15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183783340");
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r9_v8+18]");
							object obj16 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r9_v8+18]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v11+18]");
							if (num3 >= 0)
							{
								break;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new IndexOutOfRangeException();
	}

	protected UnitySerializedDictionary()
	{
		nint num = 0;
		object obj = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183731620");
		nint num3 = 0;
		object obj2 = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18485AFD0");
	}
}
