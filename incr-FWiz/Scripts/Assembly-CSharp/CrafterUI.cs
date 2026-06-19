using System;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class CrafterUI : MonoBehaviour
{
	[SerializeField]
	private CrafterProcessViewUI _processView;

	[SerializeField]
	private RecipeSelectionUI _recipesView;

	[SerializeField]
	private EventReference _openSelectMenuSound;

	[SerializeField]
	private EventReference _closeSelectMenuSound;

	private Crafter _crafter;

	private bool _doingRecipeSelect;

	public event Action AnnounceEndRecipeSelect
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

	public event Action AnnounceStartRecipeSelect
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

	public void StartRecipeSelect()
	{
	}

	public void EndRecipeSelect()
	{
	}
}
