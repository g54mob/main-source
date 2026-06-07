using System.Collections.Generic;
using ModApi.Common.SimpleTypes;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Brush
{
	public class BrushPixelFaceData
	{
		public Vector2i BrushCenterPixelPosition { get; private set; }

		public int FaceIndex { get; private set; }

		public List<BrushPixel> PixelData { get; }

		public NativeArray<ColorRGB24> Pixels { get; private set; }

		public Texture2D Texture { get; private set; }

		public BrushPixelFaceData()
		{
			PixelData = new List<BrushPixel>();
		}

		public void Cleanup()
		{
			Texture = null;
			Pixels = default(NativeArray<ColorRGB24>);
		}

		public void Initialize(int faceIndex, Texture2D texture, Vector2i brushCenterPixelPosition)
		{
			FaceIndex = faceIndex;
			Texture = texture;
			Pixels = texture.GetRawTextureData<ColorRGB24>();
			BrushCenterPixelPosition = brushCenterPixelPosition;
			PixelData.Clear();
		}
	}
}
