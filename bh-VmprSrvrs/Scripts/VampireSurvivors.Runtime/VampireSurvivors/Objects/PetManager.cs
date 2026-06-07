using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects
{
	public class PetManager : GameMonoBehaviour
	{
		private List<PetInstance> _pets;

		private VampireSurvivors.Objects.Characters.CharacterController _owner;

		public void Init(VampireSurvivors.Objects.Characters.CharacterController owner)
		{
		}

		public PetInstance AddPet(Equipment baseEquipment, Equipment hiddenWeapon, SpriteRenderer petSprite, float petOffset)
		{
			return null;
		}

		public List<PetInstance> GetPets()
		{
			return null;
		}

		protected override void OnUpdate()
		{
		}
	}
}
