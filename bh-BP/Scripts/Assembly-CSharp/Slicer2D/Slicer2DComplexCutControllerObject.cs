using System;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D
{
	[Serializable]
	public class Slicer2DComplexCutControllerObject : Slicer2DControllerObject
	{
		private List<Vector2D> pointsList;

		public float cutSize;

		public float minVertexDistance;

		public List<Vector2D> GetList()
		{
			return null;
		}

		public void Update(Vector2 pos)
		{
		}

		public void Draw(Transform transform)
		{
		}
	}
}
