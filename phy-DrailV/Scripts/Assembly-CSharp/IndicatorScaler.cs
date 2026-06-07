using UnityEngine;

public class IndicatorScaler : Indicator
{
	public Transform indicatorToScale;

	public Vector3 startScale = Vector3.one;

	public Vector3 endScale = Vector3.one;

	private void Awake()
	{
		if (indicatorToScale == null)
		{
			indicatorToScale = base.transform;
		}
	}

	protected override void OnValueSet()
	{
		indicatorToScale.localScale = Vector3.Lerp(startScale, endScale, GetNormalizedValue());
	}
}
