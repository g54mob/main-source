using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Generic;
using UnityEngine;

public class DrifterEyesHandler : MonoBehaviour
{
	public enum EyeState
	{
		Neutral = 0,
		Closed = 1,
		Dead = 2
	}

	[SerializeField]
	private Renderer _renderer;

	[SerializeField]
	[Tooltip("Time range it takes between blinks.")]
	private RangedFloat _betweenBlinkTimerRange;

	[SerializeField]
	[Tooltip("Time it takes to blink.")]
	private float _blinkTime = 0.25f;

	private float _betweenBlinkTime;

	private float _betweenBlinkCurrentTimer;

	private static Dictionary<EyeState, Vector2> _eyeStateCoordinates = new Dictionary<EyeState, Vector2>
	{
		{
			EyeState.Neutral,
			new Vector2(0f, 0f)
		},
		{
			EyeState.Closed,
			new Vector2(1f, 0f)
		},
		{
			EyeState.Dead,
			new Vector2(2f, 0f)
		}
	};

	public bool IsBlinking { get; set; } = true;

	public EyeState State { get; private set; }

	private void Awake()
	{
		_betweenBlinkTime = Random.Range(_betweenBlinkTimerRange.Minimum, _betweenBlinkTimerRange.Maximum);
	}

	private void Update()
	{
		if (IsBlinking)
		{
			_betweenBlinkCurrentTimer += Time.unscaledDeltaTime;
			if (_betweenBlinkCurrentTimer >= _betweenBlinkTime)
			{
				_betweenBlinkCurrentTimer = 0f;
				StartCoroutine(BlinkCoroutine());
			}
		}
	}

	private IEnumerator BlinkCoroutine()
	{
		SetEyeMaterial(EyeState.Closed);
		float timer = _blinkTime;
		while (timer > 0f)
		{
			timer -= Time.unscaledDeltaTime;
			yield return null;
		}
		SetEyeMaterial(State);
	}

	public void UpdateEyestate(Activity activity)
	{
		switch (activity)
		{
		case Activity.Sleeping:
			State = EyeState.Closed;
			IsBlinking = false;
			break;
		case Activity.Dead:
			State = EyeState.Dead;
			IsBlinking = false;
			break;
		default:
			State = EyeState.Neutral;
			IsBlinking = true;
			break;
		}
		SetEyeMaterial(State);
	}

	private void SetEyeMaterial(EyeState state)
	{
		if (_eyeStateCoordinates.TryGetValue(state, out var value))
		{
			_renderer.material.SetFloat("_CurrentColumn", value.x);
			_renderer.material.SetFloat("_CurrentRow", value.y);
		}
	}
}
