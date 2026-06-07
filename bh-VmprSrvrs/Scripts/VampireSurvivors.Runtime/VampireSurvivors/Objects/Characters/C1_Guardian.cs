using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Objects.Characters
{
	public class C1_Guardian : CharacterController
	{
		private List<CharacterController> _charactersAffectedByAura;

		private ParticleSystem _guardianParticleSystem;

		private float _timer;

		protected override void OnStop()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void ApplyAuraToPlayer(CharacterController character)
		{
		}

		private void RemoveAuraFromPlayer(CharacterController character)
		{
		}

		public override void DoPostRevivalActions(CharacterController revived, bool instantRevival = false)
		{
		}

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}
	}
}
