using Pug.Sprite;
using UnityEngine;

public class RootPlant : Plant
{
	public SpriteObject BottomSprite;

	public override void OnOccupied()
	{
		BottomSprite.color = new Color(1f, 1f, 1f, 0f);
		base.OnOccupied();
	}

	public override void ReachedFinalStage()
	{
		BottomSprite.color = new Color(1f, 1f, 1f, 1f);
		base.ReachedFinalStage();
	}
}
