using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class LEM_Fibonacci1_Weapon : LEM_BaseWeapon
	{
		protected virtual float WeaponTriggerChance => 0f;

		protected virtual float WeaponTriggerLuckBonus => 0f;

		protected virtual int NumWeaponsToTrigger => 0;

		public List<int> FibonacciSequence { get; private set; }

		public List<float2> FibonacciOffsets { get; private set; }

		public float FibSeqLength => 0f;

		public virtual float StartingAngle => 0f;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		private void CreateFibonacciSequence()
		{
		}

		private void CreateFibonnaciOffsets()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void CheckForWeaponTrigger()
		{
		}

		protected void TriggerOtherWeapons(int numWeapons)
		{
		}

		private void RemoveProblematicWeapons(ref List<Equipment> weapons)
		{
		}

		private void TriggerWeapon(Weapon weapon)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
