using UnityEngine;

public class NukeAttackFX : MonoBehaviour
{
	public enum AnimationState
	{
		None = 0,
		Static = 1,
		Shrinking = 2,
		Anticipation = 3,
		Shockwave = 4
	}

	public MeshRenderer shockwaveRenderer;

	public WaterSimAffector waterAffector;

	[Min(0f)]
	public float fadeInDuration = 0.5f;

	[Min(0f)]
	public float fadeOutDuration = 0.5f;

	[Min(0f)]
	public float staticDuration = 6f;

	[Min(0f)]
	public float shrinkDuration = 0.3f;

	[Min(0f)]
	public float pauseDuration = 0.2f;

	[Min(0f)]
	public float shockwaveDuration = 1f;

	public float timeScaleBeforePause = -1f;

	public float timeScaleAfterPause = 1f;

	public float radius = 15f;

	public bool play;

	private float m_playTime = -1f;

	private MaterialPropertyBlock m_shockwaveProperties;

	private AnimationState m_state;

	private static int _PulseStartTime = Shader.PropertyToID("_PulseStartTime");

	private static int _Opacity = Shader.PropertyToID("_Opacity");

	private static int _Timescale = Shader.PropertyToID("_Timescale");

	private void OnValidate()
	{
		if (play)
		{
			Play();
			play = false;
		}
	}

	private void Awake()
	{
		m_shockwaveProperties = new MaterialPropertyBlock();
	}

	private void OnEnable()
	{
		shockwaveRenderer.enabled = false;
	}

	public void Play()
	{
		m_playTime = Time.time;
	}

	private void LateUpdate()
	{
		float num = Time.time - m_playTime;
		float num2 = staticDuration + shrinkDuration + pauseDuration + shockwaveDuration;
		bool flag = m_playTime > 0f && num < num2;
		shockwaveRenderer.enabled = flag;
		if (flag)
		{
			float num3 = staticDuration + shrinkDuration;
			float num4 = staticDuration + shrinkDuration + pauseDuration;
			if (num < staticDuration)
			{
				shockwaveRenderer.transform.localScale = Vector3.one * radius;
				m_state = AnimationState.Static;
			}
			else if (num < num3)
			{
				shockwaveRenderer.transform.localScale = Vector3.one * (radius * Mathf.Clamp((num3 - num) / shrinkDuration, 0f, 1f));
				m_state = AnimationState.Shrinking;
			}
			else if (num < num4)
			{
				shockwaveRenderer.transform.localScale = Vector3.zero;
				m_state = AnimationState.Anticipation;
			}
			else if (num < num2)
			{
				shockwaveRenderer.transform.localScale = Vector3.one * (radius * Mathf.Sqrt(Mathf.Clamp(1f - (num2 - num) / shockwaveDuration, 0f, 1f)));
				float num5 = (num - num4) / (num2 - num4);
				waterAffector.transform.localScale = Vector3.one * Mathf.Lerp(Mathf.Epsilon, radius, num5);
				waterAffector.movement = (1f - num5) * 30f;
				m_state = AnimationState.Shockwave;
			}
			else
			{
				m_state = AnimationState.None;
			}
			if (m_state != AnimationState.Shockwave)
			{
				waterAffector.movement = 0f;
			}
			if (num < fadeInDuration)
			{
				m_shockwaveProperties.SetFloat(_Opacity, Mathf.Sqrt(Mathf.Clamp01(num / fadeInDuration)));
			}
			else if (num - num4 - (shockwaveDuration - fadeOutDuration) > 0f)
			{
				m_shockwaveProperties.SetFloat(_Opacity, 1f - Mathf.Sqrt(Mathf.Clamp01((num - num4 - (shockwaveDuration - fadeOutDuration)) / fadeOutDuration)));
			}
			else
			{
				m_shockwaveProperties.SetFloat(_Opacity, 1f);
			}
			m_shockwaveProperties.SetFloat(_PulseStartTime, shockwaveRenderer.enabled ? (m_playTime + staticDuration + shrinkDuration + pauseDuration) : (-1f));
			m_shockwaveProperties.SetFloat(_Timescale, (num - num4 > 0f) ? timeScaleAfterPause : timeScaleBeforePause);
			shockwaveRenderer.SetPropertyBlock(m_shockwaveProperties);
		}
	}
}
