using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	[ExecuteInEditMode]
	public class UIManagerDropdown : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		public Image background;

		public Image contentBackground;

		public Image mainIcon;

		public TextMeshProUGUI mainText;

		public Image expandIcon;

		public Image itemBackground;

		public Image itemIcon;

		public TextMeshProUGUI itemText;

		private bool dynamicUpdateEnabled;

		private CustomDropdown dropdownMain;

		private DropdownMultiSelect dropdownMulti;

		private void OnEnable()
		{
			try
			{
				dropdownMain = base.gameObject.GetComponent<CustomDropdown>();
			}
			catch
			{
			}
			if (dropdownMain == null)
			{
				dropdownMulti = base.gameObject.GetComponent<DropdownMultiSelect>();
			}
			if (UIManagerAsset == null)
			{
				try
				{
					UIManagerAsset = Resources.Load<UIManager>("MUIP Manager");
				}
				catch
				{
					Debug.LogWarning("No UI Manager found. Assign it manually, otherwise you'll get errors about it.", this);
				}
			}
		}

		private void Awake()
		{
			if (!dynamicUpdateEnabled)
			{
				base.enabled = true;
				UpdateDropdown();
			}
		}

		private void LateUpdate()
		{
			if (Application.isEditor && UIManagerAsset != null)
			{
				if (UIManagerAsset.enableDynamicUpdate)
				{
					dynamicUpdateEnabled = true;
					UpdateDropdown();
				}
				else
				{
					dynamicUpdateEnabled = false;
				}
			}
		}

		private void UpdateDropdown()
		{
			try
			{
				if (UIManagerAsset.buttonThemeType == UIManager.ButtonThemeType.BASIC)
				{
					background.color = UIManagerAsset.dropdownColor;
					contentBackground.color = UIManagerAsset.dropdownColor;
					mainIcon.color = UIManagerAsset.dropdownTextColor;
					mainText.color = UIManagerAsset.dropdownTextColor;
					expandIcon.color = UIManagerAsset.dropdownTextColor;
					itemBackground.color = UIManagerAsset.dropdownItemColor;
					itemIcon.color = UIManagerAsset.dropdownTextColor;
					itemText.color = UIManagerAsset.dropdownTextColor;
					mainText.font = UIManagerAsset.dropdownFont;
					mainText.fontSize = UIManagerAsset.dropdownFontSize;
					itemText.font = UIManagerAsset.dropdownFont;
					itemText.fontSize = UIManagerAsset.dropdownFontSize;
				}
				else if (UIManagerAsset.buttonThemeType == UIManager.ButtonThemeType.CUSTOM)
				{
					background.color = UIManagerAsset.dropdownColor;
					contentBackground.color = UIManagerAsset.dropdownColor;
					mainIcon.color = UIManagerAsset.dropdownIconColor;
					mainText.color = UIManagerAsset.dropdownTextColor;
					expandIcon.color = UIManagerAsset.dropdownIconColor;
					itemBackground.color = UIManagerAsset.dropdownItemColor;
					itemIcon.color = UIManagerAsset.dropdownItemIconColor;
					itemText.color = UIManagerAsset.dropdownItemTextColor;
					mainText.font = UIManagerAsset.dropdownFont;
					mainText.fontSize = UIManagerAsset.dropdownFontSize;
					itemText.font = UIManagerAsset.dropdownItemFont;
					itemText.fontSize = UIManagerAsset.dropdownItemFontSize;
				}
				if (dropdownMain != null)
				{
					if (UIManagerAsset.dropdownAnimationType == UIManager.DropdownAnimationType.FADING)
					{
						dropdownMain.animationType = CustomDropdown.AnimationType.FADING;
					}
					else if (UIManagerAsset.dropdownAnimationType == UIManager.DropdownAnimationType.SLIDING)
					{
						dropdownMain.animationType = CustomDropdown.AnimationType.SLIDING;
					}
					else if (UIManagerAsset.dropdownAnimationType == UIManager.DropdownAnimationType.STYLISH)
					{
						dropdownMain.animationType = CustomDropdown.AnimationType.STYLISH;
					}
				}
				else if (dropdownMulti != null)
				{
					if (UIManagerAsset.dropdownAnimationType == UIManager.DropdownAnimationType.FADING)
					{
						dropdownMulti.animationType = DropdownMultiSelect.AnimationType.FADING;
					}
					else if (UIManagerAsset.dropdownAnimationType == UIManager.DropdownAnimationType.SLIDING)
					{
						dropdownMulti.animationType = DropdownMultiSelect.AnimationType.SLIDING;
					}
					else if (UIManagerAsset.dropdownAnimationType == UIManager.DropdownAnimationType.STYLISH)
					{
						dropdownMulti.animationType = DropdownMultiSelect.AnimationType.STYLISH;
					}
				}
			}
			catch
			{
			}
		}
	}
}
