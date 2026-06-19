using OUSystems.Basics.UI;
using UnityEngine;

public class CrafterOptionsUI : MonoBehaviour
{
	private CrafterUI _crafterUI;

	private Crafter _crafter;

	[SerializeField]
	private ClickListener _recipeSelectButton;

	[SerializeField]
	private HoldListener _destroyButton;

	private int _hideStacks;

	public void Initiate(CrafterUI crafterUI, Crafter crafter)
	{
	}

	private void OnDestroy()
	{
	}

	public void OnRecipeSelectButton()
	{
	}

	public void OnDestroyButton()
	{
	}

	public void IncrementHideStacks()
	{
	}

	public void DecrementHideStacks()
	{
	}

	private void Show()
	{
	}

	private void Hide()
	{
	}
}
