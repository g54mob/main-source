using DV.CabControls;

public class ItemStaticParentPaintStation : ItemStaticParent
{
	public override bool ValidParentFor(ItemBase item)
	{
		if (!base.ValidParentFor(item))
		{
			return false;
		}
		return item.GetComponent<PaintStationParentableItem>() != null;
	}
}
