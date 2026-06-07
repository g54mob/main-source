using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyGroup : MonoBehaviour
{
	private const string LabelSeparator = " - ";

	private TextMeshProUGUI keyText;

	private TextMeshProUGUI labelText;

	private GameObject keyImagePanel;

	private Image keyImage;

	private Transform blockKeyNameFolder;

	private List<BlockKeyName> blockKeyNames;

	public bool IsMixedGroup { get; private set; }

	public bool IsCustomLabel { get; private set; }

	private void Awake()
	{
		keyText = base.transform.FindComponent<TextMeshProUGUI>("KeyText", isRecursively: true);
		labelText = base.transform.FindComponent<TextMeshProUGUI>("LabelText", isRecursively: true);
		keyImage = base.transform.FindComponent<Image>("KeyImage", isRecursively: true);
		keyImagePanel = keyImage.transform.parent.gameObject;
		blockKeyNameFolder = base.transform.FindChildRecursively("BlockKeyNameFolder");
		blockKeyNames = new List<BlockKeyName>();
		ComponentEventTrigger componentEventTrigger = base.transform.FindComponent<ComponentEventTrigger>("Header", isRecursively: true);
		componentEventTrigger.OnPointerEnterEvent += OnPointerEnterHandler;
		componentEventTrigger.OnPointerExitEvent += OnPointerExitHandler;
	}

	public void Initialize(string key)
	{
		keyText.gameObject.SetActive(value: true);
		keyImagePanel.SetActive(value: false);
		keyText.SetText(key);
		labelText.SetText("");
		IsMixedGroup = false;
		IsCustomLabel = false;
	}

	public void Initialize(Sprite keySprite)
	{
		keyText.gameObject.SetActive(value: false);
		keyImagePanel.SetActive(value: true);
		keyImage.sprite = keySprite;
		labelText.SetText("");
		IsMixedGroup = false;
		IsCustomLabel = false;
	}

	public void AddBlockKeyName(GameObject blockKeyNamePrefab, DefaultKeyIO defaultKeyIO)
	{
		string text = LanguagesManager.Instance.GetText(defaultKeyIO.ParentBlockBodyModel.ParentBlockModel.Schematic.Name);
		string text2 = LanguagesManager.Instance.GetText(defaultKeyIO.BaseName);
		string text3 = text + " - " + text2;
		if (labelText.text != text3)
		{
			string[] array = labelText.text.Split(new string[1] { " - " }, StringSplitOptions.None);
			if (array.Length == 2)
			{
				string text4 = array[0];
				string obj = array[1];
				string text5 = LanguagesManager.Instance.GetText("label.text.keylist.mixed", "Mixed");
				if (text4 != text)
				{
					text = text5;
				}
				if (obj != text2)
				{
					text2 = text5;
				}
				text3 = text + " - " + text2;
				IsMixedGroup = true;
			}
			labelText.SetText(text3);
		}
		bool flag = false;
		foreach (BlockKeyName blockKeyName in blockKeyNames)
		{
			if (blockKeyName.BlockName == text && blockKeyName.ComponentKeyLabel == text2)
			{
				blockKeyName.AddEqualBlockKeyName(defaultKeyIO);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			BlockKeyName component = Util.InstantiateForGUI(blockKeyNamePrefab, blockKeyNameFolder).GetComponent<BlockKeyName>();
			component.SetFirstBlockKeyName(defaultKeyIO);
			blockKeyNames.Add(component);
		}
	}

	public void SetKeyGroupCompactStatus(bool shouldBeCompact)
	{
		blockKeyNameFolder.gameObject.SetActive(!shouldBeCompact && (IsMixedGroup || IsCustomLabel));
	}

	public void SetCustomLabel(string label)
	{
		labelText.SetText(label);
		IsCustomLabel = true;
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
		foreach (BlockKeyName blockKeyName in blockKeyNames)
		{
			blockKeyName.SetBlockOutlineVisibility(isVisible);
		}
	}
}
