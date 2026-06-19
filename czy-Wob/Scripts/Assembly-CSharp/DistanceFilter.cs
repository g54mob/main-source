using UnityEngine;

public class DistanceFilter : MonoBehaviour
{
	private AudioHighPassFilter filterRef;

	public float filterValueLow;

	public float filterValueHigh = 1000f;

	public float filterRangeLow = 20f;

	public float filterRangeHigh = 100f;

	private GameObject mainCamRef;

	private void Start()
	{
		if (Camera.main != null)
		{
			mainCamRef = Camera.main.gameObject;
		}
		AddFilter();
	}

	private void Update()
	{
		UpdateFilter();
	}

	public void RemoveFilter()
	{
		if (filterRef != null)
		{
			Object.Destroy(filterRef);
			filterRef = null;
		}
	}

	public void AddFilter()
	{
		filterRef = GetComponent<AudioHighPassFilter>();
		if (filterRef == null)
		{
			filterRef = base.gameObject.AddComponent<AudioHighPassFilter>();
		}
		filterRef.enabled = true;
		UpdateFilter();
	}

	private void UpdateFilter()
	{
		if (!(filterRef == null) && !(mainCamRef == null) && base.gameObject.activeSelf)
		{
			float num = Vector3.Distance(mainCamRef.transform.position, base.transform.position);
			if (num < filterRangeLow)
			{
				filterRef.enabled = false;
				return;
			}
			filterRef.enabled = true;
			float percentage = (Mathf.Min(num, filterRangeHigh) - filterRangeLow) / (filterRangeHigh - filterRangeLow);
			filterRef.cutoffFrequency = MathUtil.GetValueOfRangePercentage(percentage, filterValueLow, filterValueHigh);
		}
	}
}
