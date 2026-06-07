using SettingScripts;
using TMPro;
using UnityEngine;

namespace UIScripts.SettingHandles.References
{
	public sealed class StringFieldHandle : SettingHandle<StringSetting, string>
	{
		private TextLineReference textLineRef;

		public TMP_InputField field => textLineRef.lineField;

		public void LinkToRef(TextLineReference lineRef)
		{
			textLineRef = lineRef;
		}

		public override void CreateUIElement(GameObject _parent)
		{
			LinkToRef(Object.Instantiate(UIPrefabsHolder.Instance.TextLinePrefab, _parent.transform).GetComponent<TextLineReference>());
			InitUIElement();
			initialized = true;
		}

		public StringFieldHandle(StringSetting settingToAssign)
		{
			setting = settingToAssign;
		}

		public StringFieldHandle(StringSetting settingToAssign, TextLineReference reference)
		{
			setting = settingToAssign;
			InitUIElement(reference);
		}

		public void InitUIElement(TextLineReference reference)
		{
			LinkToRef(reference);
			InitUIElement();
		}

		public override void InitUIElement()
		{
			base.InitUIElement();
			if (textLineRef.settingName != null)
			{
				textLineRef.settingName.text = setting.Name + ": ";
			}
			if (textLineRef.tooltip != null && !string.IsNullOrEmpty(setting.HelperText))
			{
				textLineRef.tooltip.UpdateText(setting.Name, setting.HelperText);
			}
			if (textLineRef.normalSection != null)
			{
				textLineRef.normalSection.SetActive(value: false);
			}
			if (textLineRef.editSection != null)
			{
				textLineRef.editSection.SetActive(value: true);
			}
			if (textLineRef.lineField != null)
			{
				textLineRef.lineField.onValueChanged.AddListener(base.SetValue);
				textLineRef.lineField.SetTextWithoutNotify(setting.val);
			}
		}

		public override void UpdateUIElement()
		{
			textLineRef.lineField.SetTextWithoutNotify(setting.val);
		}

		public override void HideUIElement()
		{
			textLineRef.gameObject.SetActive(value: false);
		}

		public override void ShowUIElement()
		{
			textLineRef.gameObject.SetActive(value: true);
		}

		public override void SetInteractable(bool isInteractable)
		{
			base.SetInteractable(isInteractable);
			textLineRef.lineField.interactable = isInteractable;
		}
	}
}
