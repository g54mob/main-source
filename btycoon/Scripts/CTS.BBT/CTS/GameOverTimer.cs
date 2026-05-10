using System;
using CTS.Core;
using CTS.UI;
using CTS.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class GameOverTimer : CTSBehaviour
	{
		[InjectScope(EGetScope.Singleton)]
		[Inject(false)]
		private GameOver _manager;

		[SerializeField]
		private Image _graceTimerImage;

		[SerializeField]
		private TMP_Text _endTimerText;

		[SerializeField]
		private AnimationCurve _pulseCurve;

		[SerializeField]
		private Vector2 _pulseSpeed;

		[SerializeField]
		private float _volumeMaxWeight = 0.45f;

		[SerializeField]
		private PaletteData _highPulseColor;

		[SerializeField]
		private PaletteData _lowPulseColor;

		private VolumeTween _volumeTween;

		private float _pulseTime;

		protected override void OnAwake()
		{
			base.OnAwake();
			GameOver.GameOverTimerTriggered += OnTimerTriggered;
			_volumeTween = _manager.transform.parent.GetComponentInChildren<VolumeTween>(includeInactive: true);
		}

		private void Start()
		{
			OnTimerTriggered(_manager.IsTimerActive);
		}

		private void OnDestroy()
		{
			GameOver.GameOverTimerTriggered -= OnTimerTriggered;
		}

		private void LateUpdate()
		{
			if (!GameOver.IsGameOver)
			{
				float fillAmount = _manager.GraceTimer / _manager.GraceTimerDuration;
				float num = 1f - _manager.EndTimer / _manager.EndTimerDuration;
				float num2 = Mathf.Lerp(_pulseSpeed.x, _pulseSpeed.y, num);
				_pulseTime += num2 * Time.unscaledDeltaTime;
				_pulseTime %= 1f;
				float num3 = _pulseCurve.Evaluate(_pulseTime);
				Color color = Color.Lerp(_lowPulseColor, _highPulseColor, num3);
				_graceTimerImage.color = color;
				float num4 = 0.1f * num3;
				_volumeTween.SetValue(_volumeMaxWeight * num + num4);
				TimeSpan timeSpan = TimeSpan.FromSeconds(_manager.EndTimer);
				_endTimerText.text = timeSpan.Minutes + ":" + timeSpan.Seconds.ToString("D2");
				_graceTimerImage.fillAmount = fillAmount;
			}
		}

		private void OnTimerTriggered(bool obj)
		{
			base.gameObject.SetActive(obj);
			if (!obj)
			{
				_volumeTween.Hide();
			}
		}
	}
}
