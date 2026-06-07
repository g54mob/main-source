using System.Collections.Generic;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Data.Variables.Recipes;
using NaughtyAttributes;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Unlock Recipe", fileName = "UnlockRecipeTechTreeNodeBehaviour")]
	public class UnlockRecipeTechTreeNodeBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private UnlockedRecipesPersistentSO _unlockedRecipesPersistentSO;

		[SerializeField]
		private List<RecipeData> recipeDatas;

		[Button(null, EButtonEnableMode.Always)]
		public override void Unlock()
		{
			foreach (RecipeData recipeData in recipeDatas)
			{
				_unlockedRecipesPersistentSO.TryUnlockRecipe(recipeData);
			}
		}

		public override void RefunableReUnlock()
		{
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = null;
			return false;
		}
	}
}
