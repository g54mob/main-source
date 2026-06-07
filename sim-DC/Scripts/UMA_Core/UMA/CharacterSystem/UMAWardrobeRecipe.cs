using System.Collections.Generic;
using UnityEngine;

namespace UMA.CharacterSystem
{
	public class UMAWardrobeRecipe : UMATextRecipe
	{
		[SerializeField]
		[Tooltip("For tracking incompatible items. Not automatic.")]
		public List<UMAWardrobeRecipe> IncompatibleRecipes;

		[SerializeField]
		[Tooltip("The system does not use this field. Use it for whatever you need.")]
		public string UserField;

		[SerializeField]
		public string replaces;

		public bool HasReplaces => false;
	}
}
