using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StockMeshListRow : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public TextMeshProUGUI text;

	public Image background;

	[NonSerialized]
	public StockMeshDialog stockMeshDialog;

	private bool _selected;

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string meshName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
