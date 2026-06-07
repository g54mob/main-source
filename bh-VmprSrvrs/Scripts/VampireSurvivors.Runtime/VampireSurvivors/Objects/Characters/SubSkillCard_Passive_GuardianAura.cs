using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class SubSkillCard_Passive_GuardianAura : CharacterSkillCard_Base
	{
		private List<CharacterController> _charactersAffectedByAura;

		private ParticleSystem _guardianParticleSystem;

		private float _timer;

		public SubSkillCard_Passive_GuardianAura(ArcanaType type)
			: base(default(ArcanaType))
		{
		}

		public override void InitialActivate()
		{
		}

		public override void Update()
		{
		}

		private void ApplyAuraToPlayer(CharacterController character)
		{
		}

		private void RemoveAuraFromPlayer(CharacterController character)
		{
		}
	}
}
