using UnityEngine;

namespace HQFPSTemplate.Surfaces
{
	public class TerrainInfo
	{
		private Terrain m_Terrain;

		private TerrainLayer[] m_Layers;

		public Vector3 Position { get; private set; }

		public TerrainData Data { get; private set; }

		public TerrainInfo(Terrain terrain)
		{
			Position = terrain.GetPosition();
			m_Terrain = terrain;
			Data = terrain.terrainData;
			m_Layers = Data.terrainLayers;
		}

		public Texture GetSplatmapPrototypeId(int i)
		{
			if (m_Layers != null && m_Layers.Length > i)
			{
				return m_Layers[i].diffuseTexture;
			}
			return null;
		}

		public float[,,] GetAlphamaps(int x, int y, int width, int height)
		{
			return m_Terrain.terrainData.GetAlphamaps(x, y, width, height);
		}
	}
}
