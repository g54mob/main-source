using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Objects.Items
{
	public class FriendshipAmulet : NetworkPickup
	{
		private static List<Equipment> s_equipmentCache;

		private LevelUpFactory _levelUpFactory;

		private CoherenceSync _sync;

		[Inject]
		private void GetLevelUpFactory(LevelUpFactory levelUpFactory)
		{
		}

		protected override void Awake()
		{
		}

		public override void GetTaken()
		{
		}

		public static void ApplyFriendshipAmuletLevelUp(WeaponType weaponType, CharacterController player)
		{
		}

		public static WeaponType? GetRandomWeaponToLevelUp(CharacterController player)
		{
			return null;
		}

		private void SendOnlineLevelUps()
		{
		}
	}
}
