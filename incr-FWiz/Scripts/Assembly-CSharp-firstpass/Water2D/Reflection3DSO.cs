using System;
using UnityEngine;

namespace Water2D
{
	[Serializable]
	public class Reflection3DSO
	{
		public Transform source;

		public Transform reflection;

		public Vector2 displacement;

		public Reflection3DSO(Transform source, Transform reflection, Vector2 displacement)
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
