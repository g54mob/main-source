using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.UI.Player
{
	public class WickedSeasonUI : GameMonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _SeasonFan;

		[SerializeField]
		private SpriteRenderer _SeasonSprite;

		[SerializeField]
		private Transform _SeasonSpriteParent;

		private SignalBus _signalBus;

		private Tween _seasonTween;

		private float _tweenValue;

		private static readonly int FillAmount;

		[Inject]
		private void Construct(SignalBus signalBus)
		{
		}

		private void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OpenSeasonFan(GameplaySignals.OpenSeasonFanSignal signal)
		{
		}
	}
}
