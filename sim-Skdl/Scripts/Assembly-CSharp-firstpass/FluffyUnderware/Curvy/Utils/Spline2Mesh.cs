using System.Collections.Generic;
using FluffyUnderware.Curvy.ThirdParty.LibTessDotNet;
using UnityEngine;

namespace FluffyUnderware.Curvy.Utils
{
	public class Spline2Mesh
	{
		public List<SplinePolyLine> Lines;

		public WindingRule Winding;

		public Vector2 UVTiling;

		public Vector2 UVOffset;

		public bool SuppressUVMapping;

		public bool UV2;

		public string MeshName;

		public bool VertexLineOnly;

		private Tess mTess;

		private Mesh mMesh;

		public string Error { get; private set; }

		public bool Apply(out Mesh result)
		{
			result = null;
			return false;
		}

		private bool triangulate()
		{
			return false;
		}

		private static bool polyLineIsValid(SplinePolyLine pl)
		{
			return false;
		}
	}
}
