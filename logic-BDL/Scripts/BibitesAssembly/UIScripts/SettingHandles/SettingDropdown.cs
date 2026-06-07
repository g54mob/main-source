using System;
using System.Text;
using System.Text.RegularExpressions;
using ManagementScripts;
using ScriptHelpers;
using SettingScripts;
using TMPro;
using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public abstract class SettingDropdown<TSetting, TType> : SettingHandle<TSetting, TType> where TSetting : Setting<TType>
	{
		[SerializeField]
		protected SettingDropdownReference settingDropdownRef;

		private readonly Regex match = new Regex("\\s+");

		protected TooltipTrigger tooltip;

		protected int previousValue;

		[NonSerialized]
		public bool dropdownSelectionRevertable;

		public TMP_Dropdown dropdown => settingDropdownRef.dropdown;

		public override void CreateUIElement(GameObject _parent)
		{
			LinkToRef(UnityEngine.Object.Instantiate(UIPrefabsHolder.Instance.SettingDropdownPrefab, _parent.transform).GetComponent<SettingDropdownReference>());
			InitUIElement();
		}

		public override void InitUIElement()
		{
			base.InitUIElement();
			dropdownSelectionRevertable = changeIsRevertable;
			changeIsRevertable = false;
			if (settingDropdownRef.resetButton != null)
			{
				settingDropdownRef.resetButton.onClick.AddListener(ResetValue);
			}
			if (settingDropdownRef.helperButton != null)
			{
				settingDropdownRef.helperButton.WikiLink = setting.WikiLink;
			}
			if (settingDropdownRef.settingName != null)
			{
				settingDropdownRef.settingName.text = setting.Name;
				tooltip = settingDropdownRef.settingName.GetComponent<TooltipTrigger>();
				if (tooltip != null && !string.IsNullOrEmpty(setting.HelperText))
				{
					tooltip.UpdateText(setting.Name, setting.HelperText);
				}
			}
			if (settingDropdownRef.helperText != null)
			{
				settingDropdownRef.helperText.text = "Info : \n" + setting.HelperText;
				settingDropdownRef.helperText.transform.parent.parent.gameObject.SetActive(value: false);
			}
			if (settingDropdownRef.dropdown != null)
			{
				PopulateList();
				settingDropdownRef.dropdown.onValueChanged.AddListener(OnOptionSelected);
			}
			UpdateUIElement();
			previousValue = dropdown.value;
			initialized = true;
		}

		protected abstract void PopulateList();

		protected virtual void OnOptionSelected(int val)
		{
			bool flag = val != previousValue;
			if (initialized && !SerializationHelper.loadingSettings && !updatedFromSetting && dropdownSelectionRevertable && flag)
			{
				UINavigationManager.AddRevertableActionToStack(new DropdownSelectionAction<TSetting, TType>(this, previousValue, val));
			}
			previousValue = dropdown.value;
			SetValueOfSetting(val);
			if (initialized && !updatedFromSetting && !SerializationHelper.loadingSettings && flag)
			{
				onValueChangedByUser.Invoke(setting.val);
			}
		}

		protected abstract void SetValueOfSetting(int val);

		public void InitUIElement(SettingDropdownReference existingRef)
		{
			LinkToRef(existingRef);
			InitUIElement();
		}

		public override void SetInteractable(bool isInteractable)
		{
			base.SetInteractable(isInteractable);
			settingDropdownRef.dropdown.interactable = isInteractable;
		}

		public void LinkToRef(SettingDropdownReference dropdownRef)
		{
			settingDropdownRef = dropdownRef;
		}

		public override void HideUIElement()
		{
			settingDropdownRef.gameObject.SetActive(value: false);
		}

		public override void ShowUIElement()
		{
			settingDropdownRef.gameObject.SetActive(value: true);
		}

		protected static string AddSpacesToSentence(string text, bool preserveAcronyms = true)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length * 2);
			stringBuilder.Append(text[0]);
			for (int i = 1; i < text.Length; i++)
			{
				if (char.IsUpper(text[i]) && ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) || (preserveAcronyms && char.IsUpper(text[i - 1]) && i < text.Length - 1 && !char.IsUpper(text[i + 1]))))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(text[i]);
			}
			return stringBuilder.ToString();
		}

		protected string RemoveSpaces(string text)
		{
			return match.Replace(text, "");
		}

		protected SettingDropdown(TSetting _setting, SettingDropdownReference reference)
		{
			setting = _setting;
			InitUIElement(reference);
		}

		protected SettingDropdown(TSetting _setting)
			: base(_setting, false)
		{
		}

		protected SettingDropdown()
		{
		}
	}
}
