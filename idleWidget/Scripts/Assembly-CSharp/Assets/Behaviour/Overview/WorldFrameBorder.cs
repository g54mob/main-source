using Assets.Source.World;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Behaviour.Overview
{
	public class WorldFrameBorder : MonoBehaviour
	{
		[SerializeField]
		private Tilemap _tiles;

		[SerializeField]
		private TileBase _tile;

		public void AddFrame(WorldFrame frame)
		{
			_tiles.SetTile(new Vector3Int(frame.Position.x, frame.Position.y), _tile);
		}

		public void RemoveFrame(WorldFrame frame)
		{
			_tiles.SetTile(new Vector3Int(frame.Position.x, frame.Position.y), null);
		}
	}
}
