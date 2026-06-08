using UnityEngine;

public class TutorialEvent_ReplaceStackedTile : TutorialEvent
{
	[SerializeField]
	private Tile replacementTile;

	[SerializeField]
	private int stackIndex;

	[SerializeField]
	private bool discardCurrentTile;

	[SerializeField]
	private TileStack tileStack;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private TileFactory tileFactory;

	public override void Begin()
	{
		if (!(replacementTile is QuestTile))
		{
			Tile tile = Object.Instantiate(replacementTile);
			tileFactory.InitializePrebuiltTile(tile);
			tileStack.ReplaceStackedTile(stackIndex, tile);
			Object.Destroy(tile.gameObject);
		}
		else
		{
			tileStack.ReplaceStackedTile(stackIndex, replacementTile);
		}
		if (discardCurrentTile)
		{
			inputRouter.DiscardCurrentPreviewTile(refillStack: true);
		}
	}

	public override void Finish()
	{
	}

	public override void Skip()
	{
	}
}
