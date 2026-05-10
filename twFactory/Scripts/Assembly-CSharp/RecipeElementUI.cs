using UnityEngine;
using UnityEngine.UI;

public class RecipeElementUI : UIListElement
{
	[SerializeField]
	private Image image;

	private TooltipComponent_recipe tooltipComponentRecipe;

	private TooltipComponent_text tooltipComponentText;

	private void Awake()
	{
		tooltipComponentRecipe = GetComponent<TooltipComponent_recipe>();
		tooltipComponentText = GetComponent<TooltipComponent_text>();
	}

	public override void LoadData()
	{
		Recipe recipe = (Recipe)base.Data;
		image.sprite = recipe.Output.Resource.Image;
		if ((bool)tooltipComponentRecipe)
		{
			tooltipComponentRecipe.Recipe = recipe;
		}
		else if ((bool)tooltipComponentText)
		{
			tooltipComponentText.TooltipText = recipe.Output.Resource.DisplayName;
		}
	}

	public void MarkSelected(bool selected)
	{
		GetComponent<ButtonAnimation>().MarkSelected(selected);
	}
}
