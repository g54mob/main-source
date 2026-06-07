using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using Zenject;

namespace VampireSurvivors.Framework
{
	public class WhiteHandManager : GameMonoBehaviour
	{
		private Camera _mainCamera;

		private GameManager _gameManager;

		private GameSessionData _gameSessionData;

		private bool _triggered;

		private bool _kill;

		private float _bellTime;

		private Sequence _bellTollEvent;

		private PhaserSprite _whiteHand;

		[Inject]
		private void Construct(GameManager gameManager, GameSessionData gameSessionData)
		{
		}

		private void Awake()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void SummonWhiteHand(bool forceStageTimerEnd = false)
		{
		}

		private void ZoomOnPlayer()
		{
		}

		private void SpawnWhiteHand(bool forceStageTimerEnd = false)
		{
		}
	}
}
