using System;
using System.Collections.Generic;

namespace Assets.Scripts.PlanetStudio.Brush.Events
{
	public class BrushStrokeCompletedEventArgs : EventArgs
	{
		public IReadOnlyList<int> TextureIndices { get; }

		public BrushStrokeCompletedEventArgs(IEnumerable<int> textureIndices)
		{
			TextureIndices = new List<int>(textureIndices);
		}
	}
}
