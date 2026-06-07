using UnityEngine;

public class AdjustSizeAndPositionBasedOnUIScale : MonoBehaviour
{
	public bool useSize = true;

	public float minSize;

	public float maxSize;

	public bool useXPos;

	public float minXPos;

	public float maxXPos;

	[Range(50f, 150f)]
	public float minScale = 100f;

	[Range(50f, 150f)]
	public float maxScale = 100f;

	private void OnEnable()
	{
		RectTransform component = GetComponent<RectTransform>();
		float value = Mathf.Lerp(50f, 150f, Mathf.InverseLerp(1.2f, 0.8f, SettingsManager.Instance.UiReferenceResolutionFactor));
		float num = Mathf.Lerp(minSize, maxSize, Mathf.InverseLerp(minScale, maxScale, value));
		float x = Mathf.Lerp(minXPos, maxXPos, Mathf.InverseLerp(minScale, maxScale, value));
		if (useSize)
		{
			component.localScale = num * Vector3.one;
		}
		if (useXPos)
		{
			component.anchoredPosition = new Vector2(x, component.anchoredPosition.y);
		}
	}
}
