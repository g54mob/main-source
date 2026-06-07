using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickKeysView : BaseGUIPanelView
{
	public const string KeyAssignedEvent = "QuickKeysView.KeyAssignedEvent";

	public const string KeysGroupLabelErasedEvent = "QuickKeysView.KeysGroupLabelErasedEvent";

	public const string KeysGroupLabelChangedEvent = "QuickKeysView.KeysGroupLabelChangedEvent";

	public const string KeysGroupLabelRefreshEvent = "QuickKeysView.KeysGroupLabelRefreshEvent";

	public const string IsKeyboardInUsingEvent = "QuickKeysView.IsKeyboardInUsingEvent";

	public const string CloseButtonEvent = "QuickKeysView.CloseButtonEvent";

	public const string MouseOverUIEvent = "QuickKeysView.MouseOverUIEvent";

	private GameObject quickKeysGroupFolder;

	private Button closeButton;

	private GameObject noKeysTextPrefab;

	private Dictionary<string, QuickKeysGroup> quickKeysGroupMap;

	private bool isMouseOverUI;

	public ConstructionToolsView ConstructionToolsView { get; private set; }

	public QuickKeysView(TopButtonsView topButtonsView, ConstructionToolsView constructionToolsView)
	{
		noKeysTextPrefab = topButtonsView.noKeysTextPrefab;
		base.MainPanel = topButtonsView.mainPanel.transform.FindChildRecursively("QuickKeysWindow").gameObject;
		ConstructionToolsView = constructionToolsView;
		quickKeysGroupFolder = base.MainPanel.transform.FindChildRecursively("QuickKeysGroupFolder").gameObject;
		closeButton = base.MainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("QuickKeysView.CloseButtonEvent");
		});
		quickKeysGroupMap = new Dictionary<string, QuickKeysGroup>();
		isMouseOverUI = false;
		KeyListScrollView keyListScrollView = base.MainPanel.GetComponent<KeyListScrollView>();
		keyListScrollView.OnChangedScrollActivation += delegate(bool isScrollActive)
		{
			NotifyChange("QuickKeysView.MouseOverUIEvent", isMouseOverUI, isScrollActive);
		};
		ComponentEventTrigger componentEventTrigger = base.MainPanel.transform.FindComponent<ComponentEventTrigger>("ScrollView", isRecursively: true);
		componentEventTrigger.OnPointerEnterEvent += delegate
		{
			MouseOverUIHandler(isMouseOverUI: true, keyListScrollView.IsScrollActive);
		};
		componentEventTrigger.OnPointerExitEvent += delegate
		{
			MouseOverUIHandler(isMouseOverUI: false, keyListScrollView.IsScrollActive);
		};
	}

	private void MouseOverUIHandler(bool isMouseOverUI, bool isScrollActive)
	{
		this.isMouseOverUI = isMouseOverUI;
		NotifyChange("QuickKeysView.MouseOverUIEvent", isMouseOverUI, isScrollActive);
	}

	public void ClearAllKeyGroups()
	{
		foreach (QuickKeysGroup value in quickKeysGroupMap.Values)
		{
			foreach (QuickKeySlot allQuickKeySlot in value.GetAllQuickKeySlots())
			{
				ObjectPools.Instance.ReturnInstance(allQuickKeySlot.gameObject);
			}
			ObjectPools.Instance.ReturnInstance(value.gameObject);
		}
		quickKeysGroupMap.Clear();
		quickKeysGroupFolder.transform.RemoveAllChildren();
	}

	public void AddNewKeySlot(DefaultKeyIO defaultKeyIO, int siblingIndex = -1)
	{
		string inputKeyId = Util.GetInputKeyId(defaultKeyIO.KeyValue, defaultKeyIO.AxisValue);
		if (!quickKeysGroupMap.ContainsKey(inputKeyId))
		{
			GameObject instanceForUI = ObjectPools.Instance.GetInstanceForUI("quick_keys_group", quickKeysGroupFolder.transform);
			instanceForUI.name = inputKeyId + "_QuickKeysGroup";
			if (siblingIndex >= 0)
			{
				instanceForUI.transform.SetSiblingIndex(siblingIndex);
			}
			QuickKeysGroup component = instanceForUI.GetComponent<QuickKeysGroup>();
			component.SetAxisEnabled(!GameManager.Instance.OptionsModel.IsJoystickAxesDisabled);
			component.KeyMapId = inputKeyId;
			component.SetParentKeyAssignmentValue(defaultKeyIO.KeyValue, defaultKeyIO.AxisValue, defaultKeyIO.IsAxisSensitive, defaultKeyIO.IsAttachedInWritableSocketIO());
			component.OnKeySlotAssigned += KeySlotAssignedHandler;
			component.OnKeyBeginingAssignment += delegate
			{
				NotifyChange("QuickKeysView.IsKeyboardInUsingEvent", true);
			};
			component.OnKeyEndingAssignment += delegate
			{
				NotifyChange("QuickKeysView.IsKeyboardInUsingEvent", false);
			};
			component.OnKeyChangedAndCustomLabel += delegate(string keyId, string label)
			{
				NotifyChange("QuickKeysView.KeysGroupLabelChangedEvent", keyId, label);
			};
			component.OnEraseCustomLabel += delegate(string keyId)
			{
				NotifyChange("QuickKeysView.KeysGroupLabelErasedEvent", keyId);
			};
			component.OnEndingEditCustomLabel += delegate(string keyId, string label)
			{
				NotifyChange("QuickKeysView.KeysGroupLabelChangedEvent", keyId, label);
			};
			component.OnBeginingEditCustomLabel += delegate
			{
				NotifyChange("QuickKeysView.IsKeyboardInUsingEvent", true);
			};
			component.OnEndingEditCustomLabel += delegate
			{
				NotifyChange("QuickKeysView.IsKeyboardInUsingEvent", false);
			};
			quickKeysGroupMap.Add(inputKeyId, component);
		}
		quickKeysGroupMap[inputKeyId].AddQuickKeySlot(defaultKeyIO);
	}

	public void RefreshKeySlots(DefaultKeyIO[] defaultKeyIOs)
	{
		List<QuickKeysGroup> list = new List<QuickKeysGroup>();
		foreach (QuickKeysGroup value in quickKeysGroupMap.Values)
		{
			List<QuickKeySlot> list2 = new List<QuickKeySlot>();
			bool flag = false;
			foreach (QuickKeySlot allQuickKeySlot in value.GetAllQuickKeySlots())
			{
				if (allQuickKeySlot.DefaultKeyIO.ParentBlockBodyModel == null || allQuickKeySlot.DefaultKeyIO.ParentBlockBodyModel.ParentBlockModel.ParentCreationModel == null)
				{
					flag = true;
					list2.Add(allQuickKeySlot);
				}
			}
			foreach (QuickKeySlot item in list2)
			{
				value.RemoveQuickKeySlot(item);
				ObjectPools.Instance.ReturnInstance(item.gameObject);
			}
			if (value.QuickKeySlotsCount == 0)
			{
				list.Add(value);
			}
			else if (flag)
			{
				value.RegenerateGroupLabel();
				value.BlinkGroup();
			}
		}
		foreach (QuickKeysGroup item2 in list)
		{
			NotifyChange("QuickKeysView.KeysGroupLabelErasedEvent", item2.KeyMapId);
			quickKeysGroupMap.Remove(item2.KeyMapId);
			ObjectPools.Instance.ReturnInstance(item2.gameObject);
		}
		for (int i = 0; i < defaultKeyIOs.Length; i++)
		{
			if (defaultKeyIOs[i].Direction == DefaultKeyIODirection.Output || defaultKeyIOs[i].IsInputWithoutKey)
			{
				continue;
			}
			bool flag2 = false;
			foreach (QuickKeysGroup value2 in quickKeysGroupMap.Values)
			{
				foreach (QuickKeySlot allQuickKeySlot2 in value2.GetAllQuickKeySlots())
				{
					if (allQuickKeySlot2.DefaultKeyIO == defaultKeyIOs[i])
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					break;
				}
			}
			if (!flag2)
			{
				AddNewKeySlot(defaultKeyIOs[i]);
			}
		}
		NotifyChange("QuickKeysView.KeysGroupLabelRefreshEvent");
	}

	private void KeySlotAssignedHandler(QuickKeysGroup quickKeysGroup, QuickKeySlot quickKeySlot)
	{
		var (keyCode, axisCode) = quickKeySlot.GetCurrentAssignedKey();
		if (!(Util.GetInputKeyId(keyCode, axisCode) == quickKeysGroup.KeyMapId))
		{
			int id = quickKeySlot.DefaultKeyIO.ParentBlockBodyModel.ParentBlockModel.Id;
			int index = quickKeySlot.DefaultKeyIO.ParentBlockBodyModel.Index;
			string name = quickKeySlot.DefaultKeyIO.Name;
			NotifyChange("QuickKeysView.KeyAssignedEvent", id, index, name, keyCode, axisCode);
		}
	}

	public void UpdateKeySlot(DefaultKeyIO defaultKeyIO)
	{
		bool flag = false;
		QuickKeysGroup quickKeysGroup = null;
		QuickKeySlot quickKeySlot = null;
		foreach (QuickKeysGroup value in quickKeysGroupMap.Values)
		{
			foreach (QuickKeySlot allQuickKeySlot in value.GetAllQuickKeySlots())
			{
				if (allQuickKeySlot.DefaultKeyIO == defaultKeyIO)
				{
					quickKeysGroup = value;
					quickKeySlot = allQuickKeySlot;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		int siblingIndex = quickKeysGroup.transform.GetSiblingIndex() + 1;
		if (quickKeysGroup.QuickKeySlotsCount <= 1)
		{
			if (quickKeysGroup.QuickKeySlotsCount == 1)
			{
				quickKeysGroup.RemoveQuickKeySlot(quickKeySlot);
				ObjectPools.Instance.ReturnInstance(quickKeySlot.gameObject);
			}
			NotifyChange("QuickKeysView.KeysGroupLabelErasedEvent", quickKeysGroup.KeyMapId);
			quickKeysGroupMap.Remove(quickKeysGroup.KeyMapId);
			ObjectPools.Instance.ReturnInstance(quickKeysGroup.gameObject);
		}
		else
		{
			quickKeysGroup.RemoveQuickKeySlot(quickKeySlot);
			quickKeysGroup.RegenerateGroupLabel();
			ObjectPools.Instance.ReturnInstance(quickKeySlot.gameObject);
		}
		AddNewKeySlot(defaultKeyIO, siblingIndex);
		NotifyChange("QuickKeysView.KeysGroupLabelRefreshEvent");
	}

	public void UpdateQuickKeysGroupLabel(string keyId, string label)
	{
		if (quickKeysGroupMap.ContainsKey(keyId))
		{
			quickKeysGroupMap[keyId].SetCustomLabel(label);
		}
	}

	public void UpdateWindowStatus()
	{
		if (quickKeysGroupMap.Keys.Count == 0)
		{
			if (quickKeysGroupFolder.transform.childCount == 0)
			{
				Util.InstantiateForGUI(noKeysTextPrefab, quickKeysGroupFolder.transform, "NoKeysText");
			}
		}
		else if (quickKeysGroupFolder.transform.childCount > 0 && quickKeysGroupFolder.transform.GetChild(0).name == "NoKeysText")
		{
			Object.Destroy(quickKeysGroupFolder.transform.GetChild(0).gameObject);
		}
	}

	public void RefreshKeysControlledByLogicIcons()
	{
		foreach (QuickKeysGroup value in quickKeysGroupMap.Values)
		{
			value.RefreshKeyControlledByLogicIcon();
		}
	}
}
