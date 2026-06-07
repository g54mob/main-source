using UnityEngine;

public class Obj_EmberFire : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem particle_Fire;

	[SerializeField]
	private Light light;

	[Header("亮度最大最小值")]
	[SerializeField]
	private Vector2 lightIntensityValueRange;

	[Header("照亮範圍最大最小值")]
	[SerializeField]
	private Vector2 lightRangeValueRange;

	[Header("火焰尺寸最大最小值")]
	[SerializeField]
	private Vector2 particleSizeValueRange;

	private float lerpingLightIntensity;

	private float lerpingLightRange;

	private float lerpingFireParticleScale;

	public ParticleSystem Particle_Fire => null;

	public Light Light => null;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void ToggleFire(bool isOn)
	{
	}

	public void SetFireStrengthRate(float rate)
	{
	}
}
