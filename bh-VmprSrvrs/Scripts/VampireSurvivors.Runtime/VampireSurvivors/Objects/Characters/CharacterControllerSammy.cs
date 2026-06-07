using System;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerSammy : CharacterController
	{
		private Action<float> _onCoinPickupCallback;

		private GrangattiWeapon _hungerWeapon;

		private Timer _timeout1;

		private Timer _timeout2;

		private Timer _timeout3;

		public override void AfterFullInitialization()
		{
		}

		public override void OnQuit()
		{
		}

		public override void LevelUp()
		{
		}

		public void OnCoinPickup(float value)
		{
		}
	}
}
