using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipUI_recipe : TooltipUI
{
	[SerializeField]
	private TextMeshProUGUI recipeName;

	[SerializeField]
	private UIList inputList;

	[SerializeField]
	private UIList outputList;

	public override void Setup(Dictionary<string, object> data)
	{
		Recipe recipe = data["recipe"] as Recipe;
		if ((bool)recipe)
		{
			recipeName.text = recipe.Output.Resource.DisplayName;
			List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
			Cost[] input = recipe.Input;
			foreach (Cost value in input)
			{
				list.Add(new Dictionary<string, object>
				{
					{ "cost", value },
					{ "processingTime", recipe.ProcessingTime }
				});
			}
			inputList.LoadList(list);
			List<Dictionary<string, object>> list2 = new List<Dictionary<string, object>>();
			list2.Add(new Dictionary<string, object>
			{
				{ "cost", recipe.Output },
				{ "processingTime", recipe.ProcessingTime }
			});
			outputList.LoadList(list2);
			GetComponent<AutoTransformRebuild>().RebuildTransform();
		}
		else
		{
			recipeName.text = "-";
		}
	}
}
