using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Os.Utils
{
	public static class UnityFunctions
	{
		private struct HirearchyEnumerator : IEnumerator<Transform>, IEnumerator, IDisposable, IEnumerable<Transform>, IEnumerable
		{
			private int siblingIndex;

			private int siblingCount;

			private int depth;

			private bool includeInactive;

			public Transform transform;

			public Transform parent;

			public Transform Current => null;

			object IEnumerator.Current => null;

			public HirearchyEnumerator(Transform t, bool includeInactive)
			{
				siblingIndex = 0;
				siblingCount = 0;
				depth = 0;
				this.includeInactive = false;
				transform = null;
				parent = null;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}

			IEnumerator<Transform> IEnumerable<Transform>.GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			public override string ToString()
			{
				return null;
			}
		}

		public static T GetNewObject<T>(string name, Transform parent) where T : Component
		{
			return null;
		}

		public static T GetNewObject<T>(Transform parent) where T : Component
		{
			return null;
		}

		public static GameObject GetNewGameObject(string name, Transform parent)
		{
			return null;
		}

		public static bool InView(this Camera camera, Vector3 worldPos, float margin = 0f)
		{
			return false;
		}

		public static IEnumerable<Transform> EnumerateHirearchy(this Transform t, bool includeInactive)
		{
			return null;
		}
	}
}
