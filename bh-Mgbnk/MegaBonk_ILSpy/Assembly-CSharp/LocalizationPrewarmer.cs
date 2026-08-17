using System;
using System.Collections.Generic;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

public class LocalizationPrewarmer : MonoBehaviour
{
	public TMP_FontAsset mainFont;

	public TMP_FontAsset notoDefault;

	public TMP_FontAsset notoJp;

	public TMP_FontAsset notoKo;

	public TMP_FontAsset notoSc;

	public TMP_FontAsset notoTc;

	public TMP_FontAsset notoTh;

	public List<string> tableNamesToPreload;

	private void Start()
	{
		Locale selectedLocale = LocalizationSettings.SelectedLocale;
		TMP_FontAsset fontAsset = GetFontAsset(selectedLocale);
		if (fontAsset != null)
		{
			TMP_FontAsset fontAsset2 = GetFontAsset(selectedLocale);
			PrewarmFontAsset(fontAsset2, selectedLocale);
		}
		else
		{
			Debug.LogError("Font asset is null, can't prewarm...");
		}
		Action<Locale> value = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged += value;
	}

	private void OnDestroy()
	{
		Action<Locale> value = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged -= value;
	}

	private void OnLocaleChanged(Locale locale)
	{
		TMP_FontAsset fontAsset = GetFontAsset(locale);
		if (fontAsset != null)
		{
			TMP_FontAsset fontAsset2 = GetFontAsset(locale);
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 74 Invalid \"Jump target not found in method: 0x180508C40\"");
		}
		Debug.LogError("Font asset is null, can't prewarm...");
	}

	public unsafe void PrewarmFontAsset(TMP_FontAsset fontAsset, Locale locale)
	{
		//IL_0057: Expected O, but got Ref
		//IL_006d: Expected I, but got O
		//IL_0098: Expected O, but got Ref
		//IL_01e9: Expected I4, but got O
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		HashSet<char> hashSet = new HashSet<char>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		Guid guid2 = default(Guid);
		Guid guid = guid2;
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		List<object>.Enumerator enumerator = enumerator2;
		List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
		object obj2 = default(object);
		List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
		IntPtr intPtr = default(IntPtr);
		object obj3 = default(object);
		UnityEngine.Object obj4 = default(UnityEngine.Object);
		string value = default(string);
		string text = default(string);
		object arg = default(object);
		while (true)
		{
			if (enumerator3.MoveNext())
			{
				LocalizedStringDatabase stringDatabase = LocalizationSettings.StringDatabase;
				TableReference tableReference = (string)guid2;
				bool flag = stringDatabase == null;
				UnityEngine.Object obj = (UnityEngine.Object)(&obj2);
				if (flag)
				{
					break;
				}
				nint num = (nint)stringDatabase;
				enumerator = (List<object>.Enumerator)tableReference.m_TableCollectionName;
				guid = tableReference._003CTableCollectionNameGuid_003Ek__BackingField;
				StringTable table = stringDatabase.GetTable((TableReference)(&enumerator4), locale);
				if (!(table != null))
				{
					continue;
				}
				if ((object)table != null)
				{
					ICollection<StringTableEntry> values = table.Values;
					if (values != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
						while (true)
						{
							if (intPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
								if (obj3 == null)
								{
									break;
								}
								bool flag2 = intPtr == (IntPtr)0;
								obj = null;
								if (!flag2)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
									if ((object)obj4 == null)
									{
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181C957E0");
									if (string.IsNullOrEmpty(value))
									{
										continue;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181C957E0");
									bool flag3 = text == null;
									string text2 = null;
									if (flag3)
									{
										throw new NullReferenceException();
									}
									while ((nint)text2 < text._stringLength)
									{
										char item = text.get_Chars((int)text2);
										if (hashSet != null)
										{
											bool flag4 = hashSet.Add(item);
											text2++;
											continue;
										}
										throw new NullReferenceException();
									}
									continue;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F6C90");
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<string>.Enumerator*)(&enumerator3))->Dispose();
			List<char> list = new List<char>(hashSet);
			char[] val = list.ToArray();
			string characters = ((string)null).CreateString(val);
			bool flag5 = fontAsset.TryAddCharacters(characters, out var _);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			string s = $"[FontPrewarm] Prewarmed {arg} characters for {locale.m_Identifier}";
			MyLogger.LogInBuild(s);
			SortFallbacks(fontAsset);
			return;
		}
		throw new NullReferenceException();
	}

	private void SortFallbacks(TMP_FontAsset fontAsset)
	{
		//IL_0568: Expected O, but got I4
		List<TMP_FontAsset> list = new List<TMP_FontAsset>();
		int version = list._version + 1;
		list._version = version;
		TMP_FontAsset[] items = list._items;
		int size = list._size;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)notoDefault);
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			items[size] = notoDefault;
		}
		int version2 = list._version + 1;
		list._version = version2;
		TMP_FontAsset[] items2 = list._items;
		int size3 = list._size;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)notoJp);
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			items2[size3] = notoJp;
		}
		int version3 = list._version + 1;
		list._version = version3;
		TMP_FontAsset[] items3 = list._items;
		int size5 = list._size;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)notoKo);
		}
		else
		{
			int size6 = list._size + 1;
			list._size = size6;
			items3[size5] = notoKo;
		}
		int version4 = list._version + 1;
		list._version = version4;
		TMP_FontAsset[] items4 = list._items;
		int size7 = list._size;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)notoSc);
		}
		else
		{
			int size8 = list._size + 1;
			list._size = size8;
			items4[size7] = notoSc;
		}
		int version5 = list._version + 1;
		list._version = version5;
		TMP_FontAsset[] items5 = list._items;
		int size9 = list._size;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)notoTc);
		}
		else
		{
			int size10 = list._size + 1;
			list._size = size10;
			items5[size9] = notoTc;
		}
		int version6 = list._version + 1;
		list._version = version6;
		TMP_FontAsset[] items6 = list._items;
		int size11 = list._size;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)notoTh);
		}
		else
		{
			int size12 = list._size + 1;
			list._size = size12;
			items6[size11] = notoTh;
		}
		bool flag = ((List<object>)(object)list).Remove((object)fontAsset);
		((List<object>)(object)list).Insert(0, (object)fontAsset);
		TMP_FontAsset tMP_FontAsset = mainFont;
		List<TMP_FontAsset> list2 = new List<TMP_FontAsset>();
		TMP_FontAsset tMP_FontAsset2 = list.get_Item(0);
		int version7 = list2._version + 1;
		list2._version = version7;
		TMP_FontAsset[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)tMP_FontAsset2);
		}
		else
		{
			int size13 = list2._size + 1;
			list2._size = size13;
			int num = default(int);
			items7[num] = tMP_FontAsset2;
		}
		tMP_FontAsset.m_FallbackFontAssetTable = list2;
		int num2 = 0;
		int num3 = 0;
		while (num2 < list._size)
		{
			object obj = list._size - 1;
			if (num3 != (nint)obj)
			{
				TMP_FontAsset tMP_FontAsset3 = list.get_Item(num3);
				List<TMP_FontAsset> list3 = new List<TMP_FontAsset>();
				int index = num3 + 1;
				TMP_FontAsset item = list.get_Item(index);
				list3.Add(item);
				tMP_FontAsset3.m_FallbackFontAssetTable = list3;
				num3++;
				num2 = num3;
				continue;
			}
			break;
		}
	}

	private TMP_FontAsset GetFontAsset(Locale locale)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172E00]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)locale != null && (object)locale.m_Identifier != null)
		{
			string text = ((string)locale.m_Identifier).ToLower();
			if (text != null)
			{
				if (!text.StartsWith("ja"))
				{
					if (!text.StartsWith("ko"))
					{
						if (!text.StartsWith("zh-hans") && text != "zh-cn")
						{
							if (!text.StartsWith("zh-hant") && text != "zh-tw" && text != "zh-hk")
							{
								if (!text.StartsWith("th"))
								{
									return notoDefault;
								}
								return notoTh;
							}
							return notoTc;
						}
						return notoSc;
					}
					return notoKo;
				}
				return notoJp;
			}
		}
		return (TMP_FontAsset)(object)new NullReferenceException();
	}

	public LocalizationPrewarmer()
	{
		List<string> list = new List<string>();
		tableNamesToPreload = list;
		base._002Ector();
	}
}
