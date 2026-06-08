public interface ITileStateReceiver
{
	void ChangeTileState(TileState targetState);

	void SetRendererLayer(int targetLayer);

	void SetAnimationsRunning(bool animationsRunning);

	void SetTileReference(Tile tile);
}
