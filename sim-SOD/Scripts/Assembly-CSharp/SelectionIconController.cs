using UnityEngine;
using UnityEngine.UI;

public class SelectionIconController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public CanvasRenderer rend;

	public Image image;

	[Header("State")]
	public bool highlighted;

	public bool fadeIn;

	public bool destroy;

	public float alpha;

	public Interactable interactable;

	public float highlightProgress;

	[Header("Settings")]
	public Color highlightedColor;

	public Color unHighlightedColor;

	public void Setup(Interactable newInteractable)
	{
	}

	private void Update()
	{
	}

	public void Remove()
	{
	}

	public void SetHighlighted(bool val)
	{
	}
}
