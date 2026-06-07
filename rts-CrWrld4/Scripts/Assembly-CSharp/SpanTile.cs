using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpanTile : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public Image background;

	public Image selectedImage;

	public Image inProgress;

	public GameObject objectivesContainer;

	public GameObject objectiveNullify;

	public GameObject objectiveTotem;

	public GameObject objectiveReclaim;

	[NonSerialized]
	public int x;

	[NonSerialized]
	public int y;

	[NonSerialized]
	public int page;

	[NonSerialized]
	public int difficulty;

	public Color easyColor;

	public Color normalColor;

	public Color hardColor;

	private bool _selected;

	[NonSerialized]
	public bool interactable;

	private SpanSector sector;

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

	public void Init(SpanSector sector, int x, int y, int page, bool interactable)
	{
	}

	public void OnPointerEnter(PointerEventData ed)
	{
	}

	public void OnPointerExit(PointerEventData ed)
	{
	}

	public void OnPointerClick(PointerEventData ed)
	{
	}
}
