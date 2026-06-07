using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Clockwork_Weapon : Weapon
	{
		protected bool _initialisedParticles;

		protected int _orologionCount;

		protected float _oroBonus;

		protected List<WeaponType> _otherClockWeapons;

		protected List<Weapon> _foundClockWeapons;

		protected override void Awake()
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public virtual void FireProjectiles(Vector2 pos)
		{
		}

		private void UpdateOrologionCount()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp(bool skipFire)
		{
			return false;
		}

		protected void FireOthers()
		{
		}

		public void FindClockWeapons()
		{
		}
	}
}
