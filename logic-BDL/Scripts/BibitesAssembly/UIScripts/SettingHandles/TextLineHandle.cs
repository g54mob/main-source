using ManagementScripts;
using SettingScripts;
using UIScripts.SettingHandles.References;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public class TextLineHandle : SettingHandle<StringSetting, string>
	{
		private TextLineReference textLineRef;

		private EscapableAction editField;

		private bool editOnClick = true;

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

		public override void InitUIElement()
		{
			base.InitUIElement();
			if (textLineRef.settingName != null)
			{
				textLineRef.settingName.text = setting.Name;
			}
			if (textLineRef.tooltip != null && !string.IsNullOrEmpty(setting.HelperText))
			{
				textLineRef.tooltip.UpdateText(setting.Name, setting.HelperText);
			}
			if (textLineRef.line != null)
			{
				textLineRef.line.text = setting.val;
			}
			if (textLineRef.lineField != null)
			{
				textLineRef.lineField.onDeselect.AddListener(delegate
				{
					CloseEditSection();
				});
				textLineRef.lineField.onSubmit.AddListener(FieldSubmit);
			}
			if (textLineRef.openEdit != null)
			{
				textLineRef.openEdit.onClick.AddListener(OpenEditSection);
			}
			editField = new EscapableAction(CloseEditSection);
			CloseEditSection();
		}

		public void AllowEditOnClick(bool val)
		{
			editOnClick = val;
		}

		public void OpenEditSection()
		{
			if (editOnClick && interactable)
			{
				textLineRef.normalSection.SetActive(value: false);
				textLineRef.editSection.SetActive(value: true);
				textLineRef.lineField.text = setting.val;
				UserControl.SetKeyboardBlockFromSource("TextLineEdit", block: true);
				textLineRef.lineField.Select();
				UINavigationManager.AddEscapableToStack(editField);
			}
		}

		public void CloseEditSection()
		{
			textLineRef.normalSection.SetActive(value: true);
			textLineRef.editSection.SetActive(value: false);
			UserControl.SetKeyboardBlockFromSource("TextLineEdit", block: false);
			UINavigationManager.RemoveEscapableFromStack(editField);
		}

		public void FieldSubmit(string val)
		{
			setting.SetValue(val);
			CloseEditSection();
		}

		public override void SetInteractable(bool isInteractable)
		{
			base.SetInteractable(isInteractable);
			textLineRef.lineField.interactable = isInteractable;
		}

		public override void UpdateUIElement()
		{
			textLineRef.line.text = setting.val;
		}

		public override void HideUIElement()
		{
			textLineRef.gameObject.SetActive(value: false);
		}

		public override void ShowUIElement()
		{
			textLineRef.gameObject.SetActive(value: true);
		}
	}
}
