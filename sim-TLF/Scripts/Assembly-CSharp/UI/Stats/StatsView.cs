using Player.Stats;
using UI.HUD;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Stats
{
	public class StatsView : MonoBehaviour
	{
		[SerializeField]
		private Slider _nicotineSlider;

		[SerializeField]
		private Slider _alcoholSlider;

		[SerializeField]
		private CanvasGroup _statsCanvasGroup;

		[Header("Stat rows (fordenied-ability feedback)")]
		[SerializeField]
		private StatSliderView _nicotineStatRow;

		[SerializeField]
		private StatSliderView _alcoholStatRow;

		[Inject]
		private IPlayerStatsService _playerStatsService;

		public StatSliderView NicotineStatRow => _nicotineStatRow;

		public StatSliderView AlcoholStatRow => _alcoholStatRow;

		private void OnEnable()
		{
			_playerStatsService.AlcoholChanged += AlcoholStatChanged;
			_playerStatsService.NicotineChanged += NicotineStatChanged;
		}

		private void OnDisable()
		{
			_playerStatsService.AlcoholChanged -= AlcoholStatChanged;
			_playerStatsService.NicotineChanged -= NicotineStatChanged;
		}

		public void SetStatsVisible()
		{
			_statsCanvasGroup.alpha = 1f;
		}

		public void SetStatsTransparent()
		{
			_statsCanvasGroup.alpha = 0.22f;
		}

		private void NicotineStatChanged(float value)
		{
			_nicotineSlider.SetValueWithoutNotify(value);
		}

		private void AlcoholStatChanged(float value)
		{
			_alcoholSlider.SetValueWithoutNotify(value);
		}
	}
}
