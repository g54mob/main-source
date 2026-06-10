using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[NonSerialized]
	public InfoWindow window;

	public string selectableType;

	public bool selectable;

	public bool highlighted;

	private void Start()
	{
	}

	public void SetSelectable(bool tf)
	{
	}

	private void OnDestroy()
	{
	}

	public void OnPointerEnter(PointerEventData data)
	{
	}

	public void OnPointerExit(PointerEventData data)
	{
	}

	private void Update()
	{
	}

	public void Hightlight()
	{
	}

	public void Restore()
	{
	}
}
