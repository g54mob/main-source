using UnityEngine;
using UnityEngine.UI;

public class SegmentedLoadingBar : MonoBehaviour
{
	[SerializeField]
	private Image segmentPrefab;

	[SerializeField]
	private RectTransform segmentParent;

	[SerializeField]
	private int segmentCount = 20;

	private Image[] _segments;

	private float _progress;

	private void Start()
	{
		InitializeSegments();
	}

	public void SetNormalizedValue(float progress)
	{
		_progress = Mathf.Clamp01(progress);
		if (_segments != null && segmentCount != 0 && (bool)_segments[0])
		{
			int num = Mathf.RoundToInt(_progress * (float)segmentCount);
			for (int i = 0; i < segmentCount; i++)
			{
				_segments[i].enabled = i < num;
			}
		}
	}

	private void InitializeSegments()
	{
		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate(segmentParent);
		RebuildSegments();
	}

	private void RebuildSegments()
	{
		if (!segmentPrefab)
		{
			return;
		}
		foreach (Transform item in segmentParent)
		{
			Object.Destroy(item.gameObject);
		}
		HorizontalLayoutGroup component = segmentParent.GetComponent<HorizontalLayoutGroup>();
		float width = segmentParent.rect.width;
		float num = component.spacing * (float)(segmentCount - 1);
		int num2 = component.padding.left + component.padding.right;
		float x = (width - num - (float)num2) / (float)segmentCount;
		_segments = new Image[segmentCount];
		int num3 = Mathf.RoundToInt(_progress * (float)segmentCount);
		for (int i = 0; i < segmentCount; i++)
		{
			Image image = Object.Instantiate(segmentPrefab, segmentParent);
			image.enabled = false;
			RectTransform component2 = image.GetComponent<RectTransform>();
			component2.anchorMin = Vector2.zero;
			component2.anchorMax = Vector2.one;
			component2.offsetMin = Vector2.zero;
			component2.offsetMax = Vector2.zero;
			Vector2 sizeDelta = component2.sizeDelta;
			sizeDelta.x = x;
			component2.sizeDelta = sizeDelta;
			_segments[i] = image;
			if (i < num3)
			{
				image.enabled = true;
			}
		}
	}
}
