using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors
{
	public class TreasureFactory : IInitializable, IDisposable
	{
		[Inject]
		private LevelUpFactory _levelUpFactory;

		[Inject]
		private DataManager _dataManager;

		[Inject]
		private PlayerOptions _playerOptions;

		private List<WeaponType> _accumulatedWeaponPrizes;

		private List<WeaponType> _accumulatedWorldSpacePrizes;

		private int _accumulatedCoinPrize;

		public List<PrizeType> currentTreasureTypes;

		private float _coinsAward;

		private List<TreasurePrizeTypePair> _prizes;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public List<TreasurePrizeTypePair> GenerateNewPrizes(Treasure data)
		{
			return null;
		}

		private TreasurePrizeTypePair MakePrizePairFromAvailablePowerUps(PrizeType prizeType, WeaponType fixedPrize, CharacterController character, bool isSpecial = false)
		{
			return null;
		}

		private void MakePrizes(Treasure treasure)
		{
		}

		public int GetCoins()
		{
			return 0;
		}

		public List<WeaponType> GetAccumulatedWeaponPrizes()
		{
			return null;
		}

		private void AddFiller(TreasurePrizeTypePair pair)
		{
		}
	}
}
