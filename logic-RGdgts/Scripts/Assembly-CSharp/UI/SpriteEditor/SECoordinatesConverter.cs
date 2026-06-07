using System.Collections.Generic;
using UnityEngine;

namespace UI.SpriteEditor
{
	public class SECoordinatesConverter
	{
		public Vector2 ConvertZoomCoordToFullImageCoord(Vector2 zoomCoords, int zoomAreaSize, int numberPixelsInZoom)
		{
			return default(Vector2);
		}

		public List<Vector2> ConvertZoomCordsToFullImageCoords(List<Vector2Int> zoomCoords, int zoomAreaSize, int numberPixelInZoom)
		{
			return null;
		}

		public Vector2Int ConvertFullToZoomCoord(Vector2Int fullC, int zoomAreaSize, int numberPixelsInZoom)
		{
			return default(Vector2Int);
		}

		public int ConvertFullImageCoordToAssetIndex(Vector2 coords, Vector2Int fullImageSize)
		{
			return 0;
		}

		public List<int> ConvertFullImageCoordsToAssetIndices(List<Vector2Int> coords, Vector2Int fullImageSize)
		{
			return null;
		}

		public Vector2Int ConvertAssetIndexToImageCoord(int index, Vector2Int fullImageSize)
		{
			return default(Vector2Int);
		}

		public List<Vector2Int> ConvertAssetIndicesToImageCoords(List<int> indices, Vector2Int fullImageSize)
		{
			return null;
		}

		public Texture2D ConvertPixelIndexArrayToTexture(Color[] colorArray, Vector2Int fullImageSize)
		{
			return null;
		}
	}
}
