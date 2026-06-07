using System;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DPointControllerObject : Slicer2DControllerObject
	{
		public enum SliceRotation
		{
			Random = 0,
			Vertical = 1,
			Horizontal = 2
		}

		public SliceRotation sliceRotation;

		public void Update(Vector2 pos)
		{
		}

		private void PointSlice(Vector2 pos)
		{
		}

		public void Draw(Transform transform)
		{
		}
	}
}
