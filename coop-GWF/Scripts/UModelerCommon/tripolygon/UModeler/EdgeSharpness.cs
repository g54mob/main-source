using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class EdgeSharpness
	{
		public string name;

		public float sharpness;

		[SerializeField]
		private List<Edge> edges_ = new List<Edge>();

		public void AddEdge(Edge edge)
		{
			edges_.Add(edge);
		}
	}
}
