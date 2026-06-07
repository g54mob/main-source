using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InspectorView : BaseGUIView
{
	public const string ColorPresetsChangedEvent = "InspectorView.ColorPresetsChangedEvent";

	private GameObject transformPanel;

	private GameObject propertiesPanel;

	private GameObject colorPanel;

	private GameObject logicPanel;

	private GameObject rotatorPanel;

	private TextMeshProUGUI levelObjectNameText;

	private TMP_InputField posXInput;

	private TMP_InputField posYInput;

	private TMP_InputField posZInput;

	private TMP_InputField rotXInput;

	private TMP_InputField rotYInput;

	private TMP_InputField rotZInput;

	private TMP_InputField sclXInput;

	private TMP_InputField sclYInput;

	private TMP_InputField sclZInput;

	private Toggle affectedByPhysicsToggle;

	private TMP_InputField massInput;

	private ColorPicker colorPicker;

	private ColorPresets colorPresets;

	private HexColorField hexColorField;

	private Toggle gridRemoveToggle;

	private Toggle altTexOffsetToggle;

	private TextMeshProUGUI outputText;

	private Toggle invertedLogicToggle;

	private Toggle pressOnceToggle;

	private Button logicPlugButton;

	private Button logicUnplugButton;

	private TMP_InputField spdXInput;

	private TMP_InputField spdYInput;

	private TMP_InputField spdZInput;

	private Toggle localSpaceToggle;

	private LevelObjectView selectedLevelObjectView;

	private bool shouldOnlyShowLogicPanel;

	public bool IsAnyInputFieldFocused
	{
		get
		{
			if (!posXInput.isFocused && !posYInput.isFocused && !posZInput.isFocused && !rotXInput.isFocused && !rotYInput.isFocused && !rotZInput.isFocused && !sclXInput.isFocused && !sclYInput.isFocused && !sclZInput.isFocused && !massInput.isFocused)
			{
				return hexColorField.IsHexInputFieldFocused;
			}
			return true;
		}
	}

	public event Action OnTransformChanged;

	public event Action OnPickingUpOutputForInput;

	public override void Initialize()
	{
		transformPanel = mainPanel.transform.FindChildRecursively("TransformPanel").gameObject;
		propertiesPanel = mainPanel.transform.FindChildRecursively("PropertiesPanel").gameObject;
		colorPanel = mainPanel.transform.FindChildRecursively("ColorPanel").gameObject;
		logicPanel = mainPanel.transform.FindChildRecursively("LogicPanel").gameObject;
		rotatorPanel = mainPanel.transform.FindChildRecursively("RotatorPanel").gameObject;
		levelObjectNameText = mainPanel.transform.FindComponent<TextMeshProUGUI>("LevelObjectNameText", isRecursively: true);
		posXInput = mainPanel.transform.FindComponent<TMP_InputField>("PosXValue", isRecursively: true);
		posYInput = mainPanel.transform.FindComponent<TMP_InputField>("PosYValue", isRecursively: true);
		posZInput = mainPanel.transform.FindComponent<TMP_InputField>("PosZValue", isRecursively: true);
		rotXInput = mainPanel.transform.FindComponent<TMP_InputField>("RotXValue", isRecursively: true);
		rotYInput = mainPanel.transform.FindComponent<TMP_InputField>("RotYValue", isRecursively: true);
		rotZInput = mainPanel.transform.FindComponent<TMP_InputField>("RotZValue", isRecursively: true);
		sclXInput = mainPanel.transform.FindComponent<TMP_InputField>("SclXValue", isRecursively: true);
		sclYInput = mainPanel.transform.FindComponent<TMP_InputField>("SclYValue", isRecursively: true);
		sclZInput = mainPanel.transform.FindComponent<TMP_InputField>("SclZValue", isRecursively: true);
		affectedByPhysicsToggle = mainPanel.transform.FindComponent<Toggle>("PhysicsToggle", isRecursively: true);
		massInput = mainPanel.transform.FindComponent<TMP_InputField>("MassInput", isRecursively: true);
		colorPicker = mainPanel.transform.FindComponent<ColorPicker>("CustomColorPicker", isRecursively: true);
		colorPresets = mainPanel.transform.FindComponent<ColorPresets>("Presets", isRecursively: true);
		hexColorField = mainPanel.transform.FindComponent<HexColorField>("ColorInput", isRecursively: true);
		gridRemoveToggle = mainPanel.transform.FindComponent<Toggle>("GridRemoveToggle", isRecursively: true);
		altTexOffsetToggle = mainPanel.transform.FindComponent<Toggle>("AltTexOffsetToggle", isRecursively: true);
		outputText = mainPanel.transform.FindComponent<TextMeshProUGUI>("OutputText", isRecursively: true);
		invertedLogicToggle = mainPanel.transform.FindComponent<Toggle>("InvertedLogicToggle", isRecursively: true);
		pressOnceToggle = mainPanel.transform.FindComponent<Toggle>("PressOnceToggle", isRecursively: true);
		logicPlugButton = mainPanel.transform.FindComponent<Button>("LogicPlugButton", isRecursively: true);
		logicUnplugButton = mainPanel.transform.FindComponent<Button>("LogicUnplugButton", isRecursively: true);
		spdXInput = mainPanel.transform.FindComponent<TMP_InputField>("SpdXValue", isRecursively: true);
		spdYInput = mainPanel.transform.FindComponent<TMP_InputField>("SpdYValue", isRecursively: true);
		spdZInput = mainPanel.transform.FindComponent<TMP_InputField>("SpdZValue", isRecursively: true);
		localSpaceToggle = mainPanel.transform.FindComponent<Toggle>("LocalSpaceToggle", isRecursively: true);
		posXInput.onEndEdit.AddListener(delegate(string value)
		{
			PositionChangedHandler(value, 0);
		});
		posYInput.onEndEdit.AddListener(delegate(string value)
		{
			PositionChangedHandler(value, 1);
		});
		posZInput.onEndEdit.AddListener(delegate(string value)
		{
			PositionChangedHandler(value, 2);
		});
		rotXInput.onEndEdit.AddListener(delegate(string value)
		{
			RotationChangedHandler(value, 0);
		});
		rotYInput.onEndEdit.AddListener(delegate(string value)
		{
			RotationChangedHandler(value, 1);
		});
		rotZInput.onEndEdit.AddListener(delegate(string value)
		{
			RotationChangedHandler(value, 2);
		});
		sclXInput.onEndEdit.AddListener(delegate(string value)
		{
			ScaleChangedHandler(value, 0);
		});
		sclYInput.onEndEdit.AddListener(delegate(string value)
		{
			ScaleChangedHandler(value, 1);
		});
		sclZInput.onEndEdit.AddListener(delegate(string value)
		{
			ScaleChangedHandler(value, 2);
		});
		affectedByPhysicsToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			AffectedByPhysicsHandler(isOn);
		});
		massInput.onEndEdit.AddListener(delegate(string value)
		{
			MassChangedHandler(value);
		});
		colorPicker.onValueChanged.AddListener(delegate(Color color)
		{
			ColorPickerChangedHandler(color);
		});
		ColorPicker obj = colorPicker;
		obj.OnValueDiscretChanged = (Action<Color, Color>)Delegate.Combine(obj.OnValueDiscretChanged, (Action<Color, Color>)delegate(Color odlColor, Color newColor)
		{
			ColorPickerDiscretChangedHandler(odlColor, newColor);
		});
		colorPresets.OnColorPresetChanged += delegate
		{
			NotifyChange("InspectorView.ColorPresetsChangedEvent");
		};
		gridRemoveToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			GridRemoveChangedHandler(isOn);
		});
		altTexOffsetToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			AltTexOffsetChangedHandler(isOn);
		});
		invertedLogicToggle.onValueChanged.AddListener(InvertedLogicToggleHandler);
		pressOnceToggle.onValueChanged.AddListener(PressOnceToggleHandler);
		logicPlugButton.onClick.AddListener(LogicPlugButtonHandler);
		logicUnplugButton.onClick.AddListener(LogicUnplugButtonHandler);
		spdXInput.onEndEdit.AddListener(delegate(string value)
		{
			RotatorSpeedChangedHandler(value, 0);
		});
		spdYInput.onEndEdit.AddListener(delegate(string value)
		{
			RotatorSpeedChangedHandler(value, 1);
		});
		spdZInput.onEndEdit.AddListener(delegate(string value)
		{
			RotatorSpeedChangedHandler(value, 2);
		});
		localSpaceToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			RotatorLocalSpaceChangedHandler(isOn);
		});
		Util.AddMouseUIEvent(colorPanel, EventTriggerType.PointerEnter, delegate(BaseEventData eventData)
		{
			ColorPanelPointerEnterHandler(eventData as PointerEventData);
		});
		Util.AddMouseUIEvent(colorPanel, EventTriggerType.PointerExit, delegate(BaseEventData eventData)
		{
			ColorPanelPointerExitHandler(eventData as PointerEventData);
		});
		Util.AddMouseOverUIEvents(mainPanel, base.OnMouseOverUIHandler);
	}

	public void SetLevelObjectView(LevelObjectView levelObjectView, bool shouldOnlyShowLogicPanel = false)
	{
		selectedLevelObjectView = levelObjectView;
		this.shouldOnlyShowLogicPanel = shouldOnlyShowLogicPanel;
		RefreshPanelData();
	}

	public void RefreshPanelData()
	{
		if (!(selectedLevelObjectView == null))
		{
			string id = "leveleditor.object.name." + selectedLevelObjectView.Name;
			string text = LanguagesManager.Instance.GetText(id, selectedLevelObjectView.Name);
			levelObjectNameText.SetText(text);
			transformPanel.SetActive(value: true);
			propertiesPanel.SetActive(value: true);
			UpdatePositionValues();
			UpdateRotationValues();
			UpdateScaleValues();
			UpdateAffectByPhysics();
			UpdateMassValue();
			UpdateColor();
			UpdateLogic();
			UpdateRotator();
			if (shouldOnlyShowLogicPanel)
			{
				transformPanel.SetActive(value: false);
				propertiesPanel.SetActive(value: false);
				colorPanel.SetActive(value: false);
			}
		}
	}

	public void UpdatePositionValues()
	{
		if (!(selectedLevelObjectView == null))
		{
			posXInput.text = selectedLevelObjectView.transform.position.x.ToString("0.####");
			posYInput.text = selectedLevelObjectView.transform.position.y.ToString("0.####");
			posZInput.text = selectedLevelObjectView.transform.position.z.ToString("0.####");
		}
	}

	public void UpdateRotationValues()
	{
		if (!(selectedLevelObjectView == null))
		{
			rotXInput.text = selectedLevelObjectView.transform.eulerAngles.x.ToString("0.####");
			rotYInput.text = selectedLevelObjectView.transform.eulerAngles.y.ToString("0.####");
			rotZInput.text = selectedLevelObjectView.transform.eulerAngles.z.ToString("0.####");
		}
	}

	public void UpdateScaleValues()
	{
		if (!(selectedLevelObjectView == null))
		{
			sclXInput.text = selectedLevelObjectView.LevelObjectScale.x.ToString("0.####");
			sclYInput.text = selectedLevelObjectView.LevelObjectScale.y.ToString("0.####");
			sclZInput.text = selectedLevelObjectView.LevelObjectScale.z.ToString("0.####");
			bool interactable = selectedLevelObjectView.LevelObjectType == LevelObjectType.Structure || selectedLevelObjectView.LevelObjectType == LevelObjectType.Active;
			sclXInput.interactable = interactable;
			sclYInput.interactable = interactable;
			sclZInput.interactable = interactable;
		}
	}

	private void PositionChangedHandler(string positionStr, int axis)
	{
		if (float.TryParse(positionStr, out var result))
		{
			float oldValue = 0f;
			switch (axis)
			{
			case 0:
				oldValue = selectedLevelObjectView.transform.position.x;
				selectedLevelObjectView.transform.SetPositionX(result);
				break;
			case 1:
				oldValue = selectedLevelObjectView.transform.position.y;
				selectedLevelObjectView.transform.SetPositionY(result);
				break;
			case 2:
				oldValue = selectedLevelObjectView.transform.position.z;
				selectedLevelObjectView.transform.SetPositionZ(result);
				break;
			}
			new TransformValueChangedAction(selectedLevelObjectView.transform, axis, oldValue, result).Execute();
			this.OnTransformChanged?.Invoke();
		}
		else
		{
			UpdatePositionValues();
		}
	}

	private void RotationChangedHandler(string rotationStr, int axis)
	{
		if (float.TryParse(rotationStr, out var result))
		{
			float oldValue = 0f;
			switch (axis)
			{
			case 0:
				oldValue = selectedLevelObjectView.transform.eulerAngles.x;
				selectedLevelObjectView.transform.SetEulerRotationX(result);
				break;
			case 1:
				oldValue = selectedLevelObjectView.transform.eulerAngles.y;
				selectedLevelObjectView.transform.SetEulerRotationY(result);
				break;
			case 2:
				oldValue = selectedLevelObjectView.transform.eulerAngles.z;
				selectedLevelObjectView.transform.SetEulerRotationZ(result);
				break;
			}
			new TransformValueChangedAction(selectedLevelObjectView.transform, axis + 3, oldValue, result).Execute();
			this.OnTransformChanged?.Invoke();
		}
		else
		{
			UpdateRotationValues();
		}
	}

	private void ScaleChangedHandler(string scaleStr, int axis)
	{
		if (float.TryParse(scaleStr, out var result))
		{
			if (result <= 0f)
			{
				UpdateScaleValues();
				return;
			}
			float oldValue = 0f;
			switch (axis)
			{
			case 0:
			{
				Vector3 levelObjectScale = new Vector3(result, selectedLevelObjectView.LevelObjectScale.y, selectedLevelObjectView.LevelObjectScale.z);
				oldValue = selectedLevelObjectView.LevelObjectScale.x;
				selectedLevelObjectView.LevelObjectScale = levelObjectScale;
				break;
			}
			case 1:
			{
				Vector3 levelObjectScale = new Vector3(selectedLevelObjectView.LevelObjectScale.x, result, selectedLevelObjectView.LevelObjectScale.z);
				oldValue = selectedLevelObjectView.LevelObjectScale.y;
				selectedLevelObjectView.LevelObjectScale = levelObjectScale;
				break;
			}
			case 2:
			{
				Vector3 levelObjectScale = new Vector3(selectedLevelObjectView.LevelObjectScale.x, selectedLevelObjectView.LevelObjectScale.y, result);
				oldValue = selectedLevelObjectView.LevelObjectScale.z;
				selectedLevelObjectView.LevelObjectScale = levelObjectScale;
				break;
			}
			}
			new TransformValueChangedAction(selectedLevelObjectView.transform, axis + 6, oldValue, result).Execute();
			this.OnTransformChanged?.Invoke();
		}
		else
		{
			UpdateScaleValues();
		}
	}

	private void UpdateAffectByPhysics()
	{
		if (!(selectedLevelObjectView == null))
		{
			affectedByPhysicsToggle.SetValue(selectedLevelObjectView.IsAffectedByPhysics);
			affectedByPhysicsToggle.interactable = selectedLevelObjectView.LevelObjectType == LevelObjectType.Structure;
		}
	}

	private void AffectedByPhysicsHandler(bool isOn)
	{
		if (!(selectedLevelObjectView == null))
		{
			bool isAffectedByPhysics = selectedLevelObjectView.IsAffectedByPhysics;
			selectedLevelObjectView.IsAffectedByPhysics = isOn;
			float mass = selectedLevelObjectView.Mass;
			new LevelObjectPhysicsChangedAction(selectedLevelObjectView, isAffectedByPhysics, isOn, mass, mass).Execute();
			UpdateMassValue();
		}
	}

	private void UpdateMassValue()
	{
		if (!(selectedLevelObjectView == null))
		{
			massInput.text = selectedLevelObjectView.Mass.ToString();
			massInput.interactable = selectedLevelObjectView.LevelObjectType == LevelObjectType.Structure && affectedByPhysicsToggle.isOn;
		}
	}

	private void MassChangedHandler(string massStr)
	{
		if (float.TryParse(massStr, out var result))
		{
			if (result >= 0.1f)
			{
				float mass = selectedLevelObjectView.Mass;
				selectedLevelObjectView.Mass = result;
				bool isAffectedByPhysics = selectedLevelObjectView.IsAffectedByPhysics;
				new LevelObjectPhysicsChangedAction(selectedLevelObjectView, isAffectedByPhysics, isAffectedByPhysics, mass, result).Execute();
			}
			else
			{
				UpdateMassValue();
			}
		}
		else
		{
			UpdateMassValue();
		}
	}

	private void UpdateColor()
	{
		if (!(selectedLevelObjectView == null))
		{
			if (selectedLevelObjectView.LevelObjectType != LevelObjectType.Structure && selectedLevelObjectView.LevelObjectType != LevelObjectType.Active)
			{
				colorPanel.SetActive(value: false);
				return;
			}
			colorPanel.SetActive(value: true);
			colorPicker.CurrentColor = selectedLevelObjectView.GetColor();
			gridRemoveToggle.SetValue(!selectedLevelObjectView.IsWithGrid);
			altTexOffsetToggle.SetValue(selectedLevelObjectView.IsAltTexOffset);
			altTexOffsetToggle.interactable = selectedLevelObjectView.IsWithGrid;
		}
	}

	private void ColorPickerDiscretChangedHandler(Color oldColor, Color newColor)
	{
		if (!(selectedLevelObjectView == null))
		{
			bool isWithGrid = selectedLevelObjectView.IsWithGrid;
			bool isAltTexOffset = selectedLevelObjectView.IsAltTexOffset;
			new LevelObjectColorChangedAction(selectedLevelObjectView, oldColor, newColor, isWithGrid, isWithGrid, isAltTexOffset, isAltTexOffset).Execute();
		}
	}

	private void ColorPickerChangedHandler(Color color)
	{
		if (!(selectedLevelObjectView == null))
		{
			selectedLevelObjectView.SetColor(color);
		}
	}

	private void ColorPanelPointerEnterHandler(PointerEventData eventData)
	{
		selectedLevelObjectView.SetOutline(isEnabled: false);
	}

	private void ColorPanelPointerExitHandler(PointerEventData eventData)
	{
		selectedLevelObjectView.SetOutline(isEnabled: true);
	}

	private void GridRemoveChangedHandler(bool isOn)
	{
		if (!(selectedLevelObjectView == null))
		{
			bool isWithGrid = selectedLevelObjectView.IsWithGrid;
			selectedLevelObjectView.SetGridOnTexture(!isOn);
			altTexOffsetToggle.interactable = !isOn;
			Color color = selectedLevelObjectView.GetColor();
			bool isAltTexOffset = selectedLevelObjectView.IsAltTexOffset;
			new LevelObjectColorChangedAction(selectedLevelObjectView, color, color, isWithGrid, !isOn, isAltTexOffset, isAltTexOffset).Execute();
		}
	}

	private void AltTexOffsetChangedHandler(bool isOn)
	{
		if (!(selectedLevelObjectView == null))
		{
			bool isAltTexOffset = selectedLevelObjectView.IsAltTexOffset;
			selectedLevelObjectView.IsAltTexOffset = isOn;
			Color color = selectedLevelObjectView.GetColor();
			bool isWithGrid = selectedLevelObjectView.IsWithGrid;
			new LevelObjectColorChangedAction(selectedLevelObjectView, color, color, isWithGrid, isWithGrid, isAltTexOffset, isOn).Execute();
		}
	}

	private void UpdateLogic()
	{
		if (selectedLevelObjectView == null)
		{
			return;
		}
		if (selectedLevelObjectView.LogicType != LevelObjectLogicType.Input)
		{
			logicPanel.SetActive(value: false);
			return;
		}
		logicPanel.SetActive(value: true);
		invertedLogicToggle.SetValue(selectedLevelObjectView.IsInvertedLogic);
		pressOnceToggle.SetValue(selectedLevelObjectView.IsPressOnce);
		if (selectedLevelObjectView.LevelObjectViewOutput != null)
		{
			string text = selectedLevelObjectView.LevelObjectViewOutput.Name;
			string text2 = LanguagesManager.Instance.GetText("leveleditor.object.name." + text, text);
			outputText.color = Util.HexToColor("#49D949FF");
			outputText.SetText(text2);
			logicUnplugButton.interactable = true;
		}
		else
		{
			string text3 = LanguagesManager.Instance.GetText("label.text.leveleditor.notplugged", "Nothing plugged!");
			outputText.color = Util.HexToColor("#EC5C5CFF");
			outputText.SetText(text3);
			logicUnplugButton.interactable = false;
		}
	}

	private void UpdateRotator()
	{
		if (!(selectedLevelObjectView == null))
		{
			if (selectedLevelObjectView.LevelObjectType != LevelObjectType.Structure)
			{
				rotatorPanel.SetActive(value: false);
				return;
			}
			rotatorPanel.SetActive(value: true);
			spdXInput.text = selectedLevelObjectView.RotatorSpeed.x.ToString("0.####");
			spdYInput.text = selectedLevelObjectView.RotatorSpeed.y.ToString("0.####");
			spdZInput.text = selectedLevelObjectView.RotatorSpeed.z.ToString("0.####");
			localSpaceToggle.SetValue(selectedLevelObjectView.IsLocalSpaceRotator);
		}
	}

	private void InvertedLogicToggleHandler(bool isOn)
	{
		bool isInvertedLogic = selectedLevelObjectView.IsInvertedLogic;
		selectedLevelObjectView.IsInvertedLogic = isOn;
		bool isPressOnce = selectedLevelObjectView.IsPressOnce;
		new LevelObjectLogicChangedAction(selectedLevelObjectView, isInvertedLogic, isOn, isPressOnce, isPressOnce).Execute();
	}

	private void PressOnceToggleHandler(bool isOn)
	{
		bool isPressOnce = selectedLevelObjectView.IsPressOnce;
		selectedLevelObjectView.IsPressOnce = isOn;
		bool isInvertedLogic = selectedLevelObjectView.IsInvertedLogic;
		new LevelObjectLogicChangedAction(selectedLevelObjectView, isInvertedLogic, isInvertedLogic, isPressOnce, isOn).Execute();
	}

	private void LogicPlugButtonHandler()
	{
		this.OnPickingUpOutputForInput?.Invoke();
	}

	private void LogicUnplugButtonHandler()
	{
		LevelObjectView levelObjectViewOutput = selectedLevelObjectView.LevelObjectViewOutput;
		selectedLevelObjectView.LevelObjectViewOutput = null;
		new LevelObjectLogicPlugedAction(selectedLevelObjectView, null, levelObjectViewOutput).Execute();
		UpdateLogic();
	}

	private void RotatorSpeedChangedHandler(string rotationStr, int axis)
	{
		if (float.TryParse(rotationStr, out var result))
		{
			switch (axis)
			{
			case 0:
				selectedLevelObjectView.RotatorSpeed = selectedLevelObjectView.RotatorSpeed.WithChange(result);
				break;
			case 1:
				selectedLevelObjectView.RotatorSpeed = selectedLevelObjectView.RotatorSpeed.WithChange(null, result);
				break;
			case 2:
				selectedLevelObjectView.RotatorSpeed = selectedLevelObjectView.RotatorSpeed.WithChange(null, null, result);
				break;
			}
		}
		else
		{
			UpdateRotator();
		}
	}

	private void RotatorLocalSpaceChangedHandler(bool isLocalSpace)
	{
		selectedLevelObjectView.IsLocalSpaceRotator = isLocalSpace;
	}

	public void SetLogicOutputForInput(LevelObjectView outputLevelObjectView)
	{
		selectedLevelObjectView.LevelObjectViewOutput = outputLevelObjectView;
		UpdateLogic();
	}

	public LevelObjectView GetSelectedLevelObjectView()
	{
		return selectedLevelObjectView;
	}

	public void SetColorPresets(Color[] colors)
	{
		colorPresets.SetColorPresets(colors);
	}

	public Color[] GetColorPresets()
	{
		return colorPresets.GetColorPresets();
	}
}
