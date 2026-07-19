using System;
using UnityEngine;

namespace UniGLTF
{
	public static class MonoBehaviourComparator
	{
		public static bool AssertAreEquals(GameObject l, GameObject r)
		{
			if (l.name == r.name && AssertAreEquals(l, r, (Transform[] x, Transform[] y) => AssertAreEquals(x[0], y[0])) && AssertAreEquals(l, r, (MeshFilter[] x, MeshFilter[] y) => AssertAreEquals(x[0], y[0])) && AssertAreEquals(l, r, (MeshRenderer[] x, MeshRenderer[] y) => AssertAreEquals(x[0], y[0])))
			{
				return AssertAreEquals(l, r, (SkinnedMeshRenderer[] x, SkinnedMeshRenderer[] y) => AssertAreEquals(x[0], y[0]));
			}
			return false;
		}

		public static bool AssertAreEquals<T>(GameObject l, GameObject r, Func<T[], T[], bool> pred) where T : Component
		{
			T[] components = l.GetComponents<T>();
			T[] components2 = r.GetComponents<T>();
			if (components.Length != components2.Length)
			{
				return false;
			}
			if (components.Length == 0)
			{
				return true;
			}
			return pred(components, components2);
		}

		public static bool AssertAreEquals(Transform l, Transform r)
		{
			if (l.localPosition == r.localPosition && l.localRotation == r.localRotation)
			{
				return l.localScale == r.localScale;
			}
			return false;
		}

		public static bool AssertAreEquals(MeshFilter l, MeshFilter r)
		{
			throw new NotImplementedException();
		}

		public static bool AssertAreEquals(MeshRenderer l, MeshRenderer r)
		{
			throw new NotImplementedException();
		}

		public static bool AssertAreEquals(SkinnedMeshRenderer l, SkinnedMeshRenderer r)
		{
			throw new NotImplementedException();
		}

		public static bool AssetAreEquals(Texture2D l, Texture2D r)
		{
			throw new NotImplementedException();
		}
	}
}
