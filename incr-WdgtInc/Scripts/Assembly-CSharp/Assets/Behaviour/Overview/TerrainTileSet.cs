using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Behaviour.Overview
{
	public class TerrainTileSet : MonoBehaviour
	{
		[SerializeField]
		public float DetailChance;

		[field: SerializeField]
		public byte TileID { get; private set; }

		[field: SerializeField]
		public TileBase BaseSprite { get; private set; }

		[field: SerializeField]
		public TileBase[] DetailSprites { get; private set; }
	}
}
