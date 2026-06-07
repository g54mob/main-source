using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerSpaceDette : CharacterController
	{
		private Phaser2Weapon StartingWeapon;

		private float _baseWeaponPower;

		private int _nextTreshold;

		private int _extraFollowersAmount;

		private int _maxFollowers;

		private int[] _thresholds;

		private int _finalThreshold;

		private List<CharacterType> possibleFollowers;

		private List<CharacterType> currentFollowers;

		public override void AfterFullInitialization()
		{
		}

		private void CalculateTreshold()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void LevelUp()
		{
		}

		private void AddRandomFollower()
		{
		}
	}
}
