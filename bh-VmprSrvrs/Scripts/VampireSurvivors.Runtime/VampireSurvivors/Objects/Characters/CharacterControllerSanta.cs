using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerSanta : CharacterController
	{
		private List<string> _WeaponIcons;

		private bool _AddedHiddenWeapons;

		public override void AfterFullInitialization()
		{
		}

		public override void GetTreasureModifier()
		{
		}

		private void CriticalHP()
		{
		}

		private void OnCriticalHp()
		{
		}

		[Command]
		public void TriggerOnCriticalHp(long startingSimFrame)
		{
		}

		public override void LevelUp()
		{
		}

		private Weapon AddHiddenWeaponAndRemoveEvolution(WeaponType type)
		{
			return null;
		}

		public void ShowRings(ref List<string> frames)
		{
		}
	}
}
