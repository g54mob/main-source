using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;
using VLB;

public class ItemVolumetricBeamController : VolumetricBeamControllerBase
{
	[SerializeField]
	private VolumetricBeamData beamData;

	private void Awake()
	{
		if (beamData.beam == null)
		{
			Debug.LogError("Missing VolumetricLightBeam reference. ItemVolumetricBeamController destroying self.", base.gameObject);
			Object.Destroy(this);
		}
	}

	private void Update()
	{
		float t = Mathf.Clamp01(SingletonBehaviour<WeatherDriver>.Instance.GetVolumetricness(base.transform.position));
		float intensityOutside = Mathf.Lerp(0f, beamData.intensityOutsideMax, t);
		float intensityInside = Mathf.Lerp(0f, beamData.intensityInsideMax, t);
		beamData.beam.intensityOutside = intensityOutside;
		beamData.beam.intensityInside = intensityInside;
	}

	public override void ToggleActive(bool on)
	{
		shouldBeActive = on;
		base.enabled = shouldBeActive;
	}

	public Color GetBeamColor()
	{
		VolumetricLightBeam beam = beamData.beam;
		if (beam != null)
		{
			return beam.color;
		}
		Debug.LogError("Missing VolumetricLightBeam refernce. Returning default Color value.", this);
		return default(Color);
	}

	public void SetBeamColor(Color color)
	{
		VolumetricLightBeam beam = beamData.beam;
		if (beam != null)
		{
			beam.color = color;
		}
		else
		{
			Debug.LogError("Missing VolumetricLightBeam reference. Setting color skipped.", this);
		}
	}
}
