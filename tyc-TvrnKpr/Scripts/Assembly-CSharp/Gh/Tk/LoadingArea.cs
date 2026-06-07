using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class LoadingArea : MonoBehaviour
	{
		private float[] _sizes;

		private float[] _cumulativeSizes;

		private float _total;

		private Mesh _mesh;

		private void Start()
		{
		}

		private static float[] GetTriangleSizes(IReadOnlyList<int> triangles, IReadOnlyList<Vector3> vertices)
		{
			return null;
		}

		public Vector3 GetRandomPoint(IRng rng = null)
		{
			return default(Vector3);
		}
	}
}
