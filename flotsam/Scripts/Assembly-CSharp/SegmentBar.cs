using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SegmentBar<T> : MonoBehaviour where T : UIBehaviour
{
	[SerializeField]
	private T _segmentPrefab;

	private List<T> _segments;

	public void SetValue(int value, int max)
	{
		UpdateBar(value, max);
	}

	private void UpdateBar(int value, int max)
	{
		if (_segments == null)
		{
			_segments = new List<T>();
		}
		foreach (T segment in _segments)
		{
			segment.gameObject.SetActive(value: false);
		}
		for (int i = 0; i < max; i++)
		{
			T val = ReturnSegment();
			InitializeSegment(val, i);
			if (i < value)
			{
				SetActive(val);
			}
			else
			{
				SetInactive(val);
			}
		}
	}

	protected virtual void InitializeSegment(T segment, int index)
	{
		segment.gameObject.SetActive(value: true);
	}

	protected abstract void SetActive(T segment);

	protected abstract void SetInactive(T segment);

	private T ReturnSegment()
	{
		if (_segments == null)
		{
			_segments = new List<T>();
		}
		foreach (T segment in _segments)
		{
			if (!segment.gameObject.activeSelf)
			{
				return segment;
			}
		}
		T val = Object.Instantiate(_segmentPrefab, base.transform);
		_segments.Add(val);
		return val;
	}
}
