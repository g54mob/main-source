using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class ConstructDCAFromScratch : MonoBehaviour
	{
		public string raceName;

		public RuntimeAnimatorController raceController;

		public List<UMAWardrobeRecipe> wardrobeItems;

		public Color hairColor;

		public bool LoadFromAvatarDef;

		[TextArea(3, 12)]
		public string AvatarDef;

		private void Start()
		{
		}

		public void IsCreated(UMAData u)
		{
		}
	}
}
