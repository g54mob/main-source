using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Block block;

	public bool deluxe;

	public bool custom;

	public Sprite deluxeSprite;

	public Sprite customSprite;

	private void Start()
	{
		if (deluxe)
		{
			GetComponent<Image>().sprite = deluxeSprite;
		}
		if (custom)
		{
			GetComponent<Image>().sprite = customSprite;
		}
	}

	public void SetData(Hashtable h)
	{
		base.transform.name = (string)h["name"];
		block = (Block)h["block"];
		deluxe = (bool)h["deluxe"];
		custom = (bool)h["custom"];
		base.transform.GetChild(0).GetComponent<RawImage>().texture = block.thumbnail;
		GetComponent<Tooltip>().tip = (string)h["tooltip"];
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			Collections.ToggleFavorite(block);
			TextEditor textEditor = new TextEditor();
			textEditor.content = new GUIContent($"{block.collection}/{block.type}");
			textEditor.SelectAll();
			textEditor.Copy();
		}
	}

	public void Select()
	{
		Selection.Clear();
		Control.ClearSelector();
		GameObject obj = Collections.CreateBlock(block.collection, block.type);
		obj.transform.SetParent(Global.elements["selector"], worldPositionStays: false);
		obj.AddComponent<BlockComponent>().data = block.Copy();
		Collections.AddRecentlyUsedBlock(block);
		Global.SetLayerRecursively(Global.elements["selector"], 2);
	}
}
