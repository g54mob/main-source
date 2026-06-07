using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects
{
	public class Accessory : Equipment
	{
		private ModifierStats _modifierStats;

		public WeaponData CurrentAccessoryData { get; private set; }

		public void Init(CharacterController characterController, WeaponType accessoryType)
		{
		}

		public virtual void OnAccessoryAddedToEquipment()
		{
		}

		public virtual void OnAccessoryRemovedFromEquipment()
		{
		}

		public void Apply()
		{
		}

		private void ApplyToCharacter(CharacterController character)
		{
		}

		public override bool LevelUp(bool skipFire = false)
		{
			return false;
		}

		public override void Cleanup()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override void MakeLevelOne()
		{
		}

		protected override Dictionary<WeaponType, JArray> GetDataDictionary()
		{
			return null;
		}

		private void CleanJsonModifierStats()
		{
		}
	}
}
