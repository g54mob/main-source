using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterController_EX_Ziappunta : CharacterController
	{
		protected float _spawnPROPS_Delay;

		protected float _spawnPROPS_Time;

		protected Timer _PROPSactivationTimer;

		protected List<PropType> _PROPSTypes;

		protected bool _spawnExtraProps;

		[Sync]
		public int SpecialChestsSpawned;

		public override void AfterFullInitialization()
		{
		}

		protected float PROPSSpawnInterval()
		{
			return 0f;
		}

		protected override void OnUpdate()
		{
		}

		protected void SpawnProps()
		{
		}

		public bool CheckAchievementStats()
		{
			return false;
		}
	}
}
