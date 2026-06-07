using System;
using System.Collections.Generic;
using Poncle.Schema.Attributes.Attributes;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	[Title("Treasure")]
	public class Treasure
	{
		[NonSerialized]
		public bool QuickTreasureAnim;

		[NonSerialized]
		public CharacterController openingPlayer;

		[NonSerialized]
		public CharacterController winningPlayer;

		[NonSerialized]
		public List<TreasurePrizeTypePair> prizes;

		[NonSerialized]
		public List<WeaponType> accumulatedWeaponPrizes;

		[NonSerialized]
		public float accumulatedCoinPrize;

		[NonSerialized]
		public float quickAddedCoins;

		[NonSerialized]
		public List<WeaponType> accumulatedWorldSpacePrizes;

		[Title("Chances")]
		public List<float> chances { get; set; }

		[Title("Level")]
		public int level { get; set; }

		[Title("Prize Types")]
		public List<PrizeType?> prizeTypes { get; set; }

		[Title("Fixed Prizes")]
		public List<WeaponType> fixedPrizes { get; set; }

		[Title("Has Arcana")]
		public bool hasArcana { get; set; }

		[Title("Has Randoms")]
		public bool hasRandoms { get; set; }

		public void AddPrizes(List<TreasurePrizeTypePair> argPrizes, List<WeaponType> argAccumulatedWeaponPrizes, int argAccumulatedCoinPrize, List<WeaponType> argAccumulatedWorldSpacePrizes = null)
		{
		}

		public int GetCoinPrize()
		{
			return 0;
		}

		public void ClaimPrizes(CharacterController character)
		{
		}

		private void SpawnWorldSpaceWeapon(float x, float y, WeaponType weaponPrize, float delay)
		{
		}
	}
}
