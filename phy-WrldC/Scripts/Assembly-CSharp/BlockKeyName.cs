using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockKeyName : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private TextMeshProUGUI blockKeyName;

	private DefaultKeyIO firstDefaultKeyIO;

	private List<DefaultKeyIO> defaultKeyIOs;

	public string BlockName { get; private set; }

	public string ComponentKeyLabel { get; private set; }

	private void Awake()
	{
		blockKeyName = GetComponent<TextMeshProUGUI>();
		defaultKeyIOs = new List<DefaultKeyIO>();
	}

	public void SetFirstBlockKeyName(DefaultKeyIO defaultKeyIO)
	{
		BlockName = LanguagesManager.Instance.GetText(defaultKeyIO.ParentBlockBodyModel.ParentBlockModel.Schematic.Name);
		ComponentKeyLabel = LanguagesManager.Instance.GetText(defaultKeyIO.BaseName);
		string sourceText = BlockName + " - " + ComponentKeyLabel;
		blockKeyName.SetText(sourceText);
		firstDefaultKeyIO = defaultKeyIO;
		defaultKeyIOs.Add(defaultKeyIO);
	}

	public void AddEqualBlockKeyName(DefaultKeyIO defaultKeyIO)
	{
		if (firstDefaultKeyIO != null)
		{
			defaultKeyIOs.Add(defaultKeyIO);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		SetBlockOutlineVisibility(isVisible: true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		SetBlockOutlineVisibility(isVisible: false);
	}

	public void SetBlockOutlineVisibility(bool isVisible)
	{
		for (int i = 0; i < defaultKeyIOs.Count; i++)
		{
			CreationModel parentCreationModel = defaultKeyIOs[i].ParentBlockBodyModel.ParentBlockModel.ParentCreationModel;
			int id = defaultKeyIOs[i].ParentBlockBodyModel.ParentBlockModel.Id;
			parentCreationModel.SetBlockOutline(id, isVisible, Util.OutlineColorParser(Color.green));
		}
	}
}
