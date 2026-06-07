using System.Collections.Generic;

namespace Assets.Scripts.PlanetStudio.Brush
{
	public class BrushPixelData
	{
		public List<BrushPixelFaceData> Faces { get; }

		public BrushPixelData()
		{
			Faces = new List<BrushPixelFaceData>();
		}

		public void Initialize()
		{
			Faces.Clear();
		}
	}
}
