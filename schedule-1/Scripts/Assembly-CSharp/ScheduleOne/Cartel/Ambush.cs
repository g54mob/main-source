using EasyButtons;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Economy;
using ScheduleOne.Levelling;
using ScheduleOne.Map;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Cartel
{
	public class Ambush : CartelActivity
	{
		public const float MIN_DISTANCE_TO_POLICE_OFFICER = 15f;

		public const int CANCEL_AMBUSH_AFTER_MINS = 360;

		public const float AMBUSH_DEFEATED_INFLUENCE_CHANGE = -0.1f;

		public static FullRank MIN_RANK_FOR_RANGED_WEAPONS;

		private CartelRegionActivities _regionActivities;

		[Header("Settings")]
		public AvatarWeapon[] RangedWeapons;

		public AvatarWeapon[] MeleeWeapons;

		[Header("Debugging & Development")]
		public EMapRegion region;

		public override void Activate(EMapRegion region)
		{
		}

		protected override void Deactivate()
		{
		}

		protected override void MinPassed()
		{
		}

		private bool CanPlayerBeAmbushed(Player player)
		{
			return false;
		}

		private void ContractReceiptRecorded(ContractReceipt receipt)
		{
		}

		private void SpawnAmbush(Player target, Vector3[] potentialSpawnPoints)
		{
		}

		[Button]
		public void TriggerAmbushForPlayer()
		{
		}
	}
}
