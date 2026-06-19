using Pug.UnityExtensions;
using PugTilemap;

public class RemoteExplosive : EntityMonoBehaviour
{
	protected override void OnShow()
	{
		Manager.multiMap.SetHiddenTile(base.WorldPosition.RoundToInt2(), 4, TileType.circuitPlate, 0);
		base.OnShow();
	}

	protected override void OnHide()
	{
		Manager.multiMap.ClearHiddenTileOfType(base.WorldPosition.RoundToInt2(), TileType.circuitPlate);
		base.OnHide();
	}

	public void AE_bounceAudio()
	{
	}

	protected override void OnDeath()
	{
	}
}
