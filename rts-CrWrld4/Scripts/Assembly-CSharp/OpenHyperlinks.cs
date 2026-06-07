using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenHyperlinks : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public bool doesColorChangeOnHover;

	public Color hoverColor;

	private TextMeshProUGUI pTextMeshPro;

	private Canvas pCanvas;

	private Camera pCamera;

	private int pCurrentLink;

	private List<Color32[]> pOriginalVertexColors;

	public bool isLinkHighlighted => false;

	protected virtual void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	private List<Color32[]> SetLinkToColor(int linkIndex, Func<int, int, Color32> colorForLinkAndVert)
	{
		return null;
	}
}
