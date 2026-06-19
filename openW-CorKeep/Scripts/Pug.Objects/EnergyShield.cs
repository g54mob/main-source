using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
	private static int _Color = Shader.PropertyToID("_Color");

	private static int _Arc = Shader.PropertyToID("_Arc");

	public MeshRenderer renderer;

	[ColorUsage(true, true)]
	public Color color = new Color(3f, 0.4f, 0f, 0.1f);

	[Space(5f)]
	public SpriteObject indirectSO;

	[Min(0f)]
	public float indirectLight = 1f;

	[Space(5f)]
	[Min(0f)]
	public float deployDuration = 0.3f;

	[Range(0f, 180f)]
	public float arc = 110f;

	[Space(10f)]
	public bool deployed;

	public Vector2 facingDirection = Vector2.right;

	private MaterialPropertyBlock m_properties;

	private float m_pulseTime = -1f;

	private float m_deployDelta;

	public void Pulse()
	{
		m_properties.SetFloat("_PulseTime", Time.time);
	}

	private void Awake()
	{
		m_properties = new MaterialPropertyBlock();
	}

	private void OnEnable()
	{
		UpdateRenderer();
	}

	private void LateUpdate()
	{
		UpdateRenderer();
	}

	private void UpdateRenderer()
	{
		m_deployDelta = Mathf.Clamp01(m_deployDelta + (float)(deployed ? 1 : (-1)) * Time.deltaTime / Mathf.Max(Mathf.Epsilon, deployDuration));
		if (m_deployDelta < Mathf.Epsilon)
		{
			renderer.enabled = false;
			indirectSO.emissiveColor = Color.black;
			return;
		}
		renderer.enabled = true;
		float num = arc * Smooth(m_deployDelta);
		m_properties.SetFloat(_Arc, num);
		m_properties.SetColor(_Color, color.gamma);
		renderer.SetPropertyBlock(m_properties);
		renderer.transform.rotation = Quaternion.LookRotation(facingDirection.X0Y().normalized, Vector3.up);
		indirectSO.emissiveColor = color * (num / 180f) * indirectLight;
	}

	private float Smooth(float x)
	{
		return x * x * (3f - 2f * x);
	}
}
