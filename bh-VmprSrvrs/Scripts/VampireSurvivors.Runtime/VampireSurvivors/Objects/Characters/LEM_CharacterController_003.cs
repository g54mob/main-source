using UnityEngine;

namespace VampireSurvivors.Objects.Characters
{
	public class LEM_CharacterController_003 : LEM_CharacterController_Base
	{
		[SerializeField]
		private float triggerChance;

		[SerializeField]
		private float bossHealthMultiplier;

		public override void AfterFullInitialization()
		{
		}
	}
}
