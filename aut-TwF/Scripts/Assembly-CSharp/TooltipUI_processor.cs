using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipUI_processor : TooltipUI
{
	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private FillBar fillBar;

	private Processor processor;

	private bool setupWorldObject = true;

	private void Update()
	{
		if ((bool)processor.SelectedRecipe && processor.CurrentProcessingRecipeTime < processor.SelectedRecipe.ProcessingTime)
		{
			fillBar.SetBarValue(processor.CurrentProcessingRecipeTime / processor.SelectedRecipe.ProcessingTime);
		}
		else
		{
			fillBar.SetBarValue(0f);
		}
	}

	public override void Setup(Dictionary<string, object> data)
	{
		processor = data["processor"] as Processor;
		iconImage.sprite = processor.SelectedRecipe.Output.Resource.Image;
		fillBar.SetBarMaxValue(1f);
		fillBar.SetBarValue(processor.CurrentProcessingRecipeTime / processor.SelectedRecipe.ProcessingTime);
		if (setupWorldObject)
		{
			WorldObjectUI component = GetComponent<WorldObjectUI>();
			component.FollowTarget = processor.gameObject;
			component.Offset += processor.PlacementComponent.GetCenter() - processor.transform.position;
			setupWorldObject = false;
		}
		processor.PlacementComponent.onPlace += OnPlaceProcessor;
	}

	private void OnPlaceProcessor(PlacementComponent component)
	{
		WorldObjectUI component2 = GetComponent<WorldObjectUI>();
		Vector3 zero = Vector3.zero;
		zero.y = component2.Offset.y;
		zero += processor.PlacementComponent.GetCenter() - processor.transform.position;
		component2.Offset = zero;
	}
}
