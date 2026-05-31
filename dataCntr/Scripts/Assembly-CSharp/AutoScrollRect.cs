using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class AutoScrollRect : MonoBehaviour
{
	public ScrollRect scrollRect;

	public RectTransform viewportRectTransform;

	public RectTransform contentRectTransform;

	[SerializeField]
	private Scrollbar scrollbar;

	private RectTransform selectedRectTransform;

	[SerializeField]
	private float additionalScrollOffset;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void ScrollAuto()
	{
	}
}
