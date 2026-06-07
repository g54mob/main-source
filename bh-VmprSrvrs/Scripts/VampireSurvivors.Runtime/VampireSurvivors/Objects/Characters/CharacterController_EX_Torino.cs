using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterController_EX_Torino : CharacterController
	{
		private MorphVFX _morphVFX;

		private Weapon _groundHitWeapon;

		private bool _canRetaliate;

		private int _morphLevel;

		private List<WeaponType> _magicWeapons;

		private void SyncedMorph()
		{
		}

		public override void LevelUp()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}

		[Command]
		public void Morph()
		{
		}

		private void MakeMorphVFX()
		{
		}

		private void MorphToSecondForm()
		{
		}

		private void MorphToThirdForm()
		{
		}

		private void SetBodyOffset(float x, float y)
		{
		}
	}
}
