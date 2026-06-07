using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoGraphEventLine : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject mapIndicatorLinePrefab;

	[NonSerialized]
	public int time;

	[NonSerialized]
	public InfoGraph infoGraph;

	private List<int> eventNumbers;

	private int verticalPos;

	private List<GameObject> mapIndicatorLines;

	public void Init(InfoGraph infoGraph, int time, int verticalPos)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void DestroyMapIndicatorLines()
	{
	}

	public void GameUpdate()
	{
	}

	public void AddEventNumbers(List<int> ens)
	{
	}

	public void AddEventNumber(int en)
	{
	}

	public List<int> GetEventNumbers()
	{
		return null;
	}

	public void DestroyInfoGraphLine()
	{
	}
}
