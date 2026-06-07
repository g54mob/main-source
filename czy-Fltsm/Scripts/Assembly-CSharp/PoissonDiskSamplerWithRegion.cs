using System;
using UnityEngine;

[Serializable]
public class PoissonDiskSamplerWithRegion : PoissonDiskSampler
{
	private IRegion _region;

	public void GenerateSamples(IRegion region, int sampleCount)
	{
		_region = region;
		GenerateSamples(sampleCount, _sampleLimit, region.ReturnPositionInRegion());
	}

	protected override bool IsValidSample(Vector2 sample)
	{
		return _region.ReturnContainsPosition(sample);
	}
}
