using UnityEngine;

namespace DV.Common
{
	public interface IInventoryItemSpec
	{
		bool BelongsToPlayer { get; set; }

		bool ImmuneToDumpster { get; set; }

		bool IsEssential { get; set; }

		string ItemPrefabName { get; }

		string LocalizationKey { get; }

		string LocalizedName { get; }

		string LocalizedDescription { get; }

		GameObject PreviewPrefab { get; set; }

		Bounds PreviewBounds { get; set; }

		Vector3 PreviewRotation { get; }

		Sprite ItemIconSpriteSimple { get; }

		Sprite ItemIconSprite { get; }

		Sprite ItemIconSpriteDropped { get; }

		GameObject GetGameObject();
	}
}
