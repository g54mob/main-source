using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentPropertiesView : BaseGUIView
{
	public const string ChangeComponentKeyEvent = "ComponentPropertiesView.ChangeComponentKeyEvent";

	public const string ChangeOverridablePropertyEvent = "ComponentPropertiesView.ChangeOverridablePropertyEvent";

	public const string IsKeyboardInUsingEvent = "ComponentPropertiesView.IsKeyboardInUsingEvent";

	public const string IsMouseOverScrollEvent = "ComponentPropertiesView.IsMouseOverScrollEvent";

	public const string CloseWindowEvent = "ComponentPropertiesView.CloseWindowEvent";

	public GameObject keyAssignmentPrefab;

	public GameObject booleanPrefab;

	public GameObject comboBoxPrefab;

	public GameObject iconComboBoxPrefab;

	public GameObject sliderPrefab;

	public GameObject textFieldPrefab;

	public GameObject colorPickerPrefab;

	private GameObject propertiesConfigPanel;

	private GameObject inputsPanel;

	private GameObject propertiesPanel;

	private TextMeshProUGUI blockNameText;

	private Button closeButton;

	private LanguagesManager languagesManager;

	private Button3D currentButton3D;

	public override void Initialize()
	{
		languagesManager = GameManager.Instance.LanguagesManager;
		propertiesConfigPanel = mainPanel.transform.Find("PropertiesConfigPanel").gameObject;
		inputsPanel = propertiesConfigPanel.transform.Find("InputsPanel").gameObject;
		propertiesPanel = propertiesConfigPanel.transform.Find("PropertiesPanel").gameObject;
		blockNameText = propertiesConfigPanel.transform.FindComponent<TextMeshProUGUI>("BlockNameText", isRecursively: true);
		closeButton = propertiesConfigPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("ComponentPropertiesView.CloseWindowEvent");
		});
		Util.AddMouseOverUIEvents(propertiesConfigPanel, base.OnMouseOverUIHandler);
		propertiesConfigPanel.SetActive(value: false);
	}

	public void OnComponentDeselected()
	{
		base.IsMouseOverUI = false;
		currentButton3D = null;
		propertiesConfigPanel.SetActive(value: false);
	}

	public void OnComponentSelected(Button3D button3D)
	{
		if (!(button3D is BlockBodyModelButton3D))
		{
			return;
		}
		propertiesConfigPanel.SetActive(value: true);
		if (button3D != currentButton3D)
		{
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.blockSelected, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
		BlockModel blockModel = (button3D as BlockBodyModelButton3D).BlockModel;
		blockNameText.text = blockModel.Schematic.Name;
		inputsPanel.transform.RemoveAllChildren(0);
		inputsPanel.SetActive(blockModel.HasAnyDefaultKeyIO() && !blockModel.HasOnlyHingeJointIOs() && !blockModel.HasOnlyOutputDefaultKeyIOs());
		propertiesPanel.transform.RemoveAllChildren(0);
		propertiesPanel.SetActive(blockModel.HasAnyOverridableProperties());
		foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
		{
			foreach (DefaultKeyIO allDefaultKeyIO in allBlockBodyModel.GetAllDefaultKeyIOs())
			{
				if (allDefaultKeyIO.Place != DefaultKeyIOPlace.HingeJoint && allDefaultKeyIO.Direction != DefaultKeyIODirection.Output && !allDefaultKeyIO.IsInputWithoutKey)
				{
					AddDefaultKeyIO(allDefaultKeyIO);
				}
			}
			foreach (OverridablePropertyModel allOverridableProperty in allBlockBodyModel.GetAllOverridableProperties())
			{
				if (allOverridableProperty is ComboBoxPropertyModel)
				{
					AddComboBoxProperty(allOverridableProperty as ComboBoxPropertyModel);
				}
				else if (allOverridableProperty is BooleanPropertyModel)
				{
					AddBooleanProperty(allOverridableProperty as BooleanPropertyModel);
				}
				else if (allOverridableProperty is SliderPropertyModel)
				{
					AddSliderProperty(allOverridableProperty as SliderPropertyModel);
				}
				else if (allOverridableProperty is TextFieldPropertyModel)
				{
					AddTextFieldProperty(allOverridableProperty as TextFieldPropertyModel);
				}
				else if (allOverridableProperty is ColorPickerPropertyModel)
				{
					AddColorPickerProperty(allOverridableProperty as ColorPickerPropertyModel);
				}
			}
		}
		currentButton3D = button3D;
	}

	private void AddDefaultKeyIO(DefaultKeyIO defaultKey)
	{
		string text = "KeyAssignment_" + defaultKey.ParentBlockBodyModel.BodySchematic.ParentSchematic.Name + "_" + defaultKey.Name;
		KeyAssignment component = Util.InstantiateForGUI(keyAssignmentPrefab, inputsPanel.transform, text).GetComponent<KeyAssignment>();
		component.IsAxisEnabled = !GameManager.Instance.OptionsModel.IsJoystickAxesDisabled;
		string text2 = languagesManager.GetText(defaultKey.BaseName);
		component.SetKey(defaultKey.KeyValue, defaultKey.AxisValue);
		component.SetLabel(text2);
		component.IsAxisSensitive = defaultKey.IsAxisSensitive;
		component.IsKeyControlledByLogic = defaultKey.IsAttachedInWritableSocketIO();
		int bodyIndex = defaultKey.ParentBlockBodyModel.Index;
		string keyName = defaultKey.Name;
		component.AddListener(delegate(KeyCode key, AxisCode axis)
		{
			OnKeyChangedHandler(defaultKey.ParentBlockBodyModel.ParentBlockModel.Id, bodyIndex, keyName, key, axis);
		});
	}

	private void AddComboBoxProperty(ComboBoxPropertyModel comboBoxProperty)
	{
		string text = "ComboBox_" + comboBoxProperty.ParentBlockBodyModel.BodySchematic.ParentSchematic.Name + "_" + comboBoxProperty.Key;
		GameObject gameObject = Util.InstantiateForGUI(comboBoxProperty.IsUsingIcons ? iconComboBoxPrefab : comboBoxPrefab, propertiesPanel.transform, text);
		ComboBoxProperties component = gameObject.GetComponent<ComboBoxProperties>();
		component.SetLabel(languagesManager.GetText(comboBoxProperty.Key));
		ComboBoxPropertyModel.Item[] allItems = comboBoxProperty.GetAllItems();
		foreach (ComboBoxPropertyModel.Item item in allItems)
		{
			if (comboBoxProperty.IsUsingIcons)
			{
				component.AddComboBoxOption(item.ItemLabel, item.ItemIcon);
			}
			else
			{
				component.AddComboBoxOption(item.ItemLabel);
			}
		}
		int comboBoxIndexSelected = (comboBoxProperty.ShouldUseIndexAsItemKey ? comboBoxProperty.ValueAsInt : comboBoxProperty.GetItemIndex(comboBoxProperty.Value));
		component.SetComboBoxIndexSelected(comboBoxIndexSelected);
		component.OnValueChangedEvent = (Action<string>)Delegate.Combine(component.OnValueChangedEvent, (Action<string>)delegate(string value)
		{
			string text2 = (comboBoxProperty.ShouldUseIndexAsItemKey ? value : comboBoxProperty.GetItem(int.Parse(value)).ItemKey);
			NotifyChange("ComponentPropertiesView.ChangeOverridablePropertyEvent", comboBoxProperty, text2);
		});
		ComponentEventTrigger componentEventTrigger = gameObject.transform.FindComponent<ComponentEventTrigger>("Dropdown", isRecursively: true);
		componentEventTrigger.OnPointerEnterEvent += delegate
		{
			NotifyChange("ComponentPropertiesView.IsMouseOverScrollEvent", true);
		};
		componentEventTrigger.OnPointerExitEvent += delegate
		{
			NotifyChange("ComponentPropertiesView.IsMouseOverScrollEvent", false);
		};
	}

	private void AddBooleanProperty(BooleanPropertyModel booleanProperty)
	{
		string text = "Boolean_" + booleanProperty.ParentBlockBodyModel.BodySchematic.ParentSchematic.Name + "_" + booleanProperty.Key;
		GameObject obj = Util.InstantiateForGUI(booleanPrefab, propertiesPanel.transform, text);
		obj.transform.FindComponent<TextMeshProUGUI>("Label").text = languagesManager.GetText(booleanProperty.Key);
		Toggle component = obj.GetComponent<Toggle>();
		component.isOn = booleanProperty.ValueAsBool;
		component.onValueChanged.AddListener(delegate(bool value)
		{
			NotifyChange("ComponentPropertiesView.ChangeOverridablePropertyEvent", booleanProperty, value.ToString());
		});
	}

	private void AddSliderProperty(SliderPropertyModel sliderProperty)
	{
		string text = "Slider_" + sliderProperty.ParentBlockBodyModel.BodySchematic.ParentSchematic.Name + "_" + sliderProperty.Key;
		SliderManager component = Util.InstantiateForGUI(sliderPrefab, propertiesPanel.transform, text).GetComponent<SliderManager>();
		component.ConfigureProperties(float.Parse(sliderProperty.Value), sliderProperty.MinValue, sliderProperty.MaxValue, sliderProperty.StepValue, sliderProperty.DisplayFormat);
		component.Label = languagesManager.GetText(sliderProperty.Key);
		component.OnValueChangedEvent += delegate(float value)
		{
			NotifyChange("ComponentPropertiesView.ChangeOverridablePropertyEvent", sliderProperty, value.ToString());
		};
	}

	private void AddTextFieldProperty(TextFieldPropertyModel textFieldProperty)
	{
		string text = "TextField_" + textFieldProperty.ParentBlockBodyModel.BodySchematic.ParentSchematic.Name + "_" + textFieldProperty.Key;
		GameObject obj = Util.InstantiateForGUI(textFieldPrefab, propertiesPanel.transform, text);
		obj.transform.FindComponent<TextMeshProUGUI>("Label").SetText(languagesManager.GetText(textFieldProperty.Key));
		TMP_InputField tMP_InputField = obj.transform.FindComponent<TMP_InputField>("InputField");
		tMP_InputField.SetTextWithoutNotify(textFieldProperty.Value);
		tMP_InputField.onEndEdit.AddListener(delegate(string value)
		{
			NotifyChange("ComponentPropertiesView.ChangeOverridablePropertyEvent", textFieldProperty, value.ToString());
		});
		tMP_InputField.onSelect.AddListener(delegate
		{
			NotifyChange("ComponentPropertiesView.IsKeyboardInUsingEvent", true);
		});
		tMP_InputField.onEndEdit.AddListener(delegate
		{
			NotifyChange("ComponentPropertiesView.IsKeyboardInUsingEvent", false);
		});
	}

	private void AddColorPickerProperty(ColorPickerPropertyModel colorPickerProperty)
	{
		string text = "ColorPicker_" + colorPickerProperty.ParentBlockBodyModel.BodySchematic.ParentSchematic.Name + "_" + colorPickerProperty.Key;
		GameObject obj = Util.InstantiateForGUI(colorPickerPrefab, propertiesPanel.transform, text);
		obj.transform.FindComponent<TextMeshProUGUI>("Label", isRecursively: true).SetText(languagesManager.GetText(colorPickerProperty.Key) + ":");
		ColorPicker colorPicker = obj.transform.FindComponent<ColorPicker>("CustomColorPicker", isRecursively: true);
		colorPicker.CurrentColor = Util.HexToColor(colorPickerProperty.Value);
		colorPicker.onValueChanged.AddListener(delegate(Color color)
		{
			NotifyChange("ComponentPropertiesView.ChangeOverridablePropertyEvent", colorPickerProperty, "#" + ColorUtility.ToHtmlStringRGB(color));
		});
	}

	private void OnKeyChangedHandler(int blockId, int bodyIndex, string keyName, KeyCode keyCode, AxisCode axisCode)
	{
		NotifyChange("ComponentPropertiesView.ChangeComponentKeyEvent", blockId, bodyIndex, keyName, keyCode, axisCode);
	}
}
