using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadialSegmentController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public RectTransform segmentLineRect;

	public RectTransform elementLineRect;

	public RectTransform elementRect;

	public RectTransform stolenIcon;

	public TextMeshProUGUI text;

	public Image img;

	public List<CanvasRenderer> renderers;

	[Header("Inventory")]
	public FirstPersonItemController.InventorySlot slot;

	[Tooltip("The space each segment takes up")]
	[Header("Calculations")]
	[ReadOnly]
	public float segmentAngleSpace;

	[ReadOnly]
	[Tooltip("The anlge of this slot")]
	public float angle;

	[ReadOnly]
	public float toAngle;

	public void UpdateSegment(FirstPersonItemController.InventorySlot newSlot)
	{
	}

	public void OnUpdateContent()
	{
	}
}
