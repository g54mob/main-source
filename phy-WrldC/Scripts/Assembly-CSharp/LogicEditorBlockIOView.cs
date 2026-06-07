using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicEditorBlockIOView
{
	private LogicEditorView logicEditorView;

	private GameObject iosPanel;

	private GameObject defaultKeyPanel;

	private GameObject descriptionPanel;

	private TextMeshProUGUI headerText;

	private ToggleGroup iosToggleGroup;

	private KeyAssignment defaultKeyAssignment;

	private Button removeKeyButton;

	private Button descriptionHideButton;

	private TextMeshProUGUI descriptionHideButtonIcon;

	private TextMeshProUGUI descriptionText;

	private Button3D currentButton3D;

	public GameObject MainPanel { get; private set; }

	public LogicIO SelectedLogicIO { get; private set; }

	public LogicEditorBlockIOView(LogicEditorView logicEditorView)
	{
		LogicEditorBlockIOView logicEditorBlockIOView = this;
		this.logicEditorView = logicEditorView;
		MainPanel = logicEditorView.mainPanel.transform.Find("BlockIOPanel").gameObject;
		iosPanel = MainPanel.transform.FindChildRecursively("IOsPanel").gameObject;
		defaultKeyPanel = MainPanel.transform.FindChildRecursively("DefaultKeyPanel").gameObject;
		descriptionPanel = MainPanel.transform.FindChildRecursively("DescriptionPanel").gameObject;
		headerText = MainPanel.transform.FindComponent<TextMeshProUGUI>("HeaderText", isRecursively: true);
		iosToggleGroup = iosPanel.GetComponent<ToggleGroup>();
		defaultKeyAssignment = defaultKeyPanel.transform.FindComponent<KeyAssignment>("DefaultKeyAssignment", isRecursively: true);
		removeKeyButton = defaultKeyPanel.transform.FindComponent<Button>("RemoveKeyButton", isRecursively: true);
		descriptionHideButton = descriptionPanel.transform.FindComponent<Button>("DescriptionHideButton", isRecursively: true);
		descriptionHideButtonIcon = descriptionHideButton.GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
		descriptionText = descriptionPanel.transform.FindComponent<TextMeshProUGUI>("DescriptionText", isRecursively: true);
		descriptionHideButton.onClick.AddListener(delegate
		{
			logicEditorBlockIOView.DescriptionHideButtonHandler();
		});
		defaultKeyAssignment.OnKeyBeginingAssigment += delegate
		{
			logicEditorView.SetKeyboardInUse(isKeyboardInUse: true);
		};
		defaultKeyAssignment.OnKeyEndingAssigment += delegate
		{
			logicEditorView.SetKeyboardInUse(isKeyboardInUse: false);
		};
		MainPanel.SetActive(value: false);
		defaultKeyPanel.SetActive(value: false);
		descriptionText.gameObject.SetActive(value: false);
	}

	private void DescriptionHideButtonHandler()
	{
		descriptionText.gameObject.SetActive(!descriptionText.gameObject.activeSelf);
		descriptionHideButtonIcon.SetText(descriptionText.gameObject.activeSelf ? "\uf056" : "\uf055");
	}

	public void OnBlockSelected(Button3D button3D)
	{
		MainPanel.SetActive(value: true);
		defaultKeyPanel.SetActive(value: false);
		SelectedLogicIO = null;
		iosPanel.transform.RemoveAllChildren();
		BlockModel blockModel;
		LogicIOPlace logicIOPlace;
		if (button3D is BlockBodyModelButton3D blockBodyModelButton3D)
		{
			blockModel = blockBodyModelButton3D.BlockModel;
			headerText.SetText(blockModel.Schematic.Name + " IOs");
			logicIOPlace = LogicIOPlace.Component;
		}
		else
		{
			if (!(button3D is HingeJointButton3D hingeJointButton3D))
			{
				return;
			}
			blockModel = hingeJointButton3D.HingeJointModel.ParentBlockBodyModel.ParentBlockModel;
			string text = string.Empty;
			if (hingeJointButton3D.HingeJointModel.MotorJointModel != null)
			{
				text = LanguagesManager.Instance.GetText("label.text.transmission.continuous", "Continuous Spin");
			}
			else if (hingeJointButton3D.HingeJointModel.SteerableJointModel != null)
			{
				text = LanguagesManager.Instance.GetText("label.text.transmission.steerable", "Steerable Spin");
			}
			else if (hingeJointButton3D.HingeJointModel.StepperJointModel != null)
			{
				text = LanguagesManager.Instance.GetText("label.text.transmission.stepper", "Stepper Spin");
			}
			headerText.SetText(text + " IOs");
			logicIOPlace = LogicIOPlace.HingeJoint;
		}
		CreationView view = GameManager.Instance.MainCreationController.view;
		foreach (BlockBodyModel allBlockBodyModel in blockModel.GetAllBlockBodyModels())
		{
			foreach (LogicIO allLogicIO in view.GetBlockBodyView(allBlockBodyModel).GetAllLogicIOs())
			{
				if (allLogicIO.Place == logicIOPlace)
				{
					if (allLogicIO.Direction == LogicIODirection.Input)
					{
						AddInputSlot(allLogicIO);
					}
					else if (allLogicIO.Direction == LogicIODirection.Output)
					{
						AddOutputSlot(allLogicIO);
					}
				}
			}
		}
		if (button3D != currentButton3D)
		{
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(GameManager.Instance.GameStylesData.blockSelected, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
		currentButton3D = button3D;
	}

	public void OnBlockDeselected()
	{
		MainPanel.SetActive(value: false);
		defaultKeyPanel.SetActive(value: false);
		SelectedLogicIO = null;
	}

	private void AddInputSlot(LogicIO input)
	{
		GameObject gameObject = Util.InstantiateForGUI(logicEditorView.blockInputSlotPrefab, iosPanel.transform, "InputSlot_" + input.Name);
		gameObject.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true).SetText(LanguagesManager.Instance.GetText(input.Name, input.Name));
		gameObject.transform.FindComponent<TextMeshProUGUI>("KeyIcon", isRecursively: true).gameObject.SetActive(!input.IsInputWithoutKey);
		NormalTooltipTrigger component = gameObject.GetComponent<NormalTooltipTrigger>();
		component.IsActivated = LanguagesManager.Instance.HasText("tooltip." + input.Name);
		component.HelpText = LanguagesManager.Instance.GetText("tooltip." + input.Name);
		if (!input.IsInputWithoutKey && !component.IsActivated)
		{
			component.IsActivated = true;
			component.HelpText = LanguagesManager.Instance.GetText("tooltip.default_key_input");
		}
		Toggle component2 = gameObject.GetComponent<Toggle>();
		component2.group = iosToggleGroup;
		component2.isOn = false;
		component2.onValueChanged.AddListener(delegate(bool isOn)
		{
			ChangeLogicIOSlotHandler(isOn, input);
		});
	}

	private void AddOutputSlot(LogicIO output)
	{
		GameObject gameObject = Util.InstantiateForGUI(logicEditorView.blockOutputSlotPrefab, iosPanel.transform, "OutputSlot_" + output.Name);
		gameObject.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true).SetText(LanguagesManager.Instance.GetText(output.Name, output.Name));
		NormalTooltipTrigger component = gameObject.GetComponent<NormalTooltipTrigger>();
		component.IsActivated = LanguagesManager.Instance.HasText("tooltip." + output.Name);
		component.HelpText = LanguagesManager.Instance.GetText("tooltip." + output.Name);
		Toggle component2 = gameObject.GetComponent<Toggle>();
		component2.group = iosToggleGroup;
		component2.isOn = false;
		component2.onValueChanged.AddListener(delegate(bool isOn)
		{
			ChangeLogicIOSlotHandler(isOn, output);
		});
	}

	private void ChangeLogicIOSlotHandler(bool isOn, LogicIO selectedLogicIO)
	{
		if (!isOn)
		{
			return;
		}
		SelectedLogicIO = selectedLogicIO;
		if (selectedLogicIO.Direction == LogicIODirection.Input && !selectedLogicIO.IsInputWithoutKey)
		{
			defaultKeyPanel.SetActive(value: true);
			defaultKeyAssignment.RemoveAllListeners();
			defaultKeyAssignment.SetKey(selectedLogicIO.DefaultKey, selectedLogicIO.DefaultAxis);
			defaultKeyAssignment.IsAxisEnabled = !GameManager.Instance.OptionsModel.IsJoystickAxesDisabled;
			defaultKeyAssignment.IsKeyControlledByLogic = selectedLogicIO.HasWritableAndActiveSocketIOs();
			defaultKeyAssignment.AddListener(delegate(KeyCode key, AxisCode axis)
			{
				DefaultKeyAssignmentHandler(key, selectedLogicIO);
			});
			removeKeyButton.onClick.RemoveAllListeners();
			removeKeyButton.onClick.AddListener(delegate
			{
				RemoveKeyButtonHandler(selectedLogicIO, defaultKeyAssignment);
			});
		}
		else
		{
			defaultKeyPanel.SetActive(value: false);
		}
		if (LanguagesManager.Instance.HasText("tooltip." + selectedLogicIO.Name))
		{
			descriptionPanel.SetActive(value: true);
			descriptionText.SetText(LanguagesManager.Instance.GetText("tooltip." + selectedLogicIO.Name));
		}
		else if (selectedLogicIO.Direction == LogicIODirection.Input && !selectedLogicIO.IsInputWithoutKey)
		{
			descriptionPanel.SetActive(value: true);
			descriptionText.SetText(LanguagesManager.Instance.GetText("tooltip.default_key_input"));
		}
		else
		{
			descriptionPanel.SetActive(value: false);
		}
	}

	private void DefaultKeyAssignmentHandler(KeyCode key, LogicIO logicIO)
	{
		logicIO.DefaultKey = key;
		logicEditorView.UpdateIODefaultKeyHandler(logicIO);
	}

	private void RemoveKeyButtonHandler(LogicIO logicIO, KeyAssignment keyAssignment)
	{
		logicIO.DefaultKey = KeyCode.None;
		keyAssignment.SetKey(KeyCode.None);
		logicEditorView.UpdateIODefaultKeyHandler(logicIO);
	}
}
