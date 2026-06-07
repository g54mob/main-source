using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtFloatingOrbitVisual : MonoBehaviour
	{
		public SgtLength Thickness;

		public int Points;

		public Gradient Colors;

		[NonSerialized]
		private MeshFilter cachedMeshFilter;

		[NonSerialized]
		private bool cachedMeshFilterSet;

		[NonSerialized]
		private Mesh visualMesh;

		[NonSerialized]
		private List<Vector3> positions;

		[NonSerialized]
		private List<Vector2> coords;

		[NonSerialized]
		private List<Color> colors;

		[NonSerialized]
		private List<int> indices;

		public void Draw(SgtFloatingOrbit orbit)
		{
		}
	}
}
