using UnityEngine;

public class TutorialEvent_SetBiomeConfiguration : TutorialEvent
{
	[SerializeField]
	private TileGenConfiguration targetConfiguration;

	[SerializeField]
	private TileGenerator tileGenerator;

	[SerializeField]
	private bool regenerateTileStack;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private TileStack tileStack;

	[SerializeField]
	private bool discardCurrentTile;

	public override void Begin()
	{
		tileGenerator.SetConfiguration(targetConfiguration);
		if (!regenerateTileStack)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			tileStack.DiscardStackedTile(1, replace: true);
			if (discardCurrentTile)
			{
				inputRouter.DiscardCurrentPreviewTile(refillStack: true);
			}
		}
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
		Begin();
	}
}
