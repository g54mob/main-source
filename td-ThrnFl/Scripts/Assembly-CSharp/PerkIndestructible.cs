using UnityEngine;

public class PerkIndestructible : MonoBehaviour
{
	[SerializeField]
	private Equippable indestructiblePerk;

	private void Start()
	{
		if (PerkManager.IsEquipped(indestructiblePerk))
		{
			TaggedObject componentInChildren = GetComponentInChildren<TaggedObject>();
			if ((bool)componentInChildren)
			{
				componentInChildren.RemoveTag(TagManager.ETag.PlayerOwned);
			}
		}
		Object.Destroy(this);
	}
}
