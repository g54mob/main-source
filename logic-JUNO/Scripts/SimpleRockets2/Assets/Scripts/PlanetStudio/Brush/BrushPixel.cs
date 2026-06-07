using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Brush
{
	public class BrushPixel
	{
		public int Index { get; private set; }

		public Vector2i Position { get; private set; }

		public float Strength { get; private set; }

		public void Initialize(int index, Vector2i pixelPosition, float strength)
		{
			Index = index;
			Position = pixelPosition;
			Strength = strength;
		}
	}
}
