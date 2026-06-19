using Pug.UnityExtensions;
using UnityEngine;

public class PugCoolText : MonoBehaviour
{
	public PugText pugText;

	public PugTextEffectJump pugTextEffectJump;

	[HideInInspector]
	public bool floatUpwards = true;

	private bool _useUnscaledTime;

	private bool _useTimer;

	private TimerSimple _killTimer;

	private Fader fader = new Fader(0f, Fader.FadeFunction.Linear);

	private float _fadeOutTime;

	private float _blinkFrequency = -1f;

	private float _blinkSmoothness;

	private float _minBlinkTransparency;

	private float _gravity;

	private float _velocity;

	private float _minVelocity = -100f;

	private float _maxVelocity = 100f;

	private float _resetAndPlayTimestamp;

	private float _randomSeed;

	[HideInInspector]
	public Color _color;

	[HideInInspector]
	public Color _blinkColor = Color.white;

	private float time
	{
		get
		{
			if (!_useUnscaledTime)
			{
				return Time.time;
			}
			return Time.unscaledTime;
		}
	}

	private float timeAdjustedWithRandomSeed => time - _resetAndPlayTimestamp + _randomSeed;

	private float deltaTime
	{
		get
		{
			if (!_useUnscaledTime)
			{
				return Time.deltaTime;
			}
			return Time.unscaledDeltaTime;
		}
	}

	private void Awake()
	{
		fader.fractionalFading = true;
	}

	public void ResetAndPlay(string text, Vector3 worldPosition, Color color, TextManager.FontFace fontFace = TextManager.FontFace.score, float gravity = 0f, float lifetime = 3f, float fadeInTime = 0.3f, float fadeOutTime = 0.3f, bool useUnscaledTime = false, bool activate = true, bool render = true, float initialVelocity = 0f, float bounceIntensity = 0f, float blinkFrequency = -1f, float blinkSmoothness = 0f, float minBlinkTransparency = 0.5f, float minVelocity = -100f, float maxVelocity = 100f)
	{
		if (text.Length > 24)
		{
			Debug.LogWarning("PugCoolText should use small strings, since otherwise, we may use too many glyphs from the glyph pool!");
		}
		if (blinkSmoothness < 0f || blinkSmoothness > 1f)
		{
			Debug.LogWarning("PugCoolText: Blink smoothness should be in the interval [0, 1].");
		}
		if (activate)
		{
			base.gameObject.SetActive(value: true);
		}
		_blinkColor = Color.white;
		_color = color;
		_randomSeed = PugRandom.GenerateUniform(0f, 10000f);
		_resetAndPlayTimestamp = time;
		pugText.SetText(text);
		base.transform.position = worldPosition;
		_blinkFrequency = blinkFrequency;
		_blinkSmoothness = Mathf.Clamp01(blinkSmoothness);
		_gravity = gravity;
		_velocity = initialVelocity;
		_useUnscaledTime = useUnscaledTime;
		_fadeOutTime = fadeOutTime;
		pugTextEffectJump.intensity = bounceIntensity;
		_minBlinkTransparency = minBlinkTransparency;
		_minVelocity = minVelocity;
		_maxVelocity = maxVelocity;
		pugText.SetFont(fontFace);
		if (render)
		{
			pugText.Render();
		}
		if (lifetime > Mathf.Epsilon)
		{
			_useTimer = true;
			_killTimer = new TimerSimple(lifetime, _useUnscaledTime);
			_killTimer.Start();
		}
		fader.FadeIn(fadeInTime, time);
	}

	public void LateUpdate()
	{
		if (_useTimer)
		{
			if (_killTimer.isTimerElapsed)
			{
				Manager.text.coolTextPool.Free(base.gameObject);
				base.gameObject.SetActive(value: false);
				return;
			}
			if (fader.GetFadeDirection() != Fader.FadeDirection.Out)
			{
				float remainingTime = _killTimer.remainingTime;
				if (remainingTime <= _fadeOutTime)
				{
					fader.FadeOut(remainingTime, time);
				}
			}
		}
		_velocity += _gravity * deltaTime;
		_velocity = Mathf.Clamp(_velocity, _minVelocity, _maxVelocity);
		if (Mathf.Abs(_velocity) > Mathf.Epsilon * 2f)
		{
			float x = base.transform.position.x;
			float y = base.transform.position.y + _velocity * deltaTime;
			float z = base.transform.position.z;
			base.transform.position = new Vector3(x, y, z);
		}
		float num = fader.UpdateFadeValue(time);
		float num2 = 0.5f * Mathf.Sin(timeAdjustedWithRandomSeed * _blinkFrequency) + 0.5f;
		float num3 = Mathf.Clamp(Mathf.Lerp((num2 < 0.5f) ? 0f : 1f, num2, _blinkSmoothness), _minBlinkTransparency, 1f);
		num3 = (((double)_blinkFrequency < 0.0001) ? 1f : num3);
		float r = Mathf.Lerp(_blinkColor.r, _color.r, num3);
		float g = Mathf.Lerp(_blinkColor.g, _color.g, num3);
		float b = Mathf.Lerp(_blinkColor.b, _color.b, num3);
		float num4 = Mathf.Lerp(_blinkColor.a, _color.a, num3);
		pugText.color = new Color(r, g, b, num * num4);
	}
}
