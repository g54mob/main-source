using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Themes;

[Serializable]
public class ThemesDatabase : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ThemeData, string> _003C_003E9__26_0;

		public static Func<ThemeData, bool> _003C_003E9__28_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CSort_003Eb__26_0(ThemeData data)
		{
			if ((object)data != null)
			{
				return data.m_themeName;
			}
			return (string)(object)new NullReferenceException();
		}

		internal bool _003CUpdateThemesNames_003Eb__28_0(ThemeData themeData)
		{
			if ((object)themeData != null)
			{
				bool flag = ((UnityEngine.Object)themeData).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public string themeName;

		internal unsafe bool _003CContainsTheme_003Eb__0(ThemeData theme)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if ((object)theme != null)
			{
				string text = theme.m_themeName;
				if (theme.m_themeName != null)
				{
					string text2 = themeName;
					if ((object)theme.m_themeName != themeName)
					{
						if (themeName != null && text._stringLength == text2._stringLength)
						{
							ref byte second = ref *(byte*)(themeName + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(theme.m_themeName + 20), ref second, length);
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

	public const string GENERAL_THEME_NAME = "General";

	public const string THEME_ASSET_PREFIX = "Theme_";

	public List<string> ThemesNames;

	public List<ThemeData> Themes;

	private static UILanguagePack UILabels => UILanguagePack.Instance;

	public bool AddTheme(ThemeData themeData, bool saveAssets)
	{
		//IL_0188: Expected I4, but got O
		if ((object)themeData != null && ((UnityEngine.Object)themeData).m_CachedPtr != (IntPtr)0)
		{
			if (Themes == null)
			{
				List<ThemeData> themes = new List<ThemeData>();
				Themes = themes;
			}
			List<object> themes2 = (List<object>)(object)Themes;
			if (Themes != null)
			{
				int version = themes2._version + 1;
				themes2._version = version;
				object[] items = themes2._items;
				if (themes2._items != null)
				{
					if (themes2._size >= items.Length)
					{
						((List<object>)(object)Themes).AddWithResize((object)themeData);
					}
					else
					{
						int size = themes2._size + 1;
						themes2._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					UpdateThemesNames();
					DoozyUtils.SetDirty(this, saveAssets);
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool Contains(Guid themeGuid)
	{
		//IL_0014: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		if (Themes != null)
		{
			object obj = 0;
			List<ThemeData>.Enumerator enumerator = default(List<ThemeData>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj2 = 0;
				obj = 1;
			}
			bool result = false;
			if (obj != null)
			{
				bool flag = RemoveNullDatabases();
			}
			return result;
		}
		List<ThemeData> themes = new List<ThemeData>();
		Themes = themes;
		return false;
	}

	public bool Contains(string themeName)
	{
		//IL_0014: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		if (Themes != null)
		{
			object obj = 0;
			List<ThemeData>.Enumerator enumerator = default(List<ThemeData>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj2 = 0;
				obj = 1;
			}
			bool result = false;
			if (obj != null)
			{
				bool flag = RemoveNullDatabases();
			}
			return result;
		}
		List<ThemeData> themes = new List<ThemeData>();
		Themes = themes;
		return false;
	}

	public bool CreateTheme(string themeName, bool showDialog = false, bool saveAssets = false)
	{
		string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.Themes);
		bool saveAssets2 = default(bool);
		return CreateTheme(dataPath, themeName, showDialog, saveAssets2);
	}

	public unsafe bool CreateTheme(string relativePath, string themeName, bool showDialog = false, bool saveAssets = false)
	{
		//IL_00f7: Expected O, but got Ref
		string text = themeName.TrimWhiteSpaceHelper(string.TrimType.Both);
		ThemeData themeData;
		if (text != null && text._stringLength > 0 && !Contains(text))
		{
			themeData = ScriptableObject.CreateInstance<ThemeData>();
			if ((object)themeData != null && ((UnityEngine.Object)themeData).m_CachedPtr != (IntPtr)0)
			{
				themeData.m_themeName = text;
				((UnityEngine.Object)themeData).SetName(text);
				themeData.RefreshThemeVariants(showProgress: false, performUndo: false, saveAssets: false);
				ThemeVariantData activeVariant = themeData.ActiveVariant;
				if (activeVariant != null)
				{
					ThemeVariantData activeVariant2 = themeData.ActiveVariant;
					object obj = default(object);
					if (themeData.ContainsVariant((Guid)(&obj)))
					{
						goto IL_016e;
					}
				}
				List<ThemeVariantData> variants = themeData.Variants;
				if (variants._size > 0)
				{
					ThemeVariantData[] items = variants._items;
					themeData.m_activeVariant = items[0];
					goto IL_016e;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				bool result = default(bool);
				return result;
			}
		}
		return false;
		IL_016e:
		themeData.SetDirty(saveAssets: false);
		bool flag = AddTheme(themeData, saveAssets: false);
		bool dirty = default(bool);
		SetDirty(dirty);
		return true;
	}

	public bool DeleteThemeData(ThemeData themeData)
	{
		if ((object)themeData != null)
		{
			bool flag = ((UnityEngine.Object)themeData).m_CachedPtr == (IntPtr)0;
			return !flag;
		}
		return false;
	}

	public ThemeData GetThemeData(Guid themeGuid)
	{
		List<ThemeData>.Enumerator enumerator = default(List<ThemeData>.Enumerator);
		if (Themes == null)
		{
			List<ThemeData> themes = new List<ThemeData>();
			Themes = themes;
		}
		else if (enumerator.MoveNext())
		{
			ThemeData themeData = null;
			throw new NullReferenceException();
		}
		return null;
	}

	public ThemeData GetThemeData(string themeName)
	{
		List<ThemeData>.Enumerator enumerator = default(List<ThemeData>.Enumerator);
		if (Themes == null)
		{
			List<ThemeData> themes = new List<ThemeData>();
			Themes = themes;
		}
		else if (enumerator.MoveNext())
		{
			ThemeData themeData = null;
			throw new NullReferenceException();
		}
		return null;
	}

	public int GetThemeIndex(Guid id)
	{
		//IL_025f: Expected I4, but got I8
		if (id._a == (nint)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			int num = id._a >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (id._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = id._a >> 32;
					if (num2 == (nint)obj2)
					{
						goto IL_0252;
					}
				}
			}
		}
		List<ThemeData> themes = Themes;
		int num3 = 0;
		int num4 = 0;
		int result = default(int);
		while (num4 < themes._size)
		{
			if (num3 < themes._size)
			{
				ThemeData[] items = themes._items;
				ThemeData themeData = items[num3];
				if (id._a == (nint)themeData.m_id)
				{
					object obj3 = (object)themeData.m_id >> 32;
					int num5 = id._a >> 32;
					if (num5 == (nint)obj3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
						if (id._a == (nint)themeData.m_id)
						{
							object obj4 = (object)themeData.m_id >> 32;
							int num6 = id._a >> 32;
							if (num6 != (nint)obj4)
							{
								num3++;
								num4 = num3;
								continue;
							}
							goto IL_0293;
						}
					}
				}
				num3++;
				num4 = num3;
				continue;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return result;
		}
		goto IL_0252;
		IL_0252:
		num3 = -1;
		goto IL_0293;
		IL_0293:
		return num3;
	}

	public ThemeVariantData GetVariant(Guid variantId)
	{
		//IL_02aa: Expected I, but got O
		//IL_007a: Expected I, but got O
		//IL_00f3: Expected O, but got I4
		//IL_0097: Expected I, but got O
		nint num = (nint)typeof(Guid);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (Il2CppClass<System.Guid>)+B8]");
		nint num2 = 0;
		if (variantId._a == (nint)Guid.Empty)
		{
			num2 = variantId._a >> 32;
			object obj = (object)Guid.Empty >> 32;
			if (num2 == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				bool flag = variantId._a != (nint)Guid.Empty;
				num2 = (nint)Guid.Empty;
				if (!flag)
				{
					num2 = (object)Guid.Empty >> 32;
					int num3 = variantId._a >> 32;
					if (num3 == num2)
					{
						goto IL_026d;
					}
				}
			}
		}
		if (Themes == null)
		{
			throw new NullReferenceException();
		}
		List<ThemeData>.Enumerator enumerator = default(List<ThemeData>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj2 = 0;
		}
		goto IL_026d;
		IL_026d:
		return null;
	}

	public void Initialize()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899809F5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = RemoveNullDatabases();
		if (!Contains("General"))
		{
			string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.Themes);
			bool saveAssets = default(bool);
			bool flag2 = CreateTheme(dataPath, "General", showDialog: false, saveAssets);
		}
	}

	public unsafe bool ContainsTheme(string themeName)
	{
		//IL_0056: Expected I4, but got O
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass17_0();
		if (CS_0024_003C_003E8__locals6 != null)
		{
			CS_0024_003C_003E8__locals6.themeName = themeName;
			Func<ThemeData, bool> predicate = delegate(ThemeData theme)
			{
				//IL_012f: Expected I4, but got O
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d1: Expected Ref, but got Unknown
				//IL_00e8: Expected I8, but got I4
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected Ref, but got Unknown
				if ((object)theme != null)
				{
					string themeName2 = theme.m_themeName;
					if (theme.m_themeName != null)
					{
						string themeName3 = CS_0024_003C_003E8__locals6.themeName;
						if ((object)theme.m_themeName != CS_0024_003C_003E8__locals6.themeName)
						{
							if (CS_0024_003C_003E8__locals6.themeName != null && themeName2._stringLength == themeName3._stringLength)
							{
								ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.themeName + 20);
								ulong length = (ulong)(themeName2._stringLength + themeName2._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(theme.m_themeName + 20), ref second, length);
							}
							return false;
						}
						return true;
					}
				}
				NullReferenceException ex2 = new NullReferenceException();
				return (byte)(int)ex2 != 0;
			};
			return Enumerable.Any(Themes, predicate);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void InitializeThemes()
	{
		if (Themes == null)
		{
			return;
		}
		RemoveDuplicates(performUndo: false);
		bool flag = RemoveNullDatabases();
		List<ThemeData> themes = Themes;
		if (themes._size != 0)
		{
			_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass17_0();
			CS_0024_003C_003E8__locals5.themeName = "Unnamed Theme";
			Func<ThemeData, bool> predicate = delegate(ThemeData theme)
			{
				//IL_012f: Expected I4, but got O
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d1: Expected Ref, but got Unknown
				//IL_00e8: Expected I8, but got I4
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected Ref, but got Unknown
				if ((object)theme != null)
				{
					string themeName = theme.m_themeName;
					if (theme.m_themeName != null)
					{
						string themeName2 = CS_0024_003C_003E8__locals5.themeName;
						if ((object)theme.m_themeName != CS_0024_003C_003E8__locals5.themeName)
						{
							if (CS_0024_003C_003E8__locals5.themeName != null && themeName._stringLength == themeName2._stringLength)
							{
								ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals5.themeName + 20);
								ulong length = (ulong)(themeName._stringLength + themeName._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(theme.m_themeName + 20), ref second, length);
							}
							return false;
						}
						return true;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			};
			if (Enumerable.Any(Themes, predicate))
			{
				if (flag)
				{
					SetDirty(saveAssets: false);
				}
				return;
			}
		}
		Initialize();
	}

	public void RefreshDatabase(bool performUndo = true, bool saveAssets = false)
	{
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance == null)
			{
				goto IL_00a3;
			}
			DoozyUtils.UndoRecordObject(this, instance.RefreshDatabase);
		}
		Initialize();
		if (Themes != null)
		{
			List<ThemeData>.Enumerator enumerator = default(List<ThemeData>.Enumerator);
			if (enumerator.MoveNext())
			{
				ThemeData themeData = null;
				throw new NullReferenceException();
			}
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		goto IL_00a3;
		IL_00a3:
		throw new NullReferenceException();
	}

	public void RemoveDuplicates(bool performUndo, bool saveAssets = false)
	{
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.RemovedDuplicateEntries);
		}
		IEnumerable<ThemeData> enumerable = Enumerable.Distinct(Themes);
		if (enumerable != null)
		{
			List<object> themes = new List<object>(enumerable);
			Themes = (List<ThemeData>)(object)themes;
			UpdateThemesNames(saveAssets);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public bool RemoveNullDatabases(bool saveAssets = false)
	{
		//IL_0201: Expected O, but got I4
		if (Themes == null)
		{
			List<ThemeData> themes = new List<ThemeData>();
			Themes = themes;
			DoozyUtils.SetDirty(this, saveAssets: false);
		}
		List<ThemeData> themes2 = Themes;
		bool flag = (nint)Themes < 0;
		bool flag2 = Themes == null;
		int num = themes2._size - 1;
		bool result = false;
		bool flag3 = false;
		if (!flag)
		{
			bool result2 = default(bool);
			object obj;
			do
			{
				List<ThemeData> themes3 = Themes;
				bool flag4;
				if (num < themes3._size)
				{
					ThemeData[] items = themes3._items;
					ThemeData themeData = items[num];
					if ((object)items[num] != null)
					{
						flag4 = (nint)((UnityEngine.Object)themeData).m_CachedPtr < 0;
						flag2 = ((UnityEngine.Object)themeData).m_CachedPtr == (IntPtr)0;
						if (((UnityEngine.Object)themeData).m_CachedPtr != (IntPtr)0)
						{
							goto IL_01e8;
						}
					}
					flag4 = (nint)Themes < 0;
					flag2 = Themes == null;
					Themes.RemoveAt(num);
					flag3 = true;
					goto IL_01e8;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result2;
				IL_01e8:
				num--;
				obj = !flag4;
				result = flag3;
			}
			while (obj != null);
		}
		UpdateThemesNames();
		if (!flag2)
		{
			DoozyUtils.SetDirty(this, saveAssets);
		}
		return result;
	}

	public bool RenameThemeData(ThemeData themeData, string newThemeName)
	{
		//IL_007f: Expected I4, but got O
		if ((object)themeData != null && ((UnityEngine.Object)themeData).m_CachedPtr != (IntPtr)0)
		{
			if (newThemeName != null)
			{
				string text = newThemeName.TrimWhiteSpaceHelper(string.TrimType.Both);
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool ResetDatabase()
	{
		return true;
	}

	public void SearchForUnregisteredThemes(bool saveAssets)
	{
		//IL_00ab: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		UILanguagePack instance = UILanguagePack.Instance;
		UILanguagePack instance2 = UILanguagePack.Instance;
		ThemeData[] array = Resources.LoadAll<ThemeData>("");
		if (array == null || array.Length == 0)
		{
			return;
		}
		if (Themes == null)
		{
			List<ThemeData> themes = new List<ThemeData>();
			Themes = themes;
		}
		object obj = 0;
		object obj2 = 0;
		nint num2 = default(nint);
		nint num3;
		for (; (nint)obj < array.Length; obj++, num2 = num3)
		{
			UILanguagePack instance3 = UILanguagePack.Instance;
			UILanguagePack instance4 = UILanguagePack.Instance;
			List<ThemeData> themes2 = Themes;
			if (themes2._size != 0)
			{
				int num = Array.IndexOf((object[])themes2._items, (object)array[obj], 0, themes2._size);
				bool flag = num != -1;
				num2 = 0;
				num3 = 0;
				if (flag)
				{
					continue;
				}
			}
			bool flag2 = AddTheme(array[obj], saveAssets: false);
			num3 = num2;
			obj2 = 1;
		}
		if (obj2 != null)
		{
			UILanguagePack instance5 = UILanguagePack.Instance;
			UILanguagePack instance6 = UILanguagePack.Instance;
			UpdateThemesNames();
			DoozyUtils.SetDirty(this, saveAssets);
		}
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void Sort(bool performUndo, bool saveAssets = false)
	{
		//IL_01b5: Expected I, but got O
		//IL_01cb: Expected O, but got I
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_0294: Expected O, but got I4
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.SortDatabase);
		}
		Func<ThemeData, string> keySelector = _003C_003Ec._003C_003E9__26_0;
		if (_003C_003Ec._003C_003E9__26_0 == null)
		{
			Func<ThemeData, string> func = (_003C_003Ec._003C_003E9__26_0 = (ThemeData data) => (string)(((object)data != null) ? ((object)data.m_themeName) : ((object)new NullReferenceException())));
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v51 (Il2CppClass<Doozy.Engine.Themes.ThemesDatabase+<>c>)+B8]");
			object obj = (nint)0 + (nint)8;
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v19+462E0]");
					object obj9 = 0 | obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v19+462E0]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v19+462E0]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v19+462E0]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rdx_v19+462E0]");
				}
				while (num3 != 0);
				keySelector = func;
			}
		}
		IOrderedEnumerable<ThemeData> orderedEnumerable = Enumerable.OrderBy(Themes, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> themes = new List<object>(orderedEnumerable);
			Themes = (List<ThemeData>)(object)themes;
			List<ThemeData>.Enumerator enumerator = default(List<ThemeData>.Enumerator);
			if (enumerator.MoveNext())
			{
				ThemeData themeData = null;
				throw new NullReferenceException();
			}
			UpdateThemesNames(saveAssets);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public void UpdateThemesNames(bool saveAssets = false)
	{
		//IL_00b3: Expected O, but got I4
		//IL_00c1: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		List<object> themesNames = (List<object>)(object)ThemesNames;
		if (ThemesNames != null)
		{
			int version = themesNames._version + 1;
			themesNames._version = version;
			themesNames._size = 0;
			if (themesNames._size > 0)
			{
				Array.Clear(themesNames._items, 0, themesNames._size);
				themesNames = (List<object>)(object)themesNames._items;
			}
			if (Themes != null)
			{
				object obj = 0;
				List<ThemeData>.Enumerator enumerator = default(List<ThemeData>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj2 = 0;
					obj = 1;
				}
				if (ThemesNames != null)
				{
					((List<object>)(object)ThemesNames).Sort();
					if (obj != null)
					{
						Func<ThemeData, bool> predicate = _003C_003Ec._003C_003E9__28_0;
						if (_003C_003Ec._003C_003E9__28_0 == null)
						{
							predicate = (_003C_003Ec._003C_003E9__28_0 = delegate(ThemeData themeData)
							{
								if ((object)themeData != null)
								{
									bool flag = ((UnityEngine.Object)themeData).m_CachedPtr == (IntPtr)0;
									return !flag;
								}
								return false;
							});
						}
						IEnumerable<ThemeData> enumerable = Enumerable.Where(Themes, predicate);
						if (enumerable == null)
						{
							Exception ex = System.Linq.Error.ArgumentNull("source");
							throw ex;
						}
						List<object> themes = new List<object>(enumerable);
						Themes = (List<ThemeData>)(object)themes;
						DoozyUtils.SetDirty(this, saveAssets: false);
					}
					DoozyUtils.SetDirty(this, saveAssets);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public static string[] GetThemesNames(ThemesDatabase database)
	{
		//IL_0032: Expected O, but got I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		List<ThemeData> themes = database.Themes;
		string[] array = new string[themes._size];
		object obj = 0;
		while (true)
		{
			List<ThemeData> themes2 = database.Themes;
			if ((nint)obj < themes2._size)
			{
				if ((nint)obj >= themes2._size)
				{
					break;
				}
				ThemeData[] items = themes2._items;
				ThemeData themeData = items[obj];
				array[obj] = themeData.m_themeName;
				obj++;
				continue;
			}
			return array;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		string[] result = default(string[]);
		return result;
	}

	public static string[] GetVariantNames(ThemeData themeData)
	{
		//IL_0032: Expected O, but got I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		List<ThemeVariantData> variants = themeData.Variants;
		string[] array = new string[variants._size];
		object obj = 0;
		while (true)
		{
			List<ThemeVariantData> variants2 = themeData.Variants;
			if ((nint)obj < variants2._size)
			{
				if ((nint)obj >= variants2._size)
				{
					break;
				}
				ThemeVariantData[] items = variants2._items;
				ThemeVariantData themeVariantData = items[obj];
				array[obj] = themeVariantData.m_variantName;
				obj++;
				continue;
			}
			return array;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		string[] result = default(string[]);
		return result;
	}

	public static string GetThemeDataFilename(string themeName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A03]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (themeName != null)
		{
			string text = themeName.TrimWhiteSpaceHelper(string.TrimType.Both);
			return "Theme_" + text;
		}
		return (string)(object)new NullReferenceException();
	}

	public ThemesDatabase()
	{
		List<string> themesNames = new List<string>();
		ThemesNames = themesNames;
		Themes = new List<ThemeData>();
		base._002Ector();
	}
}
