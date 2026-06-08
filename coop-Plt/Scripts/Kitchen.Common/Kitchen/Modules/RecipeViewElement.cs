using System.Collections.Generic;
using Controllers;
using KitchenData;
using UnityEngine;

namespace Kitchen.Modules
{
	public class RecipeViewElement : Element
	{
		private TextPanelElement Text;

		private InputPromptElement LeftPrompt;

		private InputPromptElement RightPrompt;

		private int CurrentIndex;

		private int CurrentUser;

		public override Bounds BoundingBox
		{
			get
			{
				if (!(Text == null))
				{
					return Text.BoundingBox;
				}
				return default(Bounds);
			}
		}

		public void SetPlayer(int player_id)
		{
			CurrentUser = player_id;
		}

		private void Start()
		{
			if (Text != null)
			{
				Object.Destroy(Text);
			}
			if (LeftPrompt != null)
			{
				Object.Destroy(LeftPrompt);
			}
			if (RightPrompt != null)
			{
				Object.Destroy(RightPrompt);
			}
			Text = Add<TextPanelElement>();
			(LeftPrompt = Add<InputPromptElement>()).Attach(Text);
			(RightPrompt = Add<InputPromptElement>()).Attach(Text, left_attach: false);
			UpdateRecipe();
		}

		public override bool HandleInteraction(InputState state)
		{
			bool flag = false;
			if (state.MenuRight == ButtonState.Pressed)
			{
				CurrentIndex++;
				flag = true;
			}
			if (state.MenuLeft == ButtonState.Pressed)
			{
				CurrentIndex--;
				flag = true;
			}
			if (flag)
			{
				UpdateRecipe();
				return true;
			}
			return false;
		}

		private List<Dish> GetRecipes()
		{
			List<Dish> list = new List<Dish>();
			foreach (Dish currentlyAvailableDish in GameInfo.CurrentlyAvailableDishes)
			{
				if (currentlyAvailableDish.SkipOwnRecipe)
				{
					continue;
				}
				list.Add(currentlyAvailableDish);
				foreach (Dish alsoAddRecipe in currentlyAvailableDish.AlsoAddRecipes)
				{
					if (!list.Contains(alsoAddRecipe))
					{
						list.Add(alsoAddRecipe);
					}
				}
			}
			return list;
		}

		private void UpdateRecipe()
		{
			if (GameInfo.CurrentlyAvailableDishes.Count == 0)
			{
				Text.SetText("Recipes", "Recipes will appear here during the game!");
				return;
			}
			List<Dish> recipes = GetRecipes();
			CurrentIndex = MathsHelpers.Wrap(CurrentIndex, 0, recipes.Count - 1);
			LeftPrompt.SetButtonForUser(Controls.MenuLeft, CurrentUser);
			RightPrompt.SetButtonForUser(Controls.MenuRight, CurrentUser);
			LeftPrompt.SetShown(CurrentIndex > 0);
			RightPrompt.SetShown(CurrentIndex < recipes.Count - 1);
			Text.SetRecipe(recipes[CurrentIndex]);
		}
	}
}
