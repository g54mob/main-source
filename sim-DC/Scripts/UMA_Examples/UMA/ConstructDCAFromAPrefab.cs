using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class ConstructDCAFromAPrefab : MonoBehaviour
	{
		public string raceName;

		public RuntimeAnimatorController raceController;

		public List<UMAWardrobeRecipe> wardrobeItems;

		public Color hairColor;

		public GameObject DCAPrefab;

		[TextArea(3, 12)]
		public string CharacterString;

		private void Start()
		{
		}
	}
}
