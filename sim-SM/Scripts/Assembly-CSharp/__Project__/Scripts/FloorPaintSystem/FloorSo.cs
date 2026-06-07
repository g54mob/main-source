using MyBox;
using UnityEngine;
using UnityEngine.Localization;

namespace __Project__.Scripts.FloorPaintSystem
{
	[CreateAssetMenu(fileName = "Customization", menuName = "Floor", order = 0)]
	public class FloorSo : ScriptableObject
	{
		public int floorId;

		public FloorTextureData textureData;

		[Separator("General Setup", false)]
		public LocalizedString LocalizedName;

		public Sprite FloorIcon;

		public int AtlasIndex;

		public Vector2Int AtlasPosition;

		public PaintableFloor floorPrefab;

		[Separator("Purchase Info", false)]
		public float Cost;

		public int ProductAmount;

		public string FloorBoxName => null;
	}
}
