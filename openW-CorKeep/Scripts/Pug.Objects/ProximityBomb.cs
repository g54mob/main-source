public class ProximityBomb : EntityMonoBehaviour
{
	public override void OnOccupied()
	{
		PlaySpriteObjectAnimation(-601574123);
		base.OnOccupied();
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == -1225259135)
		{
			Manager.audio.PlaySfx(SfxTableID.proximityBombTick, base.RenderPosition);
		}
		base.HandleAnimationTrigger(animID);
	}
}
