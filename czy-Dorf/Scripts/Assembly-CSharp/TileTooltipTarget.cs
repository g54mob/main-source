public class TileTooltipTarget : TooltipTarget
{
	private Tile tile;

	private void Awake()
	{
		tile = GetComponent<Tile>();
	}

	protected override string GetTooltipText()
	{
		return LocalizationManager.Instance.GetLocalizedValue("tooltip_tileFitInfo").Replace("[x]", tile.FittingPlacedNeighbors.Count.ToString());
	}
}
