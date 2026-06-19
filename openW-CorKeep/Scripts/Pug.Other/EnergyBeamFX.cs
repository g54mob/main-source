using System;
using UnityEngine;

public class EnergyBeamFX : MonoBehaviour
{
	public MeshRenderer renderer;

	public ParticleSystem impactParticles;

	public ParticleSystem impactParticlesGround;

	public ParticleSystem impactParticlesWater;

	public WaterSimAffector waterAffector;

	[ColorUsage(false, true)]
	public Color color;

	[Range(0f, 1f)]
	public float coreHueShift = 0.1f;

	[Min(0f)]
	public float coreIntensity = 1f;

	[Min(0.0001f)]
	public float radius = 0.5f;

	[Min(0f)]
	public float overshoot = 2f;

	[Min(0f)]
	public float wobbleFrequency = 8f;

	[Min(0f)]
	public float wobbleAmplitude = 0.15f;

	[Space(10f)]
	[Min(0.0001f)]
	public float chargeRadius = 0.1f;

	[Min(0f)]
	public float chargeWobbleAmplitude = 1f;

	public bool isCharging;

	public bool isImpactingWater;

	[Space(10f)]
	public Vector3 originPointWorld;

	public Vector3 endPointWorld;

	[Space(10f)]
	public bool manualUpdateMode;

	private Material m_material;

	private Material m_coreMaterial;

	private static int _Color = Shader.PropertyToID("_Color");

	private void Awake()
	{
		m_coreMaterial = UnityEngine.Object.Instantiate(renderer.sharedMaterials[0]);
		m_material = UnityEngine.Object.Instantiate(renderer.sharedMaterials[1]);
		renderer.materials = new Material[2] { m_coreMaterial, m_material };
		UpdateParticleSystem(impactParticles, isPlaying: false);
		UpdateParticleSystem(impactParticlesGround, isPlaying: false);
		UpdateParticleSystem(impactParticlesWater, isPlaying: false);
	}

	private void OnEnable()
	{
		renderer.enabled = true;
	}

	private void OnDisable()
	{
		renderer.enabled = false;
		DisableEffects();
	}

	private void LateUpdate()
	{
		if (!(endPointWorld == originPointWorld) && !manualUpdateMode)
		{
			UpdateBeam();
		}
	}

	public void UpdateBeam()
	{
		float num = (isCharging ? chargeRadius : radius) * (1f + Mathf.Cos(Time.time * wobbleFrequency * 2f * MathF.PI) * (isCharging ? chargeWobbleAmplitude : wobbleAmplitude));
		Vector3 vector = endPointWorld - originPointWorld;
		float magnitude = vector.magnitude;
		if (Mathf.Approximately(0f, magnitude))
		{
			renderer.enabled = false;
			DisableEffects();
			return;
		}
		renderer.enabled = base.isActiveAndEnabled;
		vector /= magnitude;
		renderer.transform.position = originPointWorld.ToRender();
		renderer.transform.rotation = Quaternion.LookRotation(vector);
		renderer.transform.localScale = new Vector3(num, num, magnitude + overshoot);
		Color.RGBToHSV(color, out var H, out var S, out var V);
		Color value = Color.HSVToRGB(H + coreHueShift, S, V) * coreIntensity;
		m_coreMaterial.SetColor(_Color, value);
		m_material.SetColor(_Color, color);
		Plane plane = new Plane(Vector3.up, Vector3.zero);
		Ray ray = new Ray(originPointWorld.ToRender(), vector);
		if (base.enabled && !isCharging && plane.Raycast(ray, out var enter) && enter < magnitude + overshoot)
		{
			Vector3 position = ray.origin + ray.direction * enter;
			UpdateParticleSystem(impactParticles, isPlaying: true, position);
			UpdateParticleSystem(impactParticlesGround, !isImpactingWater, position);
			UpdateParticleSystem(impactParticlesWater, isImpactingWater, position);
			waterAffector.gameObject.SetActive(isImpactingWater);
			waterAffector.transform.position = position;
		}
		else
		{
			DisableEffects();
		}
	}

	private void DisableEffects()
	{
		UpdateParticleSystem(impactParticles, isPlaying: false);
		UpdateParticleSystem(impactParticlesGround, isPlaying: false);
		UpdateParticleSystem(impactParticlesWater, isPlaying: false);
		waterAffector.gameObject.SetActive(value: false);
	}

	private void UpdateParticleSystem(ParticleSystem particleSystem, bool isPlaying)
	{
		if (isPlaying && !particleSystem.isEmitting)
		{
			particleSystem.Play();
		}
		else if (!isPlaying && particleSystem.isEmitting)
		{
			particleSystem.Stop();
		}
	}

	private void UpdateParticleSystem(ParticleSystem particleSystem, bool isPlaying, Vector3 position)
	{
		UpdateParticleSystem(particleSystem, isPlaying);
		particleSystem.transform.position = position;
		particleSystem.transform.rotation = Quaternion.identity;
	}
}
