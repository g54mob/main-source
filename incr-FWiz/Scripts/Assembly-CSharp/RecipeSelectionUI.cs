using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RecipeSelectionUI : MonoBehaviour
{
	private Crafter _crafter;

	[SerializeField]
	private OnPressOutsideListener _onClickOutsideListener;

	[SerializeField]
	private RecipeButtonUI _recipeButtonUIPrefab;

	[SerializeField]
	private RecipeButtonUI _demoLockedRecipeButtonUIPrefab;

	[SerializeField]
	private Transform _recipeButtonParent;

	private List<RecipeButtonUI> _recipeButtons;

	public event Action AnnounceEnd
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

	public void Initiate(Crafter crafter)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnSelectRecipe(Recipe recipe)
	{
	}

	public void Cancel()
	{
	}
}
