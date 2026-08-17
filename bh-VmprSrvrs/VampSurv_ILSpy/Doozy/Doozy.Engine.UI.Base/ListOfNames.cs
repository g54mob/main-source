using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Base;

[Serializable]
public class ListOfNames : ScriptableObject
{
	public string CategoryName;

	public NamesDatabaseType DatabaseType = NamesDatabaseType.UIView;

	public List<string> Names;

	private static UILanguagePack UILabels => UILanguagePack.Instance;

	public void AddName(string value, bool performUndo, bool saveAssets = false)
	{
		//IL_0076: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		string text = value.TrimWhiteSpaceHelper(string.TrimType.Both);
		if (text == null || text._stringLength <= 0)
		{
			return;
		}
		bool flag = Names != null;
		object obj = 0;
		if (!flag)
		{
			List<string> names = new List<string>();
			Names = names;
			obj = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B2E0");
		object obj2 = default(object);
		if (obj2 == null)
		{
			if (performUndo)
			{
				UILanguagePack instance = UILanguagePack.Instance;
				UndoRecord(instance.AddItem);
			}
			Names.Add(text);
			SetDirty(saveAssets);
		}
	}

	public void AddNames(List<string> names, bool performUndo, bool saveAssets = false)
	{
		if (names == null)
		{
			return;
		}
		bool flag = Names != null;
		if (!flag)
		{
			List<string> names2 = new List<string>();
			Names = names2;
		}
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			UndoRecord(instance.AddItem);
		}
		bool flag2 = saveAssets;
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		nint num2 = default(nint);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				List<string> names3 = Names;
				if (Names != null)
				{
					bool flag3 = names3._size == 0;
					bool flag4 = flag2;
					nint num = num2;
					bool flag5 = flag;
					if (!flag3)
					{
						int num3 = Array.IndexOf((object[])names3._items, (object)null, 0, names3._size);
						flag5 = num3 != -1;
						flag4 = (byte)names3._size != 0;
						num = 0;
						flag2 = (byte)names3._size != 0;
						num2 = 0;
						flag = flag5;
						if (flag5)
						{
							continue;
						}
					}
					if (Names == null)
					{
						break;
					}
					Names.Add(null);
					flag2 = flag4;
					num2 = num;
					flag = flag5;
					continue;
				}
				throw new NullReferenceException();
			}
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		throw new NullReferenceException();
	}

	public void Clear(bool performUndo, bool saveAssets = false)
	{
		if (Names == null)
		{
			List<string> names = new List<string>();
			Names = names;
		}
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.AddItem);
		}
		List<string> names2 = Names;
		int version = names2._version + 1;
		names2._version = version;
		names2._size = 0;
		if (names2._size > 0)
		{
			Array.Clear(names2._items, 0, names2._size);
		}
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public bool Contains(string value)
	{
		//IL_005f: Expected I4, but got O
		if (Names == null)
		{
			List<string> names = new List<string>();
			Names = names;
		}
		if (Names != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B2E0");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void RemoveDuplicateNames()
	{
		if (Names == null)
		{
			List<string> names = new List<string>();
			Names = names;
		}
		IEnumerable<string> names2 = Names;
		IEnumerable<string> enumerable = Enumerable.Distinct(Names);
		if (enumerable != null)
		{
			List<object> names3 = new List<object>(enumerable);
			Names = (List<string>)(object)names3;
			List<string> names4 = Names;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v3 (System.Collections.Generic.IEnumerable`1<System.String>)+18]");
			if ((nint)0 != names4._size)
			{
				DoozyUtils.SetDirty(this, saveAssets: false);
			}
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void RemoveEmptyNames()
	{
		//IL_005f: Expected O, but got I4
		//IL_013f: Expected O, but got I4
		//IL_01b8: Expected O, but got I4
		if (Names == null)
		{
			List<string> names = new List<string>();
			Names = names;
		}
		List<string> names2 = Names;
		bool flag = (nint)Names < 0;
		int num = names2._size - 1;
		object obj = 0;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<string> names3 = Names;
			if (num >= names3._size)
			{
				break;
			}
			string[] items = names3._items;
			string text = items[num].TrimWhiteSpaceHelper(string.TrimType.Both);
			bool flag2;
			if (text != null)
			{
				flag2 = text._stringLength < 0;
				if (text._stringLength > 0)
				{
					goto IL_019f;
				}
			}
			flag2 = (nint)Names < 0;
			Names.RemoveAt(num);
			obj = 1;
			goto IL_019f;
			IL_019f:
			num--;
			object obj2 = !flag2;
			if (obj2 == null)
			{
				if (obj != null)
				{
					DoozyUtils.SetDirty(this, saveAssets: false);
				}
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void RemoveName(string value, bool performUndo, bool saveAssets = false)
	{
		//IL_0076: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		string text = value.TrimWhiteSpaceHelper(string.TrimType.Both);
		if (text == null || text._stringLength <= 0)
		{
			return;
		}
		bool flag = Names != null;
		object obj = 0;
		if (!flag)
		{
			List<string> names = new List<string>();
			Names = names;
			obj = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B2E0");
		object obj2 = default(object);
		if (obj2 != null)
		{
			if (performUndo)
			{
				UILanguagePack instance = UILanguagePack.Instance;
				UndoRecord(instance.AddItem);
			}
			bool flag2 = ((List<object>)(object)Names).Remove((object)text);
			SetDirty(saveAssets);
		}
	}

	public void Rename(string newCategoryName, string newAssetName, bool saveAssets)
	{
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public ListOfNames()
	{
		List<string> names = new List<string>();
		Names = names;
		base._002Ector();
	}
}
