using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC;

public class DlcCatalog : ScriptableObject
{
	public DlcDataDictionary _DlcData;

	public DlcData GetData(DlcType dlcType)
	{
		if (_DlcData != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_DlcData).FindEntry((System.Int32Enum)dlcType);
			if (num < 0)
			{
				return null;
			}
			if (_DlcData != null)
			{
				return (DlcData)((Dictionary<System.Int32Enum, object>)(object)_DlcData).get_Item((System.Int32Enum)dlcType);
			}
		}
		return (DlcData)(object)new NullReferenceException();
	}

	public string GetTitle(DlcType dlcType)
	{
		//IL_0091: Expected O, but got I
		if (_DlcData != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)_DlcData).FindEntry((System.Int32Enum)dlcType);
			if (num < 0)
			{
				return "UNKNOWN";
			}
			if (_DlcData != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)_DlcData).get_Item((System.Int32Enum)dlcType);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v8 (System.Object)+18]");
					return (string)0;
				}
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe DlcType? GetDlcType_SteamAppId(string appId)
	{
		//IL_01da: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		//IL_003f: Expected O, but got I
		//IL_005e: Expected O, but got Ref
		//IL_007c: Expected O, but got I
		//IL_0183: Expected O, but got I4
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected Ref, but got Unknown
		//IL_014f: Expected I8, but got I
		Dictionary<DlcType, DlcData>.Enumerator enumerator = default(Dictionary<DlcType, DlcData>.Enumerator);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			bool flag = obj == null;
			Dictionary<DlcType, DlcData>.Enumerator enumerator2 = (Dictionary<DlcType, DlcData>.Enumerator)(&enumerator);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ stack_-20+58]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ stack_-20+58]");
				bool flag2 = (nint)0 == 0;
				enumerator2 = (Dictionary<DlcType, DlcData>.Enumerator)(&enumerator);
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5+10]");
					if (0 != (nint)appId)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5+10]");
						if ((nint)0 == 0 || appId == null)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v6+10]");
						if ((nint)0 != appId._stringLength)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5+10]");
						ref byte first = ref *(byte*)((nint)0 + (nint)20);
						ref byte second = ref *(byte*)(appId + 20);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v6+10]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v6+10]");
						ulong length = (ulong)(num + 0);
						if (!System.SpanHelpers.SequenceEqual(ref first, ref second, length))
						{
							continue;
						}
					}
					return (DlcType?)(object)1;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		return (DlcType?)(object)0;
	}

	public unsafe DlcType? GetDlcType_XboxStoreId(string storeId)
	{
		//IL_01da: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		//IL_003f: Expected O, but got I
		//IL_005e: Expected O, but got Ref
		//IL_007c: Expected O, but got I
		//IL_0183: Expected O, but got I4
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected Ref, but got Unknown
		//IL_014f: Expected I8, but got I
		Dictionary<DlcType, DlcData>.Enumerator enumerator = default(Dictionary<DlcType, DlcData>.Enumerator);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			bool flag = obj == null;
			Dictionary<DlcType, DlcData>.Enumerator enumerator2 = (Dictionary<DlcType, DlcData>.Enumerator)(&enumerator);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ stack_-20+68]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ stack_-20+68]");
				bool flag2 = (nint)0 == 0;
				enumerator2 = (Dictionary<DlcType, DlcData>.Enumerator)(&enumerator);
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5+10]");
					if (0 != (nint)storeId)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5+10]");
						if ((nint)0 == 0 || storeId == null)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v6+10]");
						if ((nint)0 != storeId._stringLength)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v5+10]");
						ref byte first = ref *(byte*)((nint)0 + (nint)20);
						ref byte second = ref *(byte*)(storeId + 20);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v6+10]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v6+10]");
						ulong length = (ulong)(num + 0);
						if (!System.SpanHelpers.SequenceEqual(ref first, ref second, length))
						{
							continue;
						}
					}
					return (DlcType?)(object)1;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		return (DlcType?)(object)0;
	}

	public string GetXboxStoreId(DlcType dlcType)
	{
		//IL_003b: Expected O, but got I
		//IL_006d: Expected O, but got I
		string data = (string)(object)GetData(dlcType);
		if (data != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v1 (System.String)+68]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v1 (System.String)+68]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v2+10]");
				return (string)0;
			}
			return (string)(object)new NullReferenceException();
		}
		return data;
	}

	public string GetXboxStorePackageIdentifier(DlcType dlcType)
	{
		//IL_003b: Expected O, but got I
		//IL_006d: Expected O, but got I
		string data = (string)(object)GetData(dlcType);
		if (data != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v1 (System.String)+68]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v1 (System.String)+68]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rax_v2+18]");
				return (string)0;
			}
			return (string)(object)new NullReferenceException();
		}
		return data;
	}

	public DlcCatalog()
	{
		DlcDataDictionary dlcData = (DlcDataDictionary)(object)new UnitySerializedDictionary<System.Int32Enum, object>();
		_DlcData = dlcData;
		base._002Ector();
	}
}
