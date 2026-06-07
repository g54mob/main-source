using UnityEngine;

namespace SuperTiled2Unity
{
	public class SuperMap : MonoBehaviour
	{
		[ReadOnly]
		public string m_Version;

		[ReadOnly]
		public string m_TiledVersion;

		[ReadOnly]
		public MapOrientation m_Orientation;

		[ReadOnly]
		public MapRenderOrder m_RenderOrder;

		[ReadOnly]
		public int m_Width;

		[ReadOnly]
		public int m_Height;

		[ReadOnly]
		public int m_TileWidth;

		[ReadOnly]
		public int m_TileHeight;

		[ReadOnly]
		public int m_HexSideLength;

		[ReadOnly]
		public StaggerAxis m_StaggerAxis;

		[ReadOnly]
		public StaggerIndex m_StaggerIndex;

		[ReadOnly]
		public bool m_Infinite;

		[ReadOnly]
		public Color m_BackgroundColor;

		[ReadOnly]
		public int m_NextObjectId;

		[ReadOnly]
		public ImportErrors m_ImportErrors;

		public Vector3Int TiledIndexToGridCell(int index, int offset_x, int offset_y, int stride)
		{
			return default(Vector3Int);
		}

		private Vector3Int TiledCellToGridCell(int x, int y)
		{
			return default(Vector3Int);
		}
	}
}
