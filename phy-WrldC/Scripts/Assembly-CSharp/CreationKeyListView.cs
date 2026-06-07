using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationKeyListView : BaseGUIPanelView
{
	public const string MouseOverUIEvent = "CreationKeyListView.MouseOverUIEvent";

	private Toggle keyListCompactToggle;

	private GameObject keyGroupFolder;

	private GameObject logicKeyPanel;

	private GameObject logicKeyGroupFolder;

	private GameObject noKeysTextPrefab;

	private GameObject keyGroupPrefab;

	private GameObject blockKeyNamePrefab;

	private GameObject logicKeyGroupPrefab;

	private Dictionary<string, KeyGroup> keyGroupMap;

	private List<LogicKeyGroup> logicKeyGroups;

	private bool isMouseOverUI;

	public CreationKeyListView(ActionModeView actionModeView, GameObject noKeysTextPrefab, GameObject keyGroupPrefab, GameObject blockKeyNamePrefab, GameObject logicKeyGroupPrefab)
	{
		CreationKeyListView creationKeyListView = this;
		base.MainPanel = actionModeView.mainPanel.transform.FindChildRecursively("KeyListWindow").gameObject;
		keyListCompactToggle = base.MainPanel.transform.FindComponent<Toggle>("KeyListCompactToggle", isRecursively: true);
		keyGroupFolder = base.MainPanel.transform.FindChildRecursively("KeyGroupFolder").gameObject;
		logicKeyPanel = base.MainPanel.transform.FindChildRecursively("LogicKeyPanel").gameObject;
		logicKeyGroupFolder = base.MainPanel.transform.FindChildRecursively("LogicKeyGroupFolder").gameObject;
		this.noKeysTextPrefab = noKeysTextPrefab;
		this.keyGroupPrefab = keyGroupPrefab;
		this.blockKeyNamePrefab = blockKeyNamePrefab;
		this.logicKeyGroupPrefab = logicKeyGroupPrefab;
		keyListCompactToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			actionModeView.NotifyKeyListCompactToggleChanged(isOn);
		});
		keyGroupMap = new Dictionary<string, KeyGroup>();
		logicKeyGroups = new List<LogicKeyGroup>();
		isMouseOverUI = false;
		KeyListScrollView keyListScrollView = base.MainPanel.GetComponent<KeyListScrollView>();
		keyListScrollView.OnChangedScrollActivation += delegate(bool isScrollActive)
		{
			creationKeyListView.NotifyChange("CreationKeyListView.MouseOverUIEvent", creationKeyListView.isMouseOverUI, isScrollActive);
		};
		ComponentEventTrigger componentEventTrigger = base.MainPanel.transform.FindComponent<ComponentEventTrigger>("ScrollView", isRecursively: true);
		componentEventTrigger.OnPointerEnterEvent += delegate
		{
			creationKeyListView.MouseOverUIHandler(isMouseOverUI: true, keyListScrollView.IsScrollActive);
		};
		componentEventTrigger.OnPointerExitEvent += delegate
		{
			creationKeyListView.MouseOverUIHandler(isMouseOverUI: false, keyListScrollView.IsScrollActive);
		};
	}

	private void MouseOverUIHandler(bool isMouseOverUI, bool isScrollActive)
	{
		this.isMouseOverUI = isMouseOverUI;
		NotifyChange("CreationKeyListView.MouseOverUIEvent", isMouseOverUI, isScrollActive);
	}

	public void ClearAllKeyGroups()
	{
		keyGroupMap.Clear();
		logicKeyGroups.Clear();
		keyGroupFolder.transform.RemoveAllChildren();
		logicKeyGroupFolder.transform.RemoveAllChildren();
	}

	public void AddNewKey(DefaultKeyIO defaultKeyIO)
	{
		string text = Util.GetInputKeyId(defaultKeyIO.KeyValue, defaultKeyIO.AxisValue);
		bool flag = defaultKeyIO.IsAttachedInWritableSocketIO();
		bool isOverwriteByOtherInput = defaultKeyIO.IsOverwriteByOtherInput;
		if (flag || isOverwriteByOtherInput)
		{
			text = "logic";
		}
		if (!keyGroupMap.ContainsKey(text))
		{
			KeyGroup component = Util.InstantiateForGUI(keyGroupPrefab, keyGroupFolder.transform, text + "_KeyGroup").GetComponent<KeyGroup>();
			if (flag || isOverwriteByOtherInput)
			{
				component.Initialize("\uf2db");
			}
			else if (defaultKeyIO.KeyValue != KeyCode.None)
			{
				Sprite sprite = Util.ConvertKeyCodeToSprite(defaultKeyIO.KeyValue);
				if (sprite != null)
				{
					component.Initialize(sprite);
				}
				else
				{
					string key = Util.ConvertKeyCodeToString(defaultKeyIO.KeyValue);
					component.Initialize(key);
				}
			}
			else if (defaultKeyIO.AxisValue != AxisCode.None)
			{
				Sprite keySprite = Util.ConvertAxisCodeToSprite(defaultKeyIO.AxisValue);
				component.Initialize(keySprite);
			}
			else
			{
				component.Initialize(KeyCode.None.ToString());
			}
			keyGroupMap.Add(text, component);
		}
		keyGroupMap[text].AddBlockKeyName(blockKeyNamePrefab, defaultKeyIO);
	}

	public void AddNewLogicKey(LogicKeyData logicKeyData)
	{
		LogicKeyGroup component = Util.InstantiateForGUI(logicKeyGroupPrefab, logicKeyGroupFolder.transform, "LogicKeyGroup").GetComponent<LogicKeyGroup>();
		component.Initialize(logicKeyData);
		logicKeyGroups.Add(component);
	}

	public void SetKeyListCompactStatus(bool shouldBeCompact)
	{
		foreach (KeyGroup value in keyGroupMap.Values)
		{
			value.SetKeyGroupCompactStatus(shouldBeCompact);
		}
	}

	public void SetKeyListCompactToggleValue(bool isSelected)
	{
		if (keyListCompactToggle.isOn != isSelected)
		{
			keyListCompactToggle.SetValue(isSelected);
		}
	}

	public bool GetKeyListCompactToggleValue()
	{
		return keyListCompactToggle.isOn;
	}

	public void UpdateKeyGroupLabel(string keyId, string label)
	{
		if (keyGroupMap.ContainsKey(keyId))
		{
			keyGroupMap[keyId].SetCustomLabel(label);
		}
	}

	public void UpdateWindowStatus()
	{
		keyListCompactToggle.gameObject.SetActive(value: false);
		if (keyGroupMap.Keys.Count == 0)
		{
			Util.InstantiateForGUI(noKeysTextPrefab, keyGroupFolder.transform, "NoKeysText");
			return;
		}
		foreach (KeyGroup value in keyGroupMap.Values)
		{
			if (value.IsMixedGroup || value.IsCustomLabel)
			{
				keyListCompactToggle.gameObject.SetActive(value: true);
				break;
			}
		}
		logicKeyPanel.SetActive(logicKeyGroups.Count > 0);
	}
}
