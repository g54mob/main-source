using Data.FactoryFloor.Maps;
using UnityEngine;

namespace Data.Minimap
{
	public class MinimapData
	{
		public Vector2 Center;

		public Bounds MapBounds;

		public RenderTexture FullMapOverlayTexture { get; private set; }

		public RenderTexture[] MinimapTextures { get; private set; }

		public IslandObject[] IslandObjects { get; private set; }

		public MinimapData(Bounds mapBounds, RenderTexture[] minimapTextures, IslandObject[] islandObjects, RenderTexture fullMapOverlayTexture)
		{
			MapBounds = mapBounds;
			MinimapTextures = minimapTextures;
			IslandObjects = islandObjects;
			Center = new Vector2(mapBounds.center.x, mapBounds.center.z);
			FullMapOverlayTexture = fullMapOverlayTexture;
		}

		public Vector2 WorldPosToLocalPos(Vector3 worldPos)
		{
			return new Vector2(worldPos.x, worldPos.z) - Center;
		}

		public Vector3 LocalPosToWorldPos(Vector2 localPos)
		{
			return new Vector3(localPos.x + Center.x, 0f, localPos.y + Center.y);
		}
	}
}
