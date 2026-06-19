using UnityEngine;

public class AttackFX : MonoBehaviour
{
	public Material defaultMaterial;

	public const float CIRCULAR_RATIO = 0.8f;

	private MeshRenderer m_renderer;

	private MaterialPropertyBlock m_properties;

	private float m_disableTime;

	private void Awake()
	{
		m_renderer = GetComponentInChildren<MeshRenderer>();
		m_renderer.enabled = false;
		m_properties = new MaterialPropertyBlock();
	}

	public void PlayLine(Vector3 direction, float maxRange, float width, float duration, float delay, Material material)
	{
		m_properties.SetFloat("_Type", 0f);
		m_renderer.transform.rotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(90f, 0f, 90f);
		PlayInternal(maxRange, duration, delay, material, 0.15f, flip: false, 2f, 1f);
	}

	public void PlayArc(Vector3 direction, float maxRange, float arc, float duration, float delay, Material material, bool flip = false)
	{
		m_properties.SetFloat("_Type", 1f);
		m_renderer.transform.localPosition = Vector3.zero;
		m_renderer.transform.rotation = Quaternion.LookRotation(direction, Vector3.up) * Quaternion.Euler(90f, 0f, 90f);
		PlayInternal(maxRange * 2f, duration, delay, material, 0.25f, flip, 1f, 0.8f);
	}

	public void PlayShockwave(float maxRange, float duration, float delay, Material material)
	{
		m_properties.SetFloat("_Type", 2f);
		m_renderer.transform.localPosition = Vector3.zero;
		PlayInternal(maxRange * 2f, duration, delay, material, 0.25f, flip: false, 1f, 0.8f);
	}

	private void PlayInternal(float size, float duration, float delay, Material material, float timeLinearity, bool flip, float length, float aspectRatio)
	{
		base.transform.localScale = new Vector3(1f, 1f, aspectRatio);
		m_renderer.transform.localScale = new Vector3(length, flip ? (-1f) : 1f, 1f) * size;
		m_renderer.material = ((material != null) ? material : defaultMaterial);
		m_properties.SetFloat("_StartTime", Time.time + delay);
		m_properties.SetFloat("_Duration", duration);
		m_properties.SetFloat("_NoiseOffset", Random.value);
		m_properties.SetFloat("_TimeLinearity", timeLinearity);
		m_renderer.SetPropertyBlock(m_properties);
		m_renderer.enabled = true;
		m_disableTime = Time.time + delay + duration;
	}

	private void Update()
	{
		if (m_renderer.enabled && Time.time > m_disableTime)
		{
			m_renderer.enabled = false;
		}
	}
}
