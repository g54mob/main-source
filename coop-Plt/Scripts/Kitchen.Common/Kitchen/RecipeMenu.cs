using Kitchen.Modules;
using UnityEngine;

namespace Kitchen
{
	public class RecipeMenu : Menu<MenuAction>
	{
		public override bool RequiresBackingPanel { get; protected set; }

		public RecipeMenu(Transform container, ModuleList module_list)
			: base(container, module_list)
		{
		}

		public override void Setup(int player_id)
		{
			RecipeViewElement recipeViewElement = ModuleDirectory.Add<RecipeViewElement>(Container, new Vector2(0f, 0f));
			recipeViewElement.SetPlayer(player_id);
			ModuleList.AddModule(recipeViewElement, recipeViewElement.transform.localPosition.ToFlat());
		}
	}
}
