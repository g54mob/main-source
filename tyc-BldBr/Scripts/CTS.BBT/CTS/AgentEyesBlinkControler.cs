using System.Collections;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class AgentEyesBlinkControler : MonoBehaviour
	{
		public enum e_eyesState
		{
			Normal = 0,
			StayOpen = 1,
			StayClose = 2
		}

		[SerializeField]
		private float _topLidCloseValue = 85f;

		[SerializeField]
		private float _bottomLidCloseValue = 50f;

		[Header("Drunk")]
		[SerializeField]
		private float _drunkTopLidLeftValue = 50f;

		[SerializeField]
		private float _drunkBottomLidLeftValue;

		[SerializeField]
		private float _drunkTopLidRightValue;

		[SerializeField]
		private float _drunkBottomLidRightValue = 100f;

		[SerializeField]
		private float _blinkSpeed = 20f;

		[SerializeField]
		[MinMaxSlider(0.1f, 10f)]
		private Vector2 _blinkIntervalRange = new Vector2(0.5f, 5f);

		[HideInInspector]
		public bool UseUnscaledDeltaTime;

		private SkinnedMeshRenderer _skinRenderer;

		private float _currentTime;

		private Coroutine _blinkCoroutine;

		private e_eyesState _currentEyesState;

		private bool _isDrunk;

		public e_eyesState CurrentEyesState
		{
			get
			{
				return _currentEyesState;
			}
			set
			{
				_currentEyesState = value;
				PlayBlink();
			}
		}

		public bool IsDrunk
		{
			set
			{
				_isDrunk = value;
				PlayBlink();
			}
		}

		private float GetRandomTime => Random.Range(_blinkIntervalRange.x, _blinkIntervalRange.y);

		public SkinnedMeshRenderer SetSkinnedMeshRenderer
		{
			set
			{
				_skinRenderer = value;
				base.enabled = _skinRenderer != null;
			}
		}

		private void Awake()
		{
			_currentTime = GetRandomTime;
			if (_skinRenderer == null)
			{
				base.enabled = false;
			}
		}

		private void Update()
		{
			if (_currentEyesState == e_eyesState.Normal)
			{
				_currentTime -= (UseUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime);
				if (_currentTime <= 0f)
				{
					_currentTime = GetRandomTime;
					PlayBlink();
				}
			}
		}

		private void PlayBlink()
		{
			if (!(_skinRenderer == null))
			{
				if (_blinkCoroutine != null)
				{
					StopCoroutine(_blinkCoroutine);
				}
				if (base.isActiveAndEnabled)
				{
					_blinkCoroutine = StartCoroutine(Blink());
				}
			}
		}

		private IEnumerator Blink()
		{
			float timer = 0f;
			if (_currentEyesState != e_eyesState.StayOpen)
			{
				while (timer < 1f)
				{
					timer += (UseUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime) * (_blinkSpeed * (_isDrunk ? 0.3f : 1f));
					UpdateBlinkValue(timer);
					yield return null;
				}
				UpdateBlinkValue(1f);
			}
			if (_currentEyesState != e_eyesState.StayClose)
			{
				while (timer > 0f)
				{
					timer -= (UseUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime) * (_blinkSpeed * (_isDrunk ? 0.3f : 1f));
					UpdateBlinkValue(timer);
					yield return null;
				}
				UpdateBlinkValue(0f);
			}
			_blinkCoroutine = null;
		}

		private void UpdateBlinkValue(float p_timer)
		{
			_skinRenderer.SetBlendShapeWeight(0, Mathf.Lerp(_isDrunk ? _drunkTopLidRightValue : 0f, _topLidCloseValue, p_timer));
			_skinRenderer.SetBlendShapeWeight(1, Mathf.Lerp(_isDrunk ? _drunkTopLidLeftValue : 0f, _topLidCloseValue, p_timer));
			_skinRenderer.SetBlendShapeWeight(2, Mathf.Lerp(_isDrunk ? _drunkBottomLidRightValue : 0f, _bottomLidCloseValue, p_timer));
			_skinRenderer.SetBlendShapeWeight(3, Mathf.Lerp(_isDrunk ? _drunkBottomLidLeftValue : 0f, _bottomLidCloseValue, p_timer));
		}
	}
}
