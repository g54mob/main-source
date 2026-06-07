using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_FakeTrio_Character : TP_Character
	{
		private bool _spawnFollowersNextFrame;

		private SkinType mySkin;

		private CharacterController follower1;

		private CharacterController follower2;

		private bool _canRetaliate;

		private float RetaliationDelay;

		private float OverhealDelay;

		private float OverhealTriggerValue;

		private bool _canOverheal;

		private Timer _overHealTimer;

		private List<WeaponType> knives;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void AfterFullInitialization()
		{
		}

		private void SpawnFollowers()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void FireAllKnives()
		{
		}

		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}

		private void OverhealTrigger(float value, float rawValue)
		{
		}
	}
}
