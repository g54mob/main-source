using System;
using System.Collections.Generic;
using UnityEngine;

namespace FluffyUnderware.Curvy.Components
{
	[Serializable]
	public class GLSlotData
	{
		[SerializeField]
		public CurvySpline Spline;

		public Color LineColor;

		public List<Vector3[]> VertexData;

		public void GetVertexData()
		{
		}

		public void Render(Material mat)
		{
		}
	}
}
