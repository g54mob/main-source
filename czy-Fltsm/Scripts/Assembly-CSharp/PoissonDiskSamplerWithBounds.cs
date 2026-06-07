using System;
using UnityEngine;

[Serializable]
public class PoissonDiskSamplerWithBounds : PoissonDiskSampler
{
	private Rect _bounds;

	public void GenerateSamples(Rect bounds)
	{
		_bounds = bounds;
		GenerateSamples(bounds.center);
	}

	protected override bool IsValidSample(Vector2 sample)
	{
		return _bounds.Contains(sample);
	}
}
