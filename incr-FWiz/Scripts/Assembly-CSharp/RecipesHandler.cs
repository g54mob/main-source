using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RecipesHandler : MonoBehaviour
{
	private HashSet<Recipe> _recipeSet;

	public static RecipesHandler Instance { get; private set; }

	[field: SerializeField]
	public List<Recipe> RecipesUnlocked { get; private set; }

	public static event Action<Recipe> AnnounceRecipeUnlocked
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Initiate()
	{
	}

	public void LearnRecipe(Recipe recipe)
	{
	}

	public bool HasRecipe(Recipe recipe)
	{
		return false;
	}

	public void UnlockRecipe(Recipe recipe)
	{
	}
}
