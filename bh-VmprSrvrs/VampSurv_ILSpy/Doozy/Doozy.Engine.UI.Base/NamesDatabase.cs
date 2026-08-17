using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Base;

[Serializable]
public class NamesDatabase : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ListOfNames, bool> _003C_003E9__18_0;

		public static Func<ListOfNames, string> _003C_003E9__34_0;

		public static Func<ListOfNames, bool> _003C_003E9__36_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CContains_003Eb__18_0(ListOfNames listOfNames)
		{
			if ((object)listOfNames != null)
			{
				bool flag = ((UnityEngine.Object)listOfNames).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}

		internal string _003CSort_003Eb__34_0(ListOfNames listOfNames)
		{
			if ((object)listOfNames != null)
			{
				return listOfNames.CategoryName;
			}
			return (string)(object)new NullReferenceException();
		}

		internal bool _003CUpdateListOfCategoryNames_003Eb__36_0(ListOfNames listOfNames)
		{
			if ((object)listOfNames != null)
			{
				bool flag = ((UnityEngine.Object)listOfNames).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public string categoryName;

		internal unsafe bool _003CContains_003Eb__1(ListOfNames listOfNames)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if ((object)listOfNames != null)
			{
				string text = listOfNames.CategoryName;
				if (listOfNames.CategoryName != null)
				{
					string text2 = categoryName;
					if ((object)listOfNames.CategoryName != categoryName)
					{
						if (categoryName != null && text._stringLength == text2._stringLength)
						{
							ref byte second = ref *(byte*)(categoryName + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(listOfNames.CategoryName + 20), ref second, length);
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public const string BACK = "Back";

	public const string CUSTOM = "Custom";

	public const string DOWN = "Down";

	public const string GENERAL = "General";

	public const string LEFT = "Left";

	public const string MASTER_CANVAS = "MasterCanvas";

	public const string RIGHT = "Right";

	public const string UNNAMED = "Unnamed";

	public const string UP = "Up";

	public NamesDatabaseType DatabaseType = NamesDatabaseType.UIView;

	public List<string> CategoryNames;

	public List<ListOfNames> Categories;

	private static UILanguagePack UILabels => UILanguagePack.Instance;

	public bool IsEmpty
	{
		get
		{
			//IL_002c: Expected I4, but got O
			List<ListOfNames> categories = Categories;
			if (Categories != null)
			{
				return categories._size == 0;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public bool Add(ListOfNames category, bool performUndo, bool saveAssets)
	{
		//IL_0135: Expected I4, but got O
		if ((object)category != null && ((UnityEngine.Object)category).m_CachedPtr != (IntPtr)0)
		{
			if (Categories == null)
			{
				List<ListOfNames> categories = new List<ListOfNames>();
				Categories = categories;
			}
			bool flag = default(bool);
			if (flag)
			{
				UILanguagePack instance = UILanguagePack.Instance;
				if ((object)instance == null)
				{
					goto IL_0127;
				}
				UndoRecord(instance.AddItem);
			}
			if (Categories != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B350");
				category.DatabaseType = DatabaseType;
				UpdateListOfCategoryNames();
				DoozyUtils.SetDirty(this, saveAssets);
				return true;
			}
			goto IL_0127;
		}
		return false;
		IL_0127:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void AddDefaultCategories(bool saveAssets)
	{
		//IL_00a1: Expected O, but got I4
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		if (!Contains("General"))
		{
			ListOfNames listOfNames = ScriptableObject.CreateInstance<ListOfNames>();
			listOfNames.CategoryName = "General";
			listOfNames.DatabaseType = DatabaseType;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B350");
			UpdateListOfCategoryNames();
			DoozyUtils.SetDirty(this, saveAssets);
		}
		ListOfNames category = GetCategory("General");
		bool flag = DatabaseType == NamesDatabaseType.UIButton;
		if (!flag)
		{
			object obj = DatabaseType - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						if (!category.Contains("Unnamed"))
						{
							category.AddName("Unnamed", performUndo: false);
						}
						if (!category.Contains("Left"))
						{
							category.AddName("Left", performUndo: false);
						}
						if (!category.Contains("Right"))
						{
							category.AddName("Right", performUndo: false);
						}
						if (!category.Contains("Up"))
						{
							category.AddName("Up", performUndo: false);
						}
						if (!category.Contains("Down"))
						{
							category.AddName("Down", performUndo: false);
						}
					}
				}
				else if (!category.Contains("Unnamed"))
				{
					category.AddName("Unnamed", performUndo: false);
				}
			}
			else if (!category.Contains("MasterCanvas"))
			{
				category.AddName("MasterCanvas", performUndo: false);
			}
		}
		else
		{
			if (!category.Contains("Unnamed"))
			{
				category.AddName("Unnamed", performUndo: false);
			}
			if (!category.Contains("Back"))
			{
				category.AddName("Back", performUndo: false);
			}
		}
	}

	public unsafe bool Contains(string categoryName)
	{
		//IL_021d: Expected I4, but got O
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected Ref, but got Unknown
		//IL_012c: Expected I8, but got I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Ref, but got Unknown
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass18_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13.categoryName = categoryName;
			if (CS_0024_003C_003E8__locals13.categoryName != null)
			{
				string categoryName2 = CS_0024_003C_003E8__locals13.categoryName.TrimWhiteSpaceHelper(string.TrimType.Both);
				CS_0024_003C_003E8__locals13.categoryName = categoryName2;
				string categoryName3 = CS_0024_003C_003E8__locals13.categoryName;
				if (CS_0024_003C_003E8__locals13.categoryName != null)
				{
					object obj = "Custom";
					if ((object)CS_0024_003C_003E8__locals13.categoryName != "Custom")
					{
						if ("Custom" != null)
						{
							int stringLength = categoryName3._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdx_v5+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("Custom" + 20);
								ulong length = (ulong)(categoryName3._stringLength + categoryName3._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref *(byte*)(CS_0024_003C_003E8__locals13.categoryName + 20), ref second, length))
								{
									goto IL_0201;
								}
							}
						}
						if (Categories == null)
						{
							List<ListOfNames> categories = new List<ListOfNames>();
							Categories = categories;
							return false;
						}
						Func<ListOfNames, bool> predicate = _003C_003Ec._003C_003E9__18_0;
						if (_003C_003Ec._003C_003E9__18_0 == null)
						{
							predicate = (_003C_003Ec._003C_003E9__18_0 = delegate(ListOfNames listOfNames)
							{
								if ((object)listOfNames != null)
								{
									bool flag = ((UnityEngine.Object)listOfNames).m_CachedPtr == (IntPtr)0;
									return !flag;
								}
								return false;
							});
						}
						IEnumerable<ListOfNames> source = Enumerable.Where(Categories, predicate);
						Func<ListOfNames, bool> predicate2 = delegate(ListOfNames listOfNames)
						{
							//IL_012f: Expected I4, but got O
							//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
							//IL_00d1: Expected Ref, but got Unknown
							//IL_00e8: Expected I8, but got I4
							//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
							//IL_00fb: Expected Ref, but got Unknown
							if ((object)listOfNames != null)
							{
								string categoryName4 = listOfNames.CategoryName;
								if (listOfNames.CategoryName != null)
								{
									string categoryName5 = CS_0024_003C_003E8__locals13.categoryName;
									if ((object)listOfNames.CategoryName != CS_0024_003C_003E8__locals13.categoryName)
									{
										if (CS_0024_003C_003E8__locals13.categoryName != null && categoryName4._stringLength == categoryName5._stringLength)
										{
											ref byte second2 = ref *(byte*)(CS_0024_003C_003E8__locals13.categoryName + 20);
											ulong length2 = (ulong)(categoryName4._stringLength + categoryName4._stringLength);
											return System.SpanHelpers.SequenceEqual(ref *(byte*)(listOfNames.CategoryName + 20), ref second2, length2);
										}
										return false;
									}
									return true;
								}
							}
							NullReferenceException ex2 = new NullReferenceException();
							return (byte)(int)ex2 != 0;
						};
						return Enumerable.Any(source, predicate2);
					}
					goto IL_0201;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0201:
		return true;
	}

	public bool CreateCategory(string categoryName, List<string> names, bool showDialog = false, bool saveAssets = false)
	{
		string path = GetPath(DatabaseType);
		bool showDialog2 = default(bool);
		bool saveAssets2 = default(bool);
		return CreateCategory(path, categoryName, names, showDialog2, saveAssets2);
	}

	public bool CreateCategory(string relativePath, string categoryName, List<string> names, bool showDialog = false, bool saveAssets = false)
	{
		//IL_018d: Expected I4, but got O
		if (categoryName != null)
		{
			string text = categoryName.TrimWhiteSpaceHelper(string.TrimType.Both);
			if (text == null || text._stringLength <= 0 || Contains(text))
			{
				return false;
			}
			ListOfNames listOfNames = ScriptableObject.CreateInstance<ListOfNames>();
			if ((object)listOfNames != null)
			{
				listOfNames.CategoryName = text;
				bool flag = names != null;
				List<string> names2 = names;
				if (!flag)
				{
					List<string> list = new List<string>();
					names2 = list;
				}
				listOfNames.AddNames(names2, performUndo: true);
				listOfNames.DatabaseType = DatabaseType;
				listOfNames.SetDirty(saveAssets: false);
				if (Categories != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B350");
					UpdateListOfCategoryNames();
					bool dirty = default(bool);
					SetDirty(dirty);
					return true;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool DeleteCategory(ListOfNames category)
	{
		if ((object)category != null)
		{
			bool flag = ((UnityEngine.Object)category).m_CachedPtr == (IntPtr)0;
			return !flag;
		}
		return false;
	}

	public unsafe ListOfNames GetCategory(string categoryName)
	{
		//IL_0017: Expected O, but got Ref
		List<ListOfNames>.Enumerator enumerator = default(List<ListOfNames>.Enumerator);
		if (enumerator.MoveNext())
		{
			ListOfNames listOfNames = null;
			List<ListOfNames>.Enumerator enumerator2 = (List<ListOfNames>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe List<string> GetNamesList(string categoryName, bool getDirectReference = false)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<ListOfNames>.Enumerator enumerator = default(List<ListOfNames>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<ListOfNames>.Enumerator enumerator2 = (List<ListOfNames>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe void RefreshDatabase(bool performUndo, bool saveAssets)
	{
		//IL_000e: Expected O, but got Ref
		UILanguagePack instance = UILanguagePack.Instance;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string text2 = instance.Database + ": " + text;
		UILanguagePack instance2 = UILanguagePack.Instance;
		if (performUndo)
		{
			UILanguagePack instance3 = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance3.RefreshDatabase);
		}
		RemoveEmptyNames(performUndo: false);
		RemoveDuplicateNamesFromCategories(performUndo: false);
		AddDefaultCategories(saveAssets: false);
		Sort(performUndo: false);
		UpdateListOfCategoryNames();
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public unsafe void RemoveCategory(string categoryName, bool showDialog, bool saveAssets)
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
		if (!Contains(categoryName))
		{
			return;
		}
		List<ListOfNames> categories = Categories;
		bool flag = (nint)Categories < 0;
		object obj = categories._size - 1;
		if (flag)
		{
			return;
		}
		bool flag2 = saveAssets;
		ulong num = 0uL;
		object obj2 = 0;
		while (true)
		{
			List<ListOfNames> categories2 = Categories;
			if ((nint)obj >= categories2._size)
			{
				break;
			}
			ListOfNames[] items = categories2._items;
			ListOfNames listOfNames = items[obj];
			string categoryName2 = listOfNames.CategoryName;
			if ((object)listOfNames.CategoryName == categoryName)
			{
				goto IL_022f;
			}
			bool flag3 = (nint)listOfNames.CategoryName < 0;
			bool flag4 = listOfNames.CategoryName == null;
			bool flag5 = flag2;
			if (!flag4)
			{
				flag3 = (nint)categoryName < 0;
				bool flag6 = categoryName == null;
				flag5 = flag2;
				if (!flag6)
				{
					object obj3 = categoryName2._stringLength - categoryName._stringLength;
					flag3 = (nint)obj3 < 0;
					bool flag7 = categoryName2._stringLength != categoryName._stringLength;
					flag5 = flag2;
					if (!flag7)
					{
						ref byte second = ref *(byte*)(categoryName + 20);
						num = (ulong)(categoryName2._stringLength + categoryName2._stringLength);
						bool flag8 = System.SpanHelpers.SequenceEqual(ref *(byte*)(listOfNames.CategoryName + 20), ref second, num);
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
			bool flag10 = DeleteCategory(listOfNames);
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

	public unsafe bool Rename(string oldCategoryName, string newCategoryName, bool performUndo = true, bool saveAssets = false)
	{
		//IL_0040: Expected O, but got I4
		//IL_0048: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B2E0");
		object obj = default(object);
		if (obj == null)
		{
			return false;
		}
		List<ListOfNames>.Enumerator enumerator = default(List<ListOfNames>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj2 = 0;
			List<ListOfNames>.Enumerator enumerator2 = (List<ListOfNames>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		UpdateListOfCategoryNames();
		bool dirty = default(bool);
		SetDirty(dirty);
		return true;
	}

	public void RemoveDuplicateNamesFromCategories(bool performUndo, bool saveAssets = false)
	{
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.RemovedDuplicateEntries);
		}
		List<ListOfNames>.Enumerator enumerator = default(List<ListOfNames>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public void RemoveNullDatabases(bool saveAssets = false)
	{
		//IL_01db: Expected O, but got I4
		if (Categories == null)
		{
			List<ListOfNames> categories = new List<ListOfNames>();
			Categories = categories;
			DoozyUtils.SetDirty(this, saveAssets: false);
		}
		List<ListOfNames> categories2 = Categories;
		bool flag = (nint)Categories < 0;
		bool flag2 = Categories == null;
		int num = categories2._size - 1;
		if (!flag)
		{
			object obj;
			do
			{
				List<ListOfNames> categories3 = Categories;
				bool flag3;
				if (num < categories3._size)
				{
					ListOfNames[] items = categories3._items;
					ListOfNames listOfNames = items[num];
					if ((object)items[num] != null)
					{
						flag3 = (nint)((UnityEngine.Object)listOfNames).m_CachedPtr < 0;
						flag2 = ((UnityEngine.Object)listOfNames).m_CachedPtr == (IntPtr)0;
						if (((UnityEngine.Object)listOfNames).m_CachedPtr != (IntPtr)0)
						{
							goto IL_01c2;
						}
					}
					flag3 = (nint)Categories < 0;
					flag2 = Categories == null;
					Categories.RemoveAt(num);
					goto IL_01c2;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
				IL_01c2:
				num--;
				obj = !flag3;
			}
			while (obj != null);
		}
		UpdateListOfCategoryNames();
		if (!flag2)
		{
			DoozyUtils.SetDirty(this, saveAssets);
		}
	}

	public void RemoveEmptyNames(bool performUndo, bool saveAssets = false)
	{
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.RemoveEmptyEntries);
		}
		List<ListOfNames>.Enumerator enumerator = default(List<ListOfNames>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public void RemoveUnreferencedData(bool saveAssets = false)
	{
	}

	public bool ResetDatabase()
	{
		return true;
	}

	public void SearchForUnregisteredDatabases(bool saveAssets)
	{
		//IL_00ad: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_0157: Expected O, but got I4
		UILanguagePack instance = UILanguagePack.Instance;
		UILanguagePack instance2 = UILanguagePack.Instance;
		ListOfNames[] array = Resources.LoadAll<ListOfNames>("");
		if (array == null || array.Length == 0)
		{
			return;
		}
		if (Categories == null)
		{
			List<ListOfNames> categories = new List<ListOfNames>();
			Categories = categories;
		}
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < array.Length)
		{
			UILanguagePack instance3 = UILanguagePack.Instance;
			UILanguagePack instance4 = UILanguagePack.Instance;
			ListOfNames listOfNames = array[obj];
			if (listOfNames.DatabaseType == DatabaseType && !((List<object>)(object)Categories).Contains((object)listOfNames))
			{
				bool flag = Categories.Contains(listOfNames);
				obj2 = 1;
			}
			obj++;
		}
		if (obj2 != null)
		{
			UILanguagePack instance5 = UILanguagePack.Instance;
			UILanguagePack instance6 = UILanguagePack.Instance;
			UpdateListOfCategoryNames();
			DoozyUtils.SetDirty(this, saveAssets);
		}
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public unsafe void Sort(bool performUndo, bool saveAssets = false)
	{
		//IL_01f2: Expected I, but got O
		//IL_0208: Expected O, but got I
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_02d6: Expected O, but got I4
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_00fc: Expected O, but got I4
		//IL_0104: Expected O, but got Ref
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.SortDatabase);
		}
		Func<ListOfNames, string> keySelector = _003C_003Ec._003C_003E9__34_0;
		if (_003C_003Ec._003C_003E9__34_0 == null)
		{
			Func<ListOfNames, string> func = (_003C_003Ec._003C_003E9__34_0 = (ListOfNames listOfNames) => (string)(((object)listOfNames != null) ? ((object)listOfNames.CategoryName) : ((object)new NullReferenceException())));
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v58 (Il2CppClass<Doozy.Engine.UI.Base.NamesDatabase+<>c>)+B8]");
			object obj = (nint)0 + (nint)16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			keySelector = func;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj4 * 8;
				object obj6 = 6603577472L + obj5;
				object obj7 = obj3 & 0x3F;
				nint num3;
				do
				{
					object obj8 = 1 << (int)obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v20+462E0]");
					object obj9 = 0 | obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v20+462E0]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v20+462E0]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v20+462E0]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v20+462E0]");
				}
				while (num3 != 0);
				keySelector = func;
			}
		}
		IOrderedEnumerable<ListOfNames> orderedEnumerable = Enumerable.OrderBy(Categories, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> categories = new List<object>(orderedEnumerable);
			Categories = (List<ListOfNames>)(object)categories;
			List<ListOfNames>.Enumerator enumerator = default(List<ListOfNames>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj10 = 0;
				List<ListOfNames>.Enumerator enumerator2 = (List<ListOfNames>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
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

	public unsafe void UpdateListOfCategoryNames()
	{
		//IL_0068: Expected O, but got I
		//IL_00e5: Expected O, but got Ref
		//IL_01d8: Expected O, but got I4
		//IL_017d: Expected O, but got I
		//IL_0186: Expected O, but got I4
		//IL_02ab: Expected O, but got I
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_0283: Expected O, but got I
		IEnumerable<ListOfNames> categoryNames = (IEnumerable<ListOfNames>)CategoryNames;
		if (CategoryNames != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v8 (System.Collections.Generic.IEnumerable`1<Doozy.Engine.UI.Base.ListOfNames>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v8 (System.Collections.Generic.IEnumerable`1<Doozy.Engine.UI.Base.ListOfNames>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v8 (System.Collections.Generic.IEnumerable`1<Doozy.Engine.UI.Base.ListOfNames>)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v8 (System.Collections.Generic.IEnumerable`1<Doozy.Engine.UI.Base.ListOfNames>)+18]");
				Array.Clear((Array)num, 0, 0);
			}
			Func<ListOfNames, bool> predicate = _003C_003Ec._003C_003E9__36_0;
			if (_003C_003Ec._003C_003E9__36_0 == null)
			{
				predicate = (_003C_003Ec._003C_003E9__36_0 = delegate(ListOfNames listOfNames)
				{
					if ((object)listOfNames != null)
					{
						bool flag2 = ((UnityEngine.Object)listOfNames).m_CachedPtr == (IntPtr)0;
						return !flag2;
					}
					return false;
				});
			}
			IEnumerable<ListOfNames> source = Enumerable.Where(Categories, predicate);
			Func<ListOfNames, bool> predicate2 = delegate(ListOfNames listOfNames)
			{
				//IL_004f: Expected I4, but got O
				//IL_0037: Unknown result type (might be due to invalid IL or missing references)
				//IL_003c: Expected I4, but got Unknown
				if ((object)listOfNames == null || CategoryNames == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B2E0");
				object obj15 = default(object);
				return (byte)(obj15 ^ 1) != 0;
			};
			IEnumerable<ListOfNames> enumerable = Enumerable.Where(source, predicate2);
			if (enumerable != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj2 = default(object);
				object obj = (object)(&obj2);
				object[] array = null;
				List<object> list = null;
				object obj3 = default(object);
				object obj13 = default(object);
				object obj14 = default(object);
				while (true)
				{
					object obj12;
					object obj5;
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj3 == null)
						{
							break;
						}
						bool flag = obj2 == null;
						list = null;
						if (!flag)
						{
							object obj4 = obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ r10_v9+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_01bd;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ r10_v9+B0]");
							obj5 = 0;
							object obj6 = 0;
							while (true)
							{
								object obj7 = obj6 + obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r8_v18+v621 @ rcx_v31*8]");
								if (0 == (nint)typeof(IEnumerator<ListOfNames>))
								{
									break;
								}
								obj6++;
								object obj8 = obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ r10_v9+12E]");
								if ((nint)obj8 < 0)
								{
									continue;
								}
								goto IL_01bd;
							}
							object obj9 = obj6 + obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r8_v18+8+v675 @ rcx_v33*8]");
							object obj10 = (nint)0 << 4;
							object obj11 = obj10 + 312;
							obj12 = obj11 + obj4;
							goto IL_0468;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
					IL_0468:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v680 @ rdx_v19] (should have been resolved before IL gen)");
					list = (List<object>)(object)CategoryNames;
					if (obj13 != null)
					{
						if (CategoryNames != null)
						{
							int version = list._version + 1;
							list._version = version;
							array = list._items;
							if (list._items != null)
							{
								if (list._size >= array.Length)
								{
									List<object> list2 = list;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v32+18]");
									list2.AddWithResize((object)0);
								}
								else
								{
									int size = list._size + 1;
									list._size = size;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									list = (List<object>)(object)list._items;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
					IL_01bd:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj12 = obj14;
					obj5 = 0;
					goto IL_0468;
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (CategoryNames != null)
				{
					((List<object>)(object)CategoryNames).Insert(0, (object)"Custom");
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static bool CanDeleteItem(NamesDatabase database, string itemName)
	{
		//IL_05fa: Expected I4, but got O
		//IL_0068: Expected O, but got I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected Ref, but got Unknown
		//IL_0501: Expected I8, but got I4
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected Ref, but got Unknown
		//IL_0593: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected Ref, but got Unknown
		//IL_05af: Expected I8, but got I4
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Expected Ref, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected Ref, but got Unknown
		//IL_0164: Expected I8, but got I4
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected Ref, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected Ref, but got Unknown
		//IL_022b: Expected I8, but got I4
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected Ref, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected Ref, but got Unknown
		//IL_02f2: Expected I8, but got I4
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected Ref, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected Ref, but got Unknown
		//IL_03b9: Expected I8, but got I4
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998088C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj7;
		if ((object)database != null)
		{
			bool flag = database.DatabaseType == NamesDatabaseType.UIButton;
			if (!flag)
			{
				object obj = database.DatabaseType - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 != 1)
						{
							goto IL_05e0;
						}
						if (itemName != null)
						{
							object obj3 = "Unnamed";
							if ((object)itemName != "Unnamed")
							{
								if ("Unnamed" != null)
								{
									int stringLength = itemName._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v11+10]");
									if ((nint)stringLength == 0)
									{
										ref byte first = ref *(byte*)(itemName + 20);
										ulong length = (ulong)(itemName._stringLength + itemName._stringLength);
										if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("Unnamed" + 20), length))
										{
											goto IL_05e6;
										}
									}
								}
								object obj4 = "Left";
								if ((object)itemName != "Left")
								{
									if ("Left" != null)
									{
										int stringLength2 = itemName._stringLength;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rdx_v13+10]");
										if ((nint)stringLength2 == 0)
										{
											ref byte first2 = ref *(byte*)(itemName + 20);
											ulong length2 = (ulong)(itemName._stringLength + itemName._stringLength);
											if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("Left" + 20), length2))
											{
												goto IL_05e6;
											}
										}
									}
									object obj5 = "Right";
									if ((object)itemName != "Right")
									{
										if ("Right" != null)
										{
											int stringLength3 = itemName._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rdx_v15+10]");
											if ((nint)stringLength3 == 0)
											{
												ref byte first3 = ref *(byte*)(itemName + 20);
												ulong length3 = (ulong)(itemName._stringLength + itemName._stringLength);
												if (System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("Right" + 20), length3))
												{
													goto IL_05e6;
												}
											}
										}
										object obj6 = "Up";
										if ((object)itemName != "Up")
										{
											if ("Up" != null)
											{
												int stringLength4 = itemName._stringLength;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdx_v17+10]");
												if ((nint)stringLength4 == 0)
												{
													ref byte first4 = ref *(byte*)(itemName + 20);
													ulong length4 = (ulong)(itemName._stringLength + itemName._stringLength);
													if (System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("Up" + 20), length4))
													{
														goto IL_05e6;
													}
												}
											}
											obj7 = "Down";
											goto IL_0617;
										}
									}
								}
							}
							goto IL_05e6;
						}
					}
					else if (itemName != null)
					{
						obj7 = "Unnamed";
						goto IL_0617;
					}
				}
				else if (itemName != null)
				{
					obj7 = "MasterCanvas";
					goto IL_0617;
				}
			}
			else if (itemName != null)
			{
				object obj8 = "Unnamed";
				if ((object)itemName == "Unnamed")
				{
					goto IL_05e6;
				}
				if ("Unnamed" != null)
				{
					int stringLength5 = itemName._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v5+10]");
					if ((nint)stringLength5 == 0)
					{
						ref byte first5 = ref *(byte*)(itemName + 20);
						ulong length5 = (ulong)(itemName._stringLength + itemName._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("Unnamed" + 20), length5))
						{
							goto IL_05e6;
						}
					}
				}
				obj7 = "Back";
				goto IL_0617;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_05e6:
		return false;
		IL_0617:
		if (itemName != obj7)
		{
			if (obj7 != null)
			{
				int stringLength6 = itemName._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v1+10]");
				if ((nint)stringLength6 == 0)
				{
					ref byte first6 = ref *(byte*)(itemName + 20);
					ulong length6 = (ulong)(itemName._stringLength + itemName._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)(obj7 + 20), length6))
					{
						goto IL_05e6;
					}
				}
			}
			goto IL_05e0;
		}
		goto IL_05e6;
		IL_05e0:
		return true;
	}

	public static NamesDatabase GetDatabase(string fileName, string resourcesPath)
	{
		string text = "_" + fileName;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182EF8950");
		NamesDatabase result = default(NamesDatabase);
		return result;
	}

	public static string GetPath(NamesDatabaseType databaseType)
	{
		//IL_0013: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		bool flag = databaseType == NamesDatabaseType.UIButton;
		DoozyPath.ComponentName componentName;
		if (!flag)
		{
			object obj = databaseType - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
						throw ex;
					}
					componentName = DoozyPath.ComponentName.UIDrawer;
				}
				else
				{
					componentName = DoozyPath.ComponentName.UIView;
				}
			}
			else
			{
				componentName = DoozyPath.ComponentName.UICanvas;
			}
		}
		else
		{
			componentName = DoozyPath.ComponentName.UIButton;
		}
		return DoozyPath.GetDataPath(componentName);
	}

	public static DoozyPath.ComponentName GetComponentName(NamesDatabaseType databaseType)
	{
		//IL_002b: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		bool flag = databaseType == NamesDatabaseType.UIButton;
		if (!flag)
		{
			object obj = databaseType - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 == 1)
					{
						return DoozyPath.ComponentName.UIDrawer;
					}
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
					throw ex;
				}
				return DoozyPath.ComponentName.UIView;
			}
			return DoozyPath.ComponentName.UICanvas;
		}
		return DoozyPath.ComponentName.UIButton;
	}

	private unsafe static string GetDatabaseFileName(NamesDatabaseType databaseType, string categoryName)
	{
		//IL_0052: Expected O, but got Ref
		//IL_0066: Expected O, but got I
		//IL_0076: Expected O, but got I
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rcx_v3+B8]");
		object newValue = 0;
		if (categoryName != null)
		{
			string text2 = categoryName.Replace(" ", (string)newValue);
			return text + "_" + text2;
		}
		return (string)(object)new NullReferenceException();
	}

	public NamesDatabase()
	{
		List<string> categoryNames = new List<string>();
		CategoryNames = categoryNames;
		Categories = new List<ListOfNames>();
		base._002Ector();
	}

	private bool _003CUpdateListOfCategoryNames_003Eb__36_1(ListOfNames listOfNames)
	{
		//IL_004f: Expected I4, but got O
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected I4, but got Unknown
		if ((object)listOfNames != null && CategoryNames != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B2E0");
			object obj = default(object);
			return (byte)(obj ^ 1) != 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
