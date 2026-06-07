using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuickKeysGroup : MonoBehaviour, IRecyclableObject
{
	private const string LabelSeparator = " - ";

	private Image headerBackgroundImage;

	private KeyAssignment parentKeyAssignment;

	private Button expandButton;

	private TextMeshProUGUI expandButtonLabel;

	private Button eraseCustomLabelButton;

	private Button editCustomLabelButton;

	private TMP_InputField customLabelInput;

	private GameObject quickKeySlotsFolder;

	private string lastLabel;

	private bool isAxisEnabled;

	private List<QuickKeySlot> quickKeySlots;

	public int QuickKeySlotsCount => quickKeySlots.Count;

	public string KeyMapId { get; set; }

	public bool IsCustomLabel { get; private set; }

	public string ObjectTypeId { get; set; }

	public event Action<QuickKeysGroup, QuickKeySlot> OnKeySlotAssigned;

	public event Action OnKeyBeginingAssignment;

	public event Action OnKeyEndingAssignment;

	public event Action<string, string> OnKeyChangedAndCustomLabel;

	public event Action<string> OnEraseCustomLabel;

	public event Action<string> OnBeginingEditCustomLabel;

	public event Action<string, string> OnEndingEditCustomLabel;

	private void Awake()
	{
		headerBackgroundImage = base.transform.FindComponent<Image>("ParentKeyHeader", isRecursively: true);
		headerBackgroundImage.color = headerBackgroundImage.color.WithChange(null, null, null, 0.3f);
		parentKeyAssignment = base.transform.FindComponent<KeyAssignment>("ParentKeyAssignment", isRecursively: true);
		expandButton = base.transform.FindComponent<Button>("ExpandButton", isRecursively: true);
		expandButtonLabel = expandButton.transform.FindComponent<TextMeshProUGUI>("Text", isRecursively: true);
		eraseCustomLabelButton = base.transform.FindComponent<Button>("EraseCustomLabelButton", isRecursively: true);
		editCustomLabelButton = base.transform.FindComponent<Button>("EditCustomLabelButton", isRecursively: true);
		customLabelInput = base.transform.FindComponent<TMP_InputField>("CustomLabelInput", isRecursively: true);
		quickKeySlotsFolder = base.transform.FindChildRecursively("QuickKeySlotsFolder").gameObject;
		quickKeySlotsFolder.transform.RemoveAllChildren();
		quickKeySlotsFolder.SetActive(value: false);
		expandButton.onClick.AddListener(ExpandButtonClickHandler);
		eraseCustomLabelButton.onClick.AddListener(EraseCustomLabelButtonHandler);
		editCustomLabelButton.onClick.AddListener(EditCustomLabelButtonHandler);
		customLabelInput.onEndEdit.AddListener(CustomLabelInputHandler);
		parentKeyAssignment.OnKeyAssignment += ParentKeyAssignedHandler;
		parentKeyAssignment.OnKeyBeginingAssigment += delegate
		{
			this.OnKeyBeginingAssignment?.Invoke();
		};
		parentKeyAssignment.OnKeyEndingAssigment += delegate
		{
			this.OnKeyEndingAssignment?.Invoke();
		};
		lastLabel = "";
		IsCustomLabel = false;
		quickKeySlots = new List<QuickKeySlot>();
		ComponentEventTrigger componentEventTrigger = base.transform.FindComponent<ComponentEventTrigger>("ParentKeyHeader", isRecursively: true);
		componentEventTrigger.OnPointerEnterEvent += OnPointerEnterHandler;
		componentEventTrigger.OnPointerExitEvent += OnPointerExitHandler;
	}

	private void Update()
	{
		if (headerBackgroundImage.color.a > 0f)
		{
			float value = headerBackgroundImage.color.a - Time.deltaTime;
			headerBackgroundImage.color = headerBackgroundImage.color.WithChange(null, null, null, value);
		}
	}

	private void OnDestroy()
	{
		SetBlocksOutlineVisibility(isVisible: false);
	}

	public void BlinkGroup()
	{
		headerBackgroundImage.color = headerBackgroundImage.color.WithChange(null, null, null, 0.3f);
	}

	public void SetParentKeyAssignmentValue(KeyCode key, AxisCode axis, bool isAxisSensitive, bool isControlledByLogic)
	{
		parentKeyAssignment.SetKey(key, axis);
		parentKeyAssignment.IsAxisSensitive = isAxisSensitive;
		parentKeyAssignment.IsKeyControlledByLogic = isControlledByLogic;
	}

	public void SetCustomLabel(string label)
	{
		parentKeyAssignment.SetLabel(label);
		eraseCustomLabelButton.interactable = true;
		IsCustomLabel = true;
	}

	public void SetAxisEnabled(bool isEnabled)
	{
		isAxisEnabled = isEnabled;
		parentKeyAssignment.IsAxisEnabled = isEnabled;
	}

	public void AddQuickKeySlot(DefaultKeyIO defaultKeyIO)
	{
		string text = LanguagesManager.Instance.GetText(defaultKeyIO.ParentBlockBodyModel.ParentBlockModel.Schematic.Name);
		string text2 = LanguagesManager.Instance.GetText(defaultKeyIO.BaseName);
		string currentLabel = text + " - " + text2;
		UpdateGroupLabel(currentLabel, text, text2);
		QuickKeySlot component = ObjectPools.Instance.GetInstanceForUI("quick_key_slot", quickKeySlotsFolder.transform).GetComponent<QuickKeySlot>();
		component.Initialize(defaultKeyIO);
		component.SetAxisEnabled(isAxisEnabled);
		component.OnKeyAssigned += KeySlotAssignedHandler;
		component.OnKeyBeginingAssignment += delegate
		{
			this.OnKeyBeginingAssignment?.Invoke();
		};
		component.OnKeyEndingAssignment += delegate
		{
			this.OnKeyEndingAssignment?.Invoke();
		};
		quickKeySlots.Add(component);
		expandButton.interactable = quickKeySlots.Count > 1;
		if (parentKeyAssignment.IsAxisSensitive != defaultKeyIO.IsAxisSensitive)
		{
			parentKeyAssignment.IsAxisSensitive = false;
		}
		if (parentKeyAssignment.IsKeyControlledByLogic != defaultKeyIO.IsAttachedInWritableSocketIO())
		{
			parentKeyAssignment.IsKeyControlledByLogic = false;
		}
	}

	private void UpdateGroupLabel(string currentLabel, string blockName, string componentKeyLabel)
	{
		if (currentLabel != lastLabel)
		{
			string[] array = lastLabel.Split(new string[1] { " - " }, StringSplitOptions.None);
			if (array.Length == 2)
			{
				string text = array[0];
				string obj = array[1];
				string text2 = LanguagesManager.Instance.GetText("label.text.keylist.mixed", "Mixed");
				if (text != blockName)
				{
					blockName = text2;
				}
				if (obj != componentKeyLabel)
				{
					componentKeyLabel = text2;
				}
				currentLabel = blockName + " - " + componentKeyLabel;
			}
			parentKeyAssignment.SetLabel(currentLabel);
		}
		lastLabel = currentLabel;
	}

	public void RegenerateGroupLabel()
	{
		lastLabel = "";
		bool flag = quickKeySlots[0].DefaultKeyIO.IsAxisSensitive;
		foreach (QuickKeySlot quickKeySlot in quickKeySlots)
		{
			string text = LanguagesManager.Instance.GetText(quickKeySlot.DefaultKeyIO.ParentBlockBodyModel.ParentBlockModel.Schematic.Name);
			string text2 = LanguagesManager.Instance.GetText(quickKeySlot.DefaultKeyIO.BaseName);
			string currentLabel = text + " - " + text2;
			UpdateGroupLabel(currentLabel, text, text2);
			if (flag != quickKeySlot.DefaultKeyIO.IsAxisSensitive)
			{
				flag = false;
			}
		}
		if (quickKeySlots.Count <= 1)
		{
			quickKeySlotsFolder.SetActive(value: false);
		}
		expandButton.interactable = quickKeySlots.Count > 1;
		expandButtonLabel.SetText(quickKeySlotsFolder.activeSelf ? "\uf146" : "\uf0fe");
		parentKeyAssignment.IsAxisSensitive = flag;
	}

	public void RemoveQuickKeySlot(QuickKeySlot quickKeySlot)
	{
		quickKeySlots.Remove(quickKeySlot);
	}

	public ICollection GetAllQuickKeySlots()
	{
		return quickKeySlots;
	}

	private void ParentKeyAssignedHandler(KeyCode key, AxisCode axis)
	{
		QuickKeySlot[] array = quickKeySlots.ToArray();
		if (IsCustomLabel)
		{
			this.OnKeyChangedAndCustomLabel?.Invoke(Util.GetInputKeyId(key, axis), parentKeyAssignment.GetLabel());
		}
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetCurrentKey(key, axis);
			this.OnKeySlotAssigned?.Invoke(this, array[i]);
		}
	}

	private void KeySlotAssignedHandler(QuickKeySlot quickKeySlot)
	{
		this.OnKeySlotAssigned?.Invoke(this, quickKeySlot);
	}

	private void ExpandButtonClickHandler()
	{
		quickKeySlotsFolder.SetActive(!quickKeySlotsFolder.activeSelf);
		expandButtonLabel.SetText(quickKeySlotsFolder.activeSelf ? "\uf146" : "\uf0fe");
	}

	private void EditCustomLabelButtonHandler()
	{
		editCustomLabelButton.interactable = false;
		customLabelInput.gameObject.SetActive(value: true);
		customLabelInput.SetTextWithoutNotify(parentKeyAssignment.GetLabel());
		customLabelInput.Select();
		customLabelInput.ActivateInputField();
		this.OnBeginingEditCustomLabel?.Invoke(KeyMapId);
	}

	private void EraseCustomLabelButtonHandler()
	{
		eraseCustomLabelButton.interactable = false;
		RegenerateGroupLabel();
		IsCustomLabel = false;
		this.OnEraseCustomLabel?.Invoke(KeyMapId);
	}

	private void CustomLabelInputHandler(string customLabel)
	{
		if (customLabel == lastLabel || string.IsNullOrEmpty(customLabel))
		{
			editCustomLabelButton.interactable = true;
			customLabelInput.gameObject.SetActive(value: false);
			this.OnEndingEditCustomLabel?.Invoke(KeyMapId, "");
			return;
		}
		eraseCustomLabelButton.interactable = true;
		editCustomLabelButton.interactable = true;
		customLabelInput.gameObject.SetActive(value: false);
		parentKeyAssignment.SetLabel(customLabel);
		IsCustomLabel = true;
		this.OnEndingEditCustomLabel?.Invoke(KeyMapId, customLabel);
	}

	private void OnPointerEnterHandler(BaseEventData eventData)
	{
		SetBlocksOutlineVisibility(isVisible: true);
	}

	private void OnPointerExitHandler(BaseEventData eventData)
	{
		SetBlocksOutlineVisibility(isVisible: false);
	}

	private void SetBlocksOutlineVisibility(bool isVisible)
	{
		for (int i = 0; i < quickKeySlots.Count; i++)
		{
			quickKeySlots[i].SetBlockOutlineVisibility(isVisible);
		}
	}

	public void RefreshKeyControlledByLogicIcon()
	{
		bool isKeyControlledByLogic = true;
		foreach (QuickKeySlot quickKeySlot in quickKeySlots)
		{
			if (!quickKeySlot.RefreshKeyControlledByLogic())
			{
				isKeyControlledByLogic = false;
			}
		}
		parentKeyAssignment.IsKeyControlledByLogic = isKeyControlledByLogic;
	}

	public void OnInstantiation()
	{
		headerBackgroundImage.color = headerBackgroundImage.color.WithChange(null, null, null, 0.3f);
	}

	public void OnUnistantiation()
	{
		this.OnKeySlotAssigned = null;
		this.OnKeyBeginingAssignment = null;
		this.OnKeyEndingAssignment = null;
		this.OnKeyChangedAndCustomLabel = null;
		this.OnEraseCustomLabel = null;
		this.OnBeginingEditCustomLabel = null;
		this.OnEndingEditCustomLabel = null;
		eraseCustomLabelButton.interactable = false;
		editCustomLabelButton.interactable = true;
		customLabelInput.gameObject.SetActive(value: false);
		SetBlocksOutlineVisibility(isVisible: false);
		lastLabel = "";
		KeyMapId = "";
		IsCustomLabel = false;
		quickKeySlots.Clear();
		quickKeySlotsFolder.transform.RemoveAllChildren();
	}
}
