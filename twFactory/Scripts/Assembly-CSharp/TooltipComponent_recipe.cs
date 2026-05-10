using System.Collections.Generic;

public class TooltipComponent_recipe : TooltipComponent
{
	private Recipe recipe;

	public Recipe Recipe
	{
		get
		{
			return recipe;
		}
		set
		{
			recipe = value;
			InvokeDataChanged();
		}
	}

	protected override Dictionary<string, object> GetData()
	{
		return new Dictionary<string, object> { { "recipe", Recipe } };
	}
}
