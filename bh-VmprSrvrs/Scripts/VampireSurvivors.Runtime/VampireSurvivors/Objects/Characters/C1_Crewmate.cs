using System.Collections.Generic;
using Coherence.Toolkit;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class C1_Crewmate : CharacterController
	{
		private List<WeaponType> _addedBonuses;

		private Dictionary<WeaponType, float> _powerUpBonusList;

		private Dictionary<WeaponType, float> _weaponBonusList;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void OnLevelUpCompleted()
		{
		}

		private void HandleEquipment(Equipment equipment)
		{
		}

		[Command]
		public void AddValue(int bonus, float bonusValue)
		{
		}
	}
}
