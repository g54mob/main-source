using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors
{
	public class GoldFeverController : GameTickable, IInitializable, IDisposable
	{
		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private GameManager _gameManager;

		[Inject]
		private DataManager _dataManager;

		[Inject]
		private GameSessionData _session;

		[Inject]
		private ArcanaManager _arcanas;

		private bool _isActive;

		private float _totalTime;

		private float _durationInMS;

		private float _durationCap;

		private float _defaultCap;

		private float _totalDuration;

		private List<float> _randoms;

		private int _randomIndex;

		private float _total;

		private float _redu;

		private bool _isFake;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		protected override void OnTick()
		{
		}

		public bool IsFake()
		{
			return false;
		}

		public float GetScaleFactor()
		{
			return 0f;
		}

		public float GetProgress()
		{
			return 0f;
		}

		public float GetDuration()
		{
			return 0f;
		}

		public int GetTotalCoins()
		{
			return 0;
		}

		public void OnCoinPickup(Pickup c)
		{
		}

		private void CheckResults()
		{
		}

		private void OnEnemyDeath(GameplaySignals.EnemyKilledImmediateSignal sig)
		{
		}

		private float GetHighestFeverBonus()
		{
			return 0f;
		}

		private void StartGoldFever(UISignals.GoldFeverStartedSignal sig)
		{
		}

		private void EndGoldFever()
		{
		}

		private float GetRandom()
		{
			return 0f;
		}
	}
}
