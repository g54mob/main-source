using Factory;
using Libs;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	public class TileAppend
	{
		public Vector2Int RelativeAddr;

		public string PartsName;

		public eTileAppendKind Kind;

		public eTileAppendKind Disable;

		private eTileAppendKind Remain => default(eTileAppendKind);

		public TileAppend(PortTileAppendType type = PortTileAppendType.None, Vector2Int? relativeAddr = null)
		{
		}

		public PortTileAppendType GetPortTileAppendType()
		{
			return default(PortTileAppendType);
		}

		public bool IsEnable(eTileAppendKind kind)
		{
			return false;
		}

		public void SetDisable(eTileAppendKind kind)
		{
		}

		public void UnsetDisable(eTileAppendKind kind)
		{
		}

		public bool Any(eTileAppendKind kinds)
		{
			return false;
		}

		public (TileLayer, TileLayer) GetPortTileLayer()
		{
			return default((TileLayer, TileLayer));
		}

		public static eTileAppendKind PortRotToKind(Dir.Rot rot)
		{
			return default(eTileAppendKind);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
