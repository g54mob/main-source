using System.Collections.Generic;
using UnityEngine;

public abstract class SubItemPropertiesProviderBase : ScriptableObject
{
	public abstract bool TryReturnSubItemProperties(out ItemProperties itemProperties, Item item = null);

	public abstract void ReturnAllSubItemProperties(List<ItemProperties> subItemProperties);
}
