using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors;

public class LanguageDropDownUI : MonoBehaviour
{
	private Dictionary<string, string> DisplayNames;

	private void Awake()
	{
	}

	private void OnEnable()
	{
		//IL_0052: Expected I, but got O
		//IL_00f5: Expected I, but got O
		//IL_0532: Expected I, but got O
		//IL_0139: Expected I, but got O
		//IL_0239: Expected I, but got O
		//IL_016b: Expected I, but got O
		//IL_01a6: Expected I, but got O
		//IL_0331: Expected I4, but got O
		//IL_03c3: Expected O, but got I
		//IL_03c3: Expected O, but got I
		//IL_03d7: Expected I4, but got O
		TMP_Dropdown component = GetComponent<TMP_Dropdown>();
		if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string currentLanguage = LocalizationManager.CurrentLanguage;
		nint num = (nint)typeof(LocalizationManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rdx_v3 (Il2CppClass<I2.Loc.LocalizationManager>)+B8]");
		nint num2 = 0;
		List<LanguageSourceData> sources = LocalizationManager.Sources;
		if (LocalizationManager.Sources != null)
		{
			if (sources._size == 0)
			{
				bool flag = LocalizationManager.UpdateSources();
			}
			List<string> allLanguages = LocalizationManager.GetAllLanguages();
			List<string> list = new List<string>();
			bool flag2 = allLanguages == null;
			num2 = (nint)list;
			if (!flag2)
			{
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				while (enumerator.MoveNext())
				{
					CultureInfo cultureInfo = new CultureInfo((string)null, true, false);
					bool flag3 = cultureInfo == null;
					num2 = (nint)cultureInfo;
					if (!flag3)
					{
						string displayName = cultureInfo.DisplayName;
						bool flag4 = list == null;
						num2 = (nint)cultureInfo;
						if (!flag4)
						{
							int version = list._version + 1;
							list._version = version;
							num2 = (nint)list._items;
							if (list._items != null)
							{
								if (list._size >= (LocalizationManager.mChangeCultureInfo ? 1 : 0))
								{
									((List<object>)(object)list).AddWithResize((object)displayName);
									continue;
								}
								int size = list._size + 1;
								list._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				num2 = (nint)component.m_Options;
				if (component.m_Options != null)
				{
					num2 = (nint)LocalizationManager.mCurrentCulture;
					if (LocalizationManager.mCurrentCulture != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rcx_v14 (Il2CppStaticFields<I2.Loc.LocalizationManager>)+1C]");
						_ = (nint)0 + (nint)1;
						LocalizationManager.mChangeCultureInfo = false;
						if ((LocalizationManager.mChangeCultureInfo ? 1 : 0) > (false ? 1 : 0))
						{
							Array.Clear((Array)(object)LocalizationManager.mCurrentCulture, 0, LocalizationManager.mChangeCultureInfo ? 1 : 0);
						}
						Graphic placeholder = component.m_Placeholder;
						bool flag6;
						if ((object)component.m_Placeholder != null)
						{
							bool flag5 = ((UnityEngine.Object)placeholder).m_CachedPtr == (IntPtr)0;
							flag6 = flag5;
						}
						else
						{
							flag6 = true;
						}
						int value = (flag6 ? 1 : 0) - 1;
						component.m_Value = value;
						component.RefreshShownValue();
						component.AddOptions(list);
						int value2 = Array.IndexOf((object[])allLanguages._items, (object)currentLanguage, 0, allLanguages._size);
						component.SetValue(value2, true);
						TMP_Dropdown.DropdownEvent onValueChanged = component.m_OnValueChanged;
						UnityAction<int> unityAction = null;
						((LanguageDropDownUI)(object)unityAction).OnValueChanged((int)this);
						if (component.m_OnValueChanged != null && unityAction != null)
						{
							MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rsi_v8 (TMPro.TMP_Dropdown+DropdownEvent)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rsi_v8 (TMPro.TMP_Dropdown+DropdownEvent)+10]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ rax_v46 (UnityEngine.Events.UnityAction`1<System.Int32>)+20]");
								((UnityEngine.Events.InvokableCallList)num3).RemoveListener(0, methodImpl);
								UnityAction<int> unityAction2 = null;
								((LanguageDropDownUI)(object)unityAction2).OnValueChanged((int)this);
								if (component.m_OnValueChanged != null)
								{
									component.m_OnValueChanged.AddListener(unityAction2);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnValueChanged(int index)
	{
		TMP_Dropdown component = GetComponent<TMP_Dropdown>();
		bool flag = index >= 0;
		int num = index;
		if (!flag)
		{
			component.SetValue(0, true);
			num = 0;
		}
		List<string> allLanguages = LocalizationManager.GetAllLanguages();
		if (num < allLanguages._size)
		{
			string[] items = allLanguages._items;
			LocalizationManager.CurrentLanguage = items[num];
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public LanguageDropDownUI()
	{
		Dictionary<string, string> displayNames = new Dictionary<string, string>();
		DisplayNames = displayNames;
	}
}
