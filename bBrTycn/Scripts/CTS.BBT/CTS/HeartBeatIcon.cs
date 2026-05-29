using CTS.BBT.AI;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class HeartBeatIcon : MonoBehaviour
	{
		[SerializeField]
		private float _maxScale;

		[SerializeField]
		private Transform _transform;

		[SerializeField]
		private AnimationCurve _beatCurve;

		[SerializeField]
		private float _beatSpeed;

		[SerializeField]
		[MinMaxSlider(0.1f, 100f)]
		private Vector2 _beatSpeedSlider;

		private float _scaleTransitionValue;

		private Agent _currentAgent;

		public Agent CurrentAgent
		{
			set
			{
				_currentAgent = value;
				base.enabled = _currentAgent != null;
			}
		}

		private void Update()
		{
			if (!(_currentAgent == null))
			{
				_beatSpeed = Mathf.Lerp(_beatSpeedSlider.y, _beatSpeedSlider.x, _currentAgent.Statistics.GetStatisticUnitInterval(EAgentStatistics.Health));
				_scaleTransitionValue += Time.unscaledDeltaTime * _beatSpeed;
				if (_scaleTransitionValue >= 1f)
				{
					_scaleTransitionValue -= 1f;
				}
				_transform.localScale = Vector3.one * Mathf.Lerp(1f, _maxScale, _beatCurve.Evaluate(_scaleTransitionValue));
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void TestBless()
		{
			if (!(_currentAgent == null))
			{
				_currentAgent.Statistics.AddToStatistic(EAgentStatistics.Health, -5f);
			}
		}
	}
}
