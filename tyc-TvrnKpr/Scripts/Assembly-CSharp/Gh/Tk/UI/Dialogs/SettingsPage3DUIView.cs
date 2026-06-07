using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using I18n;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gh.Tk.UI.Dialogs
{
	public class SettingsPage3DUIView : MonoBehaviour
	{
		[SerializeField]
		protected DissolveArea3DUIView _dissolveArea;

		[Header("Text Group Sizes")]
		[SerializeField]
		private int _headerTextSizeGroupMaxSize;

		[SerializeField]
		private int _subHeaderTextSizeGroupMaxSize;

		[SerializeField]
		private int _buttonTextSizeGroupMaxSize;

		[SerializeField]
		private int _defaultTextSizeGroupMaxSize;

		private bool _isMaterialsDirty;

		[SerializeField]
		protected GameObject _parentDialog;

		protected IPrefabProvider _prefabProvider;

		[SerializeField]
		protected Container3DUIView _container;

		protected Dictionary<AccordionButton3DUIView, bool> _accordionButtons;

		protected List<Action> _cleanupActions;

		protected TextSizeGroup _headerTextSizeGroup;

		protected TextSizeGroup _subHeaderTextSizeGroup;

		protected TextSizeGroup _buttonTextSizeGroup;

		protected TextSizeGroup _defaultTextSizeGroup;

		protected static PlayerProfile Profile => null;

		public event EventHandler Opened
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void OpenSettingsAndSelectThisPage<T>() where T : SettingsPage3DUIView
		{
		}

		protected virtual void Awake()
		{
		}

		protected TextSizeGroup AddGroup(int maxSize)
		{
			return null;
		}

		private void OnAfterLanguageChanged(object sender, ValueChangedEventArgs<string> args)
		{
		}

		public virtual void Init()
		{
		}

		protected void MarkTextDissolveDirty(object sender, EventArgs e)
		{
		}

		protected void MarkMaterialsDirty()
		{
		}

		protected virtual void Update()
		{
		}

		protected void ClearContent()
		{
		}

		public virtual void Open()
		{
		}

		protected void UpdateAccordion()
		{
		}

		public virtual void Close()
		{
		}

		private void OnEnable()
		{
		}

		protected void RegisterAccordion(AccordionButton3DUIView accordion, bool defaultStateExpanded = true)
		{
		}

		protected TextBlock3DUIView AddTextBlock(string text)
		{
			return null;
		}

		protected TextBlock3DUIView AddTextBlock(string textHoverCodexId, string text, string prefabVariant = "GameSetting_Textblock")
		{
			return null;
		}

		[ContextMenu("Update Dissolve Materials")]
		private void UpdateDissolveMaterials()
		{
		}

		protected Button3DUIView AddButtonSetting(string id, string keyString, Action onClicked, string variant = "GameSetting_Button")
		{
			return null;
		}

		protected ButtonTextBlockCompound AddButtonTextBlockCompoundSetting(string codexId, string buttonKey, string textKey, Action onClicked, string variant = "GameSetting_TextAndButton")
		{
			return null;
		}

		protected InputFieldWithButtonAndLabel3DUIView AddButtonWithTextInputSetting(string id, string labelKeyString, string buttonTextKeyString, string inputPlaceholderKeyString, Action<string> onClicked, string variant = "GameSetting_TextFieldAndButton")
		{
			return null;
		}

		protected (CheckBox3DUIView, GameObject) AddCheckboxSetting(string id, string keyString, Func<bool> getFunc, Action<bool> setFunc, string prefabVariant = "GameSetting_Checkbox")
		{
			return default((CheckBox3DUIView, GameObject));
		}

		protected Slider3DUIView AddSliderSetting(string id, string label, Func<float> getFunc, Action<float> setFunc, Action resetAction = null, float minValue = 0f, float maxValue = 100f, bool isPercentageValue = true, bool roundToIntValues = true, Func<float, string> customValueLabel = null, string sliderPrefabVariant = "GameSetting_Slider")
		{
			return null;
		}

		protected (TMP_DropdownI18n, GameObject) AddDropdownSetting(string id, string keyString, string[] options, Func<string, string> getDisplayString, Func<string> getSelectedValue, Action<string> onValueChanged)
		{
			return default((TMP_DropdownI18n, GameObject));
		}

		protected (TMP_DropdownI18n, GameObject) AddDropdownSetting(string id, string keyString, Action<TMP_DropdownI18n> init, Action<TMP_DropdownI18n, int> onValueChanged)
		{
			return default((TMP_DropdownI18n, GameObject));
		}

		protected AccordionButton3DUIView AddTextHeader(string text, bool showAccordian = true, string prefabVariant = "GameSetting_TextHeader")
		{
			return null;
		}

		protected GameObject AddSubHeader(string text, string prefabVariant = "GameSetting_TextSubHeader")
		{
			return null;
		}

		protected void SetCodexTooltip(BaseInteractable3DUIView view, string codexId)
		{
		}

		protected void AddControlBindingSetting(AccordionButton3DUIView parentGroup, InputAction inputAction, string nameOverride = null, bool lockedAction = false, int bindingIndex1 = 0, int bindingIndex2 = 1, string codexTooltip = null)
		{
		}

		protected (VolumeControl3DUIView, GameObject) AddVolumeSliderSetting(string id, string label)
		{
			return default((VolumeControl3DUIView, GameObject));
		}

		protected void RefreshBindingField(BindingButton3DUIView bindingField, InputAction inputAction, int bindingIndex, List<int> compositeIndexes)
		{
		}

		protected (TMP_Dropdown, GameObject) AddAudioLanguageDropdown()
		{
			return default((TMP_Dropdown, GameObject));
		}
	}
}
