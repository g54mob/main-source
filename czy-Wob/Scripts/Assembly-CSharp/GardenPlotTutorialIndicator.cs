using UnityEngine;

public class GardenPlotTutorialIndicator : WorldSpaceBillboard
{
	public GameObject tutorialArrowEat;

	public GameObject tutorialArrowPlant;

	private float defaultYOffset = 2f;

	protected override void AwakeBehavior()
	{
		base.AwakeBehavior();
		SetDefaultOffset();
		tutorialArrowEat.SetActive(value: false);
		tutorialArrowPlant.SetActive(value: false);
	}

	public void SetDefaultOffset()
	{
		worldspaceOffset.y = defaultYOffset;
	}
}
