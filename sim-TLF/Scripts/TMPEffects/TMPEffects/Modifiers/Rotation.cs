using System;
using UnityEngine;

namespace TMPEffects.Modifiers
{
	[Serializable]
	public struct Rotation
	{
		public Vector3 pivot;

		public Vector3 eulerAngles;

		public Rotation(Vector3 eulerAngles, Vector3 pivot)
		{
			this.eulerAngles = eulerAngles;
			this.pivot = pivot;
		}

		public bool Equals(Rotation other)
		{
			if (pivot.Equals(other.pivot))
			{
				return eulerAngles.Equals(other.eulerAngles);
			}
			return false;
		}
	}
}
