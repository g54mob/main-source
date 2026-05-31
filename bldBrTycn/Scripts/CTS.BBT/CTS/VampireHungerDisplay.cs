using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class VampireHungerDisplay : CTSBehaviour
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float _displayAtPercent = 0.6f;

		[SerializeField]
		private Sprite _backgroundSprite;

		[SerializeField]
		[ColorUsage(false, true)]
		private Color _normalEyes = Color.white;

		[SerializeField]
		[ColorUsage(false, true)]
		private Color _hungryEyes = Color.red;

		[SerializeField]
		private AnimationCurve _eyesCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Inject(false)]
		private Agent _agent;

		private static readonly int EmissiveMapColor = Shader.PropertyToID("_EmissiveMapColor");

		private NumericStatistic _hunger;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			Application.quitting -= Clear;
			Application.quitting += Clear;
		}

		private static void Clear()
		{
			Application.quitting -= Clear;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_agent.Statistics.StatisticUpdated += OnAgentStatisticsUpdated;
			OnAgentStatisticsUpdated();
		}

		private void OnAgentStatisticsUpdated()
		{
			if (_hunger != null)
			{
				_hunger.ValueChanged -= OnNeedChanged;
			}
			if (_agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Hunger, out _hunger))
			{
				_hunger.ValueChanged += OnNeedChanged;
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_agent.Statistics.StatisticUpdated -= OnAgentStatisticsUpdated;
			if (_hunger != null)
			{
				_hunger.ValueChanged -= OnNeedChanged;
			}
		}

		private void OnNeedChanged(float value)
		{
			value = _hunger.UnitInterval;
			float time = value.Remap(0f, _displayAtPercent, 0f, 1f);
			if ((bool)_agent.Material && (bool)_agent.Material.EyesMaterial)
			{
				_agent.Material.EyesMaterial.SetColor(EmissiveMapColor, Color.Lerp(_hungryEyes, _normalEyes, _eyesCurve.Evaluate(time)));
			}
		}
	}
}
