using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BluePrintUIItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler
{
	public Image Back;

	public Image Arrow;

	public Color NormalColor;

	public Color HighlightColor;

	public Color SelectedColor;

	public Text Label;

	public bool Group;

	public bool Selected;

	public bool Unfolded;

	public List<BluePrintUIItem> Children = new List<BluePrintUIItem>();

	public BluePrintUIItem ParentItem;

	[NonSerialized]
	public BlueprintGroup Parent;

	[NonSerialized]
	public BuildingPrefab Prefab;

	public GameObject[] Buttons;

	public GameObject SteamIcon;

	public void Delete()
	{
		BlueprintWindow.Instance.DeleteBlueprint(this);
	}

	private void Start()
	{
		if (!Parent.CanUpload)
		{
			for (int i = 0; i < Buttons.Length; i++)
			{
				Buttons[i].SetActive(false);
			}
		}
		if (Parent.GetSteamID().HasValue && SteamIcon != null)
		{
			SteamIcon.SetActive(true);
		}
	}

	public void UpdateSelection()
	{
		if (Group)
		{
			BlueprintWindow.Instance.SaveToGroup(this);
			return;
		}
		WindowManager.Instance.ShowMessageBox("BlueprintReplacePrompt".Loc(Prefab.Name), true, DialogWindow.DialogType.Question, delegate
		{
			BlueprintWindow.Instance.UpdatePrefab(this);
		}, "BlueprintReplacePrompt");
	}

	public void CreateGroup()
	{
		BlueprintWindow.Instance.CreateGroup(this);
	}

	public void MoveToGroup()
	{
		BlueprintWindow.Instance.MoveToGroup(this);
	}

	public void DestroyMe()
	{
		if (ParentItem != null)
		{
			ParentItem.Children.Remove(this);
		}
		for (int i = 0; i < Children.Count; i++)
		{
			BluePrintUIItem bluePrintUIItem = Children[i];
			if (bluePrintUIItem != null)
			{
				bluePrintUIItem.ParentItem = null;
				UnityEngine.Object.Destroy(bluePrintUIItem.gameObject);
			}
		}
		Children.Clear();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		if (BlueprintWindow.Instance != null)
		{
			BlueprintWindow.Instance.Items.Remove(this);
		}
	}

	public void Rename()
	{
		BlueprintWindow.Instance.RenameItem(this);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!Selected)
		{
			Back.color = HighlightColor;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!Selected)
		{
			Back.color = NormalColor;
		}
	}

	public void Select(bool s)
	{
		Back.color = (s ? SelectedColor : NormalColor);
		Selected = s;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Group)
		{
			Unfolded = !Unfolded;
			for (int i = 0; i < Children.Count; i++)
			{
				if (Children[i] == null || Children[i].gameObject == null)
				{
					Children.RemoveAt(i);
					i--;
				}
				else
				{
					Children[i].gameObject.SetActive(Unfolded);
				}
			}
			Arrow.rectTransform.rotation = Quaternion.Euler(0f, 0f, Unfolded ? 90 : 180);
		}
		else
		{
			BlueprintWindow.Instance.Select(this);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
