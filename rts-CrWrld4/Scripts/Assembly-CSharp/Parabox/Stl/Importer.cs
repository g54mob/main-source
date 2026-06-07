using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

namespace Parabox.Stl
{
	public static class Importer
	{
		private struct Facet
		{
			public Vector3 normal;

			public Vector3 a;

			public Vector3 b;

			public Vector3 c;

			public Facet(Vector3 normal, Vector3 a, Vector3 b, Vector3 c)
			{
				this.normal = default(Vector3);
				this.a = default(Vector3);
				this.b = default(Vector3);
				this.c = default(Vector3);
			}

			public override string ToString()
			{
				return null;
			}
		}

		private const int MaxFacetsPerMesh16 = 21845;

		private const int MaxFacetsPerMesh32 = 715827882;

		private const int SOLID = 1;

		private const int FACET = 2;

		private const int OUTER = 3;

		private const int VERTEX = 4;

		private const int ENDLOOP = 5;

		private const int ENDFACET = 6;

		private const int ENDSOLID = 7;

		private const int EMPTY = 0;

		public static Mesh[] Import(string path, CoordinateSpace space = CoordinateSpace.Right, UpAxis axis = UpAxis.Y, bool smooth = false, IndexFormat indexFormat = IndexFormat.UInt32)
		{
			return null;
		}

		private static IEnumerable<Facet> ImportBinary(string path)
		{
			return null;
		}

		private static Facet GetFacet(this BinaryReader binaryReader)
		{
			return default(Facet);
		}

		private static Vector3 GetVector3(this BinaryReader binaryReader)
		{
			return default(Vector3);
		}

		private static int ReadState(string line)
		{
			return 0;
		}

		private static IEnumerable<Facet> ImportAscii(string path)
		{
			return null;
		}

		private static Vector3 StringToVec3(string str)
		{
			return default(Vector3);
		}

		private static bool IsBinary(string path)
		{
			return false;
		}

		private static Mesh[] ImportSmoothNormals(IEnumerable<Facet> faces, CoordinateSpace modelCoordinateSpace, UpAxis modelUpAxis, IndexFormat indexFormat)
		{
			return null;
		}

		private static Mesh[] ImportHardNormals(IEnumerable<Facet> faces, CoordinateSpace modelCoordinateSpace, UpAxis modelUpAxis, IndexFormat indexFormat)
		{
			return null;
		}
	}
}
