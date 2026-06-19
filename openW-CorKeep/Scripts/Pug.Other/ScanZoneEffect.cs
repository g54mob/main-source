using UnityEngine;

public class ScanZoneEffect : MonoBehaviour
{
	public MeshRenderer meshRenderer;

	[ColorUsage(true, true)]
	public Color inactiveColor = new Color(1f, 1f, 0f, 0.5f);

	[ColorUsage(true, true)]
	public Color halfActiveColor = Color.yellow;

	[ColorUsage(true, true)]
	public Color activeColor = Color.green;

	public bool scanIsVisible;

	[Range(0f, 1f)]
	public float progressSpeed;

	[SerializeField]
	private AnimationCurve m_visibleAnimation = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	private MaterialPropertyBlock m_properties;

	private float m_scanTime;

	private float m_showTimer;

	private static readonly int _Color = Shader.PropertyToID("_Color");

	private static readonly int _ScanTime = Shader.PropertyToID("_ScanTime");

	private void Awake()
	{
		m_properties = new MaterialPropertyBlock();
		meshRenderer.GetPropertyBlock(m_properties);
	}

	private void OnEnable()
	{
		m_scanTime = 0f;
	}

	private void Update()
	{
		progressSpeed = Mathf.Clamp01(progressSpeed);
		m_scanTime += Time.deltaTime * (1f + progressSpeed * 3f);
		Color color = ((progressSpeed > 0.7f) ? activeColor : halfActiveColor);
		m_properties.SetColor(_Color, (progressSpeed > 0f) ? new Color(color.r, color.g, color.b, color.a * (0.5f + progressSpeed * 0.5f)) : inactiveColor);
		m_properties.SetFloat(_ScanTime, m_scanTime);
		meshRenderer.SetPropertyBlock(m_properties);
		m_showTimer = Mathf.Clamp01(m_showTimer + Time.deltaTime * (float)(scanIsVisible ? 1 : (-1)) * 2f);
		float num = m_visibleAnimation.Evaluate(m_showTimer);
		meshRenderer.transform.localScale = Vector3.one * Mathf.Max(0.001f, num);
		meshRenderer.enabled = num > Mathf.Epsilon;
	}
}
