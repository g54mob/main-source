using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
	[SerializeField]
	private RectTransform rectTransform;

	[SerializeField]
	private TextMeshProUGUI text;

	public bool doNotShowTooltip;

	[SerializeField]
	private Canvas canvasToScaleTo;

	[SerializeField]
	private Vector3 offset;

	[SerializeField]
	private Vector2 defaultPivotOverlay;

	[SerializeField]
	private Vector2 defaultPivotWorld;

	[SerializeField]
	private float widthOfBackground;

	public void ShowTooltipOverlayCanvas(string tooltipText, Vector3 _position, int differentXOffset = 0)
	{
	}

	public void ShowTooltipWorldCanvas(string _text, RectTransform _transform, Camera cam)
	{
	}

	public void HideTooltip()
	{
	}
}
