using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class LightFlickerEffect : MonoBehaviour
{
	[FormerlySerializedAs("light")]
	[Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
	public Light flickeringLight;

	[Tooltip("Minimum random light intensity")]
	public float minIntensity;

	[Tooltip("Maximum random light intensity")]
	public float maxIntensity = 1f;

	public bool enableMovement = true;

	private float3 _lightStartPosition;

	private int _effectID = -1;

	private void Awake()
	{
		if (flickeringLight == null)
		{
			flickeringLight = GetComponent<Light>();
		}
		if (flickeringLight != null)
		{
			_lightStartPosition = flickeringLight.transform.localPosition;
			flickeringLight.intensity = (minIntensity + maxIntensity) * 0.5f;
		}
		_effectID = -1;
	}

	private void OnEnable()
	{
		_effectID = Manager.lights.AddLightFlicker(flickeringLight, minIntensity, maxIntensity, _lightStartPosition, enableMovement);
	}

	private void OnDisable()
	{
		if (_effectID != -1)
		{
			Manager.lights.RemoveLightFlicker(_effectID);
			_effectID = -1;
		}
	}

	private void OnValidate()
	{
		if (Application.isPlaying && _effectID != -1)
		{
			Manager.lights.UpdateLightFlickerParameters(_effectID, minIntensity, maxIntensity, enableMovement);
		}
	}

	public void SetIntensityRange(float min, float max)
	{
		minIntensity = min;
		maxIntensity = max;
		if (_effectID != -1)
		{
			Manager.lights.UpdateLightFlickerParameters(_effectID, min, max, enableMovement);
		}
	}
}
