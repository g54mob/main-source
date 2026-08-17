using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI;

[Serializable]
public class UIPopupDatabase : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<UIPopupLink, string> _003C_003E9__21_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CSort_003Eb__21_0(UIPopupLink reference)
		{
			if ((object)reference != null)
			{
				return reference.PopupName;
			}
			return (string)(object)new NullReferenceException();
		}
	}

	public List<string> PopupNames;

	public List<UIPopupLink> Popups;

	private static UILanguagePack UILabels => UILanguagePack.Instance;

	public bool IsEmpty
	{
		get
		{
			//IL_002c: Expected I4, but got O
			List<UIPopupLink> popups = Popups;
			if (Popups != null)
			{
				return popups._size == 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool Add(UIPopupLink popupLink, bool performUndo, bool saveAssets)
	{
		//IL_0126: Expected I4, but got O
		if ((object)popupLink != null && ((UnityEngine.Object)popupLink).m_CachedPtr != (IntPtr)0)
		{
			if (Popups == null)
			{
				List<UIPopupLink> popups = new List<UIPopupLink>();
				Popups = popups;
			}
			bool flag = default(bool);
			if (flag)
			{
				UILanguagePack instance = UILanguagePack.Instance;
				if ((object)instance == null)
				{
					goto IL_0118;
				}
				UndoRecord(instance.AddItem);
			}
			if (Popups != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AC00");
				UpdateListOfPopupNames();
				DoozyUtils.SetDirty(this, saveAssets);
				return true;
			}
			goto IL_0118;
		}
		return false;
		IL_0118:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe bool Contains(string popupName)
	{
		//IL_0044: Expected O, but got I4
		//IL_004c: Expected O, but got Ref
		if (popupName != null)
		{
			string text = popupName.TrimWhiteSpaceHelper(string.TrimType.Both);
			if (Popups != null)
			{
				List<UIPopupLink>.Enumerator enumerator = default(List<UIPopupLink>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<UIPopupLink>.Enumerator enumerator2 = (List<UIPopupLink>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				return false;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe bool Contains(UIPopup prefab)
	{
		//IL_0195: Expected I4, but got O
		//IL_0066: Expected O, but got I4
		//IL_006e: Expected O, but got Ref
		if ((object)prefab != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [prefab @ rdx (Doozy.Engine.UI.UIPopup)+10]");
			if ((nint)0 != 0)
			{
				if (Popups == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				List<UIPopupLink>.Enumerator enumerator = default(List<UIPopupLink>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<UIPopupLink>.Enumerator enumerator2 = (List<UIPopupLink>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
			}
		}
		return false;
	}

	public bool CreateUIPopupLink(string popupName, GameObject prefab, bool performUndo, bool saveAssets)
	{
		//IL_027e: Expected I4, but got O
		string[] array2;
		if (popupName != null)
		{
			string text = popupName.TrimWhiteSpaceHelper(string.TrimType.Both);
			if (text != null && text._stringLength > 0)
			{
				if (!Contains(text))
				{
					UIPopupLink uIPopupLink = ScriptableObject.CreateInstance<UIPopupLink>();
					if ((object)uIPopupLink != null)
					{
						uIPopupLink.PopupName = text;
						uIPopupLink.Prefab = prefab;
						bool saveAssets2 = default(bool);
						bool flag = Add(uIPopupLink, performUndo: false, saveAssets2);
						return true;
					}
				}
				else
				{
					string[] array = new string[5];
					UILanguagePack instance = UILanguagePack.Instance;
					if ((object)instance != null && array != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						UILanguagePack instance2 = UILanguagePack.Instance;
						if ((object)instance2 != null)
						{
							string anotherEntryExists = instance2.AnotherEntryExists;
							array2 = array;
							goto IL_02ad;
						}
					}
				}
			}
			else
			{
				string[] array3 = new string[5];
				UILanguagePack instance3 = UILanguagePack.Instance;
				if ((object)instance3 != null && array3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					UILanguagePack instance4 = UILanguagePack.Instance;
					if ((object)instance4 != null)
					{
						string anotherEntryExists = instance4.CannotAddEmptyEntry;
						array2 = array3;
						goto IL_02ad;
					}
				}
			}
		}
		goto IL_0270;
		IL_02ad:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		UILanguagePack instance5 = UILanguagePack.Instance;
		if ((object)instance5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string message = string.Concat(array2);
			DDebug.Log(message);
			return false;
		}
		goto IL_0270;
		IL_0270:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool DeletePopupLink(UIPopupLink reference)
	{
		//IL_0092: Expected I4, but got O
		if ((object)reference != null && ((UnityEngine.Object)reference).m_CachedPtr != (IntPtr)0)
		{
			if (Popups != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AC60");
				object obj = default(object);
				bool flag = obj == null;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public unsafe GameObject GetPrefab(string popupName)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<UIPopupLink>.Enumerator enumerator = default(List<UIPopupLink>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<UIPopupLink>.Enumerator enumerator2 = (List<UIPopupLink>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe string GetPopupName(UIPopup prefab)
	{
		//IL_0066: Expected O, but got I4
		//IL_006e: Expected O, but got Ref
		if ((object)prefab != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [prefab @ rdx (Doozy.Engine.UI.UIPopup)+10]");
			if ((nint)0 != 0)
			{
				if (Popups == null)
				{
					return (string)(object)new NullReferenceException();
				}
				List<UIPopupLink>.Enumerator enumerator = default(List<UIPopupLink>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					List<UIPopupLink>.Enumerator enumerator2 = (List<UIPopupLink>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
			}
		}
		return null;
	}

	public unsafe int IndexOf(string popupName)
	{
		//IL_0210: Expected I4, but got I8
		//IL_024a: Expected I4, but got O
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected Ref, but got Unknown
		//IL_018a: Expected I8, but got I4
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Ref, but got Unknown
		if (Contains(popupName))
		{
			List<UIPopupLink> popups = Popups;
			if (Popups == null)
			{
				goto IL_023c;
			}
			int num = 0;
			int num2 = 0;
			while (num2 < popups._size)
			{
				if (num < popups._size)
				{
					UIPopupLink[] items = popups._items;
					if (popups._items != null)
					{
						UIPopupLink uIPopupLink = items[num];
						if ((object)items[num] != null)
						{
							string popupName2 = uIPopupLink.PopupName;
							if (uIPopupLink.PopupName != null)
							{
								if ((object)uIPopupLink.PopupName != popupName)
								{
									if (popupName == null || popupName2._stringLength != popupName._stringLength)
									{
										num++;
										num2 = num;
										continue;
									}
									ref byte second = ref *(byte*)(popupName + 20);
									ulong length = (ulong)(popupName2._stringLength + popupName2._stringLength);
									if (!System.SpanHelpers.SequenceEqual(ref *(byte*)(uIPopupLink.PopupName + 20), ref second, length))
									{
										num++;
										num2 = num;
										continue;
									}
								}
								return num;
							}
						}
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
				goto IL_023c;
			}
		}
		return -1;
		IL_023c:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public int IndexOf(UIPopup prefab)
	{
		//IL_0194: Expected I4, but got I8
		//IL_01ff: Expected O, but got I4
		//IL_0219: Expected O, but got I4
		if (Contains(prefab))
		{
			List<UIPopupLink> popups = Popups;
			int num = 0;
			int num2 = 0;
			int result = default(int);
			while (num2 < popups._size)
			{
				List<UIPopupLink> popups2 = Popups;
				if (num < popups2._size)
				{
					UIPopupLink[] items = popups2._items;
					UIPopupLink uIPopupLink = items[num];
					GameObject prefab2 = uIPopupLink.Prefab;
					GameObject gameObject = prefab.gameObject;
					bool flag = (object)gameObject == null;
					bool flag2 = (object)uIPopupLink.Prefab == null;
					object obj = flag2 & flag;
					bool flag3 = obj == null;
					object obj2 = !flag3;
					if (obj2 == null)
					{
						bool flag4;
						if ((object)gameObject != null)
						{
							if ((object)uIPopupLink.Prefab != null)
							{
								object obj3 = (object)uIPopupLink.Prefab - (object)gameObject;
								flag4 = obj3 == null;
							}
							else
							{
								flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							}
						}
						else
						{
							flag4 = ((UnityEngine.Object)prefab2).m_CachedPtr == (IntPtr)0;
						}
						if (!flag4)
						{
							popups = Popups;
							num++;
							num2 = num;
							continue;
						}
					}
					return num;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		return -1;
	}

	public void RefreshDatabase(bool performUndo, bool saveAssets)
	{
		UILanguagePack instance = UILanguagePack.Instance;
		string text = instance.Database + ": UIPopup";
		UILanguagePack instance2 = UILanguagePack.Instance;
		if (performUndo)
		{
			UILanguagePack instance3 = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance3.RefreshDatabase);
		}
		Sort(performUndo: false);
		UpdateListOfPopupNames();
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public unsafe void RemoveLink(string popupName, bool showDialog, bool saveAssets)
	{
		//IL_0038: Expected O, but got I4
		//IL_0057: Expected I8, but got I4
		//IL_0060: Expected O, but got I4
		//IL_0268: Expected I8, but got I4
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_030d: Expected O, but got I4
		//IL_0287: Expected I8, but got I4
		//IL_0290: Expected O, but got I4
		//IL_0168: Expected O, but got I4
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected Ref, but got Unknown
		//IL_01cd: Expected I8, but got I4
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected Ref, but got Unknown
		if (!Contains(popupName))
		{
			return;
		}
		List<UIPopupLink> popups = Popups;
		bool flag = (nint)Popups < 0;
		object obj = popups._size - 1;
		if (flag)
		{
			return;
		}
		bool flag2 = saveAssets;
		ulong num = 0uL;
		object obj2 = 0;
		while (true)
		{
			List<UIPopupLink> popups2 = Popups;
			if ((nint)obj >= popups2._size)
			{
				break;
			}
			UIPopupLink[] items = popups2._items;
			UIPopupLink uIPopupLink = items[obj];
			string popupName2 = uIPopupLink.PopupName;
			if ((object)uIPopupLink.PopupName == popupName)
			{
				goto IL_022f;
			}
			bool flag3 = (nint)uIPopupLink.PopupName < 0;
			bool flag4 = uIPopupLink.PopupName == null;
			bool flag5 = flag2;
			if (!flag4)
			{
				flag3 = (nint)popupName < 0;
				bool flag6 = popupName == null;
				flag5 = flag2;
				if (!flag6)
				{
					object obj3 = popupName2._stringLength - popupName._stringLength;
					flag3 = (nint)obj3 < 0;
					bool flag7 = popupName2._stringLength != popupName._stringLength;
					flag5 = flag2;
					if (!flag7)
					{
						ref byte second = ref *(byte*)(popupName + 20);
						num = (ulong)(popupName2._stringLength + popupName2._stringLength);
						bool flag8 = System.SpanHelpers.SequenceEqual(ref *(byte*)(uIPopupLink.PopupName + 20), ref second, num);
						flag3 = (flag8 ? 1 : 0) < (false ? 1 : 0);
						bool flag9 = !flag8;
						flag2 = false;
						flag5 = false;
						if (!flag9)
						{
							goto IL_022f;
						}
					}
				}
			}
			goto IL_02f4;
			IL_02f4:
			obj--;
			object obj4 = !flag3;
			flag2 = flag5;
			if (obj4 == null)
			{
				if (obj2 != null)
				{
					DoozyUtils.SetDirty(this, saveAssets);
				}
				return;
			}
			continue;
			IL_022f:
			bool flag10 = DeletePopupLink(uIPopupLink);
			flag3 = (flag10 ? 1 : 0) < (false ? 1 : 0);
			bool flag11 = !flag10;
			flag5 = flag2;
			num = 0uL;
			if (!flag11)
			{
				flag5 = flag2;
				num = 0uL;
				obj2 = 1;
			}
			goto IL_02f4;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void RemoveUnreferencedData(bool saveAssets = false)
	{
	}

	public bool ResetDatabase()
	{
		return true;
	}

	public void SearchForUnregisteredLinks(bool saveAssets)
	{
		//IL_00c2: Expected O, but got I4
		//IL_00cb: Expected O, but got I4
		//IL_01b7: Expected O, but got I4
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		UILanguagePack instance = UILanguagePack.Instance;
		string text = instance.Database + ": UIPopup";
		UILanguagePack instance2 = UILanguagePack.Instance;
		UIPopupLink[] array = Resources.LoadAll<UIPopupLink>("");
		if (array == null || array.Length == 0)
		{
			return;
		}
		if (Popups == null)
		{
			List<UIPopupLink> popups = new List<UIPopupLink>();
			Popups = popups;
		}
		object obj = 0;
		object obj2 = 0;
		nint num4 = default(nint);
		nint num5;
		int num2 = default(int);
		int num6;
		int num7;
		for (int num = 0; (nint)obj < array.Length; obj++, num4 = num5, num2 = num6, num = num7)
		{
			List<UIPopupLink> popups2 = Popups;
			if (popups2._size != 0)
			{
				num2 = popups2._size;
				int num3 = Array.IndexOf((object[])popups2._items, (object)array[obj], 0, popups2._size);
				bool flag = num3 != -1;
				num4 = 0;
				num = 0;
				num5 = 0;
				num6 = popups2._size;
				num7 = 0;
				if (flag)
				{
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AC00");
			num5 = num4;
			num6 = num2;
			obj2 = 1;
			num7 = num;
		}
		if (obj2 != null)
		{
			UpdateListOfPopupNames();
			DoozyUtils.SetDirty(this, saveAssets);
		}
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void Sort(bool performUndo, bool saveAssets = false)
	{
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.SortDatabase);
		}
		Func<UIPopupLink, string> keySelector = _003C_003Ec._003C_003E9__21_0;
		if (_003C_003Ec._003C_003E9__21_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__21_0 = (UIPopupLink reference) => (string)(((object)reference != null) ? ((object)reference.PopupName) : ((object)new NullReferenceException())));
		}
		IOrderedEnumerable<UIPopupLink> orderedEnumerable = Enumerable.OrderBy(Popups, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> popups = new List<object>(orderedEnumerable);
			Popups = (List<UIPopupLink>)(object)popups;
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public void UpdateListOfPopupNames()
	{
		//IL_0056: Expected O, but got I
		//IL_0078: Expected O, but got I
		//IL_00bc: Expected O, but got I4
		Array array = (Array)(object)PopupNames;
		bool flag = PopupNames == null;
		List<object> popupNames = (List<object>)(object)PopupNames;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7 (System.Array)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7 (System.Array)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7 (System.Array)+10]");
				array = (Array)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7 (System.Array)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7 (System.Array)+18]");
				Array.Clear((Array)num, 0, 0);
			}
			bool flag2 = Popups == null;
			popupNames = (List<object>)(object)array;
			if (!flag2)
			{
				List<UIPopupLink>.Enumerator enumerator = default(List<UIPopupLink>.Enumerator);
				if (enumerator.MoveNext())
				{
					popupNames = (List<object>)(object)PopupNames;
					object obj = 0;
					throw new NullReferenceException();
				}
				DoozyUtils.SetDirty(this, saveAssets: false);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public UIPopupDatabase()
	{
		List<string> popupNames = new List<string>();
		PopupNames = popupNames;
		Popups = new List<UIPopupLink>();
		base._002Ector();
	}
}
