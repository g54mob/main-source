using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;

public abstract class ThresholdBar<T> : UIBehaviour where T : UIBehaviour
{
	[SerializeField]
	private T _segmentPrefab;

	[ReadOnly]
	[SerializeField]
	private float _barWidth;

	private List<Tuple<T, float>> _segmentSizes = new List<Tuple<T, float>>();

	private float _totalWidth;

	private List<T> _segments = new List<T>();

	protected override void OnRectTransformDimensionsChange()
	{
		_barWidth = (base.transform as RectTransform).rect.width;
		UpdateSegmentSizes();
	}

	public T Add(float size)
	{
		_totalWidth += size;
		T val = ReturnSegment();
		_segmentSizes.Add(new Tuple<T, float>(val, size));
		UpdateSegmentSizes();
		return val;
	}

	public void Clear()
	{
		_totalWidth = 0f;
		foreach (T segment in _segments)
		{
			segment.gameObject.SetActive(value: false);
		}
	}

	private void UpdateSegmentSizes()
	{
		foreach (Tuple<T, float> segmentSize in _segmentSizes)
		{
			RectTransform rectTransform = segmentSize.Item1.transform as RectTransform;
			if (rectTransform == null)
			{
				Debug.LogError("Thresholdbar tried to get rect transform of prefab but was unable. Make sure prefab has rect transform.");
				continue;
			}
			Vector2 sizeDelta = rectTransform.sizeDelta;
			sizeDelta.x = segmentSize.Item2 / _totalWidth * _barWidth;
			rectTransform.sizeDelta = sizeDelta;
		}
	}

	private T ReturnSegment()
	{
		foreach (T segment in _segments)
		{
			if (!segment.gameObject.activeSelf)
			{
				segment.gameObject.SetActive(value: true);
				return segment;
			}
		}
		T val = UnityEngine.Object.Instantiate(_segmentPrefab, base.transform);
		val.name = "Segment";
		_segments.Add(val);
		return val;
	}
}
