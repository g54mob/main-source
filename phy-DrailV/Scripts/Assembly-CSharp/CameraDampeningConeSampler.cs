using UnityEngine;

public class CameraDampeningConeSampler : CameraDampening
{
	[Header("ConeSampler parameters")]
	public float coneAngle = 9f;

	public float maxDistance = 10f;

	[Range(1f, 100f)]
	public int samplesPerFrame = 2;

	public int sampleSize = 40;

	public LayerMask sampleLayers;

	private ConeSampler sampler;

	protected override void OnEnable()
	{
		base.OnEnable();
		sampler = cameraGO.GetComponent<ConeSampler>();
		if (!sampler)
		{
			sampler = cameraGO.AddComponent<ConeSampler>();
		}
		sampler.coneAngle = coneAngle;
		sampler.maxDistance = maxDistance;
		sampler.timingMode = ConeSampler.TimingMode.SamplesPerFrame;
		sampler.timingRate = samplesPerFrame;
		sampler.sampleBufferSize = sampleSize;
		sampler.sampleLayers = sampleLayers;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		sampler = null;
	}

	protected override float GetDamping()
	{
		return 1f - Mathf.Clamp01(sampler.average);
	}
}
