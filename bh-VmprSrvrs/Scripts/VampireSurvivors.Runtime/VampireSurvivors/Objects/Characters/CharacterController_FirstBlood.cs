using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterController_FirstBlood : CharacterController
	{
		protected float _spawnPROPS_Delay;

		protected float _spawnPROPS_Time;

		protected Timer _PROPSactivationTimer;

		protected List<PropType> _PROPSTypes;

		protected bool _spawnExtraProps;

		public override void AfterFullInitialization()
		{
		}

		public override void OnDeath()
		{
		}

		private void PlayDeathSound()
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
	}
}
