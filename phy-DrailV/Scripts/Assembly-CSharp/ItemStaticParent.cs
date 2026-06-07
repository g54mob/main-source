using DV.CabControls;
using UnityEngine;

public class ItemStaticParent : MonoBehaviour
{
	public virtual void ItemParented(ItemBase item, ItemReparentingBase reparenting)
	{
	}

	public virtual bool ValidParentFor(ItemBase item)
	{
		return item != null;
	}
}
